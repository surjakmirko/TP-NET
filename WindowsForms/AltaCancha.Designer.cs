namespace WindowsForms
{
    partial class AltaCancha
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
            nroCanchaLabel = new Label();
            nroCancha = new NumericUpDown();
            label1 = new Label();
            cmbTipoCancha = new ComboBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nroCancha).BeginInit();
            SuspendLayout();
            // 
            // nroCanchaLabel
            // 
            nroCanchaLabel.AutoSize = true;
            nroCanchaLabel.Location = new Point(12, 33);
            nroCanchaLabel.Name = "nroCanchaLabel";
            nroCanchaLabel.Size = new Size(137, 20);
            nroCanchaLabel.TabIndex = 0;
            nroCanchaLabel.Text = "Numero de cancha:";
            nroCanchaLabel.Click += label1_Click;
            // 
            // nroCancha
            // 
            nroCancha.Location = new Point(155, 33);
            nroCancha.Name = "nroCancha";
            nroCancha.Size = new Size(49, 27);
            nroCancha.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 81);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 2;
            label1.Text = "Tipo de deporte:";
            // 
            // cmbTipoCancha
            // 
            cmbTipoCancha.FormattingEnabled = true;
            cmbTipoCancha.Location = new Point(138, 78);
            cmbTipoCancha.Name = "cmbTipoCancha";
            cmbTipoCancha.Size = new Size(151, 28);
            cmbTipoCancha.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.DialogResult = DialogResult.OK;
            btnAceptar.Location = new Point(73, 143);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(209, 143);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AltaCancha
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(375, 211);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbTipoCancha);
            Controls.Add(label1);
            Controls.Add(nroCancha);
            Controls.Add(nroCanchaLabel);
            Name = "AltaCancha";
            Text = "AltaCancha";
            Load += AltaCancha_Load;
            ((System.ComponentModel.ISupportInitialize)nroCancha).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nroCanchaLabel;
        private NumericUpDown nroCancha;
        private Label label1;
        private ComboBox cmbTipoCancha;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}