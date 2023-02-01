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
    public partial class FormRoom : Form
    {
        public Room current_room;
        public bool save; 
        public FormRoom()
        {
            InitializeComponent();
        }
        public FormRoom(Room room)
        {
            InitializeComponent();

            this.current_room = room;

            textBox_Roomname.Text = current_room.Name;
            textBox_Roomnumber.Text = current_room.RoomNumber.ToString();


        }


        private void FormRoom_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            current_room.Name = textBox_Roomname.Text;
            current_room.RoomNumber = textBox_Roomnumber.Text;

            save = true;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
