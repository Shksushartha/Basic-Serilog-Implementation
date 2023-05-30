using Serilog;

namespace serilogDemo;

public class Program
{
    public static void Main(string[] args)
    {
       

        try
        {
            
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .CreateLogger();

            builder.Host.UseSerilog(Logger);
            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();
            Logger.Information("application starting up.");
            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseStaticFiles();


           


            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
        catch(Exception ex)
        {
            Log.Fatal(ex,"App starting failed");
        }
        finally
        {
            Log.CloseAndFlush();
        }
        
    }

   
}
