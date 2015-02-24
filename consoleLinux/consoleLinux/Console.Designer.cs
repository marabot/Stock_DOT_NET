namespace consoleLinux
{
    partial class Console
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.send = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.Disconnect = new System.Windows.Forms.Button();
            this.su = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(731, 29);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 0;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(35, 32);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(635, 20);
            this.input.TabIndex = 1;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(47, 140);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(623, 338);
            this.output.TabIndex = 2;
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(762, 153);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 3;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // Disconnect
            // 
            this.Disconnect.Enabled = false;
            this.Disconnect.Location = new System.Drawing.Point(762, 192);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(75, 23);
            this.Disconnect.TabIndex = 4;
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // su
            // 
            this.su.Location = new System.Drawing.Point(731, 278);
            this.su.Name = "su";
            this.su.Size = new System.Drawing.Size(122, 23);
            this.su.TabIndex = 5;
            this.su.Text = "Super Utilisateur";
            this.su.UseVisualStyleBackColor = true;
            this.su.Click += new System.EventHandler(this.su_Click);
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 562);
            this.Controls.Add(this.su);
            this.Controls.Add(this.Disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.Controls.Add(this.send);
            this.Name = "Console";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button Disconnect;
        private System.Windows.Forms.Button su;
    }
}

