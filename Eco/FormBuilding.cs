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
    public partial class FormBuilding : Form
    {
        public Building current_building;
        public Boolean save = false;

        public FormBuilding()
        {
            InitializeComponent();

            



        }


        public FormBuilding(Building building)
        {
            InitializeComponent();
            this.current_building = building;

            textBox_name.Text = current_building.Name;
            textBox_housenumber.Text = current_building.Housenumber.ToString();
            textBox_place.Text = current_building.Place;
            textBox_postalcode.Text = current_building.Postalcode.ToString();
            textBox_street.Text = current_building.Street; 


        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormBuilding_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            current_building.Name = textBox_name.Text;
            current_building.Postalcode = Convert.ToInt32(textBox_postalcode.Text);
            current_building.Street = textBox_street.Text;
            current_building.Housenumber = Convert.ToInt32(textBox_housenumber.Text);
            current_building.Place = textBox_place.Text;

            save = true;
            this.Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
