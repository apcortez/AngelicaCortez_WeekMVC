using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14Day5.Core.Entities;
using Week14Day5.Core.Interfaces;

namespace Week14Day5.EF.Repositories
{
    public class PiattoRepository : IPiattoRepository
    {

        public bool Add(Piatto item)
        {
            if (item == null)
                return false;

            using (var menuCtx = new MenuContext())
            {
                menuCtx.Piatti.Add(item);
                menuCtx.SaveChanges();
                return true;


            }
           
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                return false;

            using (var menuCtx = new MenuContext())
            {
                var piatto = menuCtx.Piatti.Find(id);

                if (piatto != null)
                    menuCtx.Piatti.Remove(piatto);

                menuCtx.SaveChanges();
                return true;
            }

        }
        public List<Piatto> Fetch()
        {
            try
            {
                using (var menuCtx = new MenuContext())
                {
                    var piatti = menuCtx.Piatti.ToList();
                    return piatti;
                }
            }
            catch (Exception)
            {
                return new List<Piatto>();
            }
        }

        public Piatto GetById(int id)
        {
            if (id <= 0)
                return null;

            using (var menuCtx = new MenuContext())
            {
                return menuCtx.Piatti.Find(id);
            }
        }

        public bool Update(Piatto item)
        {
            if (item == null)
                return false;

            try
            {
                using (var menuCtx = new MenuContext())
                {
                    menuCtx.Piatti.Update(item);
                    menuCtx.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
        }
    }
}
