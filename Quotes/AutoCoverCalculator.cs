using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Baldrich.DBRequest;

namespace EPolicy.Quotes
{
	/// <summary>
	/// Summary description for AutoCoverCalculator.
	/// </summary>
	public class AutoCoverCalculator
	{
		/* Private Variables */
		
		// AUTOCOVER
		private AutoCover AC;
		private AssignedDriver AD;

		// FLAGS
		private bool isRemainder = false;

		// VARIABLES
		private int Remainder;
		private decimal BIFactor;
		private decimal PDFactor;
		private decimal CSLFactor;
		private decimal BI1020;
		private decimal PD5000;
		private decimal SL2500;
		private decimal COMP100;

//		private double biPremium;
//		private double pdPremium;
//		private double cslPremium;
//		private double Factor;
//		private double compRate;
//		private double collRate;
//		private double compValue;

		// LOOKUP VARIABLES
		private string _lookupAge = "";
		private string _lookupSex = "";
		private string _lookupTraining = "";
		private string _lookupOwner = "";
		private string _lookupMaritalStatus = "";
		private string _lookupGoodStanding = "";
		private string _lookupPrimaryUse = "";
		private string _lookupAgeGroup = "";
		private string _lookupCostNet = "";
		//use for Policy only.
		private bool _IsPolicy = false;
			
		// AUTOCOVER DECODED VALUES
		private decimal _ComprehensiveDeductibleDesc;
		private decimal _CollisionDeductibleDesc;
		private string _BodilyInjuryLimitDesc;
		private string _PropertyDamageLimitDesc;
		private string _CombinedSingleLimitDesc;
		private string _MedicalLimitDesc;
		private decimal  _SeatBeltPremium;
		private decimal  _PARPremium;
		private decimal  _LeaseLoanGapDesc;
//		private string _HomeCityDesc;
//		private string _WorkCityDesc; 
//		private string _VehicleMakeDesc;
//		private string _VehicleModelDesc; 
//		private string _VehicleYearDesc;
//		private string _NewUseDesc;
//		private string _VehicleUseDesc;
//		private string _TerritoryDesc;
//		private string _AlarmTypeDesc;

		private bool isCSL
		{
			get 
			{
				return AC.CombinedSingleLimit > 0;
			}
		}

		private bool isBIPD
		{
			get 
			{
				return AC.BodilyInjuryLimit > 0 && AC.PropertyDamageLimit > 0;
			}
		}
		/* Public Methods */
		public AutoCoverCalculator()
		{
			;
		}

		//RPR 2004-03-03
		private int GetAgeBasedOnPeriodAniversary(
			DateTime PeriodAniversary, DateTime BirthDate)
		{
			TimeSpan timeSpan = PeriodAniversary - BirthDate;
			return (int)(((float)timeSpan.Days) / 365.25f);
		}

		//RPR 2004-03-03
		private DateTime GetAniversaryDateFromPeriod(
			int Period, DateTime DateOfPolicyEffectivity)
		{
			if(Period > 1)
			{
				TimeSpan timeToAdd = 
					new TimeSpan((int)(365.25f * (Period - 1)), 0, 0, 0);

				return (DateOfPolicyEffectivity + timeToAdd);
			}
			else
			{
				return DateOfPolicyEffectivity;
			}
		}

		public void SetIsPolicy(bool ispolicy)
		{
			this._IsPolicy = ispolicy;
		}

		public void Calculate(AutoCover AC)
		{
			int Years = 0;
			
			/* INIT AutoCover & Driver */
			this.AC = AC; 
			GetAssignedDriver();
			
			if(this.AD != null) //RPR 2004-03-16
			{
				DecodeAutoCover();

				/* INIT VARIABLES */
				SetTerritoryFactor();
				Years = CalculatePeriodAmounts();
				GetPolicyFactors();
				bool isDoubleInterest = CalcIsDoubleInterest();
				bool isLiability = CalcIsLiability();
				
				//			SetOnlyOperator(Years);  // NOt done on code.. User must select it

				/* CALCULATE */
				//			Loop through all Years
				for (int yr = 1; yr <= Years; yr++)
				{
					bool isLastYear = (yr == Years);
					decimal Factor;
					string ISOCode;

					GetLookUpVariables(this.GetAgeBasedOnPeriodAniversary(
						this.GetAniversaryDateFromPeriod(
						yr, Convert.ToDateTime(AC.EffectiveDate.Trim())), 
						Convert.ToDateTime(AD.AutoDriver.BirthDate.Trim())));

					GetPremiumFactors(out Factor, out ISOCode);

					// set ISOCode
					AC.AddCoverBreakdown(Enumerators.Premiums.IsoCode, yr-1, ISOCode);
				
					// sets Period Text (Months)
					if(isLastYear && isRemainder)
					{
						AC.AddCoverBreakdown(
							Enumerators.Premiums.Periods, yr-1, 
							(((yr-1)*12) + Remainder).ToString());
					}
					else
					{
						AC.AddCoverBreakdown(
							Enumerators.Premiums.Periods, 
							yr-1, (yr*12).ToString());
					}

					if(isLiability)
					{
						CalculateLiability(yr, Factor, isLastYear);
					}
				
					if(isDoubleInterest)
					{
						CalculateDoubInt(yr, isLastYear, Factor);
					}

					// Towing, Assistance, SeatBelt Premiums, VehicleRental
					CalculateTASP(yr, Years, isLastYear); 
				}
				SetTotals();
			}
			else //RPR 2004-03-16
			{
				AC.Charge = 0;
				AC.TotalAmount = 0;
			}
		} // End: Calculate()

