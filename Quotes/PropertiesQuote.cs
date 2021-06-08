using System;
using System.Data;
using System.Xml;
using Baldrich.DBRequest;
using EPolicy.LookupTables;
using EPolicy;
using EPolicy.XmlCooker;

namespace EPolicy.Quotes
{
    public class PropertiesQuote
    {

        public PropertiesQuote()
        {

        }

        private Building _Building = new Building();
        private Contents _Contents = new Contents();

        public Building Building
        {
            get
            {
                return this._Building;
            }
            set
            {
                this._Building = value;
            }
        }

        public Contents Contents
        {
            get
            {
                return this._Contents;
            }
            set
            {
                this._Contents = value;
            }
        }

        public static PropertiesQuote Calculate(PropertiesQuote propertiesQuote, int TypeConstruction, bool Building, bool Contents)
        {
            switch (TypeConstruction)
            {
                case 1: //Concrete
                    propertiesQuote = Concrete(Building, Contents, propertiesQuote);
                    break;

                case 2: //Masonry
                    propertiesQuote = Masonry(Building, Contents, propertiesQuote);
                    break;

                case 3: //Frame
                    propertiesQuote = Frame(Building, Contents, propertiesQuote);
                    break;
            }

            return propertiesQuote;
        }

        private static PropertiesQuote Concrete(bool Building, bool Contents, PropertiesQuote propertiesQuote)
        {
            if (Building)
            {
                propertiesQuote.Building.RateFire = 0.133;
                propertiesQuote.Building.RateExtCoverage = 1.003;
                propertiesQuote.Building.RateVandalism = 0.340;
                propertiesQuote.Building.RateEarthquake = 1.500;
                propertiesQuote.Building.RateAOP = 0.405;
                propertiesQuote.Building.RateExcessAOP = 0.000;
                propertiesQuote.Building.RateTheft = 0.500;

                propertiesQuote.Building.FactorFire = 0.80;
                propertiesQuote.Building.FactorExtCoverage = 0.80;
                propertiesQuote.Building.FactorVandalism = 0.80;
                propertiesQuote.Building.FactorEarthquake = 0.80;
                propertiesQuote.Building.FactorAOP = 0.80;
                propertiesQuote.Building.FactorExcessAOP = 0.80;
                propertiesQuote.Building.FactorTheft = 0.80;

                propertiesQuote.Building.TotalFire = propertiesQuote.Building.LimitFire * propertiesQuote.Building.RateFire * propertiesQuote.Building.FactorFire /1000;
                propertiesQuote.Building.TotalExtCoverage = propertiesQuote.Building.LimitExtCoverage * propertiesQuote.Building.RateExtCoverage * propertiesQuote.Building.FactorExtCoverage /1000;
                propertiesQuote.Building.TotalVandalism = propertiesQuote.Building.LimitVandalism * propertiesQuote.Building.RateVandalism * propertiesQuote.Building.FactorVandalism /1000;
                propertiesQuote.Building.TotalEarthquake = propertiesQuote.Building.LimitEarthquake * propertiesQuote.Building.RateEarthquake * propertiesQuote.Building.FactorEarthquake /1000;
                propertiesQuote.Building.TotalAOP = propertiesQuote.Building.LimitAOP * propertiesQuote.Building.RateAOP * propertiesQuote.Building.FactorAOP /1000;
                propertiesQuote.Building.TotalExcessAOP = propertiesQuote.Building.LimitExcessAOP * propertiesQuote.Building.RateExcessAOP * propertiesQuote.Building.FactorExcessAOP /1000;
                propertiesQuote.Building.TotalTheft = propertiesQuote.Building.LimitTheft * propertiesQuote.Building.RateTheft * propertiesQuote.Building.FactorTheft / 1000;

                propertiesQuote.Building.PremiumFire = Math.Round(propertiesQuote.Building.TotalFire ,0);
                propertiesQuote.Building.PremiumExtCoverage = Math.Round(propertiesQuote.Building.TotalExtCoverage,0);
                propertiesQuote.Building.PremiumVandalism = Math.Round(propertiesQuote.Building.TotalVandalism,0);
                propertiesQuote.Building.PremiumEarthquake = Math.Round(propertiesQuote.Building.TotalEarthquake,0);
                propertiesQuote.Building.PremiumAOP = Math.Round(propertiesQuote.Building.TotalAOP,0);
                propertiesQuote.Building.PremiumExcessAOP = Math.Round(propertiesQuote.Building.TotalExcessAOP,0);
                propertiesQuote.Building.PremiumTheft = Math.Round(propertiesQuote.Building.TotalTheft,0);

                propertiesQuote.Building.BuildingPremiumTotal = propertiesQuote.Building.PremiumFire +
                                                                propertiesQuote.Building.PremiumExtCoverage + propertiesQuote.Building.PremiumVandalism +
                                                                propertiesQuote.Building.PremiumEarthquake + propertiesQuote.Building.PremiumAOP +
                                                                propertiesQuote.Building.PremiumExcessAOP + propertiesQuote.Building.PremiumTheft;
            }

            if (Contents)
            {
                propertiesQuote.Contents.RateFire = 0.094;
                propertiesQuote.Contents.RateExtCoverage = 1.375;
                propertiesQuote.Contents.RateVandalism = 0.340;
                propertiesQuote.Contents.RateEarthquake = 1.130;
                propertiesQuote.Contents.RateAOP = 0.750;
                propertiesQuote.Contents.RateExcessAOP = 0.000;
                propertiesQuote.Contents.RateTheft = 1.500;

                propertiesQuote.Contents.FactorFire = 0.80;
                propertiesQuote.Contents.FactorExtCoverage = 0.80;
                propertiesQuote.Contents.FactorVandalism = 0.80;
                propertiesQuote.Contents.FactorEarthquake = 0.80;
                propertiesQuote.Contents.FactorAOP = 0.80;
                propertiesQuote.Contents.FactorExcessAOP = 0.80;
                propertiesQuote.Contents.FactorTheft = 0.80;

                propertiesQuote.Contents.TotalFire = propertiesQuote.Contents.LimitFire * propertiesQuote.Contents.RateFire * propertiesQuote.Contents.FactorFire / 1000;
                propertiesQuote.Contents.TotalExtCoverage = propertiesQuote.Contents.LimitExtCoverage * propertiesQuote.Contents.RateExtCoverage * propertiesQuote.Contents.FactorExtCoverage / 1000;
                propertiesQuote.Contents.TotalVandalism = propertiesQuote.Contents.LimitVandalism * propertiesQuote.Contents.RateVandalism * propertiesQuote.Contents.FactorVandalism / 1000;
                propertiesQuote.Contents.TotalEarthquake = propertiesQuote.Contents.LimitEarthquake * propertiesQuote.Contents.RateEarthquake * propertiesQuote.Contents.FactorEarthquake / 1000;
                propertiesQuote.Contents.TotalAOP = propertiesQuote.Contents.LimitAOP * propertiesQuote.Contents.RateAOP * propertiesQuote.Contents.FactorAOP / 1000;
                propertiesQuote.Contents.TotalExcessAOP = propertiesQuote.Contents.LimitExcessAOP * propertiesQuote.Contents.RateExcessAOP * propertiesQuote.Contents.FactorExcessAOP / 1000;
                propertiesQuote.Contents.TotalTheft = propertiesQuote.Contents.LimitTheft * propertiesQuote.Contents.RateTheft * propertiesQuote.Contents.FactorTheft / 1000;

                propertiesQuote.Contents.PremiumFire = Math.Round(propertiesQuote.Contents.TotalFire, 0);
                propertiesQuote.Contents.PremiumExtCoverage = Math.Round(propertiesQuote.Contents.TotalExtCoverage, 0);
                propertiesQuote.Contents.PremiumVandalism = Math.Round(propertiesQuote.Contents.TotalVandalism, 0);
                propertiesQuote.Contents.PremiumEarthquake = Math.Round(propertiesQuote.Contents.TotalEarthquake, 0);
                propertiesQuote.Contents.PremiumAOP = Math.Round(propertiesQuote.Contents.TotalAOP, 0);
                propertiesQuote.Contents.PremiumExcessAOP = Math.Round(propertiesQuote.Contents.TotalExcessAOP, 0);
                propertiesQuote.Contents.PremiumTheft = Math.Round(propertiesQuote.Contents.TotalTheft, 0);

                propertiesQuote.Contents.ContentsPremiumTotal = propertiesQuote.Contents.PremiumFire +
                                                 propertiesQuote.Contents.PremiumExtCoverage + propertiesQuote.Contents.PremiumVandalism +
                                                 propertiesQuote.Contents.PremiumEarthquake + propertiesQuote.Contents.PremiumAOP +
                                                 propertiesQuote.Contents.PremiumExcessAOP + propertiesQuote.Contents.PremiumTheft;
            }
            return propertiesQuote;;
        }

