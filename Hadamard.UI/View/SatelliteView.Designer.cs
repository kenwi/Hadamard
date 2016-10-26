namespace Hadamard.UI.View
{
    partial class SatelliteView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddSatellite = new System.Windows.Forms.Button();
            this.txtSatelliteId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(691, 217);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAddSatellite
            // 
            this.btnAddSatellite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSatellite.Location = new System.Drawing.Point(114, 231);
            this.btnAddSatellite.Name = "btnAddSatellite";
            this.btnAddSatellite.Size = new System.Drawing.Size(75, 23);
            this.btnAddSatellite.TabIndex = 1;
            this.btnAddSatellite.Text = "Add";
            this.btnAddSatellite.UseVisualStyleBackColor = true;
            // 
            // txtSatelliteId
            // 
            this.txtSatelliteId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSatelliteId.Location = new System.Drawing.Point(8, 233);
            this.txtSatelliteId.Name = "txtSatelliteId";
            this.txtSatelliteId.Size = new System.Drawing.Size(100, 20);
            this.txtSatelliteId.TabIndex = 2;
            // 
            // SatelliteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 261);
            this.Controls.Add(this.txtSatelliteId);
            this.Controls.Add(this.btnAddSatellite);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SatelliteView";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "SatelliteView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddSatellite;
        private System.Windows.Forms.TextBox txtSatelliteId;
    }
}