using System;
using System.Collections.Generic;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{

	public class ColumnsListAggregation : ColumnsList, IColumnsListAggregation
	{

		public ColumnsListAggregation(IFormatter parameters) : base(parameters)
		{
			this.Parameters = parameters;
		}

		public IColumnsListAggregation Append(IColumn expression)
		{
			if (expression == null)
				throw new ArgumentNullException(nameof(expression));

			this._expressions.Add(expression);
			return this;
		}

		public IColumnsListAggregation Append(params string[] names)
		{
			if (names == null)
				throw new ArgumentNullException(nameof(names));

			foreach (string name in names)
				this.AppendAlias(name, string.Empty);
			return this;
		}

		public IColumnsListAggregation AppendAlias(string name, string alias, string prefix = "", string postfix = "", bool isAggregation = false)
		{
			Column column = new Column()
			{
				Value = name,
				Alias = alias,
				Postfix = postfix,
				Prefix = prefix,
				IsRaw = false,
				IsAggregation = isAggregation,
				TableAlias = this.TableAlias,
			};
			this.Append(column);
			return this;
		}

		public IColumnsListAggregation RawValue(string rawSql, string alias = "")
		{
			Column column = new Column()
			{
				Value = rawSql,
				Alias = alias,
				Postfix = string.Empty,
				Prefix = string.Empty,
				IsRaw = true,
				IsAggregation = false,
			};
			this.Append(column);
			return this;
		}

		public IColumnsListAggregation Raw(params string[] rawSql)
		{
			foreach(string sql in rawSql)
			{
				this.RawValue(sql);
			}
			return this;
		}

		public IColumnsListAggregation FuncMax(string name, string aliasName = "")
		{
			this.AppendAlias(name, aliasName, "MAX(", ")", true);
			return this;
		}

		public IColumnsListAggregation FuncMin(string name, string aliasName = "")
		{
			this.AppendAlias(name, aliasName, "MIN(", ")", true);
			return this;
		}

		public IColumnsListAggregation FuncCount(string name, string aliasName = "")
		{
			this.AppendAlias(name, aliasName, "COUNT(", ")", true);
			return this;
		}

		public IColumnsListAggregation FuncSum(string name, string aliasName = "")
		{
			this.AppendAlias("*", aliasName, "SUM(", ")", true);
			return this;
		}

		public IColumnsListAggregation SetTableAlias(string tableAlias = "")
		{
			this.TableAlias = tableAlias;
			return this;
		}

	}

}