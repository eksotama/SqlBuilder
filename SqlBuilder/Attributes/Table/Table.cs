﻿using System;

namespace SqlBuilder.Attributes
{

	public class TableNameAttribute : Attribute
	{

		public string TableName { get; set; }

		public TableNameAttribute(string TableName)
		{
			this.TableName = TableName;
		}

		public override string ToString()
		{
			return this.TableName;
		}

	}

}