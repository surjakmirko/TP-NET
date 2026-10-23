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
            Button botonCancelar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            usuario = new Label();
            usuarioCaja = new TextBox();
            contraseñaCaja = new TextBox();
            contraseña = new Label();
            iniciarSesión = new Button();
            titulo = new Label();
            pictureBox1 = new PictureBox();
            mostrarPassword = new Button();
            botonCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // botonCancelar
            // 
            botonCancelar.Location = new Point(85, 192);
            botonCancelar.Name = "botonCancelar";
            botonCancelar.Size = new Size(75, 23);
            botonCancelar.TabIndex = 8;
            botonCancelar.Text = "Cancelar";
            botonCancelar.UseVisualStyleBackColor = true;
            botonCancelar.Click += botonCancelar_Click;
            // 
            // usuario
            // 
            usuario.AutoSize = true;
            usuario.Location = new Point(85, 65);
            usuario.Name = "usuario";
            usuario.Size = new Size(49, 15);
            usuario.TabIndex = 0;
            usuario.Text = "Usuario";
            // 
            // usuarioCaja
            // 
            usuarioCaja.Location = new Point(85, 83);
            usuarioCaja.Name = "usuarioCaja";
            usuarioCaja.Size = new Size(175, 23);
            usuarioCaja.TabIndex = 1;
            // 
            // contraseñaCaja
            // 
            contraseñaCaja.Location = new Point(85, 151);
            contraseñaCaja.Name = "contraseñaCaja";
            contraseñaCaja.Size = new Size(173, 23);
            contraseñaCaja.TabIndex = 3;
            contraseñaCaja.UseSystemPasswordChar = true;
            // 
            // contraseña
            // 
            contraseña.AutoSize = true;
            contraseña.Location = new Point(85, 133);
            contraseña.Name = "contraseña";
            contraseña.Size = new Size(69, 15);
            contraseña.TabIndex = 2;
            contraseña.Text = "Contraseña";
            // 
            // iniciarSesión
            // 
            iniciarSesión.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            iniciarSesión.Location = new Point(166, 192);
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
            titulo.Font = new Font("Segoe UI", 16F);
            titulo.Location = new Point(64, 19);
            titulo.Name = "titulo";
            titulo.Size = new Size(255, 30);
            titulo.TabIndex = 5;
            titulo.Text = "Bienvenido a TurnoLibre!";
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 49);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // mostrarPassword
            // 
            mostrarPassword.Location = new Point(264, 151);
            mostrarPassword.Name = "mostrarPassword";
            mostrarPassword.Size = new Size(35, 23);
            mostrarPassword.TabIndex = 10;
            mostrarPassword.Text = "👁";
            mostrarPassword.UseVisualStyleBackColor = true;
            mostrarPassword.Click += mostrarPassword_Click;
            // 
            // LoginForm
            // 
            ClientSize = new Size(358, 252);
            Controls.Add(mostrarPassword);
            Controls.Add(botonCancelar);
            Controls.Add(pictureBox1);
            Controls.Add(titulo);
            Controls.Add(iniciarSesión);
            Controls.Add(contraseñaCaja);
            Controls.Add(contraseña);
            Controls.Add(usuarioCaja);
            Controls.Add(usuario);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
        private Button botonCancelar;
        private Button mostrarPassword;
    }
}
