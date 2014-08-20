using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace BOSucht
{
    public class Berater
    {

        // FELDER bzw. VARIABLEN *********************************************************************************************
        private String beraterID = "";
        private String vorname;
        private String nachname;
        private String adresse;
        private String plz;
        private String ort;
        private String telnr;
        private String mobilnr;
       

        // PROPERTIES *********************************************************************************************
        public String BeraterID
        {
            get { return beraterID; }
            set { beraterID = value; }
        }

        public String Vorname
        {
            get { return vorname; }
            set { vorname = value; }
        }

        public String Nachname
        {
            get { return nachname; }
            set { nachname = value; }
        }

        public String Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public String Plz
        {
            get { return plz; }
            set { plz = value; }
        }

        public String Ort
        {
            get { return ort; }
            set { ort = value; }
        }

        public String Telnr
        {
            get { return telnr; }
            set { telnr = value; }
        }

        public String Mobilnr
        {
            get { return mobilnr; }
            set { mobilnr = value; }
        }

       

        public bool saveBerater()
        {
            
                //neuer Record -> INSERT
                string SQL = "insert into berater (beraterID, vorname, nachname, adresse, " +
                                                 "plz, ort, telnr, mobilnr " +
                                                 ")" +
                                          "values (@beraterID, @vorname, @nachname, @adresse, " +
                                                  "@plz, @ort, @telnr, @mobilnr " +
                                                  ");";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();

                //GUID für ID erzeugen und als String zurückgeben (weil mID=="")!

                //beraterID = Guid.NewGuid().ToString();

                //Die Parameter in SQL-String mit Werten versehen...

                cmd.Parameters.Add(new SqlParameter("beraterID", beraterID));
                cmd.Parameters.Add(new SqlParameter("vorname", vorname));
                cmd.Parameters.Add(new SqlParameter("nachname", nachname));
                cmd.Parameters.Add(new SqlParameter("adresse", adresse));
                cmd.Parameters.Add(new SqlParameter("plz", plz));
                cmd.Parameters.Add(new SqlParameter("ort", ort));
                cmd.Parameters.Add(new SqlParameter("telnr", telnr));
                cmd.Parameters.Add(new SqlParameter("mobilnr", mobilnr));
               

                // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
                return (cmd.ExecuteNonQuery() > 0); //hat der INSERT geklappt, sollte genau ein Record verändert worden sein
          
        }

        // Laden eines Kundenobjekts - wird von BOMail.getKunde() aufgerufen
        internal static Berater getBeraterByID(string beraterID)
        {
            if (beraterID == null)
            {
                beraterID = "0";
            }

            string sql = "SELECT beraterID, vorname, nachname, adresse, " +
                         "plz, ort, telnr, mobilnr " +
                         "FROM berater " +
                         "WHERE beraterID=@id " +
                         "ORDER BY nachname, vorname DESC;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();
            cmd.Parameters.Add(new SqlParameter("id", beraterID));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                return fillBeraterFromSQLDataReader(reader);
            }
            else
                return null;
        }

        internal static DieBerater getBeraterByName(string name)
        {
            throw new NotImplementedException();
        }

        // Laden aller Kunden als Liste von Objekten
        internal static DieBerater getAllBerater()
        {
            // Schnellvariante, wie oben aber alles in einer Zeile....
            string sql = "SELECT beraterID, vorname, nachname, adresse, " +
                         "plz, ort, telnr, mobilnr " +
                         "FROM berater " +
                         "ORDER BY nachname, vorname DESC;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();

            SqlDataReader reader = cmd.ExecuteReader();
            DieBerater alleBerater = new DieBerater(); //initialisiere lehre Liste
            while (reader.Read())
            {
                Berater einBerater = fillBeraterFromSQLDataReader(reader);
                alleBerater.Add(einBerater);
            }
            return alleBerater;
        }

        // Hilfsfunktion für die beiden oberen Methoden
        private static Berater fillBeraterFromSQLDataReader(SqlDataReader reader)
        {
            Berater einBerater = new Berater();

            einBerater.beraterID = reader.GetGuid(0).ToString();
            einBerater.vorname = reader.GetString(1);
            einBerater.nachname = reader.GetString(2);
            einBerater.adresse = reader.GetString(3);
            einBerater.plz = reader.GetString(4);
            einBerater.ort = reader.GetString(5);
            einBerater.telnr = reader.GetString(6);
            einBerater.mobilnr = reader.GetString(7);

            return einBerater;
        }

        //Nicht erforderlich das löschbar
        /*internal bool deleteBerater()
        {
            if (beraterID != "")
            {

                

                string SQL = "delete berater where beraterID = @beraterID;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();
                cmd.Parameters.Add(new SqlParameter("beraterID", beraterID));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    beraterID = ""; //das Objekt existiert weiter - es verhält sich aber wieder wie ein neuer Kunde
                    return true;
                }
                else return false; //Löschen aus DB klappt nicht...
            }
            else return true; // Kunde hat keine ID??? -> war noch gar nicht gespeichert.
            // wenn er nicht gespeichert war, kann man ihn auch nicht löschen,
            // aber jedenfalls ist er auch nicht in der DB, also sagen wir halt true :-)
        }*/

       
    }
}
