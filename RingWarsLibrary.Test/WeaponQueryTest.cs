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
    public class WeaponQueryTest
    {
        [TestMethod]
        // Arrange
        [DataRow(205, "Assassins Beak", "The beak of an assassin bug", 60, "Poison", 60, "205")]
        [DataRow(207, "Worm Flail", "A flail you concocted with the carcass of a worm and some metal", 100, "Normal", 90, "207")]

        public void GetWeapon_Test(int id, string name, string description, int price, string dmgType, int damage, string itemId)
        {
            // Act
            Weapons actual = SqliteDataAccess.GetWeapon(itemId);

            // Assert
            Assert.AreEqual(id, actual.Id);
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(description, actual.Description);
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(dmgType, actual.DmgType);
            Assert.AreEqual(damage, actual.Damage);
        }
    }
}
