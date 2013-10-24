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
using System.Linq;

namespace FluentTheory
{
	/// <summary>
	/// Hypothesis is a part of theory.
	/// </summary>
	public class Hypothesis
	{
		#region Properties
		private readonly List<Func<bool>> _suppositions;

		private readonly List<Action> _falseResultActions;

		private readonly List<Action> _trueResultActions;

		private readonly List<Func<Hypothesis, bool>> _preconditions;

		/// <summary>
		/// Referenced theory.
		/// </summary>
		public Theory Theory { get; private set; }

		/// <summary>
		/// Is hypothesis already evaluated.
		/// </summary>
		public bool IsEvaluated { get; private set; }

		/// <summary>
		/// Is evaluation valid.
		/// </summary>
		public bool? IsValid { get; private set; }

		/// <summary>
		/// Parent hypothesis. Is set only if this hypothesis is created from anothe hypothesis.
		/// </summary>
		public Hypothesis ParentHypothesis { get; private set; }
		#endregion Properties


		#region Constructors
		public Hypothesis(Theory theory)
		{
			_falseResultActions = new List<Action>();
			_trueResultActions = new List<Action>();
			_suppositions = new List<Func<bool>>();
			_preconditions = new List<Func<Hypothesis, bool>>();
			Theory = theory;
		}
		#endregion Constructors


		#region Interface
		/// <summary>
		/// Evaluates hypothesis.
		/// </summary>
		/// <returns>
		/// true or false, if hypothesis is true or false.
		/// null, if preconditions are not fulfilled.
		/// </returns>
		public bool? Evaluate()
		{
			if (IsEvaluated)
			{
				throw new EvaluateException("Hypothesis is already evaluated.");
			}

			IsEvaluated = true;

			if (_preconditions.Any(precondition => !precondition(this))) {
				return null;
			}

			foreach (Func<bool> supposition in _suppositions)
			{
				if (!supposition())
				{
					IsValid = false;
					_falseResultActions.ForEach(x => x());
					return false;
				}
			}

			_trueResultActions.ForEach(x => x());
			IsValid = true;
			return true;
		}

		/// <summary>
		/// Creates dependent hypothesis
		/// </summary>
		/// <param name="hypothesisName">Name for new hypothesis.</param>
		/// <returns>new hypothesis</returns>
		public Hypothesis DependentHypothesis(string hypothesisName = null)
		{
			var hypothesis = Theory.Hypothesis(hypothesisName);
			hypothesis.ParentHypothesis = this;
			return hypothesis;
		}

		/// <summary>
		/// Adds precondition that needs to be fullfilled to allow hypothesis be evaluated.
		/// </summary>
		/// <param name="precondition"></param>
		/// <returns></returns>
		public Hypothesis WithPrecondition(Func<Hypothesis, bool> precondition )
		{
			_preconditions.Add(precondition);
			return this;
		}

		/// <summary>
		/// Adds suppositions to proove hypothesis.
		/// </summary>
		/// <param name="supposition">Supposition to prove hypothesis.</param>
		/// <returns>same hypothesis</returns>
		public Hypothesis Suppose(Func<bool> supposition)
		{
			_suppositions.Add(supposition);
			return this;
		}

		/// <summary>
		/// Adds suppositions to proove hypothesis.
		/// </summary>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="supposition">Supposition to prove hypothesis.</param>
		/// <returns>same hypothesis</returns>
		public Hypothesis Suppose<TValue>(Func<TheoryClause<TValue>> supposition)
		{
			_suppositions.Add(() => supposition().Evaluate());
			return this;
		}

		/// <summary>
		/// Add action that will be triggered on hypothesis evaluation if evaluation is true.
		/// </summary>
		/// <param name="action"></param>
		/// <returns>same hypothesis</returns>
		public Hypothesis IfFalse(Action action)
		{
			_falseResultActions.Add(action);
			return this;
		}

		/// <summary>
		/// Add action that will be triggered on hypothesis evaluation if evaluation is false.
		/// </summary>
		/// <param name="action"></param>
		/// <returns>same hypothesis</returns>
		public Hypothesis IfTrue(Action action)
		{
			_trueResultActions.Add(action);
			return this;
		}
		#endregion Interface
	}
}