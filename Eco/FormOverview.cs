using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary_Eco_Group25_EE1;
using Autodesk.Revit.UI;

namespace Eco
{
    public partial class FormOverview : Form
    {
        private int[] count;
        public static double[] volumes;
        public static string type;
        public static string id;
        private ExternalEvent updateVolume;

        public FormOverview()
        {
            InitializeComponent();
        }


        public FormOverview(int[] count, double[] _volumes, string buildingpart, string name, string _id, ExternalEvent _updateVolume)
        {

            InitializeComponent();

            this.count = count;
            volumes = _volumes;
            type = buildingpart;
            id = _id;
            this.updateVolume = _updateVolume;


            if (buildingpart.Equals("Building"))
            {
                richTextBox1.Text = "Number of Floors: " + count[0] + "\n\nNumber of Rooms: " + count[1] + "\n\nNumber of Walls: " + count[2] +
                    "\n\nVolume of Wood: " + volumes[0] + " m^3\n\nVolume of Concrete: " + volumes[1] + " m^3\n\nVolume of Masonry: " + volumes[2] + " m^3";
                label1.Text = "Building: " + name;
            }
            else if (buildingpart.Equals("Floor"))
            {
                richTextBox1.Text = "Number of Rooms: " + count[1] + "\n\nNumber of Walls: " + count[2] +
                    "\n\nVolume of Wood: " + volumes[0] + " m^3\n\nVolume of Concrete: " + volumes[1] + " m^3\n\nVolume of Masonry: " + volumes[2] + " m^3";
                label1.Text = "Floor: " + name;


            }
            else if (buildingpart.Equals("Room"))
            {
                richTextBox1.Text = "Number of Walls: " + count[2] +
                    "\n\nVolume of Wood: " + volumes[0] + " m^3\n\nVolume of Concrete: " + volumes[1] + " m^3\n\nVolume of Masonry: " + volumes[2] + " m^3";
                label1.Text = "Room: " + name;


            }
            else if (buildingpart.Equals("Wall"))
            {
                richTextBox1.Text = "Volume of Wood: " + volumes[0] + " m^3\n\nVolume of Concrete: " + volumes[1] + " m^3\n\nVolume of Masonry: " + volumes[2] + " m^3";
                label1.Text = "Wall: " + name;
            }

            

        }

            private void FormOverview_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type == "Floor")
            {
                updateVolume.Raise();
                this.Close();
            }
            else if (type == "Room")
            {
                updateVolume.Raise();
                this.Close();
            }
            else
            {
                label2.Text = "Sorry, you can only export Rooms and Floors :)";
            }
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
