﻿using System;
using System.Collections.Generic;

namespace PuntosRecompensasAPI.Models;

public partial class TfaTeam
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string TeamDescription { get; set; } = null!;

    public int TeamStatusId { get; set; }

    public int? TeamLeadId { get; set; }

    public virtual TfaUser? TeamLead { get; set; }

    public virtual TfaTeamstatus TeamStatus { get; set; } = null!;

    public virtual ICollection<TfaUser> ColaboratorUsers { get; set; } = new List<TfaUser>();
}
