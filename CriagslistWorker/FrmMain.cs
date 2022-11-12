using CriagslistWorker.Models;
using OpenQA.Selenium;
using System.ComponentModel;
using System.Diagnostics;

namespace CriagslistWorker;

public partial class FrmMain : Form
{
    readonly BackgroundWorker _worker;

    public FrmMain()
    {
        InitializeComponent();

        _worker = new BackgroundWorker();
        _worker.WorkerSupportsCancellation = true;
        _worker.DoWork += Worker_DoWork;
        _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
    }

    private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        SeleniumHelper.Instance.Dispose();

        btnHarvest.Enabled = true;
        btnCancel.Enabled = false;
    }

    void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        if (_worker.CancellationPending)
        {
            e.Cancel = true;
            return;
        }

        var helper = SeleniumHelper.Instance;
        helper.IsConsoleHidden = chkHideConsole.Checked;
        helper.IsBrowserHidden = chkHideBrowser.Checked;
        helper.IsTorNetwork = chkUseTor.Checked;

        helper.Navigate("https://seattle.craigslist.org/search/acc");

        if (_worker.CancellationPending)
        {
            e.Cancel = true;
            return;
        }

        var linkUrls = new List<string>();

        if (!helper.IsElementVisible("//div[contains(@class, 'results')]/ol"))
            return;

        var links = helper.FindElements("//div[contains(@class, 'results')]/ol/li[contains(@class, 'cl-search-result')]/a[@class = 'post-title']");
        foreach (var link in links)
        {
            var href = link.GetAttribute("href");
            linkUrls.Add(href);
        }

        foreach (var linkUrl in linkUrls)
        {
            if (_worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            helper.Navigate(linkUrl);

            var h1 = helper.FindElement("//h1[@class = 'postingtitle']/span[@class = 'postingtitletext']");
            if (h1 == null)
                continue;

            var listing = new Listing
            {
                Url = linkUrl,
                Title = h1.FindElement(By.Id("titletextonly")).Text,
            };

            try
            {
                listing.Location = h1
                    .FindElement(By.TagName("small"))
                    .Text
                    .Trim()
                    .TrimStart('(')
                    .TrimEnd(')');
            }
            catch (NoSuchElementException) { }

            if (helper.IsElementVisible("//div[@class = 'reply-button-row']/div[@class = 'actions-combo']/button[@class = 'reply-button js-only']", 2))
            {
                helper
                    .FindElement("//div[@class = 'reply-button-row']/div[@class = 'actions-combo']/button[@class = 'reply-button js-only']")?
                    .Click();

                if (helper.IsElementVisible("//div[@class = 'reply-button-row']/div[@class = 'actions-combo']/div[@class = 'reply-info js-only']/aside/ul/button", 10))
                {
                    helper
                        .FindElement("//div[@class = 'reply-button-row']/div[@class = 'actions-combo']/div[@class = 'reply-info js-only']/aside/ul/button")
                        .Click();

                    if (helper.IsElementVisible("//div[@class = 'reply-button-row']/div[@class = 'actions-combo']/div[@class = 'reply-info js-only']/aside/ul/li/input[@type = 'text' and @class = 'anonemail']", 10))
                        listing.Email = helper
                            .FindElement("//div[@class = 'reply-button-row']/div[@class = 'actions-combo']/div[@class = 'reply-info js-only']/aside/ul/li/input[@type = 'text' and @class = 'anonemail']")
                            .GetAttribute("value");
                }

            }

            var index = 0;
            dgvListings.BeginInvoke(() =>
            {
                index = dgvListings.Rows.Add();

                var row = dgvListings.Rows[index];
                row.Tag = listing;
                row.Cells[0].Value = listing.Title;
                row.Cells[1].Value = listing.Location;
                row.Cells[2].Value = listing.Email;
                row.Cells[3].Value = listing.Url;
                dgvListings.Refresh();
            }
            );

            lblListings.BeginInvoke(() =>
            {
                lblListings.Text = $"Listings Extracted: {index + 1}";
                lblListings.Refresh();
            });
        }
    }

    void btnHarvest_Click(object sender, EventArgs e)
    {
        if (chkUseTor.Checked)
        {
            var tors = Process.GetProcessesByName("tor");
            if (tors.Length == 0)
            {
                MessageBox.Show("Please launch TOR browser and connect to the TOR network.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        btnHarvest.Enabled = false;
        btnCancel.Enabled = true;

        dgvListings.Rows.Clear();
        lblListings.Text = "Listings Extarcted: 0";

        _worker.RunWorkerAsync();
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
        _worker.CancelAsync();
    }

    void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        SeleniumHelper.Instance.Dispose();
        _worker.Dispose();
    }
}