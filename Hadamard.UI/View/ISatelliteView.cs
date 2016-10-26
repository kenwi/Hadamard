﻿using System;
using System.Collections.Generic;
using Hadamard.Common.Model;

namespace Hadamard.UI.View
{
    public interface ISatelliteView : IView
    {
        IList<Satellite> SatelliteList { get; }

        event EventHandler UpdateGui;
    }
}