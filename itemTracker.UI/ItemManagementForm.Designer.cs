namespace itemTracker.UI
{
    partial class ItemManagementForm
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
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbUnits = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.picItemImage = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(544, 48);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(117, 26);
            this.txtItemName.TabIndex = 0;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(421, 48);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(117, 26);
            this.txtSize.TabIndex = 1;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(298, 48);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(117, 26);
            this.txtType.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(175, 48);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(117, 26);
            this.txtDescription.TabIndex = 3;
            // 
            // cmbUnits
            // 
            this.cmbUnits.FormattingEnabled = true;
            this.cmbUnits.Location = new System.Drawing.Point(48, 46);
            this.cmbUnits.Name = "cmbUnits";
            this.cmbUnits.Size = new System.Drawing.Size(121, 28);
            this.cmbUnits.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SpringGreen;
            this.btnSave.Location = new System.Drawing.Point(671, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(12, 128);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 62;
            this.dgvItems.RowTemplate.Height = 28;
            this.dgvItems.Size = new System.Drawing.Size(649, 296);
            this.dgvItems.TabIndex = 6;
            this.dgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            // 
            // picItemImage
            // 
            this.picItemImage.Location = new System.Drawing.Point(676, 35);
            this.picItemImage.Name = "picItemImage";
            this.picItemImage.Size = new System.Drawing.Size(100, 50);
            this.picItemImage.TabIndex = 7;
            this.picItemImage.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Location = new System.Drawing.Point(676, 114);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(116, 51);
            this.btnUploadImage.TabIndex = 8;
            this.btnUploadImage.Text = "UploadImage";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // ItemManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.picItemImage);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbUnits);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtItemName);
            this.Name = "ItemManagementForm";
            this.Text = "ItemManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItemImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbUnits;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.PictureBox picItemImage;
        private System.Windows.Forms.Button btnUploadImage;
    }
}