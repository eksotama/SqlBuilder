using System.Collections.Generic;

namespace SqlBuilder.Interfaces
{

	public interface IOrderByList
	{

		IFormatter Parameters { get; }

		IEnumerable<IOrderBy> Expressions { get; }

		string GetSql(string tableAlias = "");

		int Count { get; }

		void Clear();

		IOrderByList Append(IOrderBy expression);

		IOrderByList Raw(string rawSql);

		IOrderByList Ascending(params string[] columns);

		IOrderByList AscendingValue(string column, string tableAlias);

		IOrderByList Descending(params string[] columns);

		IOrderByList DescendingValue(string column, string tableAlias);

	}

}