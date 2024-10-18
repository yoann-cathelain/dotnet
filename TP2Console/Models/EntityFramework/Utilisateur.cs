using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TP2Console.Models.EntityFramework;

[Table(nameof(Utilisateur))]
public partial class Utilisateur
{
    [Key]
    [Column(nameof(Idutilisateur))]
    public int Idutilisateur { get; set; }

    [Column(nameof(Login))]
    [StringLength(50)]
    public string Login { get; set; } = null!;

    [Column(nameof(Email))]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column(nameof(Pwd))]
    [StringLength(64)]
    public string Pwd { get; set; } = null!;

    [InverseProperty("IdutilisateurNavigation")]
    public virtual ICollection<Avi> Avis { get; set; } = new List<Avi>();
}
