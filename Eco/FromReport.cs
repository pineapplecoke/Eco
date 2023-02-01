using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using ClassLibrary_Eco_Group25_EE1;

namespace Eco
{
    public partial class FromReport : Form
    {
        public static Report calculation;
        private List<double[]> impacts;
        public static string name;
        public static string type;
        public static string id;
        private ExternalEvent _updateEvent;
        private ExternalEvent _placeLampe;
        public FromReport()
        {
            InitializeComponent();
        }


        public FromReport(Report _calculation, string name_object, string type_object, string _id, ExternalEvent updateEvent, ExternalEvent placeLampe)
        {
            InitializeComponent();
            ComboBoxen();
            calculation = _calculation;
            this.impacts = _calculation.get_impacts();
            name = name_object;
            type = type_object;
            id = _id;
            _updateEvent = updateEvent;
            _placeLampe = placeLampe;

            switch (type)
            {
                case "Building":

                    label2.Text = "Building: " + name;
                    break;

                case "Floor":

                    label2.Text = "Floor: " + name;
                    break;

                case "Room":

                    label2.Text = "Room: " + name;
                    break;

                case "Wall":

                    label2.Text = "Wall: " + name;
                    break;

                    
            }
            
           
        }


        public string NameOfObject() 
        {
            return name;
        }
        public string TypeOfObject() 
        {
            return type;
        }

        public void ComboBoxen()
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false; 
        }

        private void FromReport_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] labels = new string[] { "GWP", "ODP", "POCP", "AP", "EP", "ADPE", "ADPF" };

            if (comboBox1.SelectedItem.Equals("Production"))
            {
                chart1.Series[0].Points.DataBindXY(labels, impacts[0]);
                chart1.Series[0].LegendText = "Production";
                richTextBox1.Text = calculation.life_cycle_to_string("Production");


            }else if (comboBox1.SelectedItem.Equals("Transport"))
            {
                chart1.Series[0].Points.DataBindXY(labels, impacts[1]);
                chart1.Series[0].LegendText = "Transport";
                richTextBox1.Text = calculation.life_cycle_to_string("Transport");

            }
            else if (comboBox1.SelectedItem.Equals("Wastemanagement"))
            {
                chart1.Series[0].Points.DataBindXY(labels, impacts[2]);
                chart1.Series[0].LegendText = "Wastemanagement";
                richTextBox1.Text = calculation.life_cycle_to_string("Wastemanagement");
            }
            else if (comboBox1.SelectedItem.Equals("Recyclingpotential")) 
            {
                chart1.Series[0].Points.DataBindXY(labels, impacts[3]);
                chart1.Series[0].LegendText = "Recyclingpotential";
                richTextBox1.Text = calculation.life_cycle_to_string("Recyclingpotential");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
 

            if (radioButton1.Checked)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = true; 
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox2.Enabled = false;
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] labels = new string[] { "Production", "Transport", "Wastemanagement", "Recyclingpotential"};
            if (comboBox2.SelectedItem.Equals("GWP"))
            {
                double[] impacts_new = new double[] { impacts[0][0], impacts[1][0], impacts[2][0], impacts[3][0] };

                chart1.Series[0].Points.DataBindXY(labels, impacts_new);
                chart1.Series[0].LegendText = "GWP";
                richTextBox1.Text = calculation.impact_factor_to_string("GWP");
            }
            else if (comboBox2.SelectedItem.Equals("ODP"))
            {
                double[] impacts_new = new double[] { impacts[0][1], impacts[1][1], impacts[2][1], impacts[3][1] };

                chart1.Series[0].Points.DataBindXY(labels, impacts_new);
                chart1.Series[0].LegendText = "ODP";
                richTextBox1.Text = calculation.impact_factor_to_string("ODP");
            }
            else if (comboBox2.SelectedItem.Equals("POCP"))
            {
                double[] impacts_new = new double[] { impacts[0][2], impacts[1][2], impacts[2][2], impacts[3][2] };

                chart1.Series[0].Points.DataBindXY(labels, impacts_new);
                chart1.Series[0].LegendText = "POCP";
                richTextBox1.Text = calculation.impact_factor_to_string("POCP");
            }
            else if (comboBox2.SelectedItem.Equals("AP"))
            {
                double[] impacts_new = new double[] { impacts[0][3], impacts[1][3], impacts[2][3], impacts[3][3] };

                chart1.Series[0].Points.DataBindXY(labels, impacts_new);
                chart1.Series[0].LegendText = "AP";
                richTextBox1.Text = calculation.impact_factor_to_string("AP");
            }
            else if (comboBox2.SelectedItem.Equals("EP"))
            {
                double[] impacts_new = new double[] { impacts[0][4], impacts[1][4], impacts[2][4], impacts[3][4] };

                chart1.Series[0].Points.DataBindXY(labels, impacts_new);
                chart1.Series[0].LegendText = "EP";
                richTextBox1.Text = calculation.impact_factor_to_string("EP");
            }
            else if (comboBox2.SelectedItem.Equals("ADPE"))
            {
                double[] impacts_new = new double[] { impacts[0][5], impacts[1][5], impacts[2][5], impacts[3][5] };

                chart1.Series[0].Points.DataBindXY(labels, impacts_new);
                chart1.Series[0].LegendText = "ADPE";
                richTextBox1.Text = calculation.impact_factor_to_string("ADPE");
            }
            else if (comboBox2.SelectedItem.Equals("ADPF"))
            {
                double[] impacts_new = new double[] { impacts[0][6], impacts[1][6], impacts[2][6], impacts[3][6] };

                chart1.Series[0].Points.DataBindXY(labels, impacts_new);
                chart1.Series[0].LegendText = "ADPF";
                richTextBox1.Text = calculation.impact_factor_to_string("ADPF");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _updateEvent.Raise();

            if(type == "Room")
            {
                try
                {
                    _placeLampe.Raise();

                }catch(Exception ex)
                {
                    TaskDialog.Show("Revit", ex.ToString());
                    label3.Text = "Sorry, something went wrong :(";
                }
            }
            label3.Text = "Imported to Revit! :)";
            this.Close();
        }
    }
}
