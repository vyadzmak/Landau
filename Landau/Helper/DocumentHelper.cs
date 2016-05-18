using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Landau.DB;
using Landau.Models.DocumentModel;


namespace Landau.Helper
{
    public class DocumentHelper
    {
        #region Settings
        /// <summary>
        /// Отображение иконки файла по типу
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ShowSetting(int id)
        {
            try
            {
                using (LandauEntities entities = new LandauEntities())
                {
                    var q = (from s in entities.Settings where s.Id == id select s).FirstOrDefault();
                    return q.SettingsValue;
                }
            }
            catch (Exception exception)
            {
                return null;
            }

        }
        #endregion
        #region Add File
        /// <summary>
        /// Подвязка файла к БД
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="fileextension"></param>
        /// <param name="userid"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool AddFile(HttpPostedFileBase file, string path, Guid name, string fileextension, int userid, string description)
        {

            try
            {
                int projectId = -1;

                using (LandauEntities entities = new LandauEntities())
                {
                    int clientId = (from s in entities.Users where s.Id == userid select s.ClientId).FirstOrDefault();
                    Projects project = (from s in entities.Projects where s.ClientId == clientId && s.State == 1 select s).FirstOrDefault();

                    if (project == null)
                    {
                        project = new Projects();
                        project.ClientId = clientId;
                        project.CreationDate = DateTime.Now;
                        project.State = 1;

                        // Костыль для создания имени
                        project.ProjectName = Guid.NewGuid().ToString();

                        entities.Projects.Add(project);
                        entities.SaveChanges();
                        projectId = project.Id;
                    }
                    else
                    {
                        projectId = project.Id;
                    }

                    // var q = entities.Positions.Find(modelVm.CurrentProducerId);
                    Documents document = new Documents();
                    document.ProjectId = projectId;
                    document.FileName = file.FileName;
                    document.DocumentType = DocumentHelper.GetTypeDocumets(file);
                    document.State = 1;
                    document.ServerPath = name + fileextension;
                    document.Description = description.Trim();
                    document.UserId = userid;

                    if (document.DocumentType == 2) document.ViewType = 2;

                    if (document.DocumentType == 1 || document.DocumentType == 3 || document.DocumentType == 4 || document.DocumentType == 5)
                    {
                        document.ViewType = 1;
                    }

                    document.FileSize = file.ContentLength.ToString();
                    document.UploadDate = DateTime.Now;
                    document.CRC = BuildMd5Checksum(path);
                    document.GUID = name;

                    entities.Documents.Add(document);
                    entities.SaveChanges();

                    return true;
                }

                
            }
            catch (Exception exception)
            {

                return false;
            }

        }
        /// <summary>
        /// Кодировка Md5 для содержимого файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string BuildMd5Checksum(string path)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    return Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
        }
        #endregion
        #region Get InFormation About Files
        /// <summary>
        /// Получение информации с БД о файлах
        /// </summary>
        /// <returns></returns>
        public static List<DocumentModelVm> GetToAllFiles(int userId, int projectId)
        {
            try
            {
                List<DocumentModelVm> models = new List<DocumentModelVm>();

                using (LandauEntities entities = new LandauEntities())
                {
                    var q = (from s in entities.SourceDocuments
                             where ((s.UserId == userId) && (s.ProjectId == projectId))
                             select new { s.Id, s.FileName, s.FileSize, s.UploadDate, s.DocumentType, s.UserId, s.Extension });

                    foreach (var files in q)
                    {
                        DocumentModelVm vm = new DocumentModelVm();
                        vm.FileName = files.FileName;
                        vm.FileSize = Math.Round(files.FileSize / (1024 * 1024), 2);
                        vm.Id = files.Id;
                        vm.DataUpload = files.UploadDate.ToString();
                        vm.DocumentType = files.DocumentType;
                        // vm.DocumentTypeInt = files.DocumentType;
                        // vm.Image = Path.Combine(DocumentHelper.GetImageForFile(files.DocumentType));
                        // var user = (from s in entities.Users where s.Id == files.UserId select s).FirstOrDefault();
                        // vm.User = user.FirstName + " " + user.SecondName + " " + user.LastName;
                        // vm.DocumentType = files.Type;
                        //vm.Description = files.Description;

                        //var statecomments =
                        //    (from s in entities.Comments where s.DocumentId == vm.Id && s.State == 0 select s).FirstOrDefault();
                        //if (statecomments != null && statecomments.UserIdGet == userId)
                        //{
                        //    vm.StateComments = 0;
                        //}
                        //else
                        //{
                        //    vm.StateComments = 1;
                        //}
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



        /// <summary>
        /// Получение типов файлов(для поиска)
        /// </summary>
        /// <returns></returns>
        public static List<DocumentTypeListElement> GetToAllTypes()
        {
            try
            {
                List<DocumentTypeListElement> models = new List<DocumentTypeListElement>();

                using (LandauEntities entities = new LandauEntities())
                {
                    var q = (from s in entities.DocumentTypes select s);
                    foreach (var types in q)
                    {
                        DocumentTypeListElement vm = new DocumentTypeListElement();
                        vm.Id = types.Id;
                        vm.Title = types.Type;
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

        /// <summary>
        /// Получение типа элемента для добавления в таблицу Documents
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static int GetTypeDocumets(HttpPostedFileBase file)
        {
            try
            {
                string extension = Path.GetExtension(file.FileName).ToLower();
                switch (extension)
                {
                    case ".doc":
                        return 1;
                        break;
                    case ".docx":
                        return 1;
                        break;
                    case ".xls":
                        return 2;
                        break;
                    case ".xlsx":
                        return 2;
                        break;
                    case ".pdf":
                        return 3;
                        break;
                    case ".txt":
                        return 5;
                        break;
                    case ".jpg":
                        return 4;
                        break;
                    case ".jpeg":
                        return 4;
                        break;
                    case ".png":
                        return 4;
                        break;
                    case ".bmp":
                        return 4;
                        break;
                    default:
                        return 6;
                        break;
                }



            }
            catch (Exception)
            {

                return 6;
            }
        }
        /// <summary>
        /// Получение иконки для файла
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetImageForFile(int id)
        {
            try
            {
                switch (id)
                {
                    case 1:
                        return ShowSetting(3);
                        break;

                    case 2:
                        return ShowSetting(4);
                        break;

                    case 3:
                        return ShowSetting(5);
                        break;

                    case 4:
                        return ShowSetting(9);
                        break;

                    case 5:
                        return ShowSetting(8);
                        break;

                    default:
                        return ShowSetting(1);
                        break;
                }

            }
            catch (Exception)
            {

                return null;
            }
        }
        /// <summary>
        /// Получение самого файла(при скачивании)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DocumentModelVm GetFile(int id)
        {
            try
            {
                DocumentModelVm vm = new DocumentModelVm();

                using (LandauEntities entities = new LandauEntities())
                {
                    var q = (from s in entities.Documents where s.Id == id select s).FirstOrDefault();

                    vm.FileName = q.FileName;
                    vm.FileNameGuid = q.GUID;
                    vm.ServerPath = q.ServerPath;
                    vm.UserInt = q.UserId;

                    if (q.ServerPath.Contains(".pdf"))
                    {
                        vm.DocumentType = "application/pdf";
                        vm.DocumentTypeInt = q.DocumentType;
                    }

                    else if (q.ServerPath.Contains(".docx") || q.ServerPath.Contains(".doc"))
                    {
                        vm.DocumentType = "application/docx";
                    }
                    else if (q.ServerPath.Contains(".xlsx") || q.ServerPath.Contains(".xls"))
                    {
                        vm.DocumentType = "application/xlxs";
                    }
                    else if (q.ServerPath.Contains(".txt"))
                    {
                        vm.DocumentType = "application/txt";
                        vm.DocumentTypeInt = q.DocumentType;
                    }
                    else if (q.ServerPath.Contains(".jpg") || q.ServerPath.Contains(".jpeg") || q.ServerPath.Contains(".png") || q.ServerPath.Contains(".PNG") || q.ServerPath.Contains(".bmp"))
                    {
                        vm.DocumentType = "application/jpg";
                        vm.DocumentTypeInt = q.DocumentType;
                    }

                    return vm;
                }
                
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        public static DocumentModelVm GetFileName(int documentid)
        {
            try
            {
                DocumentModelVm fileproperty = new DocumentModelVm();

                using (LandauEntities entities = new LandauEntities())
                {
                    var q = (from s in entities.Documents where s.Id == documentid select s).FirstOrDefault();
                    // string filename = q.FileName;
                    fileproperty.FileName = q.FileName;
                    fileproperty.ProjectId = (int)q.ProjectId;
                }
                
                return fileproperty;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// обновляем статус проекта
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="stateId"></param>

        public static void UpdateProjectState(int projectId, int stateId)
        {
            try
            {
                using (LandauEntities entities = new LandauEntities())
                {
                    Projects project = (from s in entities.Projects where s.Id == projectId select s).FirstOrDefault();
                    project.State = stateId;
                    entities.SaveChanges();
                }
            }
            catch (Exception exception)
            {

            }
        }
        public static List<DocumentModelVm> ChangeWaitFiles(int userId)
        {
            try
            {
                List<DocumentModelVm> models = new List<DocumentModelVm>();
                int projectId = -1;

                using (LandauEntities entities = new LandauEntities())
                {
                    var q = (from s in entities.Documents
                             where s.UserId == userId && s.State == 1
                             select s);


                    foreach (var files in q)
                    {
                        files.State = 2;
                        projectId = (int)files.ProjectId;


                        entities.Entry(files).State = EntityState.Modified;
                        entities.SaveChanges();

                        DocumentModelVm vm = new DocumentModelVm();
                        vm.FileName = files.FileName;
                        vm.State = "подтвержденно";
                        models.Add(vm);
                    }
                }

                if (projectId != -1)
                {
                    UpdateProjectState(projectId, 2);
                }

                return models;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static List<DocumentModelVm> GetToAllFilesForAnalyst(int projectId, int userid)
        {
            try
            {
                List<DocumentModelVm> models = new List<DocumentModelVm>();

                using (LandauEntities entities = new LandauEntities())
                {
                    var query = (from doc in entities.SourceDocuments where doc.ProjectId == projectId && doc.UserId == userid select doc).ToList();

                    foreach (var files in query)
                    {
                        DocumentModelVm vm = new DocumentModelVm();
                        vm.FileName = files.FileName;
                        vm.FileSize = Math.Round(files.FileSize / (1024 * 1024), 2);
                        vm.Id = files.Id;
                        vm.DataUpload = files.UploadDate.ToString();

                        if (files.Extension.ToLower().Equals("xls") || files.Extension.ToLower().Equals("xlsx"))
                        {
                            vm.DocumentTypeInt = 3;
                        }
                        //vm.DocumentTypeInt = files.DocumentType;
                        //vm.Image = Path.Combine(DocumentHelper.GetImageForFile(files.DocumentType));
                        var user = (from s in entities.Users where s.Id == files.UserId select s).FirstOrDefault();
                        vm.User = user.FirstName + " " + user.SecondName + " " + user.LastName;
                        //   vm.DocumentType = files.Type;
                        // vm.Description = files.Description;
                        //var statecomments =
                        //   (from s in entities.Comments where s.DocumentId == vm.Id && s.State == 0 select s).FirstOrDefault();
                        //if (statecomments != null && statecomments.UserIdGet == userid)
                        //{
                        //    vm.StateComments = 0;
                        //}
                        //else
                        //{
                        //    vm.StateComments = 1;
                        //}
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
        public static List<DocumentModelVm> GetToAllOrders(int projectId)
        {
            try
            {
                List<DocumentModelVm> models = new List<DocumentModelVm>();

                using (LandauEntities entities = new LandauEntities())
                {
                    var query = (from doc in entities.Documents where doc.ProjectId == projectId && (doc.ViewType == 3) && doc.State != 6 select doc).ToList();
                    foreach (var files in query)
                    {
                        DocumentModelVm vm = new DocumentModelVm();
                        vm.FileName = files.FileName;
                        vm.FileSize = Math.Round(double.Parse(files.FileSize) / (1024 * 1024), 2);
                        vm.Id = files.Id;
                        vm.DataUpload = files.UploadDate.ToString();
                        //vm.DocumentTypeInt = files.DocumentType;
                        vm.Image = Path.Combine(DocumentHelper.GetImageForFile(files.DocumentType));
                        var user = (from s in entities.Users where s.Id == files.UserId select s).FirstOrDefault();
                        vm.User = user.FirstName + " " + user.SecondName + " " + user.LastName;
                        //   vm.DocumentType = files.Type;
                        vm.Description = files.Description;
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

        //public static string GetWay(string param)
        //{
        //    try
        //    {
        //        LandauEntities entities = new LandauEntities();
        //        var query = (from doc in entities.Settings where doc.SettingsName.Equals(param) select doc).FirstOrDefault();
        //        return query.SettingsValue;
        //    }
        //    catch (Exception)
        //    {

        //      return null;
        //    }
        //}




        #endregion
    }

}