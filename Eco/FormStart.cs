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
//using Autodesk.Revit.DB;


// Library for project load and save
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary_Eco_Group25_EE1;

namespace Eco
{
    public partial class FormStart : System.Windows.Forms.Form
    {

        private BindingList<Building> _buildings = new BindingList<Building>();
        private Building b;
        private ProjectEvents projectevent;

        public FormStart(ProjectEvents projectevent)
        {
            InitializeComponent();
            //CreateExampleData();
            //UpdateTreeView();
            //ShowLog();
            this.projectevent = projectevent;
            _buildings.Add(projectevent.b);
            UpdateTreeView();

            
        }
        

        public void import_building(Building b)
        {
            _buildings.Add(b);
            Console.WriteLine(b.ToString());
        }

     

        private void CreateExampleData()
        {
            Building haus1 = new Building("Haus 1",64560,"Frankfurter Straße",2, "Darmstadt");
            Building haus2 = new Building("Haus 2", 63560, "Berliner Straße", 12, "Frankfurt");

            Floor floor1 = new Floor("Test","Erdgeschoss");
            haus1.AddFloor(floor1);

            Floor floor2 = new Floor("testc","Obergeschoss");
            haus1.AddFloor(floor2);

            Room room1 = new Room("test","Schlafzimmer");
            floor1.AddRoom(room1);

            Room room2 = new Room("test","Wohnzimmer");
            floor1.AddRoom(room2);

            Wall wall1 = new Wall("Steinmauer","1",1.9,3.5,0.4,"concrete");
            room1.AddWall(wall1);

            Wall wall2 = new Wall("Schöne Mauer", "1", 1.9, 3.5, 0.4, "concrete");
            room1.AddWall(wall2);

            Wall wall3 = new Wall("Alte Mauer", "1", 1.9, 3.5, 0.4, "concrete");
            room2.AddWall(wall3);

            Wall wall4 = new Wall("Kleine Mauer", "1", 1.9, 3.5, 0.4, "concrete");
            room2.AddWall(wall4);

            _buildings.Add(haus1);
            _buildings.Add(haus2);
        }
    
    
   
        private void ShowLog()
        {
            foreach (Building b in _buildings)
            {
                Console.WriteLine(b.Name);
                foreach (Floor f in b.Floors)
                {
                    Console.WriteLine(" - " + f.Name);
                    foreach (Room r in f.Rooms)
                    {
                        Console.WriteLine(" - - " + r.Name);
                        foreach (Wall w in r.Walls)
                        {
                            Console.WriteLine(" - - - " + w.Name);
                        }
                    }
                }
            }
        }

        private void UpdateTreeView_for_Revit()
        {
            treeViewBuilding.Nodes.Clear();

            TreeNode tn;
            for (int i = 0; i < _buildings.Count; i++)
            {
                tn = treeViewBuilding.Nodes.Add("Building: " + _buildings[i].Name);
                tn.Tag = _buildings[i];

                for (int j = 0; j < _buildings[i].Floors.Count; j++)
                {
                    tn = treeViewBuilding.Nodes[i].Nodes.Add("Floor: " + _buildings[i].Floors[j].Name);
                    tn.Tag = _buildings[i].Floors[j];

                    for (int l = 0; l < _buildings[i].Floors[j].Walls.Count; l++)
                    {
                        tn = treeViewBuilding.Nodes[i].Nodes[j].Nodes.Add("Wall: " + _buildings[i].Floors[j].Walls[l].Name);
                        tn.Tag = _buildings[i].Floors[j].Walls[l];
                    }

                    for (int l = 0; l < _buildings[i].Floors[j].Rooms.Count; ++l)
                    {
                        tn = treeViewBuilding.Nodes[i].Nodes[j].Nodes.Add("Room: " + _buildings[i].Floors[j].Rooms[l].Name);
                        tn.Tag = _buildings[i].Floors[j].Rooms[l];

                        for (int k = 0; k < _buildings[i].Floors[j].Rooms[l].Walls.Count; k++)
                        {
                            tn = treeViewBuilding.Nodes[i].Nodes[j].Nodes[l].Nodes.Add("Wall: " + _buildings[i].Floors[j].Rooms[l].Walls[k].Name);
                            tn.Tag = _buildings[i].Floors[j].Rooms[l].Walls[k];
                        }


                    }

                }
            }
            treeViewBuilding.ExpandAll();
        }
    

