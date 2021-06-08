using System;
using System.Data;
using System.Text;
using System.IO;
using Baldrich.DBRequest;
using System.Xml;
using EPolicy.Customer;
using System.Reflection;
using EPolicy.TaskControl;
using EPolicy.Audit;
using EPolicy.XmlCooker;
using System.Web.UI.WebControls;
using System.Configuration;

namespace EPolicy.TaskControl
{
    public class Application : TaskControl
    {
        public Application()
        {
            this.PolicyClassID = 0;
            this.InsuranceCompany = "000";
            this.Agency = "000";
            this.Agent = "000";
            this.Bank = "000";
            this.Dealer = "000";
            this.CompanyDealer = "000";
            this.TaskStatusID = int.Parse(LookupTables.LookupTables.GetID("TaskStatus", "Open"));
            this.TaskControlTypeID = int.Parse(LookupTables.LookupTables.GetID("TaskControlType", "Application"));
        }

        #region Miselaneos Variables

        DataTable dtApplication;
        private string applicationMode = "";
        public string ApplicationMode
        {
            get { return applicationMode; }
            set { applicationMode = value; }
        }

        private int status = 1; //Open
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion

        #region Variables & Properties Application1

        //Begin Application 1

        private int applicationID;

        public int ApplicationID
        {
            get { return applicationID; }
            set { applicationID = value; }
        }

        private string comments;

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        private string priCarierName1;

        public string PriCarierName1
        {
            get { return priCarierName1; }
            set { priCarierName1 = value; }
        }
        private string priPolEffecDate1;

        public string PriPolEffecDate1
        {
            get { return priPolEffecDate1; }
            set { priPolEffecDate1 = value; }
        }
        private string priPolLimits1;

        public string PriPolLimits1
        {
            get { return priPolLimits1; }
            set { priPolLimits1 = value; }
        }
        private string priClaims1;

        public string PriClaims1
        {
            get { return priClaims1; }
            set { priClaims1 = value; }
        }
        private string priCarierName2;

        public string PriCarierName2
        {
            get { return priCarierName2; }
            set { priCarierName2 = value; }
        }
        private string priPolEffecDate2;

        public string PriPolEffecDate2
        {
            get { return priPolEffecDate2; }
            set { priPolEffecDate2 = value; }
        }
        private string priPolLimits2;

        public string PriPolLimits2
        {
            get { return priPolLimits2; }
            set { priPolLimits2 = value; }
        }
        private string priClaims2;

        public string PriClaims2
        {
            get { return priClaims2; }
            set { priClaims2 = value; }
        }
        private string priCarierName3;

        public string PriCarierName3
        {
            get { return priCarierName3; }
            set { priCarierName3 = value; }
        }
        private string priPolEffecDate3;

        public string PriPolEffecDate3
        {
            get { return priPolEffecDate3; }
            set { priPolEffecDate3 = value; }
        }
        private string priPolLimits3;

        public string PriPolLimits3
        {
            get { return priPolLimits3; }
            set { priPolLimits3 = value; }
        }
        private string priClaims3;

        public string PriClaims3
        {
            get { return priClaims3; }
            set { priClaims3 = value; }
        }
        private string excCarierName1;

        public string ExcCarierName1
        {
            get { return excCarierName1; }
            set { excCarierName1 = value; }
        }
        private string excPolEffecDate1;

        public string ExcPolEffecDate1
        {
            get { return excPolEffecDate1; }
            set { excPolEffecDate1 = value; }
        }
        private string excPolLimits1;

        public string ExcPolLimits1
        {
            get { return excPolLimits1; }
            set { excPolLimits1 = value; }
        }
        private string excClaims1;

        public string ExcClaims1
        {
            get { return excClaims1; }
            set { excClaims1 = value; }
        }
        private string excCarierName2;

        public string ExcCarierName2
        {
            get { return excCarierName2; }
            set { excCarierName2 = value; }
        }
        private string excPolEffecDate2;

        public string ExcPolEffecDate2
        {
            get { return excPolEffecDate2; }
            set { excPolEffecDate2 = value; }
        }
        private string excPolLimits2;

        public string ExcPolLimits2
        {
            get { return excPolLimits2; }
            set { excPolLimits2 = value; }
        }
        private string excClaims2;

        public string ExcClaims2
        {
            get { return excClaims2; }
            set { excClaims2 = value; }
        }
        private string excCarierName3;

        public string ExcCarierName3
        {
            get { return excCarierName3; }
            set { excCarierName3 = value; }
        }
        private string excPolEffecDate3;

        public string ExcPolEffecDate3
        {
            get { return excPolEffecDate3; }
            set { excPolEffecDate3 = value; }
        }
        private string excPolLimits3;

        public string ExcPolLimits3
        {
            get { return excPolLimits3; }
            set { excPolLimits3 = value; }
        }
        private string excClaims3;

        public string ExcClaims3
        {
            get { return excClaims3; }
            set { excClaims3 = value; }
        }
        private bool mcaInsuranceCia;

        public bool McaInsuranceCia
        {
            get { return mcaInsuranceCia; }
            set { mcaInsuranceCia = value; }
        }
        private string insuranceCiaDesc;

        public string InsuranceCiaDesc
        {
            get { return insuranceCiaDesc; }
            set { insuranceCiaDesc = value; }
        }
        private string medSchool;

        public string MedSchool
        {
            get { return medSchool; }
            set { medSchool = value; }
        }
        private string medCity;

        public string MedCity
        {
            get { return medCity; }
            set { medCity = value; }
        }
        private string medFrom;

        public string MedFrom
        {
            get { return medFrom; }
            set { medFrom = value; }
        }
        private string medDegree;

        public string MedDegree
        {
            get { return medDegree; }
            set { medDegree = value; }
        }
        private string intSchool;

        public string IntSchool
        {
            get { return intSchool; }
            set { intSchool = value; }
        }
        private string intCity;

        public string IntCity
        {
            get { return intCity; }
            set { intCity = value; }
        }
        private string intFrom;

        public string IntFrom
        {
            get { return intFrom; }
            set { intFrom = value; }
        }
        private string intDegree;

        public string IntDegree
        {
            get { return intDegree; }
            set { intDegree = value; }
        }
        private string resSchool;

        public string ResSchool
        {
            get { return resSchool; }
            set { resSchool = value; }
        }
        private string resCity;

        public string ResCity
        {
            get { return resCity; }
            set { resCity = value; }
        }
        private string resFrom;

        public string ResFrom
        {
            get { return resFrom; }
            set { resFrom = value; }
        }
        private string resDegree;

        public string ResDegree
        {
            get { return resDegree; }
            set { resDegree = value; }
        }
        private string fellSchool;

        public string FellSchool
        {
            get { return fellSchool; }
            set { fellSchool = value; }
        }
        private string fellCity;

        public string FellCity
        {
            get { return fellCity; }
            set { fellCity = value; }
        }
        private string fellFrom;

        public string FellFrom
        {
            get { return fellFrom; }
            set { fellFrom = value; }
        }
        private string fellDegree;

        public string FellDegree
        {
            get { return fellDegree; }
            set { fellDegree = value; }
        }
        private string oSchool;

        public string OSchool
        {
            get { return oSchool; }
            set { oSchool = value; }
        }
        private string oCity;

        public string OCity
        {
            get { return oCity; }
            set { oCity = value; }
        }
        private string oFrom;

        public string OFrom
        {
            get { return oFrom; }
            set { oFrom = value; }
        }
        private string oDegree;

        public string ODegree
        {
            get { return oDegree; }
            set { oDegree = value; }
        }
        private bool mcaCertified;

        public bool McaCertified
        {
            get { return mcaCertified; }
            set { mcaCertified = value; }
        }
        private bool mcaResTraining;

        public bool McaResTraining
        {
            get { return mcaResTraining; }
            set { mcaResTraining = value; }
        }

        private string residency;
        public string Residency
        {
            get { return residency; }
            set { residency = value; }
        }

        private int pRMEDICRATEID;
        public int PRMEDICRATEID
        {
            get { return pRMEDICRATEID; }
            set { pRMEDICRATEID = value; }
        }

        private int pRMEDICSpecialtyID;
        public int PRMEDICSpecialtyID
        {
            get { return PRMEDICSpecialtyID; }
            set { PRMEDICSpecialtyID = value; }
        } 

        private string isoCode;
        public string IsoCode
        {
            get { return isoCode; }
            set { isoCode = value; }
        } 

        private string classRate;
        public string ClassRate
        {
            get { return classRate; }
            set { classRate = value; }
        } 

        private double rateYear1;
        public double RateYear1
        {
            get { return rateYear1; }
            set { rateYear1 = value; }
        } 

        private double rateYear2;
        public double RateYear2
        {
            get { return rateYear2; }
            set { rateYear2 = value; }
        } 

        private double rateYear3;
        public double RateYear3
        {
            get { return rateYear3; }
            set { rateYear3 = value; }
        } 

        private double mCMRate;
        public double MCMRate
        {
            get { return mCMRate; }
            set { mCMRate = value; }
        }

        private int pRMedicalLimitID;
        public int PRMedicalLimitID
        {
            get { return pRMedicalLimitID; }
            set { pRMedicalLimitID = value; }
        }

        private double rateYear12;
        public double RateYear12
        {
            get { return rateYear12; }
            set { rateYear12 = value; }
        }

        private double rateYear22;
        public double RateYear22
        {
            get { return rateYear22; }
            set { rateYear22 = value; }
        }

        private double rateYear32;
        public double RateYear32
        {
            get { return rateYear32; }
            set { rateYear32 = value; }
        }

        private double rateYear42;
        public double RateYear42
        {
            get { return rateYear42; }
            set { rateYear42 = value; }
        }

        private int pRMedicalLimit2ID;
        public int PRMedicalLimit2ID
        {
            get { return pRMedicalLimit2ID; }
            set { pRMedicalLimit2ID = value; }
        }

        private double rateYear13;
        public double RateYear13
        {
            get { return rateYear13; }
            set { rateYear13 = value; }
        }

        private double rateYear23;
        public double RateYear23
        {
            get { return rateYear23; }
            set { rateYear23 = value; }
        }

        private double rateYear33;
        public double RateYear33
        {
            get { return rateYear33; }
            set { rateYear33 = value; }
        }

        private double rateYear43;
        public double RateYear43
        {
            get { return rateYear43; }
            set { rateYear43 = value; }
        }

        private int pRMedicalLimit3ID;
        public int PRMedicalLimit3ID
        {
            get { return pRMedicalLimit3ID; }
            set { pRMedicalLimit3ID = value; }
        }

        private double rateYear14;
        public double RateYear14
        {
            get { return rateYear14; }
            set { rateYear14 = value; }
        }

        private double rateYear24;
        public double RateYear24
        {
            get { return rateYear24; }
            set { rateYear24 = value; }
        }

        private double rateYear34;
        public double RateYear34
        {
            get { return rateYear34; }
            set { rateYear34 = value; }
        }

        private double rateYear44;
        public double RateYear44
        {
            get { return rateYear44; }
            set { rateYear44 = value; }
        }

        private int pRMedicalLimit4ID;
        public int PRMedicalLimit4ID
        {
            get { return pRMedicalLimit4ID; }
            set { pRMedicalLimit4ID = value; }
        }

        private double rateYear15;
        public double RateYear15
        {
            get { return rateYear15; }
            set { rateYear15 = value; }
        }

        private double rateYear25;
        public double RateYear25
        {
            get { return rateYear25; }
            set { rateYear25 = value; }
        }

        private double rateYear35;
        public double RateYear35
        {
            get { return rateYear35; }
            set { rateYear35 = value; }
        }

        private double rateYear45;
        public double RateYear45
        {
            get { return rateYear45; }
            set { rateYear45 = value; }
        }

        private int pRMedicalLimit5ID;
        public int PRMedicalLimit5ID
        {
            get { return pRMedicalLimit5ID; }
            set { pRMedicalLimit5ID = value; }
        }

        private double rateYear16;
        public double RateYear16
        {
            get { return rateYear16; }
            set { rateYear16 = value; }
        }

        private double rateYear26;
        public double RateYear26
        {
            get { return rateYear26; }
            set { rateYear26 = value; }
        }

        private double rateYear36;
        public double RateYear36
        {
            get { return rateYear36; }
            set { rateYear36 = value; }
        }

        private double rateYear46;
        public double RateYear46
        {
            get { return rateYear46; }
            set { rateYear46 = value; }
        }

        private int pRMedicalLimit6ID;
        public int PRMedicalLimit6ID
        {
            get { return pRMedicalLimit6ID; }
            set { pRMedicalLimit6ID = value; }
        }

        private double pRateYear1;
        public double PRateYear1
        {
            get { return pRateYear1; }
            set { pRateYear1 = value; }
        }

        private double pRateYear2;
        public double PRateYear2
        {
            get { return pRateYear2; }
            set { pRateYear2 = value; }
        }

        private double pRateYear3;
        public double PRateYear3
        {
            get { return pRateYear3; }
            set { pRateYear3 = value; }
        }

        private double pRateYear4;
        public double PRateYear4
        {
            get { return pRateYear4; }
            set { pRateYear4 = value; }
        }

        private int pRPrimaryLimitID;
        public int PRPrimaryLimitID
        {
            get { return pRPrimaryLimitID; }
            set { pRPrimaryLimitID = value; }
        }

        private int pRPrimeryRateID;
        public int PRPrimeryRateID
        {
            get { return pRPrimeryRateID; }
            set { pRPrimeryRateID = value; }
        }

        private bool isPrimary;
        public bool IsPrimary
        {
            get { return isPrimary; }
            set { isPrimary = value; }
        }

        private string primaryRetroDate;
        public string PrimaryRetroDate
        {
            get { return primaryRetroDate; }
            set { primaryRetroDate = value; }
        }

        private string excessRetroDate;
        public string ExcessRetroDate
        {
            get { return excessRetroDate; }
            set { excessRetroDate = value; }
        }
        
        //End Application 1

        #endregion

        #region Variables & Properties Application2

        private string priSpecialty;

        public string PriSpecialty
        {
            get { return priSpecialty; }
            set { priSpecialty = value; }
        }
        private string priPractice;

        public string PriPractice
        {
            get { return priPractice; }
            set { priPractice = value; }
        }
        private string secSpecialty;

        public string SecSpecialty
        {
            get { return secSpecialty; }
            set { secSpecialty = value; }
        }
        private string secPractice;

        public string SecPractice
        {
            get { return secPractice; }
            set { secPractice = value; }
        }
        private bool mcaPracticeLimit;

        public bool McaPracticeLimit
        {
            get { return mcaPracticeLimit; }
            set { mcaPracticeLimit = value; }
        }
        private string practiceLimitDesc;

        public string PracticeLimitDesc
        {
            get { return practiceLimitDesc; }
            set { practiceLimitDesc = value; }
        }
        private bool mcaBoardCertified;

        public bool McaBoardCertified
        {
            get { return mcaBoardCertified; }
            set { mcaBoardCertified = value; }
        }
        private string boardCertifiedDesc1;

        public string BoardCertifiedDesc1
        {
            get { return boardCertifiedDesc1; }
            set { boardCertifiedDesc1 = value; }
        }
        private string boardCertifiedDesc2;

        public string BoardCertifiedDesc2
        {
            get { return boardCertifiedDesc2; }
            set { boardCertifiedDesc2 = value; }
        }
        private string boardCertifiedDesc3;

        public string BoardCertifiedDesc3
        {
            get { return boardCertifiedDesc3; }
            set { boardCertifiedDesc3 = value; }
        }

        private string boardCertifiedDesc4;

        public string BoardCertifiedDesc4
        {
            get { return boardCertifiedDesc4; }
            set { boardCertifiedDesc4 = value; }
        }

        private string boardCertifiedDesc5;

        public string BoardCertifiedDesc5
        {
            get { return boardCertifiedDesc5; }
            set { boardCertifiedDesc5 = value; }
        }

        private string boardCertifiedDesc6;

        public string BoardCertifiedDesc6
        {
            get { return boardCertifiedDesc6; }
            set { boardCertifiedDesc6 = value; }
        }

        private string boardCertifiedDesc7;

        public string BoardCertifiedDesc7
        {
            get { return boardCertifiedDesc7; }
            set { boardCertifiedDesc7 = value; }
        }
        private string boardCertifiedDesc8;

        public string BoardCertifiedDesc8
        {
            get { return boardCertifiedDesc8; }
            set { boardCertifiedDesc8 = value; }
        }
        private string boardCertifiedDesc9;

        public string BoardCertifiedDesc9
        {
            get { return boardCertifiedDesc9; }
            set { boardCertifiedDesc9 = value; }
        }

        private string boardCertifiedDesc10;

        public string BoardCertifiedDesc10
        {
            get { return boardCertifiedDesc10; }
            set { boardCertifiedDesc10 = value; }
        }
        private string boardCertifiedDesc11;

        public string BoardCertifiedDesc11
        {
            get { return boardCertifiedDesc11; }
            set { boardCertifiedDesc11 = value; }
        }
        private string boardCertifiedDesc12;

        public string BoardCertifiedDesc12
        {
            get { return boardCertifiedDesc12; }
            set { boardCertifiedDesc12 = value; }
        }

        private string eleExpDate;

        public string EleExpDate
        {
            get { return eleExpDate; }
            set { eleExpDate = value; }
        }
        private string expiredWhy;

        public string ExpiredWhy
        {
            get { return expiredWhy; }
            set { expiredWhy = value; }
        }
        private bool mcaBoardExam;

        public bool McaBoardExam
        {
            get { return mcaBoardExam; }
            set { mcaBoardExam = value; }
        }
        private string boardExamDesc;

        public string BoardExamDesc
        {
            get { return boardExamDesc; }
            set { boardExamDesc = value; }
        }
        private bool mcaWrittenExam;

        public bool McaWrittenExam
        {
            get { return mcaWrittenExam; }
            set { mcaWrittenExam = value; }
        }
        private string writtenWhen;

        public string WrittenWhen
        {
            get { return writtenWhen; }
            set { writtenWhen = value; }
        }
        private string writtenResult;

        public string WrittenResult
        {
            get { return writtenResult; }
            set { writtenResult = value; }
        }
        private bool mcaOralExam;

        public bool McaOralExam
        {
            get { return mcaOralExam; }
            set { mcaOralExam = value; }
        }
        private string oralWhen;

        public string OralWhen
        {
            get { return oralWhen; }
            set { oralWhen = value; }
        }
        private string oralResult;

        public string OralResult
        {
            get { return oralResult; }
            set { oralResult = value; }
        }
        private bool mcaFailedBoardExam;

        public bool McaFailedBoardExam
        {
            get { return mcaFailedBoardExam; }
            set { mcaFailedBoardExam = value; }
        }
        private string boardFailedSpecialty;

        public string BoardFailedSpecialty
        {
            get { return boardFailedSpecialty; }
            set { boardFailedSpecialty = value; }
        }
        private string boardDate;

        public string BoardDate
        {
            get { return boardDate; }
            set { boardDate = value; }
        }
        private bool mcaMilitary;

        public bool McaMilitary
        {
            get { return mcaMilitary; }
            set { mcaMilitary = value; }
        }
        private string militaryDesc;

        public string MilitaryDesc
        {
            get { return militaryDesc; }
            set { militaryDesc = value; }
        }
        private bool mcaMilitaryReserve;

        public bool McaMilitaryReserve
        {
            get { return mcaMilitaryReserve; }
            set { mcaMilitaryReserve = value; }
        }
        private string licState1;

        public string LicState1
        {
            get { return licState1; }
            set { licState1 = value; }
        }
        private string licYear1;

        public string LicYear1
        {
            get { return licYear1; }
            set { licYear1 = value; }
        }
        private string licNumber1;

        public string LicNumber1
        {
            get { return licNumber1; }
            set { licNumber1 = value; }
        }
        private string licStatus1;

        public string LicStatus1
        {
            get { return licStatus1; }
            set { licStatus1 = value; }
        }
        private string licState2;

        public string LicState2
        {
            get { return licState2; }
            set { licState2 = value; }
        }
        private string licYear2;

        public string LicYear2
        {
            get { return licYear2; }
            set { licYear2 = value; }
        }
        private string licNumber2;

        public string LicNumber2
        {
            get { return licNumber2; }
            set { licNumber2 = value; }
        }
        private string licStatus2;

        public string LicStatus2
        {
            get { return licStatus2; }
            set { licStatus2 = value; }
        }
        private string licState3;

        public string LicState3
        {
            get { return licState3; }
            set { licState3 = value; }
        }
        private string licYear3;

        public string LicYear3
        {
            get { return licYear3; }
            set { licYear3 = value; }
        }
        private string licNumber3;

        public string LicNumber3
        {
            get { return licNumber3; }
            set { licNumber3 = value; }
        }
        private string licStatus3;

        public string LicStatus3
        {
            get { return licStatus3; }
            set { licStatus3 = value; }
        }

        private string licInactive;
        public string LicInactive
        {
            get { return licInactive; }
            set { licInactive = value; }
        }

        private bool mcaMedSocieties;

        public bool McaMedSocieties
        {
            get { return mcaMedSocieties; }
            set { mcaMedSocieties = value; }
        }
        private string medSocietiesDesc;

        public string MedSocietiesDesc
        {
            get { return medSocietiesDesc; }
            set { medSocietiesDesc = value; }
        }
        private bool mcaNationalSocieties;

        public bool McaNationalSocieties
        {
            get { return mcaNationalSocieties; }
            set { mcaNationalSocieties = value; }
        }
        private string nationalSocietiesDesc;

        public string NationalSocietiesDesc
        {
            get { return nationalSocietiesDesc; }
            set { nationalSocietiesDesc = value; }
        }
        private bool mcaStateMedSocieties;

        public bool McaStateMedSocieties
        {
            get { return mcaStateMedSocieties; }
            set { mcaStateMedSocieties = value; }
        }
        private bool mcaLocalMedSocieties;

        public bool McaLocalMedSocieties
        {
            get { return mcaLocalMedSocieties; }
            set { mcaLocalMedSocieties = value; }
        }



        #endregion

        #region Variables & Properties Application3

        private string hospital1;

        public string Hospital1
        {
            get { return hospital1; }
            set { hospital1 = value; }
        }
        private string city1;

        public string City1
        {
            get { return city1; }
            set { city1 = value; }
        }
        private string privileges1;

        public string Privileges1
        {
            get { return privileges1; }
            set { privileges1 = value; }
        }
        private string restrictions1;

        public string Restrictions1
        {
            get { return restrictions1; }
            set { restrictions1 = value; }
        }
        private string hospital2;

        public string Hospital2
        {
            get { return hospital2; }
            set { hospital2 = value; }
        }
        private string city2;

        public string City2
        {
            get { return city2; }
            set { city2 = value; }
        }
        private string privileges2;

        public string Privileges2
        {
            get { return privileges2; }
            set { privileges2 = value; }
        }
        private string restrictions2;

        public string Restrictions2
        {
            get { return restrictions2; }
            set { restrictions2 = value; }
        }
        private string hospital3;

        public string Hospital3
        {
            get { return hospital3; }
            set { hospital3 = value; }
        }
        private string city3;

        public string City3
        {
            get { return city3; }
            set { city3 = value; }
        }
        private string privileges3;

        public string Privileges3
        {
            get { return privileges3; }
            set { privileges3 = value; }
        }
        private string restrictions3;

        public string Restrictions3
        {
            get { return restrictions3; }
            set { restrictions3 = value; }
        }
        private string hospital4;

