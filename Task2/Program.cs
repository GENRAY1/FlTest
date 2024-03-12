using Microsoft.Extensions.DependencyInjection;
using Task2.AppContext;
using Microsoft.EntityFrameworkCore;
using Task2.Repositories;
using Microsoft.Extensions.Logging;
using System;
using Task2.Model;
using System.Text.Json;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace Task2;
class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=DESKTOP-FSAMJ9H\\SQLEXPRESS;Database=FLTest;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False";

        ServiceCollection services = new ServiceCollection();
        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddTransient<IUserRepository, UserRepository>();

        var serviceProvider = services.BuildServiceProvider();
        var rep = serviceProvider.GetRequiredService<IUserRepository>();

        //task1(rep);
        //task2(rep);
        //task3(rep);

    }

    static void PrintToJSON<T>(T Entity)
    {
        if(Entity == null)
        {
            Console.WriteLine("null");
            return;
        }

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,

        };
        string json = JsonSerializer.Serialize<T>(Entity, options);
        Console.WriteLine(json);
    }

    static void task1(IUserRepository rep)
    {
        Guid guid = Guid.Parse("74f5f45e-caab-4a33-b5ca-eeba0fd3caaa");
        User user = rep.GetUserByIdAndDomain(guid, "Маркетинг");

        PrintToJSON(user);
    }

    static void task2(IUserRepository rep)
    {
        List<User> users = rep.GetUsersPagination("Маркетинг", 1, 2);
        PrintToJSON(users);
    }

    static void task3(IUserRepository rep)
    {
        List<User> users = rep.GetUsersByDomainAndTag("Маркетинг", "Тег 1");
        PrintToJSON(users);
    }
}