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
// �C���`�J�ɡA���O�@�ӷs�����
builder.Services.AddTransient<TransientService>();

// �C��Request���P�@�ӷs����� => �A�Φb�U�O���ϥΪ̸��
builder.Services.AddScoped<ScopedService>();

// �{���B������u�|���@�ӹ�� => �A�ΨC�ӤH���i�H���Ϊ�
builder.Services.AddSingleton<SingletonService>();

// IoC: �H�ɥi�⴫��StudentIocService => ���@�ӵ{���޿�A�ëO�d�ª��Ϊ̦b�Y�ر���U�ϥίS�w�޿�
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
app.UseStaticFiles(); // ���}�R�A�ؿ�

app.Run();