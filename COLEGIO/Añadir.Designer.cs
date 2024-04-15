
namespace COLEGIO
{
    partial class Añadir
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
            this.buttonguardar = new System.Windows.Forms.Button();
            this.textBoxdni = new System.Windows.Forms.TextBox();
            this.textnombre = new System.Windows.Forms.TextBox();
            this.textapellidos = new System.Windows.Forms.TextBox();
            this.texttelefono = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.combociudad = new System.Windows.Forms.ComboBox();
            this.combolocalidad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonguardar
            // 
            this.buttonguardar.Location = new System.Drawing.Point(172, 633);
            this.buttonguardar.Name = "buttonguardar";
            this.buttonguardar.Size = new System.Drawing.Size(73, 24);
            this.buttonguardar.TabIndex = 0;
            this.buttonguardar.Text = "Guardar";
            this.buttonguardar.UseVisualStyleBackColor = true;
            this.buttonguardar.Click += new System.EventHandler(this.buttonguardar_Click);
            // 
            // textBoxdni
            // 
            this.textBoxdni.Location = new System.Drawing.Point(172, 117);
            this.textBoxdni.Name = "textBoxdni";
            this.textBoxdni.Size = new System.Drawing.Size(164, 20);
            this.textBoxdni.TabIndex = 1;
            // 
            // textnombre
            // 
            this.textnombre.Location = new System.Drawing.Point(172, 183);
            this.textnombre.Name = "textnombre";
            this.textnombre.Size = new System.Drawing.Size(164, 20);
            this.textnombre.TabIndex = 2;
            // 
            // textapellidos
            // 
            this.textapellidos.Location = new System.Drawing.Point(172, 244);
            this.textapellidos.Name = "textapellidos";
            this.textapellidos.Size = new System.Drawing.Size(164, 20);
            this.textapellidos.TabIndex = 3;
            // 
            // texttelefono
            // 
            this.texttelefono.Location = new System.Drawing.Point(172, 316);
            this.texttelefono.Name = "texttelefono";
            this.texttelefono.Size = new System.Drawing.Size(164, 20);
            this.texttelefono.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "apellidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "telefono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "dni";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "ciudad\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 460);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "provincia";
            // 
            // combociudad
            // 
            this.combociudad.FormattingEnabled = true;
            this.combociudad.Items.AddRange(new object[] {
            "Huelva",
            "Sevilla",
            "Cordoba",
            "Jaen",
            "Cadiz",
            "Granada",
            "Alameria",
            "Malaga"});
            this.combociudad.Location = new System.Drawing.Point(172, 389);
            this.combociudad.Name = "combociudad";
            this.combociudad.Size = new System.Drawing.Size(164, 21);
            this.combociudad.TabIndex = 14;
            this.combociudad.SelectedIndexChanged += new System.EventHandler(this.combociudad_SelectedIndexChanged);
            // 
            // combolocalidad
            // 
            this.combolocalidad.FormattingEnabled = true;
            this.combolocalidad.Location = new System.Drawing.Point(172, 452);
            this.combolocalidad.Name = "combolocalidad";
            this.combolocalidad.Size = new System.Drawing.Size(164, 21);
            this.combolocalidad.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "AÑADIR  ALUMNOS";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(263, 633);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(73, 24);
            this.buttonCancelar.TabIndex = 17;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // Añadir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 669);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.combolocalidad);
            this.Controls.Add(this.combociudad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.texttelefono);
            this.Controls.Add(this.textapellidos);
            this.Controls.Add(this.textnombre);
            this.Controls.Add(this.textBoxdni);
            this.Controls.Add(this.buttonguardar);
            this.Name = "Añadir";
            this.Text = "Añadir";
            this.Load += new System.EventHandler(this.Añadir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonguardar;
        private System.Windows.Forms.TextBox textBoxdni;
        private System.Windows.Forms.TextBox textnombre;
        private System.Windows.Forms.TextBox textapellidos;
        private System.Windows.Forms.TextBox texttelefono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combociudad;
        private System.Windows.Forms.ComboBox combolocalidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonCancelar;
    }
}