        public string Hospital4
        {
            get { return hospital4; }
            set { hospital4 = value; }
        }
        private string city4;

        public string City4
        {
            get { return city4; }
            set { city4 = value; }
        }
        private string privileges4;

        public string Privileges4
        {
            get { return privileges4; }
            set { privileges4 = value; }
        }
        private string restrictions4;

        public string Restrictions4
        {
            get { return restrictions4; }
            set { restrictions4 = value; }
        }
        private string oficeAddr1;

        public string OficeAddr1
        {
            get { return oficeAddr1; }
            set { oficeAddr1 = value; }
        }
        private string oficeCity1;

        public string OficeCity1
        {
            get { return oficeCity1; }
            set { oficeCity1 = value; }
        }
        private string oficeCountry1;

        public string OficeCountry1
        {
            get { return oficeCountry1; }
            set { oficeCountry1 = value; }
        }
        private string oficeAddr2;

        public string OficeAddr2
        {
            get { return oficeAddr2; }
            set { oficeAddr2 = value; }
        }
        private string oficeCity2;

        public string OficeCity2
        {
            get { return oficeCity2; }
            set { oficeCity2 = value; }
        }
        private string oficeCountry2;

        public string OficeCountry2
        {
            get { return oficeCountry2; }
            set { oficeCountry2 = value; }
        }
        private string oficeAddr3;

        public string OficeAddr3
        {
            get { return oficeAddr3; }
            set { oficeAddr3 = value; }
        }
        private string oficeCity3;

        public string OficeCity3
        {
            get { return oficeCity3; }
            set { oficeCity3 = value; }
        }
        private string oficeCountry3;

        public string OficeCountry3
        {
            get { return oficeCountry3; }
            set { oficeCountry3 = value; }
        }
        private string entName1;

        public string EntName1
        {
            get { return entName1; }
            set { entName1 = value; }
        }
        private string entDate1;

        public string EntDate1
        {
            get { return entDate1; }
            set { entDate1 = value; }
        }
        private string entAddr1;

        public string EntAddr1
        {
            get { return entAddr1; }
            set { entAddr1 = value; }
        }
        private string entSpecialty1;

        public string EntSpecialty1
        {
            get { return entSpecialty1; }
            set { entSpecialty1 = value; }
        }
        private string entName2;

        public string EntName2
        {
            get { return entName2; }
            set { entName2 = value; }
        }
        private string entDate2;

        public string EntDate2
        {
            get { return entDate2; }
            set { entDate2 = value; }
        }
        private string entAddr2;

        public string EntAddr2
        {
            get { return entAddr2; }
            set { entAddr2 = value; }
        }
        private string entSpecialty2;

        public string EntSpecialty2
        {
            get { return entSpecialty2; }
            set { entSpecialty2 = value; }
        }
        private string entName3;

        public string EntName3
        {
            get { return entName3; }
            set { entName3 = value; }
        }
        private string entDate3;

        public string EntDate3
        {
            get { return entDate3; }
            set { entDate3 = value; }
        }
        private string entAddr3;

        public string EntAddr3
        {
            get { return entAddr3; }
            set { entAddr3 = value; }
        }
        private string entSpecialty3;

        public string EntSpecialty3
        {
            get { return entSpecialty3; }
            set { entSpecialty3 = value; }
        }
        private string entName4;

        public string EntName4
        {
            get { return entName4; }
            set { entName4 = value; }
        }
        private string entDate4;

        public string EntDate4
        {
            get { return entDate4; }
            set { entDate4 = value; }
        }
        private string entAddr4;

        public string EntAddr4
        {
            get { return entAddr4; }
            set { entAddr4 = value; }
        }
        private string entSpecialty4;

        public string EntSpecialty4
        {
            get { return entSpecialty4; }
            set { entSpecialty4 = value; }
        }
        private string entName5;

        public string EntName5
        {
            get { return entName5; }
            set { entName5 = value; }
        }
        private string entDate5;

        public string EntDate5
        {
            get { return entDate5; }
            set { entDate5 = value; }
        }
        private string entAddr5;

        public string EntAddr5
        {
            get { return entAddr5; }
            set { entAddr5 = value; }
        }
        private string entSpecialty5;

        public string EntSpecialty5
        {
            get { return entSpecialty5; }
            set { entSpecialty5 = value; }
        }
        private bool mcaPhysician;

        public bool McaPhysician
        {
            get { return mcaPhysician; }
            set { mcaPhysician = value; }
        }
        private bool mcaEmpPhysician;

        public bool McaEmpPhysician
        {
            get { return mcaEmpPhysician; }
            set { mcaEmpPhysician = value; }
        }
        private bool mcaProfAss;

        public bool McaProfAss
        {
            get { return mcaProfAss; }
            set { mcaProfAss = value; }
        }
        private bool mcaOther;

        public bool McaOther
        {
            get { return mcaOther; }
            set { mcaOther = value; }
        }
        private bool mcaPartnership;

        public bool McaPartnership
        {
            get { return mcaPartnership; }
            set { mcaPartnership = value; }
        }
        private bool mcaGroup;

        public bool McaGroup
        {
            get { return mcaGroup; }
            set { mcaGroup = value; }
        }
        private bool mcaProfCorp;

        public bool McaProfCorp
        {
            get { return mcaProfCorp; }
            set { mcaProfCorp = value; }
        }
        private string phyEntName;

        public string PhyEntName
        {
            get { return phyEntName; }
            set { phyEntName = value; }
        }
        private string phyStatus;

        public string PhyStatus
        {
            get { return phyStatus; }
            set { phyStatus = value; }
        }
        private string phyPartners;

        public string PhyPartners
        {
            get { return phyPartners; }
            set { phyPartners = value; }
        }
        private bool mcaOtherPhy;

        public bool McaOtherPhy
        {
            get { return mcaOtherPhy; }
            set { mcaOtherPhy = value; }
        }
        private string phyName;

        public string PhyName
        {
            get { return phyName; }
            set { phyName = value; }
        }
        private string phyAssoc;

        public string PhyAssoc
        {
            get { return phyAssoc; }
            set { phyAssoc = value; }
        }
        private bool mcaRefferral;

        public bool McaRefferral
        {
            get { return mcaRefferral; }
            set { mcaRefferral = value; }
        }
        private string refferralDesc;

        public string RefferralDesc
        {
            get { return refferralDesc; }
            set { refferralDesc = value; }
        }


        #endregion

        #region Variables & Properties Application4

        private bool mcaLab;

        public bool McaLab
        {
            get { return mcaLab; }
            set { mcaLab = value; }
        }
        private string labHours;

        public string LabHours
        {
            get { return labHours; }
            set { labHours = value; }
        }
        private string labEmp;

        public string LabEmp
        {
            get { return labEmp; }
            set { labEmp = value; }
        }
        private bool mcaPhy;

        public bool McaPhy
        {
            get { return mcaPhy; }
            set { mcaPhy = value; }
        }
        private string phyHours;

        public string PhyHours
        {
            get { return phyHours; }
            set { phyHours = value; }
        }
        private string phyEmp;

        public string PhyEmp
        {
            get { return phyEmp; }
            set { phyEmp = value; }
        }
        private bool mcaXray;

        public bool McaXray
        {
            get { return mcaXray; }
            set { mcaXray = value; }
        }
        private string xrayHours;

        public string XrayHours
        {
            get { return xrayHours; }
            set { xrayHours = value; }
        }
        private string xrayEmp;

        public string XrayEmp
        {
            get { return xrayEmp; }
            set { xrayEmp = value; }
        }
        private bool mcaOtherApp3;

        public bool McaOtherApp3
        {
            get { return mcaOtherApp3; }
            set { mcaOtherApp3 = value; }
        }
        private string otherHours;

        public string OtherHours
        {
            get { return otherHours; }
            set { otherHours = value; }
        }
        private string otherEmp;

        public string OtherEmp
        {
            get { return otherEmp; }
            set { otherEmp = value; }
        }
        private bool mcaNurseAnes;

        public bool McaNurseAnes
        {
            get { return mcaNurseAnes; }
            set { mcaNurseAnes = value; }
        }
        private string nurseAnesHours;

        public string NurseAnesHours
        {
            get { return nurseAnesHours; }
            set { nurseAnesHours = value; }
        }
        private string nurseAnesEmp;

        public string NurseAnesEmp
        {
            get { return nurseAnesEmp; }
            set { nurseAnesEmp = value; }
        }
        private bool mcaNurseMid;

        public bool McaNurseMid
        {
            get { return mcaNurseMid; }
            set { mcaNurseMid = value; }
        }
        private string nurseMidHours;

        public string NurseMidHours
        {
            get { return nurseMidHours; }
            set { nurseMidHours = value; }
        }
        private string nurseMidEmp;

        public string NurseMidEmp
        {
            get { return nurseMidEmp; }
            set { nurseMidEmp = value; }
        }
        private bool mcaNursePerf;

        public bool McaNursePerf
        {
            get { return mcaNursePerf; }
            set { mcaNursePerf = value; }
        }
        private string nursePerfHours;

        public string NursePerfHours
        {
            get { return nursePerfHours; }
            set { nursePerfHours = value; }
        }
        private string nursePerfEmp;

        public string NursePerfEmp
        {
            get { return nursePerfEmp; }
            set { nursePerfEmp = value; }
        }
        private bool mcaNursePrac;

        public bool McaNursePrac
        {
            get { return mcaNursePrac; }
            set { mcaNursePrac = value; }
        }
        private string nursePracHours;

        public string NursePracHours
        {
            get { return nursePracHours; }
            set { nursePracHours = value; }
        }
        private string nursePracEmp;

        public string NursePracEmp
        {
            get { return nursePracEmp; }
            set { nursePracEmp = value; }
        }
        private bool mcaOpto;

        public bool McaOpto
        {
            get { return mcaOpto; }
            set { mcaOpto = value; }
        }
        private string optoHours;

        public string OptoHours
        {
            get { return optoHours; }
            set { optoHours = value; }
        }
        private string optoEmp;

        public string OptoEmp
        {
            get { return optoEmp; }
            set { optoEmp = value; }
        }
        private bool mcaPhyAss;

        public bool McaPhyAss
        {
            get { return mcaPhyAss; }
            set { mcaPhyAss = value; }
        }
        private string phyAssHours;

        public string PhyAssHours
        {
            get { return phyAssHours; }
            set { phyAssHours = value; }
        }
        private string phyAssEmp;

        public string PhyAssEmp
        {
            get { return phyAssEmp; }
            set { phyAssEmp = value; }
        }
        private bool mcaPsych;

        public bool McaPsych
        {
            get { return mcaPsych; }
            set { mcaPsych = value; }
        }
        private string psychHours;

        public string PsychHours
        {
            get { return psychHours; }
            set { psychHours = value; }
        }
        private string psychEmp;

        public string PsychEmp
        {
            get { return psychEmp; }
            set { psychEmp = value; }
        }
        private bool mcaScrub;

        public bool McaScrub
        {
            get { return mcaScrub; }
            set { mcaScrub = value; }
        }
        private string scrubHours;

        public string ScrubHours
        {
            get { return scrubHours; }
            set { scrubHours = value; }
        }
        private string scrubEmp;

        public string ScrubEmp
        {
            get { return scrubEmp; }
            set { scrubEmp = value; }
        }
        private bool mcaSurgical;

        public bool McaSurgical
        {
            get { return mcaSurgical; }
            set { mcaSurgical = value; }
        }
        private string surgicalHours;

        public string SurgicalHours
        {
            get { return surgicalHours; }
            set { surgicalHours = value; }
        }
        private string surgicalEmp;

        public string SurgicalEmp
        {
            get { return surgicalEmp; }
            set { surgicalEmp = value; }
        }


        public bool mcaOtherDesc;
        public bool McaOtherDesc
        {
            get { return mcaOtherDesc; }
            set { mcaOtherDesc = value; }
        }

        public string otherDescHours;
        public string OtherDescHours
        {
            get { return otherDescHours; }
            set { otherDescHours = value; }
        }

        public string otherDescEmp;
        public string OtherDescEmp
        {
            get { return otherDescEmp; }
            set { otherDescEmp = value; }
        }

        private string hCName1;

        public string HCName1
        {
            get { return hCName1; }
            set { hCName1 = value; }
        }
        private string hCSpeciality1;

        public string HCSpeciality1
        {
            get { return hCSpeciality1; }
            set { hCSpeciality1 = value; }
        }
        private string hCInsured1;

        public string HCInsured1
        {
            get { return hCInsured1; }
            set { hCInsured1 = value; }
        }
        private string hCLimits1;

        public string HCLimits1
        {
            get { return hCLimits1; }
            set { hCLimits1 = value; }
        }
        private string hCName2;

        public string HCName2
        {
            get { return hCName2; }
            set { hCName2 = value; }
        }
        private string hCSpecialty2;

        public string HCSpecialty2
        {
            get { return hCSpecialty2; }
            set { hCSpecialty2 = value; }
        }
        private string hCInsured2;

        public string HCInsured2
        {
            get { return hCInsured2; }
            set { hCInsured2 = value; }
        }
        private string hCLimits2;

        public string HCLimits2
        {
            get { return hCLimits2; }
            set { hCLimits2 = value; }
        }
        private string hCName3;

        public string HCName3
        {
            get { return hCName3; }
            set { hCName3 = value; }
        }
        private string hCSpecialty3;

        public string HCSpecialty3
        {
            get { return hCSpecialty3; }
            set { hCSpecialty3 = value; }
        }
        private string hCInsured3;

        public string HCInsured3
        {
            get { return hCInsured3; }
            set { hCInsured3 = value; }
        }
        private string hCLimits3;

        public string HCLimits3
        {
            get { return hCLimits3; }
            set { hCLimits3 = value; }
        }

        private bool mcaNone;
        public bool McaNone
        {
            get { return mcaNone; }
            set { mcaNone = value; }
        }

        private bool mcaBlood;

        public bool McaBlood
        {
            get { return mcaBlood; }
            set { mcaBlood = value; }
        }
        private bool mcaBirthing;

        public bool McaBirthing
        {
            get { return mcaBirthing; }
            set { mcaBirthing = value; }
        }
        private bool mcaCity;

        public bool McaCity
        {
            get { return mcaCity; }
            set { mcaCity = value; }
        }
        private bool mcaClinic;

        public bool McaClinic
        {
            get { return mcaClinic; }
            set { mcaClinic = value; }
        }
        private bool mcaEmergency;

        public bool McaEmergency
        {
            get { return mcaEmergency; }
            set { mcaEmergency = value; }
        }
        private bool mcaEmerHospital;

        public bool McaEmerHospital
        {
            get { return mcaEmerHospital; }
            set { mcaEmerHospital = value; }
        }
        private bool mcaFreeStanding;

        public bool McaFreeStanding
        {
            get { return mcaFreeStanding; }
            set { mcaFreeStanding = value; }
        }
        private bool mcaHospital;

        public bool McaHospital
        {
            get { return mcaHospital; }
            set { mcaHospital = value; }
        }
        private bool mcaConva;

        public bool McaConva
        {
            get { return mcaConva; }
            set { mcaConva = value; }
        }
        private bool mcaPsy;

        public bool McaPsy
        {
            get { return mcaPsy; }
            set { mcaPsy = value; }
        }
        private bool mcaInd;

        public bool McaInd
        {
            get { return mcaInd; }
            set { mcaInd = value; }
        }
        private bool mcaLaboratory;

        public bool McaLaboratory
        {
            get { return mcaLaboratory; }
            set { mcaLaboratory = value; }
        }
        private bool mcaNursing;

        public bool McaNursing
        {
            get { return mcaNursing; }
            set { mcaNursing = value; }
        }
        private bool mcaSanitarium;

        public bool McaSanitarium
        {
            get { return mcaSanitarium; }
            set { mcaSanitarium = value; }
        }
        private bool mcaUrgent;

        public bool McaUrgent
        {
            get { return mcaUrgent; }
            set { mcaUrgent = value; }
        }
        private bool mcaXrayFacility;

        public bool McaXrayFacility
        {
            get { return mcaXrayFacility; }
            set { mcaXrayFacility = value; }
        }
        private bool mcaOtherHC;

        public bool McaOtherHC
        {
            get { return mcaOtherHC; }
            set { mcaOtherHC = value; }
        }
        private string facilityName1;

        public string FacilityName1
        {
            get { return facilityName1; }
            set { facilityName1 = value; }
        }
        private string facilityAddr1;

        public string FacilityAddr1
        {
            get { return facilityAddr1; }
            set { facilityAddr1 = value; }
        }
        private string facilityType1;

        public string FacilityType1
        {
            get { return facilityType1; }
            set { facilityType1 = value; }
        }
        private string facilityDuties1;

        public string FacilityDuties1
        {
            get { return facilityDuties1; }
            set { facilityDuties1 = value; }
        }
        private string facilityNumbers1;

        public string FacilityNumbers1
        {
            get { return facilityNumbers1; }
            set { facilityNumbers1 = value; }
        }
        
        private bool mcaProfLiab1;
        public bool McaProfLiab1
        {
            get { return mcaProfLiab1; }
            set { mcaProfLiab1 = value; }
        }

        private bool mcaExtendedCov1;
        public bool McaExtendedCov1
        {
            get { return mcaExtendedCov1; }
            set { mcaExtendedCov1 = value; }
        }

        private string facilityName2;

        public string FacilityName2
        {
            get { return facilityName2; }
            set { facilityName2 = value; }
        }
        private string facilityAddr2;

        public string FacilityAddr2
        {
            get { return facilityAddr2; }
            set { facilityAddr2 = value; }
        }
        private string facilityType2;

        public string FacilityType2
        {
            get { return facilityType2; }
            set { facilityType2 = value; }
        }
        private string facilityDuties2;

        public string FacilityDuties2
        {
            get { return facilityDuties2; }
            set { facilityDuties2 = value; }
        }
        private string facilityNumbers2;

        public string FacilityNumbers2
        {
            get { return facilityNumbers2; }
            set { facilityNumbers2 = value; }
        }
        private bool mcaProfLiab;

        public bool McaProfLiab
        {
            get { return mcaProfLiab; }
            set { mcaProfLiab = value; }
        }
        private bool mcaExtendedCov;

        public bool McaExtendedCov
        {
            get { return mcaExtendedCov; }
            set { mcaExtendedCov = value; }
        }
        private bool mcaFullTimeCov;

        public bool McaFullTimeCov
        {
            get { return mcaFullTimeCov; }
            set { mcaFullTimeCov = value; }
        }
        private bool mcaPartTimeCov;

        public bool McaPartTimeCov
        {
            get { return mcaPartTimeCov; }
            set { mcaPartTimeCov = value; }
        }
        private string daysPWeek;

        public string DaysPWeek
        {
            get { return daysPWeek; }
            set { daysPWeek = value; }
        }
        private string hoursPDayOffice;

        public string HoursPDayOffice
        {
            get { return hoursPDayOffice; }
            set { hoursPDayOffice = value; }
        }
        private string patienPWeek;

        public string PatienPWeek
        {
            get { return patienPWeek; }
            set { patienPWeek = value; }
        }
        private string hoursPDayHosp;

        public string HoursPDayHosp
        {
            get { return hoursPDayHosp; }
            set { hoursPDayHosp = value; }
        }
        private string actDesc;

        public string ActDesc
        {
            get { return actDesc; }
            set { actDesc = value; }
        }
        private string app339Number1;

        public string App339Number1
        {
            get { return app339Number1; }
            set { app339Number1 = value; }
        }
        private string app339Hours1;

        public string App339Hours1
        {
            get { return app339Hours1; }
            set { app339Hours1 = value; }
        }
        private string app339Number2;

        public string App339Number2
        {
            get { return app339Number2; }
            set { app339Number2 = value; }
        }
        private string app339Hours2;

        public string App339Hours2
        {
            get { return app339Hours2; }
            set { app339Hours2 = value; }
        }
        private string app339Number3;

        public string App339Number3
        {
            get { return app339Number3; }
            set { app339Number3 = value; }
        }
        private string app339Hours3;

        public string App339Hours3
        {
            get { return app339Hours3; }
            set { app339Hours3 = value; }
        }
        private string app339Number4;

        public string App339Number4
        {
            get { return app339Number4; }
            set { app339Number4 = value; }
        }
        private string app339Hours4;

        public string App339Hours4
        {
            get { return app339Hours4; }
            set { app339Hours4 = value; }
        }
        private string app339Number5;

        public string App339Number5
        {
            get { return app339Number5; }
            set { app339Number5 = value; }
        }
        private string app339Hours5;

        public string App339Hours5
        {
            get { return app339Hours5; }
            set { app339Hours5 = value; }
        }
        private string app339Number6;

        public string App339Number6
        {
            get { return app339Number6; }
            set { app339Number6 = value; }
        }
        private string app339Hours6;

        public string App339Hours6
        {
            get { return app339Hours6; }
            set { app339Hours6 = value; }
        }


        #endregion

        #region Variables & Properties Application5

        private bool mcaAngio;

        public bool McaAngio
        {
            get { return mcaAngio; }
            set { mcaAngio = value; }
        }
        private string angioNumber;

        public string AngioNumber
        {
            get { return angioNumber; }
            set { angioNumber = value; }
        }
        private bool mcaAngioPTA;

        public bool McaAngioPTA
        {
            get { return mcaAngioPTA; }
            set { mcaAngioPTA = value; }
        }
        private string angioPTANumber;

        public string AngioPTANumber
        {
            get { return angioPTANumber; }
            set { angioPTANumber = value; }
        }
        private bool mcaAorto;

        public bool McaAorto
        {
            get { return mcaAorto; }
            set { mcaAorto = value; }
        }
        private string aortoNumber;

        public string AortoNumber
        {
            get { return aortoNumber; }
            set { aortoNumber = value; }
        }
        private bool mcaBiopsy;

        public bool McaBiopsy
        {
            get { return mcaBiopsy; }
            set { mcaBiopsy = value; }
        }
        private string biopsyNumber;

        public string BiopsyNumber
        {
            get { return biopsyNumber; }
            set { biopsyNumber = value; }
        }
        private bool mcaBreast;

        public bool McaBreast
        {
            get { return mcaBreast; }
            set { mcaBreast = value; }
        }
        private string breastNumber;

        public string BreastNumber
        {
            get { return breastNumber; }
            set { breastNumber = value; }
        }
        private bool mcaBreastImpl;

        public bool McaBreastImpl
        {
            get { return mcaBreastImpl; }
            set { mcaBreastImpl = value; }
        }
        private string breastImplNumber;

        public string BreastImplNumber
        {
            get { return breastImplNumber; }
            set { breastImplNumber = value; }
        }
        private bool mcaCardiac;

        public bool McaCardiac
        {
            get { return mcaCardiac; }
            set { mcaCardiac = value; }
        }
        private string cardiacNumber;

        public string CardiacNumber
        {
            get { return cardiacNumber; }
            set { cardiacNumber = value; }
        }
        private bool mcaCoronary;

        public bool McaCoronary
        {
            get { return mcaCoronary; }
            set { mcaCoronary = value; }
        }
        private string coronaryNumber;

        public string CoronaryNumber
        {
            get { return coronaryNumber; }
            set { coronaryNumber = value; }
        }
        private bool mcaCholangio;

        public bool McaCholangio
        {
            get { return mcaCholangio; }
            set { mcaCholangio = value; }
        }
        private string cholangioNumber;

        public string CholangioNumber
        {
            get { return cholangioNumber; }
            set { cholangioNumber = value; }
        }
        private bool mcaContrast;

