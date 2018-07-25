using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace SMSApp.ViewModels
{
    public class ArcgisMapViewModel : BindableBase/* : ViewModelBase*/
    {
        //public ArcgisMapViewModel(IContainer container) : base(container)
        //{
        //    MyMap = new Map(SpatialReferences.WebMercator);
        //    LoadMapData();

        //    DrawPointBtnClickCommand = new DelegateCommand(ExecuteDrawPointBtnClick);
        //}


        public MapView MyMapView { get; set; }
        public Map MyMap { get; set; }

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
                var nestingGround = polygonBuilder.ToGeometry();
                var outlineSymbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, Colors.Blue, 1.0);
                var fillSymbol = new SimpleFillSymbol(SimpleFillSymbolStyle.DiagonalCross, Color.FromArgb(255, 0, 80, 0), outlineSymbol);
                var nestingGraphic = new Graphic(nestingGround, fillSymbol);
                tempPolygonGraphicsOverlay.Graphics.Add(nestingGraphic);
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
        private async void RedoPointAction()
        {
            if (undoPointActionHistory.Count() > 0)
            {
                MapPoint location = undoPointActionHistory.Last();
                undoPointActionHistory.Remove(location);
                var pointsTable = pointsData.Tables.First();
                var pointFeature = pointsTable.CreateFeature();
                pointFeature.Geometry = location;
                pointFeature.Attributes["Text"] = $"title-({location.X},{location.Y})";
                await pointsTable.AddFeatureAsync(pointFeature);
                drawPointActionHistory.Add(location);
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
                var tempPointMarker = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Circle, Colors.Green, 7);
                var tempPointGraphic = new Graphic(loc, tempPointMarker);
                tempPointGraphicsOverlay.Graphics.Add(tempPointGraphic);

                tempPolygonGraphicsOverlay.Graphics.Clear();
                var nestingGround1 = polygonBuilder.ToGeometry();
                var outlineSymbol1 = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, Colors.Blue, 1.0);
                var fillSymbol1 = new SimpleFillSymbol(SimpleFillSymbolStyle.DiagonalCross, Color.FromArgb(255, 0, 80, 0), outlineSymbol1);
                var nestingGraphic1 = new Graphic(nestingGround1, fillSymbol1);
                tempPolygonGraphicsOverlay.Graphics.Add(nestingGraphic1);
            }
            
        }

        public DelegateCommand DrawPointBtnClickCommand { get; set; }
        private void ExecuteDrawPointBtnClick()
        {
            currentBtnAction = 1;
            MyMapView.GraphicsOverlays.Clear();
            InfoText = "Draw POINT button clicked";
        }
        private List<MapPoint> drawPointActionHistory = new List<MapPoint>();
        private List<MapPoint> undoPointActionHistory = new List<MapPoint>();
        private async void AddPoint(MapPoint location)
        {
            var pointsTable = pointsData.Tables.First();
            var pointFeature = pointsTable.CreateFeature();
            pointFeature.Geometry = location;
            pointFeature.Attributes["Text"] = $"title-({location.X},{location.Y})";
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
        //    //    pointFeature.Attributes["Text"] = $"title-({location.X},{location.Y})";
        //    //    await pointsTable.AddFeatureAsync(pointFeature);

        //    undoPointActionHistory.Clear();
        //    //drawPointActionHistory.Add(location);

        //}

        public DelegateCommand DrawPolygonBtnClickCommand { get; set; }
        private List<MapPoint> undoPolygonActionHistory = new List<MapPoint>();
        private List<MapPoint> tempMapPoints = new List<MapPoint>();
        private PolygonBuilder polygonBuilder = new PolygonBuilder(SpatialReferences.WebMercator);
        private GraphicsOverlay tempPointGraphicsOverlay = new GraphicsOverlay();
        private GraphicsOverlay tempPolygonGraphicsOverlay = new GraphicsOverlay();
        private void ExecuteDrawPolygonBtnClick()
        {
            currentBtnAction = 2;
            MyMapView.GraphicsOverlays.Clear();
            MyMapView.GraphicsOverlays.Add(tempPointGraphicsOverlay);
            MyMapView.GraphicsOverlays.Add(tempPolygonGraphicsOverlay);
            InfoText = "Draw POLYGON button clicked";
        }
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
            var tempPointMarker = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Circle, Colors.Green, 7);
            var tempPointGraphic = new Graphic(e.Location, tempPointMarker);
            tempPointGraphicsOverlay.Graphics.Add(tempPointGraphic);

            tempPolygonGraphicsOverlay.Graphics.Clear();
            var nestingGround1 = polygonBuilder.ToGeometry();
            var outlineSymbol1 = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, Colors.Blue, 1.0);
            var fillSymbol1 = new SimpleFillSymbol(SimpleFillSymbolStyle.DiagonalCross, Color.FromArgb(255, 0, 80, 0), outlineSymbol1);
            var nestingGraphic1 = new Graphic(nestingGround1, fillSymbol1);
            tempPolygonGraphicsOverlay.Graphics.Add(nestingGraphic1);
            undoPolygonActionHistory.Clear();
            //}
        }
        private async void DrawPolygon()
        {
            if (polygonBuilder.IsSketchValid)
            {
                var polygonsTable = polygonsData.Tables.First();
                var polygonFeature = polygonsTable.CreateFeature();
                polygonFeature.Geometry = polygonBuilder.ToGeometry();
                polygonFeature.Attributes["Text"] = $"{polygonBuilder.ToGeometry().ToJson()}";
                await polygonsTable.AddFeatureAsync(polygonFeature);
            }
            tempMapPoints = new List<MapPoint>();
            undoPolygonActionHistory.Clear();
            polygonBuilder = new PolygonBuilder(SpatialReferences.WebMercator);
            tempPointGraphicsOverlay.Graphics.Clear();
            tempPolygonGraphicsOverlay.Graphics.Clear();
        }

        public DelegateCommand SelectByRadiusBtnClickCommand { get; set; }
        private void ExecuteSelectByRadiusBtnClick()
        {
            currentBtnAction = 3;
            MyMapView.GraphicsOverlays.Clear();
            MyMapView.GraphicsOverlays.Add(tempSelectByRadiusGraphicsOverlay);
            InfoText = "SELECT BY RADIUS button clicked";
        }
        private GraphicsOverlay tempSelectByRadiusGraphicsOverlay = new GraphicsOverlay();
        private PolylineBuilder tempPolylineBuilder = new PolylineBuilder(SpatialReferences.Wgs84);
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
                var lineSymbol = new SimpleLineSymbol();
                lineSymbol.Color = Colors.Blue;
                lineSymbol.Style = SimpleLineSymbolStyle.Dash;
                lineSymbol.Width = 2;
                // create a new graphic; set the Geometry and Symbol
                var lineGraphic = new Esri.ArcGISRuntime.UI.Graphic();
                lineGraphic.Geometry = tempPolylineBuilder.ToGeometry();
                lineGraphic.Symbol = lineSymbol;
                tempSelectByRadiusGraphicsOverlay.Graphics.Add(lineGraphic);
                
                pos0 = null;
                
                // Build a buffer (polygon) around a click point
                var buffer = GeometryEngine.Buffer(e.Location, dis/2);
                // Use the buffer to define the geometry for a query
                var query = new QueryParameters();
                query.Geometry = buffer;
                query.SpatialRelationship = SpatialRelationship.Intersects;

                string str = "";
                foreach (var table in polygonsData.Tables)
                {
                    await table.FeatureLayer.SelectFeaturesAsync(query, Esri.ArcGISRuntime.Mapping.SelectionMode.New);
                    var selectedFeatures = await table.FeatureLayer.GetSelectedFeaturesAsync();

                    foreach (var f in selectedFeatures)
                    {
                        //await polygonsData.Tables.First().DeleteFeatureAsync(f);
                        str = str + f.Geometry.ToJson() + '\n';

                    }

                }
                InfoText = str;
            }
        }

        public ArcgisMapViewModel(Esri.ArcGISRuntime.UI.Controls.MapView mapView)
        {
            MyMapView = mapView;
            MyMap = new Map(SpatialReferences.WebMercator) { InitialViewpoint = new Viewpoint(33, 50, 40000) };
            LoadMapData();

            UndoCommand = new DelegateCommand(ExecuteUndo);
            ZeroCommand = new DelegateCommand(ExecuteZero);
            RedoCommand = new DelegateCommand(ExecuteRedo);

            DrawPointBtnClickCommand = new DelegateCommand(ExecuteDrawPointBtnClick);
            //RemovePointBtnClickCommand = new DelegateCommand(ExecuteRemovePointBtnClick);
            DrawPolygonBtnClickCommand = new DelegateCommand(ExecuteDrawPolygonBtnClick);
            SelectByRadiusBtnClickCommand = new DelegateCommand(ExecuteSelectByRadiusBtnClick);


            MyMapView.GeoViewTapped += (sender, e) =>
            {
                switch (currentBtnAction)
                {
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

            SaveMapDataCommand = new DelegateCommand(ExecuteSaveMapDataCommand);
        }


        private const string FILENAME_POINTSDATA = "pointsData.json";
        private const string FILENAME_POLYGONSDATA = "polygonsData.json";
        private FeatureCollection pointsData = new FeatureCollection();
        private FeatureCollection polygonsData = new FeatureCollection();
        private void LoadMapData()
        {
            infoText = "Loading map...";

            if (File.Exists(FILENAME_POINTSDATA))
            {
                pointsData = FeatureCollection.FromJson(File.ReadAllText(FILENAME_POINTSDATA));
            }
            else
            {
                pointsData.Tables.Add(new FeatureCollectionTable(new Field[] { new Field(FieldType.Text, "Text", null, 50) }, GeometryType.Point, SpatialReferences.WebMercator));
            }

            if (File.Exists(FILENAME_POLYGONSDATA))
            {
                polygonsData = FeatureCollection.FromJson(File.ReadAllText(FILENAME_POLYGONSDATA));
            }
            else
            {
                polygonsData.Tables.Add(new FeatureCollectionTable(new Field[] { new Field(FieldType.Text, "Text", null, 50) }, GeometryType.Polygon, SpatialReferences.WebMercator));
            }

            MyMap.OperationalLayers.Add(new FeatureCollectionLayer(polygonsData));
            MyMap.OperationalLayers.Add(new FeatureCollectionLayer(pointsData));

            infoText = "Loading map is completed";
        }

        public DelegateCommand SaveMapDataCommand { get; set; }
        private void ExecuteSaveMapDataCommand()
        {
            ExecuteZero();
            //InfoText = "Saving...";
            string poinsJson = pointsData.ToJson();
            File.WriteAllText("pointsData.json", poinsJson);
            string polygonsJson = polygonsData.ToJson();
            File.WriteAllText("polygonsData.json", polygonsJson);
            //InfoText = "Saved successfully";
        }

    }
}
