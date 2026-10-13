using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplicationTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Newsletter;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public ActionResult Index()
        {
            string txt = "Hello World";
            string filePath = Server.MapPath("~/log.txt");
            System.IO.File.WriteAllText(filePath, txt);
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            { 
                string queryStr = @"INSERT INTO SignUps (FirstName, LastName, EmailAddress) VALUES 
                                    (@firstName, @lastName, @emailAddress)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryStr, connection);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@emailAddress", emailAddress);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                    return View("~/Views/Shared/Success.cshtml");
            }
        }
          
        public ActionResult Admin()
        {
            string queryStr = "SELECT * FROM SignUps";
            List<SignupUser> signupUsers = new List<SignupUser>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryStr, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    SignupUser sUser = new SignupUser();
                    sUser.Id = Convert.ToInt32(reader["Id"]);
                    sUser.FirstName = reader["FirstName"].ToString();
                    sUser.LastName = reader["LastName"].ToString();
                    sUser.EmailAddress = reader["EmailAddress"].ToString();         
                    signupUsers.Add(sUser);
                }
                connection.Close();
            }
            return View(signupUsers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(int id)
        {
            ViewBag.Message = "Your contact page" + id.ToString();

            return View();
        }
    }
}