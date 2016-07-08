using System;
using System.Collections.Generic;
using RandomNameGeneratorLibrary;
using System.Data;
using System.Reflection;

namespace Administration
{
    public class Client
    {
        #region Attributes
        private const int NOMBRE_DE_GENERATIONS = 10000;
        private static Random random = new Random();
        private static PersonNameGenerator generator = new PersonNameGenerator();
        private static List<string> listePays = new List<string>();
        #endregion

        #region Constructors
        public Client()
        {
            Civilite = RandomCivilite();
            Nom = generator.GenerateRandomLastName();
            Prenom = Civilite == "M" ? generator.GenerateRandomMaleFirstName() : generator.GenerateRandomFemaleFirstName();
            Age = random.Next(18, 80);
            Adresse = GenerateAdress();
            Ville = "";
            Pays = RandomPays();
        }

        public Client(bool selectFromDB)
        {

        }
        #endregion

        #region Random methods
        private string GenerateAdress()
        {
            return random.Next(1, 100).ToString() + " rue " + generator.GenerateRandomFirstName() + " " + generator.GenerateRandomLastName();
        }

        public string RandomCivilite()
        {
            return random.Next(0, 2) == 0 ? "M" : "F";
        }

        public string RandomPays()
        {
            return listePays[random.Next(listePays.Count)];
        }
        #endregion

