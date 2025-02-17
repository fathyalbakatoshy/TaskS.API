using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task.API.Extensions;
using Task.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// قراءة سلسلة الاتصال من الإعدادات
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// تسجيل الخدمات باستخدام الإعدادات المخصصة
builder.Services.ConfigureServices(connectionString);

var app = builder.Build();

// تسجيل Middleware لمعالجة الأخطاء
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
