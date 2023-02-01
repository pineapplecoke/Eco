using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ClassLibrary_Eco_Group25_EE1
{
    [Serializable]
    public class Room
    {
        private string roomnumber;
        private string name;
        private BindingList<Wall> walls = new BindingList<Wall>(); 

        public Room(string roomnumber, string name, BindingList<Wall> walls)
        {
            this.roomnumber = roomnumber;
            this.name = name;
            this.walls = walls; 
        }
        public Room(string roomnumber, string name)
        {
            this.roomnumber = roomnumber;
            this.name = name; 
        }


        public string RoomNumber { get => roomnumber; set => roomnumber = value; }
        public string Name { get => name; set => name = value; }

        public BindingList<Wall> Walls { get => walls; set => walls = value; }

        public void AddWall(Wall wall)
        {
            this.walls.Add(wall);
        }
        public void RemoveWall(Wall wall)
        {
            this.walls.Remove(wall);
        }
        public override string ToString() => $"{"Name: " + this.name + "\nRoomnumber: " + this.roomnumber}";

        public double[] calculate_volume_entire_room()
        {


            double volume_wood = 0;
            double volume_concrete = 0;
            double volume_mansonry = 0;



            foreach (Wall w in walls)
            {
                if (w.Material.Equals("wood"))
                {
                    double volume = w.get_Volume();
                    volume_wood += volume;
                }
                else if (w.Material.Equals("concrete"))
                {
                    double volume = w.get_Volume();
                    volume_concrete += volume;
                }
                else if (w.Material.Equals("masonry"))
                {
                    double volume = w.get_Volume();
                    volume_mansonry += volume;
                }

                }
    

            double[] volumes = new double[] { volume_wood, volume_concrete, volume_mansonry };

            return volumes;

        }

        public int[] count_objects_in_rooms()
        {
            int no_floors = 0;
            int no_rooms = 0;
            int no_walls = 0;


            foreach (Wall w in walls)
            {

                no_walls++;
            }


            int[] count = new int[] { no_floors, no_rooms, no_walls };

            return count;

        }




    }



}
