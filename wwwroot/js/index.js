(() => {
	function main() {
		var app = new Vue({
			el: '#app',
			data: {
				message: 'Hello Vue!',
				notes: [],
				contentToAdd: ''
			},
			methods: {
				getNotes: function() {
					const self = this;
					let lastId = 0;
					for (let note of self.notes) {
						if (note.id > lastId) lastId = note.id;
					}

					let query = {
						params: {
							after: lastId
						}
					};

					axios.get("/api/notes", query)
						.then(response => {
							for (let note of response.data) {
								self.notes.push(note);
							}
						});
				},
				addNote: function() {
					const self = this;
					axios.post("/api/notes", { content: self.contentToAdd })
						.then(response => {
							self.contentToAdd = '';
							self.getNotes();
							console.log(response);
						});
				}
			}
		});
	}

	if (document.readyState == 'loading') {
		document.addEventListener('DOMContentLoaded', main);
	} else {
		main();
	}
})();