using MultiShop.WebUI.Services;
using MultMultiShop.WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// GCSConfigOptions'u yapýlandýrmaya baðlayýn
builder.Services.Configure<GCSConfigOptions>(builder.Configuration.GetSection("GCSConfigOptions"));

// CloudStorageService'i DI konteynerine ekleyin
builder.Services.AddScoped<ICloudStorageService, CloudStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Create}/{id?}");

app.Run();
