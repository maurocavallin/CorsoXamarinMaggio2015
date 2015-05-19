using System;
using SQLite;

namespace EsempioAccessoDatiLocali
{
	public interface ISQLite {
		
		SQLiteConnection GetConnection();

	}
}

