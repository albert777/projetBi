using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administration;

namespace Générateur_Projet_BI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //SelectClients();
            //GenerateClients();

            //SelectCommandes();
            //GenerateCommandes();
        }

        #region Clients methods
        public void SelectClients()
        {
            List<Client> listeClients = new List<Client>();
            listeClients = Client.GetClientsFromDataBase();
            foreach (Client cli in listeClients)
            {
                textBox1.AppendText(cli.Pays);
                textBox1.AppendText(Environment.NewLine);
            }
        }

        public void GenerateClients()
        {
            List<Client> listeClients = new List<Client>();
            listeClients = Client.GenerateRandomClients();
        }
        #endregion

        #region Commandes methods
        public void SelectCommandes()
        {
            List<Commande> listeCommandes = new List<Commande>();
            listeCommandes = Commande.GetCommandesFromDataBase();
            foreach (Commande com in listeCommandes)
            {
                textBox1.AppendText(com.Reference);
                textBox1.AppendText(Environment.NewLine);
            }
        }

        public void GenerateCommandes()
        {
            if (Produit.GetProduitsFromDataBase() == null)
                throw new Exception("Can't create commandes, no products in database.");
            List<Commande> listeCommandes = new List<Commande>();
            listeCommandes = Commande.GenerateRandomCommandes();
        }
        #endregion
    }
}