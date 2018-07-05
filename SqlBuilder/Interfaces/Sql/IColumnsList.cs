using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Interfaces
{

	public interface IColumnsList
	{

		IFormatter Parameters { get; }

		IEnumerable<IColumn> Expressions { get; }

		string GetSql(string tableAlias = "");

		int Count { get; }

		void Clear();

		string TableAlias { get; set; }

	}

	public interface IColumnsList<out T> where T: IColumnsList
	{

		T Append(IColumn expression);

		T Append(params string[] names);

		T AppendAlias(string name, string alias, string prefix = "", string postfix = "");

		T Raw(string rawSql, string alias = "");

		T Raw(params string[] rawSql);

		T SetTableAlias(string tableAlias = "");

	}

	public interface IColumnsListSimple : IColumnsList, IColumnsList<IColumnsListSimple>
	{
	}

	public interface IColumnsListAggregation : IColumnsList, IColumnsList<IColumnsListAggregation>, IAggregateFunctions<IColumnsListAggregation>
	{
	}

}