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
        // Danh sách các đường dẫn hình ảnh
        private List<string> _imagePaths = new List<string>
        {
            "Images/sang1.jpg",
            "Images/sang2.jpg",
            "Images/sang3.jpg"
            // Thêm các đường dẫn hình ảnh khác ở đây
        };

        private int _currentIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            ShowImage(_currentIndex); // Hiển thị hình ảnh đầu tiên
        }

        private void ShowImage(int index)
        {
            if (index >= 0 && index < _imagePaths.Count)
            {
                // Tạo một đối tượng BitmapImage và gán cho Image.Source
                BitmapImage bitmap = new BitmapImage(new Uri(_imagePaths[index], UriKind.RelativeOrAbsolute));
                DisplayImage.Source = bitmap;
            }
        }

        private void NextImage_Click(object sender, RoutedEventArgs e)
        {
            // Tăng chỉ số ảnh hiện tại
            _currentIndex = (_currentIndex + 1) % _imagePaths.Count; // Quay vòng lại khi đến cuối danh sách
            ShowImage(_currentIndex);
        }
    }
}
