using WebAPI_TP3.Models.EntityFramework;

namespace SeriesApp.Models
{
    public partial class Notation
    {
        public int UtilisateurId { get; set; }

        public int SerieId { get; set; }

        public int Note { get; set; }

        public Utilisateur UtilisateurNotant { get; set; }

        public Serie SerieNotee { get; set; }
    }
}
