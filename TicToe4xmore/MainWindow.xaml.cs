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
        
        void CreateButtons()
        {   
                for (int i = 0; i < intsize; i++)
                {
                    for(int j = 0; j < intsize; j++)
                    {
                        buttonlist[i,j] = new Button();
                        Grid.SetRow(buttonlist[i, j], i);
                        Grid.SetColumn(buttonlist[i, j], j);
                        buttonlist[i, j].Click += PlayingPool_Click;
                        buttonlist[i, j].Content = Convert.ToString(j)+" "+ Convert.ToString(i);
                        buttonlist[i, j].IsEnabled = true;
                        SecondMainWindowGrid.Children.Add(buttonlist[i, j]);
                    }
                }
            
            


        }
        
        public int languageid()
        {
            return MainSettings.Default.Language == "UA" ? 1 : MainSettings.Default.Language == "ENG" ? 2 : 0;
        }
        public MainWindow()
        {
            InitializeComponent();
            string testText = "";
            int languageindex = 0;
            //languageindex = MainSettings.Default.Language == "UA" ? 1 : MainSettings.Default.Language == "ENG" ? 2:0;
            //MainSettings.Default.Language=="UA"
            languageindex = languageid();
            if (languageindex==1) { testText = "Мова: " + MainSettings.Default.Language + "\r\n" + "Розмір: " + MainSettings.Default.Size; SettingsButton.Content = "Налаштування"; InfoButton.Content = "Інформація"; }
            else if (languageindex==2) { testText = "Language: " + MainSettings.Default.Language + "\r\n" + "Size: " + MainSettings.Default.Size; SettingsButton.Content = "Settings"; InfoButton.Content = "Information"; }
            this.TestTextBox.Text = testText;
            int MainSize = 0;
            if (MainSettings.Default.Size == "3x3") { MainSize = 3; Column4.Width = new GridLength(0); Column3.Width = new GridLength(0);Row4.Height = new GridLength(0);Row3.Height = new GridLength(0); }
            else if (MainSettings.Default.Size == "4x4") { MainSize = 4;Column4.Width = new GridLength(0); Row4.Height = new GridLength(0); }
            else if (MainSettings.Default.Size == "5x5") { MainSize = 5; }
            CreateButtons();
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingform = new SettingsForm();
            settingform.Show();
            Close();
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            int languageindex = languageid(); //1=ua, 2=eng
            string captiontext = languageindex == 1 ? "Інформація" : languageindex == 2 ? "Information" : "Error/Помилка";
            string entertext = "";
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    entertext += btnlist[i,j] + " ";
                }
                entertext += "\r\n";
            }
            //string entertext = languageindex == 1 ? "Ця игра була створена для двох гравців." : languageindex == 2 ? "This game was created for 2 players." : "This language not registered.\r\nЦя мова не зареєстрована.";
            MessageBox.Show(entertext, captiontext);
        }
            

        public int turn_status = 1; //1 - X, 2--O
        public int win_status=0;
        public int scoregame = 0;
        public int[,] btnlist = new int[5,5];
        public static int intsize = MainSettings.Default.Size == "3x3" ? 3 : MainSettings.Default.Size == "4x4" ? 4 : MainSettings.Default.Size == "5x5" ? 5 : 0;
        public Button[,] buttonlist = new Button[intsize, intsize];
        private void PlayingPool_Click(object sender, EventArgs e)
        {
            string str = Convert.ToString(this.Content);
            int row = Grid.GetRow((Button)sender);
            int column = Grid.GetColumn((Button)sender);
            if(str != "O" || str != "X")
            {
                if (turn_status == 1) {  turn_status = 2; btnlist[row, column] = 1; buttonlist[row, column].IsEnabled = false; buttonlist[row, column].Content = "X"; ; }
                else if (turn_status==2) { turn_status = 1; btnlist[row, column] = 2; buttonlist[row, column].IsEnabled = false; buttonlist[row, column].Content = "O"; }
            }
            else
            {
                return;
            }
            CheckLogic();
        }
        void CheckLogic()
        {

        }
    }
}
