﻿using System;
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

            Application.Run(new ChatView());

            /*
            try
            {
                var repository = new SatelliteRepository();
                var view = new MapView();
                var presenter = new MapPresenter(view, repository);
                presenter.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/

        }
    }
}
