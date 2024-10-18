using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseur.Models;

namespace ClientConvertisseur.Services.Interface
{
    public interface IService
    {
        public Task<List<Devise>> GetDevisesAsync(string nomControleur);
    }
}
