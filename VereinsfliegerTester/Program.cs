using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Vereinsflieger.Shared;
using Vereinsflieger.Api;

namespace Vereinsflieger.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            using var sr = new StreamReader("secrets.json");

            var secrets = Secrets.FromJson(sr.ReadToEnd());

            Console.WriteLine("Lets Start");

            var connection = new Connection(secrets.AppKey);

            connection.GetAccesstokenAsync().Wait();
            Console.WriteLine($"AccessToken: {connection.Accesstoken}");

            connection.LoginAsync(secrets.Username, secrets.Password).Wait();
            Console.WriteLine($"Benutzer {secrets.Username} erfolgreich eingeloggt.");

            var flights = FlightsController.GetFlights(connection, DateTime.Today.AddDays(-50), DateTime.Today).GetAwaiter().GetResult();
            Console.WriteLine($"Es wurden {flights.Count} Flüge runtergeladen.");

        }
    }
}