        public bool McaContrast
        {
            get { return mcaContrast; }
            set { mcaContrast = value; }
        }
        private string contrastNumber;

        public string ContrastNumber
        {
            get { return contrastNumber; }
            set { contrastNumber = value; }
        }
        private bool mcaEndo;

        public bool McaEndo
        {
            get { return mcaEndo; }
            set { mcaEndo = value; }
        }
        private string endoNumber;

        public string EndoNumber
        {
            get { return endoNumber; }
            set { endoNumber = value; }
        }
        private bool mcaHexa;

        public bool McaHexa
        {
            get { return mcaHexa; }
            set { mcaHexa = value; }
        }
        private string hexaNumber;

        public string HexaNumber
        {
            get { return hexaNumber; }
            set { hexaNumber = value; }
        }
        private bool mcaIntraO;

        public bool McaIntraO
        {
            get { return mcaIntraO; }
            set { mcaIntraO = value; }
        }
        private string intraONumber;

        public string IntraONumber
        {
            get { return intraONumber; }
            set { intraONumber = value; }
        }
        private bool mcaIntraG;

        public bool McaIntraG
        {
            get { return mcaIntraG; }
            set { mcaIntraG = value; }
        }
        private string intraGNumber;

        public string IntraGNumber
        {
            get { return intraGNumber; }
            set { intraGNumber = value; }
        }
        private bool mcaIvp;

        public bool McaIvp
        {
            get { return mcaIvp; }
            set { mcaIvp = value; }
        }
        private string ivpNumber;

        public string IvpNumber
        {
            get { return ivpNumber; }
            set { ivpNumber = value; }
        }
        private bool mcaKidney;

        public bool McaKidney
        {
            get { return mcaKidney; }
            set { mcaKidney = value; }
        }
        private string kidneyNumber;

        public string KidneyNumber
        {
            get { return kidneyNumber; }
            set { kidneyNumber = value; }
        }
        private bool mcaLiver;

        public bool McaLiver
        {
            get { return mcaLiver; }
            set { mcaLiver = value; }
        }
        private string liverNumber;

        public string LiverNumber
        {
            get { return liverNumber; }
            set { liverNumber = value; }
        }
        private bool mcaLipo;

        public bool McaLipo
        {
            get { return mcaLipo; }
            set { mcaLipo = value; }
        }
        private string lipoNumber;

        public string LipoNumber
        {
            get { return lipoNumber; }
            set { lipoNumber = value; }
        }
        private bool mcaLung;

        public bool McaLung
        {
            get { return mcaLung; }
            set { mcaLung = value; }
        }
        private string lungNumber;

        public string LungNumber
        {
            get { return lungNumber; }
            set { lungNumber = value; }
        }
        private bool mcaMyelo;

        public bool McaMyelo
        {
            get { return mcaMyelo; }
            set { mcaMyelo = value; }
        }
        private string myeloNumber;

        public string MyeloNumber
        {
            get { return myeloNumber; }
            set { myeloNumber = value; }
        }
        private bool mcaPaceT;

        public bool McaPaceT
        {
            get { return mcaPaceT; }
            set { mcaPaceT = value; }
        }
        private string paceNumberT;

        public string PaceNumberT
        {
            get { return paceNumberT; }
            set { paceNumberT = value; }
        }
        private bool mcaPaceP;

        public bool McaPaceP
        {
            get { return mcaPaceP; }
            set { mcaPaceP = value; }
        }
        private string paceNumberP;

        public string PaceNumberP
        {
            get { return paceNumberP; }
            set { paceNumberP = value; }
        }
        private bool mcaPercuT;

        public bool McaPercuT
        {
            get { return mcaPercuT; }
            set { mcaPercuT = value; }
        }
        private string percuNumberT;

        public string PercuNumberT
        {
            get { return percuNumberT; }
            set { percuNumberT = value; }
        }
        private bool mcaPercuG;

        public bool McaPercuG
        {
            get { return mcaPercuG; }
            set { mcaPercuG = value; }
        }
        private string percuNumberG;

        public string PercuNumberG
        {
            get { return percuNumberG; }
            set { percuNumberG = value; }
        }
        private bool mcaPerio;

        public bool McaPerio
        {
            get { return mcaPerio; }
            set { mcaPerio = value; }
        }
        private string perioNumber;

        public string PerioNumber
        {
            get { return perioNumber; }
            set { perioNumber = value; }
        }
        private bool mcaProstate;

        public bool McaProstate
        {
            get { return mcaProstate; }
            set { mcaProstate = value; }
        }
        private string prostateNumber;

        public string ProstateNumber
        {
            get { return prostateNumber; }
            set { prostateNumber = value; }
        }
        private bool mcaRadio;

        public bool McaRadio
        {
            get { return mcaRadio; }
            set { mcaRadio = value; }
        }
        private string radioNumber;

        public string RadioNumber
        {
            get { return radioNumber; }
            set { radioNumber = value; }
        }
        private bool mcaSilicone;

        public bool McaSilicone
        {
            get { return mcaSilicone; }
            set { mcaSilicone = value; }
        }
        private string siliconeNumber;

        public string SiliconeNumber
        {
            get { return siliconeNumber; }
            set { siliconeNumber = value; }
        }
        private bool mcaSaline;

        public bool McaSaline
        {
            get { return mcaSaline; }
            set { mcaSaline = value; }
        }
        private string salineNumber;

        public string SalineNumber
        {
            get { return salineNumber; }
            set { salineNumber = value; }
        }
        private bool mcaThera;

        public bool McaThera
        {
            get { return mcaThera; }
            set { mcaThera = value; }
        }
        private string theraNumber;

        public string TheraNumber
        {
            get { return theraNumber; }
            set { theraNumber = value; }
        }
        private bool mcaUseL;

        public bool McaUseL
        {
            get { return mcaUseL; }
            set { mcaUseL = value; }
        }
        private string useNumberL;

        public string UseNumberL
        {
            get { return useNumberL; }
            set { useNumberL = value; }
        }
        private bool mcaUseC;

        public bool McaUseC
        {
            get { return mcaUseC; }
            set { mcaUseC = value; }
        }
        private string useNumberC;

        public string UseNumberC
        {
            get { return useNumberC; }
            set { useNumberC = value; }
        }


        #endregion

        #region Variables & Properties Application6

        private bool mcaAbort;

        public bool McaAbort
        {
            get { return mcaAbort; }
            set { mcaAbort = value; }
        }
        private string abortYear;

        public string AbortYear
        {
            get { return abortYear; }
            set { abortYear = value; }
        }
        private string abortPercent;

        public string AbortPercent
        {
            get { return abortPercent; }
            set { abortPercent = value; }
        }
        private bool mcaAnes;

        public bool McaAnes
        {
            get { return mcaAnes; }
            set { mcaAnes = value; }
        }
        private string anesYear;

        public string AnesYear
        {
            get { return anesYear; }
            set { anesYear = value; }
        }
        private string anesPercent;

        public string AnesPercent
        {
            get { return anesPercent; }
            set { anesPercent = value; }
        }
        private bool mcaCardio;

        public bool McaCardio
        {
            get { return mcaCardio; }
            set { mcaCardio = value; }
        }
        private string cardioYear;

        public string CardioYear
        {
            get { return cardioYear; }
            set { cardioYear = value; }
        }
        private string cardioPercent;

        public string CardioPercent
        {
            get { return cardioPercent; }
            set { cardioPercent = value; }
        }
        private bool mcaChymo;

        public bool McaChymo
        {
            get { return mcaChymo; }
            set { mcaChymo = value; }
        }
        private string chymoYear;

        public string ChymoYear
        {
            get { return chymoYear; }
            set { chymoYear = value; }
        }
        private string chymoPercent;

        public string ChymoPercent
        {
            get { return chymoPercent; }
            set { chymoPercent = value; }
        }
        private bool mcaColon;

        public bool McaColon
        {
            get { return mcaColon; }
            set { mcaColon = value; }
        }
        private string colonYear;

        public string ColonYear
        {
            get { return colonYear; }
            set { colonYear = value; }
        }
        private string colonPercent;

        public string ColonPercent
        {
            get { return colonPercent; }
            set { colonPercent = value; }
        }
        private bool mcaGen;

        public bool McaGen
        {
            get { return mcaGen; }
            set { mcaGen = value; }
        }
        private string genYear;

        public string GenYear
        {
            get { return genYear; }
            set { genYear = value; }
        }
        private string genPercent;

        public string GenPercent
        {
            get { return genPercent; }
            set { genPercent = value; }
        }
        private bool mcaGyne;

        public bool McaGyne
        {
            get { return mcaGyne; }
            set { mcaGyne = value; }
        }
        private string gyneYear;

        public string GyneYear
        {
            get { return gyneYear; }
            set { gyneYear = value; }
        }
        private string gynePercent;

        public string GynePercent
        {
            get { return gynePercent; }
            set { gynePercent = value; }
        }
        private bool mcaHand;

        public bool McaHand
        {
            get { return mcaHand; }
            set { mcaHand = value; }
        }
        private string handYear;

        public string HandYear
        {
            get { return handYear; }
            set { handYear = value; }
        }
        private string handPercent;

        public string HandPercent
        {
            get { return handPercent; }
            set { handPercent = value; }
        }
        private bool mcaHead;

        public bool McaHead
        {
            get { return mcaHead; }
            set { mcaHead = value; }
        }
        private string headYear;

        public string HeadYear
        {
            get { return headYear; }
            set { headYear = value; }
        }
        private string headPercent;

        public string HeadPercent
        {
            get { return headPercent; }
            set { headPercent = value; }
        }
        private bool mcaLapa;

        public bool McaLapa
        {
            get { return mcaLapa; }
            set { mcaLapa = value; }
        }
        private string lapaYear;

        public string LapaYear
        {
            get { return lapaYear; }
            set { lapaYear = value; }
        }
        private string lapaPercent;

        public string LapaPercent
        {
            get { return lapaPercent; }
            set { lapaPercent = value; }
        }
        private bool app6mcaOther;

        public bool App6mcaOther
        {
            get { return app6mcaOther; }
            set { app6mcaOther = value; }
        }
        private string otherYear;

        public string OtherYear
        {
            get { return otherYear; }
            set { otherYear = value; }
        }
        private string otherPercent;

        public string OtherPercent
        {
            get { return otherPercent; }
            set { otherPercent = value; }
        }
        private bool app6mcaLipo;

        public bool App6mcaLipo
        {
            get { return app6mcaLipo; }
            set { app6mcaLipo = value; }
        }
        private string lipoYear;

        public string LipoYear
        {
            get { return lipoYear; }
            set { lipoYear = value; }
        }
        private string lipoPercent;

        public string LipoPercent
        {
            get { return lipoPercent; }
            set { lipoPercent = value; }
        }
        private bool mcaNeuro;

        public bool McaNeuro
        {
            get { return mcaNeuro; }
            set { mcaNeuro = value; }
        }
        private string neuroYear;

        public string NeuroYear
        {
            get { return neuroYear; }
            set { neuroYear = value; }
        }
        private string neuroPercent;

        public string NeuroPercent
        {
            get { return neuroPercent; }
            set { neuroPercent = value; }
        }
        private bool mcaObs;

        public bool McaObs
        {
            get { return mcaObs; }
            set { mcaObs = value; }
        }
        private string obsYear;

        public string ObsYear
        {
            get { return obsYear; }
            set { obsYear = value; }
        }
        private string obsPercent;

        public string ObsPercent
        {
            get { return obsPercent; }
            set { obsPercent = value; }
        }
        private bool mcaOph;

        public bool McaOph
        {
            get { return mcaOph; }
            set { mcaOph = value; }
        }
        private string ophYear;

        public string OphYear
        {
            get { return ophYear; }
            set { ophYear = value; }
        }
        private string ophPercent;

        public string OphPercent
        {
            get { return ophPercent; }
            set { ophPercent = value; }
        }
        private bool mcaOrth;

        public bool McaOrth
        {
            get { return mcaOrth; }
            set { mcaOrth = value; }
        }
        private string orthYear;

        public string OrthYear
        {
            get { return orthYear; }
            set { orthYear = value; }
        }
        private string orthPercent;

        public string OrthPercent
        {
            get { return orthPercent; }
            set { orthPercent = value; }
        }
        private bool mcaOrtho;

        public bool McaOrtho
        {
            get { return mcaOrtho; }
            set { mcaOrtho = value; }
        }
        private string orthoYear;

        public string OrthoYear
        {
            get { return orthoYear; }
            set { orthoYear = value; }
        }
        private string orthoPercent;

        public string OrthoPercent
        {
            get { return orthoPercent; }
            set { orthoPercent = value; }
        }
        private bool mcaOrthoReplace;

        public bool McaOrthoReplace
        {
            get { return mcaOrthoReplace; }
            set { mcaOrthoReplace = value; }
        }
        private string orthoReplaceYear;

        public string OrthoReplaceYear
        {
            get { return orthoReplaceYear; }
            set { orthoReplaceYear = value; }
        }
        private string orthoReplacePercent;

        public string OrthoReplacePercent
        {
            get { return orthoReplacePercent; }
            set { orthoReplacePercent = value; }
        }
        private bool mcaPlaSurElective;

        public bool McaPlaSurElective
        {
            get { return mcaPlaSurElective; }
            set { mcaPlaSurElective = value; }
        }
        private string plaSurElectiveYear;

        public string PlaSurElectiveYear
        {
            get { return plaSurElectiveYear; }
            set { plaSurElectiveYear = value; }
        }
        private string plaSurElectivePercent;

        public string PlaSurElectivePercent
        {
            get { return plaSurElectivePercent; }
            set { plaSurElectivePercent = value; }
        }
        private bool mcaPlaSurOther;

        public bool McaPlaSurOther
        {
            get { return mcaPlaSurOther; }
            set { mcaPlaSurOther = value; }
        }
        private string plaSurOtherYear;

        public string PlaSurOtherYear
        {
            get { return plaSurOtherYear; }
            set { plaSurOtherYear = value; }
        }
        private string plaSurOtherPercent;

        public string PlaSurOtherPercent
        {
            get { return plaSurOtherPercent; }
            set { plaSurOtherPercent = value; }
        }
        private bool mcaRefra;

        public bool McaRefra
        {
            get { return mcaRefra; }
            set { mcaRefra = value; }
        }
        private string refraYear;

        public string RefraYear
        {
            get { return refraYear; }
            set { refraYear = value; }
        }
        private string refraPercent;

        public string RefraPercent
        {
            get { return refraPercent; }
            set { refraPercent = value; }
        }
        private bool mcaSpinLumbar;

        public bool McaSpinLumbar
        {
            get { return mcaSpinLumbar; }
            set { mcaSpinLumbar = value; }
        }
        private string spinLumbarYear;

        public string SpinLumbarYear
        {
            get { return spinLumbarYear; }
            set { spinLumbarYear = value; }
        }
        private string spinLumbarPercent;

        public string SpinLumbarPercent
        {
            get { return spinLumbarPercent; }
            set { spinLumbarPercent = value; }
        }
        private bool mcaSpinOther;

        public bool McaSpinOther
        {
            get { return mcaSpinOther; }
            set { mcaSpinOther = value; }
        }
        private string spinOtherYear;

        public string SpinOtherYear
        {
            get { return spinOtherYear; }
            set { spinOtherYear = value; }
        }
        private string spinOtherPercent;

        public string SpinOtherPercent
        {
            get { return spinOtherPercent; }
            set { spinOtherPercent = value; }
        }
        private bool mcaThora;

        public bool McaThora
        {
            get { return mcaThora; }
            set { mcaThora = value; }
        }
        private string thoraYear;

        public string ThoraYear
        {
            get { return thoraYear; }
            set { thoraYear = value; }
        }
        private string thoraPercent;

        public string ThoraPercent
        {
            get { return thoraPercent; }
            set { thoraPercent = value; }
        }
        private bool mcaUro;

        public bool McaUro
        {
            get { return mcaUro; }
            set { mcaUro = value; }
        }
        private string uroYear;

        public string UroYear
        {
            get { return uroYear; }
            set { uroYear = value; }
        }
        private string uroPercent;

        public string UroPercent
        {
            get { return uroPercent; }
            set { uroPercent = value; }
        }
        private bool mcaVas;

        public bool McaVas
        {
            get { return mcaVas; }
            set { mcaVas = value; }
        }
        private string vasYear;

        public string VasYear
        {
            get { return vasYear; }
            set { vasYear = value; }
        }
        private string vasPercent;

        public string VasPercent
        {
            get { return vasPercent; }
            set { vasPercent = value; }
        }
        private bool mca42a;

        public bool Mca42a
        {
            get { return mca42a; }
            set { mca42a = value; }
        }
        private bool mca42b;

        public bool Mca42b
        {
            get { return mca42b; }
            set { mca42b = value; }
        }
        private bool mca42c;

        public bool Mca42c
        {
            get { return mca42c; }
            set { mca42c = value; }
        }
        private bool mca42d;

        public bool Mca42d
        {
            get { return mca42d; }
            set { mca42d = value; }
        }
        private bool mca42e;

        public bool Mca42e
        {
            get { return mca42e; }
            set { mca42e = value; }
        }
        private bool mca42f;

        public bool Mca42f
        {
            get { return mca42f; }
            set { mca42f = value; }
        }
        private string mca42g;

        public string Mca42g
        {
            get { return mca42g; }
            set { mca42g = value; }
        }
        private bool mca42h;

        public bool Mca42h
        {
            get { return mca42h; }
            set { mca42h = value; }
        }
        private bool mca42i;

        public bool Mca42i
        {
            get { return mca42i; }
            set { mca42i = value; }
        }
        private bool mca42j;

        public bool Mca42j
        {
            get { return mca42j; }
            set { mca42j = value; }
        }
        private bool mca42k;

        public bool Mca42k
        {
            get { return mca42k; }
            set { mca42k = value; }
        }
        private string mca42kDesc;

        public string Mca42kDesc
        {
            get { return mca42kDesc; }
            set { mca42kDesc = value; }
        }
        private bool mca42l;

        public bool Mca42l
        {
            get { return mca42l; }
            set { mca42l = value; }
        }
        private string mca42lDesc;

        public string Mca42lDesc
        {
            get { return mca42lDesc; }
            set { mca42lDesc = value; }
        }
        private string app643Desc;

        public string App643Desc
        {
            get { return app643Desc; }
            set { app643Desc = value; }
        }
        private bool mca44;

        public bool Mca44
        {
            get { return mca44; }
            set { mca44 = value; }
        }
        private string app644Desc;

        public string App644Desc
        {
            get { return app644Desc; }
            set { app644Desc = value; }
        }
        private bool mca45;

        public bool Mca45
        {
            get { return mca45; }
            set { mca45 = value; }
        }
        private bool mca46;

        public bool Mca46
        {
            get { return mca46; }
            set { mca46 = value; }
        }
        private bool mca47;

        public bool Mca47
        {
            get { return mca47; }
            set { mca47 = value; }
        }
        private string app647Inst;

        public string App647Inst
        {
            get { return app647Inst; }
            set { app647Inst = value; }
        }
        private string app647Addr;

        public string App647Addr
        {
            get { return app647Addr; }
            set { app647Addr = value; }
        }
        private bool mca47b;

        public bool Mca47b
        {
            get { return mca47b; }
            set { mca47b = value; }
        }
        private string app647bPercent;

        public string App647bPercent
        {
            get { return app647bPercent; }
            set { app647bPercent = value; }
        }
        private bool mca48;

        public bool Mca48
        {
            get { return mca48; }
            set { mca48 = value; }
        }
        private string app648Ent;

        public string App648Ent
        {
            get { return app648Ent; }
            set { app648Ent = value; }
        }
        private string app648Addr;

        public string App648Addr
        {
            get { return app648Addr; }
            set { app648Addr = value; }
        }
        private bool mca48b;

        public bool Mca48b
        {
            get { return mca48b; }
            set { mca48b = value; }
        }
        private bool mca48c;

        public bool Mca48c
        {
            get { return mca48c; }
            set { mca48c = value; }
        }
        private bool mca49;

        public bool Mca49
        {
            get { return mca49; }
            set { mca49 = value; }
        }
        private string app649Desc;

        public string App649Desc
        {
            get { return app649Desc; }
            set { app649Desc = value; }
        }
        private bool mca50;

        public bool Mca50
        {
            get { return mca50; }
            set { mca50 = value; }
        }
        private string app650Desc;

        public string App650Desc
        {
            get { return app650Desc; }
            set { app650Desc = value; }
        }
        private bool mca51;

        public bool Mca51
        {
            get { return mca51; }
            set { mca51 = value; }
        }
        private bool mca52;

        public bool Mca52
        {
            get { return mca52; }
            set { mca52 = value; }
        }
        private bool mca53;

        public bool Mca53
        {
            get { return mca53; }
            set { mca53 = value; }
        }
        private bool mca54;

        public bool Mca54
        {
            get { return mca54; }
            set { mca54 = value; }
        }
        private string app654b;

        public string App654b
        {
            get { return app654b; }
            set { app654b = value; }
        }
        private string app654c;

        public string App654c
        {
            get { return app654c; }
            set { app654c = value; }
        }
        private string app654d;

        public string App654d
        {
            get { return app654d; }
            set { app654d = value; }
        }
        private bool mca55;

        public bool Mca55
        {
            get { return mca55; }
            set { mca55 = value; }
        }
        private string app655Desc;

        public string App655Desc
        {
            get { return app655Desc; }
            set { app655Desc = value; }
        }
        private bool mca56;

        public bool Mca56
        {
            get { return mca56; }
            set { mca56 = value; }
        }
        private bool mca56First;

        public bool Mca56First
        {
            get { return mca56First; }
            set { mca56First = value; }
        }
        private bool mca56Second;

        public bool Mca56Second
        {
            get { return mca56Second; }
            set { mca56Second = value; }
        }
        private bool mca56Third;

        public bool Mca56Third
        {
            get { return mca56Third; }
            set { mca56Third = value; }
        }
        private string desc56A;

        public string Desc56A
        {
            get { return desc56A; }
            set { desc56A = value; }
        }
        private string desc56B;

        public string Desc56B
        {
            get { return desc56B; }
            set { desc56B = value; }
        }
        private string desc56C;

        public string Desc56C
        {
            get { return desc56C; }
            set { desc56C = value; }
        }
        private bool mca57;

        public bool Mca57
        {
            get { return mca57; }
            set { mca57 = value; }
        }
        private string app657DescA;

        public string App657DescA
        {
            get { return app657DescA; }
            set { app657DescA = value; }
        }
        private string app657DescB;

        public string App657DescB
        {
            get { return app657DescB; }
            set { app657DescB = value; }
        }
        private bool mca58;

        public bool Mca58
        {
            get { return mca58; }
            set { mca58 = value; }
        }
        private string app658DescA;

        public string App658DescA
        {
            get { return app658DescA; }
            set { app658DescA = value; }
        }
        private bool mca59;

        public bool Mca59
        {
            get { return mca59; }
            set { mca59 = value; }
        }
        private bool mca60;

        public bool Mca60
        {
            get { return mca60; }
            set { mca60 = value; }
        }
        private bool mca61;

        public bool Mca61
        {
            get { return mca61; }
            set { mca61 = value; }
        }


        #endregion

        #region Variables & Properties Application7

        private bool mca62;

        public bool Mca62
        {
            get { return mca62; }
            set { mca62 = value; }
        }
        private bool mca63;

