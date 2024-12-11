using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP_Management_System.Auth;
using TRP_Management_System.DTOs;
using TRP_Management_System.EF;

namespace TRP_Management_System.Controllers
{
    public class ChannelController : Controller
    {
        TRPEntities db = new TRPEntities(); 
        public static Channel Convert(ChannelDTO d)
        {
            return new Channel()
            {
                ChannelId = d.ChannelId,
                ChannelName = d.ChannelName,
                EstablishedYear = d.EstablishedYear,
                Country = d.Country
            };
        }
        public static ChannelDTO Convert(Channel d)
        {
            return new ChannelDTO()
            {
                ChannelId = d.ChannelId,
                ChannelName = d.ChannelName,
                EstablishedYear = d.EstablishedYear,
                Country = d.Country
            };
        }
        public List<ChannelDTO> Convert(List<Channel> data)
        {
            var list = new List<ChannelDTO>();
            foreach (var d in data)
            {
                list.Add(Convert(d));
            }
            return list;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ChannelDTO());
        }

        [HttpPost]
        public ActionResult Create(ChannelDTO d)
        {
            if (ModelState.IsValid)
            {

                db.Channels.Add(Convert(d));
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(d);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var exobj = db.Channels.Find(id);

            return View(Convert(exobj));
        }

        [HttpPost]

        public ActionResult Edit(Channel c)
        {

            var exobj = db.Channels.Find(c.ChannelId);
            exobj.ChannelId = c.ChannelId;
            exobj.ChannelName = c.ChannelName;
            exobj.EstablishedYear = c.EstablishedYear;
            exobj.Country = c.Country;
           

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Channels.Find(id);
            return View(Convert(data));
        }
        [HttpPost]
        public ActionResult Delete(int Id, string dcsn)
        {
            if (dcsn.Equals("Yes"))
            {
                var data = db.Channels.Find(Id);
                db.Channels.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        [Logged]
        public ActionResult List()
        {

            var data = db.Channels.ToList();
        

            return View(Convert(data));
        }

        public ActionResult Details(int id)
        {

            var data = db.Channels.Find(id);
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View(new List<ChannelDTO>());  // Return empty list for initial view
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return View(new List<ChannelDTO>());
            }

            var results = db.Channels
                .Where(c => c.ChannelName.Contains(name))
                .ToList();

            return View(Convert(results));  // Using your existing Convert method
        }



    }
}