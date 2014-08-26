using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace BOSucht
{
    public static class Start
    {

        /********************************Globale Einstellungen für die Seite**********************************************/
        static readonly string path_image = "/upload/img/";
        static readonly string path_anhang = "/upload/anhang/";
        static readonly string[] beratungsarten = { "Drogen", "Missbrauch", "Suizid", "..." };

        /********************************Texte**********************************************/
        static readonly string keineBeratung = "Beratung nicht gefunden - Sie können einen neue Beratung anlegen!";


        /********************************Properties**********************************************/
        public static string Path_image
        {
            get { return path_image; }
        }

        public static string Path_anhang
        {
            get { return path_anhang; }
        }

        public static string[] Beratungsarten
        {
            get { return Start.beratungsarten; }
        }

        public static string KeineBeratung
        {
            get { return Start.keineBeratung; }
        }


        /********************************Klient**********************************************/
        static public Klient newKlient()
        {
            return new Klient();
        }

        static public Klient getKlientByID(String ID)
        {
            return Klient.getKlientByID(ID);
        }

        static public Klienten getAllKlients()
        {
            return Klient.getAllKlients();
        }

        static public Klienten getKlientenByName(String vorname, String nachname)
        {
            return Klient.getKlientenByName(vorname, nachname);
        }

        /********************************Beratungen****************************************/
        static public BOSucht.Beratung newBeratung()
        {
            return new BOSucht.Beratung();
        }

        static public BOSucht.Beratung getBeratungByID(string beratungsID)
        {
            return BOSucht.Beratung.getBeratungByID(beratungsID);
        }

        static public Beratungen getAllBeratungen()
        {
            return Beratung.getAllBeratungen();
        }

        static public Beratungen getBeratungenbyKlient(string klientID)
        {
            return Beratung.getBeratungenByKlient(klientID);
        }

        /********************************Berater*************************************************/
        static public Berater newBerater()
        {
            return new Berater();
        }

        static public Berater getBeraterByID(string beraterID)
        {
            return Berater.getBeraterByID(beraterID);
        }

        static public DieBerater getAllBerater()
        {
            return Berater.getAllBerater();
        }

        static public DieBerater getBeraterByName(string name)
        {
            return Berater.getBeraterByName(name);
        }

        /********************************Beratungsthemen****************************************/
        static public Beratungsthema newBeratungsthema()
        {
            return new Beratungsthema();
        }

        public static Beratungsthemen getBeratungsThemenByBeratungsID(string beratungsID)
        {
            return Beratungsthema.getThemenByBeratungsID(beratungsID);
        }

        public static Beratungsthemen newBeratungsthemen()
        {
            return new Beratungsthemen();
        }

        /********************************Thema****************************************/
        public static Thema newThema()
        {
            return new Thema();
        }

        static public BOSucht.Themen getAllThemen()
        {
            return BOSucht.Thema.getAllThemen();
        }


        static public void login()
        {
            throw new System.NotImplementedException();
        }

        /********************************Datenbank****************************************/
        // Hilfsmethode, die eine Verbindung zur DB erzeugt und retourniert.
        static internal SqlConnection GetConnection()
        {

            // Hinweis: das @ am Anfang von Strings verhindert das Sonder- und Escapezeichen interpretiert werden.

            //Variante 1: DB File direkt angeben
            //Vorteil: Man spart sich das Registrieren der DB im SQL Manager
            //Nachteil: Pfad zur DB hardcoded - sollte besser in Web-Config gemacht werden

            //string conString = @"Data Source=localhost\SQLEXPRESS;AttachDbFilename=C:\projects\Kundenverwaltung2010\DB\KundenDB4.mdf;Integrated Security=True;Connect Timeout=30;User Instance=False";

            //Variante 2: wie oben, aber der Pfad wird aus dem absoluten App-Pfad und der relativen Position des DB-Files berechnet.
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
            string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + String.Join(@"\", dirs) + "\\BOSucht" + @"\suchtdb.mdf;Integrated Security=True;Connect Timeout=5";

            //Variante 3: DBFile mit SQL Server Manager Express im SQL-Server registrieren und den "Kurznamen aus dem SQL Manager angeben
            //Vorteil: nur ein logischer Name - Name und Pfad der DB kann verändert werden (SQL Manager)
            //Nachteil: App kann nicht mit Copy&Paste auf den Zielserver verschoben werden, da DB regstriert werden muss.
            //string conString = @"Data Source=localhost\SQLEXPRESS;Database=KundenDB4;Integrated Security=true;Integrated Security=True;Connect Timeout=30";

            // weitere Varianten:
            // man könnte den Conectionstring auch in eine externe Konfigurationsdatei schreioben und von dort auslesen...

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            return con;
        }



        
    }
}
