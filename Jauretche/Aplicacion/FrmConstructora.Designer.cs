namespace Aplicacion
{
    partial class FrmConstructora
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
            menuStrip1 = new MenuStrip();
            obrerosToolStripMenuItem = new ToolStripMenuItem();
            obrasToolStripMenuItem = new ToolStripMenuItem();
            jefesDeObraToolStripMenuItem = new ToolStripMenuItem();
            lblName = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { obrerosToolStripMenuItem, obrasToolStripMenuItem, jefesDeObraToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // obrerosToolStripMenuItem
            // 
            obrerosToolStripMenuItem.Name = "obrerosToolStripMenuItem";
            obrerosToolStripMenuItem.Size = new Size(61, 20);
            obrerosToolStripMenuItem.Text = "Obreros";
            obrerosToolStripMenuItem.Click += obrerosToolStripMenuItem_Click;
            // 
            // obrasToolStripMenuItem
            // 
            obrasToolStripMenuItem.Name = "obrasToolStripMenuItem";
            obrasToolStripMenuItem.Size = new Size(50, 20);
            obrasToolStripMenuItem.Text = "Obras";
            // 
            // jefesDeObraToolStripMenuItem
            // 
            jefesDeObraToolStripMenuItem.Name = "jefesDeObraToolStripMenuItem";
            jefesDeObraToolStripMenuItem.Size = new Size(90, 20);
            jefesDeObraToolStripMenuItem.Text = "Jefes De Obra";
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.None;
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Historic", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblName.Location = new Point(292, 136);
            lblName.Name = "lblName";
            lblName.Size = new Size(144, 30);
            lblName.TabIndex = 5;
            lblName.Text = "Constructora";
            // 
            // Constructora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblName);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Constructora";
            Text = "Constructora";
            Load += Constructora_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem obrerosToolStripMenuItem;
        private ToolStripMenuItem obrasToolStripMenuItem;
        private ToolStripMenuItem jefesDeObraToolStripMenuItem;
        private Label lblName;
    }
}