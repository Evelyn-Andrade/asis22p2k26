namespace CapaVista_Seguridad
{
    partial class FrmVideo
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
            this.navegadorPrueba = new CapaVista_Navegador.Navegador();
            this.SuspendLayout();
            // 
            // navegadorPrueba
            // 
            this.navegadorPrueba.Location = new System.Drawing.Point(2, 0);
            this.navegadorPrueba.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.navegadorPrueba.Name = "navegadorPrueba";
            this.navegadorPrueba.Size = new System.Drawing.Size(1078, 90);
            this.navegadorPrueba.TabIndex = 0;
            // 
            // FrmVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 450);
            this.Controls.Add(this.navegadorPrueba);
            this.Name = "FrmVideo";
            this.Text = "video";
            this.ResumeLayout(false);

        }

        #endregion

        private CapaVista_Navegador.Navegador navegadorPrueba;
    }
}