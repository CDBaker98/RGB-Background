using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RGB_Background {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private byte _R = 255;
        private byte _G, _B = 0;
        private static BoundProperties BP = new();

        public MainWindow() {
            InitializeComponent();
            DataContext = BP;
            MainWindow_RGB();
        }

        private async void MainWindow_RGB() {
            // Cycle through different colors in the 0-255 RGB range
            if (_R == 255 && _G < 255 && _B == 0) {
                _G++;
            }
            else if (_R > 0 && _G == 255 && _B == 0) {
                _R--;
            }
            else if (_R == 0 && _G == 255 && _B < 255) {
                _B++;
            }
            else if (_R == 0 && _G > 0 && _B == 255) {
                _G--;
            }
            else if (_R < 255 && _G == 0 && _B == 255) {
                _R++;
            }
            else if (_R == 255 && _G == 0 && _B > 0) {
                _B--;
            }


            if (BP.RGB) {
                BP.Background = new LinearGradientBrush(Colors.White, Color.FromRgb(_R, _G, _B), 90);
            }
            else {
                var bc = new BrushConverter();
                BP.Background = (Brush)bc.ConvertFrom("#FFE0E0E0");
            }

            await Task.Delay(25);
            MainWindow_RGB();
        }
    }
}