        private void UpdateTreeView()
        {
            treeViewBuilding.Nodes.Clear();

            TreeNode tn;
            for (int i = 0; i < _buildings.Count; i++)
            {
                tn = treeViewBuilding.Nodes.Add("Building: " + _buildings[i].Name);
                tn.Tag = _buildings[i];

                for (int j = 0; j < _buildings[i].Floors.Count; j++)
                {
                    tn = treeViewBuilding.Nodes[i].Nodes.Add("Floor: " + _buildings[i].Floors[j].Name);
                    tn.Tag = _buildings[i].Floors[j];

                    for (int k = 0; k < _buildings[i].Floors[j].Rooms.Count; k++)
                    {
                        tn = treeViewBuilding.Nodes[i].Nodes[j].Nodes.Add("Room: " + _buildings[i].Floors[j].Rooms[k].Name);
                        tn.Tag = _buildings[i].Floors[j].Rooms[k];

                        for (int l = 0; l < _buildings[i].Floors[j].Rooms[k].Walls.Count; l++)
                        {
                            tn = treeViewBuilding.Nodes[i].Nodes[j].Nodes[k].Nodes.Add("Wall: " + _buildings[i].Floors[j].Rooms[k].Walls[l].Name);
                            tn.Tag = _buildings[i].Floors[j].Rooms[k].Walls[l];
                        }

                    }

                }
            }
            treeViewBuilding.ExpandAll();
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!CheckIfChoose()) return;
            String item = treeViewBuilding.SelectedNode.Text;

            // Delete building
            if (treeViewBuilding.SelectedNode.Tag is Building)
            {
                _buildings.Remove((Building)treeViewBuilding.SelectedNode.Tag);
            }

            // Delete floor
            else if (treeViewBuilding.SelectedNode.Tag is Floor)
            {
                foreach (Building b in _buildings)
                {
                    foreach (Floor f in b.Floors)
                    {
                        if (f == treeViewBuilding.SelectedNode.Tag)
                        {
                            b.RemoveFloor(f);
                            break;
                        }
                    }
                }
            }
            // Delete room
            else if (treeViewBuilding.SelectedNode.Tag is Room)
            {
                foreach (Building b in _buildings)
                {
                    foreach (Floor f in b.Floors)
                    {
                        foreach (Room r in f.Rooms)
                        {
                            if (r == treeViewBuilding.SelectedNode.Tag)
                            {
                                f.RemoveRoom(r);
                                break;
                            }
                            
                        }

                    }
                }
            }

            // Delete wall
            else if (treeViewBuilding.SelectedNode.Tag is Wall)
            {
                foreach (Building b in _buildings)
                {
                    foreach (Floor f in b.Floors)
                    {
                        foreach (Room r in f.Rooms)
                        {
                            foreach (Wall w in r.Walls)
                            {
                                if (w == treeViewBuilding.SelectedNode.Tag)
                                {
                                    r.RemoveWall(w);
                                    break;
                                }
                            }
                        }

                    }
                }
            }
           
            UpdateTreeView();
            toolStripStatusLabel1.Text = "Item \"" + item + "\" deleted.";

        }

