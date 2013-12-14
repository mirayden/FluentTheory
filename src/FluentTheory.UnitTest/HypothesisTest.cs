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
			var nestedHypothesis = hypothesis.DependendHypothesis();
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
			var nestedHypothesis = hypothesis.DependendHypothesis();

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