        public bool Mca63
        {
            get { return mca63; }
            set { mca63 = value; }
        }
        private bool mca64;

        public bool Mca64
        {
            get { return mca64; }
            set { mca64 = value; }
        }
        private bool mca65;

        public bool Mca65
        {
            get { return mca65; }
            set { mca65 = value; }
        }
        private bool mca66;

        public bool Mca66
        {
            get { return mca66; }
            set { mca66 = value; }
        }
        private bool mca67;

        public bool Mca67
        {
            get { return mca67; }
            set { mca67 = value; }
        }
        private bool mca68;

        public bool Mca68
        {
            get { return mca68; }
            set { mca68 = value; }
        }
        private bool mca69;

        public bool Mca69
        {
            get { return mca69; }
            set { mca69 = value; }
        }
        private bool mca70;

        public bool Mca70
        {
            get { return mca70; }
            set { mca70 = value; }
        }
        private bool mca71;

        public bool Mca71
        {
            get { return mca71; }
            set { mca71 = value; }
        }
        private bool mca72;

        public bool Mca72
        {
            get { return mca72; }
            set { mca72 = value; }
        }
        private bool mca73;

        public bool Mca73
        {
            get { return mca73; }
            set { mca73 = value; }
        }
        private bool mca73a;

        public bool Mca73a
        {
            get { return mca73a; }
            set { mca73a = value; }
        }
        private bool mca73b;

        public bool Mca73b
        {
            get { return mca73b; }
            set { mca73b = value; }
        }
        private bool mca73c;

        public bool Mca73c
        {
            get { return mca73c; }
            set { mca73c = value; }
        }
        private bool mca73d;

        public bool Mca73d
        {
            get { return mca73d; }
            set { mca73d = value; }
        }
        private bool mca73e;

        public bool Mca73e
        {
            get { return mca73e; }
            set { mca73e = value; }
        }
        private bool mca73f;

        public bool Mca73f
        {
            get { return mca73f; }
            set { mca73f = value; }
        }



        #endregion

        #region Variables & Properties Application8

        private string patientName;

        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }
        private string dateOfIncident;

        public string DateOfIncident
        {
            get { return dateOfIncident; }
            set { dateOfIncident = value; }
        }
        private string dateReported;

        public string DateReported
        {
            get { return dateReported; }
            set { dateReported = value; }
        }
        private string insuranceNameCarrier;

        public string InsuranceNameCarrier
        {
            get { return insuranceNameCarrier; }
            set { insuranceNameCarrier = value; }
        }
        private string allegation;

        public string Allegation
        {
            get { return allegation; }
            set { allegation = value; }
        }
        private string conditionPatient;

        public string ConditionPatient
        {
            get { return conditionPatient; }
            set { conditionPatient = value; }
        }
        private bool mca7;

        public bool Mca7
        {
            get { return mca7; }
            set { mca7 = value; }
        }
        private bool mca8a;

        public bool Mca8a
        {
            get { return mca8a; }
            set { mca8a = value; }
        }
        private bool mca8b;

        public bool Mca8b
        {
            get { return mca8b; }
            set { mca8b = value; }
        }
        private bool mca8c;

        public bool Mca8c
        {
            get { return mca8c; }
            set { mca8c = value; }
        }
        private bool mca8d;

        public bool Mca8d
        {
            get { return mca8d; }
            set { mca8d = value; }
        }
        private bool mca8e;

        public bool Mca8e
        {
            get { return mca8e; }
            set { mca8e = value; }
        }
        private decimal app88ePayment;

        public decimal App88ePayment
        {
            get { return app88ePayment; }
            set { app88ePayment = value; }
        }
        private bool mca8f;

        public bool Mca8f
        {
            get { return mca8f; }
            set { mca8f = value; }
        }
        private string app88fDate;

        public string App88fDate
        {
            get { return app88fDate; }
            set { app88fDate = value; }
        }
        private decimal app88fPaid;

        public decimal App88fPaid
        {
            get { return app88fPaid; }
            set { app88fPaid = value; }
        }
        private bool mca8fc;

        public bool Mca8fc
        {
            get { return mca8fc; }
            set { mca8fc = value; }
        }
        private bool mca8g;

        public bool Mca8g
        {
            get { return mca8g; }
            set { mca8g = value; }
        }
        private bool mca8h;

        public bool Mca8h
        {
            get { return mca8h; }
            set { mca8h = value; }
        }
        private bool mca8i;

        public bool Mca8i
        {
            get { return mca8i; }
            set { mca8i = value; }
        }
        private bool mca8j;

        public bool Mca8j
        {
            get { return mca8j; }
            set { mca8j = value; }
        }
        private bool mca8k;

        public bool Mca8k
        {
            get { return mca8k; }
            set { mca8k = value; }
        }
        private bool mca8l;

        public bool Mca8l
        {
            get { return mca8l; }
            set { mca8l = value; }
        }
        private bool mca8m;

        public bool Mca8m
        {
            get { return mca8m; }
            set { mca8m = value; }
        }
        private bool mca8n;

        public bool Mca8n
        {
            get { return mca8n; }
            set { mca8n = value; }
        }
        private string app89Desc;

        public string App89Desc
        {
            get { return app89Desc; }
            set { app89Desc = value; }
        }


        #endregion

        #region Public Methods
        public void Save(int UserID, int ApplicationNumber)
        {
            base.Validate();
            this.ValidateApplication();

            if (this.Customer.CustomerNo.Trim() == "")
                this.Customer.Mode = 1;
            else
                this.Customer.Mode = 2;

            this.Customer.IsBusiness = false;
            this.Customer.Save(UserID);

            this.CustomerNo = this.Customer.CustomerNo;
            this.ProspectID = this.Customer.ProspectID;

            base.Save();
            SaveApplication(UserID, ApplicationNumber);  // Save Policies

            //if (this.Mode == 1)
            //    SendEmail();

            this.Mode = (int)TaskControlMode.CLEAR;
        }

