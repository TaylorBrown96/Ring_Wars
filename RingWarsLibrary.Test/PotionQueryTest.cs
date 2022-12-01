/**
* 8/15/2022 to 12/10/2022
* CSC 253
* Group project - Taylor Brown, Kent Jones, Kalie
* A text adventure of Ring Wars.
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RingWarsLibrary.Test
{
    [TestClass]
    public class PotionQueryTest
    {
        [TestMethod]
        // Arrange
        [DataRow(302, "Strange Liqud", 10, 30, "Gives you 30% of your mana","302")]
        [DataRow(300, "Bread Crumb", 10,30, "Heals you for 30% of your health", "300")]

        public void GetPotion_Test(int id, string name, int price, int effects, string description, string itemId)
        {
            // Act
            Potions actual = SqliteDataAccess.GetPotion(itemId);

            // Assert
            Assert.AreEqual(id, actual.Id);
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(effects, actual.Effects);
            Assert.AreEqual(description, actual.Description);
        }
    }
}
