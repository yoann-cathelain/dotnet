namespace SeriesApp.Models
{

    public partial class Serie
    {
        public int SerieId { get; set; }

        public string Titre { get; set; } = null!;

        public string? Resume { get; set; }

        public int? NbSaisons { get; set; }

        public int? NbEpisodes { get; set; }

        public int? AnneeCreation { get; set; }

        public string? Network { get; set; }

        public ICollection<Notation> NotesSerie { get; set; }

    }
}
