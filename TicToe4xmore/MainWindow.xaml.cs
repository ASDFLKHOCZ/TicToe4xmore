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
using System.Windows.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace TicToe4xmore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        void LButtonsAction(int mode)
        {
            switch (mode)
            {
                case 0:
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            buttonlist[i, j] = new Button();
                            Grid.SetRow(buttonlist[i, j], i);
                            Grid.SetColumn(buttonlist[i, j], j);
                            buttonlist[i, j].Click += PlayingPool_Click;
                            buttonlist[i, j].Content = Convert.ToString(j) + " " + Convert.ToString(i);
                            buttonlist[i, j].IsEnabled = true;
                            SecondMainWindowGrid.Children.Add(buttonlist[i, j]);
                        }
                    }
                    break;
                case 1:
                    Array.Clear(buttonlist, 0, buttonlist.Length);
                    Array.Clear(btnlist, 0, btnlist.Length);
                    break;
                case 2:
                    for(int i = 0; i < 5; i++)
                    {
                        for(int j = 0;j<5;j++)
                        {
                            buttonlist[i, j].IsEnabled = false;
                        }
                    }
                    break;
                default:
                    break;
            }
           
            
            


        }
        
        public int languageid()
        {
            return SettingsClass.PublicLanguage == "UA" ? 1 : SettingsClass.PublicLanguage == "ENG" ? 2 : 0;
        }
        public MainWindow()
        {
            InitializeComponent();
            string testText = "";
            int languageindex = 0;
            //languageindex = SettingsClass.PublicLanguage == "UA" ? 1 : SettingsClass.PublicLanguage == "ENG" ? 2:0;
            //SettingsClass.PublicLanguage=="UA"
            languageindex = languageid();
            if (languageindex==1) { testText = "Мова: " + SettingsClass.PublicLanguage + "\r\n" + "Розмір: " + SettingsClass.PublicSize; SettingsButton.Content = "Налаштування"; InfoButton.Content = "Інформація"; TurnTextBox.Text = "Хід: X"; }
            else if (languageindex==2) { testText = "Language: " + SettingsClass.PublicLanguage + "\r\n" + "Size: " + SettingsClass.PublicSize; SettingsButton.Content = "Settings"; InfoButton.Content = "Information"; TurnTextBox.Text = "Turn: X"; }
            this.TestTextBox.Text = testText;
            int MainSize = 0;
            switch (SettingsClass.PublicSize)
            {
                case "3x3":
                    MainSize = 3; Column4.Width = new GridLength(0); Column3.Width = new GridLength(0); Row4.Height = new GridLength(0); Row3.Height = new GridLength(0);
                    break;
                case "4x4":
                    MainSize = 4; Column4.Width = new GridLength(0); Row4.Height = new GridLength(0);
                    break;
                case "5x5":
                    MainSize = 5;
                    break;
            }
            LButtonsAction(0);


        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
          //  SettingsForm settingform = new SettingsForm();
          //  settingform.Show();
          //  SecondMainWindowGrid.Children.Clear();
           LButtonsAction(1);
            System.Windows.Forms.Application.Restart();
           Close();
           // RestartMyApp();
        }
        private void RestartMyApp([CallerMemberName] string callerName = "")
        {
            Application.Current.Exit += (s, e) =>
            {
                const string allowedCallingMethod = "SettingsButton_Click"; // todo: Set your calling method here

                if (callerName == allowedCallingMethod)
                {
                    Process.Start(Application.ResourceAssembly.Location);
                }
            };

            Application.Current.Shutdown(); // Environment.Exit(0); would also suffice 
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
        public int win_status=0; //1- win X, 2- win O, 3-Anybody wins
        public int scoregame = 0;
        public int[,] btnlist = new int[5,5];
        public static int intsize = SettingsClass.PublicSize == "3x3" ? 3 : SettingsClass.PublicSize == "4x4" ? 4 : SettingsClass.PublicSize == "5x5" ? 5 : 0;
        public Button[,] buttonlist = new Button[5, 5];
        private void PlayingPool_Click(object sender, EventArgs e)
        {
            
            string str = Convert.ToString(this.Content);
            int row = Grid.GetRow((Button)sender);
            int column = Grid.GetColumn((Button)sender);
            string turnstring = languageid() == 1 ? "Хід: " : languageid() == 2 ? "Turn: " : "Language Error";
            string turnplayerstring = turn_status == 1 ? "O" : turn_status == 2 ? "X" : "Error TurnPlayer";
            if(str != "O" || str != "X")
            {
                if (turn_status == 1) {   btnlist[row, column] = 1; buttonlist[row, column].IsEnabled = false; buttonlist[row, column].Content = "X";scoregame++;  TurnTextBox.Text = turnstring+turnplayerstring; CheckLogic();  turn_status = 2;   }
                else if (turn_status==2) {  btnlist[row, column] = 2; buttonlist[row, column].IsEnabled = false; buttonlist[row, column].Content = "O"; scoregame++;  TurnTextBox.Text = turnstring + turnplayerstring; CheckLogic(); turn_status = 1;  }
            }
            else
            {
                return;
            }
            
        }
        void CheckLogic()
        {
            int[,] listofbtn = btnlist;
            int turn = turn_status;
            if(ClassLib.GameLogic(btnlist,turn_status)) {
                if (turn_status == 2) { EndGame("winO"); win_status = 2;LButtonsAction(2); }
                else if (turn_status == 1) { EndGame("winX"); win_status = 1; LButtonsAction(2); }
                else { EndGame("Error"); }
            }
/*            if(intsize == 3)
            {
                if ((btnlist[0, 0] == turn & btnlist[0, 1] == turn & btnlist[0, 2] == turn)
                    ||(btnlist[1, 0] == turn & btnlist[1, 1] == turn & btnlist[1, 2] == turn)
                    || (btnlist[2, 0] == turn & btnlist[2, 1] == turn & btnlist[2, 2] == turn)
                    //vertical lines
                    ||(btnlist[0, 0] == turn & btnlist[1, 0] == turn & btnlist[2, 0] == turn)
                    ||(btnlist[0, 1] == turn & btnlist[1, 1] == turn & btnlist[2, 1] == turn)
                    || (btnlist[0, 2] == turn & btnlist[1, 2] == turn & btnlist[1, 3] == turn)
                    //horisontal lines
                    ||(btnlist[0, 0] == turn & btnlist[1, 1] == turn & btnlist[2, 2] == turn)
                    ||(btnlist[0, 2] == turn & btnlist[1, 1] == turn & btnlist[2, 0] == turn)
                    //x-lines
                    )
                {
                    if(turn_status == 2) { EndGame("winO");win_status = 2; }
                    else if (turn_status == 1) { EndGame("winX");win_status = 1; }
                    else { EndGame("Error"); }
                }

            }
            else if (intsize == 4)
            {
                if ((   btnlist[0,0]==turn & btnlist[0,1]==turn & btnlist[0,2]==turn & btnlist[0,3]==turn)
                    || (btnlist[1, 0] == turn & btnlist[1, 1] == turn & btnlist[1, 2] == turn & btnlist[1, 3] == turn)
                    || (btnlist[2, 0] == turn & btnlist[2, 1] == turn & btnlist[2, 2] == turn & btnlist[2, 3] == turn)
                    || (btnlist[3, 0] == turn & btnlist[3, 1] == turn & btnlist[3, 2] == turn & btnlist[3, 3] == turn)
                    //horisontal lines
                    || (btnlist[0, 0] == turn & btnlist[1, 0] == turn & btnlist[2, 0] == turn & btnlist[3, 0] == turn)
                    || (btnlist[0, 1] == turn & btnlist[1, 1] == turn & btnlist[2, 1] == turn & btnlist[3, 1] == turn)
                    || (btnlist[0, 2] == turn & btnlist[1, 2] == turn & btnlist[2, 2] == turn & btnlist[3, 2] == turn)
                    || (btnlist[0, 3] == turn & btnlist[1, 3] == turn & btnlist[2, 3] == turn & btnlist[3, 3] == turn)
                    //vertical lines
                    || (btnlist[0, 0] == turn & btnlist[1, 1] == turn & btnlist[2, 2] == turn & btnlist[3, 3] == turn)
                    || (btnlist[0, 3] == turn & btnlist[1, 2] == turn & btnlist[2, 1] == turn & btnlist[3, 0] == turn)
                    //x-lines
                    )
                {
                    if (turn_status == 2) { EndGame("winO"); win_status = 2; }
                    else if (turn_status == 1) { EndGame("winX"); win_status = 1; }
                    else { EndGame("Error"); }
                }

            }
            else if (intsize == 5)
            {
                if ((   btnlist[0, 0] == turn & btnlist[0, 1] == turn & btnlist[0, 2] == turn & btnlist[0, 3] == turn & btnlist[0, 4] == turn)
                    || (btnlist[1, 0] == turn & btnlist[1, 1] == turn & btnlist[1, 2] == turn & btnlist[1, 3] == turn & btnlist[1, 4] == turn)
                    || (btnlist[2, 0] == turn & btnlist[2, 1] == turn & btnlist[2, 2] == turn & btnlist[2, 3] == turn & btnlist[2, 4] == turn)
                    || (btnlist[3, 0] == turn & btnlist[3, 1] == turn & btnlist[3, 2] == turn & btnlist[3, 3] == turn & btnlist[3, 4] == turn)
                    || (btnlist[4, 0] == turn & btnlist[4, 1] == turn & btnlist[4, 2] == turn & btnlist[4, 3] == turn & btnlist[4, 4] == turn)
                    //horisontal lines
                    || (btnlist[0, 0] == turn & btnlist[1, 0] == turn & btnlist[2, 0] == turn & btnlist[3, 0] == turn & btnlist[4, 0] == turn)
                    || (btnlist[0, 1] == turn & btnlist[1, 1] == turn & btnlist[2, 1] == turn & btnlist[3, 1] == turn & btnlist[4, 1] == turn)
                    || (btnlist[0, 2] == turn & btnlist[1, 2] == turn & btnlist[2, 2] == turn & btnlist[3, 2] == turn & btnlist[4, 2] == turn)
                    || (btnlist[0, 3] == turn & btnlist[1, 3] == turn & btnlist[2, 3] == turn & btnlist[3, 3] == turn & btnlist[4, 3] == turn)
                    || (btnlist[0, 4] == turn & btnlist[1, 4] == turn & btnlist[2, 4] == turn & btnlist[3, 4] == turn & btnlist[4, 4] == turn)
                    //vertical lines
                    || (btnlist[0, 0] == turn & btnlist[1, 1] == turn & btnlist[2, 2] == turn & btnlist[3, 3] == turn & btnlist[4, 4] == turn)
                    || (btnlist[0, 4] == turn & btnlist[1, 3] == turn & btnlist[2, 2] == turn & btnlist[3, 1] == turn & btnlist[4, 0] == turn)
                    )
                {
                    if (turn_status == 2) { EndGame("winO"); win_status = 2; }
                    else if (turn_status == 1) { EndGame("winX"); win_status = 1; }
                    else { EndGame("Error"); }
                }
            }*/
            
             if (scoregame == intsize*intsize && win_status==0)
            {
                turn_status = 0;
                win_status = 3;
                EndGame("notwin");
            }
       }

        void EndGame(string status)
        {
            string casetext1="";
            string casetext2="";
            string casetext3="";
            if (languageid() == 1) { casetext1 = "Перемога: "; casetext2 = "Нажміть Кнопку Налаштування для Повтору"; casetext3 = "Ніхто не вийграв \r\nНажміть Кнопку Налаштування для Повтору"; }
            else if (languageid()==2) { casetext1 = "Win: "; casetext2 = "Press Settings Button for Replay"; casetext3 = "Nobody Wins\r\n Press Settings Button for Replay"; }
                //Press Settings Button for Replay"
                switch (status)
            {
                case "winX":
                    TurnTextBox.Text = casetext1 + "X\r\n" + casetext2 ;
                    break;
                case "winO":
                    TurnTextBox.Text = casetext1+ "O\r\n" + casetext2;
                    break;
                case "notwin":
                    TurnTextBox.Text = casetext3;
                    break;
                case "Error":
                    break;
            }
        }
    }
}
