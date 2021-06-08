using System;
using System.Data;
using System.Xml;
using Baldrich.DBRequest;
using EPolicy.LookupTables;
using EPolicy;
using EPolicy.XmlCooker;

namespace EPolicy.Quotes
{
    public class PersonalLiability
    {
        public PersonalLiability()
        {

        }

        private PersonalLiabilityPremium _PersonalLiabilityPremium = new PersonalLiabilityPremium();
        private double _BasicRate1 = 92.00;
        private double _BasicRate2 = 92.00;
        private double _BasicRate3 = 97.00;
        private double _BasicRate4 = 97.00;

        private double _MedPayment1000 = 0.00;

        private double _MedPayment2000Fam1 = 3.00;
        private double _MedPayment2000Fam2 = 3.00;
        private double _MedPayment2000Fam3 = 6.00;
        private double _MedPayment2000Fam4 = 6.00;

        private double _MedPayment3000Fam1 = 6.00;
        private double _MedPayment3000Fam2 = 6.00;
        private double _MedPayment3000Fam3 = 9.00;
        private double _MedPayment3000Fam4 = 9.00;

        private double _MedPayment5000Fam1 = 12.00;
        private double _MedPayment5000Fam2 = 12.00;
        private double _MedPayment5000Fam3 = 14.00;
        private double _MedPayment5000Fam4 = 14.00;

        private double _FactorInc100000 = 1.00;
        private double _FactorInc200000 = 1.15;
        private double _FactorInc300000 = 1.24;
        private double _FactorInc400000 = 1.30;
        private double _FactorInc500000 = 1.35;

        private int    _PropertiesCount = 0;
        private double _DiscountFactor = 0.80;
        private double _TotalPremium = 0.00;

        public PersonalLiabilityPremium PersonalLiabilityPremium
        {
            get
            {
                return this._PersonalLiabilityPremium;
            }
            set
            {
                this._PersonalLiabilityPremium = value;
            }
        }

        public int PropertiesCount
        {
            get
            {
                return this._PropertiesCount;
            }
            set
            {
                this._PropertiesCount = value;
            }
        }

