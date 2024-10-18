using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TP2Console.Models.EntityFramework;

[PrimaryKey("Idfilm", "Idutilisateur")]
[Table("avis")]
public partial class Avi
{
    [Key]
    [Column(nameof(Idfilm))]
    public int Idfilm { get; set; }

    [Key]
    [Column(nameof(Idutilisateur))]
    public int Idutilisateur { get; set; }

    [Column(nameof(Commentaire))]
    [StringLength(1000)]
    public string? Commentaire { get; set; }

    [Column(nameof(Note))]
    public decimal Note { get; set; }

    [ForeignKey(nameof(Idfilm))]
    [InverseProperty("Avis")]
    public virtual Film IdfilmNavigation { get; set; } = null!;

    [ForeignKey(nameof(Idutilisateur))]
    [InverseProperty("Avis")]
    public virtual Utilisateur IdutilisateurNavigation { get; set; } = null!;
}
