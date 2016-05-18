using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using Landau.DB;
using Landau.Models.CommentModel;
using Landau.Models.DocumentModel;
using Landau.Models.UserModel;

namespace Landau.Helper
{
    public class CommentHelper
    {
        public static bool AddComment(int sendUserId, int getUserId, int documentId, string message)
        {
            try
            {
                Comments comments = new Comments();

                comments.DocumentId = documentId;
                comments.UserIdSend = sendUserId;
                comments.UserIdGet = getUserId;
                comments.Data = message;
                comments.State = 0;
                comments.Date = DateTime.Now;

                using (LandauEntities entities = new LandauEntities())
                {
                    entities.Comments.Add(comments);
                    entities.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static List<CommentModelVm> GetComments(int documentid, int userid)
        {
            try
            {
                List<CommentModelVm> models = new List<CommentModelVm>();
                using (LandauEntities entities = new LandauEntities())
                {
                    List<Comments> q = (from s in entities.Comments where s.DocumentId == documentid select s).ToList();
                    foreach (var comments in q)
                    {
                        CommentModelVm vm = new CommentModelVm();
                        vm.Id = comments.Id;

                        Users user = (from s in entities.Users where s.Id == comments.UserIdSend select s).FirstOrDefault();

                        vm.SendUser = user.FirstName + " " + user.SecondName + " " + user.LastName;
                        vm.SendUserId = comments.UserIdSend;
                        vm.GetUserId = comments.UserIdGet;
                        vm.Data = comments.Data;
                        vm.Date = comments.Date.ToString();

                        if (comments.UserIdGet == userid)
                        {
                            comments.State = 1;
                            entities.Entry(comments).State = EntityState.Modified;
                            entities.SaveChanges();
                        }

                        models.Add(vm);
                    }
                }
               
                return models;
            }
            catch (Exception)
            {
                return null;
            }

        }


        public static List<CommentModelVm> GetCommentsForUser(int userid)
        {
            try
            {
                List<CommentModelVm> models = new List<CommentModelVm>();

                using (LandauEntities entities = new LandauEntities())
                {
                    var q = (from s in entities.Comments where s.UserIdGet == userid && s.State == 0 select s);
                    foreach (var comments in q)
                    {
                        CommentModelVm vm = new CommentModelVm();

                        var user = (from s in entities.Users where s.Id == comments.UserIdSend select s).FirstOrDefault();

                        vm.Id = comments.Id;
                        vm.SendUser = user.FirstName + " " + user.SecondName + " " + user.LastName;
                        vm.SendUserId = comments.UserIdSend;
                        vm.DocumentId = comments.DocumentId;

                        if (comments.Data.Length > 33)
                        {
                            vm.Data = comments.Data.Remove(33) + "...";
                        }
                        else
                        {
                            vm.Data = comments.Data;
                        }

                        vm.Date = comments.Date.ToString();

                        models.Add(vm);
                    }

                    return models;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}