﻿using System;
using System.Collections.Generic;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{

	public class ColumnsListSimple : ColumnsList, IColumnsListSimple
	{

		public ColumnsListSimple(IFormatter parameters) : base(parameters)
		{
			this.Parameters = parameters;
		}

		public IColumnsListSimple Append(IColumn expression)
		{
			if (expression == null)
				throw new ArgumentNullException(nameof(expression));

			this._expressions.Add(expression);
			return this;
		}

		public IColumnsListSimple Append(params string[] names)
		{
			if (names == null)
				throw new ArgumentNullException(nameof(names));

			foreach (string name in names)
				this.AppendAlias(name, string.Empty);
			return this;
		}

		public IColumnsListSimple AppendAlias(string name, string alias, string prefix = "", string postfix = "", bool isAggregation = false)
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

		public IColumnsListSimple RawValue(string rawSql, string alias = "")
		{
			Column column = new Column()
			{
				Value = rawSql,
				Alias = alias,
				Postfix = string.Empty,
				Prefix = string.Empty,
				IsRaw = true,
				IsAggregation = false,
				TableAlias = string.Empty,
			};
			this.Append(column);
			return this;
		}

		public IColumnsListSimple Raw(params string[] rawSql)
		{
			foreach(string sql in rawSql)
			{
				this.RawValue(sql);
			}
			return this;
		}

		public IColumnsListSimple SetTableAlias(string tableAlias = "")
		{
			this.TableAlias = tableAlias;
			return this;
		}

	}

}