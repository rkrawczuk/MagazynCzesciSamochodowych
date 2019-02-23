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

        [TestMethod]
        public void addShowDeleteTest()
        {
            DesktopOptions options = new DesktopOptions();
            options.ApplicationPath = @"C:\Users\Krawczuk\Desktop\MagazynCzesciSamochodowych\MagazynCzesciSamochodowych\MagazynCzesciSamochodowych\bin\Debug\MagazynCzesciSamochodowych.exe";
            WiniumDriver driver = new WiniumDriver(@"C:\Users\Krawczuk\Desktop\MagazynCzesciSamochodowych\MagazynCzesciSamochodowych\MagazynCzesciSamochodowychTests\bin\Debug", options);

            addItem(driver);
            showItem(driver, "NazwaProduktu");
            deleteItem(driver);
            driver.Close();
        }

        [TestMethod()]
        public void modifyItem()
        {
            DesktopOptions options = new DesktopOptions();
            options.ApplicationPath = @"C:\Users\Krawczuk\Desktop\MagazynCzesciSamochodowych\MagazynCzesciSamochodowych\MagazynCzesciSamochodowych\bin\Debug\MagazynCzesciSamochodowych.exe";
            WiniumDriver driver = new WiniumDriver(@"C:\Users\Krawczuk\Desktop\MagazynCzesciSamochodowych\MagazynCzesciSamochodowych\MagazynCzesciSamochodowychTests\bin\Debug", options);

            driver.FindElementByName("Radio").Click();
            driver.FindElementByName("modifyItem").Click();
            driver.FindElementByName("partNumber").SendKeys("1");
            driver.FindElementByName("save").Click();
            showItem(driver, "Radio");
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
