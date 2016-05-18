using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Landau.DB;
using Landau.Models.UserLoginsModel;
using Landau.Models.UserModel;

namespace Landau.Helper
{
    public class UserHelper
    {
        #region Registration
        /// <summary>
        /// Регистрация клиентов
        /// </summary>
        /// <param name="registrationNumber"></param>
        /// <param name="nameOrganisation"></param>
        /// <returns></returns>
        public static int RegistrationForClients(int registrationNumber, string nameOrganisation)
        {
            try
            {
                Clients client = new Clients();

                client.Name = nameOrganisation;
                client.RegistrationNumber = registrationNumber;
                client.IsLocked = false;
                client.IsClient = true;

                using (LandauEntities entities = new LandauEntities())
                {
                    entities.Clients.Add(client);
                    entities.SaveChanges();
                }

                int clientid = client.Id;

                return clientid;
            }
            catch (Exception)
            {

                return 0;
            }

        }
        /// <summary>
        /// Регистрация users
        /// </summary>
        /// <param name="model"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public static int RegistrationForUsers(UserModel model, int clientId)
        {
            try
            {
                Users user = new Users();

                user.FirstName = model.FirstName;
                user.SecondName = model.SecondName;
                user.LastName = model.LastName;
                user.Department = "aaa";
                user.Roles = 1;
                user.Rights = "bbb";
                user.ClientId = clientId;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                using (LandauEntities entities = new LandauEntities())
                {
                    entities.Users.Add(user);
                    entities.SaveChanges();
                }

                int userid = user.Id;

                return userid;
            }
            catch (Exception exception)
            {
                return 0;
            }

        }
        /// <summary>
        /// Добавление информации в таблицу UserLogins
        /// </summary>
        /// <param name="login"></param>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool RegistrationForUserLogins(string login, int userId, string password)
        {
            try
            {
                
                UserLogins userLogins = new UserLogins();

                userLogins.UserId = userId;
                userLogins.Login = login.Trim();
                userLogins.Password = PasswordHelper.Crypt.EncryptString(password.Trim());
                userLogins.LastLoginDate = DateTime.Now;
                userLogins.IsLocked = false;

                using (LandauEntities entities = new LandauEntities())
                {
                    entities.UserLogins.Add(userLogins);
                    entities.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }

        }
        #endregion
        #region Log In
        /// <summary>
        /// Авторизация 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserModel LoginForUser(UserLoginsModel model)
        {
            try
            {
                UserLogins q;
                string password = PasswordHelper.Crypt.EncryptString(model.Password.Trim());


                using (LandauEntities entities = new LandauEntities())
                {
                    q = (from s in entities.UserLogins where s.Login.Equals(model.Login.Trim()) && s.Password.Equals(password) select s).FirstOrDefault();

                    if (q != null)
                    {
                        UserLogins user = entities.UserLogins.Find(q.Id); ;
                        user.LastLoginDate = DateTime.Now;
                        entities.Entry(user).State = EntityState.Modified;
                        entities.SaveChanges();
                        var usersession = entities.Users.Find(q.UserId);
                        UserModel sessionforuser = new UserModel();
                        sessionforuser.Id = user.UserId;
                        sessionforuser.RolesForDb = usersession.Roles;
                        sessionforuser.FirstName = usersession.FirstName + " " + usersession.SecondName + " " +
                                                   usersession.LastName;


                        return sessionforuser;
                    }
                    else
                    {
                        return null;
                    }
                }



            }
            catch (Exception exception)
            {

                return null;
            }

        }
        #endregion
        #region Check Email
        /// <summary>
        /// Проверка на уникальность Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CheckEmail(string email)
        {
            try
            {
                Users q;

                using (LandauEntities entities = new LandauEntities())
                {
                    q = (from s in entities.Users where s.Email.Equals(email.Trim()) select s).FirstOrDefault();
                }

                if (q != null)
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

                return true;
            }
        }
        #endregion

        public static UserModel GetUser(int id)
        {

            try
            {
                UserModel user = new UserModel();

                using (LandauEntities entities = new LandauEntities())
                {
                    var q = (from s in entities.Users where s.Id == id select s).FirstOrDefault();
                    user.LastName = q.LastName;
                    user.FirstName = q.FirstName;
                    user.SecondName = q.SecondName;
                    user.Email = q.Email;
                    user.Id = q.Id;
                }

                return user;
            }
            catch (Exception exception)
            {

                return null;
            }
        }
    }
}