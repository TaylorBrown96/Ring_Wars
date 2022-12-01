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
    public class ItemQueryTest
    {
        [TestMethod]
        // Arrange
        [DataRow(503, "Map", 10, false, false, "A map of the area", "503")]
        [DataRow(506, "Door Key", 10, false, false, "It must open something..","506")]

        public void GetItem_Test(int id, string name, int price, bool questItem, bool required, string description, string itemId)
        {
            // Act
            Items actual = SqliteDataAccess.GetItem(itemId);

            // Assert
            Assert.AreEqual(id, actual.Id);
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(questItem, actual.QuestItem);
            Assert.AreEqual(required, actual.Required);
            Assert.AreEqual(description, actual.Description);
        }
    }
}
