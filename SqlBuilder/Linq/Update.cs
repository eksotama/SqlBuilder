using System;
using SqlBuilder;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Linq
{

	public static partial class Linq
	{

		public static IStatementUpdate Where(this IStatementUpdate q, Func<IWhereList, IWhereList> f)
		{
			f.Invoke(q.Where);
			return q;
		}

		public static IStatementUpdate Sets(this IStatementUpdate q, Func<ISetList, ISetList> f)
		{
			f.Invoke(q.Sets);
			return q;
		}

	}

}