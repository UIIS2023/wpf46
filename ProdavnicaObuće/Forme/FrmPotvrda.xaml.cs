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
    /// Interaction logic for FrmPotvrda.xaml
    /// </summary>
    public partial class FrmPotvrda : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmPotvrda()
        {
            InitializeComponent();
            cbxIzvrsena.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }
        public FrmPotvrda(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            cbxIzvrsena.Focus();
            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
            PopuniPadajuceListe();
        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();
                string vratiNarudzbine2 = @"SELECT narudzbinaID, cijenaNarudzbine AS Cijena FROM tblNarudzbina";
                SqlDataAdapter daNarudzbina2 = new SqlDataAdapter(vratiNarudzbine2, konekcija);
                DataTable dtNarudzbina2 = new DataTable();
                daNarudzbina2.Fill(dtNarudzbina2);
                cbNarudzbina2.ItemsSource = dtNarudzbina2.DefaultView;
                daNarudzbina2.Dispose();
                dtNarudzbina2.Dispose();
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
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@izvrsenaTransakcija", SqlDbType.Bit).Value = Convert.ToInt32(cbxIzvrsena.IsChecked);
                cmd.Parameters.Add("@narudzbinaID", SqlDbType.Int).Value = cbNarudzbina2.SelectedValue;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblPotvrda
                                        set izvrsenaTransakcija = @izvrsenaTransakcija, narudzbinaID = @narudzbinaID
                                        where potvrdaID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblPotvrda(izvrsenaTransakcija, narudzbinaID)
                                    values (@izvrsenaTransakcija, @narudzbinaID)";
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
