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

namespace DiskVArende
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка входа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_Vihod_Click(object sender, RoutedEventArgs e)
        {
            string login = TB_Logg.Text.Trim();
            string Password = TB_Pass.Password.Trim();
            if (login.Length == 0) //проверка заполненности логина
            {
                TB_Logg.BorderBrush = Brushes.Red;
                TB_Logg.ToolTip = "dhfh";
            }
            else
            {
                User user = DisksEntities.GetContext().User.Where(b => b.login == login & b.password == Password).FirstOrDefault();
                if (user != null)
                {
                    Class1.U = user.Familia;
                    if (user.Role == "Сотрудник")
                    {
                        WinUser winUser = new WinUser();
                        winUser.Show();
                        Application.Current.MainWindow.Close();
                    }
                    else
                    {
                        WinAdmin winU = new WinAdmin();
                        winU.Show();
                        Application.Current.MainWindow.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
    }
}
