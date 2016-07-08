namespace Générateur_Projet_BI
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_AjouterClient = new System.Windows.Forms.Button();
            this.btn_VoirClients = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_AjouterCommande = new System.Windows.Forms.Button();
            this.btn_VoirCommande = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(295, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(368, 410);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_VoirClients);
            this.groupBox1.Controls.Add(this.btn_AjouterClient);
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestion des cients";
            // 
            // btn_AjouterClient
            // 
            this.btn_AjouterClient.Location = new System.Drawing.Point(31, 20);
            this.btn_AjouterClient.Name = "btn_AjouterClient";
            this.btn_AjouterClient.Size = new System.Drawing.Size(144, 23);
            this.btn_AjouterClient.TabIndex = 0;
            this.btn_AjouterClient.Text = "Ajouter";
            this.btn_AjouterClient.UseVisualStyleBackColor = true;
            this.btn_AjouterClient.Click += new System.EventHandler(this.btn_AjouterClient_Click);
            // 
            // btn_VoirClients
            // 
            this.btn_VoirClients.Location = new System.Drawing.Point(31, 50);
            this.btn_VoirClients.Name = "btn_VoirClients";
            this.btn_VoirClients.Size = new System.Drawing.Size(144, 23);
            this.btn_VoirClients.TabIndex = 1;
            this.btn_VoirClients.Text = "Visualiser les clients";
            this.btn_VoirClients.UseVisualStyleBackColor = true;
            this.btn_VoirClients.Click += new System.EventHandler(this.btn_VoirClients_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_VoirCommande);
            this.groupBox2.Controls.Add(this.btn_AjouterCommande);
            this.groupBox2.Location = new System.Drawing.Point(35, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestion des commandes";
            // 
            // btn_AjouterCommande
            // 
            this.btn_AjouterCommande.Location = new System.Drawing.Point(31, 20);
            this.btn_AjouterCommande.Name = "btn_AjouterCommande";
            this.btn_AjouterCommande.Size = new System.Drawing.Size(144, 23);
            this.btn_AjouterCommande.TabIndex = 0;
            this.btn_AjouterCommande.Text = "Ajouter";
            this.btn_AjouterCommande.UseVisualStyleBackColor = true;
            this.btn_AjouterCommande.Click += new System.EventHandler(this.btn_AjouterCommande_Click);
            // 
            // btn_VoirCommande
            // 
            this.btn_VoirCommande.Location = new System.Drawing.Point(31, 50);
            this.btn_VoirCommande.Name = "btn_VoirCommande";
            this.btn_VoirCommande.Size = new System.Drawing.Size(144, 23);
            this.btn_VoirCommande.TabIndex = 1;
            this.btn_VoirCommande.Text = "Visualiser les commandes";
            this.btn_VoirCommande.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 434);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_VoirClients;
        private System.Windows.Forms.Button btn_AjouterClient;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_VoirCommande;
        private System.Windows.Forms.Button btn_AjouterCommande;
    }
}