        private static PropertiesQuote Masonry(bool Building, bool Contents, PropertiesQuote propertiesQuote)
        {
            if (Building)
            {
                propertiesQuote.Building.RateFire = 0.284;
                propertiesQuote.Building.RateExtCoverage = 9.195;
                propertiesQuote.Building.RateVandalism = 0.34;
                propertiesQuote.Building.RateEarthquake = 1.50;
                propertiesQuote.Building.RateAOP = 0.865;
                propertiesQuote.Building.RateExcessAOP = 0.000;
                propertiesQuote.Building.RateTheft = 0.500;

                propertiesQuote.Building.FactorFire = 0.80;
                propertiesQuote.Building.FactorExtCoverage = 0.80;
                propertiesQuote.Building.FactorVandalism = 0.80;
                propertiesQuote.Building.FactorEarthquake = 0.80;
                propertiesQuote.Building.FactorAOP = 0.80;
                propertiesQuote.Building.FactorExcessAOP = 0.80;
                propertiesQuote.Building.FactorTheft = 0.80;

                propertiesQuote.Building.TotalFire = propertiesQuote.Building.LimitFire * propertiesQuote.Building.RateFire * propertiesQuote.Building.FactorFire / 1000;
                propertiesQuote.Building.TotalExtCoverage = propertiesQuote.Building.LimitExtCoverage * propertiesQuote.Building.RateExtCoverage * propertiesQuote.Building.FactorExtCoverage / 1000;
                propertiesQuote.Building.TotalVandalism = propertiesQuote.Building.LimitVandalism * propertiesQuote.Building.RateVandalism * propertiesQuote.Building.FactorVandalism / 1000;
                propertiesQuote.Building.TotalEarthquake = propertiesQuote.Building.LimitEarthquake * propertiesQuote.Building.RateEarthquake * propertiesQuote.Building.FactorEarthquake / 1000;
                propertiesQuote.Building.TotalAOP = propertiesQuote.Building.LimitAOP * propertiesQuote.Building.RateAOP * propertiesQuote.Building.FactorAOP / 1000;
                propertiesQuote.Building.TotalExcessAOP = propertiesQuote.Building.LimitExcessAOP * propertiesQuote.Building.RateExcessAOP * propertiesQuote.Building.FactorExcessAOP / 1000;
                propertiesQuote.Building.TotalTheft = propertiesQuote.Building.LimitTheft * propertiesQuote.Building.RateTheft * propertiesQuote.Building.FactorTheft / 1000;

                propertiesQuote.Building.PremiumFire = Math.Round(propertiesQuote.Building.TotalFire, 0);
                propertiesQuote.Building.PremiumExtCoverage = Math.Round(propertiesQuote.Building.TotalExtCoverage, 0);
                propertiesQuote.Building.PremiumVandalism = Math.Round(propertiesQuote.Building.TotalVandalism, 0);
                propertiesQuote.Building.PremiumEarthquake = Math.Round(propertiesQuote.Building.TotalEarthquake, 0);
                propertiesQuote.Building.PremiumAOP = Math.Round(propertiesQuote.Building.TotalAOP, 0);
                propertiesQuote.Building.PremiumExcessAOP = Math.Round(propertiesQuote.Building.TotalExcessAOP, 0);
                propertiesQuote.Building.PremiumTheft = Math.Round(propertiesQuote.Building.TotalTheft, 0);

                propertiesQuote.Building.BuildingPremiumTotal = propertiesQuote.Building.PremiumFire +
                                                         propertiesQuote.Building.PremiumExtCoverage + propertiesQuote.Building.PremiumVandalism +
                                                         propertiesQuote.Building.PremiumEarthquake + propertiesQuote.Building.PremiumAOP +
                                                         propertiesQuote.Building.PremiumExcessAOP + propertiesQuote.Building.PremiumTheft;
            }

            if (Contents)
            {
                propertiesQuote.Contents.RateFire = 0.200;
                propertiesQuote.Contents.RateExtCoverage = 9.933;
                propertiesQuote.Contents.RateVandalism = 0.340;
                propertiesQuote.Contents.RateEarthquake = 1.130;
                propertiesQuote.Contents.RateAOP = 0.750;
                propertiesQuote.Contents.RateExcessAOP = 0.000;
                propertiesQuote.Contents.RateTheft = 1.500;

                propertiesQuote.Contents.FactorFire = 0.80;
                propertiesQuote.Contents.FactorExtCoverage = 0.80;
                propertiesQuote.Contents.FactorVandalism = 0.80;
                propertiesQuote.Contents.FactorEarthquake = 0.80;
                propertiesQuote.Contents.FactorAOP = 0.80;
                propertiesQuote.Contents.FactorExcessAOP = 0.80;
                propertiesQuote.Contents.FactorTheft = 0.80;

                propertiesQuote.Contents.TotalFire = propertiesQuote.Contents.LimitFire * propertiesQuote.Contents.RateFire * propertiesQuote.Contents.FactorFire / 1000;
                propertiesQuote.Contents.TotalExtCoverage = propertiesQuote.Contents.LimitExtCoverage * propertiesQuote.Contents.RateExtCoverage * propertiesQuote.Contents.FactorExtCoverage / 1000;
                propertiesQuote.Contents.TotalVandalism = propertiesQuote.Contents.LimitVandalism * propertiesQuote.Contents.RateVandalism * propertiesQuote.Contents.FactorVandalism / 1000;
                propertiesQuote.Contents.TotalEarthquake = propertiesQuote.Contents.LimitEarthquake * propertiesQuote.Contents.RateEarthquake * propertiesQuote.Contents.FactorEarthquake / 1000;
                propertiesQuote.Contents.TotalAOP = propertiesQuote.Contents.LimitAOP * propertiesQuote.Contents.RateAOP * propertiesQuote.Contents.FactorAOP / 1000;
                propertiesQuote.Contents.TotalExcessAOP = propertiesQuote.Contents.LimitExcessAOP * propertiesQuote.Contents.RateExcessAOP * propertiesQuote.Contents.FactorExcessAOP / 1000;
                propertiesQuote.Contents.TotalTheft = propertiesQuote.Contents.LimitTheft * propertiesQuote.Contents.RateTheft * propertiesQuote.Contents.FactorTheft / 1000;

                propertiesQuote.Contents.PremiumFire = Math.Round(propertiesQuote.Contents.TotalFire, 0);
                propertiesQuote.Contents.PremiumExtCoverage = Math.Round(propertiesQuote.Contents.TotalExtCoverage, 0);
                propertiesQuote.Contents.PremiumVandalism = Math.Round(propertiesQuote.Contents.TotalVandalism, 0);
                propertiesQuote.Contents.PremiumEarthquake = Math.Round(propertiesQuote.Contents.TotalEarthquake, 0);
                propertiesQuote.Contents.PremiumAOP = Math.Round(propertiesQuote.Contents.TotalAOP, 0);
                propertiesQuote.Contents.PremiumExcessAOP = Math.Round(propertiesQuote.Contents.TotalExcessAOP, 0);
                propertiesQuote.Contents.PremiumTheft = Math.Round(propertiesQuote.Contents.TotalTheft, 0);

                propertiesQuote.Contents.ContentsPremiumTotal = propertiesQuote.Contents.PremiumFire +
                                  propertiesQuote.Contents.PremiumExtCoverage + propertiesQuote.Contents.PremiumVandalism +
                                  propertiesQuote.Contents.PremiumEarthquake + propertiesQuote.Contents.PremiumAOP +
                                  propertiesQuote.Contents.PremiumExcessAOP + propertiesQuote.Contents.PremiumTheft;
            }
            return propertiesQuote; ;
        }

