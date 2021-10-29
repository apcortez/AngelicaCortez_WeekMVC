using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14Day5.Core.Entities;
using Week14Day5.Core.Interfaces;

namespace Week14Day5.Core.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IMenuRepository menuRepo;
        private readonly IPiattoRepository piattiRepo;
        private readonly IUtenteRepository utentiRepo;

        public BusinessLayer(IMenuRepository menu, IPiattoRepository piatti, IUtenteRepository utenti)
        {
            menuRepo = menu;
            piattiRepo = piatti;
            utentiRepo = utenti;
        }

        public string AddMenu(Menu menu)
        {
            Menu menuEsistente = menuRepo.GetById(menu.Id);
            if (menuEsistente != null)
                return "Errore: MenuId già presente";
            
            menuRepo.Add(menu);
            return "Nuovo menu aggiunto con successo";
        }

        public string AddPiatto(Piatto piatto)
        {
            Menu menuEsistente = menuRepo.GetById(piatto.MenuId);
            if (menuEsistente == null)
                menuEsistente = new Menu() ;


            piatto.Menu = menuEsistente;
            piattiRepo.Add(piatto);
            return "Nuovo piatto aggiunto con successo";

        }

        public string DeleteMenu(int id)
        {
            Menu menuEsistente = menuRepo.GetById(id);
            if (menuEsistente == null)
                return "Menu non trovato.";

            var PiattiDelMenu = GetAllPiatti().FirstOrDefault(p => p.MenuId == menuEsistente.Id);
            if (PiattiDelMenu != null)
                return "Impossibile cancellare il menu perchè risulta associato ad almeno un piatto";
            
            menuRepo.Delete(id);
            return "Menu eliminato con successo";
        }

        public string DeletePiatto(int id)
        {
            var piattoToDelete = piattiRepo.GetById(id);
            if (piattoToDelete == null)
                return "Id piatto non trovato";

            piattiRepo.Delete(id);
            return "Piatto elimanto con successo";
        }

        public string EditMenu(Menu menu)
        {
            Menu menuToUpdate = menuRepo.GetById(menu.Id);
            if (menuToUpdate == null)
                return "Errore: menu non trovato";

            menuToUpdate.Nome = menu.Nome;
            menuRepo.Update(menuToUpdate);
            return "Menu aggiornato con successo";
        }

        public string EditPiatto(Piatto piatto)
        {
            Piatto piattoToUpdate = piattiRepo.GetById(piatto.Id);
            if (piattoToUpdate == null)
                return "Errore: piatto non trovato";

            piattoToUpdate.Nome = piatto.Nome;
            piattoToUpdate.Descrizione = piatto.Descrizione;
            piattoToUpdate.Tipologia = piatto.Tipologia;
            piattoToUpdate.Prezzo = piatto.Prezzo;
            piattoToUpdate.MenuId = piatto.MenuId;
            piattoToUpdate.Menu = menuRepo.GetById(piatto.MenuId);
            piattiRepo.Update(piattoToUpdate);
            return "Piatto aggiornato con successo";
        }

        public Utente GetAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return utentiRepo.GetByUsername(username);
        }

        public List<Menu> GetAllMenus()
        {
            return menuRepo.Fetch();
        }

        public List<Piatto> GetAllPiatti()
        {
            return piattiRepo.Fetch();
        }
    }
}
