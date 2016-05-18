using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.DB;
using System.Data.SqlClient;

namespace Landau.Helper
{
    public class ProjectRemover
    {
        /// <summary>
        /// Очищаем исходники принадлежащие заданному проекту
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveSourceDocuments()
        {
            try
            {
                using (LandauEntities db = new LandauEntities())
                {
                    // Удаляем все ячейки, принадлежащие данному проекту
                    string cellsRemoveCommand =
                        "delete cells from SourceDocumentCell cells Join SourceDocumentRow Rows on cells.SourceDocumentRowId=Rows.Id " +
                        "JOIN SourceDocumentSheet sheets on Rows.SourceDocumentSheetId=sheets.Id " +
                        "JOIN SourceDocuments document on document.Id = sheets.SourceDocumentId " +
                        "where document.ProjectId = @ProjectId; \n";

                    // Исполняем команду удаления ячеек
                    //db.Database.SqlQuery<Object>(cellsRemoveCommand, new SqlParameter("@ProjectId", projectId)).ToList();


                    // Удаляем все ряды исходников, принадлежащих данному проекту
                    string rowsRemoveCommand = "DELETE [rows] FROM SourceDocumentRow [rows] " +
                                            "JOIN SourceDocumentSheet sheets ON [rows].SourceDocumentSheetId = sheets.Id " +
                                            "JOIN SourceDocuments document on document.Id = sheets.SourceDocumentId " +
                                            "where document.ProjectId = @ProjectId; \n";

                    // Исполняем команду удаления рядов
                   //db.Database.SqlQuery<Object>(rowsRemoveCommand, new SqlParameter("@ProjectId", projectId)).ToList();


                    // Удаляем все шиты исходников, связанные с данным проектом
                    string sheetsRemoveCommand = "delete sheets from SourceDocumentSheet sheets " +
                                              "JOIN SourceDocuments documents on documents.Id = sheets.SourceDocumentId " +
                                              "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                              "where documents.ProjectId = @ProjectId; \n";

                    // Исполняем команду удаления шитов
                     //db.Database.SqlQuery<Object>(sheetsRemoveCommand, new SqlParameter("@ProjectId", projectId)).ToList();


                    // Удаляем все документы (Source), связанные с проектом
                    string documentsRemoveCommand = "DELETE documents FROM SourceDocuments documents where documents.ProjectId = @ProjectId; \n";

                    // Исполняем команду удаления документов
                   // db.Database.SqlQuery<Object>(documentsRemoveCommand, new SqlParameter("@ProjectId", projectId)).ToList();

                    return cellsRemoveCommand + rowsRemoveCommand + sheetsRemoveCommand + documentsRemoveCommand;

                   // db.Database.SqlQuery<Object>(str, new SqlParameter("@ProjectId", projectId)).ToList();



                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление всех круговых диаграмм, связанных с проектом
        /// </summary>
        /// <param name="projectId"></param>
        public string RemovePieCharts()
        {
            try
            {
                string pieChartElementsDeleteCommand = "delete pchart_el from PieChartElement pchart_el " +
                "JOIN PieChart pchart on pchart_el.PieChartId = pchart.Id " +
                "JOIN AnalyticData adata on adata.Id = pchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                string pieChartsDeleteCommand = "delete pchart from PieChart pchart " +
                "JOIN AnalyticData adata on adata.Id = pchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(pieChartElementsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(pieChartsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}

                return pieChartElementsDeleteCommand + pieChartsDeleteCommand;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление всех столбиковых диаграмм, связанных с проектом
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveBarCharts()
        {
            try
            {
                string barChartElementsDeleteCommand = "delete bchart_el from BarChartElement bchart_el " +
                "JOIN BarChart bchart on bchart_el.BarChartId = bchart.Id " +
                "JOIN AnalyticData adata on adata.Id = bchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                string barChartsDeleteCommand = "delete bchart from BarChart bchart " +
                "JOIN AnalyticData adata on adata.Id = bchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(barChartElementsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(barChartsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}

                return barChartElementsDeleteCommand + barChartsDeleteCommand;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление всех линейных диаграмм, связанных с проектом
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveLineCharts()
        {
            try
            {
                string lineChartPointsDeleteCommand = "delete lchart_p from LineChartPoint lchart_p " +
                "JOIN LineChartElement lchart_el on lchart_el.Id = lchart_p.LineChartElementId " +
                "JOIN LineChart lchart on lchart_el.LineChartId = lchart.Id " +
                "JOIN AnalyticData adata on adata.Id = lchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                string lineChartElementsDeleteCommand = "delete lchart_el from LineChartElement lchart_el " +
                "JOIN LineChart lchart on lchart.Id = lchart_el.LineChartId " +
                "JOIN AnalyticData adata on adata.Id = lchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                string lineChartsDeleteCommand = "delete lchart from LineChart lchart " + 
                "JOIN AnalyticData adata on adata.Id = lchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(lineChartPointsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(lineChartElementsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(lineChartsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}

                return lineChartPointsDeleteCommand + lineChartElementsDeleteCommand + lineChartsDeleteCommand;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление всех стековых столбцовых диаграмм, связанных с проектом
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveStackedBarCharts()
        {
            try
            {
                string stackedBarChartElementsDeleteCommand = "delete sbchart_el from StackedBarchartElement sbchart_el " +
                "JOIN StackedBarchartColumn sbchart_c on sbchart_c.Id = sbchart_el.BarchartColumnId " +
                "JOIN StackedBarchart sbchart on sbchart.Id = sbchart_c.StackedBarChartId " +
                "JOIN AnalyticData adata on adata.Id = sbchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                string stackedBarChartColumnsDeleteCommand = "delete sbchart_c from StackedBarchartColumn sbchart_c " + 
                "JOIN StackedBarchart sbchart on sbchart.Id = sbchart_c.StackedBarChartId " +
                "JOIN AnalyticData adata on adata.Id = sbchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                string stackedBarChartsDeleteCommand = "delete sbchart from StackedBarchart sbchart " +
                "JOIN AnalyticData adata on adata.Id = sbchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(stackedBarChartElementsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(stackedBarChartColumnsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(stackedBarChartsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}

                return stackedBarChartElementsDeleteCommand + stackedBarChartColumnsDeleteCommand + stackedBarChartsDeleteCommand;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление всех нестековых столбцовых диаграмм, связанных с проектом
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveNonStackedBarCharts()
        {
            try
            {
                string nonStackedBarChartElementsDeleteCommand = "delete nsbchart_el from NonStackedBarChartElement nsbchart_el " +
                "JOIN NonStackedBarChartColumn nsbchart_c on nsbchart_c.Id = nsbchart_el.NonStackedBarChartColumnId " +
                "JOIN NonStackedBarChart nsbchart on nsbchart.Id = nsbchart_c.NonStackedBarChartId " +
                "JOIN AnalyticData adata on adata.Id = nsbchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                string nonStackedBarChartColumnsDeleteCommand = "delete nsbchart_c from NonStackedBarChartColumn nsbchart_c " + 
                "JOIN NonStackedBarChart nsbchart on nsbchart.Id = nsbchart_c.NonStackedBarChartId " +
                "JOIN AnalyticData adata on adata.Id = nsbchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                string nonStackedBarChartsDeleteCommand = "delete nsbchart from NonStackedBarChart nsbchart " +
                "JOIN AnalyticData adata on adata.Id = nsbchart.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(nonStackedBarChartElementsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(nonStackedBarChartColumnsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(nonStackedBarChartsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}

                return nonStackedBarChartElementsDeleteCommand + nonStackedBarChartColumnsDeleteCommand + nonStackedBarChartsDeleteCommand;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление всех модальных таблиц, связанных с проектом
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveTableModal()
        {
            try
            {
                string cellModalStylesDeleteCommand = "delete csmodal from CellModalStyle csmodal " +
                "JOIN CellModal cmodal on cmodal.Id = csmodal.CellModalId " +
                "JOIN RowModal rmodal on rmodal.Id = cmodal.RowModalId " +
                "JOIN BodyModal bmodal on bmodal.Id = rmodal.ModalBodyId " +
                "JOIN TableModal tmodal on tmodal.Id = bmodal.TableModalId " +
                "JOIN AnalyticData adata on adata.Id = tmodal.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                                "where projects.Id = @ProjectId; \n";

                string cellsModalDeleteCommand = "delete cmodal from CellModal cmodal " +
                "JOIN RowModal rmodal on rmodal.Id = cmodal.RowModalId " +
                "JOIN BodyModal bmodal on bmodal.Id = rmodal.ModalBodyId " +
                "JOIN TableModal tmodal on tmodal.Id = bmodal.TableModalId " +
                "JOIN AnalyticData adata on adata.Id = tmodal.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                                "where projects.Id = @ProjectId; \n";

                string rowsModalDeleteCommand = "delete rmodal from RowModal rmodal " +
                "JOIN BodyModal bmodal on bmodal.Id = rmodal.ModalBodyId " +
                "JOIN TableModal tmodal on tmodal.Id = bmodal.TableModalId " +
                "JOIN AnalyticData adata on adata.Id = tmodal.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                  "where projects.Id = @ProjectId; \n";

                string bodiesModalDeleteCommand = "delete bmodal from BodyModal bmodal " +
                "JOIN TableModal tmodal on tmodal.Id = bmodal.TableModalId " +
                "JOIN AnalyticData adata on adata.Id = tmodal.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId where documents.ProjectId = @ProjectId; \n";

                string tablesModalDeleteCommand = "delete tmodal from TableModal tmodal " +
                "JOIN AnalyticData adata on adata.Id = tmodal.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId where documents.ProjectId = @ProjectId; \n";

                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(cellModalStylesDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(cellsModalDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(rowsModalDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(bodiesModalDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(tablesModalDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}

                return cellModalStylesDeleteCommand + cellsModalDeleteCommand + 
                    rowsModalDeleteCommand + bodiesModalDeleteCommand + tablesModalDeleteCommand;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление всех таблиц перебросок, связанных с проектом
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveMoveTableModal()
        {
            try
            {
                string moveCellsDeleteCommand = "delete mtable_c from MoveTableCell mtable_c " +
                "JOIN MoveTableRow mtable_r on mtable_r.Id = mtable_c.MoveTableRowId " +
                "JOIN MoveTable mtable on mtable.Id = mtable_r.MoveTableId " +
                "JOIN AnalyticData adata on adata.Id = mtable.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId where documents.ProjectId = @ProjectId; \n";

                string moveRowsDeleteCommand = "delete mtable_r from MoveTableRow mtable_r " +
                "JOIN MoveTable mtable on mtable.Id = mtable_r.MoveTableId " +
                "JOIN AnalyticData adata on adata.Id = mtable.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId where documents.ProjectId = @ProjectId; \n";

                string moveTablesDeleteCommand = "delete mtable from MoveTable mtable " +
                "JOIN AnalyticData adata on adata.Id = mtable.AnalyticDataId " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId where documents.ProjectId = @ProjectId; \n";

                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(moveCellsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(moveRowsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(moveTablesDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}

                return moveCellsDeleteCommand + moveRowsDeleteCommand + moveTablesDeleteCommand;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление всех аналитических данных, связанных с проектом
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveAnalyticData()
        {
            try
            {
                string analyticDataDeleteCommand = "delete adata from AnalyticData adata " +
                "JOIN ModalViewCell mcells on mcells.Id = adata.ModalViewCellId " +
                "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                "JOIN Documents documents ON documents.Id = sheets.DocumentId " + 
                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                "where projects.Id = @ProjectId; \n";

                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(analyticDataDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}

                return analyticDataDeleteCommand;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление структуры модальных окон аналитических данных (чарты)
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveModalViews()
        {
            try
            {
                string modalViewCellsDeleteCommand = "delete mcells from ModalViewCell mcells " +
                                                 "JOIN ModalViewRow [mrows] on [mrows].Id = mcells.RowId " +
                                                 "JOIN ModalView mviews on mviews.Id = mrows.ModalViewId " +
                                                 "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                                                 "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                                                 "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                                                 "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                                                 "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                                                 "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                                 "where projects.Id = @ProjectId; \n";

                string modalViewRowsDeleteCommand = "delete [mrows] from ModalViewRow [mrows] " +
                                                 "JOIN ModalView mviews on mviews.Id = [mrows].ModalViewId " +
                                                 "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                                                 "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                                                 "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                                                 "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                                                 "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                                                 "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                                 "where projects.Id = @ProjectId; \n";

                string modalViewsDeleteCommand = "delete mviews from ModalView mviews " +
                                                 "JOIN Cell cells on cells.ModalViewId = mviews.Id " +
                                                 "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                                                 "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                                                 "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                                                 "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                                                 "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                                 "where projects.Id = @ProjectId; \n";

                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(modalViewCellsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(modalViewRowsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(modalViewsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}

                return modalViewCellsDeleteCommand + modalViewRowsDeleteCommand + modalViewsDeleteCommand;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление документов (Enterprise Sheets)
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveEnterpriseSheetDocuments()
        {
            try
            {
                string cellStylesDeleteCommand = "delete cstyles from CellStyles cstyles " +
                                                  "JOIN Cell cells on cells.Id = cstyles.CellId " +
                                                  "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                                                  "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                                                  "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                                                  "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                                                  "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                                "where projects.Id = @ProjectId; \n";

                string cellsDeleteCommand = "delete cells from Cell cells " +
                                            "JOIN [Row] [rows] ON cells.RowId = [rows].Id " +
                                            "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                                            "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                                            "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                                            "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                                "where projects.Id = @ProjectId; \n";

                string rowsDeleteCommand = "delete [rows] from [Row] [rows] " +
                                            "JOIN Body bodies ON bodies.Id = [rows].BodyId " +
                                            "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                                            "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                                            "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                                "where projects.Id = @ProjectId; \n";

                string bodiesDeleteCommand = "delete bodies from Body bodies " +
                                            "JOIN Sheet sheets ON sheets.Id = bodies.SheetId " +
                                            "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                                            "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                                "where projects.Id = @ProjectId; \n";

                string sheetsDeleteCommand = "delete sheets from Sheet sheets " +
                                            "JOIN Documents documents ON documents.Id = sheets.DocumentId " +
                                            "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                            "where projects.Id = @ProjectId; \n";

                string versionsDeleteCommand = "delete document_versions from DocumentControlVersion document_versions " +
                                               "JOIN Documents documents ON documents.Id = document_versions.DocId " +
                                               "where documents.ProjectId = @ProjectId; \n";

                string documentsDeleteCommand = "delete documents from Documents documents " +
                                                "JOIN Projects projects on projects.Id = documents.ProjectId " +
                                                "where projects.Id = @ProjectId; \n";

                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(cellStylesDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(cellsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(rowsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(bodiesDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(sheetsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(versionsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //    db.Database.SqlQuery<Object>(documentsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}

                return cellStylesDeleteCommand + cellsDeleteCommand +
                    rowsDeleteCommand + bodiesDeleteCommand +
                    sheetsDeleteCommand + versionsDeleteCommand +
                    documentsDeleteCommand;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Удаление проектов
        /// </summary>
        /// <param name="projectId"></param>
        public string RemoveProjects()
        {
            try
            {
                string projectsDeleteCommand = "delete projects from Projects projects where projects.Id = @ProjectId;";


                // Выполняем удаление
                //using (LandauEntities db = new LandauEntities())
                //{
                //    db.Database.SqlQuery<Object>(projectsDeleteCommand, new SqlParameter("@ProjectId", projectId)).ToList();
                //}
                return projectsDeleteCommand;
            }
            catch (Exception exception)
            {
                return "";
            }
        }

        public void RemoveProject(int projectId)
        {
            try
            {
                string command = 
                RemoveSourceDocuments() +
                RemovePieCharts() +
                RemoveBarCharts() +
                RemoveLineCharts() +
                RemoveStackedBarCharts() +
                RemoveNonStackedBarCharts() +
                RemoveTableModal() +
                RemoveMoveTableModal() +
                RemoveAnalyticData() +
                RemoveModalViews() +
                RemoveEnterpriseSheetDocuments() +
                RemoveProjects();

                using (LandauEntities db = new LandauEntities())
                {
                   var res =  db.Database.SqlQuery<Object>(command, new SqlParameter("@ProjectId", projectId)).ToList();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void RenameProject(int projectId, string nameNew)
        {
            try
            {
                using (LandauEntities db = new LandauEntities())
                {
                    Projects projectToRename = (from p in db.Projects where p.Id == projectId select p).ToList().LastOrDefault();

                    projectToRename.ProjectName = nameNew;
                    db.Projects.Add(projectToRename);

                    db.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                
            }
        }


    }
}