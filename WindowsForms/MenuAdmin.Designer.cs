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
            SuspendLayout();
            // 
            // tituloMenuAdmin
            // 
            tituloMenuAdmin.AutoSize = true;
            tituloMenuAdmin.Font = new Font("Segoe UI", 15F);
            tituloMenuAdmin.Location = new Point(119, 9);
            tituloMenuAdmin.Name = "tituloMenuAdmin";
            tituloMenuAdmin.Size = new Size(125, 28);
            tituloMenuAdmin.TabIndex = 0;
            tituloMenuAdmin.Text = "Menu Admin";
            // 
            // btnVerComplejos
            // 
            btnVerComplejos.Location = new Point(31, 123);
            btnVerComplejos.Name = "btnVerComplejos";
            btnVerComplejos.Size = new Size(115, 35);
            btnVerComplejos.TabIndex = 1;
            btnVerComplejos.Text = "Ver Complejos";
            btnVerComplejos.UseVisualStyleBackColor = true;
            btnVerComplejos.Click += btnVerComplejos_Click;
            // 
            // complejoTitulo
            // 
            complejoTitulo.AutoSize = true;
            complejoTitulo.Font = new Font("Segoe UI", 15F);
            complejoTitulo.Location = new Point(40, 68);
            complejoTitulo.Name = "complejoTitulo";
            complejoTitulo.Size = new Size(97, 28);
            complejoTitulo.TabIndex = 2;
            complejoTitulo.Text = "Complejo";
            // 
            // duenoTitulo
            // 
            duenoTitulo.AutoSize = true;
            duenoTitulo.Font = new Font("Segoe UI", 15F);
            duenoTitulo.Location = new Point(243, 68);
            duenoTitulo.Name = "duenoTitulo";
            duenoTitulo.Size = new Size(70, 28);
            duenoTitulo.TabIndex = 5;
            duenoTitulo.Text = "Dueño";
            // 
            // btnVerDuenos
            // 
            btnVerDuenos.Location = new Point(221, 123);
            btnVerDuenos.Name = "btnVerDuenos";
            btnVerDuenos.Size = new Size(115, 35);
            btnVerDuenos.TabIndex = 4;
            btnVerDuenos.Text = "Ver Dueños";
            btnVerDuenos.UseVisualStyleBackColor = true;
            btnVerDuenos.Click += btnVerDuenos_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(256, 294);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(95, 26);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // MenuAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 332);
            Controls.Add(btnCerrarSesion);
            Controls.Add(duenoTitulo);
            Controls.Add(btnVerDuenos);
            Controls.Add(complejoTitulo);
            Controls.Add(btnVerComplejos);
            Controls.Add(tituloMenuAdmin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MenuAdmin";
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
    }
}