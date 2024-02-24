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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProdavnicaObuće.Forme;
using System.Windows.Controls.Primitives;

namespace ProdavnicaObuće
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private string ucitanaTabela;
        private bool azuriraj;
        private DataRowView red;

        #region Select upiti
        private static string zaposleniSelect = @"SELECT zaposleniID AS ID, imeZap + ' ' + prezimeZap AS Zaposleni, jmbg AS JMBG, adresaZap AS Adresa, gradZap AS Grad, kontaktZap AS Kontakt, lozinka AS Lozinka FROM tblZaposleni";

        private static string kupciSelect = @"SELECT kupacID AS ID, ime + ' ' + prezime AS Kupac, jmbgKupca AS JMBG, adresa AS Adresa, grad AS Grad,
                                            kontakt AS Kontakt FROM tblKupac";

        private static string obucaSelect = @"SELECT obucaID AS ID, velicina AS 'Velicina obuce',cijena AS 'Cijena obuce',boja AS 'Boja obuce', nazivModela AS 'Naziv modela',
                                            nazivMarke AS 'Naziv marke', nazivTipaObuce AS 'Tip obuce',datum AS 'Datum narudzbine'
                                            FROM tblObuca JOIN tblModel on tblObuca.modelID=tblModel.modelID
                                                          JOIN tblMarka on tblObuca.markaID= tblMarka.markaID
                                                          JOIN tblTipObuce on tblObuca.tipObuceID= tblTipObuce.tipObuceID
                                                          JOIN tblNarudzbina on tblObuca.narudzbinaID= tblNarudzbina.narudzbinaID";

        private static string modeliSelect = @"SELECT modelID AS ID, nazivModela AS 'Naziv modela' FROM tblModel";

        private static string markeSelect = @"SELECT markaID AS ID, nazivMarke AS 'Naziv marke' FROM tblMarka";

        private static string tipoviSelect = @"SELECT tipObuceID AS ID, nazivTipaObuce AS 'Tip obuce' FROM tblTipObuce";

        private static string narudzbineSelect = @"SELECT narudzbinaID AS ID, datum AS Datum, cijenaNarudzbine AS 'Cijena narudzbine',
                                             ime + ' ' + prezime AS Kupac, imeZap + ' ' + prezimeZap AS Zaposleni FROM tblNarudzbina 
                                            JOIN tblKupac on tblNarudzbina.kupacID = tblKupac.kupacID
                                            JOIN tblZaposleni on tblNarudzbina.zaposleniID = tblZaposleni.zaposleniID";
        private static string potvrdeSelect = @"SELECT potvrdaID AS ID, izvrsenaTransakcija AS 'Izvrsena transakcija', cijenaNarudzbine AS 'Cijena narudzbine'
                                                FROM tblPotvrda
                                                JOIN tblNarudzbina on tblPotvrda.narudzbinaID = tblNarudzbina.narudzbinaID";
        #endregion

        #region Select sa uslovom

        private static string selectUslovZaposleni = @"SELECT * FROM tblZaposleni WHERE zaposleniID=";

        private static string selectUslovKupci = @"SELECT * FROM tblKupac WHERE kupacID=";

        private static string selectUslovObuca = @"SELECT * FROM tblObuca WHERE obucaID=";

        private static string selectUslovModeli = @"SELECT * FROM tblModel WHERE modelID=";

        private static string selectUslovMarke = @"SELECT * FROM tblMarka WHERE markaID=";

        private static string selectUslovTipovi = @"SELECT * FROM tblTipObuce WHERE tipObuceID=";

        private static string selectUslovNarudzbine = @"SELECT * FROM tblNarudzbina WHERE narudzbinaID=";

        private static string selectUslovPotvrde = @"SELECT * FROM tblPotvrda WHERE potvrdaID=";

        #endregion

        #region Delete naredbe

        private static string zaposleniDelete = @"DELETE FROM tblZaposleni WHERE zaposleniID=";

        private static string kupciDelete = @"DELETE FROM tblKupac WHERE kupacID=";

        private static string obucaDelete = @"DELETE FROM tblObuca WHERE obucaID=";

        private static string modeliDelete = @"DELETE FROM tblModel WHERE modelID=";

        private static string markeDelete = @"DELETE FROM tblMarka WHERE markaID=";

        private static string tipoviDelete = @"DELETE FROM tblTipObuce WHERE tipObuceID=";

        private static string narudzbineDelete = @"DELETE FROM tblNarudzbina WHERE narudzbinaID=";

        private static string potvrdeDelete = @"DELETE FROM tblPotvrda WHERE potvrdaID=";


        #endregion
        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(obucaSelect);
        }
        private void UcitajPodatke(string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                }

                ucitanaTabela = selectUpit;
                dataAdapter.Dispose();
                dataTable.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Nastala je greska pri ucitavanju tabele", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;

            if (ucitanaTabela.Equals(zaposleniSelect))
            {
                prozor = new FrmZaposleni();
                prozor.ShowDialog();
                UcitajPodatke(zaposleniSelect);

            }
            else if (ucitanaTabela.Equals(kupciSelect))
            {
                prozor = new FrmKupac();
                prozor.ShowDialog();
                UcitajPodatke(kupciSelect);
            }
            else if (ucitanaTabela.Equals(obucaSelect))
            {
                prozor = new FrmObuca();
                prozor.ShowDialog();
                UcitajPodatke(obucaSelect);
            }
            else if (ucitanaTabela.Equals(modeliSelect))
            {
                prozor = new FrmModel();
                prozor.ShowDialog();
                UcitajPodatke(modeliSelect);
            }
            else if (ucitanaTabela.Equals(markeSelect))
            {
                prozor = new FrmMarka();
                prozor.ShowDialog();
                UcitajPodatke(markeSelect);
            }
            else if (ucitanaTabela.Equals(tipoviSelect))
            {
                prozor = new FrmTipObuce();
                prozor.ShowDialog();
                UcitajPodatke(tipoviSelect);
            }
            else if (ucitanaTabela.Equals(narudzbineSelect))
            {
                prozor = new FrmNarudzbina();
                prozor.ShowDialog();
                UcitajPodatke(narudzbineSelect);
            }
            else if (ucitanaTabela.Equals(potvrdeSelect))
            {
                prozor = new FrmPotvrda();
                prozor.ShowDialog();
                UcitajPodatke(potvrdeSelect);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(zaposleniSelect))
            {
                PopuniFormu(selectUslovZaposleni);
                UcitajPodatke(zaposleniSelect);

            }
            else if (ucitanaTabela.Equals(kupciSelect))
            {
                PopuniFormu(selectUslovKupci);
                UcitajPodatke(kupciSelect);
            }
            else if (ucitanaTabela.Equals(obucaSelect))
            {
                PopuniFormu(selectUslovObuca);
                UcitajPodatke(obucaSelect);
            }
            else if (ucitanaTabela.Equals(modeliSelect))
            {
                PopuniFormu(selectUslovModeli);
                UcitajPodatke(modeliSelect);
            }
            else if (ucitanaTabela.Equals(markeSelect))
            {
                PopuniFormu(selectUslovMarke);
                UcitajPodatke(markeSelect);
            }
            else if (ucitanaTabela.Equals(tipoviSelect))
            {
                PopuniFormu(selectUslovTipovi);
                UcitajPodatke(tipoviSelect);
            }
            else if (ucitanaTabela.Equals(narudzbineSelect))
            {
                PopuniFormu(selectUslovNarudzbine);
                UcitajPodatke(narudzbineSelect);
            }
            else if (ucitanaTabela.Equals(potvrdeSelect))
            {
                PopuniFormu(selectUslovPotvrde);
                UcitajPodatke(potvrdeSelect);
            }
        }
        private void PopuniFormu(object selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                cmd.Dispose();
                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(zaposleniSelect))
                    {
                        FrmZaposleni prozorZaposleni = new FrmZaposleni(azuriraj, red);
                        prozorZaposleni.txtIme.Text = citac["imeZap"].ToString();
                        prozorZaposleni.txtPrezime.Text = citac["prezimeZap"].ToString();
                        prozorZaposleni.txtJMBG.Text = citac["jmbg"].ToString();
                        prozorZaposleni.txtAdresa.Text = citac["adresaZap"].ToString();
                        prozorZaposleni.txtGrad.Text = citac["gradZap"].ToString();
                        prozorZaposleni.txtKontakt.Text = citac["kontaktZap"].ToString();
                        prozorZaposleni.txtLozinka.Text = citac["lozinka"].ToString();
                        prozorZaposleni.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(kupciSelect))
                    {
                        FrmKupac prozorKupac = new FrmKupac(azuriraj, red);
                        prozorKupac.txtIme.Text = citac["ime"].ToString();
                        prozorKupac.txtPrezime.Text = citac["prezime"].ToString();
                        prozorKupac.txtJMBG.Text = citac["jmbgKupca"].ToString();
                        prozorKupac.txtAdresa.Text = citac["adresa"].ToString();
                        prozorKupac.txtGrad.Text = citac["grad"].ToString();
                        prozorKupac.txtKontakt.Text = citac["kontakt"].ToString();
                        prozorKupac.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(obucaSelect))
                    {
                        FrmObuca prozorObuca = new FrmObuca(azuriraj, red);
                        prozorObuca.txtVelicina.Text = citac["velicina"].ToString();
                        prozorObuca.txtCijena.Text = citac["cijena"].ToString();
                        prozorObuca.txtBoja.Text = citac["boja"].ToString();
                        prozorObuca.cbModel.SelectedValue = citac["modelID"].ToString();
                        prozorObuca.cbMarka.SelectedValue = citac["markaID"].ToString();
                        prozorObuca.cbTipObuce.SelectedValue = citac["tipObuceID"].ToString();
                        prozorObuca.cbNarudzbina.SelectedValue = citac["narudzbinaID"].ToString();
                        prozorObuca.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(modeliSelect))
                    {
                        FrmModel prozorModel = new FrmModel(azuriraj, red);
                        prozorModel.txtNazivModela.Text = citac["nazivModela"].ToString();
                        prozorModel.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(markeSelect))
                    {
                        FrmMarka prozorMarka = new FrmMarka(azuriraj, red);
                        prozorMarka.txtNazivMarke.Text = citac["nazivMarke"].ToString();
                        prozorMarka.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(tipoviSelect))
                    {
                        FrmTipObuce prozorTipObuce = new FrmTipObuce(azuriraj, red);
                        prozorTipObuce.txtNazivTipaObuce.Text = citac["nazivTipaObuce"].ToString();
                        prozorTipObuce.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(narudzbineSelect))
                    {
                        FrmNarudzbina prozorNarudzbina = new FrmNarudzbina(azuriraj, red);
                        prozorNarudzbina.dpDatum.SelectedDate = (DateTime)citac["datum"];
                        prozorNarudzbina.txtCijena.Text = citac["cijenaNarudzbine"].ToString();
                        prozorNarudzbina.cbKupac.SelectedValue = citac["kupacID"].ToString();
                        prozorNarudzbina.cbZaposleni.SelectedValue = citac["zaposleniID"].ToString();
                        prozorNarudzbina.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(potvrdeSelect))
                    {
                        FrmPotvrda prozorPotvrda = new FrmPotvrda(azuriraj, red);
                        prozorPotvrda.cbxIzvrsena.IsChecked = (bool)citac["izvrsenaTransakcija"];
                        prozorPotvrda.cbNarudzbina2.SelectedValue =citac["narudzbinaID"].ToString();
                        prozorPotvrda.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

            private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(zaposleniSelect))
            {
                ObrisiZapis(zaposleniDelete);
                UcitajPodatke(zaposleniSelect);

            }
            else if (ucitanaTabela.Equals(kupciSelect))
            {
                ObrisiZapis(kupciDelete);
                UcitajPodatke(kupciSelect);
            }
            else if (ucitanaTabela.Equals(obucaSelect))
            {
                ObrisiZapis(obucaDelete);
                UcitajPodatke(obucaSelect);
            }
            else if (ucitanaTabela.Equals(modeliSelect))
            {
                ObrisiZapis(modeliDelete);
                UcitajPodatke(modeliSelect);
            }
            else if (ucitanaTabela.Equals(markeSelect))
            {
                ObrisiZapis(markeDelete);
                UcitajPodatke(markeSelect);
            }
            else if (ucitanaTabela.Equals(tipoviSelect))
            {
                ObrisiZapis(tipoviDelete);
                UcitajPodatke(tipoviSelect);
            }
            else if (ucitanaTabela.Equals(narudzbineSelect))
            {
                ObrisiZapis(narudzbineDelete);
                UcitajPodatke(narudzbineSelect);
            }
            else if (ucitanaTabela.Equals(potvrdeSelect))
            {
                ObrisiZapis(potvrdeDelete);
                UcitajPodatke(potvrdeSelect);
            }
        }
        private void ObrisiZapis(string deleteUslov)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUslov + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnZaposleni_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(zaposleniSelect);
        }

        private void btnKupci_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(kupciSelect);
        }

        private void btnObuca_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(obucaSelect);
        }

        private void btnModeli_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(modeliSelect);
        }

        private void btnMarke_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(markeSelect);
        }

        private void btnTipovi_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(tipoviSelect);
        }

        private void btnNarudzbine_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(narudzbineSelect);
        }

        private void btnPotvrde_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(potvrdeSelect);
        }
    }
}
