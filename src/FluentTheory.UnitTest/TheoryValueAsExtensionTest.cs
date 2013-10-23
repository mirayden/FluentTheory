using FluentTheory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace FluentTheory.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for TheoryValueAsExtensionTest and is intended
    ///to contain all TheoryValueAsExtensionTest Unit Tests
    ///</summary>
	[TestClass]
	public class TheoryValueAsExtensionTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for AsBool
		///</summary>
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

		/// <summary>
		///A test for AsDateTime
		///</summary>
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

		/// <summary>
		///A test for AsDateTime
		///</summary>
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

		/// <summary>
		///A test for AsDecimal
		///</summary>
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

		/// <summary>
		///A test for AsDouble
		///</summary>
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

		/// <summary>
		///A test for AsFloat
		///</summary>
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

		/// <summary>
		///A test for AsInt
		///</summary>
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

		/// <summary>
		///A test for AsLong
		///</summary>
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
