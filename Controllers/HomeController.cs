using MovieTicketBooking.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieTicketBooking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Movies()
        {
            return View();
        }

        public ActionResult MovieDetails()
        {
            return View();
        }
        public ActionResult Blogs()
        {
            return View();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }
        public ActionResult Faqs()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModal model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ticketdb"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                { 

                    using (SqlCommand cmd = new SqlCommand("CheckUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", model.Username);
                        cmd.Parameters.AddWithValue("@Password", model.Password);

                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            string username = reader["Username"].ToString();

                            Session["Username"] = username; // Set session
                            TempData["WelcomeMessage"] = "Welcome " + username + "!";

                            return RedirectToAction("Index", "Home"); // go to home page
                        }
                        else
                        {
                            ViewBag.Message = "Invalid Username or Password.";
                            return View(model);
                        }
                    }
                }
            }

            ViewBag.Message = "Please enter valid login details.";
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ticketdb"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", model.Username);
                        cmd.Parameters.AddWithValue("@Email", model.Email);
                        cmd.Parameters.AddWithValue("@Password", model.Password);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                ViewBag.Message = "Registration Successful!";
                return RedirectToAction("Login"); // redirect to login after registration
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Ticket()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(ContactMessageModal model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ticketdb"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertContactMessage", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", model.Name);
                        cmd.Parameters.AddWithValue("@Email", model.Email);
                        cmd.Parameters.AddWithValue("@Phone", model.Phone ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Subject", model.Subject ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Message", model.Message);
                        cmd.Parameters.AddWithValue("@CreatedAt", model.CreatedAt);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                ViewBag.Message = "Your message has been sent successfully!";
                ModelState.Clear();
                return View();
            }

            return View(model);
        }



        public ActionResult Comment()
        {
            return View();
        }
        public ActionResult UpcomingMovies()
        {
            return View();
        }
        public ActionResult FilmAward()
        {
            return View();
        }
        public ActionResult WebSeries()
        {
            return View();
        }
        public ActionResult Trailer()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckEmail(string Email)
        {
            if (!string.IsNullOrEmpty(Email))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ticketdb"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("GetDetailsWithEmailId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", Email);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string username = reader["Username"].ToString();
                        Session["Username"] = username; // Store username in session
                        TempData["WelcomeMessage"] = "Welcome " + username + "!";
                    }
                    else
                    {
                        TempData["WelcomeMessage"] = "Email not found!";
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Booking()
        {
            var theaters = new List<TheaterModel>();
            return View(theaters);
        }

        [HttpPost]
        public ActionResult Booking(FormCollection collection)
        {
            var theaters = new List<TheaterModel>
            {
                new TheaterModel
                {
                    TheaterName = "Cinepolis: Nexus Seawoods",
                    Location = "Navi Mumbai",
                    ShowTimings = new List<string> { "04:30 PM", "09:35 PM" },
                    IsCancellable = true
                },
                new TheaterModel
                {
                    TheaterName = "Cinepolis: Viviana Mall",
                    Location = "Thane",
                    ShowTimings = new List<string> { "05:55 PM" },
                    IsCancellable = false
                }
            };
            return View(theaters);
        }









    }
}