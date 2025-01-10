using System;
using System.Collections.Generic;

namespace PuntosRecompensasAPI.Models;

public partial class TfaTask
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string? TaskEvidence { get; set; }

    public bool TaskStatus { get; set; }

    public int? CategoryId { get; set; }

    public virtual TfaCategory? Category { get; set; }

    public virtual ICollection<TfaUser> Users { get; set; } = new List<TfaUser>();
}
