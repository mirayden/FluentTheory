using FluentTheory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace FluentTheory.UnitTest
{


	/// <summary>
	///This is a test class for TheoryValueIsExtensionTest and is intended
	///to contain all TheoryValueIsExtensionTest Unit Tests
	///</summary>
	[TestClass()]
	public class TheoryValueIsExtensionTest
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
		///A test for IsBool
		///</summary>
		[TestMethod()]
		public void IsBoolTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> actual;
			actual = TheoryValueIsExtension.IsBool(theoryClause);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IsDateTime
		///</summary>
		[TestMethod()]
		public void IsDateTimeTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> actual;
			actual = TheoryValueIsExtension.IsDateTime(theoryClause);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IsDateTime
		///</summary>
		[TestMethod()]
		public void IsDateTimeTest1()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			DateTimeStyles dateTimeStyles = new DateTimeStyles(); // TODO: Initialize to an appropriate value
			string[] formats = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> actual;
			actual = TheoryValueIsExtension.IsDateTime(theoryClause, formatProvider, dateTimeStyles, formats);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IsDecimal
		///</summary>
		[TestMethod()]
		public void IsDecimalTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			NumberStyles numberStyles = new NumberStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<string> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> actual;
			actual = TheoryValueIsExtension.IsDecimal(theoryClause, formatProvider, numberStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IsDouble
		///</summary>
		[TestMethod()]
		public void IsDoubleTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			NumberStyles numberStyles = new NumberStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<string> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> actual;
			actual = TheoryValueIsExtension.IsDouble(theoryClause, formatProvider, numberStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IsEmail
		///</summary>
		[TestMethod()]
		public void IsEmailTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> actual;
			actual = TheoryValueIsExtension.IsEmail(theoryClause);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IsFloat
		///</summary>
		[TestMethod()]
		public void IsFloatTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			NumberStyles numberStyles = new NumberStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<string> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> actual;
			actual = TheoryValueIsExtension.IsFloat(theoryClause, formatProvider, numberStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IsInt
		///</summary>
		[TestMethod()]
		public void IsIntTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			NumberStyles numberStyles = new NumberStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<string> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> actual;
			actual = TheoryValueIsExtension.IsInt(theoryClause, formatProvider, numberStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IsLong
		///</summary>
		[TestMethod()]
		public void IsLongTest()
		{
			TheoryClause<string> theoryClause = null; // TODO: Initialize to an appropriate value
			IFormatProvider formatProvider = null; // TODO: Initialize to an appropriate value
			NumberStyles numberStyles = new NumberStyles(); // TODO: Initialize to an appropriate value
			TheoryClause<string> expected = null; // TODO: Initialize to an appropriate value
			TheoryClause<string> actual;
			actual = TheoryValueIsExtension.IsLong(theoryClause, formatProvider, numberStyles);
			Assert.AreEqual(expected, actual);
			Assert.Inconclusive("Verify the correctness of this test method.");
		}
	}
}