        private static PropertiesQuote Frame(bool Building, bool Contents, PropertiesQuote propertiesQuote)
        {
            if (Building)
            {
                propertiesQuote.Building.RateFire = 0.710;
                propertiesQuote.Building.RateExtCoverage = 20.23;
                propertiesQuote.Building.RateVandalism = 0.34;
                propertiesQuote.Building.RateEarthquake = 1.500;
                propertiesQuote.Building.RateAOP = 0.865;
                propertiesQuote.Building.RateExcessAOP = 0.000;
                propertiesQuote.Building.RateTheft = 0.500;

                propertiesQuote.Building.FactorFire = 0.80;
                propertiesQuote.Building.FactorExtCoverage = 0.80;
                propertiesQuote.Building.FactorVandalism = 0.80;
                propertiesQuote.Building.FactorEarthquake = 0.80;
                propertiesQuote.Building.FactorAOP = 0.80;
                propertiesQuote.Building.FactorExcessAOP = 0.80;
                propertiesQuote.Building.FactorTheft = 0.80;

                propertiesQuote.Building.TotalFire = propertiesQuote.Building.LimitFire * propertiesQuote.Building.RateFire * propertiesQuote.Building.FactorFire / 1000;
                propertiesQuote.Building.TotalExtCoverage = propertiesQuote.Building.LimitExtCoverage * propertiesQuote.Building.RateExtCoverage * propertiesQuote.Building.FactorExtCoverage / 1000;
                propertiesQuote.Building.TotalVandalism = propertiesQuote.Building.LimitVandalism * propertiesQuote.Building.RateVandalism * propertiesQuote.Building.FactorVandalism / 1000;
                propertiesQuote.Building.TotalEarthquake = propertiesQuote.Building.LimitEarthquake * propertiesQuote.Building.RateEarthquake * propertiesQuote.Building.FactorEarthquake / 1000;
                propertiesQuote.Building.TotalAOP = propertiesQuote.Building.LimitAOP * propertiesQuote.Building.RateAOP * propertiesQuote.Building.FactorAOP / 1000;
                propertiesQuote.Building.TotalExcessAOP = propertiesQuote.Building.LimitExcessAOP * propertiesQuote.Building.RateExcessAOP * propertiesQuote.Building.FactorExcessAOP / 1000;
                propertiesQuote.Building.TotalTheft = propertiesQuote.Building.LimitTheft * propertiesQuote.Building.RateTheft * propertiesQuote.Building.FactorTheft / 1000;

                propertiesQuote.Building.PremiumFire = Math.Round(propertiesQuote.Building.TotalFire, 0);
                propertiesQuote.Building.PremiumExtCoverage = Math.Round(propertiesQuote.Building.TotalExtCoverage, 0);
                propertiesQuote.Building.PremiumVandalism = Math.Round(propertiesQuote.Building.TotalVandalism, 0);
                propertiesQuote.Building.PremiumEarthquake = Math.Round(propertiesQuote.Building.TotalEarthquake, 0);
                propertiesQuote.Building.PremiumAOP = Math.Round(propertiesQuote.Building.TotalAOP, 0);
                propertiesQuote.Building.PremiumExcessAOP = Math.Round(propertiesQuote.Building.TotalExcessAOP, 0);
                propertiesQuote.Building.PremiumTheft = Math.Round(propertiesQuote.Building.TotalTheft, 0);

                propertiesQuote.Building.BuildingPremiumTotal = propertiesQuote.Building.PremiumFire +
                                         propertiesQuote.Building.PremiumExtCoverage + propertiesQuote.Building.PremiumVandalism +
                                         propertiesQuote.Building.PremiumEarthquake + propertiesQuote.Building.PremiumAOP +
                                         propertiesQuote.Building.PremiumExcessAOP + propertiesQuote.Building.PremiumTheft;            
            }

            if (Contents)
            {
                propertiesQuote.Contents.RateFire = 0.499;
                propertiesQuote.Contents.RateExtCoverage = 21.521;
                propertiesQuote.Contents.RateVandalism = 0.34;
                propertiesQuote.Contents.RateEarthquake = 1.130;
                propertiesQuote.Contents.RateAOP = 0.750;
                propertiesQuote.Contents.RateExcessAOP = 0.000;
                propertiesQuote.Contents.RateTheft = 1.500;

                propertiesQuote.Contents.FactorFire = 0.80;
                propertiesQuote.Contents.FactorExtCoverage = 0.80;
                propertiesQuote.Contents.FactorVandalism = 0.80;
                propertiesQuote.Contents.FactorEarthquake = 0.80;
                propertiesQuote.Contents.FactorAOP = 0.80;
                propertiesQuote.Contents.FactorExcessAOP = 0.80;
                propertiesQuote.Contents.FactorTheft = 0.80;

                propertiesQuote.Contents.TotalFire = propertiesQuote.Contents.LimitFire * propertiesQuote.Contents.RateFire * propertiesQuote.Contents.FactorFire / 1000;
                propertiesQuote.Contents.TotalExtCoverage = propertiesQuote.Contents.LimitExtCoverage * propertiesQuote.Contents.RateExtCoverage * propertiesQuote.Contents.FactorExtCoverage / 1000;
                propertiesQuote.Contents.TotalVandalism = propertiesQuote.Contents.LimitVandalism * propertiesQuote.Contents.RateVandalism * propertiesQuote.Contents.FactorVandalism / 1000;
                propertiesQuote.Contents.TotalEarthquake = propertiesQuote.Contents.LimitEarthquake * propertiesQuote.Contents.RateEarthquake * propertiesQuote.Contents.FactorEarthquake / 1000;
                propertiesQuote.Contents.TotalAOP = propertiesQuote.Contents.LimitAOP * propertiesQuote.Contents.RateAOP * propertiesQuote.Contents.FactorAOP / 1000;
                propertiesQuote.Contents.TotalExcessAOP = propertiesQuote.Contents.LimitExcessAOP * propertiesQuote.Contents.RateExcessAOP * propertiesQuote.Contents.FactorExcessAOP / 1000;
                propertiesQuote.Contents.TotalTheft = propertiesQuote.Contents.LimitTheft * propertiesQuote.Contents.RateTheft * propertiesQuote.Contents.FactorTheft / 1000;

                propertiesQuote.Contents.PremiumFire = Math.Round(propertiesQuote.Contents.TotalFire, 0);
                propertiesQuote.Contents.PremiumExtCoverage = Math.Round(propertiesQuote.Contents.TotalExtCoverage, 0);
                propertiesQuote.Contents.PremiumVandalism = Math.Round(propertiesQuote.Contents.TotalVandalism, 0);
                propertiesQuote.Contents.PremiumEarthquake = Math.Round(propertiesQuote.Contents.TotalEarthquake, 0);
                propertiesQuote.Contents.PremiumAOP = Math.Round(propertiesQuote.Contents.TotalAOP, 0);
                propertiesQuote.Contents.PremiumExcessAOP = Math.Round(propertiesQuote.Contents.TotalExcessAOP, 0);
                propertiesQuote.Contents.PremiumTheft = Math.Round(propertiesQuote.Contents.TotalTheft, 0);

                propertiesQuote.Contents.ContentsPremiumTotal = propertiesQuote.Contents.PremiumFire +
                      propertiesQuote.Contents.PremiumExtCoverage + propertiesQuote.Contents.PremiumVandalism +
                      propertiesQuote.Contents.PremiumEarthquake + propertiesQuote.Contents.PremiumAOP +
                      propertiesQuote.Contents.PremiumExcessAOP + propertiesQuote.Contents.PremiumTheft;
            }
            return propertiesQuote; ;
        }
    }

