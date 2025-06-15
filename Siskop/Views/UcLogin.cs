using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Siskop;

namespace Siskop.Views
{
    public partial class UcLogin : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly AuthModel _authModel;

        public UcLogin(MainForm mainForm, string connstring)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _authModel = new AuthModel(connstring);
            ClearTextBox();
            SetupPasswordField();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text;

            // Validate input fields
            if (string.IsNullOrWhiteSpace(username))
            {
                ShowWarning("Username harus diisi!");
                tbUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowWarning("Password harus diisi!");
                tbPassword.Focus();
                return;
            }

            // Disable login button to prevent multiple clicks
            btnLogin.Enabled = false;

            try
            {
                var result = await _authModel.LoginAsync(username, password);

                if (result.IsSuccess)
                {
                    // Successful login
                    ShowSuccess($"Selamat datang, {result.User.Nama_Karyawan}!");

                    // Clear form
                    ClearTextBox();

                    // Navigate based on role
                    NavigateBasedOnRole(result.User.Role);
                }
                else
                {
                    // Login failed
                    ShowWarning(result.Message);
                    tbPassword.Clear();
                    tbUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Terjadi kesalahan saat login: {ex.Message}");
            }
            finally
            {
                // Re-enable login button
                btnLogin.Enabled = true;
            }
        }

        private void NavigateBasedOnRole(string role)
        {
            try
            {
                switch (role.ToLower())
                {
                    case "admin":
                        //_mainForm.ShowPage();
                        break;
                    case "karyawan":
                        _mainForm.ShowPage(_mainForm.NasabahDash);
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError($"Terjadi kesalahan saat membuka dashboard: {ex.Message}");
            }
        }

        private void SetupPasswordField()
        {
            // Make password field secure
            tbPassword.UseSystemPasswordChar = true;

            // Add Enter key support for both fields
            tbUsername.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    tbPassword.Focus();
                }
            };

            tbPassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    btnLogin_Click(btnLogin, EventArgs.Empty);
                }
            };
        }

        // Public method to get AuthModel instance (for MainForm to use)
        public AuthModel GetAuthModel()
        {
            return _authModel;
        }

        // Private helper methods
        private void ClearTextBox()
        {
            tbUsername.Clear();
            tbPassword.Clear();
            tbUsername.Focus();
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Event handlers for UI
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // UI paint event - keep as is
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Text changed event - keep as is
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

// Extension methods for MainForm (add these methods to your MainForm class)
public static class MainFormExtensions
{
    // These are placeholder method signatures that should be implemented in MainForm
    /*
    public void SetCurrentUser(Karyawan user)
    {
        // Store current user in MainForm
        CurrentUser = user;
        
        // Update UI elements to show current user info
        UpdateUserInfo();
    }

    public void ShowAdminDashboard()
    {
        // Navigate to admin dashboard
        ShowPage(adminDashboardPage);
    }

    public void ShowKasirDashboard()
    {
        // Navigate to kasir dashboard
        ShowPage(kasirDashboardPage);
    }

    public void ShowManagerDashboard()
    {
        // Navigate to manager dashboard
        ShowPage(managerDashboardPage);
    }

    public void ShowStaffDashboard()
    {
        // Navigate to staff dashboard
        ShowPage(staffDashboardPage);
    }

    public void ShowDefaultDashboard()
    {
        // Navigate to default dashboard
        ShowPage(defaultDashboardPage);
    }
    */
}