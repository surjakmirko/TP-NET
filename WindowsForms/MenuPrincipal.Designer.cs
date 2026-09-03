namespace WindowsForms
{
    partial class MenuPrincipal
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
            bienvenido = new Label();
            miComplejo = new Label();
            btnModificarComplejo = new Button();
            btnVerComplejo = new Button();
            btnVerCancha = new Button();
            btnDarDeAltaCancha = new Button();
            label1 = new Label();
            cambiarComplejoBoton = new Button();
            btnCerrarSesion = new Button();
            SuspendLayout();
            // 
            // bienvenido
            // 
            bienvenido.Anchor = AnchorStyles.Top;
            bienvenido.Font = new Font("Segoe UI", 18F);
            bienvenido.Location = new Point(12, 34);
            bienvenido.Name = "bienvenido";
            bienvenido.Size = new Size(461, 32);
            bienvenido.TabIndex = 0;
            bienvenido.Text = "Bienvenido!";
            bienvenido.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // miComplejo
            // 
            miComplejo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            miComplejo.AutoSize = true;
            miComplejo.Font = new Font("Segoe UI", 15F);
            miComplejo.Location = new Point(67, 116);
            miComplejo.Name = "miComplejo";
            miComplejo.Size = new Size(125, 28);
            miComplejo.TabIndex = 1;
            miComplejo.Text = "Mi Complejo";
            // 
            // btnModificarComplejo
            // 
            btnModificarComplejo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnModificarComplejo.Location = new Point(37, 203);
            btnModificarComplejo.Name = "btnModificarComplejo";
            btnModificarComplejo.Size = new Size(188, 33);
            btnModificarComplejo.TabIndex = 3;
            btnModificarComplejo.Text = "Modificar";
            btnModificarComplejo.UseVisualStyleBackColor = true;
            btnModificarComplejo.Click += btnModificarComplejo_Click;
            // 
            // btnVerComplejo
            // 
            btnVerComplejo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnVerComplejo.Location = new Point(37, 164);
            btnVerComplejo.Name = "btnVerComplejo";
            btnVerComplejo.Size = new Size(188, 33);
            btnVerComplejo.TabIndex = 4;
            btnVerComplejo.Text = "Ver";
            btnVerComplejo.UseVisualStyleBackColor = true;
            btnVerComplejo.Click += btnVerComplejo_Click;
            // 
            // btnVerCancha
            // 
            btnVerCancha.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnVerCancha.Location = new Point(265, 203);
            btnVerCancha.Margin = new Padding(2);
            btnVerCancha.Name = "btnVerCancha";
            btnVerCancha.Size = new Size(188, 33);
            btnVerCancha.TabIndex = 8;
            btnVerCancha.Text = "Ver";
            btnVerCancha.UseVisualStyleBackColor = true;
            btnVerCancha.Click += btnVerCancha_Click;
            // 
            // btnDarDeAltaCancha
            // 
            btnDarDeAltaCancha.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDarDeAltaCancha.Location = new Point(265, 164);
            btnDarDeAltaCancha.Margin = new Padding(2);
            btnDarDeAltaCancha.Name = "btnDarDeAltaCancha";
            btnDarDeAltaCancha.Size = new Size(188, 33);
            btnDarDeAltaCancha.TabIndex = 6;
            btnDarDeAltaCancha.Text = "Dar de Alta";
            btnDarDeAltaCancha.UseVisualStyleBackColor = true;
            btnDarDeAltaCancha.Click += btnDarDeAltaCancha_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(300, 116);
            label1.Name = "label1";
            label1.Size = new Size(119, 28);
            label1.TabIndex = 5;
            label1.Text = "Mis Canchas";
            // 
            // cambiarComplejoBoton
            // 
            cambiarComplejoBoton.Location = new Point(10, 390);
            cambiarComplejoBoton.Margin = new Padding(2);
            cambiarComplejoBoton.Name = "cambiarComplejoBoton";
            cambiarComplejoBoton.Size = new Size(150, 26);
            cambiarComplejoBoton.TabIndex = 11;
            cambiarComplejoBoton.Text = "Cambiar Complejo";
            cambiarComplejoBoton.UseVisualStyleBackColor = true;
            cambiarComplejoBoton.Click += cambiarComplejoBoton_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(324, 390);
            btnCerrarSesion.Margin = new Padding(2);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(150, 26);
            btnCerrarSesion.TabIndex = 12;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click_1;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(485, 426);
            Controls.Add(btnCerrarSesion);
            Controls.Add(cambiarComplejoBoton);
            Controls.Add(btnVerCancha);
            Controls.Add(btnDarDeAltaCancha);
            Controls.Add(label1);
            Controls.Add(btnVerComplejo);
            Controls.Add(btnModificarComplejo);
            Controls.Add(miComplejo);
            Controls.Add(bienvenido);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
            Load += MenuPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label bienvenido;
        private Label miComplejo;
        private Button btnModificarComplejo;
        private Button btnVerComplejo;
        private Button btnVerCancha;
        private Button btnDarDeAltaCancha;
        private Label label1;
        private Button cambiarComplejoBoton;
        private Button btnCerrarSesion;
    }
}