using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_TP3.Models.EntityFramework
{
    [Table(("t_j_notation_not"))]
    [PrimaryKey("UtilisateurId", "SerieId")]
    public partial class Notation
    {
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("ser_id")]
        public int SerieId { get; set; }

        [Column("not_note")]
        public int Note { get; set; }

        [InverseProperty("NotesUtilisateur")]
        public Utilisateur UtilisateurNotant { get; set; }

        [InverseProperty("NotesSerie")]
        public Serie SerieNotee { get; set; }
    }
}
