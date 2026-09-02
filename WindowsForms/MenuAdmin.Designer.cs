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
            btnDarAltaComplejo = new Button();
            complejoTitulo = new Label();
            btnEliminarComplejo = new Button();
            btnEliminarDueno = new Button();
            duenoTitulo = new Label();
            btnDarAltaDueno = new Button();
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
            // btnDarAltaComplejo
            // 
            btnDarAltaComplejo.Location = new Point(31, 123);
            btnDarAltaComplejo.Name = "btnDarAltaComplejo";
            btnDarAltaComplejo.Size = new Size(115, 35);
            btnDarAltaComplejo.TabIndex = 1;
            btnDarAltaComplejo.Text = "Dar de Alta";
            btnDarAltaComplejo.UseVisualStyleBackColor = true;
            // 
            // complejoTitulo
            // 
            complejoTitulo.AutoSize = true;
            complejoTitulo.Font = new Font("Segoe UI", 15F);
            complejoTitulo.Location = new Point(12, 68);
            complejoTitulo.Name = "complejoTitulo";
            complejoTitulo.Size = new Size(152, 28);
            complejoTitulo.TabIndex = 2;
            complejoTitulo.Text = "Complejo Titulo";
            // 
            // btnEliminarComplejo
            // 
            btnEliminarComplejo.Location = new Point(31, 187);
            btnEliminarComplejo.Name = "btnEliminarComplejo";
            btnEliminarComplejo.Size = new Size(115, 35);
            btnEliminarComplejo.TabIndex = 3;
            btnEliminarComplejo.Text = "Eliminar";
            btnEliminarComplejo.UseVisualStyleBackColor = true;
            // 
            // btnEliminarDueno
            // 
            btnEliminarDueno.Location = new Point(221, 187);
            btnEliminarDueno.Name = "btnEliminarDueno";
            btnEliminarDueno.Size = new Size(115, 35);
            btnEliminarDueno.TabIndex = 6;
            btnEliminarDueno.Text = "Eliminar";
            btnEliminarDueno.UseVisualStyleBackColor = true;
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
            // btnDarAltaDueno
            // 
            btnDarAltaDueno.Location = new Point(221, 123);
            btnDarAltaDueno.Name = "btnDarAltaDueno";
            btnDarAltaDueno.Size = new Size(115, 35);
            btnDarAltaDueno.TabIndex = 4;
            btnDarAltaDueno.Text = "Dar de Alta";
            btnDarAltaDueno.UseVisualStyleBackColor = true;
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
            Controls.Add(btnEliminarDueno);
            Controls.Add(duenoTitulo);
            Controls.Add(btnDarAltaDueno);
            Controls.Add(btnEliminarComplejo);
            Controls.Add(complejoTitulo);
            Controls.Add(btnDarAltaComplejo);
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
        private Button btnDarAltaComplejo;
        private Label complejoTitulo;
        private Button btnEliminarComplejo;
        private Button btnEliminarDueno;
        private Label duenoTitulo;
        private Button btnDarAltaDueno;
        private Button btnCerrarSesion;
    }
}