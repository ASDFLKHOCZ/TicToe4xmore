using System;
using System.Drawing;
using System.Windows.Threading;
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
using System.Windows.Shapes;

namespace TicToe4xmore
{
    /// <summary>
    /// Логика взаимодействия для SettingsForm.xaml
    /// </summary>
    public partial class SettingsForm : Window
    {
        public SettingsForm()
        {
            InitializeComponent();
            DispatcherTimer ColorTimer = new DispatcherTimer();
            ColorTimer.Tick += ColorTimer_Tick;
            ColorTimer.Interval =System.TimeSpan.FromMilliseconds(200);
            ColorTimer.Start();
                                                                                                                 
            foreach (UIElement el in SettingsGrid.Children)
            {

                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                    
                }
            }
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string   strcontent = (string)((Button)e.OriginalSource).Content;
            if (     strcontent == "ENG") { SettingsClass.PublicLanguage = "ENG";  }
            else if (strcontent == "UA") { SettingsClass.PublicLanguage = "UA";  }
            else if (strcontent == "3x3") { SettingsClass.PublicSize = "3x3";  CreateForm(); }
            else if (strcontent == "4x4") { SettingsClass.PublicSize = "4x4";  CreateForm(); }
            else if (strcontent == "5x5") { SettingsClass.PublicSize = "5x5";  CreateForm(); }
            else { }
            void CreateForm()
            {
                
                MainWindow mainwindow = new MainWindow();
                mainwindow.Show();
                Close();
            }

        }
        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            this.DebugLabel.Content = "Language: " + SettingsClass.PublicLanguage + "\r\n" + "Size: " + SettingsClass.PublicSize;
        }
        
        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            if (SettingsClass.PublicLanguage == "UA")
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#F0F8FF"); //AliceBlue
                Language_ENG_Settings.Background = brush;
                brush = (System.Windows.Media.Brush)converter.ConvertFromString("#C1C1C1"); //LightSteelBlue
                Language_UA_Settings.Background = brush;
            }
            else if (SettingsClass.PublicLanguage == "ENG")
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#C1C1C1"); //LightSteelBlue
                Language_ENG_Settings.Background = brush;
                brush = (System.Windows.Media.Brush)converter.ConvertFromString("#F0F8FF"); //AliceBlue
                Language_UA_Settings.Background = brush;
            }
            //LightSteelBlue
        }
    }
}
