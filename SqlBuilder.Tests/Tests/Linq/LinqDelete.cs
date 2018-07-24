﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class LinqDelete
	{

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqDeleteSimple()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			var q1 = new Delete<DataBaseDemo.Author>();
			string result = q1.GetSql();
			string sql = "DELETE FROM [tab_authors];";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqDeleteSimpleWhere()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			var q1 = new Delete<DataBaseDemo.Author>();
			q1.Where(x => x.Equal("a").IsNULL("b"));
			string result = q1.GetSql();
			string sql = "DELETE FROM [tab_authors] WHERE [a]=@a AND [b] IS NULL;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqQueryDeleteSimpleWhere()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			string result = Query<DataBaseDemo.Author>.CreateDelete().Where(x=>x.Equal("a")).GetSql();
			string sql = "DELETE FROM [tab_authors] WHERE [a]=@a;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqDeleteTableAlias()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			string result = Query<DataBaseDemo.Author>.CreateDelete("t").Where(x => x.Equal("a")).GetSql();
			string sql = "DELETE FROM [tab_authors] as [t] WHERE [t].[a]=@a;";
			Assert.AreEqual(result, sql);
		}

	}

}