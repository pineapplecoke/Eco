using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using ClassLibrary_Eco_Group25_EE1;
using Autodesk.Revit.DB.Lighting;
using Autodesk.Revit.DB.Structure;
using System.IO;

namespace Eco
{
    public class Lampe
    {
        private FamilySymbol symbol;
        

        public Lampe(FamilySymbol symbol)
        {
            this.symbol = symbol;
        }

        public FamilySymbol Symbol { get => symbol; }


    }
}
