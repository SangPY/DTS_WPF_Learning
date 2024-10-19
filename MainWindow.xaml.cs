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

namespace DTS_WPF_Learning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Food> listName;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbItemSource.ItemsSource = new List<string>() { "DTS", "Hồng Ân", "Mây" };
            listName = new List<Food>()
            {
                new Food() {Name = "Tiger", Price = "350"},
                new Food() {Name = "333", Price = "30"},
                new Food() {Name = "Heniken", Price = "50"},
                new Food() {Name = "Sai gon", Price = "70"}
            };
            cbItemSource.ItemsSource = listName;
            //cbItemSource.DisplayMemberPath = "Name";
            //cbItemSource.SelectedValuePath = "Price";

            cbColor.ItemsSource = typeof(Colors).GetProperties();
            cbFont.ItemsSource = typeof(FontFamily).GetProperties();

            cbItemSource.SelectionChanged += CbItemSource_SelectionChanged;
        }

        private void CbItemSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show((cbItemSource.SelectedItem as Food).Price);
            MessageBox.Show(cbItemSource.SelectedValue.ToString());
        }
    }

    public class Food
    {
        public string Name { get; set; }
        public string Price { get; set; }

    }
}