    public class Building
    {
        public Building()
        {

        }

        #region Private Variable
        private double _LimitFire = 0.00;
        private double _LimitExtCoverage = 0.00;
        private double _LimitVandalism = 0.00;
        private double _LimitEarthquake = 0.00;
        private double _LimitAOP = 0.00;
        private double _LimitExcessAOP = 0.00;
        private double _LimitTheft = 0.00;

        private double _RateFire = 0.00;
        private double _RateExtCoverage = 0.00;
        private double _RateVandalism = 0.00;
        private double _RateEarthquake = 0.00;
        private double _RateAOP = 0.00;
        private double _RateExcessAOP = 0.00;
        private double _RateTheft = 0.00;

        private double _FactorFire = 0.00;
        private double _FactorExtCoverage = 0.00;
        private double _FactorVandalism = 0.00;
        private double _FactorEarthquake = 0.00;
        private double _FactorAOP = 0.00;
        private double _FactorExcessAOP = 0.00;
        private double _FactorTheft = 0.00;

        private double _TotalFire = 0.00;
        private double _TotalExtCoverage = 0.00;
        private double _TotalVandalism = 0.00;
        private double _TotalEarthquake = 0.00;
        private double _TotalAOP = 0.00;
        private double _TotalExcessAOP = 0.00;
        private double _TotalTheft = 0.00;

