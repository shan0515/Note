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

namespace 記事本
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        //定義儲存路徑
        string FilePath = "";
        //定義用作判斷儲存
        string Savedtext = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        //滑鼠可以移動
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        //最小化
        private void MinimunButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //最大化
        private void MaximumButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        //宣告儲存檔案 
        void Save()
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                FilePath = dlg.FileName;

                // 儲存檔案
                System.IO.File.WriteAllText(FilePath, TextArea.Text);

                //判斷是否儲存過
                Savedtext = TextArea.Text;

                //是否需要另存
                fileTitle.Text = FilePath;

            }
        }

        //宣告開啟檔案
        void Open()
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                FilePath = dlg.FileName;

                // 讀取檔案
                TextArea.Text = System.IO.File.ReadAllText(FilePath);

                //設定判斷是否儲存過的參考值
                Savedtext = TextArea.Text;

                //設定是否需要另存的判斷參考值
                fileTitle.Text = FilePath;
            }
        }

        //關閉
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (Savedtext != TextArea.Text)
            {
                if (MessageBox.Show("是否要儲存新的變更?", "Save or Not", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        //新增
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Savedtext != TextArea.Text)
            {
                if (MessageBox.Show("是否要儲存新的變更?", "YES or NO", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                }
                else
                {
                    //設定案名為NEW 用作Save的判斷
                    fileTitle.Text = "New";

                    //清空文字方格
                    TextArea.Text = "";

                    //設定判斷是否儲存過的參考值
                    Savedtext = TextArea.Text;
                }
            }
            else
            {
                //設定案名為NEW 用作Save的判斷
                fileTitle.Text = "New";

                //清空文字方格
                TextArea.Text = "";

                //設定判斷是否儲存過的參考值
                Savedtext = TextArea.Text;
            }
        }

        //打開
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextArea.Text != Savedtext)
            {
                if (MessageBox.Show("是否要儲存新的變更?", "YES or NO", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Save();
                    Open();
                }
                else
                {
                    Open();
                }
            }
            else
            {
                Open();
            }
        }

        //儲存
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (fileTitle.Text == FilePath)
            {
                System.IO.File.WriteAllText(FilePath, TextArea.Text);
                Savedtext = TextArea.Text;
            }
            else
            {
                Save();
                Savedtext = TextArea.Text;
            }
        }

        //另存
        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            Save();
            Savedtext = TextArea.Text;
        }

        //字型大小
        private void frontSize12_Click(object sender, RoutedEventArgs e)
        {
            TextArea.FontSize = 12;
        }

        private void frontSize18_Click(object sender, RoutedEventArgs e)
        {
            TextArea.FontSize = 18;
        }

        private void frontSize24_Click(object sender, RoutedEventArgs e)
        {
            TextArea.FontSize = 24;
        }

        //切換面板
        private void DarkmodeSwitch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //判斷背景顏色
            if (TextArea.Background == Brushes.White)
            {
                //文字和背景的顏色
                TextArea.Foreground = Brushes.White;
                TextArea.Background = Brushes.Gray;
            }
        }

        private void WhitemodeSwitch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TextArea.Background == Brushes.Gray)
            {
                TextArea.Background = Brushes.White;
                TextArea.Foreground = Brushes.Black;
            }
        }
    }
}
