namespace PuntosRecompensasAPI.Models;

public partial class TfaTeamCollaborator
{
    public int ColaboratorTeamId { get; set; }

    public int ColaboratorUsersId { get; set; }

    public virtual TfaTeam Team { get; set; } = null!;

    public virtual TfaUser User { get; set; } = null!;
}
