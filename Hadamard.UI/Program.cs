using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Hadamard.UI.View;
using Hadamard.Common;
using Hadamard.Common.Model;
using Hadamard.UI.Presenter;

namespace Hadamard.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ISatelliteRepository repository = new SatelliteRepository();            
            var allSatellites = repository.GetAllSatellites();
            var singleSatellite = repository.GetSatelliteByIndex(0);
            var selectedSatellite = repository.GetSatelliteById(25544);

            repository.OnSatelliteValuesUpdated += (s, e) =>
            {
                Console.WriteLine($"Satellite '{e.Satellite.Id}' updated latitude '{e.Satellite.Latitude}' longitude '{e.Satellite.Longitude}'");
            };

            repository.OnSatelliteAdded += (s, e) =>
            {
                Console.WriteLine($"Satellite with ID '{e.Satellite.Id}' added");
            };

            while(true)
            {
                var input = Console.ReadLine();
                if (input.Equals("show"))
                    repository.UpdateAll();
                else if(input.StartsWith("add"))
                {
                    repository.Add(new Satellite(int.Parse(input.Split(' ')[1])));
                }
            }

            //var view = new SatelliteForm();
            /*var presenter = new SatellitePresenter(view, repository);
            presenter.Run();*/

            //var view = new MapView();
            //var presenter = new MapPresenter(view, repository);
            //presenter.Run();
        }
    }
}
