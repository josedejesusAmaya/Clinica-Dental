namespace Pantallas
{
    partial class Administrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrador));
            this.cerrarSesiónA = new System.Windows.Forms.Button();
            this.CPacientes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cerrarSesiónA
            // 
            this.cerrarSesiónA.BackColor = System.Drawing.Color.Transparent;
            this.cerrarSesiónA.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrarSesiónA.Location = new System.Drawing.Point(27, 163);
            this.cerrarSesiónA.Name = "cerrarSesiónA";
            this.cerrarSesiónA.Size = new System.Drawing.Size(107, 23);
            this.cerrarSesiónA.TabIndex = 6;
            this.cerrarSesiónA.Text = "Cerrar Sesión";
            this.cerrarSesiónA.UseVisualStyleBackColor = false;
            this.cerrarSesiónA.Click += new System.EventHandler(this.cerrarSesiónA_Click);
            // 
            // CPacientes
            // 
            this.CPacientes.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.CPacientes.Location = new System.Drawing.Point(262, 101);
            this.CPacientes.Name = "CPacientes";
            this.CPacientes.Size = new System.Drawing.Size(185, 23);
            this.CPacientes.TabIndex = 16;
            this.CPacientes.Text = "Catálogo Pacientes";
            this.CPacientes.UseVisualStyleBackColor = true;
            this.CPacientes.Click += new System.EventHandler(this.CPacientes_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(27, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Perfil";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.button2.Location = new System.Drawing.Point(262, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Catálogo Empleados";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.button4.Location = new System.Drawing.Point(262, 134);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "Citas";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(578, 211);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CPacientes);
            this.Controls.Add(this.cerrarSesiónA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Administrador";
            this.Text = "Administrador";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cerrarSesiónA;
        private System.Windows.Forms.Button CPacientes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}