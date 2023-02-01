using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using System.IO;


namespace Eco
{
    public class Application : IExternalApplication
    {
        static string thisAssemblyPath = typeof(Application).Assembly.Location;//path: the loaction is ../bin/Debug folder

        public Result OnStartup(UIControlledApplication application)
        {
            String panelName = "Eco Group 25"; // the name of panel

            RibbonPanel ribbonDemoPanel = application.CreateRibbonPanel(panelName); // create a new RibbonPanel on the Addin tab

            PushButton myButton = (PushButton)ribbonDemoPanel.AddItem(new PushButtonData("Eco", "Eco", thisAssemblyPath, "Eco.CustomControl1" ));

            //set the icon of button
            string ButtonIconsFolder = Path.GetDirectoryName(thisAssemblyPath) + "/../../"; //path: the loaction is ../bin/Debug folder
            
            myButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "Ribbon.png"), UriKind.Absolute)); //choose the .png with pixel 35x35. The size of the pixel is more appropriate

            myButton.ToolTip = "Click to open Eco Tool"; //tip of button

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

    }
}

