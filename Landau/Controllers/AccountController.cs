using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Landau.Models;
using Landau.Models.UserModel;
using Landau.Helper;
using Landau.Models.UserLoginsModel;

namespace Landau.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        #region Login

        /// <summary>
        /// Страница авторизации
        /// </summary>

        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            try
            {
                
                if (Session["UserId"] != null)
                {
                    return RedirectToAction("Cabinet", "Cabinet");
                }
                else
                {
                    ViewBag.StartSession = Session["UserId"];
                    ViewBag.StartLogin = Session["Name"];
                    return View();
                }
               

            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");

            }
        }
        /// <summary>
        /// Выход, уничтожение сессии
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>

        [AllowAnonymous]
        public ActionResult KillSession(int? check)
        {
            try
            {

                Session.Clear();

                if (check == 1)
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            catch (Exception exception)
            {
                return RedirectToAction("Index", "Home");

            }

        }
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public bool Login(UserLoginsModel model)
        {
            try
            {
                var sessionforuser = UserHelper.LoginForUser(model);

                if (sessionforuser != null)
                {

                    Session["UserId"] = sessionforuser.Id;
                    Session["Roles"] = sessionforuser.RolesForDb;
                    Session["Name"] = sessionforuser.FirstName;
                    int a = (int)Session["UserId"] ;
                    string f = (string)Session["Name"];
                    return true;

                }
                else
                {
                    ViewBag.logincheck = false;
                    return false;
                }

            }
            catch (Exception)
            {

                return false;
            }

        }
        #endregion

        #region Register
        /// <summary>
        /// Страница регистрации пользователя
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public bool Register(UserModel model)
        {
            try
            {
                int clientid = UserHelper.RegistrationForClients(model.RegistrationNumber, model.NameOrganisation);

                int userid = UserHelper.RegistrationForUsers(model, clientid);
                if (UserHelper.RegistrationForUserLogins(model.Email, userid, model.Password))
                {
                    bool checksendtoemai = SendEmailHelper.SendToEmail(model.Email, model.FirstName, model.SecondName, model.LastName);
                    if (checksendtoemai)
                    {
                        Session["UserId"] = userid;
                        Session["Roles"] = 1;
                        Session["Name"] = model.FirstName + " " + model.SecondName + " " + model.LastName;

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }



            }
            catch (Exception exception)
            {

                return false;
            }

        }
        /// <summary>
        /// Проверка на уникальность Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public bool CheckEmail(string email)
        {


            try
            {

                bool checkemail = UserHelper.CheckEmail(email);
                if (checkemail)
                {
                    return false;
                }
                else
                {
                    return true;
                }


            }
            catch (Exception)
            {

                return false;
            }


        }
        /// <summary>
        /// Проверка на совпадение паролей
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public bool CheckPassword(UserModel model)
        {


            try
            {

                if (model.Password.Equals(model.ConfirmPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {

                return false;
            }


        }
        #endregion

    }
}