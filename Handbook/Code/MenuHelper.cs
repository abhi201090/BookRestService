using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Handbook.Code;

namespace Handbook.Code
{
    public class MenuHelper
    {
        public List<AllMenu> GetMenus()
        {
            List<AllMenu> mList = new List<AllMenu>();
            Menu m = new Menu();
            HandbookNewEntities ent = new HandbookNewEntities();
            foreach( var menu in ent.Menus)
            {
                AllMenu am = new AllMenu();
                am.id = menu.ID;
                am.name = menu.Name;
                am.parentID = menu.ParentID;
                mList.Add(am);
            }
            var list = ent.Menus.Select(menu => menu.ParentID).Distinct().Where(menu=>menu.Value != null).OrderByDescending(menu => menu.Value);
            
            foreach(var parentId in list)
            {
                var children = mList.Where(menu => menu.parentID == parentId).ToList<AllMenu>();
                mList.ForEach(menu =>
                {
                    if(menu.id == parentId)
                    {
                        menu.children = children;
                    }
                    mList = mList.Except(children).ToList<AllMenu>();
                });
            }

            return mList;
        }

        public IQueryable<MenuLink> GetMenuDetails(int menuId)
        {
            using(var db = new HandbookNewEntities())
            {
                IQueryable<MenuLink> menuLinks = from links in db.MenuLinks where links.ID == menuId select links;

                //var links = db.MenuLinks.Where(link => link.MenuID == menuId).ToList<MenuLink>();
                return menuLinks;
            }
            
        }
    }
}