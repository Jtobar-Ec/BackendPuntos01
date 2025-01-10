using System;
using System.Collections.Generic;

namespace PuntosRecompensasAPI.Models;

public partial class TfaHistory
{
    public int HistoryId { get; set; }

    public DateTime? HistoryEmission { get; set; } // Cambiado de DateOnly a DateTime.

    public int? UserHistoryId { get; set; }

    public int? UserCategoriesId { get; set; }

    public int? UserCertificateId { get; set; }

    public virtual TfaCategory? UserCategories { get; set; }

    public virtual TfaCertificate? UserCertificate { get; set; }

    public virtual TfaUser? UserHistory { get; set; }
}