        private double _PremiumFire = 0.00;
        private double _PremiumExtCoverage = 0.00;
        private double _PremiumVandalism = 0.00;
        private double _PremiumEarthquake = 0.00;
        private double _PremiumAOP = 0.00;
        private double _PremiumExcessAOP = 0.00;
        private double _PremiumTheft = 0.00;

        private double _BuildingPremiumTotal = 0.00;
        #endregion

        #region Properties
        public double LimitFire
        {
            get
            {
                return this._LimitFire;
            }
            set
            {
                this._LimitFire = value;
            }
        }
        public double LimitExtCoverage
        {
            get
            {
                return this._LimitExtCoverage;
            }
            set
            {
                this._LimitExtCoverage = value;
            }
        }
        public double LimitVandalism
        {
            get
            {
                return this._LimitVandalism;
            }
            set
            {
                this._LimitVandalism = value;
            }
        }
        public double LimitEarthquake
        {
            get
            {
                return this._LimitEarthquake;
            }
            set
            {
                this._LimitEarthquake = value;
            }
        }
        public double LimitAOP
        {
            get
            {
                return this._LimitAOP;
            }
            set
            {
                this._LimitAOP = value;
            }
        }
        public double LimitExcessAOP
        {
            get
            {
                return this._LimitExcessAOP;
            }
            set
            {
                this._LimitExcessAOP = value;
            }
        }
        public double LimitTheft
        {
            get
            {
                return this._LimitTheft;
            }
            set
            {
                this._LimitTheft = value;
            }
        }
        
