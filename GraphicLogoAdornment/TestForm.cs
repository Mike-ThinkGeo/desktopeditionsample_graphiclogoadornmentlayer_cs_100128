using System;
using System.Drawing;
using System.Windows.Forms;
using ThinkGeo.MapSuite.Core;
using ThinkGeo.MapSuite.DesktopEdition;


namespace  GraphicLogoAdornment
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            // Set the full extent and the background color
            winformsMap1.CurrentExtent = new RectangleShape(-160.31,89.13,71.36,-51.48);
            winformsMap1.BackgroundOverlay.BackgroundBrush = new GeoSolidBrush(GeoColor.StandardColors.White);
            winformsMap1.AdornmentOverlay.ShowLogo = false;

            // Setup the World Map Kit overlay
            WorldMapKitWmsDesktopOverlay worldMapKitDesktopOverlay = new WorldMapKitWmsDesktopOverlay();
            winformsMap1.Overlays.Add("WorldOverlay", worldMapKitDesktopOverlay);

            // Create our GraphicLogAdornmentLayer and specify the graphic we want to use
            GraphicLogoAdornmentLayer graphicLogoAdornmentLayer = new GraphicLogoAdornmentLayer();
            graphicLogoAdornmentLayer.LogoImage = new Bitmap(@"..\..\Data\logo.png");
            winformsMap1.AdornmentOverlay.Layers.Add(graphicLogoAdornmentLayer);

            // Draw the map image on the screen
            winformsMap1.Refresh();
        }

      
        private void winformsMap1_MouseMove(object sender, MouseEventArgs e)
        {
            //Displays the X and Y in screen coordinates.
            statusStrip1.Items["toolStripStatusLabelScreen"].Text = "X:" + e.X + " Y:" + e.Y;

            //Gets the PointShape in world coordinates from screen coordinates.
            PointShape pointShape = ExtentHelper.ToWorldCoordinate(winformsMap1.CurrentExtent, new ScreenPointF(e.X, e.Y), winformsMap1.Width, winformsMap1.Height);

            //Displays world coordinates.
            statusStrip1.Items["toolStripStatusLabelWorld"].Text = "(world) X:" + Math.Round(pointShape.X, 4) + " Y:" + Math.Round(pointShape.Y, 4);
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
