using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynCzesciSamochodowych
{
    public class Part
    {
        private int partNumber;
        private string name;
        private string carBrand;
        private string carModel;
        private string price;
        private string partCategory;

        public Part(int partNumber, string name, string carBrand, string carModel, string price, string partCategory)
        {
            this.PartNumber = partNumber;
            this.Name = name;
            this.CarBrand = carBrand;
            this.CarModel = carModel;
            this.Price = price;
            this.PartCategory = partCategory;
        }

        public int PartNumber { get { return partNumber; } set { partNumber = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string CarBrand { get { return carBrand; } set { carBrand = value; } }
        public string CarModel { get { return carModel; } set { carModel = value; } }
        public string Price { get { return price; } set { price = value; } }
        public string PartCategory { get { return partCategory; } set { partCategory = value; } }
    }
}