        #region Getters and setters
        public int? Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Civilite { get; set; }
        public int Age { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        #endregion

        #region Methods for DB
        public static List<Client> GenerateRandomClients(int nombreClients)
        {
            #region Pays
            listePays.Add("Afghanistan");
            listePays.Add("Afrique Du Sud");
            listePays.Add("Albanie");
            listePays.Add("Algérie");
            listePays.Add("Allemagne");
            listePays.Add("Andorre");
            listePays.Add("Angola");
            listePays.Add("Antigua-Et-Barbuda");
            listePays.Add("Arabie Saoudite");
            listePays.Add("Argentine");
            listePays.Add("Arménie");
            listePays.Add("Australie");
            listePays.Add("Autriche");
            listePays.Add("Azerbaïdjan");
            listePays.Add("Bahamas");
            listePays.Add("Bahreïn");
            listePays.Add("Bangladesh");
            listePays.Add("Barbade");
            listePays.Add("Belau");
            listePays.Add("Belgique");
            listePays.Add("Belize");
            listePays.Add("Bénin");
            listePays.Add("Bhoutan");
            listePays.Add("Biélorussie");
            listePays.Add("Birmanie");
            listePays.Add("Bolivie");
            listePays.Add("Bosnie-Herzégovine");
            listePays.Add("Botswana");
            listePays.Add("Brésil");
            listePays.Add("Brunei");
            listePays.Add("Bulgarie");
            listePays.Add("Burkina Faso");
            listePays.Add("Burundi");
            listePays.Add("Cambodge");
            listePays.Add("Cameroun");
            listePays.Add("Canada");
            listePays.Add("Cap-Vert");
            listePays.Add("Centrafrique");
            listePays.Add("Chili");
            listePays.Add("Chine");
            listePays.Add("Chypre");
            listePays.Add("Colombie");
            listePays.Add("Comores");
            listePays.Add("Congo-Brazzaville");
            listePays.Add("République Démocratique Du Congo");
            listePays.Add("Corée Du Nord");
            listePays.Add("Corée Du Sud");
            listePays.Add("Costa Rica");
            listePays.Add("Côte d Ivoire");
            listePays.Add("Croatie");
            listePays.Add("Cuba");
            listePays.Add("Danemark");
            listePays.Add("Djibouti");
            listePays.Add("Dominique");
            listePays.Add("Egypte");
            listePays.Add("Emirats Arabes Unis");
            listePays.Add("Equateur");
            listePays.Add("Erythrée");
            listePays.Add("Espagne");
            listePays.Add("Estonie");
            listePays.Add("Etats-Unis");
            listePays.Add("Ethiopie");
            listePays.Add("Fidji");
            listePays.Add("Finlande");
            listePays.Add("France");
            listePays.Add("Gabon");
            listePays.Add("Gambie");
            listePays.Add("Géorgie");
            listePays.Add("Ghana");
            listePays.Add("Grèce");
            listePays.Add("Grenade");
            listePays.Add("Guatemala");
            listePays.Add("Guinée-Bissau");
            listePays.Add("Guinée-Conakry");
            listePays.Add("Guinée Equatoriale");
            listePays.Add("Guyana");
            listePays.Add("Haiti");
            listePays.Add("Honduras");
            listePays.Add("Hongrie");
            listePays.Add("Inde");
            listePays.Add("Indonésie");
            listePays.Add("Irak");
            listePays.Add("Iran");
            listePays.Add("Irlande");
            listePays.Add("Islande");
            listePays.Add("Israel");
            listePays.Add("Italie");
            listePays.Add("Jamaique");
            listePays.Add("Japon");
            listePays.Add("Jordanie");
            listePays.Add("Kazakhstan");
            listePays.Add("Kenya");
            listePays.Add("Kirghizistan");
            listePays.Add("Kiribati");
            listePays.Add("Kosovo");
            listePays.Add("Koweit");
            listePays.Add("Laos");
            listePays.Add("Lesotho");
            listePays.Add("Lettonie");
            listePays.Add("Liban");
            listePays.Add("Liberia");
            listePays.Add("Libye");
            listePays.Add("Liechtenstein");
            listePays.Add("Lituanie");
            listePays.Add("Luxembourg");
            listePays.Add("Macédoine");
            listePays.Add("Madagascar");
            listePays.Add("Malaisie");
            listePays.Add("Malawi");
            listePays.Add("Maldives");
            listePays.Add("Mali");
            listePays.Add("Malte");
            listePays.Add("Maroc");
            listePays.Add("Marshall");
            listePays.Add("Ile Maurice");
            listePays.Add("Mauritanie");
            listePays.Add("Mexique");
            listePays.Add("Micronésie");
            listePays.Add("Moldavie");
            listePays.Add("Monaco");
            listePays.Add("Mongolie");
            listePays.Add("Monténégro");
            listePays.Add("Mozambique");
            listePays.Add("Namibie");
            listePays.Add("Nauru");
            listePays.Add("Népal");
            listePays.Add("Nicaragua");
            listePays.Add("Niger");
            listePays.Add("Nigéria");
            listePays.Add("Norvège");
            listePays.Add("Nouvelle Zélande");
            listePays.Add("Oman");
            listePays.Add("Ouganda");
            listePays.Add("Ouzbékistan");
            listePays.Add("Pakistan");
            listePays.Add("Panama");
            listePays.Add("Papouasie-Nouvelle-Guinée");
            listePays.Add("Paraguay");
            listePays.Add("Pays-Bas");
            listePays.Add("Pérou");
            listePays.Add("Philippines");
            listePays.Add("Pologne");
            listePays.Add("Portugal");
            listePays.Add("Qatar");
            listePays.Add("République Dominicaine");
            listePays.Add("République Tchèque");
            listePays.Add("Roumanie");
            listePays.Add("Royaume-Uni");
            listePays.Add("Russie");
            listePays.Add("Rwanda");
            listePays.Add("Saint-Christophe-Et-Niévès");
            listePays.Add("Sainte-Lucie");
            listePays.Add("Saint-Marin");
            listePays.Add("Saint-Vincent-Et-Les-Grenadines");
            listePays.Add("Iles Salomon");
            listePays.Add("Sao-Tome-Et-Principe");
            listePays.Add("Salvador");
            listePays.Add("Samoa");
            listePays.Add("Sénégal");
            listePays.Add("Serbie");
            listePays.Add("Seychelles");
            listePays.Add("Sierra Leone");
            listePays.Add("Singapour");
            listePays.Add("Slovénie");
            listePays.Add("Slovaquie");
            listePays.Add("Somalie");
            listePays.Add("Soudan");
            listePays.Add("Sri Lanka");
            listePays.Add("Suède");
            listePays.Add("Suisse");
            listePays.Add("Surinam");
            listePays.Add("Swaziland");
            listePays.Add("Syrie");
            listePays.Add("Tadjikistan");
            listePays.Add("Tanzanie");
            listePays.Add("Tchad");
            listePays.Add("Timor Oriental");
            listePays.Add("Thailande");
            listePays.Add("Togo");
            listePays.Add("Tonga");
            listePays.Add("Trinité-Et-Tobago");
            listePays.Add("Tunisie");
            listePays.Add("Turkménistan");
            listePays.Add("Turquie");
            listePays.Add("Tuvalu");
            listePays.Add("Ukraine");
            listePays.Add("Uruguay");
            listePays.Add("Vanuatu");
            listePays.Add("Vatican");
            listePays.Add("Venezuela");
            listePays.Add("Vietnam");
            listePays.Add("Yémen");
            listePays.Add("Zambie");
            listePays.Add("Zimbabwe");
            #endregion
            List<Client> listeClients = new List<Client>();

            for (int i = 0; i < nombreClients; i++)
            {
                listeClients.Add(new Client());
            }
            DBConnect connect = new Administration.DBConnect();
            connect.InsertDT(CreateDataTable(listeClients), "client");
            Expédition.DBConnect connect2 = new Expédition.DBConnect();
            connect2.InsertDT(CreateDataTable(listeClients), "client");
            return listeClients;
        }
        public static List<Client> GetClientsFromDataBase()
        {
            List<Client> listeClients = new List<Client>();

            Administration.DBConnect connect = new Administration.DBConnect();
            listeClients = connect.SelectClient();

            return listeClients;
        }
        #endregion

        #region DataTable
        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dt = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dt.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] value = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    value[i] = properties[i].GetValue(entity);
                }
                dt.Rows.Add(value);
            }
            return dt;
        }
        #endregion
    }
}
