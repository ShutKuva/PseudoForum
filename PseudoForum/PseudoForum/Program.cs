using Core.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(builder.Configuration.GetSection("AuthenticationOptions")["AuthScheme"])
    .AddCookie(builder.Configuration.GetSection("AuthenticationOptions")["AuthScheme"], options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
        options.Cookie.Name = "PseudoForumCookie";
    });

builder.Services.Configure<AuthentificationOptions>(builder.Configuration.GetSection("AuthenticationOptions"));

BLL.DependencyRegisterer.Register(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
