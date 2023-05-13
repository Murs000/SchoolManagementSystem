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
using System.Windows.Shapes;

namespace SchoolManagementSystem.Views.Windows
{
    /// <summary>
    /// Interaction logic for SureDialogWindow.xaml
    /// </summary>
    public partial class SureDialogWindow : Window
    {
        public SureDialogWindow()
        {
            InitializeComponent();
        }

        private void YesClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void NoClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
