using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week14Day5.Core.Entities;
using Week14Day5.Core.Interfaces;

namespace Week14Day5.EF.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MenuContext menuCtx;
        public MenuRepository()
        {
            menuCtx = new MenuContext();
        }
        public bool Add(Menu item)
        {
            if (item == null)
                return false;

            try
            {
                menuCtx.IMenu.Add(item);
                menuCtx.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {

                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                return false;

            try
            {
                var menu = menuCtx.IMenu.Find(id);

                if (menu != null)
                    menuCtx.IMenu.Remove(menu);

                menuCtx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
        
        }
        public List<Menu> Fetch()
        {
            try
            {
                var imenu = menuCtx.IMenu.ToList();
                return imenu;
            }
            catch (Exception)
            {
                return new List<Menu>();
            }
        }

        public Menu GetById(int id)
        {
            if (id <= 0)
                return null;

            return menuCtx.IMenu.Find(id);
        }

        public bool Update(Menu item)
        {
            if(item == null)
                return false;

            try
            {
                menuCtx.IMenu.Update(item);
                menuCtx.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {

                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
        }
    }
}
