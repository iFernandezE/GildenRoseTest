using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Net.Http.Headers;

namespace GildenRoseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUpdateNotExpiredNormalProductQuality()
        {
            Product product = new Product("bread",35,40,false);
            product.UpdateProductValues();
            Assert.AreEqual(39,product.quality);
        }

        [TestMethod]
        public void TestUpdateNotExpiredNormalProductSellIn()
        {
            Product product = new Product("bread", 35, 40, false);
            product.UpdateProductValues();
            Assert.AreEqual(34, product.sellIn);
        }

        [TestMethod]
        public void TestUpdateExpiredNormalProductQuality()
        {
            Product product = new Product("bread", 0, 40, false);
            product.UpdateProductValues();
            Assert.AreEqual(38, product.quality);
        }

        [TestMethod]
        public void TestUpdateLegendaryProductQuality()
        {
            Product product = new Product("Sulfuras", 0, 80, false);
            product.UpdateProductValues();
            Assert.AreEqual(80, product.quality);
        }

        [TestMethod]
        public void TestUpdateNotExpiredConjuredProductQuality()
        {
            Product product = new Product("toy", 10, 30, true);
            product.UpdateProductValues();
            Assert.AreEqual(28, product.quality);
        }

        [TestMethod]
        public void TestUpdateExpiredConjuredProductQuality()
        {
            Product product = new Product("toy", 0, 30, true);
            product.UpdateProductValues();
            Assert.AreEqual(26, product.quality);
        }

        [TestMethod]
        public void TestUpdateNotExpiredSpecialProductQualityWithSellInIsLessOrEqualThan5()
        {
            Product product = new Product("Aged Brie", 4, 30, false);
            product.UpdateProductValues();
            Assert.AreEqual(33, product.quality);
        }

        [TestMethod]
        public void TestUpdateNotExpiredSpecialProductQualityWithSellInIsLessOrEqualThan10()
        {
            Product product = new Product("Aged Brie", 7, 30, false);
            product.UpdateProductValues();
            Assert.AreEqual(32, product.quality);
        }

        [TestMethod]
        public void TestUpdateNotExpiredSpecialProductQualityWithSellInIsMoreThan10()
        {
            Product product = new Product("Aged Brie", 15, 30, false);
            product.UpdateProductValues();
            Assert.AreEqual(31, product.quality);
        }

        [TestMethod]
        public void TestUpdateExpiredSpecialProductQualityReturnQualityZero()
        {
            Product product = new Product("Aged Brie", 0, 50, false);
            product.UpdateProductValues();
            Assert.AreEqual(0, product.quality);
        }

        [TestMethod]
        public void TestQualityValueNotSulfurasIsOver50OrUnder0ReturnErrorMessage() {
            Product product = new Product("Bread", 35, 60,false);
            string message = string.Empty;
            try
            {
                product.UpdateProductValues();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid Data", message);
        }

        [TestMethod]
        public void TestQualityValueForSulfurasIsnot80ReturnErrorMessage()
        {
            Product product = new Product("Bread", 35, 80,false);
            string message = string.Empty;
            try
            {
                product.UpdateProductValues();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Invalid Data", message);
        }


    }
}