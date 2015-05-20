using System;
using SQLite; 

namespace Accessoaidati
{
	public class TodoItem : NotifyPropertyChangedViewModel
	{
		public TodoItem ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		private string _name = "";

		public string Name { get{ return _name; } set{ _name = value; OnPropertyChanged(); } }

		public string Notes { get; set; }

		public bool Done { get; set; }
	}
}

