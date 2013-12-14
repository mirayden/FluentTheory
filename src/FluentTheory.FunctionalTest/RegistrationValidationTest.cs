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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentTheory.FunctionalTest
{
	[TestClass]
	public class RegistrationValidationTest
	{
		#region Helpers
		[TestInitialize]
		public void Initialize()
		{
			//Use invariant culture to parse strings.
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		}
		#endregion Helpers


		[TestMethod]
		public void PasswordValidation_PasswordStringIsABC_PasswordIsTooShort()
		{
			//Assert
			string passwordString = "abc";
			string result = null;
			string expectedResult = "password is too short";

			var theory = new Theory();
			theory.Suppose(() => passwordString.Length > 8)
				.DoFalse(() => result = expectedResult)
				.DoTrue(() => result = "password is ok");

			//Act
			theory.Evaluate();

			//Assert
			Assert.AreSame(result, expectedResult);
		}

		[TestMethod]
		public void PasswordValidation_PasswordStringIsSecuredPassword123_PasswordIsSecured()
		{
			//Assert
			string passwordString = "SecuredPassword123";

			var theory = new Theory();
			theory
				.Suppose(() => passwordString != null)
					.DependendHypothesis()
						.Suppose(() =>
						{
							int strength = 0;
							strength += Regex.IsMatch(passwordString, "[A-Z]") ? 1 : 0;
							strength += Regex.IsMatch(passwordString, "[a-z]") ? 1 : 0;
							strength += Regex.IsMatch(passwordString, "[0-9]") ? 1 : 0;
							strength += passwordString.Length >= 8 ? 1 : 0;

							return strength >= 3;
						});

			//Act
			bool result = theory.Evaluate();

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void RegistrationValidation_EnteredDataIsValid_RegistrationIsCompleted()
		{
			//Assert
			string passwordString = "SecuredPassword123";
			string firstName = "John";
			string lastName = "Smith";
			string dob = "1990-01-01";
			string email = "john.Smith@nomail.com";

			var errors = new Dictionary<string, string>();
			var theory = new Theory();
			theory
				.Suppose(() => passwordString != null)
					.DependendHypothesis()
						.Suppose(() =>
						{
							int strength = 0;
							strength += Regex.IsMatch(passwordString, "[A-Z]") ? 1 : 0;
							strength += Regex.IsMatch(passwordString, "[a-z]") ? 1 : 0;
							strength += Regex.IsMatch(passwordString, "[0-9]") ? 1 : 0;
							strength += passwordString.Length >= 8 ? 1 : 0;

							return strength >= 3;
						})
						.DoFalse(() => errors.Add("password", "Password is insecured"));

			theory.Suppose(() => !string.IsNullOrEmpty(firstName))
				.DoFalse(() => errors.Add("lastName", "First name is empty."));

			theory.Suppose(() => !string.IsNullOrEmpty(lastName))
				.DoFalse(() => errors.Add("lastName", "Last name is empty."));

			theory.Suppose(() => 
				TheoryClause.Create(dob)
					.AsDateTime()
					.Is(x => x < DateTime.Now)
					.Is(x => x > DateTime.Now.AddYears(-100)))
				.DoFalse(() => errors.Add("dob", "Day of birth is incorrect."));

			theory.Suppose(() => TheoryClause.IsEmail(email))
				.DoFalse(() => errors.Add("email", "Email is incorrect."));

			theory.Evaluate()

			//Assert
			Assert.IsTrue(theory.Evaluate());
			Assert.AreEqual(0, errors.Count);
		}

		[TestMethod]
		public void RegistrationValidation_EnteredDataIsInvalid_ErrorMessageAreShown()
		{
			//Assert
			string passwordString = "weak";
			string firstName = "";
			string lastName = null;
			string dob = "1800-01-01";
			string email = "john.Smith@nomail";

			var errors = new Dictionary<string, string>();

			var theory = new Theory();
			theory
				.Hypothesis("password strength")
					.Suppose(() => {
							int strength = 0;
							strength += Regex.IsMatch(passwordString, "[A-Z]") ? 1 : 0;
							strength += Regex.IsMatch(passwordString, "[a-z]") ? 1 : 0;
							strength += Regex.IsMatch(passwordString, "[0-9]") ? 1 : 0;
							strength += passwordString.Length >= 8 ? 1 : 0;

							return strength >= 3;
						})
					.DoFalse(() => errors.Add("password", "Password is insecured"));

			theory.Suppose(() => !string.IsNullOrEmpty(firstName))
				.DoFalse(() => errors.Add("firstName", "First name is empty."));

			theory.Suppose(() => !string.IsNullOrEmpty(lastName))
				.DoFalse(() => errors.Add("lastName", "Last name is empty."));

			theory.Suppose(() =>
				TheoryClause.Create(dob)
					.AsDateTime()
					.Is(x => x < DateTime.Now)
					.Is(x => x > DateTime.Now.AddYears(-100)))
				.DoFalse(() => errors.Add("dob", "Day of birth is incorrect."));

			theory.Suppose(() => TheoryClause.IsEmail(email))
				.DoFalse(() => errors.Add("email", "Email is incorrect."));

			//Assert
			Assert.IsFalse(theory.Evaluate());
			Assert.AreEqual(5, errors.Count);
		}

		[TestMethod]
		public void EvaluateTheoryClausesOnlyIfDateIsCorrect_DateStringIsABC_TheoryClausesWereNotEvaluates()
		{
			//Arrange
			string dateString = "ABC";
			var theory = new Theory();
			var messages = new List<string>();
			theory.Hypothesis()
				.OnlyIf(x => TheoryClause.IsDateTime(dateString))
				.Suppose(() => TheoryClause.Create(dateString).AsDateTime().Is(x => x > DateTime.Now))
				.DoTrue(() => messages.Add("Date is okay"));

			//Act
			theory.Evaluate();
			int messagesCount = messages.Count;

			//Assert
			Assert.AreEqual(messagesCount, 0);
		}
	}
}