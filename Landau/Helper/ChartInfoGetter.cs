using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Landau.DB;
using Landau.Models.Modal;

namespace Landau.Helper
{
    public class ChartInfoGetter
    {
        public List<ChartInfo> GetChartInfo(ModalView view)
        {
            try
            {
                List<ModalViewCell> cells = new List<ModalViewCell>();
                List<ChartInfo> infos = new List<ChartInfo>();

                using (LandauEntities db = new LandauEntities())
                {
                    var rowQuery = (from r in db.ModalViewRow
                                    where r.ModalViewId == view.Id
                                    select new
                                    {
                                        Id = r.Id
                                    }).ToList();

                    List<ModalViewCell> cellQuery = (from c in db.ModalViewCell where 1 == 1 select c).ToList();

                    foreach (var rowItem in rowQuery)
                    {
                        foreach (var cellItem in cellQuery)
                        {
                            if (cellItem.RowId == rowItem.Id)
                            {
                                cells.Add(cellItem);
                            }
                        }
                    }

                    var chartInfoQuery = (from c in cells
                                          join ad in db.AnalyticData on c.Id equals ad.ModalViewCellId
                                          select new
                                          {
                                              AnalyticDataId = ad.Id,
                                              TypeId = ad.TypeId
                                          }).ToList();

                    foreach (var item in chartInfoQuery)
                    {
                        infos.Add(new ChartInfo(item.AnalyticDataId, item.TypeId));
                    }

                    return infos;
                }
                
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}