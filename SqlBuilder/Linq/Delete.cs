﻿using System;
using SqlBuilder;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Linq
{

	public static partial class Linq
	{

		public static IStatementDelete Where(this IStatementDelete q, Func<IWhereList, IWhereList> f)
		{
			f.Invoke(q.Where);
			return q;
		}

	}

}