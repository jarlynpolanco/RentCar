namespace RentCar.UI.Forms
{
    partial class frmInspeccion
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
            this.cboEmpleados = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboVehiculo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ftHalf = new System.Windows.Forms.RadioButton();
            this.ftQuarter = new System.Windows.Forms.RadioButton();
            this.ftFull = new System.Windows.Forms.RadioButton();
            this.ftThreeQuarters = new System.Windows.Forms.RadioButton();
            this.ralladuras = new System.Windows.Forms.CheckBox();
            this.tieneGoma = new System.Windows.Forms.CheckBox();
            this.tieneRotura = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.goma1 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.goma2 = new System.Windows.Forms.CheckBox();
            this.goma4 = new System.Windows.Forms.CheckBox();
            this.goma3 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEmpleados
            // 
            this.cboEmpleados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleados.FormattingEnabled = true;
            this.cboEmpleados.Location = new System.Drawing.Point(497, 209);
            this.cboEmpleados.Name = "cboEmpleados";
            this.cboEmpleados.Size = new System.Drawing.Size(129, 21);
            this.cboEmpleados.TabIndex = 52;
            this.cboEmpleados.SelectedIndexChanged += new System.EventHandler(this.cboEmpleados_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(369, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "Empleado Inspección";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(49, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Tiene Ralladuras";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Tiene Goma de Respuesta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Cantidad Combustible";
            // 
            // cboClientes
            // 
            this.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(178, 99);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(169, 21);
            this.cboClientes.TabIndex = 44;
            this.cboClientes.SelectedIndexChanged += new System.EventHandler(this.cboClientes_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Nombre Cliente";
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehiculo.FormattingEnabled = true;
            this.cboVehiculo.Location = new System.Drawing.Point(178, 61);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(169, 21);
            this.cboVehiculo.TabIndex = 42;
            this.cboVehiculo.SelectedIndexChanged += new System.EventHandler(this.cboVehiculo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Vehiculo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(687, 111);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 29);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(687, 74);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 29);
            this.btnGuardar.TabIndex = 39;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Inspección Vehiculo";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 276);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1050, 290);
            this.dataGridView1.TabIndex = 37;
            // 
            // ftHalf
            // 
            this.ftHalf.AutoSize = true;
            this.ftHalf.Location = new System.Drawing.Point(223, 176);
            this.ftHalf.Name = "ftHalf";
            this.ftHalf.Size = new System.Drawing.Size(42, 17);
            this.ftHalf.TabIndex = 61;
            this.ftHalf.TabStop = true;
            this.ftHalf.Text = "1/2";
            this.ftHalf.UseVisualStyleBackColor = true;
            // 
            // ftQuarter
            // 
            this.ftQuarter.AutoSize = true;
            this.ftQuarter.Location = new System.Drawing.Point(178, 176);
            this.ftQuarter.Name = "ftQuarter";
            this.ftQuarter.Size = new System.Drawing.Size(42, 17);
            this.ftQuarter.TabIndex = 60;
            this.ftQuarter.TabStop = true;
            this.ftQuarter.Text = "1/4";
            this.ftQuarter.UseVisualStyleBackColor = true;
            // 
            // ftFull
            // 
            this.ftFull.AutoSize = true;
            this.ftFull.Location = new System.Drawing.Point(313, 176);
            this.ftFull.Name = "ftFull";
            this.ftFull.Size = new System.Drawing.Size(41, 17);
            this.ftFull.TabIndex = 63;
            this.ftFull.TabStop = true;
            this.ftFull.Text = "Full";
            this.ftFull.UseVisualStyleBackColor = true;
            // 
            // ftThreeQuarters
            // 
            this.ftThreeQuarters.AutoSize = true;
            this.ftThreeQuarters.Location = new System.Drawing.Point(268, 176);
            this.ftThreeQuarters.Name = "ftThreeQuarters";
            this.ftThreeQuarters.Size = new System.Drawing.Size(42, 17);
            this.ftThreeQuarters.TabIndex = 62;
            this.ftThreeQuarters.TabStop = true;
            this.ftThreeQuarters.Text = "3/4";
            this.ftThreeQuarters.UseVisualStyleBackColor = true;
            // 
            // ralladuras
            // 
            this.ralladuras.AutoSize = true;
            this.ralladuras.Location = new System.Drawing.Point(178, 137);
            this.ralladuras.Name = "ralladuras";
            this.ralladuras.Size = new System.Drawing.Size(15, 14);
            this.ralladuras.TabIndex = 64;
            this.ralladuras.UseVisualStyleBackColor = true;
            // 
            // tieneGoma
            // 
            this.tieneGoma.AutoSize = true;
            this.tieneGoma.Location = new System.Drawing.Point(178, 212);
            this.tieneGoma.Name = "tieneGoma";
            this.tieneGoma.Size = new System.Drawing.Size(15, 14);
            this.tieneGoma.TabIndex = 65;
            this.tieneGoma.UseVisualStyleBackColor = true;
            // 
            // tieneRotura
            // 
            this.tieneRotura.AutoSize = true;
            this.tieneRotura.Location = new System.Drawing.Point(178, 246);
            this.tieneRotura.Name = "tieneRotura";
            this.tieneRotura.Size = new System.Drawing.Size(15, 14);
            this.tieneRotura.TabIndex = 67;
            this.tieneRotura.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 13);
            this.label10.TabIndex = 66;
            this.label10.Text = "Tiene Rotura de Cristal";
            // 
            // goma1
            // 
            this.goma1.AutoSize = true;
            this.goma1.Location = new System.Drawing.Point(429, 81);
            this.goma1.Name = "goma1";
            this.goma1.Size = new System.Drawing.Size(15, 14);
            this.goma1.TabIndex = 69;
            this.goma1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(408, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 13);
            this.label12.TabIndex = 68;
            this.label12.Text = "Estado Gomas";
            // 
            // goma2
            // 
            this.goma2.AutoSize = true;
            this.goma2.Location = new System.Drawing.Point(466, 81);
            this.goma2.Name = "goma2";
            this.goma2.Size = new System.Drawing.Size(15, 14);
            this.goma2.TabIndex = 70;
            this.goma2.UseVisualStyleBackColor = true;
            // 
            // goma4
            // 
            this.goma4.AutoSize = true;
            this.goma4.Location = new System.Drawing.Point(466, 111);
            this.goma4.Name = "goma4";
            this.goma4.Size = new System.Drawing.Size(15, 14);
            this.goma4.TabIndex = 72;
            this.goma4.UseVisualStyleBackColor = true;
            // 
            // goma3
            // 
            this.goma3.AutoSize = true;
            this.goma3.Location = new System.Drawing.Point(429, 111);
            this.goma3.Name = "goma3";
            this.goma3.Size = new System.Drawing.Size(15, 14);
            this.goma3.TabIndex = 71;
            this.goma3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(426, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 73;
            this.label11.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(372, 167);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 74;
            // 
            // frmInspeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 616);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.goma4);
            this.Controls.Add(this.goma3);
            this.Controls.Add(this.goma2);
            this.Controls.Add(this.goma1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tieneRotura);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tieneGoma);
            this.Controls.Add(this.ralladuras);
            this.Controls.Add(this.ftFull);
            this.Controls.Add(this.ftThreeQuarters);
            this.Controls.Add(this.ftHalf);
            this.Controls.Add(this.ftQuarter);
            this.Controls.Add(this.cboEmpleados);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboClientes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboVehiculo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmInspeccion";
            this.Text = "frmInspeccion";
            this.Load += new System.EventHandler(this.frmInspeccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboEmpleados;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboVehiculo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton ftHalf;
        private System.Windows.Forms.RadioButton ftQuarter;
        private System.Windows.Forms.RadioButton ftFull;
        private System.Windows.Forms.RadioButton ftThreeQuarters;
        private System.Windows.Forms.CheckBox ralladuras;
        private System.Windows.Forms.CheckBox tieneGoma;
        private System.Windows.Forms.CheckBox tieneRotura;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox goma1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox goma2;
        private System.Windows.Forms.CheckBox goma4;
        private System.Windows.Forms.CheckBox goma3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}