using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Landau.DB;
using Landau.Models.OperationModels;

namespace Landau.Helper
{
    public static class OperationsHelper
    {
        /// <summary>
        /// конвертим изменения
        /// </summary>
        /// <param name="id"></param>
        /// <param name="changes"></param>
        /// <returns></returns>
        public static string ConvertChanges(string id, string changes)
        {
            try
            {
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// выполняем перемещение ячеек
        /// </summary>
        public static void MakeTransferCells(bool isSource, int documentId, string changes)
        {
            try
            {
                JavaScriptSerializer deserializer = new JavaScriptSerializer();
                TransferModel[] result = deserializer.Deserialize<TransferModel[]>(changes);
                if (result==null ||result.Length==0)
                {
                   return;
                }
                int projectId = 0;
                int userId = 0;
                int clientId = 0;
                using (LandauEntities entities = new LandauEntities())
                {
                    if (!isSource)
                    {
                        Documents document =
                            (from doc in entities.Documents where doc.Id == documentId select doc).FirstOrDefault();
                        userId = document.UserId;
                        projectId = Convert.ToInt32(document.ProjectId);
                    }
                    else
                    {
                        SourceDocuments sourceDocument =
                            (from s in entities.SourceDocuments where s.Id == documentId select s).FirstOrDefault();
                        userId = Convert.ToInt32(sourceDocument.UserId);
                        projectId = Convert.ToInt32(sourceDocument.ProjectId);
                    }
                    Projects project = (from s in entities.Projects where s.Id == projectId select s).FirstOrDefault();

                    clientId = project.ClientId;

                    OperationModel model = new OperationModel();
                    model.ClientId = clientId;
                    model.OperationType = 2;
                    model.UserId = userId;
                    model.ProjectId = projectId;

                    model.Contragents = new List<string>();

                    foreach (var transferModel in result)
                    {
                        int sourceRowId = Convert.ToInt32(transferModel.Id);
                        List<SourceDocumentCell> cells =
                            (from s in entities.SourceDocumentCell
                                where s.SourceDocumentRowId == sourceRowId
                                select s).ToList();
                        if (cells.Count > 0)
                        {
                            TransferCellModel mdl = new TransferCellModel();
                            mdl.CurrentCategoryType = Convert.ToInt32(cells[0].AnalyticDataType);
                            mdl.NewCategoryType = Convert.ToInt32(transferModel.Value);
                            mdl.SourceCellId = cells[0].Id;
                            mdl.CurrentDocumentType = Convert.ToInt32(cells[0].DocumentType);
                            model.TransferCells.Cells.Add(mdl);
                        }
                        
                    }

                    string strModel = XmlHelper.XMLSerialize(model);

                    Operations operations = new Operations();
                    operations.ClientId = clientId;
                    operations.OperationCommand = strModel;
                    operations.TimeAddToQueue = DateTime.Now;
                    operations.OperationState = 1;
                    operations.OperationType = 2;
                    operations.UserId = userId;
                    entities.Operations.Add(operations);
                    entities.SaveChanges();
                }
            }
            catch (Exception exception)
            {

            }
        }

        /// <summary>
        /// выполняем операцию закуп
        /// </summary>
        public static void MakePurchaseOperation(int documentId, string changes)
        {
            try
            {
                
                JavaScriptSerializer deserializer = new JavaScriptSerializer();
                var result = deserializer.Deserialize<PurchaseModel[]>(changes);
                if (result == null || result.Length == 0)
                {
                    return;
                }
                int projectId = 0;
                int userId = 0;
                int clientId = 0;
                using (LandauEntities entities = new LandauEntities())
                {
                    SourceDocuments document =
                            (from s in entities.SourceDocuments where s.Id == documentId select s).FirstOrDefault();
                    userId = Convert.ToInt32(document.UserId);
                    projectId =Convert.ToInt32(document.ProjectId);
                    Projects project = (from s in entities.Projects where s.Id == projectId select s).FirstOrDefault();

                    clientId = project.ClientId;

                    OperationModel model = new OperationModel();
                    model.ClientId = clientId;
                    model.OperationType = 1;
                    model.UserId = userId;
                    model.ProjectId = projectId;

                    model.Contragents = new List<string>();
                    foreach (var purchaseModel in result)
                    {
                        model.Contragents.Add(purchaseModel.Name);
                    }

                    string strModel = XmlHelper.XMLSerialize(model);

                    Operations operations = new Operations();
                    operations.ClientId = clientId;
                    operations.OperationCommand = strModel;
                    operations.TimeAddToQueue = DateTime.Now;
                    operations.OperationState = 1;
                    operations.OperationType = 1;
                    operations.UserId = userId;
                    entities.Operations.Add(operations);
                    entities.SaveChanges();
                }
            }
            catch (Exception exception)
            {
            }
        }
    }
}