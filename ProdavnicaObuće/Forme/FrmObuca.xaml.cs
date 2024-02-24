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
    /// Interaction logic for FrmObuca.xaml
    /// </summary>
    public partial class FrmObuca : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmObuca()
        {
            InitializeComponent();
            txtVelicina.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }
        public FrmObuca(bool azuriraj, DataRowView red)
        {
            this.azuriraj = azuriraj;
            this.red = red;
            InitializeComponent();
            txtVelicina.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiModele = @"SELECT modelID, nazivModela AS Model FROM tblModel";
                SqlDataAdapter daModel = new SqlDataAdapter(vratiModele, konekcija);
                DataTable dtModel = new DataTable();
                daModel.Fill(dtModel);
                cbModel.ItemsSource = dtModel.DefaultView;
                daModel.Dispose();
                dtModel.Dispose();

                string vratiMarke = @"SELECT markaID, nazivMarke AS Marka FROM tblMarka";
                SqlDataAdapter daMarka = new SqlDataAdapter(vratiMarke, konekcija);
                DataTable dtMarka = new DataTable();
                daMarka.Fill(dtMarka);
                cbMarka.ItemsSource = dtMarka.DefaultView;
                daMarka.Dispose();
                dtMarka.Dispose();

                string vratiTipoveObuce = @"SELECT tipObuceID, nazivTipaObuce AS Tip FROM tblTipObuce";
                SqlDataAdapter daTipObuce = new SqlDataAdapter(vratiTipoveObuce, konekcija);
                DataTable dtTipObuce = new DataTable();
                daTipObuce.Fill(dtTipObuce);
                cbTipObuce.ItemsSource = dtTipObuce.DefaultView;
                daTipObuce.Dispose();
                dtTipObuce.Dispose();

                string vratiNarudzbine = @"SELECT narudzbinaID, datum FROM tblNarudzbina";
                SqlDataAdapter daNarudzbina = new SqlDataAdapter(vratiNarudzbine, konekcija);
                DataTable dtNarudzbina = new DataTable();
                daNarudzbina.Fill(dtNarudzbina);
                cbNarudzbina.ItemsSource = dtNarudzbina.DefaultView;
                daNarudzbina.Dispose();
                dtNarudzbina.Dispose();
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
                cmd.Parameters.Add("@velicina", SqlDbType.Int).Value = txtVelicina.Text;
                cmd.Parameters.Add("@cijena", SqlDbType.Real).Value = txtCijena.Text;
                cmd.Parameters.Add("@boja", SqlDbType.NVarChar).Value = txtBoja.Text;
                cmd.Parameters.Add("@modelID", SqlDbType.Int).Value = cbModel.SelectedValue;
                cmd.Parameters.Add("@markaID", SqlDbType.Int).Value = cbMarka.SelectedValue;
                cmd.Parameters.Add("@tipObuceID", SqlDbType.Int).Value = cbTipObuce.SelectedValue;
                cmd.Parameters.Add("@narudzbinaID", SqlDbType.Int).Value = cbNarudzbina.SelectedValue;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblObuca
                                       set velicina = @velicina, cijena = @cijena, boja = @boja,
                                        modelID = @modelID, markaID = @markaID, tipObuceID = @tipObuceID, narudzbinaID = @narudzbinaID
                                       where obucaID  = @id";
                    red = null;
                }
                else
                {

                    cmd.CommandText = @"insert into tblObuca(velicina, cijena, boja, 
                                    modelID, markaID, tipObuceID, narudzbinaID)
                                    VALUES (@velicina, @cijena, @boja, @modelID, @markaID, @tipObuceID, @narudzbinaID)";
                }
                cmd.ExecuteNonQuery(); //ova metoda pokrece izvrsenje nase komande gore
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
