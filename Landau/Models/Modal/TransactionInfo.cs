using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.Modal
{
    public class TransactionInfo
    {
        public List<string> TransactionNames;
        public List<string> TransactionCategories;

        public TransactionInfo()
        {
            TransactionNames = new List<string>();
            TransactionCategories = new List<string>();

            TransactionNames.Add("Getsuyoubi");
            TransactionNames.Add("Kayoubi");
            TransactionNames.Add("Suiyoubi");
            TransactionNames.Add("Mokuyoubi");
            TransactionNames.Add("Kinyoubi");
            TransactionNames.Add("Doyoubi");
            TransactionNames.Add("Nichiyoubi");

            TransactionCategories.Add("Weekday");
            TransactionCategories.Add("Day off");
        }
    }
}