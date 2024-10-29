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

        private int _currentIndex = 0;
        private bool _isDragging = false; // Biến để xác định trạng thái kéo

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

        //private void NextImage_Click(object sender, RoutedEventArgs e)
        //{
        //    // Tăng chỉ số ảnh hiện tại
        //    _currentIndex = (_currentIndex + 1) % _imagePaths.Count; // Quay vòng lại khi đến cuối danh sách
        //    ShowImage(_currentIndex);
        //}

        // Sự kiện click vào chấm trắng
        private void CenterDot_Click(object sender, MouseButtonEventArgs e)
        {
            // Mở đường link cố định trong trình duyệt
            Process.Start(new ProcessStartInfo
            {
                FileName = _fixedLink,
                UseShellExecute = true // Cần thiết để mở link trong trình duyệt mặc định
            });
        }


        // Sự kiện khi bắt đầu kéo chấm trắng
        private void CenterDot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _isDragging = true;
            }
        }

        // Sự kiện khi đang kéo
        private void CenterDot_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                // Di chuyển chấm trắng hoặc chỉ đơn giản là giữ trạng thái kéo
                // Bạn có thể thêm logic di chuyển nếu cần
            }
        }

        // Sự kiện khi thả chuột sau khi kéo
        private void CenterDot_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragging)
            {
                // Khi hoàn thành kéo, chuyển sang hình ảnh tiếp theo
                _currentIndex = (_currentIndex + 1) % _imagePaths.Count;
                ShowImage(_currentIndex);
                _isDragging = false; // Kết thúc trạng thái kéo
            }
        }

        // Sự kiện bắt đầu kéo chấm trắng
        //private void CenterDot_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.LeftButton == MouseButtonState.Pressed && !_isDragging)
        //    {
        //        _isDragging = true;
        //    }
        //    else if (e.LeftButton == MouseButtonState.Released && _isDragging)
        //    {
        //        // Khi hoàn thành kéo, chuyển sang hình ảnh tiếp theo
        //        _currentIndex = (_currentIndex + 1) % _imagePaths.Count;
        //        ShowImage(_currentIndex);
        //        _isDragging = false;
        //    }
        //}
    }
}
