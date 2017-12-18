using System;
using System.Drawing;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class MainWindow : Form
    {
        public static string defaultAppName = "WebView";
        public static string statusIndicatorPrefix = "Status: ";
        public static string[] supportedProtocols = { "http://", "https://", "ftp://", "file:///" }; //protocols supported by the webBrowser. used by validateUrl
        public static string validateUrl(string url)
        {
            //check if the url begins with a protocol specification. If not, silently add one. we need the protocol specification for the webBrowser to load the page.
            bool hasValidProtocol = false; //keep it false until it finds a protocol specification, if any.
            foreach (string protocol in supportedProtocols)
            {
                //check the url against each protocol to see if it is supported.
                if (url.StartsWith(protocol) && !(hasValidProtocol)) { hasValidProtocol = true; }
            }
            //if the url does not have a protocol, add https or http to the beginning. more often than not, they want to access websites, not some obscure service like ftp.
            if (!hasValidProtocol)
            {
                //depending on the useHTTPS setting, use either https:// or http://
                if (Properties.Settings.Default.useHTTPS) { url = "https://" + url; }
                else { url = "http://" + url; }
            }
            return url;
        }

        public MainWindow()
        {
            InitializeComponent();

            //set the MainWindow title text to the browserName setting
            Text = Properties.Settings.Default.browserName;
            //attempt to load the icon that was previously set, if any.
            try { if (Properties.Settings.Default.browserIcon != "none") { Icon = new Icon(Properties.Settings.Default.browserIcon); } }
            catch (Exception)
            {
                MessageBox.Show("ERROR: Could not find the file\n'" + Properties.Settings.Default.browserIcon + "'. The link to the file has now been removed. You may define a new one in Settings if you wish.");
                Properties.Settings.Default.browserIcon = "none"; //clear browser icon setting, as the file no longer exists as far as we are concerned.
                Properties.Settings.Default.Save(); //save the change we just made to the settings file.
            }

            //supresses javascript errors, which usually pops up a big obnoxious dialog box asking if you want to continue execution of the script.
            webBrowser.ScriptErrorsSuppressed = true;

            if (Properties.Settings.Default.RememberLastPage)
            {
                updateStatus("Loading...");
                //the user has chosen in the settings to remember the last page they visted, so we don't load the homepage, but rather the last page they visited.
                webBrowser.Navigate(Properties.Settings.Default.LastPage);
            }
            else
            {
                updateStatus("Loading...");
                //get the user's homepage preference and load it.
                webBrowser.Navigate(Properties.Settings.Default.Homepage);
            }
        }

        //if you press enter while in the textbox instead of mousing over to the button and clicking it, this does the same thing.
        private void URLBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                loadPage(); //execute the loadPage void to tell the webBrowser to load the page. Duh.

                //supress the ding sound caused by trying to put an enter in a single line textbox.
                e.SuppressKeyPress = true;

            }
        }

        //When the GO button is pressed load the page
        private void goButton_Click(object sender, EventArgs e) { loadPage(); }

        //function for loading the page
        void loadPage()
        {
            updateStatus("Loading...");
            try
            {
                string url = URLBar.Text;
                if (url == "") { return; } //if the urlbar is empty, return nothing, stopping the void.
                Text = Properties.Settings.Default.browserName + " - " + url; //set the application title Text to include the url.

                //validate the url and make it suitable for the webBrowser.
                url = validateUrl(url);

                //set the Url property of the webBrowser element. it then detects the change and loads the page.
                Uri uri = new Uri(url);
                webBrowser.Url = uri;
            }
            catch (Exception err)
            {
                //in the event that the url is invalid, 
                MessageBox.Show(Convert.ToString(err));
            }
        }

        //executed when the webBrowser navigates to a different address
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            updateStatus("Loading...");
            string url = Convert.ToString(webBrowser.Url);
            //update the LastPage setting, if enabled.
            if (Properties.Settings.Default.RememberLastPage)
            {
                //check if the url is about:blank. if so, do not update the last page visited.
                if (!(url == "about:blank"))
                {
                    Properties.Settings.Default.LastPage = url;
                }
            }

            //update the URL bar
            URLBar.Text = url;
        }

        //simply calls the webBrowser's refresh function, along with updating the status indicator.
        private void refreshButton_Click(object sender, EventArgs e) {
            updateStatus("Refreshing...");
            webBrowser.Refresh();
        }

        //when the forward or back buttons are pressed, check if the webBrowser can actually go back or forth. If so, do it.
        private void backButton_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack)
            {
                updateStatus("Going back...");
                webBrowser.GoBack();
            }
        }
        private void forwardButton_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward)
            {
                updateStatus("Going forward...");
                webBrowser.GoForward();
            }
        }

        //when the settings button is pressed...
        private void settingsButton_Click(object sender, EventArgs e)
        {
            updateStatus("In Settings...");
            SettingsWindow settingsDialog = new SettingsWindow();
            // Show testDialog as a modal dialog
            settingsDialog.ShowDialog(this);

            //now the user has updated their settings, save the changes
            Properties.Settings.Default.Save();

            //update the MainWindow title text to the browserName setting
            Text = Properties.Settings.Default.browserName;

            //attempt to set the program icon if one was selected.
            if (SettingsWindow.hasSelectedIcon)
            {
                try
                {
                    SettingsWindow.hasSelectedIcon = false; //reset the boolean to prevent false triggers which leads to errors.
                    Icon = new Icon(Properties.Settings.Default.browserIcon);
                }
                catch (Exception err) { MessageBox.Show(Convert.ToString(err)); }
            }
            updateStatus("Idle");
        }

        //simply makes the webBrowser navigate to the homepage defined in the settings.
        private void homeButton_Click(object sender, EventArgs e) {
            updateStatus("Going home...");
            webBrowser.Navigate(Properties.Settings.Default.Homepage);
        }

        //when the document is finished loading, update the status.
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e){ updateStatus("Idle"); }
        //purely for saving me some typing.
        private void updateStatus(string status) { statusIndicator.Text = statusIndicatorPrefix + status; }
    }
}