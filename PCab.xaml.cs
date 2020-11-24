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

    public partial class PCab : Page
    {
        public PCab()
        {
            InitializeComponent();
            using (TDE db = new TDE())
            {
                db.Users.Load();
                CLV.ItemsSource = db.Users.Local.ToBindingList();                
                Users user = db.Users.Where(U => U.id == MainMove.CurrentUserID).FirstOrDefault();
                CabNum.Text = "Номер счета:" + user.number;
                CabName.Text = user.Name;
            }
            
            
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            using (TDE db = new TDE())
            {
                db.Users.Load();
                var user = db.Users.Where(U => U.id == ((Users)CLV.SelectedValue).id).FirstOrDefault();
                ETBID.Text = Convert.ToString(user.id);
                ETBName.Text = user.Name;
                ETBNum.Text = user.number;
                EditPanel.Visibility = Visibility.Visible;
                 
            }
        }

        private void EditSave(object sender, RoutedEventArgs e)
        {
            using (TDE db = new TDE())
            {
                db.Users.Load();
                var user = db.Users.Where(U => U.id == ((Users)CLV.SelectedValue).id).FirstOrDefault();
                user.Name = ETBName.Text;
                user.number = (ETBNum.Text);
                db.SaveChanges();
                CLV.Items.
            }
        }
    }
}
