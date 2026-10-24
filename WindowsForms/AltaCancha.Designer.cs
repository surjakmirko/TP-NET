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
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)nroCancha).BeginInit();
            SuspendLayout();
            // 
            // nroCanchaLabel
            // 
            nroCanchaLabel.AutoSize = true;
            nroCanchaLabel.Location = new Point(12, 43);
            nroCanchaLabel.Name = "nroCanchaLabel";
            nroCanchaLabel.Size = new Size(111, 15);
            nroCanchaLabel.TabIndex = 0;
            nroCanchaLabel.Text = "Numero de cancha:";
            nroCanchaLabel.Click += label1_Click;
            // 
            // nroCancha
            // 
            nroCancha.Location = new Point(148, 43);
            nroCancha.Margin = new Padding(3, 2, 3, 2);
            nroCancha.Name = "nroCancha";
            nroCancha.Size = new Size(133, 23);
            nroCancha.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 79);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 2;
            label1.Text = "Tipo de deporte:";
            // 
            // cmbTipoCancha
            // 
            cmbTipoCancha.FormattingEnabled = true;
            cmbTipoCancha.Location = new Point(148, 76);
            cmbTipoCancha.Margin = new Padding(3, 2, 3, 2);
            cmbTipoCancha.Name = "cmbTipoCancha";
            cmbTipoCancha.Size = new Size(133, 23);
            cmbTipoCancha.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.DialogResult = DialogResult.OK;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAceptar.Location = new Point(199, 114);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(82, 22);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(111, 114);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(116, 25);
            label2.TabIndex = 6;
            label2.Text = "Alta Cancha";
            // 
            // AltaCancha
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(293, 152);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbTipoCancha);
            Controls.Add(label1);
            Controls.Add(nroCancha);
            Controls.Add(nroCanchaLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "AltaCancha";
            StartPosition = FormStartPosition.CenterParent;
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
        private Label label2;
    }
}