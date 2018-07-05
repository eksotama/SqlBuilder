namespace SqlBuilder.Interfaces
{

	public interface IGroupBy
	{

		string Column { get; set; }

		string TableAlias { get; set; }

		bool IsRaw { get; set; }

	}

}