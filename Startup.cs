using System.Collections.Generic;
using Demo.Spa.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Spa {

	public class Startup {

		public void ConfigureServices(IServiceCollection services) {
			services.AddSingleton<IList<Note>>(serviceProvider => {
				var notes = new List<Note>();
				notes.AddMockData();
				return notes;
			});
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}
			app.UseMvc();
			app.UseDefaultFiles();
			app.UseStaticFiles();
		}
	}
}