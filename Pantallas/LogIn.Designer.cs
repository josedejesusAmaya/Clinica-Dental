namespace Pantallas
{
    partial class LogIn
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.Usuario = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.iniciaSesion = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.BackColor = System.Drawing.Color.Transparent;
            this.Usuario.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario.Location = new System.Drawing.Point(66, 147);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(64, 17);
            this.Usuario.TabIndex = 9;
            this.Usuario.Text = "Usuario";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.BackColor = System.Drawing.Color.Transparent;
            this.Password.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(66, 240);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(88, 17);
            this.Password.TabIndex = 10;
            this.Password.Text = "Contraseña";
            // 
            // textUser
            // 
            this.textUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUser.Location = new System.Drawing.Point(69, 180);
            this.textUser.MaxLength = 19;
            this.textUser.Multiline = true;
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(236, 38);
            this.textUser.TabIndex = 13;
            // 
            // textPass
            // 
            this.textPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPass.Location = new System.Drawing.Point(69, 271);
            this.textPass.Multiline = true;
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.Size = new System.Drawing.Size(236, 38);
            this.textPass.TabIndex = 14;
            // 
            // iniciaSesion
            // 
            this.iniciaSesion.Font = new System.Drawing.Font("Lucida Sans", 8.25F);
            this.iniciaSesion.Location = new System.Drawing.Point(86, 338);
            this.iniciaSesion.Name = "iniciaSesion";
            this.iniciaSesion.Size = new System.Drawing.Size(192, 45);
            this.iniciaSesion.TabIndex = 15;
            this.iniciaSesion.Text = "Iniciar Sesión";
            this.iniciaSesion.UseVisualStyleBackColor = true;
            this.iniciaSesion.Click += new System.EventHandler(this.iniciaSesion_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(412, 14);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(240, 150);
            this.dataGrid.TabIndex = 16;
            this.dataGrid.Visible = false;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Pantallas.Properties.Resources.logIn;
            this.ClientSize = new System.Drawing.Size(409, 433);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.iniciaSesion);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Usuario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogIn";
            this.Text = "Log In";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Button iniciaSesion;
        private System.Windows.Forms.DataGridView dataGrid;
    }
}

