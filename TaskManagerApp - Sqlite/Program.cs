using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;
using TaskApp;
using TaskApp.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<TaskAppService>();
builder.Services.AddScoped<ILogger,Logger<TaskApp.App>>();
builder.Services.AddSqliteWasmDbContextFactory<SqliteDbContext>(options=> options.UseSqlite("Data Source=taskModel.sqlite3"));
await builder.Build().RunAsync();


// options.UseSqlite("Data Source=taskModel.sqlite3")