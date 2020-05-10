namespace breadCompany
{
    partial class CreateSubsudiary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSubsudiary));
            this.grbCreateFilial = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreateSubMarket = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFlialNAme = new System.Windows.Forms.TextBox();
            this.cmbMarket = new System.Windows.Forms.ComboBox();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.dgvSubsidary = new System.Windows.Forms.DataGridView();
            this.grbCreateFilial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubsidary)).BeginInit();
            this.SuspendLayout();
            // 
            // grbCreateFilial
            // 
            this.grbCreateFilial.Controls.Add(this.btnDelete);
            this.grbCreateFilial.Controls.Add(this.btnEdit);
            this.grbCreateFilial.Controls.Add(this.btnCreateSubMarket);
            this.grbCreateFilial.Controls.Add(this.label2);
            this.grbCreateFilial.Controls.Add(this.label1);
            this.grbCreateFilial.Controls.Add(this.txtFlialNAme);
            this.grbCreateFilial.Controls.Add(this.cmbMarket);
            this.grbCreateFilial.Location = new System.Drawing.Point(12, 12);
            this.grbCreateFilial.Name = "grbCreateFilial";
            this.grbCreateFilial.Size = new System.Drawing.Size(508, 109);
            this.grbCreateFilial.TabIndex = 0;
            this.grbCreateFilial.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(425, 64);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(77, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(328, 64);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(77, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Redaktə Et";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreateSubMarket
            // 
            this.btnCreateSubMarket.Location = new System.Drawing.Point(328, 64);
            this.btnCreateSubMarket.Name = "btnCreateSubMarket";
            this.btnCreateSubMarket.Size = new System.Drawing.Size(77, 23);
            this.btnCreateSubMarket.TabIndex = 4;
            this.btnCreateSubMarket.Text = "Yarat";
            this.btnCreateSubMarket.UseVisualStyleBackColor = true;
            this.btnCreateSubMarket.Click += new System.EventHandler(this.btnCreateSubMarket_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(173, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filialın adın daxil et";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Market Seç :";
            // 
            // txtFlialNAme
            // 
            this.txtFlialNAme.Location = new System.Drawing.Point(153, 67);
            this.txtFlialNAme.Name = "txtFlialNAme";
            this.txtFlialNAme.Size = new System.Drawing.Size(135, 20);
            this.txtFlialNAme.TabIndex = 1;
            // 
            // cmbMarket
            // 
            this.cmbMarket.DisplayMember = "Text";
            this.cmbMarket.FormattingEnabled = true;
            this.cmbMarket.Location = new System.Drawing.Point(16, 66);
            this.cmbMarket.Name = "cmbMarket";
            this.cmbMarket.Size = new System.Drawing.Size(121, 21);
            this.cmbMarket.TabIndex = 0;
            this.cmbMarket.ValueMember = "Value";
            this.cmbMarket.SelectedIndexChanged += new System.EventHandler(this.cmbMarket_SelectedIndexChanged);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // dgvSubsidary
            // 
            this.dgvSubsidary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubsidary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubsidary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSubsidary.Location = new System.Drawing.Point(0, 213);
            this.dgvSubsidary.Name = "dgvSubsidary";
            this.dgvSubsidary.Size = new System.Drawing.Size(547, 199);
            this.dgvSubsidary.TabIndex = 1;
            this.dgvSubsidary.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSubsidary_RowHeaderMouseClick);
            // 
            // CreateSubsudiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 412);
            this.Controls.Add(this.dgvSubsidary);
            this.Controls.Add(this.grbCreateFilial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateSubsudiary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filial Yarat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateSubsudiary_FormClosing);
            this.Load += new System.EventHandler(this.CreateSubsudiary_Load);
            this.Click += new System.EventHandler(this.CreateSubsudiary_Click);
            this.grbCreateFilial.ResumeLayout(false);
            this.grbCreateFilial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubsidary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCreateFilial;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFlialNAme;
        private System.Windows.Forms.ComboBox cmbMarket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateSubMarket;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dgvSubsidary;
    }
}