        private static PersonalLiability SetRate(PersonalLiability personalLiability, int PropertiesNum)
        {
            switch (PropertiesNum)
            {
                case 1:
                    personalLiability._BasicRate1 = 92.00;
                    personalLiability._BasicRate2 = 92.00;
                    personalLiability._BasicRate3 = 97.00;
                    personalLiability._BasicRate4 = 97.00;

                    personalLiability._MedPayment1000 = 0.00;

                    personalLiability._MedPayment2000Fam1 = 3.00;
                    personalLiability._MedPayment2000Fam2 = 3.00;
                    personalLiability._MedPayment2000Fam3 = 6.00;
                    personalLiability._MedPayment2000Fam4 = 6.00;

                    personalLiability._MedPayment3000Fam1 = 6.00;
                    personalLiability._MedPayment3000Fam2 = 6.00;
                    personalLiability._MedPayment3000Fam3 = 9.00;
                    personalLiability._MedPayment3000Fam4 = 9.00;

                    personalLiability._MedPayment5000Fam1 = 12.00;
                    personalLiability._MedPayment5000Fam2 = 12.00;
                    personalLiability._MedPayment5000Fam3 = 14.00;
                    personalLiability._MedPayment5000Fam4 = 14.00;

                    return personalLiability;
                    break;

                default:  //Aplica a las propiedades 2,3,y 4.
                    if (personalLiability.PersonalLiabilityPremium.Rented2)
                    {
                        personalLiability._BasicRate1 = 24.00;
                        personalLiability._BasicRate2 = 37.00;
                        personalLiability._BasicRate3 = 132.00;
                        personalLiability._BasicRate4 = 134.00;

                        personalLiability._MedPayment1000 = 0.00;

                        personalLiability._MedPayment2000Fam1 = 2.00;
                        personalLiability._MedPayment2000Fam2 = 2.00;
                        personalLiability._MedPayment2000Fam3 = 2.00;
                        personalLiability._MedPayment2000Fam4 = 2.00;

                        personalLiability._MedPayment3000Fam1 = 3.00;
                        personalLiability._MedPayment3000Fam2 = 3.00;
                        personalLiability._MedPayment3000Fam3 = 3.00;
                        personalLiability._MedPayment3000Fam4 = 3.00;

                        personalLiability._MedPayment5000Fam1 = 5.00;
                        personalLiability._MedPayment5000Fam2 = 5.00;
                        personalLiability._MedPayment5000Fam3 = 5.00;
                        personalLiability._MedPayment5000Fam4 = 5.00;

                        return personalLiability;
                    }
                    else
                    {
                        personalLiability._BasicRate1 = 7.00;
                        personalLiability._BasicRate2 = 14.00;
                        personalLiability._BasicRate3 = 101.00;
                        personalLiability._BasicRate4 = 104.00;

                        personalLiability._MedPayment1000 = 0.00;

                        personalLiability._MedPayment2000Fam1 = 2.00;
                        personalLiability._MedPayment2000Fam2 = 2.00;
                        personalLiability._MedPayment2000Fam3 = 2.00;
                        personalLiability._MedPayment2000Fam4 = 2.00;

                        personalLiability._MedPayment3000Fam1 = 3.00;
                        personalLiability._MedPayment3000Fam2 = 3.00;
                        personalLiability._MedPayment3000Fam3 = 3.00;
                        personalLiability._MedPayment3000Fam4 = 3.00;

                        personalLiability._MedPayment5000Fam1 = 5.00;
                        personalLiability._MedPayment5000Fam2 = 5.00;
                        personalLiability._MedPayment5000Fam3 = 5.00;
                        personalLiability._MedPayment5000Fam4 = 5.00;

                        return personalLiability;
                    }
                    break;
            }
        }

        public static PersonalLiability Calculate(PersonalLiability personalLiability)
        {
            if(personalLiability.PropertiesCount >= 1)
               personalLiability = CalculateProperty1(personalLiability);

           if (personalLiability.PropertiesCount >= 2)
               personalLiability = CalculateProperty2(personalLiability);

           if (personalLiability.PropertiesCount >= 3)
               personalLiability = CalculateProperty3(personalLiability);

           if (personalLiability.PropertiesCount >= 4)
               personalLiability = CalculateProperty4(personalLiability);

           personalLiability.PersonalLiabilityPremium.TotalPremium = personalLiability.PersonalLiabilityPremium.TotalPremium1 + personalLiability.PersonalLiabilityPremium.TotalPremium2 +
                 personalLiability.PersonalLiabilityPremium.TotalPremium3 + personalLiability.PersonalLiabilityPremium.TotalPremium4;

           return personalLiability;
        }

        private static PersonalLiability CalculateProperty1(PersonalLiability personalLiability)
        {
            PersonalLiability pl = new PersonalLiability();

            personalLiability =SetRate(personalLiability, 1);

            personalLiability.PersonalLiabilityPremium.BasicRate1 = CalculateBasicRate(personalLiability, personalLiability.PersonalLiabilityPremium.Families1);
            personalLiability.PersonalLiabilityPremium.FactorIncrease1 = CalculateFactorIncrease(personalLiability, personalLiability.PersonalLiabilityPremium.PersonalLiability1);
            personalLiability.PersonalLiabilityPremium.MedPayment1 = CalculateMedicalPayment(personalLiability, personalLiability.PersonalLiabilityPremium.MedicalPayment1, personalLiability.PersonalLiabilityPremium.Families1);

            personalLiability.PersonalLiabilityPremium.BasicPremium1 = Math.Round(personalLiability.PersonalLiabilityPremium.BasicRate1 * personalLiability.PersonalLiabilityPremium.FactorIncrease1, 0);
            personalLiability.PersonalLiabilityPremium.TotalPremium1 = personalLiability.PersonalLiabilityPremium.BasicPremium1 + personalLiability.PersonalLiabilityPremium.MedPayment1;

            personalLiability.PersonalLiabilityPremium.TotalPremium1 = Math.Round(personalLiability.PersonalLiabilityPremium.TotalPremium1 * pl._DiscountFactor, 0);

            return personalLiability;
        }

