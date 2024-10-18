using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_TP3.Models.EntityFramework
{
    [Table("t_e_serie_ser")]
    [Index(nameof(Titre))]
    public partial class Serie
    {
        [Column("ser_id")]
        public int SerieId { get; set; }

        [Column("ser_titre")] 
        public string Titre { get; set; } = null!;

        [Column("ser_resume", TypeName = "TEXT")]
        public string? Resume { get; set; }

        [Column("ser_nbsaisons")]
        public int? NbSaisons { get; set; }

        [Column("ser_nbepisodes")]
        public int? NbEpisodes { get; set; }

        [Column("ser_anneecreation")]
        public int? AnneeCreation { get; set; }

        [Column("ser_network")]
        [StringLength(50)]
        public string? Network { get; set; }

        [InverseProperty("SerieNotee")]
        public ICollection<Notation> NotesSerie { get; set; }

    }
}
