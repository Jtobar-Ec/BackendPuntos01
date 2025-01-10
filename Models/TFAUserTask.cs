namespace PuntosRecompensasAPI.Models;

public partial class TfaUserTask
{
    public int UserId { get; set; }

    public int UserTaskId { get; set; }

    public virtual TfaUser User { get; set; } = null!;

    public virtual TfaTask Task { get; set; } = null!;
}
