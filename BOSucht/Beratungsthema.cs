using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace BOSucht
{
    public class Beratungsthema
    {

        // FELDER bzw. VARIABLEN *********************************************************************************************
        private String beratungID = "";
        private String themenID = "";
        private Thema thema;
        private bool inDB;

        // PROPERTIES *********************************************************************************************
        public String BeratungID
        {
            get { return beratungID; }
            set { beratungID = value; }
        }

        public String ThemenID
        {
            get { return themenID; }
            set { themenID = value; }
        }

        //und hier eine Variante ohne Zwischenspeichern - hat den Vorteil, dass die Liste sicher immer aktuell ist, 
        //dafür wird sie eventuell öfters sinnlos geladen.
        public Thema Thema
        {
            get
            {
                return Thema.getTitleByBThemaID(this.ThemenID);
            }
        }

        public bool saveBeratungsThema()
        {
                //neuer Record -> INSERT
                string SQL = "insert into beratungsthemen (beratungsID, themenID)" +
                                            "values (@beratungsID, @themenID);";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();

                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("beratungsID", beratungID));
                cmd.Parameters.Add(new SqlParameter("themenID", themenID));

               
                return(cmd.ExecuteNonQuery() > 0);
           
        }

        public bool deleteBeratungsThema()
        {
            if (beratungID != "" && themenID != "")
            {
                string SQL = "delete beratungsthemen where beratungsID = @beratungsID and themenID=@themenID;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();
                cmd.Parameters.Add(new SqlParameter("beratungsID", beratungID));
                cmd.Parameters.Add(new SqlParameter("themenID", themenID));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    //beratungID = ""; //das Objekt existiert weiter - es verhält sich aber wieder wie ein neuer Kunde
                    //themenID = "";
                    return true;
                }
                else return false; //Löschen aus DB klappt nicht...
            }
            else return true; // Kunde hat keine ID??? -> war noch gar nicht gespeichert.
            // wenn er nicht gespeichert war, kann man ihn auch nicht löschen,
            // aber jedenfalls ist er auch nicht in der DB, also sagen wir halt true :-)
        }

        internal static Beratungsthemen getThemenByBeratungsID(string beratungsID)
        {

            if (beratungsID == null)
            {
                beratungsID = "0";
            }

            string sql = "SELECT beratungsID, themenID " +
                                "FROM beratungsthemen " +
                                "WHERE beratungsID=@beratungsID " +
                                "ORDER BY themenID;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();
            cmd.Parameters.Add(new SqlParameter("beratungsID", beratungsID));

            SqlDataReader reader = cmd.ExecuteReader();
            Beratungsthemen alleBeratungsthemen = new Beratungsthemen(); //initialisiere lehre Liste
            while (reader.Read())
            {
                Beratungsthema eineBeratung = fillBeratungsthemaFromSQLDataReader(reader);
                alleBeratungsthemen.Add(eineBeratung);
            }
            return alleBeratungsthemen;
        }

        // Hilfsfunktion für die beiden oberen Methoden
        private static Beratungsthema fillBeratungsthemaFromSQLDataReader(SqlDataReader reader)
        {
            Beratungsthema einBeratungsthema = new Beratungsthema();

            einBeratungsthema.beratungID = reader.GetGuid(0).ToString();
            einBeratungsthema.themenID = reader.GetGuid(1).ToString();

            return einBeratungsthema;
        }

    }
}
