namespace WindowsForms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usuario = new Label();
            usuarioCaja = new TextBox();
            contraseñaCaja = new TextBox();
            contraseña = new Label();
            iniciarSesión = new Button();
            titulo = new Label();
            olvideContraseña = new LinkLabel();
            SuspendLayout();
            // 
            // usuario
            // 
            usuario.AutoSize = true;
            usuario.Location = new Point(169, 132);
            usuario.Name = "usuario";
            usuario.Size = new Size(47, 15);
            usuario.TabIndex = 0;
            usuario.Text = "Usuario";
            // 
            // usuarioCaja
            // 
            usuarioCaja.Location = new Point(169, 150);
            usuarioCaja.Name = "usuarioCaja";
            usuarioCaja.Size = new Size(134, 23);
            usuarioCaja.TabIndex = 1;
            // 
            // contraseñaCaja
            // 
            contraseñaCaja.Location = new Point(169, 218);
            contraseñaCaja.Name = "contraseñaCaja";
            contraseñaCaja.Size = new Size(134, 23);
            contraseñaCaja.TabIndex = 3;
            contraseñaCaja.UseSystemPasswordChar = true;
            // 
            // contraseña
            // 
            contraseña.AutoSize = true;
            contraseña.Location = new Point(169, 200);
            contraseña.Name = "contraseña";
            contraseña.Size = new Size(67, 15);
            contraseña.TabIndex = 2;
            contraseña.Text = "Contraseña";
            // 
            // iniciarSesión
            // 
            iniciarSesión.Location = new Point(231, 298);
            iniciarSesión.Name = "iniciarSesión";
            iniciarSesión.Size = new Size(97, 23);
            iniciarSesión.TabIndex = 4;
            iniciarSesión.Text = "Iniciar Sesión";
            iniciarSesión.UseVisualStyleBackColor = true;
            iniciarSesión.Click += IniciarSesion_Click;
            // 
            // titulo
            // 
            titulo.AutoSize = true;
            titulo.Font = new Font("Segoe UI", 13F);
            titulo.Location = new Point(136, 81);
            titulo.Name = "titulo";
            titulo.Size = new Size(207, 25);
            titulo.TabIndex = 5;
            titulo.Text = "Bienvenido a TurnoLibre!";
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // olvideContraseña
            // 
            olvideContraseña.AutoSize = true;
            olvideContraseña.LinkColor = Color.Black;
            olvideContraseña.Location = new Point(169, 244);
            olvideContraseña.Name = "olvideContraseña";
            olvideContraseña.Size = new Size(119, 15);
            olvideContraseña.TabIndex = 6;
            olvideContraseña.TabStop = true;
            olvideContraseña.Text = "Olvidé mi contraseña";
            // 
            // LoginForm
            // 
            ClientSize = new Size(478, 403);
            Controls.Add(olvideContraseña);
            Controls.Add(titulo);
            Controls.Add(iniciarSesión);
            Controls.Add(contraseñaCaja);
            Controls.Add(contraseña);
            Controls.Add(usuarioCaja);
            Controls.Add(usuario);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            Load += LoginForm_Load_1;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion


        private Label usuario;
        private TextBox usuarioCaja;
        private TextBox contraseñaCaja;
        private Label contraseña;
        private Button iniciarSesión;
        private Label titulo;
        private LinkLabel olvideContraseña;
    }
}
