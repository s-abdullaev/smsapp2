using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace SMSApp.Controls.MapControl
{
    public class MapControlViewModel : BindableBase
    {  
        public static MapView MyMapView { get; set; }

        #region Map Data
        private static MobileMapPackage mapPackage;
        private const string MAP_PACKAGE_PATH = @"Map\Map.mmpk";

        private FeatureCollection polygonsData = new FeatureCollection();
        private const string FILENAME_POLYGONS_DATA = "polygonsData.json";
        
        private FeatureCollection pointsData = new FeatureCollection();
        private const string FILENAME_POINTS_DATA = "pointsData.json";

        private UniqueValueRenderer polygonFillRenderer = new UniqueValueRenderer();
        private UniqueValueRenderer polygonTextRenderer = new UniqueValueRenderer();
        private const string FILENAME_POLYGONS_FILL_RENDERER = "polygonsFillRenderer.json";
        private const string FILENAME_POLYGONS_TEXT_RENDERER = "polygonsTextRenderer.json";

        private UniqueValueRenderer pointRenderer = new UniqueValueRenderer();
        private const string FILENAME_POINTS_RENDERER = "pointsRenderer.json";
        private const string FILENAME_INIT_STATE = "mapState.json";
        #endregion

        #region Save Map Data
        public DelegateCommand SaveMapDataCommand { get; set; }
        private void ExecuteSaveMapDataCommand()
        {
            ExecuteZero();
            InfoText = "Saving...";
            File.WriteAllText(FILENAME_POLYGONS_DATA, polygonsData.ToJson());
            File.WriteAllText(FILENAME_POLYGONS_FILL_RENDERER, polygonFillRenderer.ToJson());
            File.WriteAllText(FILENAME_POLYGONS_TEXT_RENDERER, polygonTextRenderer.ToJson());
            
            File.WriteAllText(FILENAME_POINTS_DATA, pointsData.ToJson());
            File.WriteAllText(FILENAME_POINTS_RENDERER, pointRenderer.ToJson());
            
            File.WriteAllText(FILENAME_INIT_STATE, MyMapView.GetCurrentViewpoint(ViewpointType.CenterAndScale).ToJson());
            InfoText = "Saved successfully";
        }
        #endregion

        #region Map Design
        private Random _random = new Random();
        private Color GetRandomColor()
        {
            var colorBytes = new byte[3];
            _random.NextBytes(colorBytes);
            return Color.FromRgb(colorBytes[0], colorBytes[1], colorBytes[2]);
        }
        private SimpleFillSymbol GetRandomFillSymbol()
        {
            var color = GetRandomColor();
            return new SimpleFillSymbol()
            {
                Color = Color.FromArgb(0x77, color.R, color.G, color.B),
                Outline = new SimpleLineSymbol() { Width = 2, Style = SimpleLineSymbolStyle.Solid, Color = color },
                Style = SimpleFillSymbolStyle.Solid
            };
        }
        private SimpleFillSymbol GetDefaultFillSymbol()
        {
            var color = Colors.Red;
            return new SimpleFillSymbol()
            {
                Color = Color.FromArgb(0x77, color.R, color.G, color.B),
                Outline = new SimpleLineSymbol() { Width = 2, Style = SimpleLineSymbolStyle.Solid, Color = color },
                Style = SimpleFillSymbolStyle.Solid
            };
        }
        private SimpleFillSymbol GetDefaultSkatchFillSymbol()
        {
            var color = Colors.Green;
            return new SimpleFillSymbol()
            {
                Color = Color.FromArgb(0x77, color.R, color.G, color.B),
                Outline = new SimpleLineSymbol() { Width = 1, Style = SimpleLineSymbolStyle.Dash, Color = Colors.Blue },
                Style = SimpleFillSymbolStyle.Solid
            };
        }
        private TextSymbol GetRandomTextSymbol(string str)
        {
            var color = GetRandomColor();
            return new TextSymbol()
            {   
                Size = 12,
                Text = str,
                Color = color                
            };
        }
        private TextSymbol GetDefaultTextSymbol(string str)
        {
            var color = Colors.Blue;
            return new TextSymbol()
            {
                Size = 12,
                Text = str,
                Color = color
            };
        }
        private SimpleMarkerSymbol GetRandomMarkerSymbol()
        {
            var color = GetRandomColor();
            return new SimpleMarkerSymbol()
            {
                Style = SimpleMarkerSymbolStyle.Circle,
                Color = color,
                Size = 5
            };
            
        }
        private SimpleMarkerSymbol GetDefaultMarkerSymbol()
        {
            var color = Colors.Yellow;
            return new SimpleMarkerSymbol()
            {
                Style = SimpleMarkerSymbolStyle.Circle,
                Color = color,
                Size = 5
            };

        }
        private SimpleMarkerSymbol GetDefaultSkatchMarkerSymbol()
        {
            var color = Colors.Blue;
            return new SimpleMarkerSymbol()
            {
                Style = SimpleMarkerSymbolStyle.Circle,
                Color = color,
                Size = 7
            };

        }
        #endregion

        private async void LoadMapData()
        {
            InfoText = "Loading map...";
            mapPackage = await MobileMapPackage.OpenAsync(MAP_PACKAGE_PATH);
            MyMapView.Map = mapPackage.Maps[0];

            if (File.Exists(FILENAME_POLYGONS_DATA))
            {
                polygonsData = FeatureCollection.FromJson(File.ReadAllText(FILENAME_POLYGONS_DATA));
                polygonFillRenderer = UniqueValueRenderer.FromJson(File.ReadAllText(FILENAME_POLYGONS_FILL_RENDERER)) as UniqueValueRenderer;
                polygonTextRenderer = UniqueValueRenderer.FromJson(File.ReadAllText(FILENAME_POLYGONS_TEXT_RENDERER)) as UniqueValueRenderer;
            }
            else
            {
                polygonsData.Tables.Add(new FeatureCollectionTable(new Field[] { new Field(FieldType.Text, "PolygonRefId", null, 50) }, GeometryType.Polygon, SpatialReferences.WebMercator));
                polygonFillRenderer.FieldNames.Add("PolygonRefId");
                polygonFillRenderer.DefaultSymbol = GetDefaultFillSymbol();
                polygonFillRenderer.DefaultLabel = "Unknown Polygon";
                
                polygonsData.Tables.Add(new FeatureCollectionTable(new Field[] { new Field(FieldType.Text, "PolygonRefId", null, 50) }, GeometryType.Point, SpatialReferences.WebMercator));
                polygonTextRenderer.FieldNames.Add("PolygonRefId");
                polygonTextRenderer.DefaultSymbol = GetDefaultTextSymbol("Unknown Polygon");
                polygonTextRenderer.DefaultLabel = "Unknown Polygon";
            }
            polygonsData.Tables[0].Renderer = polygonFillRenderer;
            polygonsData.Tables[1].Renderer = polygonTextRenderer;

            
            

            if (File.Exists(FILENAME_POINTS_DATA))
            {
                pointsData = FeatureCollection.FromJson(File.ReadAllText(FILENAME_POINTS_DATA));
                pointRenderer = UniqueValueRenderer.FromJson(File.ReadAllText(FILENAME_POINTS_RENDERER)) as UniqueValueRenderer;
            }
            else
            {
                pointsData.Tables.Add(new FeatureCollectionTable(new Field[] { new Field(FieldType.Text, "PointRefId", null, 50) }, GeometryType.Point, SpatialReferences.WebMercator));
                pointRenderer.FieldNames.Add("PointRefId");
                pointRenderer.DefaultSymbol = GetDefaultMarkerSymbol();
                pointRenderer.DefaultLabel = "Unknown Point";
            }
            pointsData.Tables[0].Renderer = pointRenderer;
            
            MyMapView.Map.OperationalLayers.Add(new FeatureCollectionLayer(polygonsData));
            MyMapView.Map.OperationalLayers.Last().MinScale = 700000;
            
            MyMapView.Map.OperationalLayers.Add(new FeatureCollectionLayer(pointsData));
            MyMapView.Map.OperationalLayers.Last().MinScale = 5000000;

            if (File.Exists(FILENAME_INIT_STATE))
                MyMapView.SetViewpoint(Viewpoint.FromJson(File.ReadAllText(FILENAME_INIT_STATE)));

            InfoText = "Loading map is completed";
        }

        public MapControlViewModel(Esri.ArcGISRuntime.UI.Controls.MapView mapView)
        {
            MyMapView = mapView;

            LoadMapData();

            UndoCommand = new DelegateCommand(ExecuteUndo);
            ZeroCommand = new DelegateCommand(ExecuteZero);
            RedoCommand = new DelegateCommand(ExecuteRedo);
            DrawPointBtnClickCommand = new DelegateCommand(ExecuteDrawPointBtnClick);
            DrawPolygonBtnClickCommand = new DelegateCommand(ExecuteDrawPolygonBtnClick);
            SelectByRadiusBtnClickCommand = new DelegateCommand(ExecuteSelectByRadiusBtnClick);
            SaveMapDataCommand = new DelegateCommand(ExecuteSaveMapDataCommand);
            RemoveBtnClickCommand = new DelegateCommand(ExecuteRemoveBtnClickCommand);

            MyMapView.GeoViewTapped += (sender, e) =>
            {
                switch (currentBtnAction)
                {
                    case 0:
                        ShowInfo(e);
                        break;
                    case 1:
                        AddPoint(e.Location);
                        break;
                    //case -1:
                    //    RemovePoint(e.Location);
                    //    break;
                    case 2:
                        SkatchPolygon(e);
                        break;
                    case 3:
                        SelectByRadius(e);
                        break;
                    case 4:
                        RemoveObjOnMap(e);
                        break;
                    default:
                        break;
                }
            };

            MyMapView.MouseRightButtonUp += (s, e) =>
            {
                switch (currentBtnAction)
                {
                    case 2:
                        DrawPolygon();
                        break;
                    default:
                        break;
                }
            };

            
        }
        
        private string infoText;
        public string InfoText {
            get { return infoText; }
            set { infoText = value; RaisePropertyChanged(); }
        }

        private int currentBtnAction = 0;

        public DelegateCommand ZeroCommand { get; set; }
        private void ExecuteZero()
        {
            currentBtnAction = 0;
            MyMapView.GraphicsOverlays.Clear();
            InfoText = "";
        }

        public DelegateCommand DrawPointBtnClickCommand { get; set; }
        private List<MapPoint> drawPointActionHistory = new List<MapPoint>();
        private List<MapPoint> undoPointActionHistory = new List<MapPoint>();
        private void ExecuteDrawPointBtnClick()
        {
            ExecuteZero();
            currentBtnAction = 1;
            InfoText = "Draw POINT button clicked";
        }

        public DelegateCommand DrawPolygonBtnClickCommand { get; set; }
        private List<MapPoint> undoPolygonActionHistory = new List<MapPoint>();
        private List<MapPoint> tempMapPoints = new List<MapPoint>();
        private PolygonBuilder polygonBuilder = new PolygonBuilder(SpatialReferences.WebMercator);
        private GraphicsOverlay tempPointGraphicsOverlay = new GraphicsOverlay();
        private GraphicsOverlay tempPolygonGraphicsOverlay = new GraphicsOverlay();
        private void ExecuteDrawPolygonBtnClick()
        {
            ExecuteZero();
            currentBtnAction = 2;
            MyMapView.GraphicsOverlays.Add(tempPointGraphicsOverlay);
            MyMapView.GraphicsOverlays.Add(tempPolygonGraphicsOverlay);
            InfoText = "Draw POLYGON button clicked";
        }

        public DelegateCommand SelectByRadiusBtnClickCommand { get; set; }
        private GraphicsOverlay tempSelectByRadiusGraphicsOverlay = new GraphicsOverlay();
        private PolylineBuilder tempPolylineBuilder = new PolylineBuilder(SpatialReferences.Wgs84);
        private void ExecuteSelectByRadiusBtnClick()
        {
            ExecuteZero();
            currentBtnAction = 3;
            MyMapView.GraphicsOverlays.Add(tempSelectByRadiusGraphicsOverlay);
            InfoText = "SELECT BY RADIUS button clicked";
        }

        public DelegateCommand UndoCommand { get; set; }
        private void ExecuteUndo()
        {
            switch (currentBtnAction)
            {
                case 1:
                    UndoPointAction();
                    break;
                case 2:
                    UndoPolygonAction();
                    break;
                default:
                    break;
            }
        }

        public DelegateCommand RedoCommand { get; set; }
        private void ExecuteRedo()
        {
            switch (currentBtnAction)
            {
                case 1:
                    RedoPointAction();
                    break;
                case 2:
                    RedoPolygonAction();
                    break;
                default:
                    break;
            }
        }

        public DelegateCommand RemoveBtnClickCommand { get; set; }
        private void ExecuteRemoveBtnClickCommand()
        {
            ExecuteZero();
            currentBtnAction = 4;
            InfoText = "Remove button clicked";
        }

        private void UndoPolygonAction()
        {
            if (tempMapPoints.Count() > 0)
            {
                MapPoint loc = tempMapPoints.Last();
                tempMapPoints.Remove(loc);
                undoPolygonActionHistory.Add(loc);

                tempPointGraphicsOverlay.Graphics.Remove(tempPointGraphicsOverlay.Graphics.Last());
                if (tempMapPoints.Count() == 0)
                    polygonBuilder = new PolygonBuilder(SpatialReferences.WebMercator);
                else
                    polygonBuilder = new PolygonBuilder(tempMapPoints);

                tempPolygonGraphicsOverlay.Graphics.Clear();
                var nestingGraphic = new Graphic(polygonBuilder.ToGeometry(), GetDefaultSkatchFillSymbol());
                tempPolygonGraphicsOverlay.Graphics.Add(nestingGraphic);
            }

        }

        private void RedoPolygonAction()
        {
            if (undoPolygonActionHistory.Count > 0)
            {
                MapPoint loc = undoPolygonActionHistory.Last();
                undoPolygonActionHistory.Remove(loc);

                polygonBuilder.AddPoint(loc);
                tempMapPoints.Add(loc);

                var tempPointGraphic = new Graphic(loc, GetDefaultSkatchMarkerSymbol());
                tempPointGraphicsOverlay.Graphics.Add(tempPointGraphic);

                tempPolygonGraphicsOverlay.Graphics.Clear();
                var nestingGraphic = new Graphic(polygonBuilder.ToGeometry(), GetDefaultSkatchFillSymbol());
                tempPolygonGraphicsOverlay.Graphics.Add(nestingGraphic);
            }

        }

        private void UndoPointAction()
        {
            if (drawPointActionHistory.Count > 0)
            {
                MapPoint loc = drawPointActionHistory.Last();
                drawPointActionHistory.Remove(loc);
                var pointsTable = pointsData.Tables.First();
                pointsTable.DeleteFeatureAsync(pointsTable.Last());
                undoPointActionHistory.Add(loc);
            }
        }

        private async void RedoPointAction()
        {
            if (undoPointActionHistory.Count() > 0)
            {
                MapPoint location = undoPointActionHistory.Last();
                undoPointActionHistory.Remove(location);
                var pointsTable = pointsData.Tables[0];
                var pointFeature = pointsTable.CreateFeature();
                pointFeature.Geometry = location;
                pointFeature.Attributes["PointRefId"] = $"Point-({location.X},{location.Y})";
                await pointsTable.AddFeatureAsync(pointFeature);
                drawPointActionHistory.Add(location);
            }
        }
        
        private async void AddPoint(MapPoint location)
        {
            var pointsTable = pointsData.Tables.First();
            var pointFeature = pointsTable.CreateFeature();
            pointFeature.Geometry = location;
            pointFeature.Attributes["PointRefId"] = $"Point-({location.X},{location.Y})";
            await pointsTable.AddFeatureAsync(pointFeature);

            drawPointActionHistory.Add(location);
            undoPointActionHistory.Clear();
        }

        //public DelegateCommand RemovePointBtnClickCommand { get; set; }
        //private void ExecuteRemovePointBtnClick()
        //{
        //    currentBtnAction = -1;
        //    MyMapView.GraphicsOverlays.Clear();
        //    InfoText = "Remove POINT button clicked";
        //}
        //private async void RemovePoint(MapPoint location)
        //{
        //    //    var pointsTable = pointsData.Tables.First();
        //    //    var pointFeature = pointsTable.CreateFeature();
        //    //    pointFeature.Geometry = location;
        //    //    pointFeature.Attributes["PointRefId"] = $"title-({location.X},{location.Y})";
        //    //    await pointsTable.AddFeatureAsync(pointFeature);

        //    undoPointActionHistory.Clear();
        //    //drawPointActionHistory.Add(location);

        //}

        private void SkatchPolygon(GeoViewInputEventArgs e)
        {
            //var identifyPolPointGraphics = await MyMapView.IdentifyGraphicsOverlayAsync(tempPointGraphicsOverlay, e.Position, 10, false);

            //if (identifyPolPointGraphics != null && identifyPolPointGraphics.Graphics.Count > 0)
            //{
            //    var _idGraphic = identifyPolPointGraphics.Graphics.FirstOrDefault();

            //    int a = tempPointGraphicsOverlay.Graphics.IndexOf(_idGraphic);
            //    tempPointGraphicsOverlay.Graphics.Remove(_idGraphic);

            //    tempMapPoints.RemoveAt(a);

            //    if (tempMapPoints.Count() == 0)
            //        polygonBuilder = new PolygonBuilder(SpatialReferences.WebMercator);
            //    else
            //        polygonBuilder = new PolygonBuilder(tempMapPoints);

            //    tempPolygonGraphicsOverlay.Graphics.Clear();
            //    var nestingGround = polygonBuilder.ToGeometry();
            //    var outlineSymbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, Colors.Blue, 1.0);
            //    var fillSymbol = new SimpleFillSymbol(SimpleFillSymbolStyle.DiagonalCross, Color.FromArgb(255, 0, 80, 0), outlineSymbol);
            //    var nestingGraphic = new Graphic(nestingGround, fillSymbol);
            //    tempPolygonGraphicsOverlay.Graphics.Add(nestingGraphic);

            //}
            //else
            //{
            polygonBuilder.AddPoint(e.Location);
            tempMapPoints.Add(e.Location);
            var tempPointGraphic = new Graphic(e.Location, GetDefaultSkatchMarkerSymbol());
            tempPointGraphicsOverlay.Graphics.Add(tempPointGraphic);

            tempPolygonGraphicsOverlay.Graphics.Clear();
            var nestingGraphic = new Graphic(polygonBuilder.ToGeometry(), GetDefaultSkatchFillSymbol());
            tempPolygonGraphicsOverlay.Graphics.Add(nestingGraphic);
            undoPolygonActionHistory.Clear();
            //}
        }
       
        private async void DrawPolygon()
        {
            if (polygonBuilder.IsSketchValid)
            {   
                string random_num = _random.Next().ToString();

                var polygonsTable1 = polygonsData.Tables[0];
                var polygonFeature1 = polygonsTable1.CreateFeature();
                polygonFeature1.Geometry = polygonBuilder.ToGeometry();
                polygonFeature1.Attributes["PolygonRefId"] = random_num;
                await polygonsTable1.AddFeatureAsync(polygonFeature1);
                polygonFillRenderer.UniqueValues.Add(new UniqueValue("Polygon Field " + random_num, "Label " + random_num, GetRandomFillSymbol(), random_num));
                
                var polygonsTable2 = polygonsData.Tables[1];
                var polygonFeature2 = polygonsTable2.CreateFeature();
                polygonFeature2.Geometry = polygonBuilder.Extent.GetCenter();
                polygonFeature2.Attributes["PolygonRefId"] = random_num;
                await polygonsTable2.AddFeatureAsync(polygonFeature2);
                polygonTextRenderer.UniqueValues.Add(new UniqueValue("Polygon Field " + random_num, "Label " + random_num, GetDefaultTextSymbol(random_num), random_num));
            }
            tempMapPoints = new List<MapPoint>();
            undoPolygonActionHistory.Clear();
            polygonBuilder = new PolygonBuilder(SpatialReferences.WebMercator);
            tempPointGraphicsOverlay.Graphics.Clear();
            tempPolygonGraphicsOverlay.Graphics.Clear();
        }
        
        private GeoViewInputEventArgs pos0;
        private async void SelectByRadius(GeoViewInputEventArgs e)
        {
            if (pos0 == null)
            {
                pos0 = e;

                tempSelectByRadiusGraphicsOverlay.Graphics.Clear();
                tempPolylineBuilder = new PolylineBuilder(SpatialReferences.WebMercator);
                tempPolylineBuilder.AddPoint(pos0.Location.X, pos0.Location.Y);

                var tempPointMarker = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Circle, Colors.Red, 7);
                var tempPointGraphic = new Graphic(e.Location, tempPointMarker);
                tempSelectByRadiusGraphicsOverlay.Graphics.Add(tempPointGraphic);
                
            }
            else
            {
                var dis = GeometryEngine.Distance(pos0.Location, e.Location);

                tempPolylineBuilder.AddPoint(e.Location.X, e.Location.Y);
                var lineSymbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, Colors.Blue, 2);
                
                // create a new graphic; set the Geometry and Symbol
                var lineGraphic = new Graphic();
                lineGraphic.Geometry = tempPolylineBuilder.ToGeometry();
                lineGraphic.Symbol = lineSymbol;
                tempSelectByRadiusGraphicsOverlay.Graphics.Add(lineGraphic);

                // Build a buffer (polygon) around a click point
                var buffer = GeometryEngine.Buffer(pos0.Location, dis);
                pos0 = null;
                
                var nestingGraphic = new Graphic(buffer, GetDefaultFillSymbol());
                tempSelectByRadiusGraphicsOverlay.Graphics.Add(nestingGraphic);

                // Use the buffer to define the geometry for a query
                var query = new QueryParameters();
                query.Geometry = buffer;
                query.SpatialRelationship = SpatialRelationship.Intersects;

                string str = "";
                //foreach (var table in polygonsData.Tables)
                //{
                //await table.FeatureLayer.SelectFeaturesAsync(query, Esri.ArcGISRuntime.Mapping.SelectionMode.New);
                //var selectedFeatures = await table.FeatureLayer.GetSelectedFeaturesAsync();
                await polygonsData.Tables[0].FeatureLayer.SelectFeaturesAsync(query, Esri.ArcGISRuntime.Mapping.SelectionMode.New);
                var selectedFeatures = await polygonsData.Tables[0].FeatureLayer.GetSelectedFeaturesAsync();

                foreach (var f in selectedFeatures)
                {
                    //await polygonsData.Tables.First().DeleteFeatureAsync(f);
                    str = str + "Polygon-" + f.GetAttributeValue("PolygonRefId") + '\n';

                }
                    // delete the selected features from the local cache
                    //await table.DeleteFeaturesAsync(selectedFeatures);
                //}
                InfoText = str;
            }
        }

        private async void ShowInfo(GeoViewInputEventArgs e)
        {
            //// Build a buffer (polygon) around a click point
            //var buffer = GeometryEngine.Buffer( e.Location,100);
            //pos0 = null;


            //// Use the buffer to define the geometry for a query
            //var query = new QueryParameters();
            //query.Geometry = buffer;
            //query.SpatialRelationship = SpatialRelationship.Intersects;
            //await polygonsData.Tables[0].FeatureLayer.SelectFeaturesAsync(query, Esri.ArcGISRuntime.Mapping.SelectionMode.New);
            //var selectedFeatures = await polygonsData.Tables[0].FeatureLayer.GetSelectedFeaturesAsync();

            var identifyLayers = await MyMapView.IdentifyLayersAsync(e.Position, 10, false);

            string str ="";
            if (identifyLayers != null && identifyLayers.Count > 0)
            {
                foreach (var layer in identifyLayers)
                {
                    foreach (var item in layer.GeoElements)
                    {

                        //object obj;
                        //if (item.Attributes.TryGetValue("name", out obj))
                        //{
                        //    string name = obj as string;
                        //    str = str + "Name-" + name + "; ";
                        //}
                        //str = str + "\n";

                        foreach (var atr in item.Attributes)
                        {
                            str = str + atr.Key + "-" + atr.Value + "; ";
                        }
                        
                        str = str + "\n";
                    }
                }

            }

            InfoText = str;
        }
        
        private async void RemoveObjOnMap(GeoViewInputEventArgs e)
        {
            var table = polygonsData.Tables[0];
            Color defColor = table.FeatureLayer.SelectionColor;
            Point  rad = new Point(e.Position.X + 1, e.Position.Y + 1);
           
            var query = new QueryParameters();
            query.Geometry = GeometryEngine.Buffer(e.Location,GeometryEngine.Distance(e.Location, MyMapView.ScreenToLocation(rad)));
            
            query.MaxFeatures = 1;
            query.SpatialRelationship = SpatialRelationship.Intersects;

            table.FeatureLayer.SelectionColor = Colors.Red;
            await table.FeatureLayer.SelectFeaturesAsync(query, Esri.ArcGISRuntime.Mapping.SelectionMode.New);
            var selectedFeatures = await table.FeatureLayer.GetSelectedFeaturesAsync();
            if (selectedFeatures.Count() > 0)
            {
                var item = selectedFeatures.First();

                string str = "";
                foreach (var atr in item.Attributes)
                {
                    str = str + atr.Key + "-" + atr.Value + "; ";
                }
                str = str + "\n";
                InfoText = str + "\n end";
                MessageBoxResult res = new MessageBoxResult();

                res = MessageBox.Show("THIS ELEMENT WILL BE DELETED!!!", "SMSapp", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (System.Windows.MessageBoxResult.Yes == res)
                {
                    object val; item.Attributes.TryGetValue("PolygonRefId", out val);
                    
                    foreach (var item2 in  polygonsData.Tables[1])
                    {
                        if(item2.Attributes.Values.Contains(val))
                        {
                            await polygonsData.Tables[1].DeleteFeatureAsync(item2);
                        }
                        
                    }
                    await table.DeleteFeatureAsync(item);
                }
            }

            //else
            //{
            //    var tablePoint = pointsData.Tables[0];
            //    Color defCol = tablePoint.FeatureLayer.SelectionColor;
            //    tablePoint.FeatureLayer.SelectionColor = Colors.Red;

            //    await tablePoint.FeatureLayer.SelectFeaturesAsync(query, Esri.ArcGISRuntime.Mapping.SelectionMode.New);
            //    var pointSelectedFeatures = await tablePoint.FeatureLayer.GetSelectedFeaturesAsync();
            //    if (pointSelectedFeatures.Count() > 0)
            //    {
            //        var item = pointSelectedFeatures.First();

            //        string str = "";
            //        foreach (var atr in item.Attributes)
            //        {
            //            str = str + atr.Key + "-" + atr.Value + "; ";
            //        }
            //        str = str + "\n";
            //        InfoText = str + "\n end";
            //        MessageBoxResult res = new MessageBoxResult();

            //        res = MessageBox.Show("THIS ELEMENT WILL BE DELETED!!!", "SMSapp", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //        if (System.Windows.MessageBoxResult.Yes == res)
            //        {
            //            await tablePoint.DeleteFeatureAsync(item);
            //        }
            //    }
            //    tablePoint.FeatureLayer.SelectionColor = defCol;
            //}

            table.FeatureLayer.SelectionColor = defColor;
        }


    }
}