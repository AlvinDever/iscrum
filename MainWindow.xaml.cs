using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace iScrum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Assembly _assembly = Assembly.GetExecutingAssembly();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string winName = ((Button)e.OriginalSource).Tag.ToString();
            Window win = ((Window)_assembly.CreateInstance(string.Format("iScrum.{0}", winName)));
            win.Owner = this;
            win.Show();
        }

        private void Todo_Button_Click_Add_Card(object sender, RoutedEventArgs e)
        {
            Button btn = InitButton(DateTime.Now.ToLongTimeString());

            List<object> controls = new List<object>();

            for(int i=StackP_ToDo.Children.Count-1; i>=0; i--)
            {
                controls.Add(StackP_ToDo.Children[i]);
            }

            StackP_ToDo.Children.Clear();
            StackP_ToDo.Children.Add(btn);

            foreach(object obj in controls)
            {
                StackP_ToDo.Children.Add((UIElement)obj);
            }
        }

        private void Ip_Button_Click_Add_Card(object sender, RoutedEventArgs e)
        {
            Button btn = InitButton(DateTime.Now.ToLongTimeString());

            List<object> controls = new List<object>();

            for (int i = StackP_Inprocess.Children.Count - 1; i >= 0; i--)
            {
                controls.Add(StackP_Inprocess.Children[i]);
            }

            StackP_Inprocess.Children.Clear();
            StackP_Inprocess.Children.Add(btn);

            foreach (object obj in controls)
            {
                StackP_Inprocess.Children.Add((UIElement)obj);
            }
        }

        private void Fns_Button_Click_Add_Card(object sender, RoutedEventArgs e)
        {
            Button btn = InitButton(DateTime.Now.ToLongTimeString());

            List<object> controls = new List<object>();

            for (int i = StackP_Fns.Children.Count - 1; i >= 0; i--)
            {
                controls.Add(StackP_Fns.Children[i]);
            }

            StackP_Fns.Children.Clear();
            StackP_Fns.Children.Add(btn);

            foreach (object obj in controls)
            {
                StackP_Fns.Children.Add((UIElement)obj);
            }
        }

        private Button InitButton(string name)
        {
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Stretch;
            btn.Content = name;
            btn.Margin = new Thickness(0, 2, 0, 4);
            btn.Click += Button_Click_Edit_Card;

            return btn;
        }


        private void Button_Click_Edit_Card(object sender, RoutedEventArgs e)
        {

        }
    }
}
