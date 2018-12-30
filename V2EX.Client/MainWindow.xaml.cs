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
using V2EX.Client.Configurations;
using V2EX.Client.Controls;
using V2EX.Client.Views;
using V2EX.Client.Views.Pages;
using V2EX.Client.ViewModels;
using V2EX.Client.ViewModels.Pages;

namespace V2EX.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            Content =
                PageBuilder
                    .Wrap<MainPage>()
                    .Initialize(page => Console.WriteLine("view init 1"))
                    .Initialize(page => Console.WriteLine("view init 2"))
                    .Initialize(page => Console.WriteLine("view init 3"))
                    .Build(Urls.Instance.Home);
        }
    }
}
