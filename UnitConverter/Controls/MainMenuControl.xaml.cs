using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UnitConverter
{
    /// <summary>
    /// Interaction logic for MainMenuControl.xaml
    /// </summary>
    public partial class MainMenuControl : UserControl
    {
        ContentControl contentControl;
        public MainMenuControl(ContentControl contentControl)
        {
            InitializeComponent();
            this.contentControl = contentControl;
        }

        private void catLength_Click(object sender, RoutedEventArgs e)
        {
            LengthUserControl lengthPage = new();
            contentControl.Content = lengthPage;
        }
    }
}
