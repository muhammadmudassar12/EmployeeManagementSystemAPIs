using EmployManagementSystemAPIs.Services;
using EmployManagementSystemAPIs.Services.BasicInfoServices;
using EmployManagementSystemAPIs.Services.EmgContactInfoServices;
using EmployManagementSystemAPIs.Services.HolidayInfoServices;
using EmployManagementSystemAPIs.Services.SalaryInfoServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IBasicInfoServices, BasicInfoServices>();
builder.Services.AddTransient<IEmgContactInfoServices, EmgContactInfoServices>();
builder.Services.AddTransient<ISalaryInfoServices, SalaryInfoServices>();
builder.Services.AddTransient<IHolidayInfoServices, HolidayInfoServices>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins(new string[]
                    {
                      "https://localhost:3000",
                      "http://localhost:3001",
                       "http://localhost:7353", "http://localhost:3000"


                    })
                .WithMethods("POST", "GET", "PUT", "DELETE")
         .AllowAnyHeader()
         .AllowCredentials();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowOrigin");
app.Run();
