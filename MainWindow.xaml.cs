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
using iScrum.Respository;
using System.Data;

namespace iScrum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SqliteHelper sqliteHelper = new SqliteHelper();
        public MainWindow()
        {
            InitializeComponent();

            InitToDoList();
        }

        private Assembly _assembly = Assembly.GetExecutingAssembly();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           string winName = ((Button)e.OriginalSource).Tag.ToString();
            switch(winName)
            {
                case "AddTodo":
                    Window_Todo win = new Window_Todo();
                    win.Owner = this;
                    win.PassValuesEvent += new Window_Todo.PassValuesHandle(Add_ToDo_Event);
                    win.Show();
                    break;
            }
           
        }

        private void InitToDoList()
        {
            DataSet todoData = sqliteHelper.GetToDoList();
            Button btn = null;

            StackP_ToDo.Children.Clear();

            for (int i = todoData.Tables[0].Rows.Count - 1; i >= 0; i--)
            {
                btn = InitButton(todoData.Tables[0].Rows[i][1].ToString());
                StackP_ToDo.Children.Add(btn);
            }
        }

        private void Add_ToDo_Event(object sender, string e)
        {
            try
            {
                Button btn = null;
                if (sqliteHelper.AddToDo(new Model.ToDo
                {
                    Name = e
                }))
                {
                    List<object> controls = new List<object>();

                    for (int i = 0; i < StackP_ToDo.Children.Count; i++)
                    {
                        controls.Add(StackP_ToDo.Children[i]);
                    }

                    StackP_ToDo.Children.Clear();
                    btn = InitButton(e);
                    StackP_ToDo.Children.Add(btn);
                    
                    controls.ForEach(bt => StackP_ToDo.Children.Add((UIElement)bt));
                }

            }
            catch(Exception ex)
            {

            }

        }

        private void Todo_Button_Click_Add_Card(object sender, RoutedEventArgs e)
        {            

            Button btn = InitButton(DateTime.Now.ToLongTimeString());

            List<object> controls = new List<object>();

            for(int i=0; i< StackP_ToDo.Children.Count; i++)
            {
                controls.Add(StackP_ToDo.Children[i]);
            }

            StackP_ToDo.Children.Clear();
            StackP_ToDo.Children.Add(btn);

            controls.ForEach(bt => StackP_ToDo.Children.Add((UIElement)bt));            
        }

        private void Ip_Button_Click_Add_Card(object sender, RoutedEventArgs e)
        {
            Button btn = InitButton(DateTime.Now.ToLongTimeString());

            List<object> controls = new List<object>();

            for (int i = 0; i < StackP_Inprocess.Children.Count; i++)
            {
                controls.Add(StackP_Inprocess.Children[i]);
            }

            StackP_Inprocess.Children.Clear();
            StackP_Inprocess.Children.Add(btn);

            controls.ForEach(obj => StackP_Inprocess.Children.Add((UIElement)obj));
        }

        private void Fns_Button_Click_Add_Card(object sender, RoutedEventArgs e)
        {
            Button btn = InitButton(DateTime.Now.ToLongTimeString());

            List<object> controls = new List<object>();

            for (int i = 0; i < StackP_Fns.Children.Count; i++)
            {
                controls.Add(StackP_Fns.Children[i]);
            }

            StackP_Fns.Children.Clear();
            StackP_Fns.Children.Add(btn);

            controls.ForEach(obj => StackP_Fns.Children.Add((UIElement)obj));
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
