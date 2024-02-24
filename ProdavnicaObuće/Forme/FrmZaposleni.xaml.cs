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
    /// Interaction logic for FrmZaposleni.xaml
    /// </summary>
    public partial class FrmZaposleni : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmZaposleni()
        {
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmZaposleni(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtIme.Focus();
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

                cmd.Parameters.Add("@imeZap", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@prezimeZap", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@jmbg", SqlDbType.NVarChar).Value = txtJMBG.Text;
                cmd.Parameters.Add("@adresaZap", SqlDbType.NVarChar).Value = txtAdresa.Text;
                cmd.Parameters.Add("@kontaktZap", SqlDbType.NVarChar).Value = txtKontakt.Text;
                cmd.Parameters.Add("@lozinka", SqlDbType.NVarChar).Value = txtLozinka.Text;
                cmd.Parameters.Add("@gradZap", SqlDbType.NVarChar).Value = txtGrad.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblZaposleni SET imeZap=@imeZap,prezimeZap=@prezimeZap,jmbg=@jmbg,
                                       adresaZap=@adresaZap,kontaktZap=@kontaktZap,lozinka=@lozinka,gradZap=@gradZap 
                                       WHERE zaposleniID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblZaposleni(imeZap,prezimeZap,jmbg,adresaZap,kontaktZap,lozinka,gradZap)
                                    VALUES (@imeZap,@prezimeZap,@jmbg,@adresaZap,@kontaktZap,@lozinka,@gradZap)";
                }

                cmd.ExecuteNonQuery(); //ova metoda pokrece izvrsenje nase komande gore
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Doslo je do greske prilikom konverzija podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
