using HW2.Models;

namespace HW2
{
	public static class StaticDb
	{
		public static List<Book> Books = new List<Book>()
		{
			new Book()
			{
				Title = "The Star Wars Archives",
				Author = "Paul Duncan"
			},
			new Book()
			{
				Title = "The beginning or the end",
				Author = "Greg Mitchell"
			},
			new Book()
			{
				Title = "Conclusions",
				Author = "John Boorman"
			},
			new Book()
			{
				Title = "Made Man",
				Author = "Glenn Kenny"
			},
			new Book()
			{
				Title = "The Big Goodbye",
				Author = "Sam Wasson"
			}
		};
	}
}
