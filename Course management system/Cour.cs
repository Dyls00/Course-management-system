using System;
using System.Collections.Generic;

namespace Course_management_system;

public partial class Cour
{
    public int CoursId { get; set; }

    public string NomCours { get; set; } = null!;

    public int DureeCours { get; set; }

    public DateOnly DateDebutCours { get; set; }

    public DateOnly DateFinCours { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
