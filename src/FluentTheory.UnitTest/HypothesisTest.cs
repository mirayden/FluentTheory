using System.Data;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FluentTheory.UnitTest
{
	[TestClass]
	public class HypothesisTest
	{
		[TestMethod]
		public void Evaluate_HypothesisIsAlreadyEvaluated_ThrowsEvaluateException()
		{
			//Arrange
			var theory = new Theory();
			var hypothesis = new Hypothesis(theory);
			Action action = () => hypothesis.Evaluate();

			//Act
			hypothesis.Evaluate();
			action.ShouldThrow<EvaluateException>();
		}

		[TestMethod]
		public void Evaluate_ParentHypothesisIsNotEvaluated_ThrowsEvaluateException()
		{
			//Arrange
			var theory = new Theory();
			var hypothesis = new Hypothesis(theory);
			var nestedHypothesis = hypothesis.NestedHypothesis();
			Action action = () => nestedHypothesis.Evaluate();

			//Act
			action.ShouldThrow<EvaluateException>();
		}

		[TestMethod]
		public void Evaluate_ParentHypothesisEvaluatesToNonTrue_NestedHypothesisEvaluatesToNull()
		{
			//Arrange
			var theory = new Theory();
			var hypothesis = new Hypothesis(theory).Suppose(() => false);
			var nestedHypothesis = hypothesis.NestedHypothesis();

			//Assert
			Assert.AreNotEqual(hypothesis.Evaluate(), true);
			Assert.AreEqual(nestedHypothesis.Evaluate(), null);
		}

		[TestMethod]
		public void Evaluate_PreconditionsAreFulfilled_EvaluatesToBool()
		{
			//Arrange
			var theory = new Theory();
			var hypothesis = new Hypothesis(theory).Suppose(() => true).OnlyIf(h => true);

			//Assert
			Assert.AreNotEqual(hypothesis.Evaluate(), null);
		}

		[TestMethod]
		public void Evaluate_PreconditionsAreNotFulfilled_EvaluatesToNull()
		{
			//Arrange
			var theory = new Theory();
			var hypothesis = new Hypothesis(theory).Suppose(() => true).OnlyIf(h => false);

			//Assert
			Assert.AreEqual(hypothesis.Evaluate(), null);
		}
	}
}