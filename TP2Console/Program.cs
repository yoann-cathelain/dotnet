using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TP2Console.Models.EntityFramework;

namespace TP2Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exo3Q5();
        }

        public static void Exo2Q2()
        {
            var ctx = new PostgresContext();
            foreach (var utilisateur in ctx.Utilisateurs)
            {
                Console.WriteLine(utilisateur.Email);
            }
        }

        public static void Exo2Q3()
        {
            var ctx = new PostgresContext();
            foreach (var utilisateur in ctx.Utilisateurs.Select(c => c).OrderBy(u => u.Login).ToList())
            {
                Console.WriteLine(utilisateur.Login);
            }
        }

        public static void Exo2Q4()
        {
            var ctx = new PostgresContext();
            Categorie actionCategorie = ctx.Categories.Include(c => c.Films).First(c => c.Nom == "Action");
            foreach (var film in actionCategorie.Films)
            {
                Console.WriteLine(film.Idfilm + " : " + film.Nom);
            }
        }

        public static void Exo2Q5()
        {
            var ctx = new PostgresContext();
            Console.WriteLine("Nb categories = " + ctx.Categories.Count());
        }
        public static void Exo2Q6()
        {
            var ctx = new PostgresContext();
            Console.WriteLine("Note la plus basse : " + ctx.Avis.Min(a => a.Note));
        }

        public static void Exo2Q7()
        {
            var ctx = new PostgresContext();
            foreach (var film in ctx.Films.Select(f => f).Where(f => EF.Functions.Like(f.Nom.ToLower(), "le%")))
            {
                Console.WriteLine(film.Nom);
            }
        }

        public static void Exo2Q8()
        {
            var ctx = new PostgresContext();
            decimal averageNote = ctx.Avis.Select(a => a)
                .Where(f => EF.Functions.Like(f.IdfilmNavigation.Nom.ToLower(), "pulp fiction")).Average(n => n.Note);

            Console.WriteLine("La note moyenne du film Pulp Fiction est : " + averageNote);

        }

        public static void Exo2Q9()
        {
            var ctx = new PostgresContext();
            var utilisateur = (ctx.Utilisateurs
                .Join(ctx.Avis, u => u.Idutilisateur, a => a.Idutilisateur, (u, a) => new { u, a })
                .Where(t => t.a.Note == ctx.Avis.Max(av => av.Note))
                .Select(t => new { t.u.Idutilisateur, t.u.Login, t.u.Email })).FirstOrDefault();
            Console.WriteLine(utilisateur);
        }

        public static void Exo3Q1()
        {
            var ctx = new PostgresContext();

            Utilisateur newUtilisateur = new Utilisateur
            {
                Login = "Test",
                Pwd = "Test",
                Email = "Test@gmail.com",
                Avis = new List<Avi>()
            };

            ctx.Utilisateurs.Add(newUtilisateur);
            ctx.SaveChanges();
        }

        public static void Exo3Q2()
        {
            var ctx = new PostgresContext();

            Film film = ctx.Films.First(f => f.Nom.Contains("singes"));
            Categorie drameCategorie = ctx.Categories.First(c => c.Nom == "Drame");
            film.Description = "C'est des très gros singes";
            film.Idcategorie = drameCategorie.Idcategorie;

            ctx.SaveChanges();

        }

        public static void Exo3Q3()
        {
            var ctx = new PostgresContext();

            Film film = ctx.Films.First(f => f.Nom.Contains("singes"));
            foreach (Avi avi in ctx.Avis)
            {
                ctx.Remove(avi);
            }
            ctx.Films.Remove(film);

            ctx.SaveChanges();

        }

        public static void Exo3Q4()
        {
            var ctx = new PostgresContext();

            Film film = ctx.Films.First(f => f.Nom == "Alien");
            Utilisateur utilisateur = ctx.Utilisateurs.First(u => u.Login == "Test");
            Avi newAvi = new Avi
            {
                Note = 9,
                Idutilisateur = utilisateur.Idutilisateur,
                Commentaire = "Très très bon film, des frissons incroyables",
                IdfilmNavigation = film,
                IdutilisateurNavigation = utilisateur,
                Idfilm = film.Idfilm
            };

            ctx.Avis.Add(newAvi);
            ctx.SaveChanges();
        }

        public static void Exo3Q5()
        {
            var ctx = new PostgresContext();

            Categorie drameCategorie = ctx.Categories.First(c => c.Nom == "Drame");

            List<Film> filmToAdd = new List<Film>();

            filmToAdd.Add(new Film
            {
                Nom = "Troie",
                Idcategorie = drameCategorie.Idcategorie,
                Description = "Achille contre Hector",
                IdcategorieNavigation = drameCategorie,
                Avis = new List<Avi>()
            });

            filmToAdd.Add(new Film
            {
                Nom = "Je suis une légende",
                IdcategorieNavigation = drameCategorie,
                Idcategorie = drameCategorie.Idcategorie,
                Description = "Survie dans un monde post apocalyptique",
                Avis = new List<Avi>()
            });

            ctx.Films.AddRange(filmToAdd);

            
            ctx.SaveChanges();
        }

    }
}
