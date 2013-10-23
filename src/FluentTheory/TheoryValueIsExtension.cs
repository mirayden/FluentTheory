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
	public static class TheoryValueIsExtension
	{
		public static TheoryClause<string> IsEmail(this TheoryClause<string> theoryClause)
		{
			return new TheoryClause<string>(theoryClause.Value, TheoryClause.IsEmail) { Previous = theoryClause };
		}

		public static TheoryClause<string> IsDateTime(this TheoryClause<string> theoryClause)
		{
			return new TheoryClause<string>(theoryClause.Value, TheoryClause.IsDateTime) { Previous = theoryClause };
		}

		public static TheoryClause<string> IsDateTime(this TheoryClause<string> theoryClause, IFormatProvider formatProvider, DateTimeStyles dateTimeStyles,
			params string[] formats)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsDateTime(x, formatProvider, dateTimeStyles, formats)) { Previous = theoryClause };
		}

		public static TheoryClause<string> IsDecimal(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Number)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsDecimal(x, formatProvider, numberStyles)) { Previous = theoryClause };
		}

		public static TheoryClause<string> IsInt(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Integer)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsInt(x, formatProvider, numberStyles)) { Previous = theoryClause };
		}

		public static TheoryClause<string> IsLong(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Integer)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsLong(x, formatProvider, numberStyles)) { Previous = theoryClause };
		}

		public static TheoryClause<string> IsFloat(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Float)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsFloat(x, formatProvider, numberStyles)) { Previous = theoryClause };
		}

		public static TheoryClause<string> IsDouble(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
		{
			return new TheoryClause<string>(theoryClause.Value, x => TheoryClause.IsDouble(x, formatProvider, numberStyles)) { Previous = theoryClause };
		}

		public static TheoryClause<string> IsBool(this TheoryClause<string> theoryClause)
		{
			return new TheoryClause<string>(theoryClause.Value, TheoryClause.IsBool) { Previous = theoryClause };
		}
	}
}