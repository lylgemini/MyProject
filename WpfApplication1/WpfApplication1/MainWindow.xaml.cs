using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vlc.DotNet.Core;
using Vlc.DotNet.Wpf;
using Vlc.DotNet.Core.Medias;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VlcControl myVlcControl;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;

            //Set libvlc.dll and libvlccore.dll directory path
            //VlcContext.LibVlcDllsPath = CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_AMD64;
            ////Set the vlc plugins directory path
            //VlcContext.LibVlcPluginsPath = CommonStrings.PLUGINS_PATH_DEFAULT_VALUE_AMD64;

            ////Set the startup options
            //VlcContext.StartupOptions.IgnoreConfig = true;
            //VlcContext.StartupOptions.LogOptions.LogInFile = true;
            //VlcContext.StartupOptions.LogOptions.ShowLoggerConsole = true;
            //VlcContext.StartupOptions.LogOptions.Verbosity = VlcLogVerbosities.Debug;


            VlcContext.LibVlcDllsPath = appPath + @"VLC\";
            //Set the vlc plugins directory path
            VlcContext.LibVlcPluginsPath = appPath + @"VLC\plugins\";
            //Set the startup options
            VlcContext.StartupOptions.IgnoreConfig = true;
            VlcContext.StartupOptions.LogOptions.LogInFile = false;
            VlcContext.StartupOptions.LogOptions.ShowLoggerConsole = false;
            VlcContext.StartupOptions.LogOptions.Verbosity = VlcLogVerbosities.None;
            //Initialize the VlcContext
            VlcContext.Initialize();
            myVlcControl = new VlcControl();
            // 创建绑定，绑定Image
            Binding bing = new Binding();
            bing.Source = myVlcControl;
            bing.Path = new PropertyPath("VideoSource");
            img.SetBinding(Image.SourceProperty, bing);
            //流媒体播放
            //var media = new LocationMedia("udp://@:ip:port");
            //myVlcControl.Play(media);
            //本地播放
            myVlcControl.Play(new PathMedia(@"D:\flash1477.fla"));
            //VlcContext.CloseAll();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            myVlcControl.Stop();
            myVlcControl.Play();
        }
    }
}
