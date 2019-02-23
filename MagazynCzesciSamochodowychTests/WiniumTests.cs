using System;
using System.Collections.Generic;
using System.Threading;
using MagazynCzesciSamochodowych;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Winium;

namespace MagazynCzesciSamochodowychTests
{
    [TestClass]
    public class WiniumTest
    {

        private readonly WiniumDriver driver;
        public WiniumTest()
        {
            DesktopOptions options = new DesktopOptions();
            string path = System.IO.Path.GetDirectoryName(typeof(Form1).Assembly.Location);
            options.ApplicationPath = path + @"\MagazynCzesciSamochodowych.exe";
            driver = new WiniumDriver(@"C:\Users\Krawczuk\Desktop\MagazynCzesciSamochodowych\MagazynCzesciSamochodowych", options);

        }


        [TestMethod]
        public void addShowDeleteTest()
        {

            addItem(driver);
            showItem(driver, "NazwaProduktu");
            deleteItem(driver);
            driver.Close();
        }

        [TestMethod()]
        public void modifyItem()
        {

            driver.FindElementByName("Radio").Click();
            driver.FindElementByName("modifyItem").Click();
            driver.FindElementByName("partNumber").SendKeys("1");
            driver.FindElementByName("save").Click();
            showItem(driver, "Radio");
            driver.Close();
        }

        [TestMethod()]
        public void emptyTextBoxes()
        {

            driver.FindElementByName("addItem").Click();
            Equals(true, driver.FindElementByName("Wszystkie dane muszą być uzupełnione"));
            driver.FindElementByName("Zamknij").Click();
            driver.Close();

        }

        [TestMethod()]
        public void itemNotSelected()
        {

            driver.FindElementByName("deleteItem").Click();
            Equals(true, driver.FindElementByName("Błąd usuwania, (nie zaznaczony element)"));
            driver.FindElementByName("Zamknij").Click();

            driver.FindElementByName("modifyItem").Click();
            Equals(true, driver.FindElementByName("Nie zaznaczono elementu."));
            driver.FindElementByName("Zamknij").Click();

            driver.FindElementByName("showItem").Click();
            Equals(true, driver.FindElementByName("Brak wybranego elementu!"));
            driver.FindElementByName("Zamknij").Click();

            driver.Close();
        }

        public void addItem(WiniumDriver driver)
        {
            Thread.Sleep(5000);
            driver.FindElementByName("productName").SendKeys("NazwaProduktu");
            driver.FindElementByName("carBrand").SendKeys("MarkaSamochodu");
            driver.FindElementByName("carModel").SendKeys("ModelSamochodu");
            driver.FindElementByName("productPrice").SendKeys("100 zł");
            driver.FindElementByName("partNumber").SendKeys("1");
            driver.FindElementByName("addItem").Click();
            Equals(true, driver.FindElementByName("NazwaProduktu"));
        }

        public void showItem(WiniumDriver driver, string partName)
        {
            Thread.Sleep(2500);
            driver.FindElementByName(partName).Click();
            driver.FindElementByName("showItem").Click();

            Equals(true, driver.FindElementByName("1"));

            driver.FindElementByName("Zamknij").Click();
        }

        public void deleteItem(WiniumDriver driver)
        {
            Thread.Sleep(2500);
            driver.FindElementByName("NazwaProduktu").Click();
            driver.FindElementByName("deleteItem").Click();
        }

    }
}
