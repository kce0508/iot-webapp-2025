using System;
using System.Collections.Generic;

namespace DbFirstWebApp.Models;

public partial class Fakedata
{
    public DateTime SensingDt { get; set; }

    public string PubId { get; set; } = null!;

    public decimal Count { get; set; }

    public decimal Temp { get; set; }

    public decimal Humid { get; set; }

    public string Light { get; set; } = null!;

    public string Human { get; set; } = null!;
}
