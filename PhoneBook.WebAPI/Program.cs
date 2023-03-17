using PhoneBook.Business.Abstract;
using PhoneBook.Business.Concrete;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPersonService, PersonManager>();
builder.Services.AddSingleton<IPersonDal, EfPersonDal>();

builder.Services.AddSingleton<IContactInformationService, ContactInformationManager>();
builder.Services.AddSingleton<IContactInformationDal, EfContactInformationDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
