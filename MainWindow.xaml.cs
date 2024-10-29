using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // Danh sách các đường link dẫn hình ảnh
        private List<string> _imageLinks = new List<string>
        {
           "https://www.vikingscyber.com/",
           "https://www.vikingscyber.com/khuyen-mai",
           "https://www.vikingscyber.com/tin-tuc"
        };


        private int _currentIndex = 0;
        private bool _isDragging = false; // Biến để xác định trạng thái kéo
        private Point _startPoint; // Điểm bắt đầu của kéo

        // Đường link cố định sẽ được mở khi click
        private string _fixedLink = "https://www.vikingscyber.com/";

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

        // Sự kiện khi nhấn chuột vào hình ảnh (bắt đầu kéo)
        private void DisplayImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _startPoint = e.GetPosition(this);
        }

        // Sự kiện khi thả chuột
        private void DisplayImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragging)
            {
                // Nếu là click không phải kéo, mở link của hình ảnh hiện tại
                OpenImageLink(_currentIndex);
            }    
        }

        // Sự kiện khi di chuyển chuột (kéo hình ảnh)
        private void DisplayImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point currentpoint = e.GetPosition(this);

                // Kiểm tra để kéo đủ xa, phân biệt giữa kéo thả và click
                if (Math.Abs(currentpoint.X - _startPoint.X) > 20 || Math.Abs(currentpoint.Y - _startPoint.Y) > 20)
                {
                    _isDragging = false;
                    _currentIndex = (_currentIndex + 1) % _imagePaths.Count; //Chuyển sang hình ảnh tiếp theo
                    ShowImage(_currentIndex);
                }
            }
        }

        // Mở link của hình ảnh hiện tại
        private void OpenImageLink(int index)
        {
            if (index >= 0 && index < _imageLinks.Count)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _imageLinks[index],
                    UseShellExecute = true // Cần thiết để mở link trong trình duyệt mặc định
                });
            }
        }
    }
}
