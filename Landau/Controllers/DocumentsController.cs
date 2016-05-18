using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Landau.DB;
using Landau.Helper;
using Landau.Models.CommentModel;
using Landau.Models.DocumentModel;
using Landau.Models.UserModel;
using PagedList.Mvc;
using PagedList;
using Landau.Models.XModels;
using System.Web.Script.Serialization;
using Landau.Models;
using Landau.Models.SourceModels;

namespace Landau.Controllers
{
    public class DocumentsController : Controller
    {



        /// <summary>
        /// Добавление комментария в БД
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="message"></param>
        /// <returns></returns>

        [HttpPost]
        public JsonResult SendtoEmail(UserModel userModel, string message)
        {
            try
            {
                int sendUserId = (int)Session["UserId"];
                if ((int)Session["Roles"] == 2)
                {
                    bool addcomment = CommentHelper.AddComment(sendUserId, userModel.Id, userModel.DocumentId, message);

                    if (addcomment)
                    {
                        bool checksend = SendEmailHelper.SendToEmail(userModel);
                        if (checksend)
                        {
                            return new JsonResult();
                        }
                        else
                        {
                            return null;
                        }

                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    bool addcomment = CommentHelper.AddComment(sendUserId, 1091, userModel.DocumentId, message);
                    if (addcomment)
                    {
                        bool checksend = SendEmailHelper.SendToEmail(userModel.DocumentId, 1091);
                        if (checksend)
                        {
                            return new JsonResult();
                        }
                        else
                        {
                            return null;
                        }

                    }
                    else
                    {
                        return null;
                    }

                }

            }
            catch (Exception)
            {

                return null;
            }

        }

        #region Uplod Files

        /// <summary>
        /// Загрузка файлов на сервер и добавление их в БД
        /// </summary>
        ///// <param name="files"></param>
        ///// <param name="description"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Upload(string description)
        {

            try
            {
                // List<int> idList = new List<int>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                    var fileextension = Path.GetExtension(file.FileName);
                    Guid name = Guid.NewGuid();
                    var path = Path.Combine(DocumentHelper.ShowSetting(1), name.ToString());
                    var newpath = Path.Combine(path + fileextension);
                    file.SaveAs(newpath);
                    int usersessionid = (int)Session["UserId"];
                    DocumentHelper.AddFile(file, newpath, name, fileextension, usersessionid, description);
                    //  idList.Add( DocumentHelper.AddFile(file, newpath, name, fileextension, usersessionid, description));
                    ViewBag.Roles = Session["Roles"];
                }
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            catch (Exception exception)
            {
                return null;
            }

        }



        #endregion
        #region GetInformation from DB
        /// <summary>
        /// Получение информации о файлах из БД
        /// </summary>
        /// <returns></returns>

        public JsonResult GetDocuments(string id)
        {
            try
            {
                int projectId = Int32.Parse(id);
                DocumentsModel models = new DocumentsModel();
                int userId = (int)Session["UserId"];
                if ((int)Session["Roles"] == 1)
                {

                    models.Documents = DocumentHelper.GetToAllFiles(userId, projectId).ToList();
                    ViewBag.Roles = Session["Roles"];

                }
                else
                {

                    models.Documents = DocumentHelper.GetToAllFilesForAnalyst(projectId, userId);

                    ViewBag.Roles = Session["Roles"];


                }
                return new JsonResult { Data = models.Documents, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


            }
            catch (Exception)
            {

                return null;
            }

        }
        public JsonResult GetOrders(string id)
        {
            try
            {
                int projectId = Int32.Parse(id);
                DocumentsModel models = new DocumentsModel();
                ViewBag.Roles = Session["Roles"];

                models.Documents = DocumentHelper.GetToAllOrders(projectId);

                return new JsonResult { Data = models.Documents, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {

                return null;
            }

        }

        /// <summary>
        /// Получение типов загруженных файлов
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDocumentType()
        {
            try
            {

                List<DocumentTypeListElement> documentTypeList = new List<DocumentTypeListElement>();
                documentTypeList = DocumentHelper.GetToAllTypes().ToList();
                ViewBag.Roles = Session["Roles"];
                return new JsonResult { Data = documentTypeList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {

                return null;
            }

        }

        public JsonResult GetMessagesForUser()
        {
            try
            {

                List<CommentModelVm> messages = new List<CommentModelVm>();
                messages = CommentHelper.GetCommentsForUser((int)Session["UserId"]).ToList();
                //     ViewBag.Roles = Session["Roles"];
                return new JsonResult { Data = messages, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {

                return null;
            }

        }


        #endregion
        #region DownloadFiles
        /// <summary>
        /// Скачивание файлов с БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileResult Download(int id)
        {
            try
            {
                var file = DocumentHelper.GetFile(id);
                var filepath = DocumentHelper.ShowSetting(1) + "/" + file.ServerPath;//Path.Combine(DocumentHelper.ShowSetting(1), file.ServerPath);
                string filename = file.ServerPath;
                if (file.DocumentTypeInt == 3)
                {
                    FileStream fsSource = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                    ViewBag.Roles = Session["Roles"];
                    return new FileStreamResult(fsSource, file.DocumentType);
                }

                if (file == null)
                {
                    //
                }

                //if (file.DocumentTypeInt == 4)
                //{
                //    ViewBag.Roles = Session["Roles"];
                //    //return base.File(filename, "image/jpeg");
                //    System.IO.FileStream fs = System.IO.File.OpenRead(filename);
                //    byte[] data = new byte[fs.Length];
                //    int br = fs.Read(data, 0, data.Length);

                //    return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);;
                //}

                //if (file.DocumentTypeInt == 5)
                //{
                //    ViewBag.Roles = Session["Roles"];
                //    System.IO.FileStream fs = System.IO.File.OpenRead(filename);
                //    byte[] data = new byte[fs.Length];
                //    int br = fs.Read(data, 0, data.Length);

                //    return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
                //    //return base.File(filename, "txt/plain");
                //}
                //else
                //{
                //    ViewBag.Roles = Session["Roles"];
                //    return File(filename, file.DocumentType, file.FileName);
                //}

                ViewBag.Roles = Session["Roles"];
                System.IO.FileStream fs = System.IO.File.OpenRead(filepath);
                byte[] data = new byte[fs.Length];
                int br = fs.Read(data, 0, data.Length);

                return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, filename);

            }
            catch (Exception exception)
            {

                return null;
            }
        }
        #endregion
        /// <summary>
        /// Получение комментариев о файлах
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetComment(int id)
        {
            try
            {
                int userid = (int)Session["UserId"];
                List<CommentModelVm> comments = new List<CommentModelVm>();
                comments = CommentHelper.GetComments(id, userid).ToList();

                return new JsonResult { Data = comments, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {

                return null;
            }
        }
        /// <summary>
        /// Страница чата
        /// </summary>
        /// <param name="documentid"></param>
        /// <returns></returns>
        public ActionResult Chat(int documentid)
        {
            try
            {
                if (Session["UserId"] != null)
                {
                    ViewBag.StartSession = Session["UserId"];
                    ViewBag.StartLogin = Session["Name"];
                    DocumentModelVm document = new DocumentModelVm();
                    document = DocumentHelper.GetFile(documentid);
                    ViewBag.Roles = Session["Roles"];
                    UserModel user = new UserModel();

                    user = UserHelper.GetUser(document.UserInt);
                    user.DocumentId = documentid;
                    return View(user);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception)
            {

                return null;
            }

        }

        public JsonResult WaitConfirm()
        {
            try
            {
                var model = DocumentHelper.ChangeWaitFiles((int)Session["UserId"]);
                return new JsonResult { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception exception)
            {

                return null;
            }
        }

        public string GetModalXls(string documentId)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return SourceDocumentToViewConverter.GetToSourceDocumentToViewModel(Int32.Parse(documentId));

            }
            catch (Exception exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Getting details about money transaction in current cell in Sheets
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="sheetIndex"></param>
        /// <param name="rowIndex"></param>
        /// <param name="cellIndex"></param>
        /// <returns></returns>
        public string GetDetails(string documentId, string sheetNumber, string rowNumber, string columnNumber)
        {
            try
            {
                int docId = Int32.Parse(documentId);
                int sheetInd = Int32.Parse(sheetNumber);
                int rowInd = Int32.Parse(rowNumber);
                int cellInd = Int32.Parse(columnNumber);

                SDocument details = SourceDocumentToViewConverter.GetDetailsFromSourceDocument(docId,
                    DocumentNavigationHelper.GetNecessaryCellId(docId, sheetInd, rowInd, cellInd));

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(details);
            }
            catch (Exception exception)
            {
                return "";
            }
        }

        public string Zakup(string id)
        {
            try
            {
                int idInteger = Int32.Parse(id);
                return SourceDocumentToViewConverter.GetZakup(idInteger);


            }
            catch (Exception exception)
            {
                return "";
            }
        }

        [HttpPost]
        public void RemoveProject(string id)
        {
            try
            {
                int idInt = Int32.Parse(id);

                ProjectRemover projectRemover = new ProjectRemover();

                projectRemover.RemoveProject(idInt);
            }
            catch (Exception exception)
            {

            }
        }

        [HttpPost]
        public JsonResult GetLog(string docId)
        {
            if (docId == "")
            {
                throw new ArgumentNullException();
            }

            try
            {
                int dId = Int32.Parse(docId);
                JavaScriptSerializer s = new JavaScriptSerializer();
                var j = s.Serialize(DatabaseToModelConverter.GetReportLogs(dId));
                return Json(DatabaseToModelConverter.GetReportLogs(dId), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}