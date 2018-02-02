using System;

namespace Demo.Spa.Models {
	
	public class Note : IEquatable<Note>, IComparable<Note> {

		public int Id { get; set; }

		public string Content { get; set; }

		public int CompareTo(Note other) => Id.CompareTo(other?.Id);

		public bool Equals(Note other) => Id.Equals(other?.Id);
	}
}