﻿using BigSchool.Models;
using BigSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingCourses = _dbContext.Courses.Include(c => c.Lecture)
                .Include(c => c.category)
                .Where(c => c.DateTime > DateTime.Now);

            var viewModel = new CourseViewModel
            {
                UpcomingCourse = upcomingCourses,
                ShowAction = User.Identity.IsAuthenticated
            
            };
            return View(upcomingCourses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}