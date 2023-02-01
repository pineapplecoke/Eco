using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Eco_Group25_EE1
{
    [Serializable]
    public class Building
    {
        private BindingList<Floor> floors = new BindingList<Floor>();
        private string name;
        private int postalcode;
        private string street;
        private int housenumber;
        private string place;

        public Building(string name) {
            this.name = name; 
        }

        public Building(string name, int postalcode, string street, int housenumber, string place)
        {
            this.name = name;
            this.postalcode = postalcode;
            this.street = street;
            this.housenumber = housenumber;
            this.place = place;
        }

        public Building(string name, int postalcode, string street,  int housenumber, string place, BindingList<Floor> floors)
        {
            this.name = name;
            this.postalcode = postalcode;
            this.street = street;
            this.housenumber = housenumber;
            this.place = place;
            this.floors = floors;

        }

        public string Name { get => name; set => name = value; }
        public int Postalcode { get => postalcode; set => postalcode = value; }
        public string Street { get => street; set => street = value; }
        public int Housenumber { get => housenumber; set => housenumber = value; }
        public string Place { get => place; set => place = value; }
        public BindingList<Floor> Floors { get => floors; set => floors = value; }

        public override string ToString() => $"{"Name: "+this.name+"\nPostalcode: "+this.postalcode+"\nStreet: "+this.street+"\nHousenumber: "+this.housenumber+"\nPlace: "+this.place}";

        public void AddFloor(Floor floor)
        {
            this.floors.Add(floor);
        }
        public void RemoveFloor(Floor floor)
        {
            this.floors.Remove(floor);
        }

        public double[] calculate_volume_entire_building()
        {
           

            double volume_wood = 0;
            double volume_concrete = 0;
            double volume_mansonry = 0; 


            foreach(Floor f in floors)
            {
                foreach (Room r in f.Rooms)
                {
                    foreach(Wall w in r.Walls)
                    {
                        if(w.Material.Equals("wood"))
                        {
                            double volume = w.get_Volume();
                            volume_wood += volume; 
                        }else if (w.Material.Equals("concrete"))
                        {
                            double volume = w.get_Volume();
                            volume_concrete += volume;
                        }else if (w.Material.Equals("mansonry"))
                        {
                            double volume = w.get_Volume();
                            volume_mansonry += volume;
                        }

                    }
                }
            }
            double[] volumes = new double[] {volume_wood,volume_concrete, volume_mansonry};

            return volumes; 

        }

        public int[] count_objects_in_building()
        {
            int no_floors = 0;
            int no_rooms = 0;
            int no_walls = 0; 


            foreach(Floor f in floors)
            {
                no_floors++;
                
                foreach(Room r in f.Rooms)
                {
                    no_rooms++;

                    foreach(Wall w in r.Walls)
                    {
                        no_walls++;
                    }

                }
            
            }

            int[] count = new int[] { no_floors, no_rooms, no_walls };

            return count; 

        }


    }
}


