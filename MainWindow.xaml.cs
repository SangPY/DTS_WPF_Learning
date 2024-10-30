using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;

namespace DTS_WPF_Learning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Lớp để chứa thông tin hình ảnh
        public class ImageInfo
        {
            public string ImagePath { get; set; }
            public string Link { get; set; }
        }

        private List<ImageInfo> _imageData; // Danh sách chứa thông tin hình ảnh
        private int _currentIndex = 0;
        private bool _isDragging = false; // Biến để xác định trạng thái kéo
        private Point _startPoint; // Điểm bắt đầu của kéo

        public MainWindow()
        {
            InitializeComponent();
            LoadImageData(); // Đọc dữ liệu từ file JSON
            ShowImage(_currentIndex); // Hiển thị hình ảnh đầu tiên
        }

        // Hàm đọc dữ liệu từ file JSON
        private void LoadImageData()
        {
            //string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imageData.json");
            string jsonFilePath = @"D:\CSharp\DTS_WPF_Learning\imageData.json";

            //string jsonFilePath = "ImageData.json"; // Đường dẫn file JSON
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                _imageData = JsonConvert.DeserializeObject< List<ImageInfo>>(json);
            }
            else
            {
                MessageBox.Show("File JSON không tồn tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                _imageData = new List<ImageInfo>(); // Khởi tạo danh sách rỗng nếu không tìm thấy file JSON
            }
        }

        private void ShowImage(int index)
        {
            if (_imageData != null && index >= 0 && index < _imageData.Count)
            {
                string imagePath = _imageData[index].ImagePath;
                //string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _imageData[index].ImagePath);

                if (!File.Exists(imagePath))
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                    DisplayImage.Source = bitmap;
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy hình ảnh: {imagePath}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
            _isDragging = false; // Đặt lại trạng thái kéo
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
                    _currentIndex = (_currentIndex + 1) % _imageData.Count; //Chuyển sang hình ảnh tiếp theo
                    ShowImage(_currentIndex);
                }
            }
        }

        // Mở link của hình ảnh hiện tại
        private void OpenImageLink(int index)
        {
            if (index >= 0 && index < _imageData.Count)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _imageData[index].Link,
                    UseShellExecute = true // Cần thiết để mở link trong trình duyệt mặc định
                });
            }
        }
    }
}