        private static PersonalLiability CalculateProperty2(PersonalLiability personalLiability)
        {
            PersonalLiability pl = new PersonalLiability();

            personalLiability = SetRate(personalLiability, 2);

            personalLiability.PersonalLiabilityPremium.BasicRate2 = CalculateBasicRate(personalLiability, personalLiability.PersonalLiabilityPremium.Families2);
            personalLiability.PersonalLiabilityPremium.FactorIncrease2 = CalculateFactorIncrease(personalLiability, personalLiability.PersonalLiabilityPremium.PersonalLiability2);
            personalLiability.PersonalLiabilityPremium.MedPayment2 = CalculateMedicalPayment(personalLiability, personalLiability.PersonalLiabilityPremium.MedicalPayment2, personalLiability.PersonalLiabilityPremium.Families2);

            personalLiability.PersonalLiabilityPremium.BasicPremium2 = Math.Round(personalLiability.PersonalLiabilityPremium.BasicRate2 * personalLiability.PersonalLiabilityPremium.FactorIncrease2, 0);
            personalLiability.PersonalLiabilityPremium.TotalPremium2 = personalLiability.PersonalLiabilityPremium.BasicPremium2 + personalLiability.PersonalLiabilityPremium.MedPayment2;

            personalLiability.PersonalLiabilityPremium.TotalPremium2 = Math.Round(personalLiability.PersonalLiabilityPremium.TotalPremium2 * pl._DiscountFactor, 0);

            return personalLiability;
        }

        private static PersonalLiability CalculateProperty3(PersonalLiability personalLiability)
        {
            PersonalLiability pl = new PersonalLiability();

            personalLiability = SetRate(personalLiability, 3);

            personalLiability.PersonalLiabilityPremium.BasicRate3 = CalculateBasicRate(personalLiability, personalLiability.PersonalLiabilityPremium.Families3);
            personalLiability.PersonalLiabilityPremium.FactorIncrease3 = CalculateFactorIncrease(personalLiability, personalLiability.PersonalLiabilityPremium.PersonalLiability3);
            personalLiability.PersonalLiabilityPremium.MedPayment3 = CalculateMedicalPayment(personalLiability, personalLiability.PersonalLiabilityPremium.MedicalPayment3, personalLiability.PersonalLiabilityPremium.Families3);

            personalLiability.PersonalLiabilityPremium.BasicPremium3 = Math.Round(personalLiability.PersonalLiabilityPremium.BasicRate3 * personalLiability.PersonalLiabilityPremium.FactorIncrease3, 0);
            personalLiability.PersonalLiabilityPremium.TotalPremium3 = personalLiability.PersonalLiabilityPremium.BasicPremium3 + personalLiability.PersonalLiabilityPremium.MedPayment3;

            personalLiability.PersonalLiabilityPremium.TotalPremium3 = Math.Round(personalLiability.PersonalLiabilityPremium.TotalPremium3 * pl._DiscountFactor, 0);

            return personalLiability;
        }

