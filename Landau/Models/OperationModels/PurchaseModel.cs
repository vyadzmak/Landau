﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.OperationModels
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Index { get; set; }

        public bool state { get; set; }
    }
}