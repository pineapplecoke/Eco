using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Eco_Group25_EE1
{
    public class Report
    {

        private double[] volumes;
        private List<double[]> impacts;
        private string impact_factor_string;
        private string life_cycle_string; 


        public Report(double[] volumes)
        {
            // volumes[0] = wood, volumes[1] = concrete, volumes [2] = masonry 
            this.volumes = volumes;
            calculate_impact();
        }


        private void calculate_impact()
        {
            double[] wood_production = new double[] { -721.7380669, 1.99442E-12, 0.063992885, 0.449130758, 0.10023566, 3.85579E-05, 1001.328163 };
            double[] wood_transport = new double[] { 0.511084087, 8.508E-17, -0.000900541, 0.002141408, 0.000538709, 4.30356E-08, 7.054757672 };
            double[] wood_wastemanagement = new double[] { 809.7131962, 1.7597E-13, 0.000414745, 0.005878334, 0.001048274, 1.75259E-06, 42.29846698 };
            double[] wood_recyclingpotential = new double[] { -351.3820868, -1.2165E-11, -0.027897229, -0.355588148, -0.059340978, -0.000117641, -3915.612859 };

            double[] concrete_production = new double[] { 178, 4.79E-08, 0.0205, 0.261, 0.0498, 0.000608, 819};
            double[] concrete_transport = new double[] { 12, 2.37E-12, -0.0111, 0.0321, 0.00765, 0.00000128, 163};
            double[] concrete_wastemanagement = new double[] { 6.01, 1.31E-11, 0.000974, 0.0113, 0.00217, 0.00000197, 68.4 };
            double[] concrete_recyclingpotential = new double[] { -21.4, -1.32E-10, -0.00279, -0.0473, -0.00886, -0.0000086, -227 };

            double[] masonry_production = new double[] { 138.2938984, 1.45979E-09, 0.013187712, 0.196731704, 0.02120938, 7.12917E-06, 1219.76061, 261.3715453 };
            double[] masonry_transport = new double[] {3.20918444, 1.53184E-11, -0.007411352, 0.018855302, 0.004462931, 1.20583E-07, 44.14338723, 1.739581676};
            double[] masonry_wastemanagement = new double[] {-10.05764823, 1.94949E-11, 0.001470907, 0.010599584, 0.00243115,  2.23795E-06, 27.38734284, 1.560225767};
            double[] masonry_recyclingpotential = new double[] {-7.026694122, -1.91725E-10, 0.003150803, -0.019567719, -0.003836749, -7.13594E-07, -92.51437911, -9.522538079};

            List<double[]> wood = new List<double[]> { wood_production, wood_transport, wood_wastemanagement, wood_recyclingpotential };
            List<double[]> concrete = new List<double[]> { concrete_production, concrete_transport, concrete_wastemanagement, concrete_recyclingpotential };
            List<double[]> masonry = new List<double[]> { masonry_production, masonry_transport, masonry_wastemanagement, masonry_recyclingpotential };

            List<double[]> impacts = new List<double[]>();

            List<double[]> wood_calc = new List<double[]>();
            List<double[]> concrete_calc = new List<double[]>();
            List<double[]> masonry_calc = new List<double[]>();

            foreach (double[] x in wood)
            {

                double[] z =  x.Select(y => y * volumes[0]).ToArray();
                wood_calc.Add(z); 
            }

            foreach (double[] x in concrete)
            {

                double[] z = x.Select(y => y * volumes[1]).ToArray();
                concrete_calc.Add(z);
            }

            foreach (double[] x in masonry)
            {

                double[] z = x.Select(y => y * volumes[2]).ToArray();
                masonry_calc.Add(z);
            }


            double[] production_1 = wood_calc[0].Zip(concrete_calc[0], (a, b) => a + b).ToArray();
            double[] production_impact = production_1.Zip(masonry_calc[0], (a, b) => a + b).ToArray();

            impacts.Add(production_impact);


            double[] transport_1 = wood_calc[1].Zip(concrete_calc[1], (a, b) => a + b).ToArray();
            double[] transport_impact = transport_1.Zip(masonry_calc[1], (a, b) => a + b).ToArray();

            impacts.Add(transport_impact);

            double[] wastemanagement_1 = wood_calc[2].Zip(concrete_calc[2], (a, b) => a + b).ToArray();
            double[] wastemanagement_impact = wastemanagement_1.Zip(masonry_calc[2], (a, b) => a + b).ToArray();

            impacts.Add(wastemanagement_impact);

            double[] recyclingpotential_1 = wood_calc[3].Zip(concrete_calc[3], (a, b) => a + b).ToArray();
            double[] recyclingpotential_impact = recyclingpotential_1.Zip(masonry_calc[3], (a, b) => a + b).ToArray();

            impacts.Add(recyclingpotential_impact);


            this.impacts = impacts;

        }

        public List<double[]> get_impacts()
        {
            
            return this.impacts;

        }

        public string impact_factor_to_string(string impact_factor)
        {

            switch (impact_factor)
            {
                case "GWP":
                    string impact_factor_gwp = "Production: " + this.impacts[0][0] + " kg CO2-Äqv.\n\nTransport: " + this.impacts[1][0] + " kg CO2-Äqv.\n\nWastemanagement: " + this.impacts[2][0] + " kg CO2-Äqv.\n\nRecyclingpotential: " + this.impacts[3][0] + " kg CO2-Äqv.";
                    this.impact_factor_string = impact_factor_gwp;
                    break;

                case "ODP":
                    string impact_factor_odp = "Production: " + this.impacts[0][1] + " kg R11-Äqv.\n\nTransport: " + this.impacts[1][1] + " kg R11-Äqv.\n\nWastemanagement: " + this.impacts[2][1] + " kg R11-Äqv.\n\nRecyclingpotential: " + this.impacts[3][1] + " kg R11-Äqv.";
                    this.impact_factor_string = impact_factor_odp;
                    break;

                case "POCP":
                    string impact_factor_pocp = "Production: " + this.impacts[0][2] + " kg Ethen-Äqv.\n\nTransport: " + this.impacts[1][2] + " kg Ethen-Äqv.\n\nWastemanagement: " + this.impacts[2][2] + " kg Ethen-Äqv.\n\nRecyclingpotential: " + this.impacts[3][2] + " kg Ethen-Äqv.";
                    this.impact_factor_string = impact_factor_pocp;
                    break;

                case "AP":
                    string impact_factor_ap = "Production: " + this.impacts[0][3] + " kg SO2-Äqv.\n\nTransport: " + this.impacts[1][3] + " kg SO2-Äqv.\n\nWastemanagement: " + this.impacts[2][3] + "	kg SO2-Äqv.\n\nRecyclingpotential: " + this.impacts[3][3] + " kg SO2-Äqv.";
                    this.impact_factor_string = impact_factor_ap;
                    break;

                case "EP":
                    string impact_factor_ep = "Production: " + this.impacts[0][4] + " kg Phosphat-Äqv.\n\nTransport: " + this.impacts[1][4] + " kg Phosphat-Äqv.\n\nWastemanagement: " + this.impacts[2][4] + " kg Phosphat-Äqv.\n\nRecyclingpotential: " + this.impacts[3][4] + " kg Phosphat-Äqv.";
                    this.impact_factor_string = impact_factor_ep;
                    break;

                case "ADPE":
                    string impact_factor_adpe = "Production: " + this.impacts[0][5] + " kg Sb-Äqv.\n\nTransport: " + this.impacts[1][5] + " kg Sb-Äqv.\n\nWastemanagement: " + this.impacts[2][5] + " kg Sb-Äqv.\n\nRecyclingpotential: " + this.impacts[3][5] + " kg Sb-Äqv.";
                    this.impact_factor_string = impact_factor_adpe;
                    break;

                case "ADPF":
                    string impact_factor_adpf = "Production: " + this.impacts[0][6] + " MJ\n\nTransport: " + this.impacts[1][6] + "	MJ\n\nWastemanagement: " + this.impacts[2][6] + "	MJ\n\nRecyclingpotential: " + this.impacts[3][6] + " MJ";
                    this.impact_factor_string = impact_factor_adpf;
                    break;
            }

            return this.impact_factor_string;

            
        }
        public string life_cycle_to_string(string life_cycle)
        {
            switch (life_cycle)
            {
                case "Production":
                    string production = "GWP: " + this.impacts[0][0] + " kg CO2-Äqv.\n\nODP: " + this.impacts[0][1] + " kg R11-Äqv.\n\nPOCP: " + this.impacts[0][2] + " kg Ethen-Äqv.\n\nAP: " + this.impacts[0][3] + " kg SO2-Äqv.\n\nEP: " + this.impacts[0][4] + " kg Phosphat-Äqv.\n\nADPE: " + this.impacts[0][5] + " kg Sb-Äqv.\n\nADPF: " + this.impacts[0][6]+ " MJ";
                    this.life_cycle_string = production; 
                    break;
                case "Transport":
                    string transport = "GWP: " + this.impacts[1][0] + " kg CO2-Äqv.\n\nODP: " + this.impacts[1][1] + " kg R11-Äqv.\n\nPOCP: " + this.impacts[1][2] + " kg Ethen-Äqv.\n\nAP: " + this.impacts[1][3] + " kg SO2-Äqv.\n\nEP: " + this.impacts[1][4] + " kg Phosphat-Äqv.\n\nADPE: " + this.impacts[1][5] + " kg Sb-Äqv.\n\nADPF: " + this.impacts[1][6] + " MJ";
                    this.life_cycle_string = transport;
                    break;
                case "Wastemanagement":
                    string wastemanagement = "GWP: " + this.impacts[2][0] + " kg CO2-Äqv.\n\nODP: " + this.impacts[2][1] + " kg R11-Äqv.\n\nPOCP: " + this.impacts[2][2] + " kg Ethen-Äqv.\n\nAP: " + this.impacts[2][3] + " kg SO2-Äqv.\n\nEP: " + this.impacts[2][4] + " kg Phosphat-Äqv.\n\nADPE: " + this.impacts[2][5] + " kg Sb-Äqv.\n\nADPF: " + this.impacts[2][6] + " MJ";
                    this.life_cycle_string = wastemanagement;
                    break;
                case "Recyclingpotential":
                    string recyclingpotential = "GWP: " + this.impacts[3][0] + " kg CO2-Äqv.\n\nODP: " + this.impacts[3][1] + " kg R11-Äqv.\n\nPOCP: " + this.impacts[3][2] + " kg Ethen-Äqv.\n\nAP: " + this.impacts[3][3] + " kg SO2-Äqv.\n\nEP: " + this.impacts[3][4] + " kg Phosphat-Äqv.\n\nADPE: " + this.impacts[3][5] + " kg Sb-Äqv.\n\nADPF: " + this.impacts[3][6] + " MJ";
                    this.life_cycle_string = recyclingpotential;
                    break;

            }

            return this.life_cycle_string;


        }







    }
}
