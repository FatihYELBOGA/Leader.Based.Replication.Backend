using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Single_Leader_Replication.Configurations;
using Single_Leader_Replication.Repositories;
using Single_Leader_Replication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// leader school management database configuration
builder.Services.AddDbContext<LeaderSchoolManagement>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("leader_school_management_cnn"));
        options.ConfigureWarnings(warnings =>
            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
    }
);

// follower school management database configuration
builder.Services.AddDbContext<FollowerSchoolManagement>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("follower_school_management_cnn"));
        options.ConfigureWarnings(warnings =>
            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
    }
);

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IStudentService, StudentService>();

var app = builder.Build();

LeaderSchoolManagement.Seed(app.Services.CreateScope().ServiceProvider.GetRequiredService<LeaderSchoolManagement>());
FollowerSchoolManagement.Seed(app.Services.CreateScope().ServiceProvider.GetRequiredService<FollowerSchoolManagement>());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