        private static PersonalLiability CalculateProperty4(PersonalLiability personalLiability)
        {
            PersonalLiability pl = new PersonalLiability();

            personalLiability = SetRate(personalLiability, 4);

            personalLiability.PersonalLiabilityPremium.BasicRate4 = CalculateBasicRate(personalLiability, personalLiability.PersonalLiabilityPremium.Families4);
            personalLiability.PersonalLiabilityPremium.FactorIncrease4 = CalculateFactorIncrease(personalLiability, personalLiability.PersonalLiabilityPremium.PersonalLiability4);
            personalLiability.PersonalLiabilityPremium.MedPayment4 = CalculateMedicalPayment(personalLiability, personalLiability.PersonalLiabilityPremium.MedicalPayment4, personalLiability.PersonalLiabilityPremium.Families4);

            personalLiability.PersonalLiabilityPremium.BasicPremium4 = Math.Round(personalLiability.PersonalLiabilityPremium.BasicRate4 * personalLiability.PersonalLiabilityPremium.FactorIncrease4, 0);
            personalLiability.PersonalLiabilityPremium.TotalPremium4 = personalLiability.PersonalLiabilityPremium.BasicPremium4 + personalLiability.PersonalLiabilityPremium.MedPayment4;

            personalLiability.PersonalLiabilityPremium.TotalPremium4 = Math.Round(personalLiability.PersonalLiabilityPremium.TotalPremium4 * pl._DiscountFactor, 0);

            return personalLiability;
        }

        private static double CalculateBasicRate(PersonalLiability pl, int Families)
         {
             //PersonalLiability pl = new PersonalLiability();
             switch (Families)
             {
                 case 1:
                     return pl._BasicRate1;
                     break;

                 case 2:
                     return pl._BasicRate2;
                     break;

                 case 3:
                     return pl._BasicRate3;
                     break;

                 case 4:
                     return pl._BasicRate4;
                     break;
             }

             return pl._BasicRate1;
        }

        private static double CalculateFactorIncrease(PersonalLiability pl, int personalLiability)
        {
            //PersonalLiability pl = new PersonalLiability();

            switch (personalLiability)
            {
                case 100000:
                    return pl._FactorInc100000;
                    break;

                case 200000:
                    return pl._FactorInc200000;
                    break;

                case 300000:
                    return pl._FactorInc300000;
                    break;

                case 400000:
                    return pl._FactorInc400000;
                    break;

                case 500000:
                    return pl._FactorInc500000;
                    break;
            }

            return 1.00;

        }

        private static double CalculateMedicalPayment(PersonalLiability pl, int medicalPayment, int Families)
        {
            //PersonalLiability pl = new PersonalLiability();

            switch (Families)
            {
                case 1:
                    if (medicalPayment == 1000)
                        return pl._MedPayment1000;

                    if (medicalPayment == 2000)
                        return pl._MedPayment2000Fam1;

                    if (medicalPayment == 3000)
                        return pl._MedPayment3000Fam1;

                    if (medicalPayment == 5000)
                        return pl._MedPayment5000Fam1;
                    break;

                case 2:
                    if (medicalPayment == 1000)
                        return pl._MedPayment1000;

                    if (medicalPayment == 2000)
                        return pl._MedPayment2000Fam2;

                    if (medicalPayment == 3000)
                        return pl._MedPayment3000Fam2;

                    if (medicalPayment == 5000)
                        return pl._MedPayment5000Fam2;
                    break;

                case 3:
                    if (medicalPayment == 1000)
                        return pl._MedPayment1000;

                    if (medicalPayment == 2000)
                        return pl._MedPayment2000Fam3;

                    if (medicalPayment == 3000)
                        return pl._MedPayment3000Fam3;

                    if (medicalPayment == 5000)
                        return pl._MedPayment5000Fam3;
                    break;

                case 4:
                    if (medicalPayment == 1000)
                        return pl._MedPayment1000;

                    if (medicalPayment == 2000)
                        return pl._MedPayment2000Fam4;

                    if (medicalPayment == 3000)
                        return pl._MedPayment3000Fam4;

                    if (medicalPayment == 5000)
                        return pl._MedPayment5000Fam4;
                    break;
            }
            return 0.00;
        }
    }

    public class PersonalLiabilityPremium
    {
        public PersonalLiabilityPremium()
        {

        }

        #region Private Variable
        private double _TotalPremium = 0.00;

        private int _PersonalLiability1 = 0;
        private bool _Rented1 = false;
        private int _MedicalPayment1 = 0;
        private int _Families1 = 0;
        private double _BasicRate1 = 0.00;
        private double _FactorIncrease1 = 0.00;
        private double _BasicPremium1 = 0.00;
        private double _MedPayment1 = 0.00;
        private double _DiscountFactor1 = 0.80;
        private double _TotalPremium1 = 0.00;

