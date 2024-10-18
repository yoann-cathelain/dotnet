using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_TP3.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    [Index(nameof(Mail), IsUnique = true)]
    public partial class Utilisateur
    {
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("utl_nom")]
        [StringLength(50)]
        public string? Nom { get; set; }

        [Column("utl_prenom")]
        [StringLength(50)]
        public string? Prenom { get; set; }

        [Column("utl_mobile", TypeName = "char(10)")]
        [Phone]
        public string? Mobile { get; set; }

        [Column("utl_mail")]
        [StringLength(100)]
        [EmailAddress]
        public string Mail { get; set; } = null!;

        [Column("utl_pwd")] 
        [StringLength(64)]
        public string Pwd { get; set; } = null!;

        [Column("utl_rue")]
        [StringLength(200)]
        public string? Rue { get; set; }

        [Column("utl_cp", TypeName = "char(5)")]

        public string? CodePostal { get; set; }

        [Column("utl_ville")]
        [StringLength(50)]
        public string? Ville { get; set; }

        [Column("utl_pays")]
        [StringLength(50)]
        public string? Pays { get; set; }

        [Column("utl_latitude")]
        public float? Latitude { get; set; }

        [Column("utl_longitude")]
        public float? Longitude { get; set; }

        [Column("utl_datecreation")] 
        public DateTime DateCreation { get; set; }

        [InverseProperty("UtilisateurNotant")]
        public virtual ICollection<Notation?> NotesUtilisateur { get; set; } = new List<Notation?>();

        protected bool Equals(Utilisateur other)
        {
            return Nom == other.Nom && Prenom == other.Prenom && Mobile == other.Mobile && Mail == other.Mail && Pwd == other.Pwd && Rue == other.Rue && CodePostal == other.CodePostal && Ville == other.Ville && Pays == other.Pays && Nullable.Equals(Latitude, other.Latitude) && Nullable.Equals(Longitude, other.Longitude);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Utilisateur)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Nom);
            hashCode.Add(Prenom);
            hashCode.Add(Mobile);
            hashCode.Add(Mail);
            hashCode.Add(Pwd);
            hashCode.Add(Rue);
            hashCode.Add(CodePostal);
            hashCode.Add(Ville);
            hashCode.Add(Pays);
            hashCode.Add(Latitude);
            hashCode.Add(Longitude);
            hashCode.Add(NotesUtilisateur);
            return hashCode.ToHashCode();
        }
    }
}