		/* Private Methods: Calculate */
		private void SetTerritoryFactor() 
		{
			// Sets:
			//    BI1020
			//    PD5000
			//    SL2500
			//    Comp100
			// Using:
			//    Effective Year = 98
			//    Territory = [Selected]
			// From: 
			//    DB : BIPDCompData
			string effyear = "98";
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("<parameter>");
			sb.Append("<name>EFF_YEAR</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + effyear.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>TERRITORY</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + AC.Territory.ToString() + "</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;
			
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			DataTable basicTables = exec.GetQuery ("GetBipdcompData", xmlDoc);
			if(basicTables.Rows.Count>0)
			{
				BI1020 = int.Parse(basicTables.Rows[0]["BI10_20"].ToString());
				PD5000 = int.Parse(basicTables.Rows[0]["PD_5000"].ToString());
				SL2500 = int.Parse(basicTables.Rows[0]["SL_25000"].ToString());
				COMP100 = decimal.Parse(basicTables.Rows[0]["COMP_100"].ToString());
			}
		
		} // End: SetTerritoryFactor()

		private int CalculatePeriodAmounts()
		{
			// If Remainder
			int qterm = AC.Term;
			if((qterm % 12) > 0)
			{
				Remainder = (qterm % 12);    // Get Remainder
				qterm += (12 - (int)Remainder); // Complete to Full Years (in Months)
				isRemainder = true;
			}
			
			return qterm/12;  // Calculate Years
			
		} // End: CalculatePeriodAmounts()

		//For Override Premium
		public int CalculatePeriodAmounts(AutoCover AC)
		{
			// If Remainder
			int qterm = AC.Term;
			if((qterm % 12) > 0)
			{
				int Remainder = (qterm % 12);    // Get Remainder
				qterm += (12 - (int)Remainder); // Complete to Full Years (in Months)
				isRemainder = true;
			}
			
			return qterm/12;  // Calculate Years
		}

		private void GetPolicyFactors()
		{
			BIFactor = GetBIFactor(_BodilyInjuryLimitDesc);
			PDFactor = GetPDFactor(_PropertyDamageLimitDesc);
			CSLFactor = GetCSLFactor(_CombinedSingleLimitDesc);
		} // End: GetPolicyFactors()

		/// <summary>
		///		This function takes the Bodily Injury Limit string and 
		///		determines what the value for the Bodily Injury factor will be.
		///	</summary>
		/// <remarks>
		/// <functionName>GetBIFactor</functionName><br/>
		/// <author>B.Nieves</author><br/>
		/// <modifiedBy date=""></modifiedBy><br/>
		/// </remarks>
		/// <param name="BILimit">The string representing the chosen 
		/// Bodily Injury Limit</param>
		/// <returns>a Double representing the Bodily Injury factor</returns>
		private decimal GetBIFactor(string BILimit)
		{
			switch (BILimit)
			{
				case "10/20":
					return (decimal)1.00;
				case "15/30":
					return (decimal)1.22;
				case "20/40":
					return (decimal)1.38;
				case "25/50":
					return (decimal)1.51;
				case "50/100":
					return (decimal)1.89;
				case "100/200":
					return (decimal)2.17;
				case "100/300":
					return (decimal)2.18;
				case "250/500":
					return (decimal)2.42;
				case "300/300":
					return (decimal)2.43;
				case "500/1000":
					return (decimal)2.52;
				default:
					return (decimal)1.00;
			}
		}
		/// <summary>
		///		This function takes the Property Damage Limit string and 
		///		determines what the value for the Property Damage factor will be.
		///	</summary>
		/// <remarks>
		/// <functionName>GetPDFactor</functionName><br/>
		/// <author>B.Nieves</author><br/>
		/// <modifiedBy date=""></modifiedBy><br/>
		/// </remarks>
		/// <param name="PDLimit">The string representing the chosen 
		/// Property Damage Limit</param>
		/// <returns>a Double representing the Property Damage factor</returns>
		private decimal GetPDFactor(string PDLimit)
		{
			switch (PDLimit)
			{
				case "5":
					return (decimal)1.00;
				case "10":
					return (decimal)1.1;
				case "15":
					return (decimal)1.12;
				case "20":
					return (decimal)1.13;
				case "25":
					return (decimal)1.14;
				case "50":
					return (decimal)1.18;
				case "100":
					return (decimal)1.22;
				case "150":
					return (decimal)1.25;
				case "200":
					return (decimal)1.28;
				case "250":
					return (decimal)1.3;
				case "500":
					return (decimal)1.37;
				case "750":
					return (decimal)1.39;
				default:
					return (decimal)1.00;
			}
		}
		///	<summary>
		///		This function takes the C. Single Limit string and 
		///		determines what the value for the C. Single Limit factor will be.
		///	</summary>
		/// <remarks>
		/// <functionName>GetCSLFactor</functionName><br/>
		/// <author>B.Nieves</author><br/>
		/// <modifiedBy date=""></modifiedBy><br/>
		/// </remarks>
		/// <param name="CSLLimit">The string representing the chosen 
		/// CSL Limit</param>
		/// <returns>a Double representing the C. Single Limit factor</returns>
		private decimal GetCSLFactor(string CSLimit)
		{
			switch (CSLimit)
			{
				case "50":
					return (decimal)1.14;
				case "75":
					return (decimal)1.22;
				case "100":
					return (decimal)1.27;
				case "200":
					return (decimal)1.37;
				case "300":
					return (decimal)1.42;
				case "500":
					return (decimal)1.46;
				case "1000":
					return (decimal)1.51;
				default:
					return (decimal)1.00;
			}
		}
		private void SetOnlyOperator(int Years)
		{
			//			Selected or Single Females 30-49 Yrs
			//			(((_age>=30) || ((_age+years)>=30)) && (_age<=49) && (_sex=="F"))
			int age = CalcAge(AD.AutoDriver.BirthDate);
			if(((age >= 30) || ((age + Years) >= 30)) && (age <= 49) && 
				(AD.AutoDriver.Gender == (int)Enumerators.Gender.Female))
			{
				AD.OnlyOperator = true;
			}
		} // End: SetOnlyOperator()

		private void CalculateLiability(int yr, decimal Factor, bool isLastYear)
		{
			// Adjust Discounts
			decimal dscnt = (decimal)1.0;
			if(AC.DiscountBIPD > 0)
			{
				dscnt = (decimal)1-(AC.DiscountBIPD/100);
			}

			if (isLastYear && isRemainder)
			{
				// FORMULA: Premium = 
				//(Factor * PolicyFactors * TerritoryFactor) * Remainder/12
				if(isBIPD)
				{
					AC.AddCoverBreakdown(
						Enumerators.Premiums.BodilyInjury , 
						yr-1, 
						//RPR 2004-05-10
						this.Round(
						this.Round(
						this.Round(BIFactor * BI1020) * dscnt) * 
						Factor) * ((decimal)Remainder / 12));
					AC.AddCoverBreakdown(
						Enumerators.Premiums.PropertyDamage, yr-1, 
						//RPR 2004-05-10
						this.Round(
						this.Round(
						this.Round(PDFactor * PD5000) * dscnt) * 
						Factor) * ((decimal)Remainder / 12) );
				}
				if(isCSL)
				{
					AC.AddCoverBreakdown(
						Enumerators.Premiums.CombinedSingle,
						yr-1,
						//RPR 2004-05-10
						this.Round(
						this.Round(
						this.Round(CSLFactor * SL2500) * dscnt) * 
						Factor) * ((decimal)Remainder / 12) );
				}
			}
			else 
			{
				// FORMULA: Premium = Factor * PolicyFactors * TerritoryFactor
				if(isBIPD)
				{
					AC.AddCoverBreakdown(
						Enumerators.Premiums.BodilyInjury,
						yr-1, 
						//RPR 2004-05-10
						this.Round(
						this.Round(
						this.Round(BIFactor * BI1020) * dscnt) * 
						Factor));
					AC.AddCoverBreakdown(Enumerators.Premiums.PropertyDamage,
						yr-1, 
						//RPR 2004-05-10
						this.Round(
						this.Round(
						this.Round(PDFactor * PD5000) * dscnt) *
						Factor));
				}
				if(isCSL)
				{
					AC.AddCoverBreakdown(
						Enumerators.Premiums.CombinedSingle, yr-1, 
						//RPR 2004-05-10
						this.Round(
						this.Round(
						this.Round(CSLFactor * SL2500) * dscnt) *
						Factor));
				}
			}
		} // End: CalculatePremiums()
		/* Private  Methods: CalculatePremiums */

		/// <summary>
		///		This function takes a list of factors and then determines the
		///		lookup values that will be needed to determine the isoCode and
		///		factor.
		///	</summary>
		/// <remarks>
		/// <functionName>GetLookUpVariables</functionName><br/>
		/// <author>Javier J. Vega Caro</author><br/>
		/// <modifiedBy date="01/08/2004">Benigno Nieves</modifiedBy><br/>
		/// </remarks>
		/// <param name="age">The age of the driver</param>
		/// <param name="sex">The gender of the driver</param>
		/// <param name="onlyOperator">A value representing whether the driver 
		/// is the only operator of the vehicle</param>
		/// <param name="owner">A value representing whether the driver 
		/// is the owner of the vehicle</param>
		/// <param name="maritalStatus">The marital status of the driver</param>
		/// <param name="vehicleUse">The code that represents the vehicle use</param>
		private void GetLookUpVariables(/*int yr* RPR 2004-03-03*/ int Age)
		{
			_lookupAge = "29";
			_lookupSex = "X";
			_lookupTraining = "X";
			_lookupOwner = "X";
			_lookupMaritalStatus = "X";
			_lookupGoodStanding = "X";
			_lookupPrimaryUse = AC.VehicleClass.ToUpper();

			Enumerators.MaritalStatus TmpMarSt = Enumerators.MaritalStatus.Single;
			if (AD.AutoDriver.MaritalStatus == (int)Enumerators.MaritalStatus.Married)
				TmpMarSt = Enumerators.MaritalStatus.Married;				

			/*int age = CalcAge(AD.AutoDriver.BirthDate); RPR 2004-03-03 */
			int age = Age; //Actual age for period under calculation.
			
			if(age>=75)
			{
				_lookupAge = "75";
			}
			else if((age>=65)&&(age<75))
			{
				_lookupAge = "74";
			}
			else if((age>=50)&&(age<65))
			{
				_lookupAge = "64";
			}
			else if((age >= 30) && (age < 50))
			{
				if((AD.AutoDriver.Gender == (int)Enumerators.Gender.Female) &&
					(AD.OnlyOperator)) //&& (TmpMarSt == Enumerators.MaritalStatus.Single)) Se cambio porque debe de cualificar para ambos casos (Soltera o Casada).
				{
					_lookupAge = "49";
				}
			}
			else if((age >= 25) && (age < 30))
			{
				if((AD.AutoDriver.Gender == (int)Enumerators.Gender.Male) &&
					(TmpMarSt == Enumerators.MaritalStatus.Single) &&
					(AD.PrincipalOperator))
				{
					_lookupOwner = "Y";

					_lookupSex = "M";
					_lookupMaritalStatus = "S";
					_lookupGoodStanding = "N";

					switch(AC.VehicleClass.ToUpper())
					{
						case "2A":
						case "2B":
						case "3":
							_lookupPrimaryUse = "2";
							break;
						case "4":
							_lookupPrimaryUse = "1";
							break;
					}		
				}
				else
				{
					if((AD.AutoDriver.Gender == (int)Enumerators.Gender.Male) &&
						(TmpMarSt == Enumerators.MaritalStatus.Single) &&
						(!AD.PrincipalOperator))
					{
						_lookupOwner = "X"; // Victor

						_lookupSex = "X";
						_lookupMaritalStatus = "X";
						_lookupGoodStanding = "X";

						switch(AC.VehicleClass.ToUpper())
						{
							case "2A":
								_lookupPrimaryUse = "2A";
								break;
							case "2B":
								_lookupPrimaryUse = "2B";
								break;
							case "3":
								_lookupPrimaryUse = "3";
								break;
							case "4":
								_lookupPrimaryUse = "4";
								break;
						}		
					}
				}
			}
			else
			{
				if(!((AD.AutoDriver.Gender == 
					(int)Enumerators.Gender.Female)&&
					(TmpMarSt == Enumerators.MaritalStatus.Married)))
				{
					if(AD.AutoDriver.Gender == (int)Enumerators.Gender.Female)
						_lookupSex = "F";
					else 
						_lookupSex = "M";

					if(TmpMarSt == Enumerators.MaritalStatus.Married)
						_lookupMaritalStatus = "M";
					else 
						_lookupMaritalStatus = "S";

					_lookupGoodStanding = "N";
					if(TmpMarSt == Enumerators.MaritalStatus.Single && AD.PrincipalOperator)  //Victor
					{
						_lookupOwner = "Y";
					}
					else
					{
						_lookupOwner = "N";
					}

					//Victor - No calculaba cuando era menor de 20 y era casado.
					if((age >= 17) && (age <= 24) && TmpMarSt == Enumerators.MaritalStatus.Married)
					{
						_lookupOwner = "X";
					}
                    
					if(age>=21)
					{
						_lookupAge = "24";
					}
					else 
					{
						_lookupTraining = "N";
						if(age<=17)
						{
							_lookupAge = "17";
						}
						else
						{
							_lookupAge = age.ToString();
						}
					}
					switch(AC.VehicleClass.ToUpper())
					{
						case "2A":
						case "2B":
						case "3":
							_lookupPrimaryUse = "2";
							break;
						case "4":
							_lookupPrimaryUse = "1";
							break;
					}
				}
			}
		} // End: GetLookUpVariables()

		/// <summary>
		///		This function takes the lookup values determined in PreFactor
		///		and determines the Iso code and factor to be used in the quote.
		///	</summary>
		/// <remarks>
		/// <functionName>GetFactor</functionName><br/>
		/// <author>B.Nieves</author><br/>
		/// <modifiedBy date=""></modifiedBy><br/>
		/// </remarks>
		/// <param name="isoCode">A string that contains the iso code</param>
		/// <param name="factor">A double that contains the factor to be used 
		/// in the quote</param>
		private void GetPremiumFactors(out decimal Factor, out string ISOCode)
		{
			string effYear = "95";
			string cover = "OT";
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("<parameter>");
			sb.Append("<name>EFF_YEAR</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + effYear.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>COVER</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + cover.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>AGE</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + _lookupAge.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>SEX</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + _lookupSex.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>MARITAL_ST</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + _lookupMaritalStatus.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>OWNER</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + _lookupOwner.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>CAR_USE</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + _lookupPrimaryUse.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>TRAINING</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + _lookupTraining.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>GOOD_STUD</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + _lookupGoodStanding.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;
			
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();

			DataTable factorTable = exec.GetQuery("GetFACTOR", xmlDoc);
			if(factorTable.Rows.Count > 0)
			{
				Factor = decimal.Parse(factorTable.Rows[0]["FACTOR"].ToString());
				ISOCode = factorTable.Rows[0]["ISO_CODE"].ToString();
			}
			else
			{
				Factor = 0;
				ISOCode = "";
			}
		} // End: GetPremiumFactors()

		
		// Towing, Assistance, SeatBelt, PAR Premiums
		private void CalculateTASP(int yr, int Years, bool isLastYear) 
		{
			// TOWING: _towingTotals[i-1] = Math.Round((this._towing / years),2);
			decimal Tow = (AC.TowingPremium / Years);
				
			// ASSISTANCE: _assistanceTotals[i-1] = Math.Round((this._assistance  / years),2);
			decimal Assist = (AC.AssistancePremium  / Years);

			// Vehicle Rentals
			decimal Vrental = (AC.VehicleRental  / Years);

			
			if(isLastYear)
			{
				// if not complete $$ - Round values to total
				// if (Total != Period * Years)
				//      LastPeriod = Total - LastPeriod * Years

				if((Tow * Years) != AC.TowingPremium) 
				{
					Tow += (AC.TowingPremium - (Tow*Years));
				}
				if((Assist * Years) != AC.AssistancePremium) 
				{
					Assist += (AC.AssistancePremium - (Assist*Years));
				}
				if((Vrental * Years) != AC.VehicleRental) 
				{
					Vrental += (AC.VehicleRental - (Vrental*Years));
				}
			}

			// SEATBELT: EnteredValue;
			decimal SB = 0;
			if(AC.SeatBelt != 0)
			{
				SB = _SeatBeltPremium; // Decoded Value
			}
			else
			{
				SB = 0;
			}
				
			// PAR: EnteredValue;
			decimal PAR = 0;
			if(AC.PersonalAccidentRider != 0)
			{
				PAR = _PARPremium; // Decoded Value
			}
			else
			{
				PAR = 0;
			}
			
			if (Tow > 0)
				AC.AddCoverBreakdown(Enumerators.Premiums.Towing, yr-1, Tow);
			if (Assist > 0)
				AC.AddCoverBreakdown(Enumerators.Premiums.Assistance, yr-1, Assist); 
			if (Vrental > 0)
				AC.AddCoverBreakdown(Enumerators.Premiums.VehicleRental, yr-1, Vrental); 
			if (SB > 0)
				AC.AddCoverBreakdown(Enumerators.Premiums.SeatBelt, yr-1, SB);
			if (PAR > 0)
				AC.AddCoverBreakdown(Enumerators.Premiums.PersonalAccidentRider, yr-1, PAR);
		}  // End: CalculateTAS()

		private void CalculateDoubInt(int yr, bool isLastYear, decimal Factor)
		{
			decimal compRate = 0;
			decimal collRate = 0;
			decimal compValue = 0;

			GetLookUpCost(out compValue);
			SetVehicleAgeGroup(yr);
			
			// set Comprehensive & Collision Value;
			compRate = GetComprehensiveRate();
			collRate = GetCollisionRate();
			
			// Adjust Discounts
			//RPR 2004-05-12
			//Formerly both comp & coll, changed to 
			//make computation order more similar to FoxPro
			//collRateDiscount is applied on GetCollisionRate();
			if(AC.DiscountCompColl > 0)
			{
				compRate *= 1-(AC.DiscountCompColl/100M);
			}

			SetAlarmRate(ref compRate);
			
			// Adjustment: 4% of CollRate 
			//for every $1000 or fraction over $11,111
			if(AC.Cost > 11111)
			{
				//RPR 2004-05-11
                /*collRate = (int)(collRate + 
					((collRate * 0.04) *
					((int)(((AC.Cost-11111)/1000)+.999))));*/
				decimal mTimes = (int)((AC.Cost - 11111) / 1000 + .999M);
				
				/*collRate = (int)(collRate + ((collRate * 0.04M) *
					((int)((AC.Cost - 11111) / 1000) + .999M)));*/
				collRate = (int)(collRate + ((collRate * 0.04M) *
					(mTimes)));
			}

			// Adjust Depreciation
			AdjustDepreciation(yr, compValue, 
				ref compRate, ref collRate);

			// Adjust Ramainder
			if(isLastYear && isRemainder)
			{
				collRate = (int)((collRate/12)*(Remainder)+.5M);
				compRate = (int)((compRate/12)*(Remainder)+.5M);
			}// End if((i==years)&&(remainder>0))

			// Adjust Premium Factor
			collRate = this.Round(collRate * Factor);
			compRate = this.Round(compRate * Factor);

			AC.AddCoverBreakdown(Enumerators.Premiums.Comprehensive,yr-1, compRate);
			AC.AddCoverBreakdown(Enumerators.Premiums.Collision,yr-1, collRate);
			AC.AddCoverBreakdown(Enumerators.Premiums.LeaseLoanGap, yr-1,collRate * _LeaseLoanGapDesc + compRate * _LeaseLoanGapDesc);
		} 

		private void GetLookUpCost(out decimal compValue)
		{
			decimal cost = AC.Cost;
					
			if(AC.NewUse == (int)Enumerators.NewUse.New)
			{
				compValue = AC.Cost;
			}
			else
			{
				compValue = AC.ActualValue;
			}//End if(vehicleNew)
			
			int [] costvalue = {1111,1333,1556,1778,2111,2444,3333,
								4444,5556,6667,7778,8889,10000};
			string lookupCost = "";

			if(cost<=costvalue[0])//check before the first value
			{
				lookupCost = "0" + costvalue[0].ToString();
			}
			else if((cost>costvalue[0])&&(cost<=costvalue[costvalue.Length-1])) //check within the array
			{
				for(int i=0; i<costvalue.Length-1; i++)
				{
					if((cost>costvalue[i])&&(cost<=costvalue[i+1]))
					{
						if(costvalue[i+1].ToString().Length==4)
						{
							lookupCost = "0" + costvalue[i+1];
							break;
						}
						else
						{
							lookupCost = costvalue[i+1].ToString();
							break;
						}
					}
				}
			}
			else //If it is higher than the last value of the array
			{
				lookupCost = "11111";
			}
			_lookupCostNet = lookupCost;
		} // End: GetLookUpCost()

		/// <summary>
		///		This function takes the comprehensive deductible and determines
		///		what is the rate that will be used
		///	</summary>
		/// <remarks>
		/// <functionName>GetComprehensiveRate</functionName><br/>
		/// <author>Javier J. Vega Caro</author><br/>
		/// <modifiedBy date=""></modifiedBy><br/>
		/// </remarks>
		/// <param name="comprehensiveDeductible">an integer value that
		/// contains the value for the comprehensive deductible</param>
		/// <returns>A double that contains the Comprehensive Rate</returns>
		private decimal GetComprehensiveRate()
		{
			decimal tempCompRate = COMP100 / 100;
			switch ((int)_ComprehensiveDeductibleDesc)
			{
				case 50:
					//RPR 2004-05-11, Math.Rounds
					return (decimal)Math.Round(tempCompRate * 1.25M, 5);
				case 200:
					return (decimal)Math.Round(tempCompRate * 0.88M, 5);
				case 250:
					return (decimal)Math.Round(tempCompRate * 0.81M, 5);
				case 500:
					return (decimal)Math.Round(tempCompRate * 0.69M, 5);
				case 1000:
					return (decimal)Math.Round(tempCompRate * 0.63M, 5);
				default:
					return tempCompRate;
			}
			
			// return(Math.Round(tempCompRate,5));
		} // End: GetComprehensiveRate()

		private void SetAlarmRate(ref decimal compRate)
		{
			//RPR 2004-02-26
			//Alarm type codes were inverted.
			//1 = Active, 2 = Passive
			switch(AC.AlarmType)
			{
				case 1:  // Active
					compRate *= .95M;
					break;
				case 2:  // Passive
					compRate *= .85M;
					break;
			}//End switch(vehicleAlarmType)

		} // End: SetAlarmRate()

		private void SetVehicleAgeGroup(int Year)
		{
			if((AC.VehicleAge+Year)<=1)
			{
				_lookupAgeGroup = "1";
			}
			else if(((AC.VehicleAge+Year)==2)||((AC.VehicleAge+Year)==3))
			{
				_lookupAgeGroup = "3";
			}
			else 
			{
				_lookupAgeGroup = "4";
			}
		} // End: SetVehicleAgeGroup()

		private decimal GetCollisionRate()
		{
			decimal tempCollrate = GetCollisionData();
			
			//RPR 2004-05-12
			if(AC.DiscountCompColl > 0)
			{
				//RPR 2004-05-12 (+.5 y el (int)) no estaban
				//en el codigo original.
				tempCollrate  = 
					(int)((tempCollrate * 
					(1 - (AC.DiscountCompColl /100M))) + .5M);
			}

			switch ((int)_CollisionDeductibleDesc)
			{
				case 150:
					return tempCollrate * 0.93M;
				case 200:
					return tempCollrate * 0.83M;
				case 250:
					return tempCollrate * 0.75M;
				case 500:
					return tempCollrate * 0.54M;
				case 1000:
					return tempCollrate * 0.42M;
				default:
					return tempCollrate;
			}
			// return(tempCollrate);
		} // End: GetCollisionRate()

		private void AdjustDepreciation(int yr, decimal compValue, ref decimal compRate, ref decimal collRate)
		{
			//1st Year:
			//    Depreciation = CompValue 
			//            * [Depreciation% per Year]
			//Else
			//    Depreciation = CompValue 
			//            * [Depreciation% per First Year] 
			//            * [Depreciation after 2nd Year per Year]
			//
			//CompRate = CompRate*Depreciation
			decimal  VehicleDepreciation;
			if (yr <= 2) // first Year 100%, second Year 80%, third Year 64%.....
			{
				VehicleDepreciation = (decimal)((compValue * (decimal)Math.Pow((double)(1-(AC.Depreciation1stYear / 100)),(double)(yr-1))));
			}
			else
			{
				VehicleDepreciation = (decimal)((compValue * (1-(AC.Depreciation1stYear/100)) 
					* (decimal)Math.Pow((double)(1-(AC.DepreciationAllYear/100)),(double)(yr-2))));
			}
			// if needed uncomment to display Vehicle Depreciation
			AC.AddCoverBreakdown(Enumerators.Premiums.Depreciation, yr-1, Math.Round(VehicleDepreciation,0));
			compRate *= VehicleDepreciation;
			
			// Adjust Depreciation Factor
			AdjustDepreciationFactor(yr, ref compRate, ref collRate);

			collRate = (int)(collRate + .5M);
			compRate = (int)(compRate + .5M);
					
		} // End: AdjustCompRate()

		/// <summary>
		///		This function takes the comprehensive and collision rates
		///		and applies a multiplier depending on what year of the policy
		///		it is on
		///	</summary>
		/// <remarks>
		/// <functionName>CalculateDepreciation</functionName><br/>
		/// <author>Javier J. Vega Caro</author><br/>
		/// <modifiedBy date=""></modifiedBy><br/>
		/// </remarks>
		/// <param name="comprate">The comprehensive rate</param>
		/// <param name="collrate">The collision rate</param>
		/// <param name="year">The year for which the depreciation needs to be applied</param>
		private void AdjustDepreciationFactor(int yr, ref decimal compRate, ref decimal collRate)
		{
			//HACK: Verificar, esto varia de acuerdo al año.
			decimal [] depreciationFactor = {1.00M,.94M,.89M,.84M,.79M,.75M,.70M};
			
			if((yr>0)&&(yr<=7))
			{
				compRate *= depreciationFactor[yr-1];
				collRate *= depreciationFactor[yr-1];
			}
		
		} // End: AdjustDepreciationFactor()

		private void AdjustSecondVehicle(ref decimal compRate, ref decimal collRate)
		{
			if(AC.DiscountCompColl < 0)
			{
				collRate = collRate * .8M;
				compRate = compRate * .8M;
			}
			else
			{
				collRate = 
					collRate * (1 - (AC.DiscountCompColl/100));
				compRate = 
					compRate * (1 - (AC.DiscountCompColl/100));
			}
		} // End: AdjustSecondVehicle()

		private void GetAssignedDriver()
		{
			// Assigned Driver will be the PrincipalOperator
			for (int d = 0; d < AC.AssignedDrivers.Count; d++)
			{
				//if (((AssignedDriver) AC.AssignedDrivers[d]).PrincipalOperator == true)
				//{
					AD = (AssignedDriver)AC.AssignedDrivers[d];
					break;
				//}
			}
		}

		private int CalcAge(string birthDT)
		{
			DateTime pdt = DateTime.Parse(birthDT);
			DateTime now = DateTime.Now;
			TimeSpan ts = now - pdt;
			int Years = (int)(((decimal)ts.Days) / 365.25M);
			return Years;
		}

		private void DecodeAutoCover()
		{
			DataTable dt;
			string StrdProc;
			if (this._IsPolicy)
			{
				StrdProc = "GetPolicyAutoDecoded";
			}
			else
			{
				StrdProc = "GetQuotesAutoDecoded";
			}

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			XmlDocument xmlDoc = new XmlDocument();
		
			sb.Append("<parameters>");
			if(AC.QuotesAutoId != 0)
			{
				sb.Append("<parameter>");
				sb.Append("<name>QuotesAutoID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.QuotesAutoId.ToString() + "</value>");
				sb.Append("</parameter>");
			}
			else
			{
				if (this._IsPolicy)
				{
					StrdProc = "GetPolicyAutoDecoded2";
				}
				else
				{
					StrdProc = "GetQuotesAutoDecoded2";
				}
				sb.Append("<parameter>");
				sb.Append("<name>HomeCity</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.HomeCity.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>WorkCity</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.WorkCity.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>VehicleMakeID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.VehicleMake.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>VehicleModelID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.VehicleModel.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>VehicleYearID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.VehicleYear.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>NewUseID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.NewUse.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>VehicleUseID</name>");
				sb.Append("<type>char</type>");
				sb.Append("<length>2</length>"); 
				sb.Append("<value>" + AC.VehicleClass.Trim() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>TerritoryID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.Territory.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>AlarmTypeID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.AlarmType.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>ComprehensiveDeductibleID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.ComprehensiveDeductible.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>CollisionDeductibleID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.CollisionDeductible.ToString() + "</value>");
				sb.Append("</parameter>");
				
				sb.Append("<parameter>");
				sb.Append("<name>BodilyInjuryLimitID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.BodilyInjuryLimit.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>PropertyDamageLimitID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.PropertyDamageLimit.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>CombinedSingleLimitID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.CombinedSingleLimit.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>MedicalLimitID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.MedicalLimit.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>LeaseLoanGapID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.LeaseLoanGapId.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>SeatBeltID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.SeatBelt.ToString() + "</value>");
				sb.Append("</parameter>");

				sb.Append("<parameter>");
				sb.Append("<name>PARID</name>");
				sb.Append("<type>int</type>");
				sb.Append("<value>" + AC.PersonalAccidentRider.ToString() + "</value>");
				sb.Append("</parameter>");
			}
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;

			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			dt = exec.GetQuery(StrdProc, xmlDoc);
			
			if(dt.Rows.Count > 0)
			{
				if (dt.Rows[0]["ComprehensiveDeductibleDesc"] != 
					System.DBNull.Value)
				{
					_ComprehensiveDeductibleDesc = 
						decimal.Parse(
						dt.Rows[0]["ComprehensiveDeductibleDesc"].ToString());
				}
				if (dt.Rows[0]["CollisionDeductibleDesc"] != System.DBNull.Value)
				{
					_CollisionDeductibleDesc = 
						decimal.Parse(dt.Rows[0]["CollisionDeductibleDesc"].ToString());
				}
				_BodilyInjuryLimitDesc = dt.Rows[0]["BodilyInjuryLimitDesc"].ToString();
				_PropertyDamageLimitDesc = 
					dt.Rows[0]["PropertyDamageLimitDesc"].ToString();
				_CombinedSingleLimitDesc = 
					dt.Rows[0]["CombinedSingleLimitDesc"].ToString();
				_MedicalLimitDesc = dt.Rows[0]["MedicalLimitDesc"].ToString();
				if (dt.Rows[0]["SeatBeltDesc"] != System.DBNull.Value)
				{
					_SeatBeltPremium = 
						decimal.Parse(dt.Rows[0]["SeatBeltDesc"].ToString());
				}
				if (dt.Rows[0]["PARPremium"] != System.DBNull.Value)
				{
					_PARPremium = decimal.Parse(dt.Rows[0]["PARPremium"].ToString());
				}
				if (dt.Rows[0]["LeaseLoanGapDesc"] != 
					System.DBNull.Value)
				{
					_LeaseLoanGapDesc = 
						decimal.Parse(dt.Rows[0]["LeaseLoanGapDesc"].ToString());
				}
//				_HomeCityDesc = dt.Rows[0]["HomeCityDesc"].ToString();
//				_WorkCityDesc = dt.Rows[0]["WorkCityDesc"].ToString(); 
//				_VehicleMakeDesc = dt.Rows[0]["VehicleMakeDesc"].ToString();
//				_VehicleModelDesc = dt.Rows[0]["VehicleModelDesc"].ToString();
//				_VehicleYearDesc = dt.Rows[0]["VehicleYearDesc"].ToString();
//				_NewUseDesc = dt.Rows[0]["NewUseDesc"].ToString();
//				_VehicleUseDesc = dt.Rows[0]["VehicleUseDesc"].ToString();
//				_TerritoryDesc = dt.Rows[0]["TerritoryDesc"].ToString();
//				_AlarmTypeDesc = dt.Rows[0]["AlarmTypeDesc"].ToString();
			}
		}
		/// <summary>
		///		This function works like the Math.Round function but it
		///		uses rounding like the one used in the original quote engine.
		///	</summary>
		/// <remarks>
		/// <functionName>Round</functionName><br/>
		/// <author>Javier J. Vega Caro</author><br/>
		/// <modifiedBy date=""></modifiedBy><br/>
		/// </remarks>
		/// <param name="number">The number to round</param>
		/// <returns>An integer value representing the number after rounding</returns>
		private int Round(decimal number)
		{
			int wholeNumber = (int)number;
			if((number-wholeNumber)>=.5M)
			{
				wholeNumber++;
			}
			return(wholeNumber);
		}
		/// <summary>
		///		This function gets the data that will be needed to make
		///		the calculations for collision
		///	</summary>
		/// <remarks>
		/// <functionName>GetCollisionData</functionName><br/>
		/// <author>Javier J. Vega Caro</author><br/>
		/// <modifiedBy date=""></modifiedBy><br/>
		/// </remarks>
		/// <returns>The base collision rate value</returns>
		private decimal GetCollisionData()
		{
			string effyear = "98";
			decimal result = 0;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("<parameter>");
			sb.Append("<name>EFF_YEAR</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + effyear.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>AGE_GROUP</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + _lookupAgeGroup.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>COST_NET</name>");
			sb.Append("<type>nvarchar</type>");
			sb.Append("<value>" + _lookupCostNet.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			DataTable collisionDataTable = exec.GetQuery ("GetCollisionData", xmlDoc);
			if(collisionDataTable.Rows.Count>0)
			{
				result =
					decimal.Parse(
					collisionDataTable.Rows[0]["TERR_" + AC.Territory].ToString());
			}
			return(result);
		}
		
		/// <summary>
		///		This function makes the final calculations for the premium,
		///		charge and total premium. 
		///	</summary>
		private void SetTotals()
		{
			decimal SubTotal = 0;
			// Get Charge Value
			decimal chrgRate = GetCharge();

			AC.AddCoverBreakdown(Enumerators.Premiums.Medical, 0, GetMedicalPayments());
		 
			SubTotal += AC.BodilyInjuryPremium();
			SubTotal += AC.PropertyDamagePremium();			
			SubTotal += AC.CombinedSinglePremium();
			SubTotal += AC.CollisionPremium();
			SubTotal += AC.ComprehensivePremium();
			SubTotal += System.Math.Round(AC.LeaseLoanGapPremium(),0);
			SubTotal += AC.MedicalPremium();
			SubTotal += AC.SeatBeltPremium();
			SubTotal += AC.PersonalAccidentRiderPremium();
			SubTotal += AC.AssistancePremium;
			SubTotal += AC.TowingPremium;
			SubTotal += AC.VehicleRental;

			AC.TotalAmount = SubTotal;
			AC.Charge = Math.Round((chrgRate * SubTotal),0);
		}

		/// <summary>
		///		This function verifies the effective date and determines what
		///		the charge rate will be.
		///	</summary>
		private decimal GetCharge()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			DataTable resultCharge = new DataTable();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("<parameter>");
			sb.Append("<name>policyClassID</name>");
			sb.Append("<type>int</type>");
			sb.Append("<Length>4</Length>");
			sb.Append("<value>" + 3 + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>effectiveDate</name>");
			sb.Append("<type>DateTime</type>");
			sb.Append("<Length>8</Length>");
			sb.Append("<value>" + AC.EffectiveDate.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			resultCharge = exec.GetQuery("GetCharge", xmlDoc);
			if(resultCharge.Rows.Count > 0)
			{
				return(decimal.Parse(resultCharge.Rows[0]["chargePercent"].ToString()));
			}
			else
			{
				return 0;
			}
		}

		//For Override Premium
		public AutoCover SetTotal(AutoCover ACover)
		{
			decimal SubTotal = 0;
			// Get Charge Value
			decimal chrgRate = GetCharge(ACover.EffectiveDate);

			ACover.AddCoverBreakdown(Enumerators.Premiums.Medical, 0, GetMedicalPayments());
		 
			SubTotal += ACover.BodilyInjuryPremium();
			SubTotal += ACover.PropertyDamagePremium();			
			SubTotal += ACover.CombinedSinglePremium();
			SubTotal += ACover.CollisionPremium();
			SubTotal += ACover.ComprehensivePremium();
			SubTotal += System.Math.Round(ACover.LeaseLoanGapPremium(),0);
			SubTotal += ACover.MedicalPremium();
			SubTotal += ACover.SeatBeltPremium();
			SubTotal += ACover.PersonalAccidentRiderPremium();
			SubTotal += ACover.AssistancePremium;
			SubTotal += ACover.TowingPremium;
			SubTotal += ACover.VehicleRental;

			ACover.TotalAmount = SubTotal;
			ACover.Charge = Math.Round((chrgRate * SubTotal),0);

			return ACover;
		} 

		//For Override Premium
		private decimal GetCharge(string effectiveDate)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			DataTable resultCharge = new DataTable();

			XmlDocument xmlDoc = new XmlDocument();

			sb.Append("<parameters>");
			sb.Append("<parameter>");
			sb.Append("<name>policyClassID</name>");
			sb.Append("<type>int</type>");
			sb.Append("<Length>4</Length>");
			sb.Append("<value>" + 3 + "</value>");
			sb.Append("</parameter>");
			sb.Append("<parameter>");
			sb.Append("<name>effectiveDate</name>");
			sb.Append("<type>DateTime</type>");
			sb.Append("<Length>8</Length>");
			sb.Append("<value>" + effectiveDate.Trim() + "</value>");
			sb.Append("</parameter>");
			sb.Append("</parameters>");
			xmlDoc.InnerXml = sb.ToString();
			sb = null;
			Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
			resultCharge = exec.GetQuery("GetCharge", xmlDoc);
			if(resultCharge.Rows.Count > 0)
			{
				return(decimal.Parse(resultCharge.Rows[0]["chargePercent"].ToString()));
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		///		This function takes the medical payment that was given and
		///		then determines what is the true rate for the medical
		///		payments
		///	</summary>
		/// <remarks>
		/// <functionName>SetMedicalPayments</functionName><br/>
		/// <author>Javier J. Vega Caro</author><br/>
		/// <modifiedBy date=""></modifiedBy><br/>
		/// </remarks>
		private decimal GetMedicalPayments()
		{
			switch(_MedicalLimitDesc)
			{
				case "1000":
					return 2.0M;
				case "2000":
					return 4.0M;
				case "5000":
					return 6.0M;
				default:
					return 0.0M;
			}
		}

		private bool CalcIsDoubleInterest()
		{
			///TODO: Fix Calculus isDoubleInterest
			
			// These are Double Interest
			if (AutoCover.GetAutoPolicySubClassBaseClassID(
				AC.PolicySubClassId)== 1 /* RPR 2004-05-26 ||
				AC.PolicySubClassId == 5 ||
				AC.PolicySubClassId == 12*/)
			{
				return true;
			}
				// These are Full Cover
			else if (AutoCover.GetAutoPolicySubClassBaseClassID(
				AC.PolicySubClassId) == 3 /* RPR 2004-05-26 ||
				AC.PolicySubClassId == 6 ||
				AC.PolicySubClassId == 11 ||
				AC.PolicySubClassId == 12*/)
			{
				if (AC.ComprehensiveDeductible > 0 &&
					AC.CollisionDeductible > 0)
					return true;
				else
					return false;
			}
			else 
			{ // Else it's a Liability - 2, 4, 6, 7, 8, 9, 10, 11, 12
				return false;
			}
		}

		private bool CalcIsLiability()
		{
			///TODO: Fix Calculus isLiability
			
			// These are Liability 2, 4, 6, 7, 8, 9, 10, 11, 12
			if (AutoCover.GetAutoPolicySubClassBaseClassID(
				AC.PolicySubClassId) == 2 /*RPR 2004-05-26 ||
				AC.PolicySubClassId == 4 ||
				AC.PolicySubClassId == 6 ||
				AC.PolicySubClassId == 7 ||
				AC.PolicySubClassId == 8 ||
				AC.PolicySubClassId == 9 ||
				AC.PolicySubClassId == 10 ||
				AC.PolicySubClassId == 11 ||
				AC.PolicySubClassId == 12*/)
			{
				return true;
			}
				// These are Full Cover
			else if (AutoCover.GetAutoPolicySubClassBaseClassID(
				AC.PolicySubClassId) == 3 /* RPR 2004-05-26 ||
				AC.PolicySubClassId == 6 ||
				AC.PolicySubClassId == 11 ||
				AC.PolicySubClassId == 12*/)
			{
				if ((AC.BodilyInjuryLimit > 0 &&
					AC.PropertyDamageLimit > 0) ||
					AC.CombinedSingleLimit > 0)
					return true;
				else
					return false;
			}
			else 
			{ // Else it's a Double Interest - 1, 5, 12
				return false;
			}
		}
	}
}
