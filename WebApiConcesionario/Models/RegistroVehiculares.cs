using System;
using System.Collections.Generic;

namespace WebApiConcesionario.Models;

public partial class RegistroVehiculares
{
    public int Id { get; set; }

    public string Propietario { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int Anio { get; set; }

    public DateTime Fecha { get; set; }

    public string Placa { get; set; } = null!;

    public int? FacturacionId { get; set; }

    public bool Cancelado { get; set; }

    public string Email { get; set; } = null!;

    public virtual Facturaciones? Facturacion { get; set; }

    public virtual ICollection<Facturaciones> Facturaciones { get; set; } = new List<Facturaciones>();
}