        private int _PersonalLiability2 = 0;
        private bool _Rented2 = false;
        private int _MedicalPayment2 = 0;
        private int _Families2 = 0;
        private double _BasicRate2 = 0.00;
        private double _FactorIncrease2 = 0.00;
        private double _BasicPremium2 = 0.00;
        private double _MedPayment2 = 0.00;
        private double _DiscountFactor2 = 0.80;
        private double _TotalPremium2 = 0.00;

        private int _PersonalLiability3 = 0;
        private bool _Rented3 = false;
        private int _MedicalPayment3 = 0;
        private int _Families3 = 0;
        private double _BasicRate3 = 0.00;
        private double _FactorIncrease3 = 0.00;
        private double _BasicPremium3 = 0.00;
        private double _MedPayment3 = 0.00;
        private double _DiscountFactor3 = 0.80;
        private double _TotalPremium3 = 0.00;

        private int _PersonalLiability4 = 0;
        private bool _Rented4 = false;
        private int _MedicalPayment4 = 0;
        private int _Families4 = 0;
        private double _BasicRate4 = 0.00;
        private double _FactorIncrease4 = 0.00;
        private double _BasicPremium4 = 0.00;
        private double _MedPayment4 = 0.00;
        private double _DiscountFactor4 = 0.80;
        private double _TotalPremium4 = 0.00;
        #endregion

        #region Properties

        public double TotalPremium
        {
            get
            {
                return this._TotalPremium;
            }
            set
            {
                this._TotalPremium = value;
            }
        }

        public int PersonalLiability1
        {
            get
            {
                return this._PersonalLiability1;
            }
            set
            {
                this._PersonalLiability1 = value;
            }
        }

        public bool Rented1
        {
            get
            {
                return this._Rented1;
            }
            set
            {
                this._Rented1 = value;
            }
        }


        public int MedicalPayment1
        {
            get
            {
                return this._MedicalPayment1;
            }
            set
            {
                this._MedicalPayment1 = value;
            }
        }

        public int Families1
        {
            get
            {
                return this._Families1;
            }
            set
            {
                this._Families1 = value;
            }
        }

        public double BasicRate1
        {
            get
            {
                return this._BasicRate1;
            }
            set
            {
                this._BasicRate1 = value;
            }
        }

        public double FactorIncrease1
        {
            get
            {
                return this._FactorIncrease1;
            }
            set
            {
                this._FactorIncrease1 = value;
            }
        }

        public double BasicPremium1
        {
            get
            {
                return this._BasicPremium1;
            }
            set
            {
                this._BasicPremium1 = value;
            }
        }

        public double MedPayment1
        {
            get
            {
                return this._MedPayment1;
            }
            set
            {
                this._MedPayment1 = value;
            }
        }

        public double DiscountFactor1
        {
            get
            {
                return this._DiscountFactor1;
            }
            set
            {
                this._DiscountFactor1 = value;
            }
        }

        public double TotalPremium1
        {
            get
            {
                return this._TotalPremium1;
            }
            set
            {
                this._TotalPremium1 = value;
            }
        }

        public int PersonalLiability2
        {
            get
            {
                return this._PersonalLiability2;
            }
            set
            {
                this._PersonalLiability2 = value;
            }
        }

        public bool Rented2
        {
            get
            {
                return this._Rented2;
            }
            set
            {
                this._Rented2 = value;
            }
        }

        public int MedicalPayment2
        {
            get
            {
                return this._MedicalPayment2;
            }
            set
            {
                this._MedicalPayment2 = value;
            }
        }

        public int Families2
        {
            get
            {
                return this._Families2;
            }
            set
            {
                this._Families2 = value;
            }
        }
        
        public double BasicRate2
        {
            get
            {
                return this._BasicRate2;
            }
            set
            {
                this._BasicRate2 = value;
            }
        }

