using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Eco_Group25_EE1
{
    [Serializable]
    public class Floor 
    {
        private string floornumber;
        private string floorname;
        private BindingList<Room> rooms = new BindingList<Room>();
        private BindingList<Wall> walls = new BindingList<Wall>();

        public Floor() { }
        
        public Floor(string floornumber, string floorname)
        {
            this.floornumber = floornumber;
            this.floorname = floorname;
        }


        public Floor(string floornumber,string floorname, BindingList<Room> rooms)
        {
            this.floornumber = floornumber;
            this.floorname = floorname;
            this.rooms = rooms; 
        }


        #region propertyMethods
        public string FloorNumber { get => floornumber; set => floornumber = value; }
        public string Name { get => floorname; set => floorname = value; }
        public BindingList<Room> Rooms { get => rooms; set => rooms = value; }
        public BindingList<Wall> Walls { get => walls; set => walls = value; }
        public override string ToString() => $"{"Floorname: "+this.floorname+"\nFloornumber: "+this.floornumber}";

        #endregion


        public void AddRoom(Room room)
        {
            this.rooms.Add(room);
        }
        public void RemoveRoom(Room room)
        {
            this.rooms.Remove(room);
        }

        public void AddWall(Wall wall)
        {
            this.walls.Add(wall);
        }

       

        public double[] calculate_volume_entire_floor()
        {


            double volume_wood = 0;
            double volume_concrete = 0;
            double volume_mansonry = 0;



            foreach (Room r in rooms)
            {
                foreach (Wall w in r.Walls)
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
            }

            double[] volumes = new double[] { volume_wood, volume_concrete, volume_mansonry };

            return volumes;

        }

        public int[] count_objects_in_floors()
        {
            int no_floors = 0;
            int no_rooms = 0;
            int no_walls = 0; 

            foreach(Room r in rooms)
            {
                no_rooms++;
                
                foreach(Wall w in r.Walls)
                {

                    no_walls++;
                }
            }


            int[] count = new int[] { no_floors, no_rooms, no_walls };

            return count; 

        }




    }
}
