using System;
using System.Collections.Generic;

namespace PuntosRecompensasAPI.Models;

public partial class TfaCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDescription { get; set; }

    public int? CategoryPoints { get; set; }

    public DateTime? CategoryDeadLine { get; set; } // Cambiado de DateOnly a DateTime para mayor compatibilidad con EF Core.

    public virtual ICollection<TfaCertificate> TfaCertificates { get; set; } = new List<TfaCertificate>();

    public virtual ICollection<TfaHistory> TfaHistories { get; set; } = new List<TfaHistory>();

    public virtual ICollection<TfaTask> TfaTasks { get; set; } = new List<TfaTask>();
}
