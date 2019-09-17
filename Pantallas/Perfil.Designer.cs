namespace Pantallas
{
    partial class Perfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Perfil));
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textClave = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.Clave = new System.Windows.Forms.Label();
            this.bGuarda = new System.Windows.Forms.Button();
            this.textApellidos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textNickname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textCalleN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textColonia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textCelular = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textTelefono = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textCorreo = new System.Windows.Forms.TextBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(341, 207);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(131, 20);
            this.textPassword.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label1.Location = new System.Drawing.Point(338, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Contraseña:";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(189, 78);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(111, 20);
            this.textNombre.TabIndex = 24;
            this.textNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNombre_KeyPress);
            // 
            // textClave
            // 
            this.textClave.Enabled = false;
            this.textClave.Location = new System.Drawing.Point(189, 36);
            this.textClave.Name = "textClave";
            this.textClave.Size = new System.Drawing.Size(64, 20);
            this.textClave.TabIndex = 22;
            this.textClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textClave_KeyPress);
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.BackColor = System.Drawing.Color.Transparent;
            this.Nombre.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.Nombre.Location = new System.Drawing.Point(189, 61);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(52, 14);
            this.Nombre.TabIndex = 20;
            this.Nombre.Text = "Nombre:";
            // 
            // Clave
            // 
            this.Clave.AutoSize = true;
            this.Clave.BackColor = System.Drawing.Color.Transparent;
            this.Clave.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.Clave.Location = new System.Drawing.Point(186, 19);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(41, 14);
            this.Clave.TabIndex = 19;
            this.Clave.Text = "Clave:";
            // 
            // bGuarda
            // 
            this.bGuarda.Location = new System.Drawing.Point(274, 299);
            this.bGuarda.Name = "bGuarda";
            this.bGuarda.Size = new System.Drawing.Size(160, 23);
            this.bGuarda.TabIndex = 27;
            this.bGuarda.Text = "Guardar Cambios";
            this.bGuarda.UseVisualStyleBackColor = true;
            this.bGuarda.Click += new System.EventHandler(this.bGuarda_Click);
            // 
            // textApellidos
            // 
            this.textApellidos.Location = new System.Drawing.Point(311, 78);
            this.textApellidos.Name = "textApellidos";
            this.textApellidos.Size = new System.Drawing.Size(111, 20);
            this.textApellidos.TabIndex = 28;
            this.textApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNombre_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label2.Location = new System.Drawing.Point(309, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "Apellidos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label3.Location = new System.Drawing.Point(430, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 31;
            this.label3.Text = "Usuario:";
            // 
            // textNickname
            // 
            this.textNickname.Location = new System.Drawing.Point(432, 78);
            this.textNickname.Name = "textNickname";
            this.textNickname.Size = new System.Drawing.Size(111, 20);
            this.textNickname.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label4.Location = new System.Drawing.Point(190, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 33;
            this.label4.Text = "Calle y Número:";
            // 
            // textCalleN
            // 
            this.textCalleN.Location = new System.Drawing.Point(192, 122);
            this.textCalleN.Name = "textCalleN";
            this.textCalleN.Size = new System.Drawing.Size(111, 20);
            this.textCalleN.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label5.Location = new System.Drawing.Point(310, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 35;
            this.label5.Text = "Colonia:";
            // 
            // textColonia
            // 
            this.textColonia.Location = new System.Drawing.Point(312, 122);
            this.textColonia.Name = "textColonia";
            this.textColonia.Size = new System.Drawing.Size(111, 20);
            this.textColonia.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label6.Location = new System.Drawing.Point(191, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 14);
            this.label6.TabIndex = 37;
            this.label6.Text = "Celular:";
            // 
            // textCelular
            // 
            this.textCelular.Location = new System.Drawing.Point(193, 164);
            this.textCelular.Name = "textCelular";
            this.textCelular.Size = new System.Drawing.Size(111, 20);
            this.textCelular.TabIndex = 36;
            this.textCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textClave_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label7.Location = new System.Drawing.Point(311, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 39;
            this.label7.Text = "Teléfono:";
            // 
            // textTelefono
            // 
            this.textTelefono.Location = new System.Drawing.Point(313, 164);
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Size = new System.Drawing.Size(111, 20);
            this.textTelefono.TabIndex = 38;
            this.textTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textClave_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label8.Location = new System.Drawing.Point(192, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 14);
            this.label8.TabIndex = 41;
            this.label8.Text = "Correo:";
            // 
            // textCorreo
            // 
            this.textCorreo.Location = new System.Drawing.Point(194, 207);
            this.textCorreo.Name = "textCorreo";
            this.textCorreo.Size = new System.Drawing.Size(138, 20);
            this.textCorreo.TabIndex = 40;
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(766, 122);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(240, 150);
            this.dataGrid.TabIndex = 44;
            this.dataGrid.Visible = false;
            // 
            // Perfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Pantallas.Properties.Resources.fondito;
            this.ClientSize = new System.Drawing.Size(558, 345);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textCorreo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textTelefono);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textCelular);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textColonia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textCalleN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textNickname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textApellidos);
            this.Controls.Add(this.bGuarda);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.textClave);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Clave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Perfil";
            this.Text = "Perfil";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNombre_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textClave;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label Clave;
        private System.Windows.Forms.Button bGuarda;
        private System.Windows.Forms.TextBox textApellidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNickname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCalleN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textColonia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textCelular;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textTelefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textCorreo;
        private System.Windows.Forms.DataGridView dataGrid;
    }
}