using System.Net;
using Models;
using Siskop.Views;
using Siskop;
using Siskop.Views;
using Siskop.Views.Admin;

namespace Siskop
{
    public partial class MainForm : Form
    {
        public AdminKaryawan adminKaryawan;
        public AdminNasabah adminNasabah;
        public karyawanDetails karyawanDetails;
        public NasabahDetails nasabahDetails;
        private readonly string connString;
        public AddPinjaman addPinjaman;
        public AddNasabah addNasabah;
        public AddKaryawan addKaryawan;
        //public UcLogin loginPage;
        public UserControl1 NasabahDash;
        public PinjamanControl PinjamanDash;
        public NasabahModel nasabahModel;
        public PinjamanModel pinjamanModel;
        public AngsuranModel angsuranModel;
        public KaryawanModel karyawanModel;


        public MainForm()
        {
            connString = "Host=localhost;Username=postgres;Password=kanokon132;Database=siskop";
            InitializeComponent();

            // Initialize models once
            nasabahModel = new NasabahModel(connString);
            pinjamanModel = new PinjamanModel(connString);

            // Pass models to UserControls
            //loginPage = new UcLogin(this, connString);
            NasabahDash = new UserControl1(this, nasabahModel);

            // Don't initialize PinjamanDash here since we need nasabahId
            // It will be created when needed with ShowPinjamanForNasabah method

            //this.Controls.Add(loginPage);
            this.Controls.Add(NasabahDash);
            HideAllPage();

            ShowPage(NasabahDash);
        }

        public void HideAllPage()
        {
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }
        }

        public void ShowPage(UserControl uc)
        {
            HideAllPage();
            uc.Visible = true;
        }
        public void ShowKaryawanDetails(Karyawan karyawan)
        {
            if (karyawanDetails != null)
            {
                this.Controls.Remove(karyawanDetails);
                karyawanDetails.Dispose();
            }

            // Create new PinjamanControl for specific nasabah, passing the shared model
            karyawanDetails = new karyawanDetails(karyawanModel, karyawan);
            this.Controls.Add(karyawanDetails);

            // Show the pinjaman page
            ShowPage(karyawanDetails);
        }
        public void ShowPinjamanForNasabah(Nasabah nasabah)
        {
            // Remove existing PinjamanDash if it exists
            if (PinjamanDash != null)
            {
                this.Controls.Remove(PinjamanDash);
                PinjamanDash.Dispose();
            }

            // Create new PinjamanControl for specific nasabah, passing the shared model
            PinjamanDash = new PinjamanControl(this, pinjamanModel,nasabah,angsuranModel);
            this.Controls.Add(PinjamanDash);

            // Show the pinjaman page
            ShowPage(PinjamanDash);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}