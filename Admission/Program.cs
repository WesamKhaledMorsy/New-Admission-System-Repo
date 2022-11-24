using Admission.DB;
using Admission.Helper;
using Admission.Manage.manageAdmin;
using Admission.Manage.manageDocument;
using Admission.Manage.manageGender;
using Admission.Manage.manageGrade;
using Admission.Manage.manageInterview;
using Admission.Manage.manageInterviewer;
using Admission.Manage.manageRound;
using Admission.Manage.manageStatus;
using Admission.Manage.manageStudent;
using Admission.Manage.manageTrack;
using Admission.Manage.manageUniversity;
using Admission.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using SendGrid.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>(options =>
//                options.UseSqlServer(builder.Configuration.GetConnectionString("ProdConnection")));

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddTransient<IManageTrack, ManageTrack>();
builder.Services.AddTransient<IManageStudent, ManageStudent>();
builder.Services.AddTransient<IManageAdmin, ManageAdmin>();
builder.Services.AddTransient<IManageInterview, ManageInterview>();
builder.Services.AddTransient<IManageInterviewer, ManageInterviewer>();
builder.Services.AddTransient<IManageRound, ManageRound>();
builder.Services.AddTransient<IManageGrade, ManageGrade>();
builder.Services.AddTransient<IManageGender, ManageGender>();
builder.Services.AddTransient<IManageStatus,ManageStatus>();
builder.Services.AddTransient<IManageUniversity, ManageUniversity>();
builder.Services.AddTransient<IManageDocument, ManageDocument>();


/*
 * To Send Email And Don't forget to use This =>using SendGrid.Extensions.DependencyInjection;
 */
builder.Services.AddSendGrid(option =>
{
    option.ApiKey=builder.Configuration.GetSection("SendGridEmailSettings")
    .GetValue<string>("APIKey");
});

//UploadFiles
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit=int.MaxValue;
    o.MultipartBodyLengthLimit=int.MaxValue;
    o.MemoryBufferThreshold=int.MaxValue;
});
///

builder.Services.AddScoped<IAuthService,AuthService>();
//// Tokens
///
// Bind JWTHelper in application.json
builder.Services.Configure<JWTHelper>(builder.Configuration.GetSection("JWTHelper"));

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(option => {
        option.RequireHttpsMetadata = false;
        option.SaveToken = false;
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,

            ValidIssuer = builder.Configuration["JWTHelper:Issuer"],
            ValidAudience = builder.Configuration["JWTHelper:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTHelper:Key"]))
        };

    });

builder.Services.Configure<IdentityOptions>(opts => {
    opts.Password.RequiredLength = 8;
    opts.Password.RequireLowercase = true;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireNonAlphanumeric=false;
    opts.Password.RequireDigit=true;

    opts.User.AllowedUserNameCharacters="abcdefghijklmnopqrstuvwxyz0123456789";
    opts.User.RequireUniqueEmail= true;
    

});

builder.Services.AddCors(options => options.AddPolicy(
    name: "Admission",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyMethod().AllowAnyHeader();
    }));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Admission");

app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

//Upload
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"Resources")),
    RequestPath=new PathString("/Resources")
}) ;
///////
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
