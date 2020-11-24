using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Podgotovka
{

    public partial class PReg : Page
    {
        public PReg()
        {
            InitializeComponent();
            
        }
        TDE db = new TDE();

        private void Registration(object sender, RoutedEventArgs e)
        {
            db.Users.Load();
            using (TDE db = new TDE())
            {

                Users user = new Users()
                {
                    Name = RLTB.Text,
                    number = RNTB.Text,
                    Password = RPTB.Text                    
                };
                var newUserCheck = db.Users.Where(U => U.Name == RLTB.Text).FirstOrDefault();
                if (newUserCheck == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    MainMove.CurrentUserID = user.id;
                    System.Windows.MessageBox.Show("Вы успешно зарегестрировались!");
                    MainMove.MainFrame.Navigate(new PCab());
                }
                else System.Windows.MessageBox.Show("Такой пользователь уже зарегестрирован!");          

                
            }
        }

        private void Autorisation(object sender, RoutedEventArgs e)
        {
            db.Users.Load();
            using (TDE db = new TDE())
            {
                var autoUserCheck = db.Users.Where(U => U.Name == ALTB.Text).FirstOrDefault();
                if (autoUserCheck != null)
                {
                    MainMove.CurrentUserID = autoUserCheck.id;
                    System.Windows.MessageBox.Show("Вы успешно авторизовались!");
                    MainMove.MainFrame.Navigate(new PCab());
                }
            }
            
        }
    }
}
