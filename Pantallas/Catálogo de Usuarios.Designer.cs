namespace Pantallas
{
    partial class Catálogo_de_Usuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Catálogo_de_Usuarios));
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textClave = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.Label();
            this.Clave = new System.Windows.Forms.Label();
            this.textCont = new System.Windows.Forms.TextBox();
            this.Contrasena = new System.Windows.Forms.Label();
            this.retrocedeTodo = new System.Windows.Forms.Button();
            this.avanzaTodo = new System.Windows.Forms.Button();
            this.avanza1 = new System.Windows.Forms.Button();
            this.retrocede1 = new System.Windows.Forms.Button();
            this.bBuscar = new System.Windows.Forms.Button();
            this.modifica = new System.Windows.Forms.Button();
            this.baja = new System.Windows.Forms.Button();
            this.alta = new System.Windows.Forms.Button();
            this.textNick = new System.Windows.Forms.TextBox();
            this.Nickname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textApellidos = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.tbCalle = new System.Windows.Forms.TextBox();
            this.calle = new System.Windows.Forms.Label();
            this.tbColonia = new System.Windows.Forms.TextBox();
            this.colonia = new System.Windows.Forms.Label();
            this.tbCelular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // textNombre
            // 
            this.textNombre.Enabled = false;
            this.textNombre.Location = new System.Drawing.Point(214, 119);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(139, 20);
            this.textNombre.TabIndex = 23;
            this.textNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNombre_KeyPress);
            // 
            // textClave
            // 
            this.textClave.Enabled = false;
            this.textClave.Location = new System.Drawing.Point(214, 78);
            this.textClave.Name = "textClave";
            this.textClave.Size = new System.Drawing.Size(52, 20);
            this.textClave.TabIndex = 20;
            this.textClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textClave_KeyPress);
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.BackColor = System.Drawing.Color.Transparent;
            this.Nombre.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.Nombre.Location = new System.Drawing.Point(214, 101);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(57, 14);
            this.Nombre.TabIndex = 17;
            this.Nombre.Text = "*Nombre:";
            // 
            // Clave
            // 
            this.Clave.AutoSize = true;
            this.Clave.BackColor = System.Drawing.Color.Transparent;
            this.Clave.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.Clave.Location = new System.Drawing.Point(212, 61);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(41, 14);
            this.Clave.TabIndex = 16;
            this.Clave.Text = "Clave:";
            // 
            // textCont
            // 
            this.textCont.Enabled = false;
            this.textCont.Location = new System.Drawing.Point(371, 159);
            this.textCont.Name = "textCont";
            this.textCont.Size = new System.Drawing.Size(160, 20);
            this.textCont.TabIndex = 33;
            // 
            // Contrasena
            // 
            this.Contrasena.AutoSize = true;
            this.Contrasena.BackColor = System.Drawing.Color.Transparent;
            this.Contrasena.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.Contrasena.Location = new System.Drawing.Point(371, 141);
            this.Contrasena.Name = "Contrasena";
            this.Contrasena.Size = new System.Drawing.Size(77, 14);
            this.Contrasena.TabIndex = 32;
            this.Contrasena.Text = "*Contraseña:";
            // 
            // retrocedeTodo
            // 
            this.retrocedeTodo.BackColor = System.Drawing.Color.Transparent;
            this.retrocedeTodo.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrocedeTodo.Image = global::Pantallas.Properties.Resources.retrocedetodo;
            this.retrocedeTodo.Location = new System.Drawing.Point(11, 138);
            this.retrocedeTodo.Name = "retrocedeTodo";
            this.retrocedeTodo.Size = new System.Drawing.Size(32, 23);
            this.retrocedeTodo.TabIndex = 42;
            this.retrocedeTodo.UseVisualStyleBackColor = false;
            this.retrocedeTodo.Click += new System.EventHandler(this.retrocedeTodo_Click);
            // 
            // avanzaTodo
            // 
            this.avanzaTodo.BackColor = System.Drawing.Color.Transparent;
            this.avanzaTodo.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avanzaTodo.Image = global::Pantallas.Properties.Resources.avanzaTodo;
            this.avanzaTodo.Location = new System.Drawing.Point(125, 138);
            this.avanzaTodo.Name = "avanzaTodo";
            this.avanzaTodo.Size = new System.Drawing.Size(32, 23);
            this.avanzaTodo.TabIndex = 43;
            this.avanzaTodo.UseVisualStyleBackColor = false;
            this.avanzaTodo.Click += new System.EventHandler(this.avanzaTodo_Click);
            // 
            // avanza1
            // 
            this.avanza1.BackColor = System.Drawing.Color.Transparent;
            this.avanza1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avanza1.Image = global::Pantallas.Properties.Resources.avanza1;
            this.avanza1.Location = new System.Drawing.Point(87, 138);
            this.avanza1.Name = "avanza1";
            this.avanza1.Size = new System.Drawing.Size(32, 23);
            this.avanza1.TabIndex = 44;
            this.avanza1.UseVisualStyleBackColor = false;
            this.avanza1.Click += new System.EventHandler(this.avanza1_Click);
            // 
            // retrocede1
            // 
            this.retrocede1.BackColor = System.Drawing.Color.Transparent;
            this.retrocede1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrocede1.Image = global::Pantallas.Properties.Resources.retrocede1;
            this.retrocede1.Location = new System.Drawing.Point(49, 138);
            this.retrocede1.Name = "retrocede1";
            this.retrocede1.Size = new System.Drawing.Size(32, 23);
            this.retrocede1.TabIndex = 45;
            this.retrocede1.UseVisualStyleBackColor = false;
            this.retrocede1.Click += new System.EventHandler(this.retrocede1_Click);
            // 
            // bBuscar
            // 
            this.bBuscar.Image = ((System.Drawing.Image)(resources.GetObject("bBuscar.Image")));
            this.bBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bBuscar.Location = new System.Drawing.Point(85, 197);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(74, 30);
            this.bBuscar.TabIndex = 104;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = true;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // modifica
            // 
            this.modifica.Image = ((System.Drawing.Image)(resources.GetObject("modifica.Image")));
            this.modifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modifica.Location = new System.Drawing.Point(9, 197);
            this.modifica.Name = "modifica";
            this.modifica.Size = new System.Drawing.Size(74, 30);
            this.modifica.TabIndex = 103;
            this.modifica.Text = "  Modifica";
            this.modifica.UseVisualStyleBackColor = true;
            this.modifica.Click += new System.EventHandler(this.modifica_Click);
            // 
            // baja
            // 
            this.baja.Image = ((System.Drawing.Image)(resources.GetObject("baja.Image")));
            this.baja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.baja.Location = new System.Drawing.Point(85, 165);
            this.baja.Name = "baja";
            this.baja.Size = new System.Drawing.Size(74, 29);
            this.baja.TabIndex = 102;
            this.baja.Text = "Baja";
            this.baja.UseVisualStyleBackColor = true;
            this.baja.Click += new System.EventHandler(this.baja_Click);
            // 
            // alta
            // 
            this.alta.Image = ((System.Drawing.Image)(resources.GetObject("alta.Image")));
            this.alta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.alta.Location = new System.Drawing.Point(9, 165);
            this.alta.Name = "alta";
            this.alta.Size = new System.Drawing.Size(74, 29);
            this.alta.TabIndex = 101;
            this.alta.Text = "Alta";
            this.alta.UseVisualStyleBackColor = true;
            this.alta.Click += new System.EventHandler(this.alta_Click);
            // 
            // textNick
            // 
            this.textNick.Enabled = false;
            this.textNick.Location = new System.Drawing.Point(214, 160);
            this.textNick.Name = "textNick";
            this.textNick.Size = new System.Drawing.Size(117, 20);
            this.textNick.TabIndex = 106;
            // 
            // Nickname
            // 
            this.Nickname.AutoSize = true;
            this.Nickname.BackColor = System.Drawing.Color.Transparent;
            this.Nickname.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.Nickname.Location = new System.Drawing.Point(215, 142);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(68, 14);
            this.Nickname.TabIndex = 105;
            this.Nickname.Text = "*Nickname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label4.Location = new System.Drawing.Point(373, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 108;
            this.label4.Text = "*Apellido:";
            // 
            // textApellidos
            // 
            this.textApellidos.Enabled = false;
            this.textApellidos.Location = new System.Drawing.Point(371, 119);
            this.textApellidos.Name = "textApellidos";
            this.textApellidos.Size = new System.Drawing.Size(139, 20);
            this.textApellidos.TabIndex = 109;
            this.textApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNombre_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(329, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 29);
            this.button1.TabIndex = 110;
            this.button1.Text = "Permisos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(702, 101);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(163, 150);
            this.dataGrid.TabIndex = 111;
            // 
            // tbCalle
            // 
            this.tbCalle.Enabled = false;
            this.tbCalle.Location = new System.Drawing.Point(214, 207);
            this.tbCalle.Name = "tbCalle";
            this.tbCalle.Size = new System.Drawing.Size(117, 20);
            this.tbCalle.TabIndex = 115;
            // 
            // calle
            // 
            this.calle.AutoSize = true;
            this.calle.BackColor = System.Drawing.Color.Transparent;
            this.calle.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.calle.Location = new System.Drawing.Point(215, 189);
            this.calle.Name = "calle";
            this.calle.Size = new System.Drawing.Size(42, 14);
            this.calle.TabIndex = 114;
            this.calle.Text = "*Calle:";
            // 
            // tbColonia
            // 
            this.tbColonia.Enabled = false;
            this.tbColonia.Location = new System.Drawing.Point(372, 206);
            this.tbColonia.Name = "tbColonia";
            this.tbColonia.Size = new System.Drawing.Size(160, 20);
            this.tbColonia.TabIndex = 113;
            // 
            // colonia
            // 
            this.colonia.AutoSize = true;
            this.colonia.BackColor = System.Drawing.Color.Transparent;
            this.colonia.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.colonia.Location = new System.Drawing.Point(371, 188);
            this.colonia.Name = "colonia";
            this.colonia.Size = new System.Drawing.Size(56, 14);
            this.colonia.TabIndex = 112;
            this.colonia.Text = "*Colonia:";
            // 
            // tbCelular
            // 
            this.tbCelular.Enabled = false;
            this.tbCelular.Location = new System.Drawing.Point(214, 262);
            this.tbCelular.Name = "tbCelular";
            this.tbCelular.Size = new System.Drawing.Size(117, 20);
            this.tbCelular.TabIndex = 119;
            this.tbCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textClave_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label1.Location = new System.Drawing.Point(215, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 14);
            this.label1.TabIndex = 118;
            this.label1.Text = "*Celular:";
            // 
            // tbTelefono
            // 
            this.tbTelefono.Enabled = false;
            this.tbTelefono.Location = new System.Drawing.Point(372, 261);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(160, 20);
            this.tbTelefono.TabIndex = 117;
            this.tbTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textClave_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label2.Location = new System.Drawing.Point(371, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 116;
            this.label2.Text = "Telefono:";
            // 
            // tbEmail
            // 
            this.tbEmail.Enabled = false;
            this.tbEmail.Location = new System.Drawing.Point(214, 311);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(117, 20);
            this.tbEmail.TabIndex = 123;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label3.Location = new System.Drawing.Point(216, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 122;
            this.label3.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label5.Location = new System.Drawing.Point(365, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 14);
            this.label5.TabIndex = 124;
            this.label5.Text = "*Campos obligatorios";
            // 
            // Catálogo_de_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Pantallas.Properties.Resources.fondito;
            this.ClientSize = new System.Drawing.Size(563, 409);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCelular);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTelefono);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCalle);
            this.Controls.Add(this.calle);
            this.Controls.Add(this.tbColonia);
            this.Controls.Add(this.colonia);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textApellidos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textNick);
            this.Controls.Add(this.Nickname);
            this.Controls.Add(this.bBuscar);
            this.Controls.Add(this.modifica);
            this.Controls.Add(this.baja);
            this.Controls.Add(this.alta);
            this.Controls.Add(this.retrocede1);
            this.Controls.Add(this.avanza1);
            this.Controls.Add(this.avanzaTodo);
            this.Controls.Add(this.retrocedeTodo);
            this.Controls.Add(this.textCont);
            this.Controls.Add(this.Contrasena);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.textClave);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Clave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Catálogo_de_Usuarios";
            this.Text = "Catálogo de Empleados";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textClave_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textClave;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label Clave;
        private System.Windows.Forms.TextBox textCont;
        private System.Windows.Forms.Label Contrasena;
        private System.Windows.Forms.Button retrocedeTodo;
        private System.Windows.Forms.Button avanzaTodo;
        private System.Windows.Forms.Button avanza1;
        private System.Windows.Forms.Button retrocede1;
        private System.Windows.Forms.Button bBuscar;
        private System.Windows.Forms.Button modifica;
        private System.Windows.Forms.Button baja;
        private System.Windows.Forms.Button alta;
        private System.Windows.Forms.TextBox textNick;
        private System.Windows.Forms.Label Nickname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textApellidos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.TextBox tbCalle;
        private System.Windows.Forms.Label calle;
        private System.Windows.Forms.TextBox tbColonia;
        private System.Windows.Forms.Label colonia;
        private System.Windows.Forms.TextBox tbCelular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}