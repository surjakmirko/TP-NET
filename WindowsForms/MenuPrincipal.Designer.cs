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
            button1 = new Button();
            btnReporte = new Button();
            SuspendLayout();
            // 
            // bienvenido
            // 
            bienvenido.Anchor = AnchorStyles.Top;
            bienvenido.Font = new Font("Segoe UI", 18F);
            bienvenido.Location = new Point(12, 42);
            bienvenido.Margin = new Padding(4, 0, 4, 0);
            bienvenido.Name = "bienvenido";
            bienvenido.Size = new Size(654, 40);
            bienvenido.TabIndex = 0;
            bienvenido.Text = "Bienvenido!";
            bienvenido.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // miComplejo
            // 
            miComplejo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            miComplejo.AutoSize = true;
            miComplejo.Font = new Font("Segoe UI", 15F);
            miComplejo.Location = new Point(94, 145);
            miComplejo.Margin = new Padding(4, 0, 4, 0);
            miComplejo.Name = "miComplejo";
            miComplejo.Size = new Size(157, 35);
            miComplejo.TabIndex = 1;
            miComplejo.Text = "Mi Complejo";
            // 
            // btnModificarComplejo
            // 
            btnModificarComplejo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnModificarComplejo.Location = new Point(15, 254);
            btnModificarComplejo.Margin = new Padding(4, 4, 4, 4);
            btnModificarComplejo.Name = "btnModificarComplejo";
            btnModificarComplejo.Size = new Size(310, 41);
            btnModificarComplejo.TabIndex = 3;
            btnModificarComplejo.Text = "Modificar";
            btnModificarComplejo.UseVisualStyleBackColor = true;
            btnModificarComplejo.Click += btnModificarComplejo_Click;
            // 
            // btnVerComplejo
            // 
            btnVerComplejo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnVerComplejo.Location = new Point(15, 205);
            btnVerComplejo.Margin = new Padding(4, 4, 4, 4);
            btnVerComplejo.Name = "btnVerComplejo";
            btnVerComplejo.Size = new Size(310, 41);
            btnVerComplejo.TabIndex = 4;
            btnVerComplejo.Text = "Ver";
            btnVerComplejo.UseVisualStyleBackColor = true;
            btnVerComplejo.Click += btnVerComplejo_Click;
            // 
            // btnVerCancha
            // 
            btnVerCancha.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnVerCancha.Location = new Point(358, 254);
            btnVerCancha.Margin = new Padding(2);
            btnVerCancha.Name = "btnVerCancha";
            btnVerCancha.Size = new Size(310, 41);
            btnVerCancha.TabIndex = 8;
            btnVerCancha.Text = "Ver";
            btnVerCancha.UseVisualStyleBackColor = true;
            btnVerCancha.Click += btnVerCancha_Click;
            // 
            // btnDarDeAltaCancha
            // 
            btnDarDeAltaCancha.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDarDeAltaCancha.Location = new Point(358, 205);
            btnDarDeAltaCancha.Margin = new Padding(2);
            btnDarDeAltaCancha.Name = "btnDarDeAltaCancha";
            btnDarDeAltaCancha.Size = new Size(310, 41);
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
            label1.Location = new Point(439, 145);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 35);
            label1.TabIndex = 5;
            label1.Text = "Mis Canchas";
            // 
            // cambiarComplejoBoton
            // 
            cambiarComplejoBoton.Location = new Point(12, 488);
            cambiarComplejoBoton.Margin = new Padding(2);
            cambiarComplejoBoton.Name = "cambiarComplejoBoton";
            cambiarComplejoBoton.Size = new Size(188, 32);
            cambiarComplejoBoton.TabIndex = 11;
            cambiarComplejoBoton.Text = "Cambiar Complejo";
            cambiarComplejoBoton.UseVisualStyleBackColor = true;
            cambiarComplejoBoton.Click += cambiarComplejoBoton_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(480, 488);
            btnCerrarSesion.Margin = new Padding(2);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(188, 32);
            btnCerrarSesion.TabIndex = 12;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click_1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(15, 302);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(310, 41);
            button1.TabIndex = 13;
            button1.Text = "Horarios";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnReporte
            // 
            btnReporte.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnReporte.Location = new Point(15, 351);
            btnReporte.Margin = new Padding(4);
            btnReporte.Name = "btnReporte";
            btnReporte.Size = new Size(310, 41);
            btnReporte.TabIndex = 14;
            btnReporte.Text = "Ver Reporte de Ocupacion de Canchas";
            btnReporte.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(681, 532);
            Controls.Add(btnReporte);
            Controls.Add(button1);
            Controls.Add(btnCerrarSesion);
            Controls.Add(cambiarComplejoBoton);
            Controls.Add(btnVerCancha);
            Controls.Add(btnDarDeAltaCancha);
            Controls.Add(label1);
            Controls.Add(btnVerComplejo);
            Controls.Add(btnModificarComplejo);
            Controls.Add(miComplejo);
            Controls.Add(bienvenido);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button button1;
        private Button btnReporte;
    }
}