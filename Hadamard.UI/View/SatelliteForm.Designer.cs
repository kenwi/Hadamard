namespace Hadamard.UI.View
{
    partial class SatelliteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox groupBox1;
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.noradIdTextBox = new System.Windows.Forms.TextBox();
            this.longtitudeTextBox = new System.Windows.Forms.TextBox();
            this.latitudeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.elevationTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.satelliteListBox = new System.Windows.Forms.ListBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.tableLayoutPanel2);
            groupBox1.Controls.Add(this.button1);
            groupBox1.Controls.Add(this.addButton);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(224, 2);
            groupBox1.Margin = new System.Windows.Forms.Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(2);
            groupBox1.Size = new System.Drawing.Size(335, 257);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Satellite  info";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.noradIdTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.longtitudeTextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.latitudeTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.elevationTextBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(250, 103);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(331, 103);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "NORAD ID:";
            // 
            // noradIdTextBox
            // 
            this.noradIdTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noradIdTextBox.Location = new System.Drawing.Point(73, 2);
            this.noradIdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.noradIdTextBox.Name = "noradIdTextBox";
            this.noradIdTextBox.Size = new System.Drawing.Size(256, 20);
            this.noradIdTextBox.TabIndex = 3;
            this.noradIdTextBox.Text = "25338";
            // 
            // longtitudeTextBox
            // 
            this.longtitudeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.longtitudeTextBox.Location = new System.Drawing.Point(73, 52);
            this.longtitudeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.longtitudeTextBox.Name = "longtitudeTextBox";
            this.longtitudeTextBox.ReadOnly = true;
            this.longtitudeTextBox.Size = new System.Drawing.Size(256, 20);
            this.longtitudeTextBox.TabIndex = 5;
            // 
            // latitudeTextBox
            // 
            this.latitudeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.latitudeTextBox.Location = new System.Drawing.Point(73, 27);
            this.latitudeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.latitudeTextBox.Name = "latitudeTextBox";
            this.latitudeTextBox.ReadOnly = true;
            this.latitudeTextBox.Size = new System.Drawing.Size(256, 20);
            this.latitudeTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Longtitude:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Latitude:";
            // 
            // elevationTextBox
            // 
            this.elevationTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elevationTextBox.Location = new System.Drawing.Point(73, 77);
            this.elevationTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.elevationTextBox.Name = "elevationTextBox";
            this.elevationTextBox.ReadOnly = true;
            this.elevationTextBox.Size = new System.Drawing.Size(256, 20);
            this.elevationTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Elevation:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(210, 233);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 6;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(270, 233);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(56, 19);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.satelliteListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 261);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // satelliteListBox
            // 
            this.satelliteListBox.DisplayMember = "Id";
            this.satelliteListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.satelliteListBox.FormattingEnabled = true;
            this.satelliteListBox.Location = new System.Drawing.Point(2, 2);
            this.satelliteListBox.Margin = new System.Windows.Forms.Padding(2);
            this.satelliteListBox.Name = "satelliteListBox";
            this.satelliteListBox.Size = new System.Drawing.Size(218, 257);
            this.satelliteListBox.TabIndex = 0;
            this.satelliteListBox.SelectedIndexChanged += new System.EventHandler(this.satelliteListBox_SelectedIndexChanged);
            // 
            // SatelliteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SatelliteForm";
            this.Text = "SatelliteForm";
            groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox satelliteListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox noradIdTextBox;
        private System.Windows.Forms.TextBox longtitudeTextBox;
        private System.Windows.Forms.TextBox latitudeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox elevationTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}