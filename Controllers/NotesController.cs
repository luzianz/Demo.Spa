using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Spa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Spa.Controllers {

	[Route("api/[controller]")]
	public class NotesController : ControllerBase {

		private readonly IList<Note> notes;

		public NotesController(IList<Note> notes) => this.notes = notes ??
			throw new ArgumentNullException(nameof(notes));

		[HttpGet]
		public IEnumerable<Note> GetNotes([FromQuery] int? after = null) {
			if (after.HasValue) {
				return notes.Where(n => n.Id > after.Value);
			} else {
				return notes;
			}
		}

		[HttpGet("{id}", Name = "GetNote")]
		public IActionResult GetNote(int id) {
			var note = notes.FirstOrDefault(n => n.Id == id);
			if (note != null) {
				return Ok(note);
			} else {
				return NotFound();
			}
		}

		[HttpPost]
		public IActionResult AddNote([FromBody] Note note) {
			if (ModelState.IsValid) {
				note.Id = notes.Max(n => n.Id) + 1;
				notes.Add(note);
				return CreatedAtRoute("GetNote", new { id = note.Id }, note);
			} else {
				return BadRequest();
			}
		}
	}
}