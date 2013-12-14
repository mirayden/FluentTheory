FluentTheory
============

FluentTheory is a .NET library that allows to define and to evaluate theories.
Theory is build upon hypothese whereas each hypothesis contains assumptions. By theory evaluation all
hypothesis will be evaluated as well. Theory is true if no one hypothesie is evaluated to false.

Example:

	//New user registration
	var errors = new Dictionary<string, string>();
	var userDataIsValid = new Theory();
	userDataIsValid
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

	userDataIsValid.Suppose(() => !string.IsNullOrEmpty(firstName))
		.DoFalse(() => errors.Add("lastName", "First name is empty."));

	userDataIsValid.Suppose(() => !string.IsNullOrEmpty(lastName))
		.DoFalse(() => errors.Add("lastName", "Last name is empty."));

	userDataIsValid.Suppose(() => 
		userDataIsValidClause.Create(dob)
			.AsDateTime()
			.Is(x => x < DateTime.Now)
			.Is(x => x > DateTime.Now.AddYears(-100)))
		.DoFalse(() => errors.Add("dob", "Day of birth is incorrect."));

	userDataIsValid.Suppose(() => TheoryClause.IsEmail(email))
		.DoFalse(() => errors.Add("email", "Email is incorrect."));

	if(userDataIsValid.Evaluate())
	{
		//Register user.
	}
	else
	{
		//Show errors.
	}

This project is licensed under the Apache License 2.0 
http://www.apache.org/licenses/LICENSE-2.0