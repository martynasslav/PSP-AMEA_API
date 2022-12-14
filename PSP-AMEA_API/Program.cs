using Microsoft.OpenApi.Models;
using PSP_AMEA_API.Repository;
using System.Reflection;

class Program
{
	public static void Main()
	{
		var builder = WebApplication.CreateBuilder();

		builder.Services.AddSingleton<ICartRepository, CartRepository>();
		builder.Services.AddSingleton<IDeliveryRepository, DeliveryRepository>();
		builder.Services.AddSingleton<IItemRepository, ItemRepository>();
		builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
		builder.Services.AddSingleton<IPaymentRepository, PaymentRepository>();
		builder.Services.AddSingleton<IReviewRepository, ReviewRepository>();
    builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
		builder.Services.AddSingleton<ILoyaltyRepository, LoyaltyRepository>();
    builder.Services.AddSingleton<IDiscountRepository, DiscountRepository>();
		builder.Services.AddSingleton<IDiscountItemRepository, DiscountItemRepository>();
		builder.Services.AddSingleton<IShiftRepository, ShiftRepository>();
		builder.Services.AddSingleton<IShiftTypeRepository, ShiftTypeRepository>();
		builder.Services.AddSingleton<IShiftEmployeeRepository, ShiftEmployeeRepository>();
    builder.Services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
    builder.Services.AddSingleton<ILocationRepository, LocationRepository>();
    builder.Services.AddSingleton<IReservationRepository, ReservationRepository>();
    builder.Services.AddSingleton<ITenantRepository, TenantRepository>();
    
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