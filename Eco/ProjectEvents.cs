using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using System.ComponentModel;
using ClassLibrary_Eco_Group25_EE1;


namespace Eco
{
    [Serializable]
    public class ProjectEvents
    {
        private ExternalEvent _updateEvent;
        private ExternalEvent _placeLampe;
        private ExternalEvent _updateVolume;
        public Building b; 

        public ProjectEvents(ExternalEvent updateEvent,ExternalEvent placeLampe, ExternalEvent updateVolume ,Building b)
        {
            _updateEvent = updateEvent;
            _placeLampe = placeLampe;
            _updateVolume = updateVolume;
            this.b = b; 

        }

        public ProjectEvents()
        {

        }

        public ExternalEvent Update { get => _updateEvent; }
        public ExternalEvent Place { get => _placeLampe; }

        public ExternalEvent UpdateVolume { get => _updateVolume; }


    }
}
