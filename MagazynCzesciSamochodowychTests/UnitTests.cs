using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagazynCzesciSamochodowych;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MagazynCzesciSamochodowych.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        string productName;
        string productPrice;
        string carBrand;
        string carModel;
        string partNumber;
        string kindOfPart;
        Form1 form;

        [TestInitialize()]
        public void prepareVariables()
        {
            form = new Form1();
        }

        [TestMethod()] 
        public void itemWithoutOneParameterTest()
        {
            productName = "";
            partNumber = "partNumber";
            productPrice = "productPrice";
            carBrand = "carBrand";
            carModel = "carModel";
            kindOfPart = "part";

            bool validation = form.AddItem(productName, partNumber, carModel, carBrand, productPrice, kindOfPart);

            Assert.AreEqual(validation, false);
        }
        [TestMethod()]
        public void itemWithoutAllParametersTest()
        {
            productName = "productName";
            partNumber = "12";
            productPrice = "productPrice";
            carBrand = "carBrand";
            carModel = "carModel";
            kindOfPart = "part";

            bool validation = form.AddItem(productName, partNumber, carModel, carBrand, productPrice, kindOfPart);

            Assert.AreEqual(validation, true);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void invalidPartNumberTest()
        {
            productName = "productName";
            partNumber = "string";
            productPrice = "productPrice";
            carBrand = "carBrand";
            carModel = "carModel";
            kindOfPart = "part";

            form.AddItem(productName, partNumber, carModel, carBrand, productPrice, kindOfPart);
        }

        [TestMethod()]
        public void startEditingTest()
        {
            string itemToEdit = "itemToEdit";
            string validation = form.EditItem(itemToEdit);
            Assert.AreEqual(validation, "Edycja rozpoczęta pomyślnie");
        }


    }
}