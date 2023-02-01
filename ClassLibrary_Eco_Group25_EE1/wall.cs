using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ClassLibrary_Eco_Group25_EE1
{
    [Serializable]
    public class Wall
    {
        private string name;
        private string wallnumber;
        private double height;
        private double length;
        private double depth;
        private string material;
        private double volume;

        public Wall() { }

        public Wall(string name)
        {

        }

        public Wall (string name, string wallnumber, double volume, string material)
        {
            this.name = name;
            this.wallnumber = wallnumber;
            this.material = material;
            this.volume = volume;
        }

        public Wall(string name, string wallnumber, double height, double length, double depth, string material)
        {
            this.name = name;
            this.wallnumber = wallnumber;
            this.height = height;
            this.length = length;
            this.depth = depth;
            this.material = material;
            CalculateVolume();
        }

        //Volume Calculation Methode

        private void CalculateVolume()
        {
            double volume = 0.0;
            volume = this.height * this.length * this.depth;

            this.volume = volume;
        }

        public void update_Volume()
        {
            CalculateVolume();
        }


        public double get_Volume()
        {


            return this.volume;
        }

        public string Name { get => name; set => name = value; }
        public string WallNumber { get => wallnumber; set => wallnumber = value; }
        public double Height { get => height; set => height = value; }
        public double Length { get => length; set => length = value; }
        public double Depth { get => depth; set => depth = value; }
        public string Material { get => material; set => material = value; }
        public override string ToString() => $"{"Name: " + this.name + "\nWallnumber: " + this.wallnumber + "\nVolume: " + this.volume + "\nMaterial: " + this.material}";


        public double[] CalculateWallVolumeForImpact()
        {
            double[] volume_wall = new double[] { };

            if (this.material.Equals("wood"))
            {
                double[] volume = new double[] { this.volume, 0, 0 };
                volume_wall = volume;

            }
            else if (this.material.Equals("concrete"))
            {
                double[] volume = new double[] { 0, this.volume, 0 };
                volume_wall = volume;
            }
            else if (this.material.Equals("masonry"))
            {
                double[] volume = new double[] { 0, 0, this.volume };
                volume_wall = volume;
            }

            return volume_wall;
        }

    }


}
