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
using System.ComponentModel;

namespace DTS_WPF_Learning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<User> items = new List<User>();

            items.Add(new User() { Name = "Đỗ Thanh Sang", Age = 29, Mail = "123@gmail.com", Sex = SexType.Male});
            items.Add(new User() { Name = "Đỗ Thanh Sung", Age = 23, Mail = "123@gmail.com", Sex = SexType.Male });
            items.Add(new User() { Name = "Đỗ Thanh Sen", Age = 27, Mail = "123@gmail.com", Sex = SexType.Female });
            items.Add(new User() { Name = "Đỗ Thanh Hồng Ân", Age = 1, Mail = "123@gmail.com", Sex = SexType.Female });

            lvUsers.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFiler;
        }

        private bool UserFiler(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as User).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) > 0);
        }

        public enum SexType { Male, Female};

        public class User
        {
            public string Name {get; set; }
            public int Age { get; set; }
            public string Mail { get; set; }

            public SexType Sex { get; set; }
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        }
    }
}
