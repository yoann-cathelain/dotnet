using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Console.Models.EntityFramework;

namespace TP2Console.Models
{
    public partial class AviPart : Avi
    {

        public override string ToString()
        {
            return base.Idfilm + " : " + base.Idutilisateur;
        }
    }
}