        public double RateFire
        {
            get
            {
                return this._RateFire;
            }
            set
            {
                this._RateFire = value;
            }
        }
        public double RateExtCoverage
        {
            get
            {
                return this._RateExtCoverage;
            }
            set
            {
                this._RateExtCoverage = value;
            }
        }
        public double RateVandalism
        {
            get
            {
                return this._RateVandalism;
            }
            set
            {
                this._RateVandalism = value;
            }
        }
        public double RateEarthquake
        {
            get
            {
                return this._RateEarthquake;
            }
            set
            {
                this._RateEarthquake = value;
            }
        }
        public double RateAOP
        {
            get
            {
                return this._RateAOP;
            }
            set
            {
                this._RateAOP = value;
            }
        }
        public double RateExcessAOP
        {
            get
            {
                return this._RateExcessAOP;
            }
            set
            {
                this._RateExcessAOP = value;
            }
        }
        public double RateTheft
        {
            get
            {
                return this._RateTheft;
            }
            set
            {
                this._RateTheft = value;
            }
        }

        public double FactorFire
        {
            get
            {
                return this._FactorFire;
            }
            set
            {
                this._FactorFire = value;
            }
        }
        public double FactorExtCoverage
        {
            get
            {
                return this._FactorExtCoverage;
            }
            set
            {
                this._FactorExtCoverage = value;
            }
        }
        public double FactorVandalism
        {
            get
            {
                return this._FactorVandalism;
            }
            set
            {
                this._FactorVandalism = value;
            }
        }
        public double FactorEarthquake
        {
            get
            {
                return this._FactorEarthquake;
            }
            set
            {
                this._FactorEarthquake = value;
            }
        }
        public double FactorAOP
        {
            get
            {
                return this._FactorAOP;
            }
            set
            {
                this._FactorAOP = value;
            }
        }
        public double FactorExcessAOP
        {
            get
            {
                return this._FactorExcessAOP;
            }
            set
            {
                this._FactorExcessAOP = value;
            }
        }
        public double FactorTheft
        {
            get
            {
                return this._FactorTheft;
            }
            set
            {
                this._FactorTheft = value;
            }
        }