        private void buttonEditWall_Click(object sender, EventArgs e)
        {
            if (!CheckIfChoose()) return;

            if ( treeViewBuilding.SelectedNode.Tag is Building)
            {
                Building b = treeViewBuilding.SelectedNode.Tag as Building; 
                FormBuilding form1 = new FormBuilding(b);
                form1.ShowDialog();
                if (form1.save)
                {
                    toolStripStatusLabel1.Text = "Building updated.";
                }
                UpdateTreeView();
            }


            else if (treeViewBuilding.SelectedNode.Tag is Floor)
            {
                Floor f = treeViewBuilding.SelectedNode.Tag as Floor;
                FormFloor formFloor = new FormFloor(f);
                formFloor.ShowDialog();
                if (formFloor.save)
                {
                    toolStripStatusLabel1.Text = "Floor updated.";
                }
                UpdateTreeView();
            }

            else if (treeViewBuilding.SelectedNode.Tag is Room)
            {
                Room r = treeViewBuilding.SelectedNode.Tag as Room;
                FormRoom formRoom = new FormRoom(r);
                formRoom.ShowDialog();
                if (formRoom.save)
                {
                    toolStripStatusLabel1.Text = "Room updated.";
                }
                UpdateTreeView();
            }


            else if (treeViewBuilding.SelectedNode.Tag is Wall)
            {
                FormWall formWall = new FormWall((Wall)treeViewBuilding.SelectedNode.Tag);
                formWall.ShowDialog();
                if (formWall.save)
                {
                    toolStripStatusLabel1.Text = "Wall updated.";
                }
                UpdateTreeView();
            }else
            {
                MessageBox.Show("Please select Object!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void buttonCreate_Click_1(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length == 0)
            {
                MessageBox.Show("Name is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (treeViewBuilding.SelectedNode == null)
            {
                Building b = new Building(textBoxName.Text); 
                _buildings.Add(b);
                toolStripStatusLabel1.Text = "Building \"" + textBoxName.Text + "\" created.";
            }
            else if (treeViewBuilding.SelectedNode.Tag is Building)
            {
                Building b = (Building)treeViewBuilding.SelectedNode.Tag;
                
                int count_floors = 0; 
                
                foreach(Floor f in b.Floors)
                {
                    count_floors++; 
                }
                int count_floors_ = count_floors + 1;

                b.AddFloor(new Floor("Test",textBoxName.Text));
                toolStripStatusLabel1.Text = "Floor \""+count_floors_+","+ textBoxName.Text + "\" created.";
            }
            else if (treeViewBuilding.SelectedNode.Tag is Floor)
            {
                Floor f = (Floor)treeViewBuilding.SelectedNode.Tag;
                

                int count_rooms = 0;

                foreach (Room r in f.Rooms)
                {
                    count_rooms++;
                }
                int count_rooms_ = count_rooms + 1;
                f.AddRoom(new Room("test",textBoxName.Text));
                toolStripStatusLabel1.Text = "Room \""+count_rooms_+"," + textBoxName.Text + "\" created.";
            }
            else if (treeViewBuilding.SelectedNode.Tag is Room)
            {
                Room r = (Room)treeViewBuilding.SelectedNode.Tag;
                r.AddWall(new Wall(textBoxName.Text));
                toolStripStatusLabel1.Text = "Wall \"" + textBoxName.Text + "\" created. Edit wall for more properties.";
            }

            UpdateTreeView();
            
        }

        private bool CheckIfChoose()
        {
            if (treeViewBuilding.SelectedNode == null)
            {
                MessageBox.Show("Error: Choose an item from the tree view first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Save file
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, _buildings);
                fs.Close();
            } 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Open file
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                _buildings = (BindingList<Building>)bf.Deserialize(fs);
                fs.Close();
                UpdateTreeView();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eco 1.2 by Group 25\n\nTU Darmstadt\nEngineering Informatics I\nWS 2021/22", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void buttonCreateReport_Click(object sender, EventArgs e)
        {
            if (!CheckIfChoose()) return;

            if (treeViewBuilding.SelectedNode.Tag is Building)
            {
                Building b = treeViewBuilding.SelectedNode.Tag as Building;

                double[] volumes = b.calculate_volume_entire_building();

                Report calc = new Report(volumes);

                FromReport report = new FromReport(calc, b.Name, "Building",b.Housenumber.ToString(),projectevent.Update, projectevent.Place);
                report.ShowDialog();

            }else if(treeViewBuilding.SelectedNode.Tag is Floor)
            {
                Floor f = treeViewBuilding.SelectedNode.Tag as Floor;

                double[] volumes = f.calculate_volume_entire_floor();

                Report calc = new Report(volumes);

                FromReport report = new FromReport(calc, f.Name, "Floor",f.FloorNumber,projectevent.Update, projectevent.Place);
                report.ShowDialog();
            }
            else if (treeViewBuilding.SelectedNode.Tag is Room)
            {
                Room r = treeViewBuilding.SelectedNode.Tag as Room;

                double[] volumes = r.calculate_volume_entire_room();

                Report calc = new Report(volumes);

                FromReport report = new FromReport(calc, r.Name, "Room",r.RoomNumber,projectevent.Update, projectevent.Place);
                report.ShowDialog();
            }
            else if (treeViewBuilding.SelectedNode.Tag is Wall)
            {
                Wall w = treeViewBuilding.SelectedNode.Tag as Wall;

                double[] volumes = w.CalculateWallVolumeForImpact();

                Report calc = new Report(volumes);
                FromReport report = new FromReport(calc, w.Name, "Wall",w.WallNumber,projectevent.Update, projectevent.Place);
                report.ShowDialog();
            }


        }




        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Select an item from the tree view to create a child item.";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void treeViewBuilding_AfterSelect(object sender, TreeViewEventArgs e)
        {

            richTextBox1.Text = treeViewBuilding.SelectedNode.Tag.ToString();

        }

        private void treeViewBuilding_MouseDown(object sender, MouseEventArgs e)
        {
            if (treeViewBuilding.HitTest(e.Location).Node == null)
            {
                treeViewBuilding.SelectedNode = null;
                richTextBox1.Text = "Please select an object.";
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckIfChoose()) return;

            if (treeViewBuilding.SelectedNode.Tag is Building)
            {
                Building b = treeViewBuilding.SelectedNode.Tag as Building;

                double[] volumes = b.calculate_volume_entire_building();
                int[] count = b.count_objects_in_building();
                FormOverview overview = new FormOverview(count, volumes, "Building", b.Name, b.Housenumber.ToString(),projectevent.UpdateVolume);
                overview.ShowDialog();


            }
            else if (treeViewBuilding.SelectedNode.Tag is Floor)
            {
                Floor f = treeViewBuilding.SelectedNode.Tag as Floor;

                double[] volumes = f.calculate_volume_entire_floor();
                int[] count = f.count_objects_in_floors();
                FormOverview overview = new FormOverview(count, volumes, "Floor",f.Name,f.FloorNumber,projectevent.UpdateVolume);
                overview.ShowDialog();

            }
            else if (treeViewBuilding.SelectedNode.Tag is Room)
            {
                Room r = treeViewBuilding.SelectedNode.Tag as Room;
                double[] volumes = r.calculate_volume_entire_room();
                int[] count = r.count_objects_in_rooms();
                FormOverview overview = new FormOverview(count, volumes, "Room",r.Name,r.RoomNumber,projectevent.UpdateVolume);
                overview.ShowDialog();

            }
            else if (treeViewBuilding.SelectedNode.Tag is Wall)
            {
                Wall w = treeViewBuilding.SelectedNode.Tag as Wall;
                double[] volumes = w.CalculateWallVolumeForImpact();
                int[] count = new int[] { };
                FormOverview overview = new FormOverview(count, volumes, "Wall",w.Name, w.WallNumber,projectevent.UpdateVolume);
                overview.ShowDialog();


            }
        }

        private void FormStart_Load(object sender, EventArgs e)
        {

        }
    }
}