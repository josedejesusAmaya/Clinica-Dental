namespace Pantallas
{
    partial class Buscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buscar));
            this.textPorClave = new System.Windows.Forms.TextBox();
            this.textPorNombre = new System.Windows.Forms.TextBox();
            this.bAceptar = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.Label();
            this.Clave = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textPorApellido = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textPorClave
            // 
            this.textPorClave.Location = new System.Drawing.Point(278, 26);
            this.textPorClave.Name = "textPorClave";
            this.textPorClave.Size = new System.Drawing.Size(67, 20);
            this.textPorClave.TabIndex = 73;
            // 
            // textPorNombre
            // 
            this.textPorNombre.Location = new System.Drawing.Point(278, 56);
            this.textPorNombre.Name = "textPorNombre";
            this.textPorNombre.Size = new System.Drawing.Size(116, 20);
            this.textPorNombre.TabIndex = 74;
            this.textPorNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPorApellido_KeyPress);
            // 
            // bAceptar
            // 
            this.bAceptar.BackColor = System.Drawing.Color.Transparent;
            this.bAceptar.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAceptar.Location = new System.Drawing.Point(256, 131);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(107, 23);
            this.bAceptar.TabIndex = 77;
            this.bAceptar.Text = "Aceptar";
            this.bAceptar.UseVisualStyleBackColor = false;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.BackColor = System.Drawing.Color.Transparent;
            this.Nombre.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.Nombre.Location = new System.Drawing.Point(206, 57);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(49, 14);
            this.Nombre.TabIndex = 80;
            this.Nombre.Text = "Nombre";
            // 
            // Clave
            // 
            this.Clave.AutoSize = true;
            this.Clave.BackColor = System.Drawing.Color.Transparent;
            this.Clave.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.Clave.Location = new System.Drawing.Point(206, 29);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(38, 14);
            this.Clave.TabIndex = 79;
            this.Clave.Text = "Clave";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.label1.Location = new System.Drawing.Point(206, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 82;
            this.label1.Text = "Apellido";
            // 
            // textPorApellido
            // 
            this.textPorApellido.Location = new System.Drawing.Point(278, 86);
            this.textPorApellido.Name = "textPorApellido";
            this.textPorApellido.Size = new System.Drawing.Size(116, 20);
            this.textPorApellido.TabIndex = 81;
            this.textPorApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPorApellido_KeyPress);
            // 
            // Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Pantallas.Properties.Resources.fondito;
            this.ClientSize = new System.Drawing.Size(483, 174);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPorApellido);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Clave);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.textPorNombre);
            this.Controls.Add(this.textPorClave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Buscar";
            this.Text = "Buscar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textPorClave;
        private System.Windows.Forms.TextBox textPorNombre;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label Clave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPorApellido;
    }
}