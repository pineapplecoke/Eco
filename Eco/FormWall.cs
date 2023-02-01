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
    public partial class FormWall : Form
    {

        public Wall current_wall;
        public Boolean save = false;

        public FormWall()
        {
            InitializeComponent();
        }

        public FormWall(Wall wall)
        {
            InitializeComponent();
            this.current_wall = wall;

            textBoxName.Text = current_wall.Name;
            comboBoxMaterial.SelectedItem = current_wall.Material;
            numericUpDownLength.Value = Convert.ToDecimal(current_wall.Length);
            numericUpDownWidth.Value = Convert.ToDecimal(current_wall.Depth);
            numericUpDownHeight.Value = Convert.ToDecimal(current_wall.Height);   
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            current_wall.Name = textBoxName.Text;
            current_wall.Material = (string)comboBoxMaterial.SelectedItem;
            current_wall.Length = Convert.ToDouble(numericUpDownLength.Value);
            current_wall.Depth = Convert.ToDouble(numericUpDownWidth.Value);
            current_wall.Height = Convert.ToDouble(numericUpDownHeight.Value);
            current_wall.update_Volume();
            save = true;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormWall_Load(object sender, EventArgs e)
        {

        }
    }
}
