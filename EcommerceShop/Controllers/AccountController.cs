﻿using EcommerceShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceShop.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            List<Tbl_Members> userList = _userRepo.GetAll();
            return View(userList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tbl_Members u)
        {
            u.IsActive = true;
            u.CreatedOn = DateTime.Now;
            _userRepo.Create(u);       
            TempData["Msg"] = $"User {u.EmailId} added!";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(_userRepo.Get(id));
        }
        public ActionResult Edit(int id)
        {
            return View(_userRepo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Tbl_Members u)
        {
            _userRepo.Update(u.MemberId, u);
            TempData["Msg"] = $"User {u.EmailId} Updated!";
            return RedirectToAction("Index");
           
        }

        public ActionResult Delete(int id)
        {
            
            _userRepo.Delete(id);
            TempData["Msg"] = $"User Deleted!";

            return RedirectToAction("Index");
        }

    }
}