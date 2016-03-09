using System;
using System.Windows.Forms;

namespace CSharpWebBrowser
{
    public partial class CSBrowser : Form
    {
        public CSBrowser()
        {
            InitializeComponent();
        }


        private void toolstripExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolstripAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Andy Pillay");
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
           NavigateToPage();
        }

        private void txtAddressBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage();
            }    
        }

        /// <summary>
        /// Navigates to Page in addressbar.
        /// Disables Go button and Address bar once Navigation is done.
        /// </summary>
        private void NavigateToPage()
        {
            btnGo.Enabled = false;
            txtAddressBar.Enabled = false;
            toolStripStatusLabel1.Text = "Navigating to " + txtAddressBar.Text;
            
        
            webBrowser.Navigate(txtAddressBar.Text);
        }

        /// <summary>
        /// Re-Enables Go and Address bar so new Page can be navigated once Document Completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnGo.Enabled = true;
            txtAddressBar.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation Complete";
        }

        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            //Stops divide by zero error
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }           
        }
    }
}
