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
	/// Hypothesis is an evaluable part of a theory.
	/// </summary>
	public class Hypothesis
	{
		#region Properties
		public string Name { get; set; }

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
		/// Parent hypothesis. Is filled only by nested hypothesis.
		/// </summary>
		public Hypothesis ParentHypothesis { get; private set; }
		#endregion Properties


		#region Constructors
		/// <summary>
		/// Creates new instance.
		/// </summary>
		/// <param name="theory">Referenced theory.</param>
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
		/// Evaluation result as boolean if all preconditions are fulfilled and, in case of nested hypothesis,
		/// if parent hypothesis evaluation is true. Otherwise null.
		/// </returns>
		public bool? Evaluate()
		{
			if (IsEvaluated)
			{
				throw new EvaluateException("Hypothesis is already evaluated.");
			}

			if (ParentHypothesis != null
				&& !ParentHypothesis.IsEvaluated)
			{
				throw new EvaluateException("Can not evaluate nested hypothesis before parent hypothesis.");
			}

			IsEvaluated = true;

			if (ParentHypothesis != null
				&& ParentHypothesis.IsValid != true)
			{
				return null;
			}

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
		/// Creates nested hypothesis.
		/// </summary>
		/// <param name="hypothesisName">Name for new hypothesis.</param>
		/// <returns>New hypothesis.</returns>
		public Hypothesis NestedHypothesis(string hypothesisName = null)
		{
			var hypothesis = Theory.Hypothesis(hypothesisName);
			hypothesis.ParentHypothesis = this;
			return hypothesis;
		}

		/// <summary>
		/// Adds new precondition for hypothesis.
		/// </summary>
		/// <param name="precondition">Precondition that must be fullfilled before hypothesis evaluation.</param>
		/// <returns>Current hypothesis.</returns>
		public Hypothesis OnlyIf(Func<Hypothesis, bool> precondition )
		{
			_preconditions.Add(precondition);
			return this;
		}

		/// <summary>
		/// Adds new precondition based on <see cref="T:FluentTheory.TheoryClause`1>" /> that must be fullfilled before hypothesis evaluation.
		/// </summary>
		/// <typeparam name="TValue">Theory clause type.</typeparam>
		/// <param name="precondition">Precondition that must be fullfilled before hypothesis evaluation.</param>
		/// <returns>Current hypothesis.</returns>
		public Hypothesis OnlyIf<TValue>(Func<Hypothesis, TheoryClause<TValue>> precondition)
		{
			_preconditions.Add(h => precondition(h).Evaluate());
			return this;
		}

		/// <summary>
		/// Adds supposition into hypothesis scope.
		/// </summary>
		/// <param name="supposition">Supposition to validate current hypothesis.</param>
		/// <returns>Current hypothesis</returns>
		public Hypothesis Suppose(Func<bool> supposition)
		{
			_suppositions.Add(supposition);
			return this;
		}

		/// <summary>
		/// Adds supposition based on <see cref="T:FluentTheory.TheoryClause`1>" /> into hypothesis scope.
		/// </summary>
		/// <typeparam name="TValue">Theory clause type.</typeparam>
		/// <param name="supposition">Supposition to validate current hypothesis.</param>
		/// <returns>Current hypothesis.</returns>
		public Hypothesis Suppose<TValue>(Func<TheoryClause<TValue>> supposition)
		{
			_suppositions.Add(() => supposition().Evaluate());
			return this;
		}

		/// <summary>
		/// Add action that will be triggered once on false evaluation result.
		/// </summary>
		/// <param name="action">Action to be triggered.</param>
		/// <returns>same hypothesis</returns>
		public Hypothesis DoFalse(Action action)
		{
			_falseResultActions.Add(action);
			return this;
		}

		/// <summary>
		/// Add action that will be triggered once on true evaluation result.
		/// </summary>
		/// <param name="action">Action to be triggered.</param>
		/// <returns>same hypothesis</returns>
		public Hypothesis DoTrue(Action action)
		{
			_trueResultActions.Add(action);
			return this;
		}
		#endregion Interface
	}
}