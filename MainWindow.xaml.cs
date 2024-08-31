using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Graphics;
using System;
using Microsoft.UI;

namespace PIXELPAWLABS
{
    public sealed partial class MainWindow : Window
    {
        private int sessionCount = 1;

        public MainWindow()
        {
            this.InitializeComponent();

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);

            appWindow.Resize(new SizeInt32(800, 450));
        }

        private void OnAccelerateClick(object sender, RoutedEventArgs e)
        {
            Accelerate();
            UpdateSessionHistory();
        }

        private void Accelerate()
        {
           
            var targetHeight = 300; 
            AccelerationBarForeground.Height = targetHeight; 
        }

        private void UpdateSessionHistory()
        {
            string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");

            SessionHistoryList.Items.Add(new ListViewItem { Content = $"Session {sessionCount++}: {currentDateTime}" });
        }
    }
}
