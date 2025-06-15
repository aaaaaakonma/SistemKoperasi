using System.Net;
using Models;
using Siskop.Views;
using Siskop;
using Siskop.Views;

namespace Siskop
{
    public partial class MainForm : Form
    {
        private readonly string connString;
        public AddNasabah addNasabah;
        public UcLogin loginPage;
        public UserControl1 NasabahDash;
        public PinjamanControl PinjamanDash;
        public NasabahModel nasabahModel;
        public PinjamanModel pinjamanModel;

        public MainForm()
        {
            connString = "Host=localhost;Username=postgres;Password=kanokon132;Database=siskop";
            InitializeComponent();

            // Initialize models once
            nasabahModel = new NasabahModel(connString);
            pinjamanModel = new PinjamanModel(connString);

            // Pass models to UserControls
            loginPage = new UcLogin(this, connString);
            NasabahDash = new UserControl1(this, nasabahModel);

            // Don't initialize PinjamanDash here since we need nasabahId
            // It will be created when needed with ShowPinjamanForNasabah method

            this.Controls.Add(loginPage);
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

        // Method to show pinjaman for a specific nasabah
        public void ShowPinjamanForNasabah(int nasabahId)
        {
            // Remove existing PinjamanDash if it exists
            if (PinjamanDash != null)
            {
                this.Controls.Remove(PinjamanDash);
                PinjamanDash.Dispose();
            }

            // Create new PinjamanControl for specific nasabah, passing the shared model
            PinjamanDash = new PinjamanControl(this, pinjamanModel, nasabahId);
            this.Controls.Add(PinjamanDash);

            // Show the pinjaman page
            ShowPage(PinjamanDash);
        }

        // Method to go back to nasabah dashboard
        public void ShowNasabahDashboard()
        {
            ShowPage(NasabahDash);
        }

        // Method to show login page
        public void ShowLoginPage()
        {
            ShowPage(loginPage);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}