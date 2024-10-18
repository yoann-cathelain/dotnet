using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TP2Console.Models.EntityFramework;

[Table(nameof(Film))]
public partial class Film
{

    private ILazyLoader _lazyLoader;
    public Film(ILazyLoader lazyLoader)
    {
        _lazyLoader = lazyLoader;
    }

    public Film()
    {

    }

    [Key]
    [Column(nameof(Idfilm))]
    public int Idfilm { get; set; }

    [Column(nameof(Nom))]
    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [Column(nameof(Description))]
    public string? Description { get; set; }

    [Column(nameof(Idcategorie))]
    public int Idcategorie { get; set; }

    [InverseProperty("IdfilmNavigation")]
    public virtual ICollection<Avi> Avis { get; set; } = new List<Avi>();

    [ForeignKey(nameof(IdcategorieNavigation))]
    [InverseProperty("Films")]
    public virtual Categorie IdcategorieNavigation { get; set; } = null!;
}
