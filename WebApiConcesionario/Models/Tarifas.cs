using System;
using System.Collections.Generic;

namespace WebApiConcesionario.Models;

public partial class Tarifas
{
    public int Id { get; set; }

    public double Precio { get; set; }

    public DateTime Fecha { get; set; }

    public int? FacturacionId { get; set; }

    public virtual Facturaciones? Facturacion { get; set; }

    public virtual ICollection<Facturaciones> Facturaciones { get; set; } = new List<Facturaciones>();
}
