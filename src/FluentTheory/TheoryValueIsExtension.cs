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
using System.Globalization;

namespace FluentTheory
{
	/// <summary>
	/// Extensions to check value kind by theory clauses.
	/// </summary>
	public static class TheoryValueIsExtension
	{
		/// <summary>
		/// Checks if theory clause value is a valid email.
		/// </summary>
		/// <param name="theoryClause">Theory clause to be checked.</param>
		/// <returns>True, if theory clause value is a valid email, otherwise false.</returns>
		public static TheoryClause<string> IsEmail(this TheoryClause<string> theoryClause)
		{
			return new TheoryClause<string>(theoryClause.Value, TheoryClause.IsEmail) { Previous = theoryClause };
		}

		/// <summary>
		/// Checks if theory clause value is a valid <see cref="T:System.DateTime"/>.
		/// </summary>
		/// <param name="theoryClause">Theory clause to be checked.</param>
		/// <returns>True, if theory clause value is a valid <see cref="T:System.DateTime"/>, otherwise false.</returns>
		public static TheoryClause<string> IsDateTime(this TheoryClause<string> theoryClause)
		{
			return new TheoryClause<string>(theoryClause.Value, TheoryClause.IsDateTime) { Previous = theoryClause };
		}

		/// <summary>
		/// Checks if theory clause value is a valid <see cref="T:System.DateTime"/>.
		/// </summary>
		/// <param name="theoryClause">Theory clause to be checked.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about clause value.</param>
		/// <param name="dateTimeStyles">A bitwise combination of <see cref="T:System.Globalization.DateTimeStyles"/> enumeration values that indicates the permitted format of clause value.
		/// A typical value to specify is <see cref="F:System.Globalization.DateTimeStyles.None"/>.</param>
		/// <param name="formats">Array of allowed formats.</param>
		/// <returns>True, if theory clause value is a valid <see cref="T:System.DateTime"/>, otherwise false.</returns>
		public static TheoryClause<string> IsDateTime(this TheoryClause<string> theoryClause, IFormatProvider formatProvider, DateTimeStyles dateTimeStyles,
			params string[] formats)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsDateTime(x, formatProvider, dateTimeStyles, formats)) { Previous = theoryClause };
		}

		/// <summary>
		/// Checks if theory clause value is a valid <see cref="T:System.Decimal"/>.
		/// </summary>
		/// <param name="theoryClause">Theory clause to be checked.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about clause value.</param>
		/// <param name="numberStyles">A bitwise combination of <see cref="T:System.Globalization.NumberStyles"/> values that indicates the style elements that can be present in clause value.</param>
		/// <returns>True, if theory clause value is a valid <see cref="T:System.Decimal"/>, otherwise false.</returns>
		public static TheoryClause<string> IsDecimal(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Number)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsDecimal(x, formatProvider, numberStyles)) { Previous = theoryClause };
		}

		/// <summary>
		/// Checks if theory clause value is a valid <see cref="T:System.Int32"/>.
		/// </summary>
		/// <param name="theoryClause">Theory clause to be checked.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about clause value.</param>
		/// <param name="numberStyles">A bitwise combination of <see cref="T:System.Globalization.NumberStyles"/> values that indicates the style elements that can be present in clause value.</param>
		/// <returns>True, if theory clause value is a valid <see cref="T:System.Int32"/>, otherwise false.</returns>
		public static TheoryClause<string> IsInt(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Integer)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsInt(x, formatProvider, numberStyles)) { Previous = theoryClause };
		}

		/// <summary>
		/// Checks if theory clause value is a valid <see cref="T:System.Int64"/>.
		/// </summary>
		/// <param name="theoryClause">Theory clause to be checked.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about clause value.</param>
		/// <param name="numberStyles">A bitwise combination of <see cref="T:System.Globalization.NumberStyles"/> values that indicates the style elements that can be present in clause value.</param>
		/// <returns>True, if theory clause value is a valid <see cref="T:System.Int64"/>, otherwise false.</returns>
		public static TheoryClause<string> IsLong(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Integer)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsLong(x, formatProvider, numberStyles)) { Previous = theoryClause };
		}

		/// <summary>
		/// Checks if theory clause value is a valid <see cref="T:System.Single"/>.
		/// </summary>
		/// <param name="theoryClause">Theory clause to be checked.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about clause value.</param>
		/// <param name="numberStyles">A bitwise combination of <see cref="T:System.Globalization.NumberStyles"/> values that indicates the style elements that can be present in clause value.</param>
		/// <returns>True, if theory clause value is a valid <see cref="T:System.Single"/>, otherwise false.</returns>
		public static TheoryClause<string> IsFloat(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Float)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsFloat(x, formatProvider, numberStyles)) { Previous = theoryClause };
		}

		/// <summary>
		/// Checks if theory clause value is a valid <see cref="T:System.Double"/>.
		/// </summary>
		/// <param name="theoryClause">Theory clause to be checked.</param>
		/// <param name="formatProvider">An object that supplies culture-specific format information about clause value.</param>
		/// <param name="numberStyles">A bitwise combination of <see cref="T:System.Globalization.NumberStyles"/> values that indicates the style elements that can be present in clause value.</param>
		/// <returns>True, if theory clause value is a valid <see cref="T:System.Double"/>, otherwise false.</returns>
		public static TheoryClause<string> IsDouble(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsDouble(x, formatProvider, numberStyles)) { Previous = theoryClause };
		}

		/// <summary>
		/// Checks if theory clause value is a valid <see cref="T:System.Boolean"/>.
		/// </summary>
		/// <param name="theoryClause">Theory clause to be checked.</param>
		/// <returns>True, if theory clause value is a valid <see cref="T:System.Boolean"/>, otherwise false.</returns>
		public static TheoryClause<string> IsBool(this TheoryClause<string> theoryClause)
		{
			return new TheoryClause<string>(theoryClause.Value, TheoryClause.IsBool) { Previous = theoryClause };
		}
	}
}