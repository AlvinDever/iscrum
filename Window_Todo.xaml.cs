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

namespace iScrum
{
    /// <summary>
    /// Interaction logic for Window_Todo.xaml
    /// </summary>
    public partial class Window_Todo : Window
    {
        public delegate void PassValuesHandle(object sender, string e);
        public event PassValuesHandle PassValuesEvent;

        public Window_Todo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = this.tb_Todo_Name.Text;
            PassValuesEvent(sender, name);
            this.Close();
        }
    }
}
