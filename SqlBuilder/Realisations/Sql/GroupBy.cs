using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Enums;
using SqlBuilder.Interfaces;

namespace SqlBuilder.Sql
{

	public class GroupBy : IGroupBy
	{

		public string Column { get; set; }

		public string TableAlias { get; set; }

		public bool IsRaw { get; set; }

		public GroupBy(string column, string tableAlias = "")
		{
			this.Column = column;
			this.TableAlias = tableAlias;
		}

	}

}