namespace WindowsForms
{
    partial class PrecioCanchaCrearForm
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
            btnAgregar = new Button();
            btnCancelar = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            precioBase = new NumericUpDown();
            precioAdicional = new NumericUpDown();
            precioSeña = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)precioBase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)precioAdicional).BeginInit();
            ((System.ComponentModel.ISupportInitialize)precioSeña).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(449, 246);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 21;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(368, 246);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 20;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(226, 208);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 18;
            label4.Text = "Precio Seña";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(226, 176);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 17;
            label3.Text = "Precio Adicional";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(226, 144);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 16;
            label2.Text = "Precio Base";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(319, 89);
            label1.Name = "label1";
            label1.Size = new Size(215, 15);
            label1.TabIndex = 15;
            label1.Text = "Precio actual de la cancha seleccionada";
            // 
            // precioBase
            // 
            precioBase.Location = new Point(382, 142);
            precioBase.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            precioBase.Name = "precioBase";
            precioBase.Size = new Size(120, 23);
            precioBase.TabIndex = 22;
            // 
            // precioAdicional
            // 
            precioAdicional.Location = new Point(382, 171);
            precioAdicional.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            precioAdicional.Name = "precioAdicional";
            precioAdicional.Size = new Size(120, 23);
            precioAdicional.TabIndex = 23;
            // 
            // precioSeña
            // 
            precioSeña.Location = new Point(382, 200);
            precioSeña.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            precioSeña.Name = "precioSeña";
            precioSeña.Size = new Size(120, 23);
            precioSeña.TabIndex = 24;
            // 
            // PrecioCanchaCrearForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(precioSeña);
            Controls.Add(precioAdicional);
            Controls.Add(precioBase);
            Controls.Add(btnAgregar);
            Controls.Add(btnCancelar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PrecioCanchaCrearForm";
            Text = "PrecioCanchaCrearForm";
            ((System.ComponentModel.ISupportInitialize)precioBase).EndInit();
            ((System.ComponentModel.ISupportInitialize)precioAdicional).EndInit();
            ((System.ComponentModel.ISupportInitialize)precioSeña).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAgregar;
        private Button btnCancelar;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown precioBase;
        private NumericUpDown precioAdicional;
        private NumericUpDown precioSeña;
    }
}