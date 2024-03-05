using TFormsLib.LocalRegistry;

namespace SqlStatisticsViewer
{
    public partial class frmMain : Form
    {
        private List<ListViewItem>? _cacheItems;
        private bool _darkMode;

        public frmMain()
        {
            InitializeComponent();
            LoadForm();
        }
        private void LoadForm()
        {
            lblCaption.Text = "Paste SQL statistics into the text box, click Parse for results.";
            _cacheItems = new List<ListViewItem>();
            _darkMode = HKey_User.DetectWindowsDarkMode();
            DoubleBuffered = true;
            statisticsView.AutoSize = true; // Seems to work although not picked up by intellisense ???
            statisticsView.FullRowSelect = true;
            statisticsView.AllowColumnSort = true;
            statisticsView.AlternateRowColors = true;
            numThreshold.Minimum = 0;
            numThreshold.Maximum = 10000;
            numThreshold.Value = 120;

            if (_darkMode)
            {
                BackColor = SystemColors.ControlDarkDark;
                ForeColor = Color.White;

                btnClear.BackColor = SystemColors.ControlDark;
                btnClear.ForeColor = SystemColors.ControlText;
                btnParse.BackColor = SystemColors.ControlDark;
                btnParse.ForeColor = SystemColors.ControlText;

                txtInput.BackColor = Color.FromArgb(60, 60, 60);
                txtInput.ForeColor = Color.White;
            }

            ResetControls(true);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = string.Empty;
            statisticsView.ClearAll();
            _cacheItems?.Clear();
            ResetControls(false);
        }
        private void btnParse_Click(object sender, EventArgs e)
        {
            ShowResults();
            ResetControls(true);
        }
        private void numThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (_cacheItems?.Count >= 0)
                ShowResults(numThreshold.Value);
        }
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            ResetControls(false);
        }

        private void ResetControls(bool enabled = true)
        {
            btnParse.Enabled = !enabled;
        }
        private void ShowResults(decimal threshold = 120)
        {
            statisticsView.ClearAll();
            _cacheItems?.Clear();

            var stats = new StatisticsParser();
            var results = stats.ParseInput(txtInput.Text, threshold);

            if (results.Count > 0)
            {
                statisticsView.AddColumns(new string[]
                {
                    "Line",
                    "Table",
                    "Scan Count",
                    "Logical Reads",
                    "Phyiscal Reads",
                    "Page Server Reads",
                    "Read-Ahead Reads",
                    "Page Server Read-Ahead Reads",
                    "Lob Logical Reads",
                    "Lob Page Server Reads",
                    "Lob Read-Ahead Reads",
                    "Lob Page Server Read-Ahead Reads"
                });

                foreach (var item in results)
                {
                    var lvi = new ListViewItem()
                    {
                        Text = item.Line.ToString()
                    };
                    lvi.SubItems.Add(item.Table);
                    lvi.SubItems.Add(item.ScanCount.ToString());
                    lvi.SubItems.Add(item.LogicialReads.ToString());
                    lvi.SubItems.Add(item.PhysicalReads.ToString());
                    lvi.SubItems.Add(item.PageServerReads.ToString());
                    lvi.SubItems.Add(item.ReadAheadReads.ToString());
                    lvi.SubItems.Add(item.PageServerReadAheadReads.ToString());
                    lvi.SubItems.Add(item.LobLogicalReads.ToString());
                    lvi.SubItems.Add(item.LobPhysicalReads.ToString());
                    lvi.SubItems.Add(item.LobPageServerReads.ToString());
                    lvi.SubItems.Add(item.LobReadAheadReads.ToString());
                    lvi.SubItems.Add(item.LobPageServerReadAheadReads.ToString());
                    _cacheItems?.Add(lvi);
                }

                statisticsView.Items = _cacheItems?.ToList() ?? [];

                statisticsView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                statisticsView.Refresh();
            }
            stats = null;
        }
    }
}
