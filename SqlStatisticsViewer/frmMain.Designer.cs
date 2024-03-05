namespace SqlStatisticsViewer
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            lblCaption = new Label();
            statisticsView = new TFormsLib.FormControls.VirtualList();
            btnParse = new Button();
            txtInput = new TextBox();
            btnClear = new Button();
            splitContainer1 = new SplitContainer();
            numThreshold = new NumericUpDown();
            lblThreshold = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numThreshold).BeginInit();
            SuspendLayout();
            // 
            // lblCaption
            // 
            lblCaption.AutoSize = true;
            lblCaption.Location = new Point(12, 9);
            lblCaption.Name = "lblCaption";
            lblCaption.Size = new Size(85, 25);
            lblCaption.TabIndex = 0;
            lblCaption.Text = "#Caption";
            // 
            // statisticsView
            // 
            statisticsView.AllowColumnSort = false;
            statisticsView.AlternateRowColor = Color.FromArgb(80, 80, 80);
            statisticsView.AlternateRowColors = true;
            statisticsView.AutoSizeColumns = false;
            statisticsView.BackColor = Color.FromArgb(60, 60, 60);
            statisticsView.Dock = DockStyle.Fill;
            statisticsView.ForeColor = Color.White;
            statisticsView.FullRowSelect = true;
            statisticsView.GridLines = true;
            statisticsView.Items = (List<ListViewItem>)resources.GetObject("statisticsView.Items");
            statisticsView.LabelWrap = false;
            statisticsView.Location = new Point(0, 0);
            statisticsView.Name = "statisticsView";
            statisticsView.OwnerDraw = true;
            statisticsView.ShowAlphaNumericDates = false;
            statisticsView.ShowNullsInResults = false;
            statisticsView.ShowTimeIfDate = false;
            statisticsView.Size = new Size(978, 318);
            statisticsView.TabIndex = 2;
            statisticsView.UseCompatibleStateImageBehavior = false;
            statisticsView.View = View.Details;
            statisticsView.VirtualMode = true;
            // 
            // btnParse
            // 
            btnParse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnParse.Location = new Point(848, 4);
            btnParse.Name = "btnParse";
            btnParse.Size = new Size(142, 34);
            btnParse.TabIndex = 3;
            btnParse.Text = "Parse";
            btnParse.UseVisualStyleBackColor = true;
            btnParse.Click += btnParse_Click;
            // 
            // txtInput
            // 
            txtInput.Dock = DockStyle.Fill;
            txtInput.Location = new Point(0, 0);
            txtInput.MaxLength = 80000;
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Both;
            txtInput.Size = new Size(978, 328);
            txtInput.TabIndex = 4;
            txtInput.WordWrap = false;
            txtInput.TextChanged += txtInput_TextChanged;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(700, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(142, 34);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 44);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtInput);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(statisticsView);
            splitContainer1.Size = new Size(978, 656);
            splitContainer1.SplitterDistance = 328;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 6;
            // 
            // numThreshold
            // 
            numThreshold.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numThreshold.Location = new Point(602, 7);
            numThreshold.Name = "numThreshold";
            numThreshold.Size = new Size(92, 31);
            numThreshold.TabIndex = 7;
            numThreshold.ValueChanged += numThreshold_ValueChanged;
            // 
            // lblThreshold
            // 
            lblThreshold.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblThreshold.AutoSize = true;
            lblThreshold.Location = new Point(506, 9);
            lblThreshold.Name = "lblThreshold";
            lblThreshold.Size = new Size(94, 25);
            lblThreshold.TabIndex = 8;
            lblThreshold.Text = "Threshold:";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 712);
            Controls.Add(lblThreshold);
            Controls.Add(numThreshold);
            Controls.Add(splitContainer1);
            Controls.Add(btnClear);
            Controls.Add(btnParse);
            Controls.Add(lblCaption);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1024, 768);
            Name = "frmMain";
            Text = "SQL Statistics Viewer";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numThreshold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCaption;
        private TFormsLib.FormControls.VirtualList statisticsView;
        private Button btnParse;
        private TextBox txtInput;
        private Button btnClear;
        private SplitContainer splitContainer1;
        private NumericUpDown numThreshold;
        private Label lblThreshold;
    }
}
