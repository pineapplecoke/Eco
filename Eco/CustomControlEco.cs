using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using ClassLibrary_Eco_Group25_EE1;
using Autodesk.Revit.DB.Lighting;
using Autodesk.Revit.DB.Structure;
using System.IO;


namespace Eco
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]


    public class CustomControl1 : IExternalCommand
    {
        private static Document _doc;
        private static UIDocument _uidoc;

        private Building b = new Building("Import", 1, "import", 1, "Import");

        private ICollection<Element> floors;
        private IEnumerable<SpatialElement> rooms;
        private IEnumerable<Element> walls;

        private double volume;


        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiApp = commandData.Application;
            _uidoc = uiApp.ActiveUIDocument;
            _doc = _uidoc.Document;
            get_objects();


            UpdateInRevit updateHandler = new UpdateInRevit();
            ExternalEvent updateEvent = ExternalEvent.Create(updateHandler);

            PlaceLightWithImpacts placeHandler = new PlaceLightWithImpacts();
            ExternalEvent placeLamp = ExternalEvent.Create(placeHandler);

            UpdateVolumeToObjectAndLamp updateVolumeHandeler = new UpdateVolumeToObjectAndLamp();
            ExternalEvent updateVolume = ExternalEvent.Create(updateVolumeHandeler);

            ProjectEvents ev = new ProjectEvents(updateEvent, placeLamp, updateVolume, b);
            show_form(ev);
            return Result.Succeeded;

        }

        private void get_objects()
        {
            FilteredElementCollector collector = new FilteredElementCollector(_doc);
            ICollection<Element> floors = collector.OfClass(typeof(Level)).ToElements();
            //ICollection<Element> rooms = collector.OfClass(typeof(Autodesk.Revit.DB.Architecture.Room)).ToElements();
            //IEnumerable<Element> walls = collector.OfCategory(BuiltInCategory.OST_Walls).ToElements();

            this.floors = floors;
            //this.rooms = rooms;
            //this.walls = walls;

            cast_floors();
            addWalls();
            addRooms();





        }


        public void show_form(ProjectEvents pe)
        {
            FormStart dialog = new FormStart(pe);
            //dialog.import_building(b);
            dialog.ShowDialog();
        }

        public Building get_building()
        {
            return b;
        }

        public void cast_floors()
        {
            foreach (Element f in floors)
            {
                ClassLibrary_Eco_Group25_EE1.Floor fl = new ClassLibrary_Eco_Group25_EE1.Floor(f.Id.ToString(), f.Name);
                b.AddFloor(fl);
            }
        }
        //Die Funktion hat keine wirkliche Funktion mehr. Allerdings will ich sie erstmal drin lassen! Hier werden die Wände dem Floor zugeordnet. 
        public void cast_walls(ClassLibrary_Eco_Group25_EE1.Floor floor)
        {
            FilteredElementCollector collector = new FilteredElementCollector(_doc);
            IEnumerable<Element> walls = collector.OfCategory(BuiltInCategory.OST_Walls).ToElements().Where(o => o.LevelId.ToString().Equals(floor.FloorNumber));
            this.walls = walls;

            foreach (Element wall in walls)
            {

                if (wall.Name.Contains("STB"))
                {
                    try
                    {
                        double volume = 0.0283168 * wall.GetParameters("Volumen")[0].AsDouble();
                        this.volume = volume;
                    }
                    catch (System.ArgumentOutOfRangeException e)
                    {
                        double volume = 0.0283168 * wall.GetParameters("Volume")[0].AsDouble();
                        this.volume = volume;
                    }
                    string material = "concrete";
                    ClassLibrary_Eco_Group25_EE1.Wall wa = new ClassLibrary_Eco_Group25_EE1.Wall(wall.Name, wall.Id.ToString(), this.volume, material);
                    floor.AddWall(wa);
                }
                else if (wall.Name.Contains("MW"))
                {
                    try
                    {
                        double volume = 0.0283168 * wall.GetParameters("Volumen")[0].AsDouble();
                        this.volume = volume;
                    }
                    catch (System.ArgumentOutOfRangeException e)
                    {
                        double volume = 0.0283168 * wall.GetParameters("Volume")[0].AsDouble();
                        this.volume = volume;
                    }
                    string material = "masonry";
                    ClassLibrary_Eco_Group25_EE1.Wall wa = new ClassLibrary_Eco_Group25_EE1.Wall(wall.Name, wall.Id.ToString(), this.volume, material);
                    floor.AddWall(wa);
                }
                else if (wall.Name.Contains("GK"))
                {
                    try
                    {
                        double volume = 0.0283168 * wall.GetParameters("Volumen")[0].AsDouble();
                        this.volume = volume;
                    }
                    catch (System.ArgumentOutOfRangeException e)
                    {
                        double volume = 0.0283168 * wall.GetParameters("Volume")[0].AsDouble();
                        this.volume = volume;
                    }
                    string material = "wood";
                    ClassLibrary_Eco_Group25_EE1.Wall wa = new ClassLibrary_Eco_Group25_EE1.Wall(wall.Name, wall.Id.ToString(), this.volume, material);
                    floor.AddWall(wa);
                }
                
            }
        }


        public void cast_rooms(ClassLibrary_Eco_Group25_EE1.Floor floor)
        {
            FilteredElementCollector collector = new FilteredElementCollector(_doc);
            IEnumerable<SpatialElement> rooms = collector.WhereElementIsNotElementType().OfClass(typeof(SpatialElement)).Where(r => r.GetType() == typeof(Autodesk.Revit.DB.Architecture.Room)).Where(r => r.LevelId.ToString().Equals(floor.FloorNumber)).Cast<Autodesk.Revit.DB.SpatialElement>();
            this.rooms = rooms;


            foreach (SpatialElement room in rooms)
            {
                SpatialElementBoundaryOptions options = new SpatialElementBoundaryOptions();
                options.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
                IList<IList<Autodesk.Revit.DB.BoundarySegment>> s = room.GetBoundarySegments(options);
                List<String> ids = new List<string>();

                foreach (IList<Autodesk.Revit.DB.BoundarySegment> seg in s)
                {
                    foreach (Autodesk.Revit.DB.BoundarySegment boundSeg in seg)
                    {

                        String e = boundSeg.ElementId.ToString();
                        ids.Add(e);
                    }

                }

                ClassLibrary_Eco_Group25_EE1.Room room_new = new ClassLibrary_Eco_Group25_EE1.Room(room.Id.ToString(), room.Name);

                floor.AddRoom(room_new);
                addWall_to_room(room_new, ids);

            }
        }

        public void addRooms()
        {
            foreach (ClassLibrary_Eco_Group25_EE1.Floor f in b.Floors)
            {
                cast_rooms(f);
            }
        }


        public void addWalls()
        {
            foreach (ClassLibrary_Eco_Group25_EE1.Floor f in b.Floors)
            {
                cast_walls(f);
            }
        }

        //Hier werden die Wände den Räumen zugeordnet. Dies ist die Funktion die im Moment das im Treeview abbildet. 
        public void addWall_to_room(Room room, List<String> ids)
        {
            foreach (string id in ids)
            {

                FilteredElementCollector collector = new FilteredElementCollector(_doc);
                IEnumerable<Element> walls = collector.OfCategory(BuiltInCategory.OST_Walls).ToElements().Where(o => o.Id.ToString().Equals(id));


                foreach (Element wall in walls)
                {


                    if (wall.Name.Contains("STB"))
                    {
                        try
                        {
                            double volume = 0.0283168 * wall.GetParameters("Volumen")[0].AsDouble();
                            this.volume = volume;
                        }
                        catch (System.ArgumentOutOfRangeException e)
                        {
                            double volume = 0.0283168 * wall.GetParameters("Volume")[0].AsDouble();
                            this.volume = volume;
                        }
                        string material = "concrete";
                        ClassLibrary_Eco_Group25_EE1.Wall wa = new ClassLibrary_Eco_Group25_EE1.Wall(wall.Name, wall.Id.ToString(), this.volume, material);
                        room.AddWall(wa);
                    }
                    else if (wall.Name.Contains("MW"))
                    {
                        try
                        {
                            double volume = 0.0283168 * wall.GetParameters("Volumen")[0].AsDouble();
                            this.volume = volume;
                        }
                        catch (System.ArgumentOutOfRangeException e)
                        {
                            double volume = 0.0283168 * wall.GetParameters("Volume")[0].AsDouble();
                            this.volume = volume;
                        }
                        string material = "masonry";
                        ClassLibrary_Eco_Group25_EE1.Wall wa = new ClassLibrary_Eco_Group25_EE1.Wall(wall.Name, wall.Id.ToString(), this.volume, material);
                        room.AddWall(wa);
                    }
                    else if (wall.Name.Contains("GK"))
                    {
                        try
                        {
                            double volume = 0.0283168 * wall.GetParameters("Volumen")[0].AsDouble();
                            this.volume = volume;
                        }
                        catch (System.ArgumentOutOfRangeException e)
                        {
                            double volume = 0.0283168 * wall.GetParameters("Volume")[0].AsDouble();
                            this.volume = volume;
                        }
                        string material = "wood";
                        ClassLibrary_Eco_Group25_EE1.Wall wa = new ClassLibrary_Eco_Group25_EE1.Wall(wall.Name, wall.Id.ToString(), this.volume, material);
                        room.AddWall(wa);
                    }
                    

                }
            }
        }




        public class UpdateInRevit : IExternalEventHandler
        {
            public void Execute(UIApplication app)
            {
                updateRevit(FromReport.name, FromReport.type, FromReport.id, FromReport.calculation);
            }


            public void updateRevit(string name, string type, string id, Report calculation)
            {
                if (calculation != null)
                {
                    using (Transaction trans = new Transaction(_doc))
                    {

                        if (trans.Start("Change Parameters") == TransactionStatus.Started)
                        {

                            if (type.Equals("Floor"))
                            {
                                FilteredElementCollector collector = new FilteredElementCollector(_doc);
                                IEnumerable<Element> floors = collector.OfClass(typeof(Level)).ToElements().Where(o => o.Id.ToString().Equals(id));

                                if (floors.Count() < 2)

                                {
                                    foreach (Element floor in floors)
                                    {
                                        floor.GetParameters("GWP").First().Set((calculation.get_impacts()[0][0] + calculation.get_impacts()[1][0] + calculation.get_impacts()[2][0] + calculation.get_impacts()[3][0]));
                                        floor.GetParameters("ODP").First().Set((calculation.get_impacts()[0][1] + calculation.get_impacts()[1][1] + calculation.get_impacts()[2][1] + calculation.get_impacts()[3][1]));
                                        floor.GetParameters("POCP").First().Set((calculation.get_impacts()[0][2] + calculation.get_impacts()[1][2] + calculation.get_impacts()[2][2] + calculation.get_impacts()[3][2]));
                                        floor.GetParameters("AP").First().Set((calculation.get_impacts()[0][3] + calculation.get_impacts()[1][3] + calculation.get_impacts()[2][3] + calculation.get_impacts()[3][3]));
                                        floor.GetParameters("EP").First().Set((calculation.get_impacts()[0][4] + calculation.get_impacts()[1][4] + calculation.get_impacts()[2][4] + calculation.get_impacts()[3][4]));
                                        floor.GetParameters("ADPE").First().Set((calculation.get_impacts()[0][5] + calculation.get_impacts()[1][5] + calculation.get_impacts()[2][5] + calculation.get_impacts()[3][5]));
                                        floor.GetParameters("ADPF").First().Set((calculation.get_impacts()[0][6] + calculation.get_impacts()[1][6] + calculation.get_impacts()[2][6] + calculation.get_impacts()[3][6]));
                                    }
                                }
                                trans.Commit();
                            }
                            else if (type.Equals("Room"))
                            {
                                FilteredElementCollector collector = new FilteredElementCollector(_doc);
                                IEnumerable<SpatialElement> rooms = collector.WhereElementIsNotElementType().OfClass(typeof(SpatialElement)).Where(r => r.GetType() == typeof(Autodesk.Revit.DB.Architecture.Room)).Where(r => r.Id.ToString().Equals(id)).Cast<SpatialElement>();
                                if (rooms.Count() < 2)

                                {
                                    foreach (SpatialElement room in rooms)
                                    {
                                        room.GetParameters("GWP").First().Set((calculation.get_impacts()[0][0] + calculation.get_impacts()[1][0] + calculation.get_impacts()[2][0] + calculation.get_impacts()[3][0]));
                                        room.GetParameters("ODP").First().Set((calculation.get_impacts()[0][1] + calculation.get_impacts()[1][1] + calculation.get_impacts()[2][1] + calculation.get_impacts()[3][1]));
                                        room.GetParameters("POCP").First().Set((calculation.get_impacts()[0][2] + calculation.get_impacts()[1][2] + calculation.get_impacts()[2][2] + calculation.get_impacts()[3][2]));
                                        room.GetParameters("AP").First().Set((calculation.get_impacts()[0][3] + calculation.get_impacts()[1][3] + calculation.get_impacts()[2][3] + calculation.get_impacts()[3][3]));
                                        room.GetParameters("EP").First().Set((calculation.get_impacts()[0][4] + calculation.get_impacts()[1][4] + calculation.get_impacts()[2][4] + calculation.get_impacts()[3][4]));
                                        room.GetParameters("ADPE").First().Set((calculation.get_impacts()[0][5] + calculation.get_impacts()[1][5] + calculation.get_impacts()[2][5] + calculation.get_impacts()[3][5]));
                                        room.GetParameters("ADPF").First().Set((calculation.get_impacts()[0][6] + calculation.get_impacts()[1][6] + calculation.get_impacts()[2][6] + calculation.get_impacts()[3][6]));
                                    }
                                }
                                trans.Commit();
                            }
                            else if (type.Equals("Wall"))
                            {
                                FilteredElementCollector collector = new FilteredElementCollector(_doc);
                                IEnumerable<Element> walls = collector.OfCategory(BuiltInCategory.OST_Walls).ToElements().Where(o => o.Id.ToString().Equals(id));

                                if (walls.Count() < 2)
                                {
                                    foreach (Element wall in walls)
                                    {
                                        wall.GetParameters("GWP").First().Set((calculation.get_impacts()[0][0] + calculation.get_impacts()[1][0] + calculation.get_impacts()[2][0] + calculation.get_impacts()[3][0]));
                                        wall.GetParameters("ODP").First().Set((calculation.get_impacts()[0][1] + calculation.get_impacts()[1][1] + calculation.get_impacts()[2][1] + calculation.get_impacts()[3][1]));
                                        wall.GetParameters("POCP").First().Set((calculation.get_impacts()[0][2] + calculation.get_impacts()[1][2] + calculation.get_impacts()[2][2] + calculation.get_impacts()[3][2]));
                                        wall.GetParameters("AP").First().Set((calculation.get_impacts()[0][3] + calculation.get_impacts()[1][3] + calculation.get_impacts()[2][3] + calculation.get_impacts()[3][3]));
                                        wall.GetParameters("EP").First().Set((calculation.get_impacts()[0][4] + calculation.get_impacts()[1][4] + calculation.get_impacts()[2][4] + calculation.get_impacts()[3][4]));
                                        wall.GetParameters("ADPE").First().Set((calculation.get_impacts()[0][5] + calculation.get_impacts()[1][5] + calculation.get_impacts()[2][5] + calculation.get_impacts()[3][5]));
                                        wall.GetParameters("ADPF").First().Set((calculation.get_impacts()[0][6] + calculation.get_impacts()[1][6] + calculation.get_impacts()[2][6] + calculation.get_impacts()[3][6]));
                                    }
                                }
                                trans.Commit();
                            }
                        }
                    }
                }
            }


            public string GetName()
            {
                return "Update Information";
            }

        }


        public class PlaceLightWithImpacts : IExternalEventHandler
        {

            public void Execute(UIApplication app)
            {
                placeLampInRoom(FromReport.id, FromReport.calculation);
                WriteReportInLamp(FromReport.id, FromReport.calculation);
            }



            public void placeLampInRoom(string id, Report calculation)
            {
                if (calculation != null)
                {
                    FilteredElementCollector collector = new FilteredElementCollector(_doc);
                    IEnumerable<SpatialElement> rooms = collector.WhereElementIsNotElementType().OfClass(typeof(SpatialElement)).Where(r => r.GetType() == typeof(Autodesk.Revit.DB.Architecture.Room)).Where(r => r.Id.ToString().Equals(id)).Cast<Autodesk.Revit.DB.Architecture.Room>();
                    //TaskDialog.Show("Revit",rooms.ToString());
                    if (rooms.Count() < 2)

                    {

                        using (Transaction trans = new Transaction(_doc))
                        {

                            if (trans.Start("Change Parameters") == TransactionStatus.Started)
                            {

                                foreach (Autodesk.Revit.DB.Architecture.Room room in rooms)
                                {


                                    XYZ max = room.get_BoundingBox(null).Max;
                                    XYZ min = room.get_BoundingBox(null).Min;
                                    //TaskDialog.Show("Revit", min.ToString());



                                    double länge = (max.X + min.X) * 0.5;
                                    double breite = (max.Y + min.Y) * 0.5;
                                    double höhe = 0;

                                    XYZ location = new XYZ(länge, breite, höhe);
                                    //TaskDialog.Show("Revit", location.ToString());


                                    Family family = FindElementByName(_doc, typeof(Family), "Downlight") as Family;
                                    //TaskDialog.Show("Revit", "Family");

                                    if (null == family)
                                    {
                                        string fileName = @"C:\ProgramData\Autodesk\RVT 2019\Libraries\Germany\Architektur - Bauteil\Leuchten\Innenleuchte\Downlight.rfa";

                                        if (!File.Exists(fileName))
                                        {
                                            throw new Exception("Unable to load " + fileName);
                                        }


                                        using (Transaction tx = new Transaction(_doc))
                                        {
                                            tx.Start("Load Family");
                                            _doc.LoadFamily(fileName, out family);
                                            //TaskDialog.Show("Revit", "Loaded");
                                            tx.Commit();
                                        }
                                    }
                                    Family family1 = FindElementByName(_doc, typeof(Family), "Downlight") as Family;
                                    ISet<ElementId> sy = family1.GetFamilySymbolIds();

                                    BindingList<Lampe> lampen = new BindingList<Lampe>();

                                    foreach (ElementId id_sy in sy)
                                    {
                                        //TaskDialog.Show("Revit", id_sy.ToString());
                                        try
                                        {
                                            FamilySymbol lamp = (FamilySymbol)family.Document.GetElement(id_sy);

                                            Lampe lamp_obj = new Lampe(lamp);

                                            lampen.Add(lamp_obj);

                                        }
                                        catch (Exception e)
                                        {
                                            TaskDialog.Show("Revit", e.ToString());
                                        }

                                    }

                                    lampen[0].Symbol.Activate();
                                    _doc.Regenerate();
                                    //TaskDialog.Show("Revit", "Regenerate");

                                    try
                                    {
                                        _doc.Create.NewFamilyInstance(location, lampen[0].Symbol, StructuralType.NonStructural);

                                    }
                                    catch (Exception exc)
                                    {
                                        TaskDialog.Show("Revit", exc.ToString());
                                    }
                                    //TaskDialog.Show("Revit", "placed");
                                }
                            }

                            trans.Commit();
                        }


                    }
                }
            }

            public string GetName()
            {
                return "Place Information";
            }

            public static Element FindElementByName(Document doc, Type targetType, string targetName)
            {
                return new FilteredElementCollector(doc).OfClass(targetType).FirstOrDefault<Element>(e => e.Name.Equals(targetName));
            }

            public void WriteReportInLamp(string id, Report calculation)
            {
                FilteredElementCollector collector = new FilteredElementCollector(_doc);
                IEnumerable<SpatialElement> rooms = collector.WhereElementIsNotElementType().OfClass(typeof(SpatialElement)).Where(r => r.GetType() == typeof(Autodesk.Revit.DB.Architecture.Room)).Where(r => r.Id.ToString().Equals(id)).Cast<Autodesk.Revit.DB.Architecture.Room>();
                //TaskDialog.Show("Revit", "Family");
                if (rooms.Count() < 2)

                {

                    using (Transaction trans4 = new Transaction(_doc))
                    {
                        if (trans4.Start("Change Parameters") == TransactionStatus.Started)
                        {


                            foreach (Autodesk.Revit.DB.Architecture.Room room in rooms)
                            {

                                BoundingBoxXYZ bb = room.get_BoundingBox(null);
                                Outline outline = new Outline(bb.Min, bb.Max);
                                //TaskDialog.Show("Revit", "Family1");
                                BoundingBoxIntersectsFilter filter = new BoundingBoxIntersectsFilter(outline);

                                BuiltInCategory[] bics = new BuiltInCategory[] { BuiltInCategory.OST_LightingDevices, BuiltInCategory.OST_LightingFixtures, BuiltInCategory.OST_Lights, };

                                LogicalOrFilter categoryFilter = new LogicalOrFilter(bics.Select<BuiltInCategory, ElementFilter>(bic => new ElementCategoryFilter(bic)).ToList<ElementFilter>());

                                FilteredElementCollector collector1 = new FilteredElementCollector(_doc).WhereElementIsNotElementType().WhereElementIsViewIndependent().OfClass(typeof(FamilyInstance)).WherePasses(filter).WherePasses(categoryFilter);
                                //TaskDialog.Show("Revit", "Family2");

                                List<FamilyInstance> a = new List<FamilyInstance>();


                                foreach (FamilyInstance fi in collector1)
                                {

                                    a.Add(fi);

                                }
                                //TaskDialog.Show("Revit", a.Count().ToString());
                                foreach (FamilyInstance lamp in a)
                                {

                                    //TaskDialog.Show("Revit", "Family4");
                                    lamp.GetParameters("GWP").First().Set((calculation.get_impacts()[0][0] + calculation.get_impacts()[1][0] + calculation.get_impacts()[2][0] + calculation.get_impacts()[3][0]));
                                    lamp.GetParameters("ODP").First().Set((calculation.get_impacts()[0][1] + calculation.get_impacts()[1][1] + calculation.get_impacts()[2][1] + calculation.get_impacts()[3][1]));
                                    lamp.GetParameters("POCP").First().Set((calculation.get_impacts()[0][2] + calculation.get_impacts()[1][2] + calculation.get_impacts()[2][2] + calculation.get_impacts()[3][2]));
                                    lamp.GetParameters("AP").First().Set((calculation.get_impacts()[0][3] + calculation.get_impacts()[1][3] + calculation.get_impacts()[2][3] + calculation.get_impacts()[3][3]));
                                    lamp.GetParameters("EP").First().Set((calculation.get_impacts()[0][4] + calculation.get_impacts()[1][4] + calculation.get_impacts()[2][4] + calculation.get_impacts()[3][4]));
                                    lamp.GetParameters("ADPE").First().Set((calculation.get_impacts()[0][5] + calculation.get_impacts()[1][5] + calculation.get_impacts()[2][5] + calculation.get_impacts()[3][5]));
                                    lamp.GetParameters("ADPF").First().Set((calculation.get_impacts()[0][6] + calculation.get_impacts()[1][6] + calculation.get_impacts()[2][6] + calculation.get_impacts()[3][6]));
                                }

                            }
                            trans4.Commit();
                        }
                    }
                    //TaskDialog.Show("Revit", "Family5");


                }

            }


        }


        public class UpdateVolumeToObjectAndLamp : IExternalEventHandler
        {

            public void Execute(UIApplication app)
            {
                updatevolumetoObject(FormOverview.id, FormOverview.type, FormOverview.volumes);

            }


            public void updatevolumetoObject(string id, string type, double[] volumes)
            {
                try {
                    //TaskDialog.Show("Revit", type);
                    if (volumes != null)
                    {
                        //TaskDialog.Show("Revit", "Family2");
                        using (Transaction trans = new Transaction(_doc))
                        {
                            //TaskDialog.Show("Revit", "Family3");
                            if (trans.Start("Update Volumes") == TransactionStatus.Started)
                            {
                                //TaskDialog.Show("Revit", "Family4");
                                if (type.Equals("Floor"))
                                {
                                    FilteredElementCollector collector = new FilteredElementCollector(_doc);
                                    IEnumerable<Element> floors = collector.OfClass(typeof(Level)).ToElements().Where(o => o.Id.ToString().Equals(id));
                                    //TaskDialog.Show("Revit", "Family5");
                                    if (floors.Count() < 2)

                                    {
                                        foreach (Element floor in floors)
                                        {
                                            floor.GetParameters("Concrete").First().Set(volumes[0]);
                                            floor.GetParameters("Masonry").First().Set(volumes[1]);
                                            floor.GetParameters("Wood").First().Set(volumes[2]);

                                        }
                                        trans.Commit();
                                    }
                                }
                                else if (type.Equals("Room"))
                                {
                                    //TaskDialog.Show("Revit", "Family7");
                                    FilteredElementCollector collector1 = new FilteredElementCollector(_doc);
                                    IEnumerable<SpatialElement> rooms = collector1.WhereElementIsNotElementType().OfClass(typeof(SpatialElement)).Where(r => r.GetType() == typeof(Autodesk.Revit.DB.Architecture.Room)).Where(r => r.Id.ToString().Equals(id)).Cast<SpatialElement>();
                                    if (rooms.Count() < 2)
                                        //TaskDialog.Show("Revit", "Family8");
                                    {
                                        foreach (SpatialElement room in rooms)
                                        {
                                            room.GetParameters("Concrete").First().Set(volumes[0]);
                                            room.GetParameters("Masonry").First().Set(volumes[1]);
                                            room.GetParameters("Wood").First().Set(volumes[2]);

                                            //TaskDialog.Show("Revit", "Family4");

                                            BoundingBoxXYZ bb = room.get_BoundingBox(null);
                                            Outline outline = new Outline(bb.Min, bb.Max);
                                            //TaskDialog.Show("Revit", "Family1");
                                            BoundingBoxIntersectsFilter filter = new BoundingBoxIntersectsFilter(outline);

                                            BuiltInCategory[] bics = new BuiltInCategory[] { BuiltInCategory.OST_LightingDevices, BuiltInCategory.OST_LightingFixtures, BuiltInCategory.OST_Lights, };

                                            LogicalOrFilter categoryFilter = new LogicalOrFilter(bics.Select<BuiltInCategory, ElementFilter>(bic => new ElementCategoryFilter(bic)).ToList<ElementFilter>());

                                            FilteredElementCollector collector2 = new FilteredElementCollector(_doc).WhereElementIsNotElementType().WhereElementIsViewIndependent().OfClass(typeof(FamilyInstance)).WherePasses(filter).WherePasses(categoryFilter);
                                            //TaskDialog.Show("Revit", "Family2");

                                            List<FamilyInstance> a = new List<FamilyInstance>();

                                            foreach (FamilyInstance fi in collector2)
                                            {

                                                a.Add(fi);

                                            }

                                            if (a.Count() > 0)
                                            {

                                                foreach (FamilyInstance lamp in a)
                                                {

                                                    lamp.GetParameters("Concrete").First().Set(volumes[0]);
                                                    lamp.GetParameters("Masonry").First().Set(volumes[1]);
                                                    lamp.GetParameters("Wood").First().Set(volumes[2]);
                                                }


                                            }

                                        }
                                        trans.Commit();
                                    }

                                }
                                
                            }


                        }



                    }




                }
                catch (Exception e) {
                    TaskDialog.Show("Revit", e.ToString());
                }

            


            }

            public string GetName()
            {
                    return "Place Information";
            }
        }
        
        
    } 
}
