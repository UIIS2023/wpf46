using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace ProdavnicaObuće.Forme
{
    /// <summary>
    /// Interaction logic for FrmTipObuce.xaml
    /// </summary>
    public partial class FrmTipObuce : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmTipObuce()
        {
            InitializeComponent();
            txtNazivTipaObuce.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        public FrmTipObuce(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtNazivTipaObuce.Focus();
            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@nazivTipaObuce", SqlDbType.NVarChar).Value = txtNazivTipaObuce.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblTipObuce
                                         set nazivTipaObuce = @nazivTipaObuce
                                            where tipObuceID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblTipObuce(nazivTipaObuce)
                                    values (@nazivTipaObuce)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
