using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Acme_Coporation_Unit_Tests
{
	[TestClass]
	public class UnitTest1
	{
		public enum TestEnum : long {
			One = 12329871237,
			Two = 12329871277,
			Three = 12329871317,
			Four = 12329871336,
			Five = 100,
			Six = 100000,
			Seven = 999999,
			Eight = 12329871337
		}
		[TestMethod]
		public void ValidateProductSerialNumberUnitTest()
		{
			Assert.IsTrue(Acme_Corporation_Core.App_Code.Classes.FormsCreate.ValidateProductSerialNumberUnitTest(12329871237, typeof(TestEnum)));
			Assert.IsTrue(Acme_Corporation_Core.App_Code.Classes.FormsCreate.ValidateProductSerialNumberUnitTest(12329871277, typeof(TestEnum)));
			Assert.IsTrue(Acme_Corporation_Core.App_Code.Classes.FormsCreate.ValidateProductSerialNumberUnitTest(12329871317, typeof(TestEnum)));
			Assert.IsTrue(Acme_Corporation_Core.App_Code.Classes.FormsCreate.ValidateProductSerialNumberUnitTest(12329871336, typeof(TestEnum)));
			Assert.IsFalse(Acme_Corporation_Core.App_Code.Classes.FormsCreate.ValidateProductSerialNumberUnitTest(100, typeof(TestEnum)));
			Assert.IsFalse(Acme_Corporation_Core.App_Code.Classes.FormsCreate.ValidateProductSerialNumberUnitTest(100000, typeof(TestEnum)));
			Assert.IsFalse(Acme_Corporation_Core.App_Code.Classes.FormsCreate.ValidateProductSerialNumberUnitTest(999999, typeof(TestEnum)));
			Assert.IsFalse(Acme_Corporation_Core.App_Code.Classes.FormsCreate.ValidateProductSerialNumberUnitTest(12329871337, typeof(TestEnum)));
		}
	}
}
