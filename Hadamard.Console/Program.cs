using System;
using Hadamard.Common.Model;

namespace Hadamard.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ISatelliteRepository repository = new SatelliteRepository();
            var allSatellites = repository.GetAllSatellites();
            var singleSatellite = repository.GetSatelliteByIndex(0);
            var selectedSatellite = repository.GetSatelliteById(25544);

            repository.OnSatelliteValuesUpdated += (s, e) =>
            {
                System.Console.WriteLine($@"Satellite '{e.Satellite.Id}' updated latitude '{e.Satellite.Latitude}' longitude '{e.Satellite.Longitude}'");
            };

            repository.OnSatelliteAdded += (s, e) =>
            {
                System.Console.WriteLine($@"Satellite with ID '{e.Satellite.Id}' added");
            };

            while (true)
            {
                var input = System.Console.ReadLine();
                if (input != null && input.Equals("show"))
                    repository.UpdateAll();
                else if (input != null && input.StartsWith("add"))
                {
                    repository.Add(new Satellite(int.Parse(input.Split(' ')[1])));
                }
            }

        }
    }
}
