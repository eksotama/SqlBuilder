﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Linq;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class LinqUpdate
	{

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqUpdateSimpleWhere()
		{
			var q1 = new Update<DataBaseDemo.Author>();
			q1.Sets(x=>x.AppendValue("name", "value")).Where(x => x.Equal("a").IsNULL("b"));
			string result = q1.GetSql();
			string sql = "UPDATE [tab_authors] SET [name]=value WHERE [a]=@a AND [b] IS NULL;";
			Assert.AreEqual(result, sql);
		}

		[TestMethod]
		[TestCategory("Linq")]
		public void LinqQueryUpdateSimpleWhere()
		{
			string result = Query<DataBaseDemo.Author>.CreateUpdate().Sets(x=>x.AppendValue("count", "123")).Where(x=>x.Equal("a")).GetSql();
			string sql = "UPDATE [tab_authors] SET [count]=123 WHERE [a]=@a;";
			Assert.AreEqual(result, sql);
		}

	}

}