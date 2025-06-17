using System.Net;
using Models;
using Siskop.Views;
using Siskop;
using Siskop.Views;

namespace Siskop
{
    public partial class MainForm : Form
    {
        // Admin Views
        public AdminKaryawan adminKaryawan;
        public AdminNasabah adminNasabah;
        public UcLogin login;

        // Detail Views
        public karyawanDetails karyawanDetails;
        public NasabahDetails nasabahDetails;

        // Add/Create Views
        public AddPinjaman addPinjaman;
        public AddNasabah addNasabah;
        public AddKaryawan addKaryawan;

        // Dashboard/Control Views
        public UserControl1 NasabahDash;
        public PinjamanControl PinjamanDash;

        // Models
        public NasabahModel nasabahModel;
        public PinjamanModel pinjamanModel;
        public AngsuranModel angsuranModel;
        public KaryawanModel karyawanModel;
        public KoperasiModel koperasiModel;

        public string role;
        private readonly string connString;

        public MainForm()
        {
            connString = "Host=localhost;Username=postgres;Password=kanokon132;Database=siskop";
            InitializeComponent();

            // Initialize all models
            nasabahModel = new NasabahModel(connString);
            pinjamanModel = new PinjamanModel(connString);
            angsuranModel = new AngsuranModel(connString);
            karyawanModel = new KaryawanModel(connString);
            koperasiModel = new KoperasiModel(connString);

            // Initialize admin views
            adminKaryawan = new AdminKaryawan(this, karyawanModel);
            adminNasabah = new AdminNasabah(this, nasabahModel);
            login = new UcLogin(this, connString);

            // Initialize detail views (will be created when needed)

            // Initialize add/create views
            addNasabah = new AddNasabah(nasabahModel, this);

            // Initialize dashboard/control views
            NasabahDash = new UserControl1(this, nasabahModel);

            // Add all controls to form
            this.Controls.Add(NasabahDash);
            this.Controls.Add(PinjamanDash);
            this.Controls.Add(adminKaryawan);
            this.Controls.Add(adminNasabah);
            this.Controls.Add(login);

            this.Controls.Add(addNasabah);
            this.Controls.Add(addKaryawan);

            // Hide all initially
            HideAllPage();

            // Show default page
            ShowPage(login);
        }

        public void SetRole(string role)
        {
            role = role.ToLower();
        }

        public void HideAllPage()
        {
            foreach (Control control in this.Controls)
            {
                if (control is UserControl || control is Panel) // Only hide UserControls and Panels
                {
                    control.Visible = false;
                }
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

            karyawanDetails = new karyawanDetails(karyawanModel, karyawan);
            this.Controls.Add(karyawanDetails);
            ShowPage(karyawanDetails);
        }

        public void ShowPinjamanForNasabah(Nasabah nasabah)
        {
            if (PinjamanDash != null)
            {
                this.Controls.Remove(PinjamanDash);
                PinjamanDash.Dispose();
            }

            PinjamanDash = new PinjamanControl(this, pinjamanModel, nasabah, angsuranModel, koperasiModel);
            this.Controls.Add(PinjamanDash);
            ShowPage(PinjamanDash);
        }

        public void ShowAddPinjamanForNasabah(Nasabah nasabah)
        {
            try
            {
                // Create a new AddPinjaman instance with the specific nasabah
                var x = new AddPinjaman(this, pinjamanModel, nasabah);
                addPinjaman = x;
                this.Controls.Add(addPinjaman);
                ShowPage(addPinjaman);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Add Pinjaman form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}