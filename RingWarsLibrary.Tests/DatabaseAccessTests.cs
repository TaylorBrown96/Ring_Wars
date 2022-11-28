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

        [Theory]
        [ClassData(typeof(ExpectedReturnValueTests))]
        public void LoadRoomMobTest(ExpectedValueTestData<List<RingWarsLibrary.LivingCreature>> data)
        {
            var actual = RingWarsLibrary.SqliteDataAccess.LoadRoomMob(data.Params.value);
            Assert.Equal(data.ExpectedValue, actual);
        }
        public struct ExpectedValueTestData<TExpected>
        {
            public string Name;
            public Parameters Params;
            public TExpected ExpectedValue;

            public override string ToString()
            {
                return $"{this.Name}";
            }
        }

        public struct Parameters
        {
            public int value;
        }
        public class ExpectedReturnValueTests : TheoryData<ExpectedValueTestData<List<RingWarsLibrary.LivingCreature>>>
        {
            public ExpectedReturnValueTests()
            {
                this.Add(new ExpectedValueTestData<List<RingWarsLibrary.LivingCreature>>
                {
                    Name = @"1",
                    Params = new Parameters
                    {
                        value = 101
                    },
                    ExpectedValue = new List<RingWarsLibrary.LivingCreature> { }
                });
                this.Add(new ExpectedValueTestData<List<RingWarsLibrary.LivingCreature>>
                {
                    Name = @"p2",
                    Params = new Parameters
                    {
                        value = 105
                    },
                    ExpectedValue = new List<RingWarsLibrary.LivingCreature> { }
                });
            }
        }

        [Fact]
        //public void TestPotionAccessCall()
        //{
            //arrange
            //List<Potions> potions = new List<Potions>(GetPotionSample());
            //SqliteDataAccess.GetPotion("1")
            ///List<Potions> result = SqliteDataAccess.GetPotion("102");
            //string expected = "health";

            //Assert.Equal(expected, result);

        //}
        
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
