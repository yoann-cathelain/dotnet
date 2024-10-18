using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_TP3.Models.EntityFramework;
using WebAPI_TP3.Models.Repository;

namespace WebAPI_TP3.Models.DataManager
{
    public class UtilisateurManager : IDataRepository<Utilisateur>
    {
        readonly PostgresContext? postgresDbContext;

        public UtilisateurManager()
        {
        }

        public UtilisateurManager(PostgresContext context)
        {
            postgresDbContext = context;
        }

        public async Task<IEnumerable<Utilisateur>> GetAllAsync()
        {
            var test = await postgresDbContext.Utilisateurs.ToListAsync();
            return test;
        }

        public async Task<Utilisateur> GetByIdAsync(int id)
        {
            return  await postgresDbContext.Utilisateurs.FirstOrDefaultAsync(u => u.UtilisateurId == id);
        }

        public async Task<Utilisateur> GetByStringAsync(string mail)
        {
            return await postgresDbContext.Utilisateurs.FirstOrDefaultAsync(u => u.Mail.ToUpper() == mail.ToUpper());
        }

        public async Task Add(Utilisateur entity)
        {
            await postgresDbContext.Utilisateurs.AddAsync(entity);
            await postgresDbContext.SaveChangesAsync();
        }

        public async Task Update(Utilisateur utilisateur, Utilisateur entity)
        {
            postgresDbContext.Entry(utilisateur).State = EntityState.Modified;
            utilisateur.UtilisateurId = entity.UtilisateurId;
            utilisateur.Nom = entity.Nom;
            utilisateur.Prenom = entity.Prenom;
            utilisateur.Mail = entity.Mail;
            utilisateur.Rue = entity.Rue;
            utilisateur.CodePostal = entity.CodePostal;
            utilisateur.Ville = entity.Ville;
            utilisateur.Pays = entity.Pays;
            utilisateur.Latitude = entity.Latitude;
            utilisateur.Longitude = entity.Longitude;
            utilisateur.Pwd = entity.Pwd;
            utilisateur.Mobile = entity.Mobile;
            utilisateur.NotesUtilisateur = entity.NotesUtilisateur;
            await postgresDbContext.SaveChangesAsync();
        }

        public async Task Delete(Utilisateur utilisateur)
        {
            postgresDbContext.Utilisateurs.Remove(utilisateur);
            await postgresDbContext.SaveChangesAsync();
        }
    }
}