        public void UpdateStatusByTaskControlID(int taskControlID, int status)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Status",
                SqlDbType.Int, 0, status.ToString(),
                ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            try
            {
                exec.Update("UpdateStatusByTaskControlID", xmlDoc);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not update status for application.", ex);
            }
        }

        public void SendEmail(string date, string specialty)
        {
            string specialtyDesc = String.Empty;
            string msg = "";

            try
            {
                //DataTable dt = GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(this.PRMEDICSpecialtyID);
                //specialtyDesc = dt.Rows[0]["PRMEDICSpecialtyDesc"].ToString().Trim();

                EPolicy.TaskControl.Mail SM = new EPolicy.TaskControl.Mail();
                //tacosta@prmdic.com; resolve@prmdic.com;

                SM.MailTo = " jterrassa@prmdic.com; dhanft@prmdic.com; halamo@prmdic.com";
                //SM.MailTo = "victor@drrecord.com";
                //SM.MailTo = "luisg13@gmail.com";

                if (LookupTables.LookupTables.GetDescription("Agency", this.Agency) == "RESOLVE GENERAL AGENCY")
                    SM.MailTo = "knoblecilla@prmdic.com; lcorrea@resolvegeneral.com";

                //"victor@drrecord.com; ascharon@gmail.com"; //
                //SM.MailToCollection = listmail;
                SM.MailFrom = "system@prmdic.net";
                SM.MailSubject = "Notificación: Nueva Cotización Creada";
                //SM.MailAttach = FileList;

                string mAgent = "NO AGENTE";
                if (this.Agent != "000")
                    mAgent = LookupTables.LookupTables.GetDescription("Agent", this.Agent);

                SM.MailBody = "\r\n" +
                    "Se ha creado la cotización # " + this.TaskControlID.ToString().Trim() + "   " +"\r\n" + "\r\n" +
                    "Nombre del Cliente: " + this.Customer.FirstName.Trim() + " " + this.Customer.LastName1.Trim() + "   " + "\r\n" +
                    "Especialidad: " + specialty + "   " + System.Environment.NewLine +
                    "ISO Code: " + this.IsoCode.ToString() + "   " + "\r\n" +
                    "Fecha de Retroactividad Primaria: " + date + "   " + "\r\n" +
                    "Agente: " + mAgent + "   " + "\r\n" +
                    "Agencia: " + LookupTables.LookupTables.GetDescription("Agency", this.Agency) + "   " + "\r\n" +
                    "Creado Por: " + this.EnteredBy.Trim() + "   " + "\r\n" + "\r\n" + "\r\n" +
                    "Este es un mensaje enviado por el Sistema Automático de mensaje de ePMS." + "   " + "\r\n" + "\r\n" + "\r\n" +
                "AVISO DE CONFIDENCIALIDAD: Esta comunicación contiene  informacion  propiedad  de  Puerto Rico Medical Defense Insurance Company." + "   " + "\r\n" +
                "Clasificada como privilegiada, confidencial y exenta de divulgación. La información es para uso exclusivo del individuo o entidad" + "   " + "\r\n" +
                "a quien está dirigida. Si usted no es el destinatario, el empleado o el agente a quien se  le  confió la responsabilidad de hacer" + "   " + "\r\n" +
                "llegar el mensaje al destinatario, debe percatarse que la divulgación, copia, distribución o accion tomaba basada en el contenido" + "   " + "\r\n" +
                "de esta transmisión está estrictamente prohibida. Si ha recibido esta comunicación por error,  favor de borrarla  y  notificar al" + "   " + "\r\n" +
                "remitente inmediatamente.  Cualquier uso indebido  de  la  información contenida  en  este mensaje será sancionado bajo las leyes" + "   " + "\r\n" +
                "aplicables." + "\r\n" + "\r\n" +
                "CONFIDENTIALITY NOTE: This communication and any attachments hereto contain information property  of  Puerto Rico Medical Defense" + "   " + "\r\n" +
                "Insurance Company, classified as privileged, confidential and exempt from disclosure. The information is intended solely  for the" + "   " + "\r\n" +
                "use of the individual  or  entity to which it is addressed.  If you  are  not the intended  recipient  or  the  employee or agent" + "   " + "\r\n" +
                "entrusted with the responsibility of delivering the message  to  the intended recipient,  be aware that any disclosure,  copying," + "   " + "\r\n" +
                "distribution  or  action taken in based on the contents  of  this transmission  is  strictly  prohibited. If  you  have received" + "   " + "\r\n" +
                "this communication by mistake,  please  delete and notify  the  sender  immediately.  Any unauthorized  use  of  the information" + "   " + "\r\n" +
                "contained herein will be sanctioned under applicable laws." + "   ";

                msg = SM.SendMail();
            }
            catch (Exception exc)
            {
                string a = msg + " " + exc.InnerException.ToString();
            }
        }
        public static Application GetApplication(int taskControlID)
        {
            Application application = null;

            DataTable dt = GetApplicationByTaskControlID(taskControlID);

            application = new Application();
            application.dtApplication = dt;

            application = FillProperties(application);

            return application;
        }

        public static DataTable GetPRMEDICRATE(int PRMedicalLimitID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("PRMedicalLimitID",
            SqlDbType.Int, 0, PRMedicalLimitID.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetPRMEDICRATE", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetPRMEDICRATEByPRMEDICRATEID(int PRMEDICRATEID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("PRMEDICRATEID",
            SqlDbType.Int, 0, PRMEDICRATEID.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetPRMEDICRATEByPRMEDICRATEID", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetPRMEDICRATEBYISOCODE(int PRMEDICRATEID, string Isocode2)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("PRMEDICRATEID",
            SqlDbType.Int, 0, PRMEDICRATEID.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Isocode2",
            SqlDbType.Int, 0, Isocode2.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetPRMEDICRATEBYISOCODE", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID(int PRMEDICSpecialtyID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("PRMEDICSpecialtyID",
            SqlDbType.Int, 0, PRMEDICSpecialtyID.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetPRMEDICSpecialtyDescbyPRMEDICSpecialtyID", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetPRMEDICPrimaryRATE(int PRMedicalLimitID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("PRMedicalLimitID",
            SqlDbType.Int, 0, PRMedicalLimitID.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetPRMEDICRATEPRIMARY", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetPRMEDICRATEPRIMARYBYISOCODE(int PRMEDICRATEID, string Isocode2)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("PRMEDICRATEID",
            SqlDbType.Int, 0, PRMEDICRATEID.ToString(),
            ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Isocode2",
            SqlDbType.Int, 0, Isocode2.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetPRMEDICRATEPRIMARYBYISOCODE", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public static DataTable GetPRMEDICRATEPRIMARYByPRMEDICRATEID(int PRMEDICRATEID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
            new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("PRMEDICRATEID",
            SqlDbType.Int, 0, PRMEDICRATEID.ToString(),
            ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("GetPRMEDICRATEPRIMARYByPRMEDICRATEID", xmlDoc);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve data.", ex);
            }
        }

        public bool ApplicationExist(int TaskControlID, int ApplicationNumber)
        {
            DataTable dt = GetApplicationByTaskControlIDAndApplicationNumber(TaskControlID, ApplicationNumber);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static void DeleteApplicationByTaskControlID(int taskControlID)
        {
            DBRequest Executor = new DBRequest();

            try
            {
                Executor.BeginTrans();
                Executor.Update("sp_DeleteApplication", DeleteApplicationByTaskControlIDXml(taskControlID));
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error, Please try again. " + xcp.Message, xcp);
            }
        }
            
        #endregion

        #region Private Methods

        private void ValidateApplication()
        {

        }

        private void SaveApplication(int UserID, int ApplicationNumber)
        {
            Baldrich.DBRequest.DBRequest Executor = new Baldrich.DBRequest.DBRequest();
            int taskID = 0;
            try
            {
                Executor.BeginTrans();
                switch (ApplicationNumber)
                {
                    case 1:
                        taskID = Executor.Insert("sp_SaveApplication1", this.SaveApplication1Xml());
                        break;
                    case 2:
                        taskID = Executor.Insert("sp_SaveApplication2", this.SaveApplication2Xml());
                        break;
                    case 3:
                        taskID = Executor.Insert("sp_SaveApplication3", this.SaveApplication3Xml());
                        break;
                    case 4:
                        taskID = Executor.Insert("sp_SaveApplication4", this.SaveApplication4Xml());
                        break;
                    case 5:
                        taskID = Executor.Insert("sp_SaveApplication5", this.SaveApplication5Xml());
                        break;
                    case 6:
                        taskID = Executor.Insert("sp_SaveApplication6", this.SaveApplication6Xml());
                        break;
                    case 7:
                        taskID = Executor.Insert("sp_SaveApplication7", this.SaveApplication7Xml());
                        break;
                    case 8:
                        taskID = Executor.Insert("sp_SaveApplication8", this.SaveApplication8Xml());
                        break;
                }
                Executor.CommitTrans();
            }
            catch (Exception xcp)
            {
                Executor.RollBackTrans();
                throw new Exception("Error while trying to save the Policy. " + xcp.Message, xcp);
            }
        }

        private static DataTable GetApplicationByTaskControlID(int taskControlID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("sp_GetAllApplicationsInfo", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve prospect by criteria.", ex);
            }
        }

        private static DataTable GetApplicationByTaskControlIDAndApplicationNumber(int taskControlID, int ApplicationNumber)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[2];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            DbRequestXmlCooker.AttachCookItem("ApplicationNumber",
                SqlDbType.Int, 0, ApplicationNumber.ToString(),
                ref cookItems);

            Baldrich.DBRequest.DBRequest exec = new Baldrich.DBRequest.DBRequest();
            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
            DataTable dt = null;
            try
            {
                dt = exec.GetQuery("sp_GetApplicationByTaskControlIDAndApplicationNumber", xmlDoc);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve prospect by criteria.", ex);
            }
        }

        private static Application FillProperties(Application application)
        {
            application.Status = (int) application.dtApplication.Rows[0]["Status"];
            application.Comments = application.dtApplication.Rows[0]["Comments"].ToString();
            application.PriCarierName1 = application.dtApplication.Rows[0]["PriCarierName1"].ToString();
            application.PriPolEffecDate1 = (application.dtApplication.Rows[0]["PriPolEffecDate1"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["PriPolEffecDate1"]).ToShortDateString() : "";
            application.PriPolLimits1 = application.dtApplication.Rows[0]["PriPolLimits1"].ToString();
            application.PriClaims1 = application.dtApplication.Rows[0]["PriClaims1"].ToString();
            application.PriCarierName2 = application.dtApplication.Rows[0]["PriCarierName2"].ToString();
            application.PriPolEffecDate2 = (application.dtApplication.Rows[0]["PriPolEffecDate2"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["PriPolEffecDate2"]).ToShortDateString() : "";
            application.PriPolLimits2 = application.dtApplication.Rows[0]["PriPolLimits2"].ToString();
            application.PriClaims2 = application.dtApplication.Rows[0]["PriClaims2"].ToString();
            application.PriCarierName3 = application.dtApplication.Rows[0]["PriCarierName3"].ToString();
            application.PriPolEffecDate3 = (application.dtApplication.Rows[0]["PriPolEffecDate3"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["PriPolEffecDate3"]).ToShortDateString() : "";
            application.PriPolLimits3 = application.dtApplication.Rows[0]["PriPolLimits3"].ToString();
            application.PriClaims3 = application.dtApplication.Rows[0]["PriClaims3"].ToString();
            application.ExcCarierName1 = application.dtApplication.Rows[0]["ExcCarierName1"].ToString();
            application.ExcPolEffecDate1 = (application.dtApplication.Rows[0]["ExcPolEffecDate1"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["ExcPolEffecDate1"]).ToShortDateString() : "";
            application.ExcPolLimits1 = application.dtApplication.Rows[0]["ExcPolLimits1"].ToString();
            application.ExcClaims1 = application.dtApplication.Rows[0]["ExcClaims1"].ToString();
            application.ExcCarierName2 = application.dtApplication.Rows[0]["ExcCarierName2"].ToString();
            application.ExcPolEffecDate2 = (application.dtApplication.Rows[0]["ExcPolEffecDate2"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["ExcPolEffecDate2"]).ToShortDateString() : "";
            application.ExcPolLimits2 = application.dtApplication.Rows[0]["ExcPolLimits2"].ToString();
            application.ExcClaims2 = application.dtApplication.Rows[0]["ExcClaims2"].ToString();
            application.ExcCarierName3 = application.dtApplication.Rows[0]["ExcCarierName3"].ToString();
            application.ExcPolEffecDate3 = (application.dtApplication.Rows[0]["ExcPolEffecDate3"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["ExcPolEffecDate3"]).ToShortDateString() : "";
            application.ExcPolLimits3 = application.dtApplication.Rows[0]["ExcPolLimits3"].ToString();
            application.ExcClaims3 = application.dtApplication.Rows[0]["ExcClaims3"].ToString();
            application.McaInsuranceCia = (application.dtApplication.Rows[0]["McaInsuranceCia"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaInsuranceCia"]) : false;
            application.InsuranceCiaDesc = application.dtApplication.Rows[0]["InsuranceCiaDesc"].ToString();
            application.MedSchool = application.dtApplication.Rows[0]["MedSchool"].ToString();
            application.MedCity = application.dtApplication.Rows[0]["MedCity"].ToString();
            application.MedFrom = application.dtApplication.Rows[0]["MedFrom"].ToString();
            application.MedDegree = application.dtApplication.Rows[0]["MedDegree"].ToString();
            application.IntSchool = application.dtApplication.Rows[0]["IntSchool"].ToString();
            application.IntCity = application.dtApplication.Rows[0]["IntCity"].ToString();
            application.IntFrom = application.dtApplication.Rows[0]["IntFrom"].ToString();
            application.IntDegree = application.dtApplication.Rows[0]["IntDegree"].ToString();
            application.ResSchool = application.dtApplication.Rows[0]["ResSchool"].ToString();
            application.ResCity = application.dtApplication.Rows[0]["ResCity"].ToString();
            application.ResFrom = application.dtApplication.Rows[0]["ResFrom"].ToString();
            application.ResDegree = application.dtApplication.Rows[0]["ResDegree"].ToString();
            application.FellSchool = application.dtApplication.Rows[0]["FellSchool"].ToString();
            application.FellCity = application.dtApplication.Rows[0]["FellCity"].ToString();
            application.FellFrom = application.dtApplication.Rows[0]["FellFrom"].ToString();
            application.FellDegree = application.dtApplication.Rows[0]["FellDegree"].ToString();
            application.OSchool = application.dtApplication.Rows[0]["OSchool"].ToString();
            application.OCity = application.dtApplication.Rows[0]["OCity"].ToString();
            application.OFrom = application.dtApplication.Rows[0]["OFrom"].ToString();
            application.ODegree = application.dtApplication.Rows[0]["ODegree"].ToString();
            application.McaCertified = (application.dtApplication.Rows[0]["McaCertified"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaCertified"]) : false;
            application.McaResTraining = (application.dtApplication.Rows[0]["McaResTraining"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaResTraining"]) : false;
            application.Residency = application.dtApplication.Rows[0]["Residency"].ToString();
            application.PRMEDICRATEID = (int)application.dtApplication.Rows[0]["PRMEDICRATEID"];
            //application.PRMEDICSpecialtyID = (application.dtApplication.Rows[0]["PRMEDICSpecialtyID"] != System.DBNull.Value) ? (int)application.dtApplication.Rows[0]["PRMEDICSpecialtyID"]: 0;
            application.IsoCode = application.dtApplication.Rows[0]["IsoCode"].ToString();
            application.ClassRate = application.dtApplication.Rows[0]["Class"].ToString();
            application.RateYear1 = (application.dtApplication.Rows[0]["RateYear1"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["RateYear1"]) : 0.00;
            application.RateYear2 = (application.dtApplication.Rows[0]["RateYear2"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["RateYear2"]) : 0.00;
            application.RateYear3 = (application.dtApplication.Rows[0]["RateYear3"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["RateYear3"]) : 0.00;
            application.MCMRate = (application.dtApplication.Rows[0]["MCMRate"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["MCMRate"]) : 0.00;
            application.PRMedicalLimitID = (application.dtApplication.Rows[0]["PRMedicalLimitID"] != System.DBNull.Value) ? ((int)application.dtApplication.Rows[0]["PRMedicalLimitID"]) : 0;
            application.RateYear12 = (application.dtApplication.Rows[0]["Rate12"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate12"]) : 0.00;
            application.RateYear22 = (application.dtApplication.Rows[0]["Rate22"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate22"]) : 0.00;
            application.RateYear32 = (application.dtApplication.Rows[0]["Rate32"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate32"]) : 0.00;
            application.RateYear42 = (application.dtApplication.Rows[0]["Rate42"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate42"]) : 0.00;
            application.PRMedicalLimit2ID = (application.dtApplication.Rows[0]["PRMedicalLimit2ID"] != System.DBNull.Value) ? ((int)application.dtApplication.Rows[0]["PRMedicalLimit2ID"]) : 0;
            application.RateYear13 = (application.dtApplication.Rows[0]["Rate13"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate13"]) : 0.00;
            application.RateYear23 = (application.dtApplication.Rows[0]["Rate23"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate23"]) : 0.00;
            application.RateYear33 = (application.dtApplication.Rows[0]["Rate33"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate33"]) : 0.00;
            application.RateYear43 = (application.dtApplication.Rows[0]["Rate43"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate43"]) : 0.00;
            application.PRMedicalLimit3ID = (application.dtApplication.Rows[0]["PRMedicalLimit3ID"] != System.DBNull.Value) ? ((int)application.dtApplication.Rows[0]["PRMedicalLimit3ID"]) : 0;
            application.RateYear14 = (application.dtApplication.Rows[0]["Rate14"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate14"]) : 0.00;
            application.RateYear24 = (application.dtApplication.Rows[0]["Rate24"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate24"]) : 0.00;
            application.RateYear34 = (application.dtApplication.Rows[0]["Rate34"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate34"]) : 0.00;
            application.RateYear44 = (application.dtApplication.Rows[0]["Rate44"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate44"]) : 0.00;
            application.PRMedicalLimit4ID = (application.dtApplication.Rows[0]["PRMedicalLimit4ID"] != System.DBNull.Value) ? ((int)application.dtApplication.Rows[0]["PRMedicalLimit4ID"]) : 0;
            application.RateYear15 = (application.dtApplication.Rows[0]["Rate15"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate15"]) : 0.00;
            application.RateYear25 = (application.dtApplication.Rows[0]["Rate25"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate25"]) : 0.00;
            application.RateYear35 = (application.dtApplication.Rows[0]["Rate35"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate35"]) : 0.00;
            application.RateYear45 = (application.dtApplication.Rows[0]["Rate45"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate45"]) : 0.00;
            application.PRMedicalLimit5ID = (application.dtApplication.Rows[0]["PRMedicalLimit5ID"] != System.DBNull.Value) ? ((int)application.dtApplication.Rows[0]["PRMedicalLimit5ID"]) : 0;
            application.RateYear16 = (application.dtApplication.Rows[0]["Rate16"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate16"]) : 0.00;
            application.RateYear26 = (application.dtApplication.Rows[0]["Rate26"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate26"]) : 0.00;
            application.RateYear36 = (application.dtApplication.Rows[0]["Rate36"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate36"]) : 0.00;
            application.RateYear46 = (application.dtApplication.Rows[0]["Rate46"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["Rate46"]) : 0.00;
            application.PRMedicalLimit6ID = (application.dtApplication.Rows[0]["PRMedicalLimit6ID"] != System.DBNull.Value) ? ((int)application.dtApplication.Rows[0]["PRMedicalLimit6ID"]) : 0;

            application.PRateYear1 = (application.dtApplication.Rows[0]["PRateYear1"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["PRateYear1"]) : 0.00;
            application.PRateYear2 = (application.dtApplication.Rows[0]["PRateYear2"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["PRateYear2"]) : 0.00;
            application.PRateYear3 = (application.dtApplication.Rows[0]["PRateYear3"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["PRateYear3"]) : 0.00;
            application.PRateYear4 = (application.dtApplication.Rows[0]["PRateYear4"] != System.DBNull.Value) ? ((double)application.dtApplication.Rows[0]["PRateYear4"]) : 0.00;
            application.PRPrimaryLimitID = (application.dtApplication.Rows[0]["PRPrimaryLimitID"] != System.DBNull.Value) ? ((int)application.dtApplication.Rows[0]["PRPrimaryLimitID"]) : 0;
            application.PRPrimeryRateID = (int)application.dtApplication.Rows[0]["PRPrimeryRateID"];
            application.IsPrimary = (application.dtApplication.Rows[0]["isPrimary"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["isPrimary"]) : false;
            application.PrimaryRetroDate = application.dtApplication.Rows[0]["PrimaryRetroDate"].ToString();
            application.ExcessRetroDate = application.dtApplication.Rows[0]["ExcessRetroDate"].ToString();
            //End Properties For Application1

            //Properties For Application2
            application.PriSpecialty = application.dtApplication.Rows[0]["PriSpecialty"].ToString();
            application.PriPractice = application.dtApplication.Rows[0]["PriPractice"].ToString();
            application.SecSpecialty = application.dtApplication.Rows[0]["SecSpecialty"].ToString();
            application.SecPractice = application.dtApplication.Rows[0]["SecPractice"].ToString();
            application.McaPracticeLimit = (application.dtApplication.Rows[0]["McaPracticeLimit"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPracticeLimit"]) : false;
            application.PracticeLimitDesc = application.dtApplication.Rows[0]["PracticeLimitDesc"].ToString();
            application.McaBoardCertified = (application.dtApplication.Rows[0]["McaBoardCertified"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaBoardCertified"]) : false;
            application.BoardCertifiedDesc1 = application.dtApplication.Rows[0]["BoardCertifiedDesc1"].ToString();
            application.BoardCertifiedDesc2 = application.dtApplication.Rows[0]["BoardCertifiedDesc2"].ToString();
            application.BoardCertifiedDesc3 = application.dtApplication.Rows[0]["BoardCertifiedDesc3"].ToString();
            application.BoardCertifiedDesc4 = application.dtApplication.Rows[0]["BoardCertifiedDesc4"].ToString();
            application.BoardCertifiedDesc5 = application.dtApplication.Rows[0]["BoardCertifiedDesc5"].ToString();
            application.BoardCertifiedDesc6 = application.dtApplication.Rows[0]["BoardCertifiedDesc6"].ToString();
            application.BoardCertifiedDesc7 = (application.dtApplication.Rows[0]["BoardCertifiedDesc7"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["BoardCertifiedDesc7"]).ToShortDateString() : "";
            application.BoardCertifiedDesc8 = (application.dtApplication.Rows[0]["BoardCertifiedDesc8"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["BoardCertifiedDesc8"]).ToShortDateString() : "";
            application.BoardCertifiedDesc9 = (application.dtApplication.Rows[0]["BoardCertifiedDesc9"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["BoardCertifiedDesc9"]).ToShortDateString() : "";
            application.BoardCertifiedDesc10 = application.dtApplication.Rows[0]["BoardCertifiedDesc10"].ToString();
            application.BoardCertifiedDesc11 = application.dtApplication.Rows[0]["BoardCertifiedDesc11"].ToString();
            application.BoardCertifiedDesc12 = application.dtApplication.Rows[0]["BoardCertifiedDesc12"].ToString();
            application.EleExpDate = (application.dtApplication.Rows[0]["EleExpDate"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["EleExpDate"]).ToShortDateString() : "";
            application.ExpiredWhy = application.dtApplication.Rows[0]["ExpiredWhy"].ToString();
            application.McaBoardExam = (application.dtApplication.Rows[0]["McaBoardExam"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaBoardExam"]) : false;
            application.BoardExamDesc = application.dtApplication.Rows[0]["BoardExamDesc"].ToString();
            application.McaWrittenExam = (application.dtApplication.Rows[0]["McaWrittenExam"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaWrittenExam"]) : false;
            application.WrittenWhen = (application.dtApplication.Rows[0]["WrittenWhen"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["WrittenWhen"]).ToShortDateString() : "";
            application.WrittenResult = application.dtApplication.Rows[0]["WrittenResult"].ToString();
            application.McaOralExam = (application.dtApplication.Rows[0]["McaOralExam"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOralExam"]) : false;
            application.OralWhen = (application.dtApplication.Rows[0]["OralWhen"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["OralWhen"]).ToShortDateString() : "";
            application.OralResult = application.dtApplication.Rows[0]["OralResult"].ToString();
            application.McaFailedBoardExam = (application.dtApplication.Rows[0]["McaFailedBoardExam"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaFailedBoardExam"]) : false;
            application.BoardFailedSpecialty = application.dtApplication.Rows[0]["BoardFailedSpecialty"].ToString();
            application.BoardDate = (application.dtApplication.Rows[0]["BoardDate"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["BoardDate"]).ToShortDateString() : "";
            application.McaMilitary = (application.dtApplication.Rows[0]["McaMilitary"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaMilitary"]) : false;
            application.MilitaryDesc = application.dtApplication.Rows[0]["MilitaryDesc"].ToString();
            application.McaMilitaryReserve = (application.dtApplication.Rows[0]["McaMilitaryReserve"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaMilitaryReserve"]) : false;
            application.LicState1 = application.dtApplication.Rows[0]["LicState1"].ToString();
            application.LicYear1 = application.dtApplication.Rows[0]["LicYear1"].ToString();
            application.LicNumber1 = application.dtApplication.Rows[0]["LicNumber1"].ToString();
            application.LicStatus1 = application.dtApplication.Rows[0]["LicStatus1"].ToString();
            application.LicState2 = application.dtApplication.Rows[0]["LicState2"].ToString();
            application.LicYear2 = application.dtApplication.Rows[0]["LicYear2"].ToString();
            application.LicNumber2 = application.dtApplication.Rows[0]["LicNumber2"].ToString();
            application.LicStatus2 = application.dtApplication.Rows[0]["LicStatus2"].ToString();
            application.LicState3 = application.dtApplication.Rows[0]["LicState3"].ToString();
            application.LicYear3 = application.dtApplication.Rows[0]["LicYear3"].ToString();
            application.LicNumber3 = application.dtApplication.Rows[0]["LicNumber3"].ToString();
            application.LicStatus3 = application.dtApplication.Rows[0]["LicStatus3"].ToString();
            application.LicInactive = application.dtApplication.Rows[0]["LicInactive"].ToString();
            application.McaMedSocieties = (application.dtApplication.Rows[0]["McaMedSocieties"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaMedSocieties"]) : false;
            application.MedSocietiesDesc = application.dtApplication.Rows[0]["MedSocietiesDesc"].ToString();
            application.McaNationalSocieties = (application.dtApplication.Rows[0]["McaNationalSocieties"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaNationalSocieties"]) : false;
            application.NationalSocietiesDesc = application.dtApplication.Rows[0]["NationalSocietiesDesc"].ToString();
            application.McaStateMedSocieties = (application.dtApplication.Rows[0]["McaStateMedSocieties"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaStateMedSocieties"]) : false;
            application.McaLocalMedSocieties = (application.dtApplication.Rows[0]["McaLocalMedSocieties"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaLocalMedSocieties"]) : false;
            //End Properties For Application2

            //Properties For Application3

            application.Hospital1 = application.dtApplication.Rows[0]["Hospital1"].ToString();
            application.City1 = application.dtApplication.Rows[0]["City1"].ToString();
            application.Privileges1 = application.dtApplication.Rows[0]["Privileges1"].ToString();
            application.Restrictions1 = application.dtApplication.Rows[0]["Restrictions1"].ToString();
            application.Hospital2 = application.dtApplication.Rows[0]["Hospital2"].ToString();
            application.City2 = application.dtApplication.Rows[0]["City2"].ToString();
            application.Privileges2 = application.dtApplication.Rows[0]["Privileges2"].ToString();
            application.Restrictions2 = application.dtApplication.Rows[0]["Restrictions2"].ToString();
            application.Hospital3 = application.dtApplication.Rows[0]["Hospital3"].ToString();
            application.City3 = application.dtApplication.Rows[0]["City3"].ToString();
            application.Privileges3 = application.dtApplication.Rows[0]["Privileges3"].ToString();
            application.Restrictions3 = application.dtApplication.Rows[0]["Restrictions3"].ToString();
            application.Hospital4 = application.dtApplication.Rows[0]["Hospital4"].ToString();
            application.City4 = application.dtApplication.Rows[0]["City4"].ToString();
            application.Privileges4 = application.dtApplication.Rows[0]["Privileges4"].ToString();
            application.Restrictions4 = application.dtApplication.Rows[0]["Restrictions4"].ToString();
            application.OficeAddr1 = application.dtApplication.Rows[0]["OficeAddr1"].ToString();
            application.OficeCity1 = application.dtApplication.Rows[0]["OficeCity1"].ToString();
            application.OficeCountry1 = application.dtApplication.Rows[0]["OficeCountry1"].ToString();
            application.OficeAddr2 = application.dtApplication.Rows[0]["OficeAddr2"].ToString();
            application.OficeCity2 = application.dtApplication.Rows[0]["OficeCity2"].ToString();
            application.OficeCountry2 = application.dtApplication.Rows[0]["OficeCountry2"].ToString();
            application.OficeAddr3 = application.dtApplication.Rows[0]["OficeAddr3"].ToString();
            application.OficeCity3 = application.dtApplication.Rows[0]["OficeCity3"].ToString();
            application.OficeCountry3 = application.dtApplication.Rows[0]["OficeCountry3"].ToString();
            application.EntName1 = application.dtApplication.Rows[0]["EntName1"].ToString();
            application.EntDate1 = (application.dtApplication.Rows[0]["EntDate1"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["EntDate1"]).ToShortDateString() : "";
            application.EntAddr1 = application.dtApplication.Rows[0]["EntAddr1"].ToString();
            application.EntSpecialty1 = application.dtApplication.Rows[0]["EntSpecialty1"].ToString();
            application.EntName2 = application.dtApplication.Rows[0]["EntName2"].ToString();
            application.EntDate2 = (application.dtApplication.Rows[0]["EntDate2"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["EntDate2"]).ToShortDateString() : "";
            application.EntAddr2 = application.dtApplication.Rows[0]["EntAddr2"].ToString();
            application.EntSpecialty2 = application.dtApplication.Rows[0]["EntSpecialty2"].ToString();
            application.EntName3 = application.dtApplication.Rows[0]["EntName3"].ToString();
            application.EntDate3 = (application.dtApplication.Rows[0]["EntDate3"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["EntDate3"]).ToShortDateString() : "";
            application.EntAddr3 = application.dtApplication.Rows[0]["EntAddr3"].ToString();
            application.EntSpecialty3 = application.dtApplication.Rows[0]["EntSpecialty3"].ToString();
            application.EntName4 = application.dtApplication.Rows[0]["EntName4"].ToString();
            application.EntDate4 = (application.dtApplication.Rows[0]["EntDate4"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["EntDate4"]).ToShortDateString() : "";
            application.EntAddr4 = application.dtApplication.Rows[0]["EntAddr4"].ToString();
            application.EntSpecialty4 = application.dtApplication.Rows[0]["EntSpecialty4"].ToString();
            application.EntName5 = application.dtApplication.Rows[0]["EntName5"].ToString();
            application.EntDate5 = (application.dtApplication.Rows[0]["EntDate5"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["EntDate5"]).ToShortDateString() : "";
            application.EntAddr5 = application.dtApplication.Rows[0]["EntAddr5"].ToString();
            application.EntSpecialty5 = application.dtApplication.Rows[0]["EntSpecialty5"].ToString();
            application.McaPhysician = (application.dtApplication.Rows[0]["McaPhysician"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPhysician"]) : false;
            application.McaEmpPhysician = (application.dtApplication.Rows[0]["McaEmpPhysician"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaEmpPhysician"]) : false;
            application.McaProfAss = (application.dtApplication.Rows[0]["McaProfAss"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaProfAss"]) : false;
            application.McaOther = (application.dtApplication.Rows[0]["McaOther"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOther"]) : false;
            application.McaPartnership = (application.dtApplication.Rows[0]["McaPartnership"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPartnership"]) : false;
            application.McaGroup = (application.dtApplication.Rows[0]["McaGroup"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaGroup"]) : false;
            application.McaProfCorp = (application.dtApplication.Rows[0]["McaProfCorp"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaProfCorp"]) : false;
            application.PhyEntName = application.dtApplication.Rows[0]["PhyEntName"].ToString();
            application.PhyStatus = application.dtApplication.Rows[0]["PhyStatus"].ToString();
            application.PhyPartners = application.dtApplication.Rows[0]["PhyPartners"].ToString();
            application.McaOtherPhy = (application.dtApplication.Rows[0]["McaOtherPhy"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOtherPhy"]) : false;
            application.PhyName = application.dtApplication.Rows[0]["PhyName"].ToString().ToString();
            application.PhyAssoc = application.dtApplication.Rows[0]["PhyAssoc"].ToString();
            application.McaRefferral = (application.dtApplication.Rows[0]["McaRefferral"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaRefferral"]) : false;
            application.RefferralDesc = application.dtApplication.Rows[0]["RefferralDesc"].ToString();

            //End Properties For Application3

            //Properties For Application4
            application.McaLab = (application.dtApplication.Rows[0]["McaLab"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaLab"]) : false;
            application.LabHours = application.dtApplication.Rows[0]["LabHours"].ToString();
            application.LabEmp = application.dtApplication.Rows[0]["LabEmp"].ToString();
            application.McaPhy = (application.dtApplication.Rows[0]["McaPhy"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPhy"]) : false;
            application.PhyHours = application.dtApplication.Rows[0]["PhyHours"].ToString();
            application.PhyEmp = application.dtApplication.Rows[0]["PhyEmp"].ToString();
            application.McaXray = (application.dtApplication.Rows[0]["McaXray"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaXray"]) : false;
            application.XrayHours = application.dtApplication.Rows[0]["XrayHours"].ToString();
            application.XrayEmp = application.dtApplication.Rows[0]["XrayEmp"].ToString();
            application.McaOther = (application.dtApplication.Rows[0]["McaOther"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOther"]) : false;
            application.OtherHours = application.dtApplication.Rows[0]["OtherHours"].ToString();
            application.OtherEmp = application.dtApplication.Rows[0]["OtherEmp"].ToString();
            application.McaNurseAnes = (application.dtApplication.Rows[0]["McaNurseAnes"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaNurseAnes"]) : false;
            application.NurseAnesHours = application.dtApplication.Rows[0]["NurseAnesHours"].ToString();
            application.NurseAnesEmp = application.dtApplication.Rows[0]["NurseAnesEmp"].ToString();
            application.McaNurseMid = (application.dtApplication.Rows[0]["McaNurseMid"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaNurseMid"]) : false;
            application.NurseMidHours = application.dtApplication.Rows[0]["NurseMidHours"].ToString();
            application.NurseMidEmp = application.dtApplication.Rows[0]["NurseMidEmp"].ToString();
            application.McaNursePerf = (application.dtApplication.Rows[0]["McaNursePerf"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaNursePerf"]) : false;
            application.NursePerfHours = application.dtApplication.Rows[0]["NursePerfHours"].ToString();
            application.NursePerfEmp = application.dtApplication.Rows[0]["NursePerfEmp"].ToString();
            application.McaNursePrac = (application.dtApplication.Rows[0]["McaNursePrac"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaNursePrac"]) : false;
            application.NursePracHours = application.dtApplication.Rows[0]["NursePracHours"].ToString();
            application.NursePracEmp = application.dtApplication.Rows[0]["NursePracEmp"].ToString();
            application.McaOpto = (application.dtApplication.Rows[0]["McaOpto"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOpto"]) : false;
            application.OptoHours = application.dtApplication.Rows[0]["OptoHours"].ToString();
            application.OptoEmp = application.dtApplication.Rows[0]["OptoEmp"].ToString();
            application.McaPhyAss = (application.dtApplication.Rows[0]["McaPhyAss"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPhyAss"]) : false;
            application.PhyAssHours = application.dtApplication.Rows[0]["PhyAssHours"].ToString();
            application.PhyAssEmp = application.dtApplication.Rows[0]["PhyAssEmp"].ToString();
            application.McaPsych = (application.dtApplication.Rows[0]["McaPsych"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPsych"]) : false;
            application.PsychHours = application.dtApplication.Rows[0]["PsychHours"].ToString();
            application.PsychEmp = application.dtApplication.Rows[0]["PsychEmp"].ToString();
            application.McaScrub = (application.dtApplication.Rows[0]["McaScrub"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaScrub"]) : false;
            application.ScrubHours = application.dtApplication.Rows[0]["ScrubHours"].ToString();
            application.ScrubEmp = application.dtApplication.Rows[0]["ScrubEmp"].ToString();
            application.McaSurgical = (application.dtApplication.Rows[0]["McaSurgical"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaSurgical"]) : false;
            application.SurgicalHours = application.dtApplication.Rows[0]["SurgicalHours"].ToString();
            application.SurgicalEmp = application.dtApplication.Rows[0]["SurgicalEmp"].ToString();
            application.McaOtherDesc = (application.dtApplication.Rows[0]["McaOtherDesc"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOtherDesc"]) : false;
            application.OtherDescHours = application.dtApplication.Rows[0]["OtherDescHours"].ToString();
            application.OtherDescEmp = application.dtApplication.Rows[0]["OtherDescEmp"].ToString();
            application.HCName1 = application.dtApplication.Rows[0]["HCName1"].ToString();
            application.HCSpeciality1 = application.dtApplication.Rows[0]["HCSpeciality1"].ToString();
            application.HCInsured1 = application.dtApplication.Rows[0]["HCInsured1"].ToString();
            application.HCLimits1 = application.dtApplication.Rows[0]["HCLimits1"].ToString();
            application.HCName2 = application.dtApplication.Rows[0]["HCName2"].ToString();
            application.HCSpecialty2 = application.dtApplication.Rows[0]["HCSpecialty2"].ToString();
            application.HCInsured2 = application.dtApplication.Rows[0]["HCInsured2"].ToString();
            application.HCLimits2 = application.dtApplication.Rows[0]["HCLimits2"].ToString();
            application.HCName3 = application.dtApplication.Rows[0]["HCName3"].ToString();
            application.HCSpecialty3 = application.dtApplication.Rows[0]["HCSpecialty3"].ToString();
            application.HCInsured3 = application.dtApplication.Rows[0]["HCInsured3"].ToString();
            application.HCLimits3 = application.dtApplication.Rows[0]["HCLimits3"].ToString();
            application.McaNone = (application.dtApplication.Rows[0]["McaNone"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaNone"]) : false;
            application.McaBlood = (application.dtApplication.Rows[0]["McaBlood"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaBlood"]) : false;
            application.McaBirthing = (application.dtApplication.Rows[0]["McaBirthing"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaBirthing"]) : false;
            application.McaCity = (application.dtApplication.Rows[0]["McaCity"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaCity"]) : false;
            application.McaClinic = (application.dtApplication.Rows[0]["McaClinic"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaClinic"]) : false;
            application.McaEmergency = (application.dtApplication.Rows[0]["McaEmergency"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaEmergency"]) : false;
            application.McaEmerHospital = (application.dtApplication.Rows[0]["McaEmerHospital"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaEmerHospital"]) : false;
            application.McaFreeStanding = (application.dtApplication.Rows[0]["McaFreeStanding"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaFreeStanding"]) : false;
            application.McaHospital = (application.dtApplication.Rows[0]["McaHospital"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaHospital"]) : false;
            application.McaConva = (application.dtApplication.Rows[0]["McaConva"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaConva"]) : false;
            application.McaPsy = (application.dtApplication.Rows[0]["McaPsy"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPsy"]) : false;
            application.McaInd = (application.dtApplication.Rows[0]["McaInd"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaInd"]) : false;
            application.McaLaboratory = (application.dtApplication.Rows[0]["McaLaboratory"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaLaboratory"]) : false;
            application.McaNursing = (application.dtApplication.Rows[0]["McaNursing"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaNursing"]) : false;
            application.McaSanitarium = (application.dtApplication.Rows[0]["McaSanitarium"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaSanitarium"]) : false;
            application.McaUrgent = (application.dtApplication.Rows[0]["McaUrgent"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaUrgent"]) : false;
            application.McaXrayFacility = (application.dtApplication.Rows[0]["McaXrayFacility"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaXrayFacility"]) : false;
            application.McaOtherHC = (application.dtApplication.Rows[0]["McaOtherHC"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOtherHC"]) : false;
            application.FacilityName1 = application.dtApplication.Rows[0]["FacilityName1"].ToString();
            application.FacilityAddr1 = application.dtApplication.Rows[0]["FacilityAddr1"].ToString();
            application.FacilityType1 = application.dtApplication.Rows[0]["FacilityType1"].ToString();
            application.FacilityDuties1 = application.dtApplication.Rows[0]["FacilityDuties1"].ToString();
            application.FacilityNumbers1 = application.dtApplication.Rows[0]["FacilityNumbers1"].ToString();
            application.McaProfLiab1 = (application.dtApplication.Rows[0]["McaProfLiab1"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaProfLiab1"]) : false;
            application.McaExtendedCov1 = (application.dtApplication.Rows[0]["McaExtendedCov1"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaExtendedCov1"]) : false;
            application.FacilityName2 = application.dtApplication.Rows[0]["FacilityName2"].ToString();
            application.FacilityAddr2 = application.dtApplication.Rows[0]["FacilityAddr2"].ToString();
            application.FacilityType2 = application.dtApplication.Rows[0]["FacilityType2"].ToString();
            application.FacilityDuties2 = application.dtApplication.Rows[0]["FacilityDuties2"].ToString();
            application.FacilityNumbers2 = application.dtApplication.Rows[0]["FacilityNumbers2"].ToString();
            application.McaProfLiab = (application.dtApplication.Rows[0]["McaProfLiab"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaProfLiab"]) : false;
            application.McaExtendedCov = (application.dtApplication.Rows[0]["McaExtendedCov"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaExtendedCov"]) : false;
            application.McaFullTimeCov = (application.dtApplication.Rows[0]["McaFullTimeCov"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaFullTimeCov"]) : false;
            application.McaPartTimeCov = (application.dtApplication.Rows[0]["McaPartTimeCov"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPartTimeCov"]) : false;
            application.DaysPWeek = application.dtApplication.Rows[0]["DaysPWeek"].ToString();
            application.HoursPDayOffice = application.dtApplication.Rows[0]["HoursPDayOffice"].ToString();
            application.PatienPWeek = application.dtApplication.Rows[0]["PatienPWeek"].ToString();
            application.HoursPDayHosp = application.dtApplication.Rows[0]["HoursPDayHosp"].ToString();
            application.ActDesc = application.dtApplication.Rows[0]["ActDesc"].ToString();
            application.app339Number1 = application.dtApplication.Rows[0]["39Number1"].ToString();
            application.app339Hours1 = application.dtApplication.Rows[0]["39Hours1"].ToString();
            application.app339Number2 = application.dtApplication.Rows[0]["39Number2"].ToString();
            application.app339Hours2 = application.dtApplication.Rows[0]["39Hours2"].ToString();
            application.app339Number3 = application.dtApplication.Rows[0]["39Number3"].ToString();
            application.app339Hours3 = application.dtApplication.Rows[0]["39Hours3"].ToString();
            application.app339Number4 = application.dtApplication.Rows[0]["39Number4"].ToString();
            application.app339Hours4 = application.dtApplication.Rows[0]["39Hours4"].ToString();
            application.app339Number5 = application.dtApplication.Rows[0]["39Number5"].ToString();
            application.app339Hours5 = application.dtApplication.Rows[0]["39Hours5"].ToString();
            application.app339Number6 = application.dtApplication.Rows[0]["39Number6"].ToString();
            application.app339Hours6 = application.dtApplication.Rows[0]["39Hours6"].ToString();

            //End Properties For Application4

            //Properties For Application5

            application.McaAngio = (application.dtApplication.Rows[0]["McaAngio"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaAngio"]) : false;
            application.AngioNumber = application.dtApplication.Rows[0]["AngioNumber"].ToString();
            application.McaAngioPTA = (application.dtApplication.Rows[0]["McaAngioPTA"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaAngioPTA"]) : false;
            application.AngioPTANumber = application.dtApplication.Rows[0]["AngioPTANumber"].ToString();
            application.McaAorto = (application.dtApplication.Rows[0]["McaAorto"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaAorto"]) : false;
            application.AortoNumber = application.dtApplication.Rows[0]["AortoNumber"].ToString();
            application.McaBiopsy = (application.dtApplication.Rows[0]["McaBiopsy"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaBiopsy"]) : false;
            application.BiopsyNumber = application.dtApplication.Rows[0]["BiopsyNumber"].ToString();
            application.McaBreast = (application.dtApplication.Rows[0]["McaBreast"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaBreast"]) : false;
            application.BreastNumber = application.dtApplication.Rows[0]["BreastNumber"].ToString();
            application.McaBreastImpl = (application.dtApplication.Rows[0]["McaBreastImpl"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaBreastImpl"]) : false;
            application.BreastImplNumber = application.dtApplication.Rows[0]["BreastImplNumber"].ToString();
            application.McaCardiac = (application.dtApplication.Rows[0]["McaCardiac"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaCardiac"]) : false;
            application.CardiacNumber = application.dtApplication.Rows[0]["CardiacNumber"].ToString();
            application.McaCoronary = (application.dtApplication.Rows[0]["McaCoronary"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaCoronary"]) : false;
            application.CoronaryNumber = application.dtApplication.Rows[0]["CoronaryNumber"].ToString();
            application.McaCholangio = (application.dtApplication.Rows[0]["McaCholangio"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaCholangio"]) : false;
            application.CholangioNumber = application.dtApplication.Rows[0]["CholangioNumber"].ToString();
            application.McaContrast = (application.dtApplication.Rows[0]["McaContrast"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaContrast"]) : false;
            application.ContrastNumber = application.dtApplication.Rows[0]["ContrastNumber"].ToString();
            application.McaEndo = (application.dtApplication.Rows[0]["McaEndo"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaEndo"]) : false;
            application.EndoNumber = application.dtApplication.Rows[0]["EndoNumber"].ToString();
            application.McaHexa = (application.dtApplication.Rows[0]["McaHexa"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaHexa"]) : false;
            application.HexaNumber = application.dtApplication.Rows[0]["HexaNumber"].ToString();
            application.McaIntraO = (application.dtApplication.Rows[0]["McaIntraO"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaIntraO"]) : false;
            application.IntraONumber = application.dtApplication.Rows[0]["IntraONumber"].ToString();
            application.McaIntraG = (application.dtApplication.Rows[0]["McaIntraG"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaIntraG"]) : false;
            application.IntraGNumber = application.dtApplication.Rows[0]["IntraGNumber"].ToString();
            application.McaIvp = (application.dtApplication.Rows[0]["McaIvp"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaIvp"]) : false;
            application.IvpNumber = application.dtApplication.Rows[0]["IvpNumber"].ToString();
            application.McaKidney = (application.dtApplication.Rows[0]["McaKidney"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaKidney"]) : false;
            application.KidneyNumber = application.dtApplication.Rows[0]["KidneyNumber"].ToString();
            application.McaLiver = (application.dtApplication.Rows[0]["McaLiver"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaLiver"]) : false;
            application.LiverNumber = application.dtApplication.Rows[0]["LiverNumber"].ToString();
            application.McaLipo = (application.dtApplication.Rows[0]["McaLipo"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaLipo"]) : false;
            application.LipoNumber = application.dtApplication.Rows[0]["LipoNumber"].ToString();
            application.McaLung = (application.dtApplication.Rows[0]["McaLung"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaLung"]) : false;
            application.LungNumber = application.dtApplication.Rows[0]["LungNumber"].ToString();
            application.McaMyelo = (application.dtApplication.Rows[0]["McaMyelo"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaMyelo"]) : false;
            application.MyeloNumber = application.dtApplication.Rows[0]["MyeloNumber"].ToString();
            application.McaPaceT = (application.dtApplication.Rows[0]["McaPaceT"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPaceT"]) : false;
            application.PaceNumberT = application.dtApplication.Rows[0]["PaceNumberT"].ToString();
            application.McaPaceP = (application.dtApplication.Rows[0]["McaPaceP"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPaceP"]) : false;
            application.PaceNumberP = application.dtApplication.Rows[0]["PaceNumberP"].ToString();
            application.McaPercuT = (application.dtApplication.Rows[0]["McaPercuT"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPercuT"]) : false;
            application.PercuNumberT = application.dtApplication.Rows[0]["PercuNumberT"].ToString();
            application.McaPercuG = (application.dtApplication.Rows[0]["McaPercuG"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPercuG"]) : false;
            application.PercuNumberG = application.dtApplication.Rows[0]["PercuNumberG"].ToString();
            application.McaPerio = (application.dtApplication.Rows[0]["McaPerio"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPerio"]) : false;
            application.PerioNumber = application.dtApplication.Rows[0]["PerioNumber"].ToString();
            application.McaProstate = (application.dtApplication.Rows[0]["McaProstate"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaProstate"]) : false;
            application.ProstateNumber = application.dtApplication.Rows[0]["ProstateNumber"].ToString();
            application.McaRadio = (application.dtApplication.Rows[0]["McaRadio"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaRadio"]) : false;
            application.RadioNumber = application.dtApplication.Rows[0]["RadioNumber"].ToString();
            application.McaSilicone = (application.dtApplication.Rows[0]["McaSilicone"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaSilicone"]) : false;
            application.SiliconeNumber = application.dtApplication.Rows[0]["SiliconeNumber"].ToString();
            application.McaSaline = (application.dtApplication.Rows[0]["McaSaline"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaSaline"]) : false;
            application.SalineNumber = application.dtApplication.Rows[0]["SalineNumber"].ToString();
            application.McaThera = (application.dtApplication.Rows[0]["McaThera"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaThera"]) : false;
            application.TheraNumber = application.dtApplication.Rows[0]["TheraNumber"].ToString();
            application.McaUseL = (application.dtApplication.Rows[0]["McaUseL"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaUseL"]) : false;
            application.UseNumberL = application.dtApplication.Rows[0]["UseNumberL"].ToString();
            application.McaUseC = (application.dtApplication.Rows[0]["McaUseC"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaUseC"]) : false;
            application.UseNumberC = application.dtApplication.Rows[0]["UseNumberC"].ToString();

            //End Properties For Application5

            //Properties For Application6
            application.McaAbort = (application.dtApplication.Rows[0]["McaAbort"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaAbort"]) : false;
            application.AbortYear = application.dtApplication.Rows[0]["AbortYear"].ToString();
            application.AbortPercent = application.dtApplication.Rows[0]["AbortPercent"].ToString();
            application.McaAnes = (application.dtApplication.Rows[0]["McaAnes"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaAnes"]) : false;
            application.AnesYear = application.dtApplication.Rows[0]["AnesYear"].ToString();
            application.AnesPercent = application.dtApplication.Rows[0]["AnesPercent"].ToString();
            application.McaCardio = (application.dtApplication.Rows[0]["McaCardio"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaCardio"]) : false;
            application.CardioYear = application.dtApplication.Rows[0]["CardioYear"].ToString();
            application.CardioPercent = application.dtApplication.Rows[0]["CardioPercent"].ToString();
            application.McaChymo = (application.dtApplication.Rows[0]["McaChymo"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaChymo"]) : false;
            application.ChymoYear = application.dtApplication.Rows[0]["ChymoYear"].ToString();
            application.ChymoPercent = application.dtApplication.Rows[0]["ChymoPercent"].ToString();
            application.McaColon = (application.dtApplication.Rows[0]["McaColon"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaColon"]) : false;
            application.ColonYear = application.dtApplication.Rows[0]["ColonYear"].ToString();
            application.ColonPercent = application.dtApplication.Rows[0]["ColonPercent"].ToString();
            application.McaGen = (application.dtApplication.Rows[0]["McaGen"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaGen"]) : false;
            application.GenYear = application.dtApplication.Rows[0]["GenYear"].ToString();
            application.GenPercent = application.dtApplication.Rows[0]["GenPercent"].ToString();
            application.McaGyne = (application.dtApplication.Rows[0]["McaGyne"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaGyne"]) : false;
            application.GyneYear = application.dtApplication.Rows[0]["GyneYear"].ToString();
            application.GynePercent = application.dtApplication.Rows[0]["GynePercent"].ToString();
            application.McaHand = (application.dtApplication.Rows[0]["McaHand"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaHand"]) : false;
            application.HandYear = application.dtApplication.Rows[0]["HandYear"].ToString();
            application.HandPercent = application.dtApplication.Rows[0]["HandPercent"].ToString();
            application.McaHead = (application.dtApplication.Rows[0]["McaHead"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaHead"]) : false;
            application.HeadYear = application.dtApplication.Rows[0]["HeadYear"].ToString();
            application.HeadPercent = application.dtApplication.Rows[0]["HeadPercent"].ToString();
            application.McaLapa = (application.dtApplication.Rows[0]["McaLapa"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaLapa"]) : false;
            application.LapaYear = application.dtApplication.Rows[0]["LapaYear"].ToString();
            application.LapaPercent = application.dtApplication.Rows[0]["LapaPercent"].ToString();
            application.App6mcaOther = (application.dtApplication.Rows[0]["McaOther"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOther"]) : false;
            application.OtherYear = application.dtApplication.Rows[0]["OtherYear"].ToString();
            application.OtherPercent = application.dtApplication.Rows[0]["OtherPercent"].ToString();
            application.App6mcaLipo = (application.dtApplication.Rows[0]["McaLipo"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaLipo"]) : false;
            application.LipoYear = application.dtApplication.Rows[0]["LipoYear"].ToString();
            application.LipoPercent = application.dtApplication.Rows[0]["LipoPercent"].ToString();
            application.McaNeuro = (application.dtApplication.Rows[0]["McaNeuro"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaNeuro"]) : false;
            application.NeuroYear = application.dtApplication.Rows[0]["NeuroYear"].ToString();
            application.NeuroPercent = application.dtApplication.Rows[0]["NeuroPercent"].ToString();
            application.McaObs = (application.dtApplication.Rows[0]["McaObs"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaObs"]) : false;
            application.ObsYear = application.dtApplication.Rows[0]["ObsYear"].ToString();
            application.ObsPercent = application.dtApplication.Rows[0]["ObsPercent"].ToString();
            application.McaOph = (application.dtApplication.Rows[0]["McaOph"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOph"]) : false;
            application.OphYear = application.dtApplication.Rows[0]["OphYear"].ToString();
            application.OphPercent = application.dtApplication.Rows[0]["OphPercent"].ToString();
            application.McaOrth = (application.dtApplication.Rows[0]["McaOrth"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOrth"]) : false;
            application.OrthYear = application.dtApplication.Rows[0]["OrthYear"].ToString();
            application.OrthPercent = application.dtApplication.Rows[0]["OrthPercent"].ToString();
            application.McaOrtho = (application.dtApplication.Rows[0]["McaOrtho"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOrtho"]) : false;
            application.OrthoYear = application.dtApplication.Rows[0]["OrthoYear"].ToString();
            application.OrthoPercent = application.dtApplication.Rows[0]["OrthoPercent"].ToString();
            application.McaOrthoReplace = (application.dtApplication.Rows[0]["McaOrthoReplace"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaOrthoReplace"]) : false;
            application.OrthoReplaceYear = application.dtApplication.Rows[0]["OrthoReplaceYear"].ToString();
            application.OrthoReplacePercent = application.dtApplication.Rows[0]["OrthoReplacePercent"].ToString();
            application.McaPlaSurElective = (application.dtApplication.Rows[0]["McaPlaSurElective"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPlaSurElective"]) : false;
            application.PlaSurElectiveYear = application.dtApplication.Rows[0]["PlaSurElectiveYear"].ToString();
            application.PlaSurElectivePercent = application.dtApplication.Rows[0]["PlaSurElectivePercent"].ToString();
            application.McaPlaSurOther = (application.dtApplication.Rows[0]["McaPlaSurOther"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaPlaSurOther"]) : false;
            application.PlaSurOtherYear = application.dtApplication.Rows[0]["PlaSurOtherYear"].ToString();
            application.PlaSurOtherPercent = application.dtApplication.Rows[0]["PlaSurOtherPercent"].ToString();
            application.McaRefra = (application.dtApplication.Rows[0]["McaRefra"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaRefra"]) : false;
            application.RefraYear = application.dtApplication.Rows[0]["RefraYear"].ToString();
            application.RefraPercent = application.dtApplication.Rows[0]["RefraPercent"].ToString();
            application.McaSpinLumbar = (application.dtApplication.Rows[0]["McaSpinLumbar"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaSpinLumbar"]) : false;
            application.SpinLumbarYear = application.dtApplication.Rows[0]["SpinLumbarYear"].ToString();
            application.SpinLumbarPercent = application.dtApplication.Rows[0]["SpinLumbarPercent"].ToString();
            application.McaSpinOther = (application.dtApplication.Rows[0]["McaSpinOther"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaSpinOther"]) : false;
            application.SpinOtherYear = application.dtApplication.Rows[0]["SpinOtherYear"].ToString();
            application.SpinOtherPercent = application.dtApplication.Rows[0]["SpinOtherPercent"].ToString();
            application.McaThora = (application.dtApplication.Rows[0]["McaThora"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaThora"]) : false;
            application.ThoraYear = application.dtApplication.Rows[0]["ThoraYear"].ToString();
            application.ThoraPercent = application.dtApplication.Rows[0]["ThoraPercent"].ToString();
            application.McaUro = (application.dtApplication.Rows[0]["McaUro"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaUro"]) : false;
            application.UroYear = application.dtApplication.Rows[0]["UroYear"].ToString();
            application.UroPercent = application.dtApplication.Rows[0]["UroPercent"].ToString();
            application.McaVas = (application.dtApplication.Rows[0]["McaVas"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["McaVas"]) : false;
            application.VasYear = application.dtApplication.Rows[0]["VasYear"].ToString();
            application.VasPercent = application.dtApplication.Rows[0]["VasPercent"].ToString();
            application.Mca42a = (application.dtApplication.Rows[0]["Mca42a"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42a"]) : false;
            application.Mca42b = (application.dtApplication.Rows[0]["Mca42b"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42b"]) : false;
            application.Mca42c = (application.dtApplication.Rows[0]["Mca42c"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42c"]) : false;
            application.Mca42d = (application.dtApplication.Rows[0]["Mca42d"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42d"]) : false;
            application.Mca42e = (application.dtApplication.Rows[0]["Mca42e"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42e"]) : false;
            application.Mca42f = (application.dtApplication.Rows[0]["Mca42f"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42f"]) : false;
            application.Mca42g = application.dtApplication.Rows[0]["Mca42g"].ToString();
            application.Mca42h = (application.dtApplication.Rows[0]["Mca42h"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42h"]) : false;
            application.Mca42i = (application.dtApplication.Rows[0]["Mca42i"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42i"]) : false;
            application.Mca42j = (application.dtApplication.Rows[0]["Mca42j"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42j"]) : false;
            application.Mca42k = (application.dtApplication.Rows[0]["Mca42k"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42k"]) : false;
            application.Mca42kDesc = application.dtApplication.Rows[0]["Mca42kDesc"].ToString();
            application.Mca42l = (application.dtApplication.Rows[0]["Mca42l"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca42l"]) : false;
            application.Mca42lDesc = application.dtApplication.Rows[0]["Mca42lDesc"].ToString();
            application.app643Desc = application.dtApplication.Rows[0]["43Desc"].ToString();
            application.Mca44 = (application.dtApplication.Rows[0]["Mca44"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca44"]) : false;
            application.app644Desc = application.dtApplication.Rows[0]["44Desc"].ToString();
            application.Mca45 = (application.dtApplication.Rows[0]["Mca45"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca45"]) : false;
            application.Mca46 = (application.dtApplication.Rows[0]["Mca46"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca46"]) : false;
            application.Mca47 = (application.dtApplication.Rows[0]["Mca47"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca47"]) : false;
            application.app647Inst = application.dtApplication.Rows[0]["47Inst"].ToString();
            application.app647Addr = application.dtApplication.Rows[0]["47Addr"].ToString();
            application.Mca47b = (application.dtApplication.Rows[0]["Mca47b"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca47b"]) : false;
            application.app647bPercent = application.dtApplication.Rows[0]["47bPercent"].ToString();
            application.Mca48 = (application.dtApplication.Rows[0]["Mca48"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca48"]) : false;
            application.app648Ent = application.dtApplication.Rows[0]["48Ent"].ToString();
            application.app648Addr = application.dtApplication.Rows[0]["48Addr"].ToString();
            application.Mca48b = (application.dtApplication.Rows[0]["Mca48b"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca48b"]) : false;
            application.Mca48c = (application.dtApplication.Rows[0]["Mca48c"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca48c"]) : false;
            application.Mca49 = (application.dtApplication.Rows[0]["Mca49"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca49"]) : false;
            application.app649Desc = application.dtApplication.Rows[0]["49Desc"].ToString();
            application.Mca50 = (application.dtApplication.Rows[0]["Mca50"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca50"]) : false;
            application.app650Desc = application.dtApplication.Rows[0]["50Desc"].ToString();
            application.Mca51 = (application.dtApplication.Rows[0]["Mca51"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca51"]) : false;
            application.Mca52 = (application.dtApplication.Rows[0]["Mca52"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca52"]) : false;
            application.Mca53 = (application.dtApplication.Rows[0]["Mca53"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca53"]) : false;
            application.Mca54 = (application.dtApplication.Rows[0]["Mca54"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca54"]) : false;
            application.app654b = application.dtApplication.Rows[0]["54b"].ToString();
            application.app654c = application.dtApplication.Rows[0]["54c"].ToString();
            application.app654d = application.dtApplication.Rows[0]["54d"].ToString();
            application.Mca55 = (application.dtApplication.Rows[0]["Mca55"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca55"]) : false;
            application.app655Desc = application.dtApplication.Rows[0]["55Desc"].ToString();
            application.Mca56 = (application.dtApplication.Rows[0]["Mca56"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca56"]) : false;
            application.Mca56First = (application.dtApplication.Rows[0]["Mca56First"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca56First"]) : false;
            application.Mca56Second = (application.dtApplication.Rows[0]["Mca56Second"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca56Second"]) : false;
            application.Mca56Third = (application.dtApplication.Rows[0]["Mca56Third"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca56Third"]) : false;
            application.Desc56A = application.dtApplication.Rows[0]["Desc56A"].ToString();
            application.Desc56B = application.dtApplication.Rows[0]["Desc56B"].ToString();
            application.Desc56C = application.dtApplication.Rows[0]["Desc56C"].ToString();
            application.Mca57 = (application.dtApplication.Rows[0]["Mca57"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca57"]) : false;
            application.app657DescA = application.dtApplication.Rows[0]["57DescA"].ToString();
            application.app657DescB = application.dtApplication.Rows[0]["57DescB"].ToString();
            application.Mca58 = (application.dtApplication.Rows[0]["Mca58"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca58"]) : false;
            application.app658DescA = application.dtApplication.Rows[0]["58DescA"].ToString();
            application.Mca59 = (application.dtApplication.Rows[0]["Mca59"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca59"]) : false;
            application.Mca60 = (application.dtApplication.Rows[0]["Mca60"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca60"]) : false;
            application.Mca61 = (application.dtApplication.Rows[0]["Mca61"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca61"]) : false;
            //End Properties For Application6

            //Properties For Application7
            application.Mca62 = (application.dtApplication.Rows[0]["Mca62"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca62"]) : false;
            application.Mca63 = (application.dtApplication.Rows[0]["Mca63"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca63"]) : false;
            application.Mca64 = (application.dtApplication.Rows[0]["Mca64"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca64"]) : false;
            application.Mca65 = (application.dtApplication.Rows[0]["Mca65"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca65"]) : false;
            application.Mca66 = (application.dtApplication.Rows[0]["Mca66"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca66"]) : false;
            application.Mca67 = (application.dtApplication.Rows[0]["Mca67"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca67"]) : false;
            application.Mca68 = (application.dtApplication.Rows[0]["Mca68"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca68"]) : false;
            application.Mca69 = (application.dtApplication.Rows[0]["Mca69"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca69"]) : false;
            application.Mca70 = (application.dtApplication.Rows[0]["Mca70"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca70"]) : false;
            application.Mca71 = (application.dtApplication.Rows[0]["Mca71"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca71"]) : false;
            application.Mca72 = (application.dtApplication.Rows[0]["Mca72"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca72"]) : false;
            application.Mca73 = (application.dtApplication.Rows[0]["Mca73"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca73"]) : false;
            application.Mca73a = (application.dtApplication.Rows[0]["Mca73a"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca73a"]) : false;
            application.Mca73b = (application.dtApplication.Rows[0]["Mca73b"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca73b"]) : false;
            application.Mca73c = (application.dtApplication.Rows[0]["Mca73c"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca73c"]) : false;
            application.Mca73d = (application.dtApplication.Rows[0]["Mca73d"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca73d"]) : false;
            application.Mca73e = (application.dtApplication.Rows[0]["Mca73e"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca73e"]) : false;
            application.Mca73f = (application.dtApplication.Rows[0]["Mca73f"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca73f"]) : false;
            //End Properties For Application7

            //Properties For Application8
            application.PatientName = application.dtApplication.Rows[0]["PatientName"].ToString();
            application.DateOfIncident = (application.dtApplication.Rows[0]["DateOfIncident"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["DateOfIncident"]).ToShortDateString() : "";
            application.DateReported = (application.dtApplication.Rows[0]["DateReported"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["DateReported"]).ToShortDateString() : "";
            application.InsuranceNameCarrier = application.dtApplication.Rows[0]["InsuranceNameCarrier"].ToString();
            application.Allegation = application.dtApplication.Rows[0]["Allegation"].ToString();
            application.ConditionPatient = application.dtApplication.Rows[0]["ConditionPatient"].ToString();
            application.Mca7 = (application.dtApplication.Rows[0]["Mca7"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca7"]) : false;
            application.Mca8a = (application.dtApplication.Rows[0]["Mca8a"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8a"]) : false;
            application.Mca8b = (application.dtApplication.Rows[0]["Mca8b"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8b"]) : false;
            application.Mca8c = (application.dtApplication.Rows[0]["Mca8c"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8c"]) : false;
            application.Mca8d = (application.dtApplication.Rows[0]["Mca8d"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8d"]) : false;
            application.Mca8e = (application.dtApplication.Rows[0]["Mca8e"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8e"]) : false;
            application.app88ePayment = (application.dtApplication.Rows[0]["8ePayment"] != System.DBNull.Value) ? ((Decimal)application.dtApplication.Rows[0]["8ePayment"]) : 0;
            application.Mca8f = (application.dtApplication.Rows[0]["Mca8f"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8f"]) : false;
            application.app88fDate = (application.dtApplication.Rows[0]["8fDate"] != System.DBNull.Value) ? ((DateTime)application.dtApplication.Rows[0]["8fDate"]).ToShortDateString() : "";
            application.app88fPaid = (application.dtApplication.Rows[0]["8fPaid"] != System.DBNull.Value) ? ((Decimal)application.dtApplication.Rows[0]["8fPaid"]) : 0;
            application.Mca8fc = (application.dtApplication.Rows[0]["Mca8fc"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8fc"]) : false;
            application.Mca8g = (application.dtApplication.Rows[0]["Mca8g"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8g"]) : false;
            application.Mca8h = (application.dtApplication.Rows[0]["Mca8h"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8h"]) : false;
            application.Mca8i = (application.dtApplication.Rows[0]["Mca8i"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8i"]) : false;
            application.Mca8j = (application.dtApplication.Rows[0]["Mca8j"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8j"]) : false;
            application.Mca8k = (application.dtApplication.Rows[0]["Mca8k"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8k"]) : false;
            application.Mca8l = (application.dtApplication.Rows[0]["Mca8l"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8l"]) : false;
            application.Mca8m = (application.dtApplication.Rows[0]["Mca8m"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8m"]) : false;
            application.Mca8n = (application.dtApplication.Rows[0]["Mca8n"] != System.DBNull.Value) ? ((bool)application.dtApplication.Rows[0]["Mca8n"]) : false;
            application.app89Desc = application.dtApplication.Rows[0]["9Desc"].ToString();

            //End Properties For Application8

            return application;
        }

        private static XmlDocument DeleteApplicationByTaskControlIDXml(int taskControlID)
        {
            DbRequestXmlCookRequestItem[] cookItems =
                new DbRequestXmlCookRequestItem[1];

            DbRequestXmlCooker.AttachCookItem("TaskControlID",
                SqlDbType.Int, 0, taskControlID.ToString(),
                ref cookItems);

            XmlDocument xmlDoc;

            try
            {
                xmlDoc = DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }

            return xmlDoc;
        }

        private XmlDocument SaveApplication1Xml()
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[94];

            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Status", SqlDbType.Int, 0, this.Status.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Comments", SqlDbType.VarChar, 250, this.Comments.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriCarierName1", SqlDbType.VarChar, 75, this.PriCarierName1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPolEffecDate1", SqlDbType.VarChar, 8, this.PriPolEffecDate1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPolLimits1", SqlDbType.VarChar, 50, this.PriPolLimits1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriClaims1", SqlDbType.VarChar, 50, this.PriClaims1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriCarierName2", SqlDbType.VarChar, 75, this.PriCarierName2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPolEffecDate2", SqlDbType.VarChar, 8, this.PriPolEffecDate2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPolLimits2", SqlDbType.VarChar, 50, this.PriPolLimits2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriClaims2", SqlDbType.VarChar, 50, this.PriClaims2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriCarierName3", SqlDbType.VarChar, 75, this.PriCarierName3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPolEffecDate3", SqlDbType.VarChar, 8, this.PriPolEffecDate3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPolLimits3", SqlDbType.VarChar, 50, this.PriPolLimits3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriClaims3", SqlDbType.VarChar, 50, this.PriClaims3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcCarierName1", SqlDbType.VarChar, 75, this.ExcCarierName1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcPolEffecDate1", SqlDbType.VarChar, 8, this.ExcPolEffecDate1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcPolLimits1", SqlDbType.VarChar, 50, this.ExcPolLimits1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcClaims1", SqlDbType.VarChar, 50, this.ExcClaims1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcCarierName2", SqlDbType.VarChar, 75, this.ExcCarierName2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcPolEffecDate2", SqlDbType.VarChar, 8, this.ExcPolEffecDate2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcPolLimits2", SqlDbType.VarChar, 50, this.ExcPolLimits2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcClaims2", SqlDbType.VarChar, 50, this.ExcClaims2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcCarierName3", SqlDbType.VarChar, 75, this.ExcCarierName3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcPolEffecDate3", SqlDbType.VarChar, 8, this.ExcPolEffecDate3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcPolLimits3", SqlDbType.VarChar, 50, this.ExcPolLimits3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcClaims3", SqlDbType.VarChar, 50, this.ExcClaims3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaInsuranceCia", SqlDbType.Bit, 0, this.McaInsuranceCia.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("InsuranceCiaDesc", SqlDbType.VarChar, 100, this.InsuranceCiaDesc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("MedSchool", SqlDbType.VarChar, 75, this.MedSchool.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("MedCity", SqlDbType.VarChar, 50, this.MedCity.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("MedFrom", SqlDbType.VarChar, 50, this.MedFrom.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("MedDegree", SqlDbType.VarChar, 50, this.MedDegree.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IntSchool", SqlDbType.VarChar, 75, this.IntSchool.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IntCity", SqlDbType.VarChar, 50, this.IntCity.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IntFrom", SqlDbType.VarChar, 50, this.IntFrom.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IntDegree", SqlDbType.VarChar, 50, this.IntDegree.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ResSchool", SqlDbType.VarChar, 75, this.ResSchool.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ResCity", SqlDbType.VarChar, 50, this.ResCity.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ResFrom", SqlDbType.VarChar, 50, this.ResFrom.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ResDegree", SqlDbType.VarChar, 50, this.ResDegree.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FellSchool", SqlDbType.VarChar, 75, this.FellSchool.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FellCity", SqlDbType.VarChar, 50, this.FellCity.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FellFrom", SqlDbType.VarChar, 50, this.FellFrom.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FellDegree", SqlDbType.VarChar, 50, this.FellDegree.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OSchool", SqlDbType.VarChar, 75, this.OSchool.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OCity", SqlDbType.VarChar, 50, this.OCity.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OFrom", SqlDbType.VarChar, 50, this.OFrom.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ODegree", SqlDbType.VarChar, 50, this.ODegree.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaCertified", SqlDbType.Bit, 0, this.McaCertified.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaResTraining", SqlDbType.Bit, 0, this.McaResTraining.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Residency", SqlDbType.VarChar, 75, this.Residency.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRMEDICRATEID", SqlDbType.Int, 0, this.PRMEDICRATEID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IsoCode", SqlDbType.VarChar, 50, this.IsoCode.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Class", SqlDbType.VarChar, 5, this.ClassRate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateYear1", SqlDbType.Float, 0, this.RateYear1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateYear2", SqlDbType.Float, 0, this.RateYear2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RateYear3", SqlDbType.Float, 0, this.RateYear3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("MCMRate", SqlDbType.Float, 0, this.MCMRate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRMedicalLimitID", SqlDbType.Int, 0, this.PRMedicalLimitID.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Rate12", SqlDbType.Float, 0, this.RateYear12.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate22", SqlDbType.Float, 0, this.RateYear22.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate32", SqlDbType.Float, 0, this.RateYear32.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate42", SqlDbType.Float, 0, this.RateYear42.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRMedicalLimit2ID", SqlDbType.Int, 0, this.PRMedicalLimit2ID.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Rate13", SqlDbType.Float, 0, this.RateYear13.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate23", SqlDbType.Float, 0, this.RateYear23.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate33", SqlDbType.Float, 0, this.RateYear33.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate43", SqlDbType.Float, 0, this.RateYear43.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRMedicalLimit3ID", SqlDbType.Int, 0, this.PRMedicalLimit3ID.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Rate14", SqlDbType.Float, 0, this.RateYear14.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate24", SqlDbType.Float, 0, this.RateYear24.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate34", SqlDbType.Float, 0, this.RateYear34.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate44", SqlDbType.Float, 0, this.RateYear44.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRMedicalLimit4ID", SqlDbType.Int, 0, this.PRMedicalLimit4ID.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Rate15", SqlDbType.Float, 0, this.RateYear15.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate25", SqlDbType.Float, 0, this.RateYear25.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate35", SqlDbType.Float, 0, this.RateYear35.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate45", SqlDbType.Float, 0, this.RateYear45.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRMedicalLimit5ID", SqlDbType.Int, 0, this.PRMedicalLimit5ID.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("Rate16", SqlDbType.Float, 0, this.RateYear16.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate26", SqlDbType.Float, 0, this.RateYear26.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate36", SqlDbType.Float, 0, this.RateYear36.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Rate46", SqlDbType.Float, 0, this.RateYear46.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRMedicalLimit6ID", SqlDbType.Int, 0, this.PRMedicalLimit6ID.ToString(), ref cookItems);

            DbRequestXmlCooker.AttachCookItem("PRateYear1", SqlDbType.Float, 0, this.PRateYear1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRateYear2", SqlDbType.Float, 0, this.PRateYear2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRateYear3", SqlDbType.Float, 0, this.PRateYear3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRateYear4", SqlDbType.Float, 0, this.PRateYear4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRPrimaryLimitID", SqlDbType.Int, 0, this.PRPrimaryLimitID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PRPrimeryRateID", SqlDbType.Int, 0, this.PRPrimeryRateID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IsPrimary", SqlDbType.Bit, 0, this.IsPrimary.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PrimaryRetroDate", SqlDbType.VarChar, 20, this.PrimaryRetroDate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExcessRetroDate", SqlDbType.VarChar, 20, this.ExcessRetroDate.ToString(), ref cookItems);


            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
        }

        private XmlDocument SaveApplication2Xml()
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[55];

            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriSpecialty", SqlDbType.VarChar, 6, this.PriSpecialty.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PriPractice", SqlDbType.VarChar, 6, this.PriPractice.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("SecSpecialty", SqlDbType.VarChar, 6, this.SecSpecialty.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("SecPractice", SqlDbType.VarChar, 6, this.SecPractice.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPracticeLimit", SqlDbType.Bit, 0, this.McaPracticeLimit.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PracticeLimitDesc", SqlDbType.VarChar, 200, this.PracticeLimitDesc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaBoardCertified", SqlDbType.Bit, 0, this.McaBoardCertified.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc1", SqlDbType.VarChar, 100, this.BoardCertifiedDesc1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc2", SqlDbType.VarChar, 100, this.BoardCertifiedDesc2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc3", SqlDbType.VarChar, 100, this.BoardCertifiedDesc3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc4", SqlDbType.VarChar, 100, this.BoardCertifiedDesc4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc5", SqlDbType.VarChar, 100, this.BoardCertifiedDesc5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc6", SqlDbType.VarChar, 100, this.BoardCertifiedDesc6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc7", SqlDbType.DateTime, 0, this.BoardCertifiedDesc7.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc8", SqlDbType.DateTime, 0, this.BoardCertifiedDesc8.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc9", SqlDbType.DateTime, 0, this.BoardCertifiedDesc9.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc10", SqlDbType.VarChar, 100, this.BoardCertifiedDesc10.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc11", SqlDbType.VarChar, 100, this.BoardCertifiedDesc11.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardCertifiedDesc12", SqlDbType.VarChar, 100, this.BoardCertifiedDesc12.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EleExpDate", SqlDbType.DateTime, 0, this.EleExpDate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ExpiredWhy", SqlDbType.VarChar, 200, this.ExpiredWhy.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaBoardExam", SqlDbType.Bit, 0, this.McaBoardExam.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardExamDesc", SqlDbType.VarChar, 200, this.BoardExamDesc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaWrittenExam", SqlDbType.Bit, 0, this.McaWrittenExam.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("WrittenWhen", SqlDbType.DateTime, 0, this.WrittenWhen.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("WrittenResult", SqlDbType.VarChar, 10, this.WrittenResult.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOralExam", SqlDbType.Bit, 0, this.McaOralExam.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OralWhen", SqlDbType.DateTime, 0, this.OralWhen.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OralResult", SqlDbType.VarChar, 50, this.OralResult.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaFailedBoardExam", SqlDbType.Bit, 0, this.McaFailedBoardExam.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardFailedSpecialty", SqlDbType.VarChar, 75, this.BoardFailedSpecialty.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BoardDate", SqlDbType.VarChar, 8, this.BoardDate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaMilitary", SqlDbType.Bit, 0, this.McaMilitary.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("MilitaryDesc", SqlDbType.VarChar, 200, this.MilitaryDesc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaMilitaryReserve", SqlDbType.Bit, 0, this.McaMilitaryReserve.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicState1", SqlDbType.VarChar, 50, this.LicState1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicYear1", SqlDbType.VarChar, 4, this.LicYear1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicNumber1", SqlDbType.VarChar, 50, this.LicNumber1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicStatus1", SqlDbType.VarChar, 50, this.LicStatus1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicState2", SqlDbType.VarChar, 50, this.LicState2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicYear2", SqlDbType.VarChar, 4, this.LicYear2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicNumber2", SqlDbType.VarChar, 50, this.LicNumber2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicStatus2", SqlDbType.VarChar, 50, this.LicStatus2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicState3", SqlDbType.VarChar, 50, this.LicState3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicYear3", SqlDbType.VarChar, 4, this.LicYear3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicNumber3", SqlDbType.VarChar, 50, this.LicNumber3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicStatus3", SqlDbType.VarChar, 50, this.LicStatus3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LicInactive", SqlDbType.VarChar, 200, this.LicInactive.ToString(), ref cookItems);          
            DbRequestXmlCooker.AttachCookItem("McaMedSocieties", SqlDbType.Bit, 0, this.McaMedSocieties.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("MedSocietiesDesc", SqlDbType.VarChar, 200, this.MedSocietiesDesc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaNationalSocieties", SqlDbType.Bit, 0, this.McaNationalSocieties.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NationalSocietiesDesc", SqlDbType.VarChar, 200, this.NationalSocietiesDesc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaStateMedSocieties", SqlDbType.Bit, 0, this.McaStateMedSocieties.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaLocalMedSocieties", SqlDbType.Bit, 0, this.McaLocalMedSocieties.ToString(), ref cookItems);

            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }


        }

        private XmlDocument SaveApplication3Xml()
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[61];


            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Hospital1", SqlDbType.VarChar, 50, this.Hospital1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("City1", SqlDbType.VarChar, 50, this.City1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Privileges1", SqlDbType.VarChar, 50, this.Privileges1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Restrictions1", SqlDbType.VarChar, 50, this.Restrictions1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Hospital2", SqlDbType.VarChar, 50, this.Hospital2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("City2", SqlDbType.VarChar, 50, this.City2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Privileges2", SqlDbType.VarChar, 50, this.Privileges2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Restrictions2", SqlDbType.VarChar, 50, this.Restrictions2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Hospital3", SqlDbType.VarChar, 50, this.Hospital3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("City3", SqlDbType.VarChar, 50, this.City3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Privileges3", SqlDbType.VarChar, 50, this.Privileges3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Restrictions3", SqlDbType.VarChar, 50, this.Restrictions3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Hospital4", SqlDbType.VarChar, 50, this.Hospital4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("City4", SqlDbType.VarChar, 50, this.City4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Privileges4", SqlDbType.VarChar, 50, this.Privileges4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Restrictions4", SqlDbType.VarChar, 50, this.Restrictions4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OficeAddr1", SqlDbType.VarChar, 50, this.OficeAddr1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OficeCity1", SqlDbType.VarChar, 50, this.OficeCity1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OficeCountry1", SqlDbType.VarChar, 50, this.OficeCountry1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OficeAddr2", SqlDbType.VarChar, 50, this.OficeAddr2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OficeCity2", SqlDbType.VarChar, 50, this.OficeCity2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OficeCountry2", SqlDbType.VarChar, 50, this.OficeCountry2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OficeAddr3", SqlDbType.VarChar, 50, this.OficeAddr3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OficeCity3", SqlDbType.VarChar, 50, this.OficeCity3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OficeCountry3", SqlDbType.VarChar, 50, this.OficeCountry3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntName1", SqlDbType.VarChar, 50, this.EntName1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntDate1", SqlDbType.DateTime, 8, this.EntDate1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntAddr1", SqlDbType.VarChar, 50, this.EntAddr1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntSpecialty1", SqlDbType.VarChar, 50, this.EntSpecialty1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntName2", SqlDbType.VarChar, 50, this.EntName2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntDate2", SqlDbType.DateTime, 8, this.EntDate2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntAddr2", SqlDbType.VarChar, 50, this.EntAddr2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntSpecialty2", SqlDbType.VarChar, 50, this.EntSpecialty2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntName3", SqlDbType.VarChar, 50, this.EntName3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntDate3", SqlDbType.DateTime, 8, this.EntDate3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntAddr3", SqlDbType.VarChar, 50, this.EntAddr3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntSpecialty3", SqlDbType.VarChar, 50, this.EntSpecialty3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntName4", SqlDbType.VarChar, 50, this.EntName4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntDate4", SqlDbType.DateTime, 8, this.EntDate4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntAddr4", SqlDbType.VarChar, 50, this.EntAddr4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntSpecialty4", SqlDbType.VarChar, 50, this.EntSpecialty4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntName5", SqlDbType.VarChar, 50, this.EntName5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntDate5", SqlDbType.DateTime, 8, this.EntDate5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntAddr5", SqlDbType.VarChar, 50, this.EntAddr5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EntSpecialty5", SqlDbType.VarChar, 50, this.EntSpecialty5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPhysician", SqlDbType.Bit, 0, this.McaPhysician.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaEmpPhysician", SqlDbType.Bit, 0, this.McaEmpPhysician.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaProfAss", SqlDbType.Bit, 0, this.McaProfAss.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOther", SqlDbType.Bit, 0, this.McaOther.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPartnership", SqlDbType.Bit, 0, this.McaPartnership.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaGroup", SqlDbType.Bit, 0, this.McaGroup.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaProfCorp", SqlDbType.Bit, 0, this.McaProfCorp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PhyEntName", SqlDbType.VarChar, 50, this.PhyEntName.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PhyStatus", SqlDbType.VarChar, 50, this.PhyStatus.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PhyPartners", SqlDbType.VarChar, 200, this.PhyPartners.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOtherPhy", SqlDbType.Bit, 0, this.McaOtherPhy.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PhyName", SqlDbType.VarChar, 50, this.PhyName.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PhyAssoc", SqlDbType.VarChar, 50, this.PhyAssoc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaRefferral", SqlDbType.Bit, 0, this.McaRefferral.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RefferralDesc", SqlDbType.VarChar, 200, this.RefferralDesc.ToString(), ref cookItems);



            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }


        }

        private XmlDocument SaveApplication4Xml()
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[106];

            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaLab", SqlDbType.Bit, 0, this.McaLab.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LabHours", SqlDbType.VarChar, 4, this.LabHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LabEmp", SqlDbType.VarChar, 4, this.LabEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPhy", SqlDbType.Bit, 0, this.McaPhy.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PhyHours", SqlDbType.VarChar, 4, this.PhyHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PhyEmp", SqlDbType.VarChar, 4, this.PhyEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaXray", SqlDbType.Bit, 0, this.McaXray.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("XrayHours", SqlDbType.VarChar, 4, this.XrayHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("XrayEmp", SqlDbType.VarChar, 4, this.XrayEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOther", SqlDbType.Bit, 0, this.McaOther.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OtherHours", SqlDbType.VarChar, 4, this.OtherHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OtherEmp", SqlDbType.VarChar, 4, this.OtherEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaNurseAnes", SqlDbType.Bit, 0, this.McaNurseAnes.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NurseAnesHours", SqlDbType.VarChar, 4, this.NurseAnesHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NurseAnesEmp", SqlDbType.VarChar, 4, this.NurseAnesEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaNurseMid", SqlDbType.Bit, 0, this.McaNurseMid.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NurseMidHours", SqlDbType.VarChar, 4, this.NurseMidHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NurseMidEmp", SqlDbType.VarChar, 4, this.NurseMidEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaNursePerf", SqlDbType.Bit, 0, this.McaNursePerf.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NursePerfHours", SqlDbType.VarChar, 4, this.NursePerfHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NursePerfEmp", SqlDbType.VarChar, 4, this.NursePerfEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaNursePrac", SqlDbType.Bit, 0, this.McaNursePrac.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NursePracHours", SqlDbType.VarChar, 4, this.NursePracHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NursePracEmp", SqlDbType.VarChar, 4, this.NursePracEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOpto", SqlDbType.Bit, 0, this.McaOpto.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OptoHours", SqlDbType.VarChar, 4, this.OptoHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OptoEmp", SqlDbType.VarChar, 4, this.OptoEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPhyAss", SqlDbType.Bit, 0, this.McaPhyAss.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PhyAssHours", SqlDbType.VarChar, 4, this.PhyAssHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PhyAssEmp", SqlDbType.VarChar, 4, this.PhyAssEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPsych", SqlDbType.Bit, 0, this.McaPsych.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PsychHours", SqlDbType.VarChar, 4, this.PsychHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PsychEmp", SqlDbType.VarChar, 4, this.PsychEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaScrub", SqlDbType.Bit, 0, this.McaScrub.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ScrubHours", SqlDbType.VarChar, 4, this.ScrubHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ScrubEmp", SqlDbType.VarChar, 4, this.ScrubEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaSurgical", SqlDbType.Bit, 0, this.McaSurgical.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("SurgicalHours", SqlDbType.VarChar, 4, this.SurgicalHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("SurgicalEmp", SqlDbType.VarChar, 4, this.SurgicalEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOtherDesc", SqlDbType.Bit, 0, this.McaOtherDesc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OtherDescHours", SqlDbType.VarChar, 4, this.OtherDescHours.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OtherDescEmp", SqlDbType.VarChar, 4, this.OtherDescEmp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCName1", SqlDbType.VarChar, 50, this.HCName1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCSpeciality1", SqlDbType.VarChar, 50, this.HCSpeciality1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCInsured1", SqlDbType.VarChar, 50, this.HCInsured1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCLimits1", SqlDbType.VarChar, 50, this.HCLimits1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCName2", SqlDbType.VarChar, 50, this.HCName2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCSpecialty2", SqlDbType.VarChar, 50, this.HCSpecialty2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCInsured2", SqlDbType.VarChar, 50, this.HCInsured2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCLimits2", SqlDbType.VarChar, 50, this.HCLimits2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCName3", SqlDbType.VarChar, 50, this.HCName3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCSpecialty3", SqlDbType.VarChar, 50, this.HCSpecialty3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCInsured3", SqlDbType.VarChar, 50, this.HCInsured3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HCLimits3", SqlDbType.VarChar, 50, this.HCLimits3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaNone", SqlDbType.Bit, 0, this.McaNone.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaBlood", SqlDbType.Bit, 0, this.McaBlood.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaBirthing", SqlDbType.Bit, 0, this.McaBirthing.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaCity", SqlDbType.Bit, 0, this.McaCity.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaClinic", SqlDbType.Bit, 0, this.McaClinic.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaEmergency", SqlDbType.Bit, 0, this.McaEmergency.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaEmerHospital", SqlDbType.Bit, 0, this.McaEmerHospital.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaFreeStanding", SqlDbType.Bit, 0, this.McaFreeStanding.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaHospital", SqlDbType.Bit, 0, this.McaHospital.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaConva", SqlDbType.Bit, 0, this.McaConva.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPsy", SqlDbType.Bit, 0, this.McaPsy.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaInd", SqlDbType.Bit, 0, this.McaInd.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaLaboratory", SqlDbType.Bit, 0, this.McaLaboratory.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaNursing", SqlDbType.Bit, 0, this.McaNursing.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaSanitarium", SqlDbType.Bit, 0, this.McaSanitarium.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaUrgent", SqlDbType.Bit, 0, this.McaUrgent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaXrayFacility", SqlDbType.Bit, 0, this.McaXrayFacility.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOtherHC", SqlDbType.Bit, 0, this.McaOtherHC.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FacilityName1", SqlDbType.VarChar, 50, this.FacilityName1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FacilityAddr1", SqlDbType.VarChar, 50, this.FacilityAddr1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FacilityType1", SqlDbType.VarChar, 50, this.FacilityType1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FacilityDuties1", SqlDbType.VarChar, 50, this.FacilityDuties1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FacilityNumbers1", SqlDbType.VarChar, 50, this.FacilityNumbers1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaProfLiab1", SqlDbType.Bit, 0, this.McaProfLiab1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaExtendedCov1", SqlDbType.Bit, 0, this.McaExtendedCov1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FacilityName2", SqlDbType.VarChar, 50, this.FacilityName2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FacilityAddr2", SqlDbType.VarChar, 50, this.FacilityAddr2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FacilityType2", SqlDbType.VarChar, 50, this.FacilityType2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FacilityDuties2", SqlDbType.VarChar, 50, this.FacilityDuties2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("FacilityNumbers2", SqlDbType.VarChar, 50, this.FacilityNumbers2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaProfLiab", SqlDbType.Bit, 0, this.McaProfLiab.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaExtendedCov", SqlDbType.Bit, 0, this.McaExtendedCov.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaFullTimeCov", SqlDbType.Bit, 0, this.McaFullTimeCov.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPartTimeCov", SqlDbType.Bit, 0, this.McaPartTimeCov.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("DaysPWeek", SqlDbType.VarChar, 1, this.DaysPWeek.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HoursPDayOffice", SqlDbType.VarChar, 2, this.HoursPDayOffice.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PatienPWeek", SqlDbType.VarChar, 3, this.PatienPWeek.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HoursPDayHosp", SqlDbType.VarChar, 2, this.HoursPDayHosp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ActDesc", SqlDbType.VarChar, 200, this.ActDesc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Number1", SqlDbType.VarChar, 50, this.app339Number1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Hours1", SqlDbType.VarChar, 50, this.app339Hours1.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Number2", SqlDbType.VarChar, 50, this.app339Number2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Hours2", SqlDbType.VarChar, 50, this.app339Hours2.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Number3", SqlDbType.VarChar, 50, this.app339Number3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Hours3", SqlDbType.VarChar, 50, this.app339Hours3.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Number4", SqlDbType.VarChar, 50, this.app339Number4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Hours4", SqlDbType.VarChar, 50, this.app339Hours4.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Number5", SqlDbType.VarChar, 50, this.app339Number5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Hours5", SqlDbType.VarChar, 50, this.app339Hours5.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Number6", SqlDbType.VarChar, 50, this.app339Number6.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("39Hours6", SqlDbType.VarChar, 50, this.app339Hours6.ToString(), ref cookItems);



            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
        }

        private XmlDocument SaveApplication5Xml()
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[65];

            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaAngio", SqlDbType.Bit, 0, this.McaAngio.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AngioNumber", SqlDbType.VarChar, 3, this.AngioNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaAngioPTA", SqlDbType.Bit, 0, this.McaAngioPTA.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AngioPTANumber", SqlDbType.VarChar, 3, this.AngioPTANumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaAorto", SqlDbType.Bit, 0, this.McaAorto.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AortoNumber", SqlDbType.VarChar, 3, this.AortoNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaBiopsy", SqlDbType.Bit, 0, this.McaBiopsy.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BiopsyNumber", SqlDbType.VarChar, 3, this.BiopsyNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaBreast", SqlDbType.Bit, 0, this.McaBreast.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BreastNumber", SqlDbType.VarChar, 3, this.BreastNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaBreastImpl", SqlDbType.Bit, 0, this.McaBreastImpl.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("BreastImplNumber", SqlDbType.VarChar, 3, this.BreastImplNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaCardiac", SqlDbType.Bit, 0, this.McaCardiac.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("CardiacNumber", SqlDbType.VarChar, 3, this.CardiacNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaCoronary", SqlDbType.Bit, 0, this.McaCoronary.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("CoronaryNumber", SqlDbType.VarChar, 3, this.CoronaryNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaCholangio", SqlDbType.Bit, 0, this.McaCholangio.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("CholangioNumber", SqlDbType.VarChar, 3, this.CholangioNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaContrast", SqlDbType.Bit, 0, this.McaContrast.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ContrastNumber", SqlDbType.VarChar, 3, this.ContrastNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaEndo", SqlDbType.Bit, 0, this.McaEndo.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("EndoNumber", SqlDbType.VarChar, 3, this.EndoNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaHexa", SqlDbType.Bit, 0, this.McaHexa.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HexaNumber", SqlDbType.VarChar, 3, this.HexaNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaIntraO", SqlDbType.Bit, 0, this.McaIntraO.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IntraONumber", SqlDbType.VarChar, 3, this.IntraONumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaIntraG", SqlDbType.Bit, 0, this.McaIntraG.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IntraGNumber", SqlDbType.VarChar, 3, this.IntraGNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaIvp", SqlDbType.Bit, 0, this.McaIvp.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("IvpNumber", SqlDbType.VarChar, 3, this.IvpNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaKidney", SqlDbType.Bit, 0, this.McaKidney.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("KidneyNumber", SqlDbType.VarChar, 3, this.KidneyNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaLiver", SqlDbType.Bit, 0, this.McaLiver.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LiverNumber", SqlDbType.VarChar, 3, this.LiverNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaLipo", SqlDbType.Bit, 0, this.McaLipo.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LipoNumber", SqlDbType.VarChar, 3, this.LipoNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaLung", SqlDbType.Bit, 0, this.McaLung.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LungNumber", SqlDbType.VarChar, 3, this.LungNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaMyelo", SqlDbType.Bit, 0, this.McaMyelo.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("MyeloNumber", SqlDbType.VarChar, 3, this.MyeloNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPaceT", SqlDbType.Bit, 0, this.McaPaceT.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PaceNumberT", SqlDbType.VarChar, 3, this.PaceNumberT.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPaceP", SqlDbType.Bit, 0, this.McaPaceP.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PaceNumberP", SqlDbType.VarChar, 3, this.PaceNumberP.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPercuT", SqlDbType.Bit, 0, this.McaPercuT.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PercuNumberT", SqlDbType.VarChar, 3, this.PercuNumberT.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPercuG", SqlDbType.Bit, 0, this.McaPercuG.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PercuNumberG", SqlDbType.VarChar, 3, this.PercuNumberG.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPerio", SqlDbType.Bit, 0, this.McaPerio.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PerioNumber", SqlDbType.VarChar, 3, this.PerioNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaProstate", SqlDbType.Bit, 0, this.McaProstate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ProstateNumber", SqlDbType.VarChar, 3, this.ProstateNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaRadio", SqlDbType.Bit, 0, this.McaRadio.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RadioNumber", SqlDbType.VarChar, 3, this.RadioNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaSilicone", SqlDbType.Bit, 0, this.McaSilicone.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("SiliconeNumber", SqlDbType.VarChar, 3, this.SiliconeNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaSaline", SqlDbType.Bit, 0, this.McaSaline.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("SalineNumber", SqlDbType.VarChar, 3, this.SalineNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaThera", SqlDbType.Bit, 0, this.McaThera.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("TheraNumber", SqlDbType.VarChar, 3, this.TheraNumber.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaUseL", SqlDbType.Bit, 0, this.McaUseL.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("UseNumberL", SqlDbType.VarChar, 3, this.UseNumberL.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaUseC", SqlDbType.Bit, 0, this.McaUseC.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("UseNumberC", SqlDbType.VarChar, 3, this.UseNumberC.ToString(), ref cookItems);



            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
        }

        private XmlDocument SaveApplication6Xml()
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[136];

            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaAbort", SqlDbType.Bit, 0, this.McaAbort.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AbortYear", SqlDbType.VarChar, 4, this.AbortYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AbortPercent", SqlDbType.VarChar, 6, this.AbortPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaAnes", SqlDbType.Bit, 0, this.McaAnes.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AnesYear", SqlDbType.VarChar, 4, this.AnesYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("AnesPercent", SqlDbType.VarChar, 6, this.AnesPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaCardio", SqlDbType.Bit, 0, this.McaCardio.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("CardioYear", SqlDbType.VarChar, 4, this.CardioYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("CardioPercent", SqlDbType.VarChar, 6, this.CardioPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaChymo", SqlDbType.Bit, 0, this.McaChymo.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ChymoYear", SqlDbType.VarChar, 4, this.ChymoYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ChymoPercent", SqlDbType.VarChar, 6, this.ChymoPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaColon", SqlDbType.Bit, 0, this.McaColon.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ColonYear", SqlDbType.VarChar, 4, this.ColonYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ColonPercent", SqlDbType.VarChar, 6, this.ColonPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaGen", SqlDbType.Bit, 0, this.McaGen.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("GenYear", SqlDbType.VarChar, 4, this.GenYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("GenPercent", SqlDbType.VarChar, 6, this.GenPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaGyne", SqlDbType.Bit, 0, this.McaGyne.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("GyneYear", SqlDbType.VarChar, 4, this.GyneYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("GynePercent", SqlDbType.VarChar, 6, this.GynePercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaHand", SqlDbType.Bit, 0, this.McaHand.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HandYear", SqlDbType.VarChar, 4, this.HandYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HandPercent", SqlDbType.VarChar, 6, this.HandPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaHead", SqlDbType.Bit, 0, this.McaHead.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HeadYear", SqlDbType.VarChar, 4, this.HeadYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("HeadPercent", SqlDbType.VarChar, 6, this.HeadPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaLapa", SqlDbType.Bit, 0, this.McaLapa.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LapaYear", SqlDbType.VarChar, 4, this.LapaYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LapaPercent", SqlDbType.VarChar, 6, this.LapaPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOther", SqlDbType.Bit, 0, this.McaOther.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OtherYear", SqlDbType.VarChar, 4, this.OtherYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OtherPercent", SqlDbType.VarChar, 6, this.OtherPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaLipo", SqlDbType.Bit, 0, this.McaLipo.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LipoYear", SqlDbType.VarChar, 4, this.LipoYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("LipoPercent", SqlDbType.VarChar, 6, this.LipoPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaNeuro", SqlDbType.Bit, 0, this.McaNeuro.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NeuroYear", SqlDbType.VarChar, 4, this.NeuroYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("NeuroPercent", SqlDbType.VarChar, 6, this.NeuroPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaObs", SqlDbType.Bit, 0, this.McaObs.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ObsYear", SqlDbType.VarChar, 4, this.ObsYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ObsPercent", SqlDbType.VarChar, 6, this.ObsPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOph", SqlDbType.Bit, 0, this.McaOph.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OphYear", SqlDbType.VarChar, 4, this.OphYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OphPercent", SqlDbType.VarChar, 6, this.OphPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOrth", SqlDbType.Bit, 0, this.McaOrth.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OrthYear", SqlDbType.VarChar, 4, this.OrthYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OrthPercent", SqlDbType.VarChar, 6, this.OrthPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOrtho", SqlDbType.Bit, 0, this.McaOrtho.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OrthoYear", SqlDbType.VarChar, 4, "", ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OrthoPercent", SqlDbType.VarChar, 6, "", ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaOrthoReplace", SqlDbType.Bit, 0, this.McaOrthoReplace.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OrthoReplaceYear", SqlDbType.VarChar, 4, this.OrthoReplaceYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("OrthoReplacePercent", SqlDbType.VarChar, 6, this.OrthoReplacePercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPlaSurElective", SqlDbType.Bit, 0, this.McaPlaSurElective.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PlaSurElectiveYear", SqlDbType.VarChar, 4, this.PlaSurElectiveYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PlaSurElectivePercent", SqlDbType.VarChar, 6, this.PlaSurElectivePercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaPlaSurOther", SqlDbType.Bit, 0, this.McaPlaSurOther.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PlaSurOtherYear", SqlDbType.VarChar, 4, "", ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PlaSurOtherPercent", SqlDbType.VarChar, 6, "", ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaRefra", SqlDbType.Bit, 0, this.McaRefra.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RefraYear", SqlDbType.VarChar, 4, this.RefraYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("RefraPercent", SqlDbType.VarChar, 6, this.RefraPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaSpinLumbar", SqlDbType.Bit, 0, this.McaSpinLumbar.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("SpinLumbarYear", SqlDbType.VarChar, 4, this.SpinLumbarYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("SpinLumbarPercent", SqlDbType.VarChar, 6, this.SpinLumbarPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaSpinOther", SqlDbType.Bit, 0, this.McaSpinOther.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("SpinOtherYear", SqlDbType.VarChar, 4, this.SpinOtherYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("SpinOtherPercent", SqlDbType.VarChar, 6, this.SpinOtherPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaThora", SqlDbType.Bit, 0, this.McaThora.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ThoraYear", SqlDbType.VarChar, 4, this.ThoraYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ThoraPercent", SqlDbType.VarChar, 6, this.ThoraPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaUro", SqlDbType.Bit, 0, this.McaUro.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("UroYear", SqlDbType.VarChar, 4, this.UroYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("UroPercent", SqlDbType.VarChar, 6, this.UroPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("McaVas", SqlDbType.Bit, 0, this.McaVas.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("VasYear", SqlDbType.VarChar, 4, this.VasYear.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("VasPercent", SqlDbType.VarChar, 6, this.VasPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42a", SqlDbType.Bit, 0, this.Mca42a.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42b", SqlDbType.Bit, 0, this.Mca42b.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42c", SqlDbType.Bit, 0, this.Mca42c.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42d", SqlDbType.Bit, 0, this.Mca42d.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42e", SqlDbType.Bit, 0, this.Mca42e.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42f", SqlDbType.Bit, 0, this.Mca42f.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42g", SqlDbType.VarChar, 4, this.Mca42g.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42h", SqlDbType.Bit, 0, this.Mca42h.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42i", SqlDbType.Bit, 0, this.Mca42i.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42j", SqlDbType.Bit, 0, this.Mca42j.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42k", SqlDbType.Bit, 0, this.Mca42k.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42kDesc", SqlDbType.VarChar, 30, this.Mca42kDesc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42l", SqlDbType.Bit, 0, this.Mca42l.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca42lDesc", SqlDbType.VarChar, 100, this.Mca42lDesc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("43Desc", SqlDbType.VarChar, 200, this.app643Desc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca44", SqlDbType.Bit, 0, this.Mca44.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("44Desc", SqlDbType.VarChar, 100, this.app644Desc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca45", SqlDbType.Bit, 0, this.Mca45.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca46", SqlDbType.Bit, 0, this.Mca46.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca47", SqlDbType.Bit, 0, this.Mca47.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("47Inst", SqlDbType.VarChar, 100, this.app647Inst.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("47Addr", SqlDbType.VarChar, 100, this.app647Addr.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca47b", SqlDbType.Bit, 0, this.Mca47b.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("47bPercent", SqlDbType.VarChar, 6, this.app647bPercent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca48", SqlDbType.Bit, 0, this.Mca48.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("48Ent", SqlDbType.VarChar, 50, this.app648Ent.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("48Addr", SqlDbType.VarChar, 50, this.app648Addr.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca48b", SqlDbType.Bit, 0, this.Mca48b.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca48c", SqlDbType.Bit, 0, this.Mca48c.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca49", SqlDbType.Bit, 0, this.Mca49.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("49Desc", SqlDbType.VarChar, 200, this.app649Desc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca50", SqlDbType.Bit, 0, this.Mca50.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("50Desc", SqlDbType.VarChar, 200, this.app650Desc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca51", SqlDbType.Bit, 0, this.Mca51.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca52", SqlDbType.Bit, 0, this.Mca52.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca53", SqlDbType.Bit, 0, this.Mca53.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca54", SqlDbType.Bit, 0, this.Mca54.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("54b", SqlDbType.VarChar, 4, this.app654b.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("54c", SqlDbType.VarChar, 4, this.app654c.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("54d", SqlDbType.VarChar, 4, this.app654d.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca55", SqlDbType.Bit, 0, this.Mca55.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("55Desc", SqlDbType.VarChar, 50, this.app655Desc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca56", SqlDbType.Bit, 0, this.Mca56.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca56First", SqlDbType.Bit, 0, this.Mca56First.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca56Second", SqlDbType.Bit, 0, this.Mca56Second.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca56Third", SqlDbType.Bit, 0, this.Mca56Third.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Desc56A", SqlDbType.VarChar, 4, this.Desc56A.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Desc56B", SqlDbType.VarChar, 4, this.Desc56B.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Desc56C", SqlDbType.VarChar, 4, this.Desc56C.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca57", SqlDbType.Bit, 0, this.Mca57.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("57DescA", SqlDbType.VarChar, 50, this.app657DescA.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("57DescB", SqlDbType.VarChar, 4, this.app657DescB.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca58", SqlDbType.Bit, 0, this.Mca58.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("58DescA", SqlDbType.VarChar, 100, this.app658DescA.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca59", SqlDbType.Bit, 0, this.Mca59.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca60", SqlDbType.Bit, 0, this.Mca60.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca61", SqlDbType.Bit, 0, this.Mca61.ToString(), ref cookItems);


            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
        }

        private XmlDocument SaveApplication7Xml()
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[19];

            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca62", SqlDbType.Bit, 0, this.Mca62.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca63", SqlDbType.Bit, 0, this.Mca63.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca64", SqlDbType.Bit, 0, this.Mca64.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca65", SqlDbType.Bit, 0, this.Mca65.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca66", SqlDbType.Bit, 0, this.Mca66.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca67", SqlDbType.Bit, 0, this.Mca67.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca68", SqlDbType.Bit, 0, this.Mca68.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca69", SqlDbType.Bit, 0, this.Mca69.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca70", SqlDbType.Bit, 0, this.Mca70.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca71", SqlDbType.Bit, 0, this.Mca71.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca72", SqlDbType.Bit, 0, this.Mca72.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca73", SqlDbType.Bit, 0, this.Mca73.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca73a", SqlDbType.Bit, 0, this.Mca73a.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca73b", SqlDbType.Bit, 0, this.Mca73b.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca73c", SqlDbType.Bit, 0, this.Mca73c.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca73d", SqlDbType.Bit, 0, this.Mca73d.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca73e", SqlDbType.Bit, 0, this.Mca73e.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca73f", SqlDbType.Bit, 0, this.Mca73f.ToString(), ref cookItems);


            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
        }

        private XmlDocument SaveApplication8Xml()
        {
            DbRequestXmlCookRequestItem[] cookItems = new DbRequestXmlCookRequestItem[27];

            DbRequestXmlCooker.AttachCookItem("TaskControlID", SqlDbType.Int, 0, this.TaskControlID.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("PatientName", SqlDbType.VarChar, 75, this.PatientName.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("DateOfIncident", SqlDbType.DateTime, 8, this.DateOfIncident.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("DateReported", SqlDbType.DateTime, 8, this.DateReported.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("InsuranceNameCarrier", SqlDbType.VarChar, 75, this.InsuranceNameCarrier.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Allegation", SqlDbType.VarChar, 500, this.Allegation.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("ConditionPatient", SqlDbType.VarChar, 500, this.ConditionPatient.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca7", SqlDbType.Bit, 0, this.Mca7.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8a", SqlDbType.Bit, 0, this.Mca8a.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8b", SqlDbType.Bit, 0, this.Mca8b.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8c", SqlDbType.Bit, 0, this.Mca8c.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8d", SqlDbType.Bit, 0, this.Mca8d.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8e", SqlDbType.Bit, 0, this.Mca8e.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("8ePayment", SqlDbType.Decimal, 9, this.app88ePayment.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8f", SqlDbType.Bit, 0, this.Mca8f.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("8fDate", SqlDbType.DateTime, 8, this.app88fDate.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("8fPaid", SqlDbType.Decimal, 9, this.app88fPaid.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8fc", SqlDbType.Bit, 0, this.Mca8fc.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8g", SqlDbType.Bit, 0, this.Mca8g.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8h", SqlDbType.Bit, 0, this.Mca8h.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8i", SqlDbType.Bit, 0, this.Mca8i.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8j", SqlDbType.Bit, 0, this.Mca8j.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8k", SqlDbType.Bit, 0, this.Mca8k.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8l", SqlDbType.Bit, 0, this.Mca8l.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8m", SqlDbType.Bit, 0, this.Mca8m.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("Mca8n", SqlDbType.Bit, 0, this.Mca8n.ToString(), ref cookItems);
            DbRequestXmlCooker.AttachCookItem("9Desc", SqlDbType.VarChar, 200, this.app89Desc.ToString(), ref cookItems);



            try
            {
                return DbRequestXmlCooker.Cook(cookItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not cook items.", ex);
            }
        }
        #endregion
    }
}