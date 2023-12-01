namespace Aplicacion
{
    partial class FrmObreros
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
            DGVObreros = new DataGridView();
            btnAgregarObrero = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVObreros).BeginInit();
            SuspendLayout();
            // 
            // DGVObreros
            // 
            DGVObreros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVObreros.Location = new Point(12, 12);
            DGVObreros.Name = "DGVObreros";
            DGVObreros.RowTemplate.Height = 25;
            DGVObreros.Size = new Size(378, 273);
            DGVObreros.TabIndex = 0;
            // 
            // btnAgregarObrero
            // 
            btnAgregarObrero.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnAgregarObrero.Location = new Point(12, 301);
            btnAgregarObrero.Name = "btnAgregarObrero";
            btnAgregarObrero.Size = new Size(81, 33);
            btnAgregarObrero.TabIndex = 1;
            btnAgregarObrero.Text = "Agregar";
            btnAgregarObrero.UseVisualStyleBackColor = true;
            // 
            // Obreros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 374);
            Controls.Add(btnAgregarObrero);
            Controls.Add(DGVObreros);
            Name = "Obreros";
            Text = "Obreros";
            Load += Obreros_Load;
            ((System.ComponentModel.ISupportInitialize)DGVObreros).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVObreros;
        private Button btnAgregarObrero;
    }
}