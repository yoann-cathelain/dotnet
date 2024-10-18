using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TP3.Models.EntityFramework;

namespace SeriesApp.Contracts.Services
{
    interface IWSService
    {

         Task<Utilisateur> GetUserByEmailAsync(string email);
         Task PutUtilisateur(int id, Utilisateur utilisateur);
    }
}
