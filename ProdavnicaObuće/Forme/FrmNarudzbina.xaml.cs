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
    /// Interaction logic for FrmNarudzbina.xaml
    /// </summary>
    public partial class FrmNarudzbina : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmNarudzbina()
        {
            InitializeComponent();
            dpDatum.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmNarudzbina(bool azuriraj, DataRowView red)
        {
            this.azuriraj = azuriraj;
            this.red = red;
            InitializeComponent();
            dpDatum.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiKupce = @"SELECT kupacID, ime + ' ' + prezime AS Kupac FROM tblKupac";
                SqlDataAdapter daKupac = new SqlDataAdapter(vratiKupce, konekcija);
                DataTable dtKupac = new DataTable();
                daKupac.Fill(dtKupac);
                cbKupac.ItemsSource = dtKupac.DefaultView;
                daKupac.Dispose();
                dtKupac.Dispose();

                string vratiZaposlene = @"SELECT zaposleniID, imeZap + ' ' + prezimeZap AS Zaposleni FROM tblZaposleni";
                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposlene, konekcija);
                DataTable dtZaposleni = new DataTable();
                daZaposleni.Fill(dtZaposleni);
                cbZaposleni.ItemsSource = dtZaposleni.DefaultView;
                daZaposleni.Dispose();
                dtZaposleni.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DateTime date = (DateTime)dpDatum.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@datum", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@cijenaNarudzbine", SqlDbType.Real).Value = txtCijena.Text;
                cmd.Parameters.Add("@kupacID", SqlDbType.Int).Value = cbKupac.SelectedValue;
                cmd.Parameters.Add("@zaposleniID", SqlDbType.Int).Value = cbZaposleni.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblNarudzbina
                                       SET datum = @datum, cijenaNarudzbine = @cijenaNarudzbine, kupacID = @kupacID, zaposleniID = @zaposleniID
                                       WHERE narudzbinaID  = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblNarudzbina(datum, cijenaNarudzbine,kupacID, zaposleniID)
                                        VALUES (@datum, @cijenaNarudzbine, @kupacID, @zaposleniID)";
                }
                cmd.ExecuteNonQuery(); //ova metoda pokrece izvrsenje nase komande gore
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