        public double TotalFire
        {
            get
            {
                return this._TotalFire;
            }
            set
            {
                this._TotalFire = value;
            }
        }
        public double TotalExtCoverage
        {
            get
            {
                return this._TotalExtCoverage;
            }
            set
            {
                this._TotalExtCoverage = value;
            }
        }
        public double TotalVandalism
        {
            get
            {
                return this._TotalVandalism;
            }
            set
            {
                this._TotalVandalism = value;
            }
        }
        public double TotalEarthquake
        {
            get
            {
                return this._TotalEarthquake;
            }
            set
            {
                this._TotalEarthquake = value;
            }
        }

        public double TotalAOP
        {
            get
            {
                return this._TotalAOP;
            }
            set
            {
                this._TotalAOP = value;
            }
        }

        public double TotalExcessAOP
        {
            get
            {
                return this._TotalExcessAOP;
            }
            set
            {
                this._TotalExcessAOP = value;
            }
        }
        public double TotalTheft
        {
            get
            {
                return this._TotalTheft;
            }
            set
            {
                this._TotalTheft = value;
            }
        }

        public double PremiumFire
        {
            get
            {
                return this._PremiumFire;
            }
            set
            {
                this._PremiumFire = value;
            }
        }

        public double PremiumExtCoverage
        {
            get
            {
                return this._PremiumExtCoverage;
            }
            set
            {
                this._PremiumExtCoverage = value;
            }
        }
        public double PremiumVandalism
        {
            get
            {
                return this._PremiumVandalism;
            }
            set
            {
                this._PremiumVandalism = value;
            }
        }
        public double PremiumEarthquake
        {
            get
            {
                return this._PremiumEarthquake;
            }
            set
            {
                this._PremiumEarthquake = value;
            }
        }
        public double PremiumAOP
        {
            get
            {
                return this._PremiumAOP;
            }
            set
            {
                this._PremiumAOP = value;
            }
        }


        public double PremiumExcessAOP
        {
            get
            {
                return this._PremiumExcessAOP;
            }
            set
            {
                this._PremiumExcessAOP = value;
            }
        }

        public double PremiumTheft
        {
            get
            {
                return this._PremiumTheft;
            }
            set
            {
                this._PremiumTheft = value;
            }
        }

        public double BuildingPremiumTotal
        {
            get
            {
                return this._BuildingPremiumTotal;
            }
            set
            {
                this._BuildingPremiumTotal = value;
            }
        }

        #endregion
    }

    public class Contents
    {
        public Contents()
        {

        }

        #region Private Variable
        private double _LimitFire = 0.00;
        private double _LimitExtCoverage = 0.00;
        private double _LimitVandalism = 0.00;
        private double _LimitEarthquake = 0.00;
        private double _LimitAOP = 0.00;
        private double _LimitExcessAOP = 0.00;
        private double _LimitTheft = 0.00;

        private double _RateFire = 0.00;
        private double _RateExtCoverage = 0.00;
        private double _RateVandalism = 0.00;
        private double _RateEarthquake = 0.00;
        private double _RateAOP = 0.00;
        private double _RateExcessAOP = 0.00;
        private double _RateTheft = 0.00;

        private double _FactorFire = 0.00;
        private double _FactorExtCoverage = 0.00;
        private double _FactorVandalism = 0.00;
        private double _FactorEarthquake = 0.00;
        private double _FactorAOP = 0.00;
        private double _FactorExcessAOP = 0.00;
        private double _FactorTheft = 0.00;

        private double _TotalFire = 0.00;
        private double _TotalExtCoverage = 0.00;
        private double _TotalVandalism = 0.00;
        private double _TotalEarthquake = 0.00;
        private double _TotalAOP = 0.00;
        private double _TotalExcessAOP = 0.00;
        private double _TotalTheft = 0.00;

        private double _PremiumFire = 0.00;
        private double _PremiumExtCoverage = 0.00;
        private double _PremiumVandalism = 0.00;
        private double _PremiumEarthquake = 0.00;
        private double _PremiumAOP = 0.00;
        private double _PremiumExcessAOP = 0.00;
        private double _PremiumTheft = 0.00;

        private double _ContentsPremiumTotal = 0.00;
        #endregion

        #region Properties
        public double LimitFire
        {
            get
            {
                return this._LimitFire;
            }
            set
            {
                this._LimitFire = value;
            }
        }
        public double LimitExtCoverage
        {
            get
            {
                return this._LimitExtCoverage;
            }
            set
            {
                this._LimitExtCoverage = value;
            }
        }
        public double LimitVandalism
        {
            get
            {
                return this._LimitVandalism;
            }
            set
            {
                this._LimitVandalism = value;
            }
        }
        public double LimitEarthquake
        {
            get
            {
                return this._LimitEarthquake;
            }
            set
            {
                this._LimitEarthquake = value;
            }
        }
        public double LimitAOP
        {
            get
            {
                return this._LimitAOP;
            }
            set
            {
                this._LimitAOP = value;
            }
        }
        public double LimitExcessAOP
        {
            get
            {
                return this._LimitExcessAOP;
            }
            set
            {
                this._LimitExcessAOP = value;
            }
        }
        public double LimitTheft
        {
            get
            {
                return this._LimitTheft;
            }
            set
            {
                this._LimitTheft = value;
            }
        }

