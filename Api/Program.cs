using Api.Data;
using Api.Interfaces;
using Api.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();


builder.Services.AddScoped<DITestService>();
// DI Test
// 每次注入時，都是一個新的實例
builder.Services.AddTransient<TransientService>();

// 每個Request為同一個新的實例 => 適用在各別的使用者資料
builder.Services.AddScoped<ScopedService>();

// 程式運行期間只會有一個實例 => 適用每個人都可以取用的
builder.Services.AddSingleton<SingletonService>();

// IoC: 隨時可抽換掉StudentIocService => 換一個程式邏輯，並保留舊的或者在某種條件下使用特定邏輯
builder.Services.AddScoped<IStudentIoc, StudentIocService>();
/*
if (xxx){
    builder.Services.AddScoped<IStudentIoc, XXXStudentIocService>();
}else{
    builder.Services.AddScoped<IStudentIoc, StudentIocService>();
}
*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles(); // 打開靜態目錄

app.Run();