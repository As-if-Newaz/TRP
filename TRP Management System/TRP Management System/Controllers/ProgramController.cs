using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP_Management_System.DTOs;
using TRP_Management_System.EF;

namespace TRP_Management_System.Controllers
{
    public class ProgramController : Controller
    {
        TRPEntities db = new TRPEntities();
        public static Program Convert(ProgramDTO d)
        {
            return new Program()
            {
                ProgramId = d.ProgramId,
                ProgramName = d.ProgramName,
                TRPScore = d.TRPScore,
                ChannelId = d.ChannelId,
                AirTime = d.AirTime,
            };
        }
        public static ProgramDTO Convert(Program d)
        {
            return new ProgramDTO()
            {
                ProgramId = d.ProgramId,
                ProgramName = d.ProgramName,
                TRPScore = d.TRPScore,
                ChannelId = d.ChannelId,
                AirTime = d.AirTime,
            };
        }
        public List<ProgramDTO> Convert(List<Program> data)
        {
            var list = new List<ProgramDTO>();
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
            return View(new ProgramDTO());
        }

        [HttpPost]
        public ActionResult Create(ProgramDTO d)
        {
            if (ModelState.IsValid)
            {

                db.Programs.Add(Convert(d));
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(d);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var exobj = db.Programs.Find(id);

            return View(Convert(exobj));
        }

        [HttpPost]

        public ActionResult Edit(Program c)
        {

            var exobj = db.Programs.Find(c.ProgramId);
            exobj.ProgramId = c.ProgramId;
            exobj.ProgramName = c.ProgramName;
            exobj.TRPScore = c.TRPScore;
            exobj.ChannelId = c.ChannelId;
            exobj.AirTime = c.AirTime;


            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Programs.Find(id);
            return View(Convert(data));
        }
        [HttpPost]
        public ActionResult Delete(int Id, string dcsn)
        {
            if (dcsn.Equals("Yes"))
            {
                var data = db.Programs.Find(Id);
                db.Programs.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult List()
        {

            var data = db.Programs.ToList();


            return View(Convert(data));
        }

        public ActionResult Details(int id)
        {

            var data = db.Programs.Find(id);
            return View(Convert(data));
        }


    }
}