        public double RateFire
        {
            get
            {
                return this._RateFire;
            }
            set
            {
                this._RateFire = value;
            }
        }
        public double RateExtCoverage
        {
            get
            {
                return this._RateExtCoverage;
            }
            set
            {
                this._RateExtCoverage = value;
            }
        }
        public double RateVandalism
        {
            get
            {
                return this._RateVandalism;
            }
            set
            {
                this._RateVandalism = value;
            }
        }
        public double RateEarthquake
        {
            get
            {
                return this._RateEarthquake;
            }
            set
            {
                this._RateEarthquake = value;
            }
        }
        public double RateAOP
        {
            get
            {
                return this._RateAOP;
            }
            set
            {
                this._RateAOP = value;
            }
        }
        public double RateExcessAOP
        {
            get
            {
                return this._RateExcessAOP;
            }
            set
            {
                this._RateExcessAOP = value;
            }
        }
        public double RateTheft
        {
            get
            {
                return this._RateTheft;
            }
            set
            {
                this._RateTheft = value;
            }
        }

        public double FactorFire
        {
            get
            {
                return this._FactorFire;
            }
            set
            {
                this._FactorFire = value;
            }
        }
        public double FactorExtCoverage
        {
            get
            {
                return this._FactorExtCoverage;
            }
            set
            {
                this._FactorExtCoverage = value;
            }
        }
        public double FactorVandalism
        {
            get
            {
                return this._FactorVandalism;
            }
            set
            {
                this._FactorVandalism = value;
            }
        }
        public double FactorEarthquake
        {
            get
            {
                return this._FactorEarthquake;
            }
            set
            {
                this._FactorEarthquake = value;
            }
        }
        public double FactorAOP
        {
            get
            {
                return this._FactorAOP;
            }
            set
            {
                this._FactorAOP = value;
            }
        }
        public double FactorExcessAOP
        {
            get
            {
                return this._FactorExcessAOP;
            }
            set
            {
                this._FactorExcessAOP = value;
            }
        }
        public double FactorTheft
        {
            get
            {
                return this._FactorTheft;
            }
            set
            {
                this._FactorTheft = value;
            }
        }

        public double TotalFire
        {
            get
            {
                return this._TotalFire;
            }
            set
            {
                this._TotalFire = value;
            }
        }
        public double TotalExtCoverage
        {
            get
            {
                return this._TotalExtCoverage;
            }
            set
            {
                this._TotalExtCoverage = value;
            }
        }
        public double TotalVandalism
        {
            get
            {
                return this._TotalVandalism;
            }
            set
            {
                this._TotalVandalism = value;
            }
        }
        public double TotalEarthquake
        {
            get
            {
                return this._TotalEarthquake;
            }
            set
            {
                this._TotalEarthquake = value;
            }
        }

        public double TotalAOP
        {
            get
            {
                return this._TotalAOP;
            }
            set
            {
                this._TotalAOP = value;
            }
        }

        public double TotalExcessAOP
        {
            get
            {
                return this._TotalExcessAOP;
            }
            set
            {
                this._TotalExcessAOP = value;
            }
        }
        public double TotalTheft
        {
            get
            {
                return this._TotalTheft;
            }
            set
            {
                this._TotalTheft = value;
            }
        }

        public double PremiumFire
        {
            get
            {
                return this._PremiumFire;
            }
            set
            {
                this._PremiumFire = value;
            }
        }

        public double PremiumExtCoverage
        {
            get
            {
                return this._PremiumExtCoverage;
            }
            set
            {
                this._PremiumExtCoverage = value;
            }
        }
        public double PremiumVandalism
        {
            get
            {
                return this._PremiumVandalism;
            }
            set
            {
                this._PremiumVandalism = value;
            }
        }
        public double PremiumEarthquake
        {
            get
            {
                return this._PremiumEarthquake;
            }
            set
            {
                this._PremiumEarthquake = value;
            }
        }
        public double PremiumAOP
        {
            get
            {
                return this._PremiumAOP;
            }
            set
            {
                this._PremiumAOP = value;
            }
        }


        public double PremiumExcessAOP
        {
            get
            {
                return this._PremiumExcessAOP;
            }
            set
            {
                this._PremiumExcessAOP = value;
            }
        }

        public double PremiumTheft
        {
            get
            {
                return this._PremiumTheft;
            }
            set
            {
                this._PremiumTheft = value;
            }
        }

        public double ContentsPremiumTotal
        {
            get
            {
                return this._ContentsPremiumTotal;
            }
            set
            {
                this._ContentsPremiumTotal = value;
            }
        }

        #endregion
    }
}