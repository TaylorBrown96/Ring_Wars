

using System;
using System.Collections.Generic;
using Xunit;

namespace RingWarsLibraryTests
{
	public class GetMobTestCase
	{

		[Theory]
		[ClassData(typeof(ExpectedReturnValueTests))]
		public void GetMobTest(ExpectedValueTestData<RingWarsLibrary.Mobs> data)
		{
			var actual = RingWarsLibrary.SqliteDataAccess.GetMob(data.Params.mobID);
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
			public string mobID;
		}

		public class ExpectedReturnValueTests : TheoryData<ExpectedValueTestData<RingWarsLibrary.Mobs>>
		{
			public ExpectedReturnValueTests()
			{
				this.Add(new ExpectedValueTestData<RingWarsLibrary.Mobs>
				{
					Name = @"p1",
					Params = new Parameters
					{
						mobID = "609"
					},
					ExpectedValue = null
				});
				this.Add(new ExpectedValueTestData<RingWarsLibrary.Mobs>
				{
					Name = @"p2",
					Params = new Parameters
					{
						mobID = "600"
					},
					ExpectedValue = null
				});
			}
		}

	}
}