        public double FactorIncrease2
        {
            get
            {
                return this._FactorIncrease2;
            }
            set
            {
                this._FactorIncrease2 = value;
            }
        }

        public double BasicPremium2
        {
            get
            {
                return this._BasicPremium2;
            }
            set
            {
                this._BasicPremium2 = value;
            }
        }

        public double MedPayment2
        {
            get
            {
                return this._MedPayment2;
            }
            set
            {
                this._MedPayment2 = value;
            }
        }

        public double DiscountFactor2
        {
            get
            {
                return this._DiscountFactor2;
            }
            set
            {
                this._DiscountFactor2 = value;
            }
        }

        public double TotalPremium2
        {
            get
            {
                return this._TotalPremium2;
            }
            set
            {
                this._TotalPremium2 = value;
            }
        }

        public int PersonalLiability3
        {
            get
            {
                return this._PersonalLiability3;
            }
            set
            {
                this._PersonalLiability3 = value;
            }
        }

        public bool Rented3
        {
            get
            {
                return this._Rented3;
            }
            set
            {
                this._Rented3 = value;
            }
        }

        public int MedicalPayment3
        {
            get
            {
                return this._MedicalPayment3;
            }
            set
            {
                this._MedicalPayment3 = value;
            }
        }

        public int Families3
        {
            get
            {
                return this._Families3;
            }
            set
            {
                this._Families3 = value;
            }
        }

        public double BasicRate3
        {
            get
            {
                return this._BasicRate3;
            }
            set
            {
                this._BasicRate3 = value;
            }
        }

        public double FactorIncrease3
        {
            get
            {
                return this._FactorIncrease3;
            }
            set
            {
                this._FactorIncrease3 = value;
            }
        }

        public double BasicPremium3
        {
            get
            {
                return this._BasicPremium3;
            }
            set
            {
                this._BasicPremium3 = value;
            }
        }

        public double MedPayment3
        {
            get
            {
                return this._MedPayment3;
            }
            set
            {
                this._MedPayment3 = value;
            }
        }

        public double DiscountFactor3
        {
            get
            {
                return this._DiscountFactor3;
            }
            set
            {
                this._DiscountFactor3 = value;
            }
        }

        public double TotalPremium3
        {
            get
            {
                return this._TotalPremium3;
            }
            set
            {
                this._TotalPremium3 = value;
            }
        }

        public int PersonalLiability4
        {
            get
            {
                return this._PersonalLiability4;
            }
            set
            {
                this._PersonalLiability4 = value;
            }
        }

        public bool Rented4
        {
            get
            {
                return this._Rented4;
            }
            set
            {
                this._Rented4 = value;
            }
        }

        public int MedicalPayment4
        {
            get
            {
                return this._MedicalPayment4;
            }
            set
            {
                this._MedicalPayment4 = value;
            }
        }

        public int Families4
        {
            get
            {
                return this._Families4;
            }
            set
            {
                this._Families4 = value;
            }
        }

        public double BasicRate4
        {
            get
            {
                return this._BasicRate4;
            }
            set
            {
                this._BasicRate4 = value;
            }
        }

        public double FactorIncrease4
        {
            get
            {
                return this._FactorIncrease4;
            }
            set
            {
                this._FactorIncrease4 = value;
            }
        }

        public double BasicPremium4
        {
            get
            {
                return this._BasicPremium4;
            }
            set
            {
                this._BasicPremium4 = value;
            }
        }

        public double MedPayment4
        {
            get
            {
                return this._MedPayment4;
            }
            set
            {
                this._MedPayment4 = value;
            }
        }

        public double DiscountFactor4
        {
            get
            {
                return this._DiscountFactor4;
            }
            set
            {
                this._DiscountFactor4 = value;
            }
        }

        public double TotalPremium4
        {
            get
            {
                return this._TotalPremium4;
            }
            set
            {
                this._TotalPremium4 = value;
            }
        }

        #endregion
    }
}
