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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SMSApp.ViewModels
{
    public class MapViewModel : BindableBase
    {
        private string _InfoText;
        public string InfoText { set { this.SetProperty(ref _InfoText, value); } get => _InfoText; }
        public Map Map { set; get; }
        public DelegateCommand MapViewTapped { set; get; }
        public DelegateCommand PointBtnClick { set; get; }
        public DelegateCommand PolygonBtnClick { set; get; }
        public DelegateCommand SelectByRadiusBtnClick { set; get; }
        public DelegateCommand SaveMapData { set; get; }

        private const int N = 10;
        private MapView MyMapView;
        private int currentBtnAction = 0;
        private FeatureCollection pointsData = new FeatureCollection();
        private FeatureCollection polygonsData = new FeatureCollection();

        private List<string> imgList = new List<string>();
        private void LoadImgAddress()
        {
            var files = System.IO.Directory.GetFiles(@"D:\img", "*.jpg");
            for (int i = 0; i < N; i++)
            {
                imgList.Add(files[i]);
            }
        }

        private void LoadMapData()
        {
            LoadImgAddress();
            if (File.Exists("pointsData.json"))
            {
                pointsData = FeatureCollection.FromJson(File.ReadAllText("pointsData.json"));
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    pointsData.Tables.Add(new FeatureCollectionTable(new Field[] { new Field(FieldType.Text, "Text", null, 50) }, GeometryType.Point, SpatialReferences.WebMercator));
                }

            }
            int j = 0;
            foreach (var table in pointsData.Tables)
            {
                table.Renderer = new SimpleRenderer(new PictureMarkerSymbol(new Uri(imgList.ElementAt(j++))));
            }



            if (File.Exists("polygonsData.json"))
            {
                polygonsData = FeatureCollection.FromJson(File.ReadAllText("polygonsData.json"));
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    polygonsData.Tables.Add(new FeatureCollectionTable(new Field[] { new Field(FieldType.Text, "Text", null, 1000) }, GeometryType.Polygon, SpatialReferences.WebMercator));
                }

            }


            int kx, ky;
            Random rand = new Random();
            foreach (var table in polygonsData.Tables)
            {

                kx = rand.Next();
                ky = rand.Next();
                byte a = Convert.ToByte(100);
                byte r = Convert.ToByte(Math.Abs(2 * kx - ky) % 255);
                byte g = Convert.ToByte(Math.Abs(kx - 3 * ky) % 255);
                byte b = Convert.ToByte(Math.Abs(kx + ky) % 255);

                //var outlineSymbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, Colors.Blue, 1.0);
                table.Renderer = new SimpleRenderer(new SimpleFillSymbol(SimpleFillSymbolStyle.Solid, Color.FromArgb(a, r, g, b), null));
            }
            //polygonsData.Tables.ElementAt(0).Renderer = new SimpleRenderer(new PictureFillSymbol(new Uri(@"D:\img\home.jpg")));

            Map.OperationalLayers.Add(new FeatureCollectionLayer(polygonsData));
            Map.OperationalLayers.Add(new FeatureCollectionLayer(pointsData));
            //foreach (var table in pointsData.Tables)
            //{
            //    table.FeatureLayer.MinScale = 1000000;
            //}

        }




        private List<MapPoint> tempMapPoints = new List<MapPoint>();
        private PolygonBuilder polygonBuilder = new PolygonBuilder(SpatialReferences.WebMercator);
        private GraphicsOverlay tempPointGraphicsOverlay = new GraphicsOverlay();
        private GraphicsOverlay tempPolygonGraphicsOverlay = new GraphicsOverlay();


        public MapViewModel(MapView _MapView)
        {

            MyMapView = _MapView;
            Map = new Map(SpatialReferences.WebMercator);
            string str = "sdsd";
            InfoText = str;
            LoadMapData();

            PointBtnClick = new DelegateCommand(() =>
            {
                currentBtnAction = 1;
                MyMapView.GraphicsOverlays.Clear();
            });

            PolygonBtnClick = new DelegateCommand(() =>
            {
                currentBtnAction = 2;
                MyMapView.GraphicsOverlays.Clear();
                MyMapView.GraphicsOverlays.Add(tempPointGraphicsOverlay);
                MyMapView.GraphicsOverlays.Add(tempPolygonGraphicsOverlay);
            });

            SelectByRadiusBtnClick = new DelegateCommand(() =>
            {
                currentBtnAction = 3;

            });

            SaveMapData = new DelegateCommand(() =>
            {
                string poinsJson = pointsData.ToJson();
                File.WriteAllText("pointsData.json", poinsJson);

                string polygonsJson = polygonsData.ToJson();
                File.WriteAllText("polygonsData.json", polygonsJson);

            });

            MyMapView.GeoViewTapped += (s, e) =>
            {
                switch (currentBtnAction)
                {
                    case 1:
                        AddPoint(e.Location);
                        break;

                    case 2:
                        SkatchPolygon(e);
                        break;

                    case 3:

                        SelectByRadius(e);

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
                }
            };



        }

        private int g = 0;
        private async void AddPoint(MapPoint location)
        {
            var pointsTable = pointsData.Tables.ElementAt(++g % N);

            var pointFeature = pointsTable.CreateFeature();
            pointFeature.Geometry = location;
            pointFeature.Attributes["Text"] = $"{location.X},{location.Y}";
            try
            {
                await pointsTable.AddFeatureAsync(pointFeature);
            }
            catch { }
        }


        private async void SkatchPolygon(GeoViewInputEventArgs e)
        {
            var identifyPolPointGraphics = await MyMapView.IdentifyGraphicsOverlayAsync(tempPointGraphicsOverlay, e.Position, 10, false);

            if (identifyPolPointGraphics != null && identifyPolPointGraphics.Graphics.Count > 0)
            {
                var _idGraphic = identifyPolPointGraphics.Graphics.FirstOrDefault();

                int a = tempPointGraphicsOverlay.Graphics.IndexOf(_idGraphic);
                tempPointGraphicsOverlay.Graphics.Remove(_idGraphic);

                tempMapPoints.RemoveAt(a);

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
            else
            {
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

            }
        }

        private async void DrawPolygon()
        {
            if (polygonBuilder.IsSketchValid)
            {

                var polygonsTable = polygonsData.Tables.ElementAt(++g % N);
                var polygonFeature = polygonsTable.CreateFeature();
                polygonFeature.Geometry = polygonBuilder.ToGeometry();
                polygonFeature.Attributes["Text"] = $"{polygonBuilder.ToGeometry().ToJson()}";
                try
                {
                    await polygonsTable.AddFeatureAsync(polygonFeature);
                }
                catch { }
            }
            tempMapPoints = new List<MapPoint>();
            polygonBuilder = new PolygonBuilder(SpatialReferences.WebMercator);
            tempPointGraphicsOverlay.Graphics.Clear();
            tempPolygonGraphicsOverlay.Graphics.Clear();
        }


        private async void SelectByRadius(Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs e)
        {
            // Build a buffer (polygon) around a click point
            var buffer = GeometryEngine.Buffer(e.Location, 5000000);


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

}
