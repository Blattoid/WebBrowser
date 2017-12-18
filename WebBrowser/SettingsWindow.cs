using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class SettingsWindow : Form
    {
        public static bool hasSelectedIcon = false;
        public SettingsWindow()
        {
            InitializeComponent();

            //retrieve the current settings to display in the appropriate places
            defaultHomepageInput.Text = Properties.Settings.Default.Homepage;
            useHTTPS.Checked = Properties.Settings.Default.useHTTPS;
            rememberLastPage.Checked = Properties.Settings.Default.RememberLastPage;
            browserNameInput.Text = Properties.Settings.Default.browserName;
        }
        private void SettingsWindow_FormClosing(object sender, CancelEventArgs e)
        {
            //get the url entered
            string homepage = defaultHomepageInput.Text;
            //check if the url entered is valid. if not, throw an error message at them.
            try
            {
                //validate the url given in the homepage specification
                homepage = MainWindow.validateUrl(homepage);

                //if we are able to create a new Uri called uri, then the url specified is valid and we may proceed.
                Uri uri = new Uri(homepage);

                //set the default homepage.
                Properties.Settings.Default.Homepage = homepage;
            }
            catch (Exception err)
            {
                //in the event that the url is invalid, show this error message. 
                MessageBox.Show(Convert.ToString(err));
            }
            //update the RememberLastPage option
            Properties.Settings.Default.RememberLastPage = rememberLastPage.Checked;
            //set the last page to nothing if they have disabled remember last page, to ensure privacy.
            if (!(rememberLastPage.Checked)) { Properties.Settings.Default.LastPage = ""; }
            //update the useHTTPS option
            Properties.Settings.Default.useHTTPS = useHTTPS.Checked;
            //update the browserName setting
            Properties.Settings.Default.browserName = browserNameInput.Text;

            if (hasSelectedIcon) { Properties.Settings.Default.browserIcon = iconSelectDialog.FileName; }
        }

        //when they click the icon select button to choose a custom icon
        private void iconSelectButton_Click(object sender, EventArgs e)
        {
            //reset the hasSelectedIcon as we don't know if they will choose another one. If they don't, it will result in an empty filename and an error when we try to select the file. So, we set it false first.
            hasSelectedIcon = false;
            iconSelectDialog.ShowDialog();
        }

        //if they end up choosing one, set the hasSelectedIcon boolean to true.
        private void iconSelectDialog_FileOk(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Selected icon.");
            //set the hasSelectedIcon to true.
            hasSelectedIcon = true;
        }
    }
}
