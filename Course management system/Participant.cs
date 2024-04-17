using System;
using System.Collections.Generic;

namespace Course_management_system;

public partial class Participant
{
    public int ParticipantId { get; set; }

    public string NomParticipant { get; set; } = null!;

    public int CoursId { get; set; }

    public virtual Cour Cours { get; set; } = null!;
}
