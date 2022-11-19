using Microsoft.OpenApi.Models;
using System.Reflection;

class Program
{
	public static void Main()
	{
		var builder = WebApplication.CreateBuilder();

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(c => {
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "AMEA API", Version = "v1" });

			var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
		});

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "AMEA API V1");
			});
		}

		app.UseHttpsRedirection();
		app.UseAuthorization();
		app.MapControllers();
		app.Run();
	}
}