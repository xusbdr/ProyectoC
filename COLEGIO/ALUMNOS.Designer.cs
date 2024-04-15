
using System;
using System.Windows.Forms;

namespace COLEGIO
{
    partial class ALUMNOS
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
            this.dataGridALUMNOS = new System.Windows.Forms.DataGridView();
            this.dataGridINFORMACION = new System.Windows.Forms.DataGridView();
            this.buttonAÑADIR = new System.Windows.Forms.Button();
            this.buttonBORRAR = new System.Windows.Forms.Button();
            this.buttonMODIFICAR = new System.Windows.Forms.Button();
            this.buttonFICHA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMOfifcarNota = new System.Windows.Forms.Button();
            this.buttonAñadirNOTAS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridALUMNOS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridINFORMACION)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridALUMNOS
            // 
            this.dataGridALUMNOS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridALUMNOS.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridALUMNOS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridALUMNOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridALUMNOS.Location = new System.Drawing.Point(46, 85);
            this.dataGridALUMNOS.Name = "dataGridALUMNOS";
            this.dataGridALUMNOS.ReadOnly = true;
            this.dataGridALUMNOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridALUMNOS.Size = new System.Drawing.Size(749, 277);
            this.dataGridALUMNOS.TabIndex = 0;
            this.dataGridALUMNOS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridALUMNOS_CellContentClick);
            // 
            // dataGridINFORMACION
            // 
            this.dataGridINFORMACION.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridINFORMACION.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridINFORMACION.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridINFORMACION.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridINFORMACION.Location = new System.Drawing.Point(45, 392);
            this.dataGridINFORMACION.Name = "dataGridINFORMACION";
            this.dataGridINFORMACION.ReadOnly = true;
            this.dataGridINFORMACION.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridINFORMACION.Size = new System.Drawing.Size(750, 277);
            this.dataGridINFORMACION.TabIndex = 1;
            this.dataGridINFORMACION.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridINFORMACION_CellContentClick);
            // 
            // buttonAÑADIR
            // 
            this.buttonAÑADIR.BackColor = System.Drawing.Color.Snow;
            this.buttonAÑADIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAÑADIR.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonAÑADIR.Location = new System.Drawing.Point(910, 85);
            this.buttonAÑADIR.Name = "buttonAÑADIR";
            this.buttonAÑADIR.Size = new System.Drawing.Size(164, 53);
            this.buttonAÑADIR.TabIndex = 2;
            this.buttonAÑADIR.Text = "Añadir Alumno";
            this.buttonAÑADIR.UseVisualStyleBackColor = false;
            this.buttonAÑADIR.Click += new System.EventHandler(this.buttonAÑADIR_Click);
            // 
            // buttonBORRAR
            // 
            this.buttonBORRAR.BackColor = System.Drawing.Color.Snow;
            this.buttonBORRAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBORRAR.ForeColor = System.Drawing.Color.Red;
            this.buttonBORRAR.Location = new System.Drawing.Point(910, 239);
            this.buttonBORRAR.Name = "buttonBORRAR";
            this.buttonBORRAR.Size = new System.Drawing.Size(164, 52);
            this.buttonBORRAR.TabIndex = 3;
            this.buttonBORRAR.Text = "Borrar Alumno";
            this.buttonBORRAR.UseVisualStyleBackColor = false;
            this.buttonBORRAR.Click += new System.EventHandler(this.buttonBORRAR_Click);
            // 
            // buttonMODIFICAR
            // 
            this.buttonMODIFICAR.BackColor = System.Drawing.Color.Snow;
            this.buttonMODIFICAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMODIFICAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonMODIFICAR.Location = new System.Drawing.Point(910, 159);
            this.buttonMODIFICAR.Name = "buttonMODIFICAR";
            this.buttonMODIFICAR.Size = new System.Drawing.Size(164, 57);
            this.buttonMODIFICAR.TabIndex = 4;
            this.buttonMODIFICAR.Text = "Modificar Alumno";
            this.buttonMODIFICAR.UseVisualStyleBackColor = false;
            this.buttonMODIFICAR.Click += new System.EventHandler(this.buttonMODIFICAR_Click);
            // 
            // buttonFICHA
            // 
            this.buttonFICHA.BackColor = System.Drawing.Color.Snow;
            this.buttonFICHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFICHA.ForeColor = System.Drawing.Color.SeaGreen;
            this.buttonFICHA.Location = new System.Drawing.Point(910, 344);
            this.buttonFICHA.Name = "buttonFICHA";
            this.buttonFICHA.Size = new System.Drawing.Size(164, 76);
            this.buttonFICHA.TabIndex = 5;
            this.buttonFICHA.Text = "ABRIR FICHA";
            this.buttonFICHA.UseVisualStyleBackColor = false;
            this.buttonFICHA.Click += new System.EventHandler(this.buttonFICHA_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "ALUMNOS ACTUALES ";
            // 
            // buttonMOfifcarNota
            // 
            this.buttonMOfifcarNota.BackColor = System.Drawing.Color.Snow;
            this.buttonMOfifcarNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMOfifcarNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonMOfifcarNota.Location = new System.Drawing.Point(910, 540);
            this.buttonMOfifcarNota.Name = "buttonMOfifcarNota";
            this.buttonMOfifcarNota.Size = new System.Drawing.Size(164, 55);
            this.buttonMOfifcarNota.TabIndex = 7;
            this.buttonMOfifcarNota.Text = "Modificar Notas";
            this.buttonMOfifcarNota.UseVisualStyleBackColor = false;
            this.buttonMOfifcarNota.Click += new System.EventHandler(this.buttonMOfifcarNota_Click);
            // 
            // buttonAñadirNOTAS
            // 
            this.buttonAñadirNOTAS.BackColor = System.Drawing.Color.Snow;
            this.buttonAñadirNOTAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAñadirNOTAS.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonAñadirNOTAS.Location = new System.Drawing.Point(910, 617);
            this.buttonAñadirNOTAS.Name = "buttonAñadirNOTAS";
            this.buttonAñadirNOTAS.Size = new System.Drawing.Size(164, 52);
            this.buttonAñadirNOTAS.TabIndex = 8;
            this.buttonAñadirNOTAS.Text = "Añadir Notas";
            this.buttonAñadirNOTAS.UseVisualStyleBackColor = false;
            this.buttonAñadirNOTAS.Click += new System.EventHandler(this.buttonAñadirNOTAS_Click);
            // 
            // ALUMNOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 709);
            this.Controls.Add(this.buttonAñadirNOTAS);
            this.Controls.Add(this.buttonMOfifcarNota);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonFICHA);
            this.Controls.Add(this.buttonMODIFICAR);
            this.Controls.Add(this.buttonBORRAR);
            this.Controls.Add(this.buttonAÑADIR);
            this.Controls.Add(this.dataGridINFORMACION);
            this.Controls.Add(this.dataGridALUMNOS);
            this.Name = "ALUMNOS";
            this.Text = "ALUMNOS";
            this.Load += new System.EventHandler(this.ALUMNOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridALUMNOS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridINFORMACION)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridALUMNOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridALUMNOS;
        private System.Windows.Forms.DataGridView dataGridINFORMACION;
        private System.Windows.Forms.Button buttonAÑADIR;
        private System.Windows.Forms.Button buttonBORRAR;
        private System.Windows.Forms.Button buttonMODIFICAR;
        private System.Windows.Forms.Button buttonFICHA;
        private System.Windows.Forms.Label label1;
        private Button buttonMOfifcarNota;
        private Button buttonAñadirNOTAS;
    }
}