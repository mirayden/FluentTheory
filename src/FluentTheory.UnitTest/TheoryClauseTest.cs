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

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace FluentTheory.UnitTest
{
	[TestClass]
	public class TheoryClauseTest
	{
		#region Properties
		private const string UnknownStringArgument = "This is unknown string argument";
		#endregion Properties


		#region Helpers
		public List<Func<bool>> CreateCheckStringFunctions(string stringArgument)
		{
			return new List<Func<bool>>
			{
				() => TheoryClause.IsBool(stringArgument),
				() => TheoryClause.IsDateTime(stringArgument),
				() => TheoryClause.IsDecimal(stringArgument),
				() => TheoryClause.IsDouble(stringArgument),
				() => TheoryClause.IsEmail(stringArgument),
				() => TheoryClause.IsFloat(stringArgument),
				() => TheoryClause.IsInt(stringArgument),
				() => TheoryClause.IsLong(stringArgument)
			};
		}

		[TestInitialize]
		public void Initialize()
		{
			//Use invariant culture to parse strings.
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		}
		#endregion Helpers


		#region Common cases
		[TestMethod]
		public void AllIsMethodsForString_StringArgumentIsNullOrEmptyString_ResultIsIncorrect()
		{
			//Arrange
			List<Func<bool>> testFunctions = CreateCheckStringFunctions(null);

			//Assert
			testFunctions.ForEach(func => Assert.IsFalse(func()));
		}

		[TestMethod]
		public void AllIsMethodsForString_StringArgumentIsUnknownString_ResultIsIncorrect()
		{
			//Arrange
			List<Func<bool>> testFunctions = CreateCheckStringFunctions(UnknownStringArgument);

			//Assert
			testFunctions.ForEach(func => Assert.IsFalse(func()));
		}
		#endregion Common cases


		#region IsBool
		[TestMethod]
		public void IsBool_BoolStringIsFalse_BoolStringIsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsBool("False"));
		}

		[TestMethod]
		public void IsBool_BoolStringIsTrue_BoolStringIsCorrect()
		{
			//Arrange
			string boolString = "True";

			//Act
			bool actual = TheoryClause.IsBool(boolString);

			//Assert
			Assert.IsTrue(actual);
		}
		#endregion IsBool


		#region IsDate
		[TestMethod]
		public void IsDate_Day1_Month1_Year1_DateIsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsDate(1, 1, 1));
		}

		[TestMethod]
		public void IsDate_Day31_Month12_Year9999_DateIsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsDate(31, 12, 9999));
		}

		[TestMethod]
		public void IsDate_DayOrMonthOrYearIsZero_DateIsIncorrect()
		{
			Assert.IsFalse(TheoryClause.IsDate(0, 1, 1));
			Assert.IsFalse(TheoryClause.IsDate(1, 0, 1));
			Assert.IsFalse(TheoryClause.IsDate(1, 1, 0));
		}

		[TestMethod]
		public void IsDate_Day29_Month2_Year2016_DateIsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsDate(29, 02, 2016));
		}

		[TestMethod]
		public void IsDate_Day29_Month2_Year2015_DateIsIncorrect()
		{
			Assert.IsFalse(TheoryClause.IsDate(29, 02, 2015));
		}
		#endregion IsDate


		#region IsDateTime
		[TestMethod]
		public void IsDateTime_DateTimeStringIs2000_12_31_DateIsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsDateTime("2000-12-31"));
		}

		[TestMethod]
		public void IsDateTime_DateTimeStringIs2000_13_31_DateIsCorrect()
		{
			Assert.IsFalse(TheoryClause.IsDateTime("2000-13-31"));
		}

		[TestMethod]
		public void IsDateTime_UseCustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-DE");
			DateTimeStyles dateTimeStyles = DateTimeStyles.AllowInnerWhite;
			string correctDateTimeString = "31 . 12 . 2000";
			string incorrectDateTimeString = "2000 - 12 - 31";
			string[] formats = { "d" };

			//Assert
			Assert.IsTrue(TheoryClause.IsDateTime(correctDateTimeString, formatProvider, dateTimeStyles, formats));
			Assert.IsFalse(TheoryClause.IsDateTime(incorrectDateTimeString, formatProvider, dateTimeStyles, formats));
		}
		#endregion IsDateTime


		#region IsDecimal
		[TestMethod]
		public void IsDecimal_DecimalStringIsMinus123_456_IsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsDecimal("-123.456"));
		}

		[TestMethod]
		public void IsDecimal_DecimalStringIsABC_IsIncorrect()
		{
			Assert.IsFalse(TheoryClause.IsDecimal("ABC"));
		}

		[TestMethod]
		public void IsDecimal_CustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctDecimalString = "123.456,78";
			string incorrectDecimalString = "123,456.78";

			//Assert
			Assert.IsTrue(TheoryClause.IsDecimal(correctDecimalString, formatProvider));
			Assert.IsFalse(TheoryClause.IsDecimal(incorrectDecimalString, formatProvider));
		}
		#endregion IsDecimal


		#region IsDouble
		[TestMethod]
		public void IsDouble_DoubleStringIsMinus1_23e2_IsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsDouble("-1.23e2"));
		}

		[TestMethod]
		public void IsDouble_DoubleStringIsABC_IsIncorrect()
		{
			Assert.IsFalse(TheoryClause.IsDouble("ABC"));
		}

		[TestMethod]
		public void IsDouble_CustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctDoubleString = "123.456,78e1";
			string incorrectDoubleString = "123,456.78e1";

			//Assert
			Assert.IsTrue(TheoryClause.IsDouble(correctDoubleString, formatProvider));
			Assert.IsFalse(TheoryClause.IsDouble(incorrectDoubleString, formatProvider));
		}
		#endregion IsDouble


		#region IsFloat
		[TestMethod]
		public void IsFloat_FloatStringIsMinus1_23_IsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsFloat("-1.23"));
		}

		[TestMethod]
		public void IsFloat_FloatStringIsABC_IsIncorrect()
		{
			Assert.IsFalse(TheoryClause.IsFloat("ABC"));
		}

		[TestMethod]
		public void IsFloat_CustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctFloatString = "123456,78";
			string incorrectFloatString = "123456.78";

			//Assert
			Assert.IsTrue(TheoryClause.IsFloat(correctFloatString, formatProvider));
			Assert.IsFalse(TheoryClause.IsFloat(incorrectFloatString, formatProvider));
		}
		#endregion IsFloat


		#region IsInt
		[TestMethod]
		public void IsInt_IntStringIsMinus123_IsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsInt("-123"));
		}

		[TestMethod]
		public void IsInt_IntStringIsABC_IsIncorrect()
		{
			Assert.IsFalse(TheoryClause.IsInt("ABC"));
		}

		[TestMethod]
		public void IsInt_CustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctIntString = "123456";
			string incorrectIntString = "123.456";

			//Assert
			Assert.IsTrue(TheoryClause.IsInt(correctIntString, formatProvider));
			Assert.IsFalse(TheoryClause.IsInt(incorrectIntString, formatProvider));
		}
		#endregion IsInt


		#region IsLong
		[TestMethod]
		public void IsLong_LongStringIsMinus111222333444_IsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsLong("-111222333444"));
		}

		[TestMethod]
		public void IsLong_LongStringIsABC_IsIncorrect()
		{
			Assert.IsFalse(TheoryClause.IsLong("ABC"));
		}

		[TestMethod]
		public void IsLong_CustomFormat_IsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctLongString = "111222333444";
			string incorrectLongString = "111.222.333.444";

			//Assert
			Assert.IsTrue(TheoryClause.IsLong(correctLongString, formatProvider));
			Assert.IsFalse(TheoryClause.IsLong(incorrectLongString, formatProvider));
		}
		#endregion IsLong


		#region IsEmail
		[TestMethod]
		public void IsEmail_EmailStringIsNameAtCompanyDotCom_IsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsEmail("name@company.com"));
		}

		[TestMethod]
		public void IsEmail_EmailStringIsFirstNameDotLastNameAtTestDotCompanyDotCom_IsCorrect()
		{
			Assert.IsTrue(TheoryClause.IsEmail("FirstName.LastName@Test.Company.com"));
		}

		[TestMethod]
		public void IsEmail_EmailStringIsNameAtCompany_IsIncorrect()
		{
			Assert.IsFalse(TheoryClause.IsEmail("name@company"));
		}

		public void IsEmail_EmailStringMyEmail_IsIncorrect()
		{
			Assert.IsFalse(TheoryClause.IsEmail("myemail"));
		}
		#endregion IsEmail


		#region Generic class test
		[TestMethod]
		public void Evaluate_ClauseIsAlreadyEvaluated_ThrowsEvaluateException()
		{
			//Arrange
			var clause = new TheoryClause<string>("", String.IsNullOrEmpty);
			Action action = () => clause.Evaluate();

			//Act
			clause.Evaluate();
			action.ShouldThrow<EvaluateException>();
		}
		#endregion Generic class test

	}
}