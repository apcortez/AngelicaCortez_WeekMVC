using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14Day5.Core.Entities;

namespace Week14Day5.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        #region Menu
        public List<Menu> GetAllMenus();
        public string AddMenu(Menu menu);
        public string DeleteMenu(int id);
        public string EditMenu(Menu menu);
        #endregion

        #region Piatti
        public List<Piatto> GetAllPiatti();
        public string AddPiatto(Piatto piatto);
        public string DeletePiatto(int id);
        public string EditPiatto(Piatto piatto);
        #endregion

        public Utente GetAccount(string username);
    }
}
