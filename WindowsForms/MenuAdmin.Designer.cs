namespace WindowsForms
{
    partial class MenuAdmin
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
            tituloMenuAdmin = new Label();
            btnVerComplejos = new Button();
            complejoTitulo = new Label();
            duenoTitulo = new Label();
            btnVerDuenos = new Button();
            btnCerrarSesion = new Button();
            btnRanking = new Button();
            SuspendLayout();
            // 
            // tituloMenuAdmin
            // 
            tituloMenuAdmin.AutoSize = true;
            tituloMenuAdmin.Font = new Font("Segoe UI", 15F);
            tituloMenuAdmin.Location = new Point(113, 24);
            tituloMenuAdmin.Name = "tituloMenuAdmin";
            tituloMenuAdmin.Size = new Size(158, 35);
            tituloMenuAdmin.TabIndex = 0;
            tituloMenuAdmin.Text = "Menu Admin";
            // 
            // btnVerComplejos
            // 
            btnVerComplejos.Location = new Point(29, 164);
            btnVerComplejos.Margin = new Padding(3, 4, 3, 4);
            btnVerComplejos.Name = "btnVerComplejos";
            btnVerComplejos.Size = new Size(131, 47);
            btnVerComplejos.TabIndex = 1;
            btnVerComplejos.Text = "Ver Complejos";
            btnVerComplejos.UseVisualStyleBackColor = true;
            btnVerComplejos.Click += btnVerComplejos_Click;
            // 
            // complejoTitulo
            // 
            complejoTitulo.AutoSize = true;
            complejoTitulo.Font = new Font("Segoe UI", 15F);
            complejoTitulo.Location = new Point(39, 91);
            complejoTitulo.Name = "complejoTitulo";
            complejoTitulo.Size = new Size(122, 35);
            complejoTitulo.TabIndex = 2;
            complejoTitulo.Text = "Complejo";
            // 
            // duenoTitulo
            // 
            duenoTitulo.AutoSize = true;
            duenoTitulo.Font = new Font("Segoe UI", 15F);
            duenoTitulo.Location = new Point(235, 91);
            duenoTitulo.Name = "duenoTitulo";
            duenoTitulo.Size = new Size(89, 35);
            duenoTitulo.TabIndex = 5;
            duenoTitulo.Text = "Dueño";
            // 
            // btnVerDuenos
            // 
            btnVerDuenos.Location = new Point(210, 164);
            btnVerDuenos.Margin = new Padding(3, 4, 3, 4);
            btnVerDuenos.Name = "btnVerDuenos";
            btnVerDuenos.Size = new Size(131, 47);
            btnVerDuenos.TabIndex = 4;
            btnVerDuenos.Text = "Ver Dueños";
            btnVerDuenos.UseVisualStyleBackColor = true;
            btnVerDuenos.Click += btnVerDuenos_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrarSesion.Location = new Point(246, 344);
            btnCerrarSesion.Margin = new Padding(3, 4, 3, 4);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(109, 35);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnRanking
            // 
            btnRanking.Location = new Point(29, 219);
            btnRanking.Margin = new Padding(3, 4, 3, 4);
            btnRanking.Name = "btnRanking";
            btnRanking.Size = new Size(131, 47);
            btnRanking.TabIndex = 8;
            btnRanking.Text = "Ver Ranking";
            btnRanking.UseVisualStyleBackColor = true;
            btnRanking.Click += btnRanking_Click;
            // 
            // MenuAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 395);
            Controls.Add(btnRanking);
            Controls.Add(btnCerrarSesion);
            Controls.Add(duenoTitulo);
            Controls.Add(btnVerDuenos);
            Controls.Add(complejoTitulo);
            Controls.Add(btnVerComplejos);
            Controls.Add(tituloMenuAdmin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MenuAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Admin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tituloMenuAdmin;
        private Button btnVerComplejos;
        private Label complejoTitulo;
        private Label duenoTitulo;
        private Button btnVerDuenos;
        private Button btnCerrarSesion;
        private Button btnRanking;
    }
}