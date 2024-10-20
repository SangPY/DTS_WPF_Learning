using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public MainWindow()
        {
            InitializeComponent();

            //MenuItem root = new MenuItem() { Title = "Menu" };

            //MenuItem childItem1 = new MenuItem() { Title = "Child item #1" };
            //childItem1.Items.Add(new MenuItem() { Title = "Child item #1.1" });
            //childItem1.Items.Add(new MenuItem() { Title = "Child item #1.2" });
            //root.Items.Add(childItem1);
            //root.Items.Add(new MenuItem() { Title = "Child item #2" });
            //trvMenu.Items.Add(root);

            List<Family> families = new List<Family>();
            Family family1 = new Family() { Name = "Do thanh sang" };
            family1.Members.Add(new FamilyMember() { Name = "DTS", Age = 29 });
            family1.Members.Add(new FamilyMember() { Name = "SangDT", Age = 28 });
            family1.Members.Add(new FamilyMember() { Name = "S DX", Age = 31 });
            families.Add(family1);

            Family family2 = new Family() { Name = "Do thanh hong an" };
            family2.Members.Add(new FamilyMember() { Name = "Hong an", Age = 1 });
            family2.Members.Add(new FamilyMember() { Name = "May", Age = 2 });

            families.Add(family2);

            trvFamilies.ItemsSource = families;
        }
    }

    public class MenuItem
    {
        public MenuItem()
        {
            this.Items = new ObservableCollection<MenuItem>();
        }

        public string Title { get; set; }

        public ObservableCollection<MenuItem> Items { get; set; }
    }

    public class Family
    {
        public Family()
        {
            this.Members = new ObservableCollection<FamilyMember>();
        }

        public string Name { get; set; }

        public ObservableCollection<FamilyMember> Members { get; set; }
    }


    public class FamilyMember
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
