using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using RingWarsLibrary;
using Xunit;
using Xunit.Sdk;

namespace RingWarsLibrary.Tests
{
    public class DatabaseAccessTests
    {
        //int id, string name, int price, int effects, string description
        //[Theory]
        //[InlineData(00, "Health", 20, 20, "Heals 20")]
        //public void PotionAccess(int id, string name, int price, int effects, string description)
        //{
        //   Potions healthpotion = new Potions(null);


        //}

        /*public void PotionCall() 
        {
            using (var mock = AutoMock.GetLoose()) 
            {
                mock.Mock<SqliteDataAccess>()
                    .Setup(x => x.GetPotion<1>("select * from POTIONS"))
                    .Returns(GetPotionSample);
            }
            throw new NotImplementedException();
        }*/
        [Fact]
        public void TestPotionAccessCall()
        {
            //arrange
            List<Potions> potions = new List<Potions>(GetPotionSample());
            //SqliteDataAccess.GetPotion("1")
            List<Potions> result = SqliteDataAccess.GetPotion("1");
            string expected = "health";

            Assert.Equal(expected, result);

        }
        
        private List<Potions> GetPotionSample() 
        {
            List<Potions> potions = new List<Potions>
            {
                new Potions(1,"health", 20, 30, "Heals 30")
                {
                   Id = 1,
                   Name = "Health",
                   Price = 20,
                   Effects = 30,
                   Description = "Heals 30"
                },
                new Potions(2,"big health", 20, 40, "Heals 40")
                {
                   Id = 2,
                   Name = "Big Health",
                   Price = 20,
                   Effects = 30,
                   Description = "Heals 40"
                },
                new Potions(3,"huge health", 20, 50, "Heals 50")
                {
                   Id = 3,
                   Name = "Health",
                   Price = 20,
                   Effects = 30,
                   Description = "Heals 50"
                }
            };
            return potions;
        }
    
    }
}
