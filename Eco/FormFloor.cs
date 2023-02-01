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

namespace Eco
{
    public partial class FormFloor : Form
    {
        public Floor current_floor;
        public Boolean save = false;

        public FormFloor()
        {
            InitializeComponent();
        }

        public FormFloor(Floor floor)
        {
            InitializeComponent();
            this.current_floor = floor;

            textBox_floorname.Text = current_floor.Name;
            textBox_floornumber.Text = current_floor.FloorNumber.ToString();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            current_floor.Name = textBox_floorname.Text;
            //current_floor.FloorNumber = Convert.ToInt32(textBox_floornumber.Text);
            save = true;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
