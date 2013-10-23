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
	public static class TheoryValueAsExtension
	{
		public static TheoryClause<DateTime> AsDateTime(this TheoryClause<string> theoryClause)
		{
			return new TheoryClause<DateTime>(DateTime.Parse(theoryClause.Value)) { Previous = theoryClause };
		}

		public static TheoryClause<DateTime> AsDateTime(this TheoryClause<string> theoryClause, IFormatProvider formatProvider, DateTimeStyles dateTimeStyles = DateTimeStyles.None)
		{
			return new TheoryClause<DateTime>(DateTime.Parse(theoryClause.Value, formatProvider, dateTimeStyles)) { Previous = theoryClause };
		}

		public static TheoryClause<decimal> AsDecimal(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Number)
		{
			if (formatProvider == null)
			{
				return new TheoryClause<decimal>(decimal.Parse(theoryClause.Value, numberStyles)) { Previous = theoryClause };
			}
			return new TheoryClause<decimal>(decimal.Parse(theoryClause.Value, numberStyles, formatProvider)) { Previous = theoryClause };
		}

		public static TheoryClause<int> AsInt(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Integer)
		{
			if (formatProvider == null)
			{
				return new TheoryClause<int>(int.Parse(theoryClause.Value, numberStyles)) { Previous = theoryClause };
			}
			return new TheoryClause<int>(int.Parse(theoryClause.Value, numberStyles, formatProvider)) { Previous = theoryClause };
		}

		public static TheoryClause<long> AsLong(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Integer)
		{
			if (formatProvider == null)
			{
				return new TheoryClause<long>(long.Parse(theoryClause.Value, numberStyles)) { Previous = theoryClause };
			}
			return new TheoryClause<long>(long.Parse(theoryClause.Value, numberStyles, formatProvider)) { Previous = theoryClause };
		}

		public static TheoryClause<float> AsFloat(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Float)
		{
			if (formatProvider == null)
			{
				return new TheoryClause<float>(float.Parse(theoryClause.Value, numberStyles)) { Previous = theoryClause };
			}
			return new TheoryClause<float>(float.Parse(theoryClause.Value, numberStyles, formatProvider)) { Previous = theoryClause };
		}

		public static TheoryClause<double> AsDouble(this TheoryClause<string> theoryClause, IFormatProvider formatProvider = null, NumberStyles numberStyles = NumberStyles.Float | NumberStyles.AllowThousands)
		{
			if (formatProvider == null)
			{
				return new TheoryClause<double>(double.Parse(theoryClause.Value, numberStyles)) { Previous = theoryClause };
			}
			return new TheoryClause<double>(double.Parse(theoryClause.Value, numberStyles, formatProvider)) { Previous = theoryClause };
		}

		public static TheoryClause<bool> AsBool(this TheoryClause<string> theoryClause)
		{
			return new TheoryClause<bool>(bool.Parse(theoryClause.Value)) { Previous = theoryClause };
		}
	}
}