using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SeriesApp.Models;

namespace WebAPI_TP3.Models.EntityFramework
{

    public partial class Utilisateur
    {
        public int UtilisateurId { get; set; }



        public string? Nom { get; set; }


        public string? Prenom { get; set; }


        public string? Mobile { get; set; }


        public string Mail { get; set; } = null!;


        public string Pwd { get; set; } = null!;

        public string? Rue { get; set; }


        public string? CodePostal { get; set; }

        public string? Ville { get; set; }

        public string? Pays { get; set; }

        public float? Latitude { get; set; }

        public float? Longitude { get; set; }
        public DateTime DateCreation { get; set; }

        public virtual ICollection<Notation?> NotesUtilisateur
        {
            get;
            set;
        } = new List<Notation?>();

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
