using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Administration;
using Fabrication;

namespace Générateur_Projet_BI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Clients methods
        public void SelectClients()
        {
            List<Client> listeClients = new List<Client>();
            listeClients = Client.GetClientsFromDataBase();
            int i = 0;
            foreach (Client cli in listeClients)
            {
                textBox1.AppendText("Nom : " + cli.Nom);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("Prénom : " + cli.Prenom);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("Pays : " + cli.Pays);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText(Environment.NewLine);

                i++;
                if (i > 20) break;
            }
        }

        public void GenerateClients(int nombreClients)
        {
            List<Client> listeClients = new List<Client>();
            listeClients = Client.GenerateRandomClients(nombreClients);
        }
        #endregion

        #region Commandes methods
        public void SelectCommandes()
        {
            List<CommandeAdministration> listeCommandes = new List<CommandeAdministration>();
            listeCommandes = CommandeAdministration.GetCommandesFromDataBase();
            foreach (CommandeAdministration com in listeCommandes)
            {
                textBox1.AppendText(com.Reference);
                textBox1.AppendText(Environment.NewLine);
            }
        }

        public void GenerateCommandes(int nombreCommandes)
        {
            if (ProduitAdministration.GetProduitsFromDataBase() == null)
                MessageBox.Show("Can't create commandes, no products in database.");
            else
                CommandeAdministration.GenerateRandomCommandes(nombreCommandes);
        }
        #endregion

        private void btn_AjouterClient_Click(object sender, EventArgs e)
        {
            int nombreClients = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Entrez le nombre de clients désiré", "Nombre de clients", "10"));
            if (nombreClients > 0) GenerateClients(nombreClients);
            else MessageBox.Show("Veuillez entrer un nombre valide.");
        }

        private void btn_VoirClients_Click(object sender, EventArgs e)
        {
            SelectClients();
        }

        private void btn_AjouterCommande_Click(object sender, EventArgs e)
        {
            int nombreCommandes = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Entrez le nombre de commandes désiré", "Nombre de commandes", "10"));
            GenerateCommandes(nombreCommandes);
        }
    }
}