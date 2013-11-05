using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using FluentAssertions;

namespace FluentTheory.UnitTest
{
	[TestClass]
	public class TheoryValueAsExtensionTest
	{
		#region Helpers
		[TestInitialize]
		public void Initialize()
		{
			//Use invariant culture to parse strings.
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		}
		#endregion Helpers


		#region AsBool
		[TestMethod]
		public void AsBool_StringValueAsValidBoolean_HasBoolValue()
		{
			//Assert
			Assert.IsInstanceOfType(new TheoryClause<string>("true").AsBool().Value, typeof(bool));
			Assert.IsInstanceOfType(new TheoryClause<string>("false").AsBool().Value, typeof(bool));
		}

		[TestMethod]
		public void AsBool_StringValueAsInvalidBoolean_ThrowsFormatException()
		{
			//Assert
			Action action = () => { var temp = new TheoryClause<string>("wrong string").AsBool().Value; };

			//Act
			action.ShouldThrow<FormatException>();
		}
		#endregion AsBool


		#region AsDateTime
		[TestMethod]
		public void AsDateTime_StringValueAsValidDateTime_HasDateTimeValue()
		{
			//Assert
			Assert.IsInstanceOfType(new TheoryClause<string>("2013-01-01 23:59:59 -0100").AsDateTime().Value, typeof(DateTime));
		}

		[TestMethod]
		public void AsDateTime_StringValueAsInvalidDateTime_ThrowsFormatException()
		{
			//Assert
			Action action = () => { var temp = new TheoryClause<string>("Wrong Date Time").AsDateTime().Value; };

			//Act
			action.ShouldThrow<FormatException>();
		}

		[TestMethod]
		public void AsDateTime_CustomFormatAndValidDate_HasDateTimeValue()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-DE");
			DateTimeStyles dateTimeStyles = DateTimeStyles.AllowInnerWhite;
			string[] formats = { "d" };

			//Assert
			Assert.IsInstanceOfType(new TheoryClause<string>("31 . 12 . 2000").AsDateTime(formatProvider, dateTimeStyles, formats).Value, typeof(DateTime));
		}

		[TestMethod]
		public void AsDateTime_CustomFormatAndInvalidDate_ThrowsDException()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-DE");
			DateTimeStyles dateTimeStyles = DateTimeStyles.AllowInnerWhite;
			string[] formats = { "d" };
			Action action = () => { var temp = new TheoryClause<string>("2000 - 12 - 31").AsDateTime(formatProvider, dateTimeStyles, formats).Value; };

			//Act
			action.ShouldThrow<FormatException>();
		}
		#endregion AsDateTime


		#region AsDecimal
		[TestMethod]
		public void AsDecimal_DecimalStringAsMinus123_456_HasDecimalValue()
		{
			Assert.IsInstanceOfType(new TheoryClause<string>("-123.456").AsDecimal().Value, typeof(decimal));
		}

		[TestMethod]
		public void AsDecimal_DecimalStringAsABC_ThrowsFormatException()
		{
			//Assert
			Action action = () => { var temp = new TheoryClause<string>("ABC").AsDecimal().Value; };

			//Act
			action.ShouldThrow<FormatException>();
		}

		[TestMethod]
		public void AsDecimal_CustomFormat_AsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctDecimalString = "123.456,78";

			//Assert
			Assert.IsInstanceOfType(new TheoryClause<string>(correctDecimalString).AsDecimal(formatProvider).Value, typeof(decimal));
		}
		#endregion AsDecimal


		#region AsDouble
		[TestMethod]
		public void AsDouble_DoubleStringAsMinus1_23e2_AsCorrect()
		{
			Assert.IsInstanceOfType(new TheoryClause<string>("-1.23e2").AsDouble().Value, typeof(double));
		}

		[TestMethod]
		public void AsDouble_DoubleStringAsABC_ThrowsFormatException()
		{
			//Assert
			Action action = () => { var temp = new TheoryClause<string>("ABC").AsDouble().Value; };

			//Act
			action.ShouldThrow<FormatException>();
		}

		[TestMethod]
		public void AsDouble_CustomFormat_AsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctDoubleString = "123.456,78e1";

			//Assert
			Assert.IsInstanceOfType(new TheoryClause<string>(correctDoubleString).AsDouble(formatProvider).Value, typeof(double));
		}
		#endregion AsDouble


		#region AsFloat
		[TestMethod]
		public void AsFloat_FloatStringAsMinus1_23_AsCorrect()
		{
			Assert.IsInstanceOfType(new TheoryClause<string>("-1.23").AsFloat().Value, typeof(float));
		}

		[TestMethod]
		public void AsFloat_FloatStringAsABC_ThrowsFormatException()
		{
			//Assert
			Action action = () => { var temp = new TheoryClause<string>("ABC").AsFloat().Value; };

			//Act
			action.ShouldThrow<FormatException>();
		}

		[TestMethod]
		public void AsFloat_CustomFormat_AsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctFloatString = "123456,78";

			//Assert
			Assert.IsInstanceOfType(new TheoryClause<string>(correctFloatString).AsFloat(formatProvider).Value, typeof(float));
		}
		#endregion AsFloat


		#region AsInt
		[TestMethod]
		public void AsInt_IntStringAsMinus123_AsCorrect()
		{
			Assert.IsInstanceOfType(new TheoryClause<string>("-123").AsInt().Value, typeof(int));
		}

		[TestMethod]
		public void AsInt_IntStringAsABC_ThrowsFormatException()
		{
			//Assert
			Action action = () => { var temp = new TheoryClause<string>("ABC").AsInt().Value; };

			//Act
			action.ShouldThrow<FormatException>();
		}

		[TestMethod]
		public void AsInt_CustomFormat_AsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctIntString = "123456";

			//Assert
			Assert.IsInstanceOfType(new TheoryClause<string>(correctIntString).AsInt(formatProvider).Value, typeof(int));
		}
		#endregion AsInt


		#region AsLong
		[TestMethod]
		public void AsLong_LongStringAsMinus111222333444_AsCorrect()
		{
			Assert.IsInstanceOfType(new TheoryClause<string>("-111222333444").AsLong().Value, typeof(long));
		}

		[TestMethod]
		public void AsLong_LongStringAsABC_ThrowsFormatException()
		{
			//Assert
			Action action = () => { var temp = new TheoryClause<string>("ABC").AsLong().Value; };

			//Act
			action.ShouldThrow<FormatException>();
		}

		[TestMethod]
		public void AsLong_CustomFormat_AsExecuted()
		{
			//Arrange
			IFormatProvider formatProvider = new CultureInfo("de-De");
			string correctLongString = "111222333444";

			//Assert
			Assert.IsInstanceOfType(new TheoryClause<string>(correctLongString).AsLong(formatProvider).Value, typeof(long));
		}
		#endregion AsLong
	}
}
