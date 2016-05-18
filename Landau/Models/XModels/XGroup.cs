using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landau.Models.XModels
{
    public class XGroup
    {
        public int Id;
        public int Start;
        public int End;
        public string Name;
        public string Type;
        public int Level;

        public XGroup(int id, int start, int end, string name, string type, int level)
        {
            Id = id;
            Start = start;
            End = end;
            Name = name;
            Type = type;
            Level = level;
        }
    }
}