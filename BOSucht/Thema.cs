using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;


namespace BOSucht
{
    public class Thema
    {

        // FELDER bzw. VARIABLEN *********************************************************************************************
        private string themenID = "";
        private String titel = "";

        // PROPERTIES *********************************************************************************************
        public string ThemenID
        {
            get { return themenID; }
            internal set { themenID = value; }
        }

        public String Titel
        {
            get { return titel; }
            set { titel = value; }
        }

        public bool saveThema()
        {
            if (themenID == "")
            {
                //neuer Record -> INSERT
                string SQL = "insert into ThemenID (themenID, titel)" +
                                          "values (@themenID, @titel);";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();

                //GUID für ID erzeugen und als String zurückgeben (weil mID=="")!

                themenID = Guid.NewGuid().ToString();

                //Die Parameter in SQL-String mit Werten versehen...

                cmd.Parameters.Add(new SqlParameter("themenID", themenID));
                cmd.Parameters.Add(new SqlParameter("titel", titel));

                // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
                return (cmd.ExecuteNonQuery() > 0); //hat der INSERT geklappt, sollte genau ein Record verändert worden sein
            }
            return false;
        }

        public bool deleteThema()
        {
            if (themenID != "")
            {
                string SQL = "delete ThemenID where themenID = @themenID and titel=@titel;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();

                cmd.Parameters.Add(new SqlParameter("themenID", themenID));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    themenID = "";
                    return true;
                }
                else return false; //Löschen aus DB klappt nicht...
            }
            else return true; // Kunde hat keine ID??? -> war noch gar nicht gespeichert.
            // wenn er nicht gespeichert war, kann man ihn auch nicht löschen,
            // aber jedenfalls ist er auch nicht in der DB, also sagen wir halt true :-)

        }

        // Laden aller Kunden als Liste von Objekten
        internal static Themen getAllThemen()
        {
            // Schnellvariante, wie oben aber alles in einer Zeile....
            string sql = "SELECT themenID, titel " +
                         "FROM ThemenID  " +
                         "ORDER BY titel";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();

            SqlDataReader reader = cmd.ExecuteReader();
            Themen alleThemen = new Themen(); //initialisiere lehre Liste
            while (reader.Read())
            {
                Thema einThema = fillThemaFromSQLDataReader(reader);
                alleThemen.Add(einThema);
            }
            return alleThemen;
        }

        internal static Thema getTitleByBThemaID(string themaID)
        {
            if (themaID == null)
            {
                themaID = "0";
            }

            string sql = "SELECT themenID, titel " +
                                "FROM ThemenID " +
                                "WHERE themenID=@themenID " +
                                "ORDER BY titel;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();
            cmd.Parameters.Add(new SqlParameter("themenID", themaID));

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                return fillThemaFromSQLDataReader(reader);
            }
            else
                return null;
        }

        // Hilfsfunktion für die beiden oberen Methoden
        private static Thema fillThemaFromSQLDataReader(SqlDataReader reader)
        {
            Thema einThema = new Thema();

            einThema.themenID = reader.GetGuid(0).ToString();
            einThema.titel = reader.GetString(1);

            return einThema;
        }



    }
}
