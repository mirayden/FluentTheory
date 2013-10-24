using FluentTheory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace FluentTheory.UnitTest
{
	[TestClass]
	public class TheoryValueAsExtensionTest
	{
		[TestMethod]
		public void AsBoolTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			TheoryClause<bool> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<bool> actual;
			actual = TheoryValueAsExtension.AsBool(theoryClause);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod]
		public void AsDateTimeTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			TheoryClause<DateTime> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<DateTime> actual;
			actual = TheoryValueAsExtension.AsDateTime(theoryClause);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod]
		public void AsDateTimeTest1()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			DateTimeStyles dateTimeStyles = new DateTimeStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<DateTime> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<DateTime> actual;
			actual = TheoryValueAsExtension.AsDateTime(theoryClause, formatProvider, dateTimeStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod]
		public void AsDecimalTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			NumberStyles numberStyles = new NumberStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<Decimal> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<Decimal> actual;
			actual = TheoryValueAsExtension.AsDecimal(theoryClause, formatProvider, numberStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod]
		public void AsDoubleTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			NumberStyles numberStyles = new NumberStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<double> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<double> actual;
			actual = TheoryValueAsExtension.AsDouble(theoryClause, formatProvider, numberStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod]
		public void AsFloatTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			NumberStyles numberStyles = new NumberStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<float> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<float> actual;
			actual = TheoryValueAsExtension.AsFloat(theoryClause, formatProvider, numberStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod]
		public void AsIntTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			NumberStyles numberStyles = new NumberStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<int> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<int> actual;
			actual = TheoryValueAsExtension.AsInt(theoryClause, formatProvider, numberStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		[TestMethod]
		public void AsLongTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			NumberStyles numberStyles = new NumberStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<long> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<long> actual;
			actual = TheoryValueAsExtension.AsLong(theoryClause, formatProvider, numberStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
