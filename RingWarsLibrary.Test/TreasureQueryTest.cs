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
    public class TreasureQueryTest
    {
        [TestMethod]
        // Arrange
        [DataRow(401, "Mysterious Stone", 35, false, "A strange rock emanating a mysterious aura", "401")]
        [DataRow(402, "Fancy Heirloom", 25, false, "The dragonfly was guarding this item with its life", "402")]

        public void GetTreasure_Test(int id, string name, int price, bool questItem, string description, string itemId)
        {
            // Act
            Treasures actual = SqliteDataAccess.GetTreasure(itemId);

            // Assert
            Assert.AreEqual(id, actual.Id);
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(questItem, actual.QuestItem);
            Assert.AreEqual(description, actual.Description);
        }
    }
}
