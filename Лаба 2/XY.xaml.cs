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

namespace Лаба_2
{
    /// <summary>
    /// Логика взаимодействия для XY.xaml
    /// </summary>
    public partial class XY : Window
    {
        public XY()
        {
            InitializeComponent();
        }
        public double x1;
        public double y1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.x1 = Convert.ToDouble(X.Text);
                this.y1 = Convert.ToDouble(Y.Text);
                this.DialogResult = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
