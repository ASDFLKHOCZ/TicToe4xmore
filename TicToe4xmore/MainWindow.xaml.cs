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
using System.Collections.ObjectModel;

namespace TicToe4xmore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            string testText = "";
            int languageindex = 0;
            languageindex = MainSettings.Default.Language == "UA" ? 1 : MainSettings.Default.Language == "ENG" ? 2:0;
            //MainSettings.Default.Language=="UA"
            if (languageindex==1) { testText = "Мова: " + MainSettings.Default.Language + "\r\n" + "Розмір: " + MainSettings.Default.Size; }
            else if (languageindex==2) { testText = "Language: " + MainSettings.Default.Language + "\r\n" + "Size: " + MainSettings.Default.Size; }
            this.TestTextBox.Text = testText;
            int MainSize = 0;
            if (MainSettings.Default.Size == "3x3") { MainSize = 3; }
            else if (MainSettings.Default.Size == "4x4") { MainSize = 4; }
            else if (MainSettings.Default.Size == "5x5") { MainSize = 5; }
            int[,] buttonlist = new int[MainSize, MainSize];
            



        }
        
       

    }
}
