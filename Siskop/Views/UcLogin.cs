using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Siskop;

namespace Siskop.Views
{
//    public partial class UcLogin : UserControl
//    {
//        private readonly MainForm _mainForm;

//        public UcLogin(MainForm mainForm, string connstring)
//        {
//            InitializeComponent();
//            _mainForm = mainForm;
//            _authModel = new AuthModel(connstring);
//            ClearTextBox();
//        }

//        private async void btnLogin_Click(object sender, EventArgs e)
//        {
//            string username = tbUsername.Text.Trim();
//            string password = tbPassword.Text;

//            // Validate input fields
//            if (string.IsNullOrWhiteSpace(username) ||
//                string.IsNullOrWhiteSpace(password))
//            {
//                ShowWarning("Username, Password, and Role must be filled!");
//                return;
//            }

//            try
//            {
//                bool loginSuccess = await _authModel.LoginAsync(username, password)
//                    .ConfigureAwait(true);  // Ensure UI thread context

//                if (loginSuccess)
//                {
//                    MessageBox.Show("horeee");
//                    // Role-based navigation (uncomment when ready)
//                    // NavigateBasedOnRole(selectedRole);
//                }
//                else
//                {
//                    ShowWarning("Invalid username or password");
//                }
//            }
//            catch (Exception ex)
//            {
//                ShowError($"Login failed: {ex.Message}");
//            }
//        }


//        // Private helper methods
//        private void ClearTextBox()
//        {
//            tbUsername.Clear();
//            tbPassword.Clear();
//            tbUsername.Focus();  // Improve UX
//        }

//        private void ShowWarning(string message)
//        {
//            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//        }

//        private void ShowError(string message)
//        {
//            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }

//        // Future role-based navigation
//        private void NavigateBasedOnRole(string role)
//        {
//            // if (role == "Penyuplai")
//            //     _mainForm.ShowPage(_mainForm.penyuplaiPage);
//            // else if (role == "Pengepul")
//            //     _mainForm.ShowPage(_mainForm.pengepulPage);
//        }

//        private void panel1_Paint(object sender, PaintEventArgs e)
//        {

//        }

//        private void textBox1_TextChanged(object sender, EventArgs e)
//        {

//        }
//    }
}