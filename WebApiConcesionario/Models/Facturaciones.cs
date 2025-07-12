using System;
using System.Collections.Generic;

namespace WebApiConcesionario.Models;

public partial class Facturaciones
{
    public int Id { get; set; }

    public int IdVehicular { get; set; }

    public int IdTarifa { get; set; }

    public int Horas { get; set; }

    public double Total { get; set; }

    public DateTime FechaEntrada { get; set; }

    public DateTime FechaSalida { get; set; }

    public virtual Tarifas IdTarifaNavigation { get; set; } = null!;

    public virtual RegistroVehiculares IdVehicularNavigation { get; set; } = null!;

    public virtual ICollection<RegistroVehiculares> RegistroVehiculares { get; set; } = new List<RegistroVehiculares>();

    public virtual ICollection<Tarifas> Tarifas { get; set; } = new List<Tarifas>();
}
