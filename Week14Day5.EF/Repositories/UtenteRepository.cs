using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14Day5.Core.Entities;
using Week14Day5.Core.Interfaces;

namespace Week14Day5.EF.Repositories
{
    public class UtenteRepository : IUtenteRepository
    {
        public Utente GetByUsername(string username)
        {
            using (var ctx = new MenuContext())
            {
                if (string.IsNullOrEmpty(username))
                {
                    return null;
                }
                return ctx.Utenti.FirstOrDefault(u => u.Username == username);
            }
        }
    }
}
