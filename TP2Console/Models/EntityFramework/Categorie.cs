using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TP2Console.Models.EntityFramework;

[Table(nameof(Categorie))]
public partial class Categorie
{
    private ILazyLoader _lazyLoader;
    public Categorie(ILazyLoader lazyLoader)
    {
        _lazyLoader = lazyLoader;
    }

    public Categorie()
    {

    }

    [Key]
    [Column(nameof(Idcategorie))]
    public int Idcategorie { get; set; }

    [Column(nameof(Nom))]
    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [Column(nameof(Description))]
    public string? Description { get; set; }

    private ICollection<Film> films;

    [InverseProperty("IdcategorieNavigation")]
    public virtual ICollection<Film> Films {
        get
        {
            return _lazyLoader.Load(this, ref films);
        }
        set
        {
            films = value;
        }
    }
}
