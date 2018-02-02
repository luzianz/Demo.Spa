using System.Collections.Generic;

namespace Demo.Spa.Models {

	public static class Extensions {

		public static void AddMockData(this ICollection<Note> notes) {
			notes.Add(new Note { Id = 1, Content = "First" });
			notes.Add(new Note { Id = 2, Content = "Second" });
			notes.Add(new Note { Id = 3, Content = "Third" });
		}
	}
}