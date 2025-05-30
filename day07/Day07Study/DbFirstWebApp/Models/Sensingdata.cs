using System;
using System.Collections.Generic;

namespace DbFirstWebApp.Models;

public partial class Sensingdata
{
    public long Idx { get; set; }

    public DateTime SensingDt { get; set; }

    public int Light { get; set; }

    public int Rain { get; set; }

    public float Temp { get; set; }

    public float Humid { get; set; }

    public string Fan { get; set; } = null!;

    public string Vul { get; set; } = null!;

    public string RealLight { get; set; } = null!;

    public string ChaimBell { get; set; } = null!;
}
