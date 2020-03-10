using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabTask1.Models;

namespace LabTask1.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Person p, uLogin u)
        {
            try
            {
                if (p.submit.Equals("Submit"))
                {
                   
                    if (name(p.Pname)){
                        
                        if (email(p.pEmail))
                        {
                            if (un(p.pUn))
                            {
                                if (pass(p.pPw))
                                {
                                    if (p.pPw.Equals(p.pcpw))
                                    {
                                        if (day(p.dd) && month(p.mm) && year(p.yyyy))
                                        {
                                            Session["username"] = p.pUn;
                                            Session["password"] = p.pPw;
                                            return Content("Registration Successful!!");
                                        }
                                        else
                                        {
                                            return Content("Invalid Date");
                                        }
                                    }
                                    else
                                    {
                                        return Content("Password doesn't match!");
                                    }
                                }
                                else
                                {
                                    return Content("Password should be at least 6 characters long!!");
                                }
                            }
                            else
                            {
                                return Content("Username can contain A-Z, a-z, 0-9, underscore and dot!!");
                            }
                        }
                        else
                        {
                            return Content("Invalid email address");
                        }
                    }
                    else
                    {
                        return Content("Name can contain only letter A-Z, a-z, space and dot ");
                    }
                    
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                try
                {
                    if (u.Login.Equals("Submit"))
                    {
                        if (Session["username"].Equals(u.uUn) && Session["password"].Equals(u.upw))
                        {
                            return Content("Login successfull");
                        }
                        else
                        {
                            return Content("Invalid credentials");
                        }

                    }
                    else
                    {
                        return View();
                    }
                }
                catch
                {
                    return View();
                }
            }

            
        }

        [NonAction]
        public static bool IsNullOrWhiteSpace(string s)

        {

            if (s == null)

                return true;



            return (s.Trim() == string.Empty);

        }

        [NonAction]
        public bool name(string n)
        {
            if (!IsNullOrWhiteSpace(n))
            {
                
                string s = n.Replace(".","");
                s = s.Replace(" ", "");
                if (s.All(char.IsLetter))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        [NonAction]
        public bool email(string n)
        {
            if (!IsNullOrWhiteSpace(n))
            {
                try
                {
                    var emailcheck = new System.Net.Mail.MailAddress(n);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        [NonAction]
        public bool pass(string n)
        {

            if (!IsNullOrWhiteSpace(n))
            {
                if (n.Length >= 6)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        [NonAction]
        public bool un(string n)
        {
            if (!IsNullOrWhiteSpace(n))
            {
                string s = n.Replace(".", "");
                s = s.Replace("_", "");
                if (s.All(char.IsLetterOrDigit))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        [NonAction]
        public bool day(string n)
        {
            if(!IsNullOrWhiteSpace(n)&& n.All(char.IsDigit) && Convert.ToInt32(n)<32)
            {
                return true;
            }
            return false;
        }
        public bool month(string n)
        {
            if (!IsNullOrWhiteSpace(n) && n.All(char.IsDigit) && Convert.ToInt32(n) < 12)
            {
                return true;
            }
            return false;
        }

        [NonAction]
        public bool year(string n)
        {
            if (!IsNullOrWhiteSpace(n) && n.All(char.IsDigit) && n.Length == 4)
            {
                return true;
            }
            return false;
        }


    }
}