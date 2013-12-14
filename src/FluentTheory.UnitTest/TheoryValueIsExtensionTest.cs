#region License
// Copyright 2013 Andrey Mir
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
// 
// http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
#endregion License

using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace FluentTheory.UnitTest
{
	[TestClass]
	public class TheoryValueIsExtensionTest
	{
		#region Helpers
		[TestInitialize]
		public void Initialize()
		{
			//Use invariant culture to parse strings.
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		}
		#endregion Helpers


		#region IsBool
		[TestMethod]
		public void IsBool_ClauseValueIsValidBoolean_ReturnsTrue()
		{
			//Assert
			Assert.IsTrue(new TheoryClause<string>("true").IsBool().Evaluate());
			Assert.IsTrue(new TheoryClause<string>("TRUE").IsBool().Evaluate());
			Assert.IsTrue(new TheoryClause<string>("false").IsBool().Evaluate());
			Assert.IsTrue(new TheoryClause<string>("FALSE").IsBool().Evaluate());
		}

		[TestMethod]
		public void IsBool_ClauseValueIsInvalidBoolean_ReturnsFalse()
		{
			//Assert
			Assert.IsFalse(new TheoryClause<string>("wrong string").IsBool().Evaluate());
		}
		#endregion IsBool


		#region IsDateTime
		[TestMethod]
		public void IsDateTime_ValidDateTime_ReturnsTrue()
		{
			//Assert
			Assert.IsTrue(new TheoryClause<string>("2013-01-01 23:59:59 -0100").IsDateTime().Evaluate());
		}

		[TestMethod]
		public void IsDateTime_InvalidDateTime_ReturnsFalse()
		{
			//Assert
			Assert.IsFalse(new TheoryClause<string>("Wrong Date Time").IsDateTime().Evaluate());
		}

		[TestMethod]
		public void IsDateTime_CustomFormatAndValidDate_ReturnsTrue()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-DE");
			DateTimeStyles dateTimeStyles = DateTimeStyles.AllowInnerWhite;
			string[] formats = { "d" };

			//Assert
			Assert.IsTrue(new TheoryClause<string>("31 . 12 . 2000").IsDateTime(formatProvider, dateTimeStyles, formats).Evaluate());
		}

		[TestMethod]
		public void IsDateTime_CustomFormatAndInvalidDate_ReturnsFalse()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-DE");
			DateTimeStyles dateTimeStyles = DateTimeStyles.AllowInnerWhite;
			string[] formats = { "d" };

			//Assert
			Assert.IsFalse(new TheoryClause<string>("2000 - 12 - 31").IsDateTime(formatProvider, dateTimeStyles, formats).Evaluate());
		}
		#endregion IsDateTime


		#region IsDecimal
		[TestMethod]
		public void IsDecimal_DecimalStringIsMinus123_456_ReturnsTrue()
		{
			Assert.IsTrue(new TheoryClause<string>("-123.456").IsDecimal().Evaluate());
		}

		[TestMethod]
		public void IsDecimal_DecimalStringIsABC_ReturnsFalse()
		{
			Assert.IsFalse(new TheoryClause<string>("ABC").IsDecimal().Evaluate());
		}

		[TestMethod]
		public void IsDecimal_CustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctDecimalString = "123.456,78";
			string incorrectDecimalString = "123,456.78";

			//Assert
			Assert.IsTrue(new TheoryClause<string>(correctDecimalString).IsDecimal(formatProvider).Evaluate());
			Assert.IsFalse(new TheoryClause<string>(incorrectDecimalString).IsDecimal(formatProvider).Evaluate());
		}
		#endregion IsDecimal


		#region IsDouble
		[TestMethod]
		public void IsDouble_DoubleStringIsMinus1_23e2_ReturnsTrue()
		{
			Assert.IsTrue(new TheoryClause<string>("-1.23e2").IsDouble().Evaluate());
		}

		[TestMethod]
		public void IsDouble_DoubleStringIsABC_ReturnsFalse()
		{
			Assert.IsFalse(new TheoryClause<string> ("ABC").IsDouble().Evaluate());
		}

		[TestMethod]
		public void IsDouble_CustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctDoubleString = "123.456,78e1";
			string incorrectDoubleString = "123,456.78e1";

			//Assert
			Assert.IsTrue(new TheoryClause<string> (correctDoubleString).IsDouble(formatProvider).Evaluate());
			Assert.IsFalse(new TheoryClause<string> (incorrectDoubleString).IsDouble(formatProvider).Evaluate());
		}
		#endregion IsDouble


		#region IsFloat
		[TestMethod]
		public void IsFloat_FloatStringIsMinus1_23_ReturnsTrue()
		{
			Assert.IsTrue(new TheoryClause<string> ("-1.23").IsFloat().Evaluate());
		}

		[TestMethod]
		public void IsFloat_FloatStringIsABC_ReturnsFalse()
		{
			Assert.IsFalse(new TheoryClause<string> ("ABC").IsFloat().Evaluate());
		}

		[TestMethod]
		public void IsFloat_CustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctFloatString = "123456,78";
			string incorrectFloatString = "123456.78";

			//Assert
			Assert.IsTrue(new TheoryClause<string> (correctFloatString).IsFloat(formatProvider).Evaluate());
			Assert.IsFalse(new TheoryClause<string> (incorrectFloatString).IsFloat(formatProvider).Evaluate());
		}
		#endregion IsFloat


		#region IsInt
		[TestMethod]
		public void IsInt_IntStringIsMinus123_ReturnsTrue()
		{
			Assert.IsTrue(new TheoryClause<string> ("-123").IsInt().Evaluate());
		}

		[TestMethod]
		public void IsInt_IntStringIsABC_ReturnsFalse()
		{
			Assert.IsFalse(new TheoryClause<string> ("ABC").IsInt().Evaluate());
		}

		[TestMethod]
		public void IsInt_CustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctIntString = "123456";
			string incorrectIntString = "123.456";

			//Assert
			Assert.IsTrue(new TheoryClause<string> (correctIntString).IsInt(formatProvider).Evaluate());
			Assert.IsFalse(new TheoryClause<string> (incorrectIntString).IsInt(formatProvider).Evaluate());
		}
		#endregion IsInt


		#region IsLong
		[TestMethod]
		public void IsLong_LongStringIsMinus111222333444_ReturnsTrue()
		{
			Assert.IsTrue(new TheoryClause<string>("-111222333444").IsLong().Evaluate());
		}

		[TestMethod]
		public void IsLong_LongStringIsABC_ReturnsFalse()
		{
			Assert.IsFalse(new TheoryClause<string> ("ABC").IsLong().Evaluate());
		}

		[TestMethod]
		public void IsLong_CustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctLongString = "111222333444";
			string incorrectLongString = "111.222.333.444";

			//Assert
			Assert.IsTrue(new TheoryClause<string> (correctLongString).IsLong(formatProvider).Evaluate());
			Assert.IsFalse(new TheoryClause<string> (incorrectLongString).IsLong(formatProvider).Evaluate());
		}
		#endregion IsLong


		#region IsEmail
		[TestMethod]
		public void IsEmail_EmailStringIsNameAtCompanyDotCom_ReturnsTrue()
		{
			Assert.IsTrue(new TheoryClause<string>("name@company.com").IsEmail().Evaluate());
		}

		[TestMethod]
		public void IsEmail_EmailStringIsFirstNameDotLastNameAtTestDotCompanyDotCom_ReturnsTrue()
		{
			Assert.IsTrue(new TheoryClause<string>("FirstName.LastName@Test.Company.com").IsEmail().Evaluate());
		}

		[TestMethod]
		public void IsEmail_EmailStringIsNameAtCompany_ReturnsFalse()
		{
			Assert.IsFalse(new TheoryClause<string>("name@company").IsEmail().Evaluate());
		}

		public void IsEmail_EmailStringMyEmail_ReturnsFalse()
		{
			Assert.IsFalse(new TheoryClause<string>("myemail").IsEmail().Evaluate());
		}
		#endregion IsEmail
	}
}