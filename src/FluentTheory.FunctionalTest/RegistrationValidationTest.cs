using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentTheory.FunctionalTest
{
	[TestClass]
	public class RegistrationValidationTest
	{
		[TestMethod]
		public void PasswordValidation_PasswordStringIsABC_PasswordIsTooShort()
		{
			//Assert
			string passwordString = "abc";
			string result = null;
			string expectedResult = "password is too short";

			var theory = new Theory();
			theory.Suppose(() => passwordString.Length > 8)
				.IfFalse(() => result = expectedResult)
				.IfTrue(() => result = "password is ok");

			//Act
			theory.Evaluate();

			//Assert
			Assert.AreSame(result, expectedResult);
		}

		[TestMethod]
		public void PasswordValidation_PasswordStringIsSecuredPassword123_PasswordIsSecured()
		{
			//Assert
			string passwordString;
			passwordString = "SecuredPassword123";
			int strength = 0;


			//TODO: make possible to use preconditions from previous hypothesis.
			var theory = new Theory();
			theory
				.Suppose(() => Regex.IsMatch(passwordString, "[A-Z]"))
					.WithPrecondition(h => passwordString != null)
					.IfTrue(() => strength++)
				.Suppose(() => Regex.IsMatch(passwordString, "[a-z]"))
					.WithPrecondition(h => passwordString != null)
					.IfTrue(() => strength++)
				.Suppose(() => Regex.IsMatch(passwordString, "[0-9]"))
					.WithPrecondition(h => passwordString != null)
					.IfTrue(() => strength++)
				.Suppose(() => passwordString.Length >= 8)
					.WithPrecondition(h => passwordString != null)
					.IfTrue(() => strength++);

			//Act
			theory.Evaluate();

			//Assert
			Assert.AreEqual(strength, 4);
		}

		[TestMethod]
		[Ignore]
		public void RegistrationValidation_EnteredDataIsValid_RegistrationIsCompleted() { }

		[TestMethod]
		[Ignore]
		public void RegistrationValidation_EnteredDataIsInvalid_ErrorMessageAreShown() { }
	}
}
