using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class ShelfController : Controller
    {
        private fridgeContext db = new fridgeContext();
        [Authorize]
        public IActionResult Index()
        {
            String email = User.Identity.Name;
            var query = from p in db.User where p.Email.Equals(email) select p;
            User cur_user = query.Single();
            var query_1 = from itempattern in db.Itempattern
                          join item in db.Item on itempattern.ItemPatternId equals item.ItemPatterId
                          join shelf in db.Shelf on item.ShelfId equals shelf.ShelfId
                          join storage in db.Storage on shelf.StorageId equals storage.StorageId
                          join privelege in db.Privilege on storage.StorageId equals privelege.StorageId
                          join user in db.User on privelege.UserId equals user.UserId
                          where user == cur_user
                          select shelf;
            var list1 = query_1.Distinct().ToList();
            return View(list1);
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {   
            var items = from itempattern in db.Itempattern
                        join item in db.Item on itempattern.ItemPatternId equals item.ItemPatterId
                        join shelf in db.Shelf on item.ShelfId equals id
                        select itempattern;
            var list = items.Distinct().ToList();
            return View(list);
        }
    }
}