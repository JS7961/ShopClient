using ShopClient.Model;
using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopClient.Data
{
    public static class Client
    {


        

            static SimpleTcpClient Client1;

        static string Exepfad = System.Reflection.Assembly.GetExecutingAssembly().Location;


        static string Pfad = "";

        public static bool Bereit;





        static  Client()
            {

            Exepfad = Abschneiden(Exepfad);

            Pfad = Exepfad + "IP.dat";

            

            if (File.Exists(Pfad))
            {
                StreamReader sr = new StreamReader(Pfad);

                string ip = sr.ReadLine();

                sr.Close();

                ClientInit(ip);
                Bereit = true;
            }
            else
            {
                string ip = "127.0.0.1:9000";
                ClientInit(ip);
                Bereit = true;                  
            }

            
                              
            }


            public static void Connect()
            {
                try
                {
                    Client1.Connect();               
                }
                catch (Exception)
                {
                MessageBox.Show("\n Keine Verbindung \n");

                }
            }

            public static void Senden(string wort)
            {
                if (Client1.IsConnected == true)
                {
                    Client1.Send(wort);
                }
                else
                {
                MessageBox.Show(" \n Nicht gesendet \n");
                }
            }

            static void ClientInit(string Ip)
            {
            //Client1 = new SimpleTcpClient("127.0.0.1:9000");

            Client1 = new SimpleTcpClient(Ip);

            Client1.Events.Connected += Events_Connected;
                Client1.Events.DataReceived += Events_DataReceived;
                Client1.Events.Disconnected += Events_Disconnected;
            }


            static private void Events_Disconnected(object? sender, ConnectionEventArgs e)
            {

            }

            static private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
            {
                string Anfrage = "";
                Anfrage = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count);
            AnfrageErmitteln(Anfrage);
                
            }

            static private void Events_Connected(object? sender, ConnectionEventArgs e)
            {
                
            }




        public static void ProduktListeAnfragen()
        {
            Connect();
            Senden("Produktliste1");
        }

        static void AnfrageErmitteln(string Anfrage)
        {

            //MessageBox.Show(Anfrage);

            string zeile = "\n";
            int zeileanfang = 0;
            List<string> Nachricht = new List<string>();

            if (Anfrage[Anfrage.Length - 1] != zeile[0])
            {
                Anfrage += zeile;
            }

            for (int i = 0; i < Anfrage.Length; i++)
            {

                if (Anfrage[i] == zeile[0])
                {
                    Nachricht.Add(Anfrage.Substring(zeileanfang, (i - zeileanfang)));
                    zeileanfang = i + 1;

                }

            }

            


            if (Nachricht[0] == "Produktliste")
            {
                ProduktListeErstellen(Nachricht);
            }
        }


        static void ProduktListeErstellen(List<string> Nachricht)
        {
            int offset = 2,k=0;

            List<Item> Itemliste = new List<Item>();

            

            for (int i = 0; i < Convert.ToInt32(Nachricht[1]); i++)
            {
                k = (i*3) + offset;

                Itemliste.Add( new Item(Convert.ToInt32(Nachricht[k]), Nachricht[k + 1], Convert.ToDecimal(Nachricht[k + 2]) )  );
            }


            

            Produkte.ItemListe.Clear();

            for (int i = 0; i < Itemliste.Count; i++)
            {
                Produkte.ItemListe.Add(Itemliste[i]);
            }

            
        }

        public static bool Verbunden()
        {
            return Client1.IsConnected;                    
        }



        static string Abschneiden(string wort)
        {
            string sl = @"\";
            for (int i = wort.Length - 1; i > 0; i--)
            {
                if (wort[i] == sl[0])
                {
                    return wort.Substring(0, i + 1);
                }
            }

            return wort;
        }



    }
}
