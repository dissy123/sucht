using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace BOSucht
{
    public class Beratung
    {

        // FELDER bzw. VARIABLEN *********************************************************************************************
        private String beratungID = "";
        private String beraterID = "";
        private String klientinID = "";
        private String kontaktort;
        private String beratungsart;
        private String beratungsart_formatted;
        private String ueberweisungskontext;
        private String anmerkungen;
        private TimeSpan dauer;
        private DateTime datum;
        private String gespraechsart;
        private String anhang;
        private Klient klient;
        private Berater berater;
        private String datum_formatted;
        private Beratungsthemen beratungsthemen;

        // PROPERTIES *********************************************************************************************
        public String BeratungID
        {
            get { return beratungID; }
            internal set { beratungID = value; }
        }

        public String BeraterID
        {
            get { return beraterID; }
            internal set { beraterID = value; }
        }

        public String KlientinID
        {
            get { return klientinID; }
            internal set { klientinID = value; }
        }

        public String Kontaktort
        {
            get { return kontaktort; }
            set { kontaktort = value; }
        }

        public String Beratungsart
        {
            get { return beratungsart; }
            set { beratungsart = value; }
        }

        public String Ueberweisungskontext
        {
            get { return ueberweisungskontext; }
            set { ueberweisungskontext = value; }
        }

        public String Anmerkungen_formatted
        {
            get { return WebUtility.HtmlDecode(anmerkungen); }
            set { anmerkungen = value; }
        }
        
        public TimeSpan Dauer
        {
            get { return dauer; }
            set { dauer = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public String Gespraechsart
        {
            get { return gespraechsart; }
            set { gespraechsart = value; }
        }

        public String Anhang
        {
            get { return anhang; }
            set { anhang = value; }
        }

        public String Datum_formatted
        {
            get { return datum_formatted; }
            set { datum_formatted = value; }
        }

        public String Beratungsart_formatted
        {
            get { return beratungsart_formatted; }
            set { beratungsart_formatted = value; }
        }

        //und hier eine Variante ohne Zwischenspeichern - hat den Vorteil, dass die Liste sicher immer aktuell ist, 
        //dafür wird sie eventuell öfters sinnlos geladen.
        public Beratungsthemen Beratungsthemen
        {
            get
            {
                return beratungsthemen; 
            }
            set
            {
                beratungsthemen = value;
            }
        }

        //und hier eine Variante ohne Zwischenspeichern - hat den Vorteil, dass die Liste sicher immer aktuell ist, 
        //dafür wird sie eventuell öfters sinnlos geladen.
        public Klient Klient
        {
            get
            {
                return Klient.getKlientByID(klient.KlientinID);
            }
            set
            {
                klient = value;
            }
        }

        public Berater Berater { 
            get  
            {
                return Berater.getBeraterByID(berater.BeraterID);
            }
            set 
            {
                berater = value;
            }
        }

        public bool saveBeratung()
        {
            if (beratungID == "")
            {
                //neuer Record -> INSERT
                string SQL = "insert into beratung (beratungsID, beraterID, klientinID, kontaktort, " +
                                                 "beratungsart, ueberweisungskontext, anmerkungen, dauer, datum, gespraechsart, " +
                                                 "anhang" +
                                                 ")" +
                                          "values (@beratungsID, @beraterID, @klientinID, @kontaktort, " +
                                                  "@beratungsart, @ueberweisungskontext, @anmerkungen, @dauer, " +
                                                  "@datum, @gespraechsart, @anhang " +
                                                  ");";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();

                //GUID für ID erzeugen und als String zurückgeben (weil mID=="")!

                BeratungID = Guid.NewGuid().ToString();

                //Die Parameter in SQL-String mit Werten versehen...

                cmd.Parameters.Add(new SqlParameter("beratungsID", BeratungID));
                
                cmd.Parameters.Add(new SqlParameter("beraterID", Berater.BeraterID));
                
                cmd.Parameters.Add(new SqlParameter("klientinID", Klient.KlientinID));
                cmd.Parameters.Add(new SqlParameter("kontaktort", kontaktort));
                cmd.Parameters.Add(new SqlParameter("beratungsart", beratungsart));
                cmd.Parameters.Add(new SqlParameter("ueberweisungskontext", ueberweisungskontext));
                cmd.Parameters.Add(new SqlParameter("anmerkungen", anmerkungen));
                cmd.Parameters.Add(new SqlParameter("dauer", dauer));
                cmd.Parameters.Add(new SqlParameter("datum", datum));
                cmd.Parameters.Add(new SqlParameter("gespraechsart", gespraechsart));
                cmd.Parameters.Add(new SqlParameter("anhang", anhang));

                // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
                return (cmd.ExecuteNonQuery() > 0); //hat der INSERT geklappt, sollte genau ein Record verändert worden sein
            }
            else
            {
                //bestehender Record -> UPDATE
                string SQL = "update beratung set beraterID=@beraterID, klientinID=@klientinID, kontaktort=@kontaktort, " +
                                                 "beratungsart=@beratungsart,ueberweisungskontext=@ueberweisungskontext, " +
                                                 "anmerkungen=@anmerkungen,dauer=@dauer,datum=@datum, " +
                                                 "gespraechsart= @gespraechsart, anhang = @anhang " +
                                                 "where beratungsID = @beratungsID;";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();

                cmd.Parameters.Add(new SqlParameter("beratungsID", beratungID));
               
                cmd.Parameters.Add(new SqlParameter("beraterID", Berater.BeraterID));
                cmd.Parameters.Add(new SqlParameter("klientinID", Klient.KlientinID));
                cmd.Parameters.Add(new SqlParameter("kontaktort", kontaktort));
                cmd.Parameters.Add(new SqlParameter("beratungsart", beratungsart));
                cmd.Parameters.Add(new SqlParameter("ueberweisungskontext", ueberweisungskontext));
                cmd.Parameters.Add(new SqlParameter("anmerkungen", anmerkungen));
                cmd.Parameters.Add(new SqlParameter("dauer", dauer));
                cmd.Parameters.Add(new SqlParameter("datum", datum));
                cmd.Parameters.Add(new SqlParameter("gespraechsart", gespraechsart));
                cmd.Parameters.Add(new SqlParameter("anhang", anhang));

                return (cmd.ExecuteNonQuery() > 0);
            }
        }

        public bool deleteBeratung()
        {
            if (beratungID != "")
            {
                string SQL = "delete beratung where beratungsID = @beratungsID;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();
                cmd.Parameters.Add(new SqlParameter("beratungsID", beratungID));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    beratungID = ""; //das Objekt existiert weiter - es verhält sich aber wieder wie ein neuer Kunde
                    return true;
                }
                else return false; //Löschen aus DB klappt nicht...
            }
            else return true; // Kunde hat keine ID??? -> war noch gar nicht gespeichert.
            // wenn er nicht gespeichert war, kann man ihn auch nicht löschen,
            // aber jedenfalls ist er auch nicht in der DB, also sagen wir halt true :-)
        }

        // Laden eines Kundenobjekts - wird von BOMail.getKunde() aufgerufen
        internal static Beratung getBeratungByID(string beratungID)
        {
            if (beratungID == null)
            {
                beratungID = "0";
            }

            string sql = "SELECT beratungsID, beraterID, klientinID, kontaktort, " +
                                "beratungsart, ueberweisungskontext, anmerkungen, dauer, datum, gespraechsart, anhang " +
                                "FROM beratung " +
                                "WHERE beratungsID=@id " +
                                "ORDER BY beratungsID;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();
            cmd.Parameters.Add(new SqlParameter("id", beratungID));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                return fillBeratungFromSQLDataReader(reader);
            }
            else
                return null;
        }

        // Laden aller Kunden als Liste von Objekten
        internal static Beratungen getAllBeratungen()
        {
            // Schnellvariante, wie oben aber alles in einer Zeile....
            string sql = "SELECT beratungsID, beraterID, klientinID, kontaktort, " +
                                "beratungsart, ueberweisungskontext, anmerkungen, dauer, datum, gespraechsart, anhang " +
                                "FROM beratung " +
                                "ORDER BY beratungsID;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();

            SqlDataReader reader = cmd.ExecuteReader();
            Beratungen alleBeratungen = new Beratungen(); //initialisiere lehre Liste
            while (reader.Read())
            {
                Beratung eineBeratung = fillBeratungFromSQLDataReader(reader);
                alleBeratungen.Add(eineBeratung);
            }
            return alleBeratungen;
        }

        public static Beratungen getBeratungenByKlient(string klientinID)
        {
            if (klientinID == null)
            {
                klientinID = "0";
            }

            string sql = "SELECT beratungsID, beraterID, klientinID, kontaktort, " +
                                "beratungsart, ueberweisungskontext, anmerkungen, dauer, datum, gespraechsart, anhang " +
                                "FROM beratung " +
                                "WHERE klientinID=@id " +
                                "ORDER BY datum;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();
            cmd.Parameters.Add(new SqlParameter("id", klientinID));

            SqlDataReader reader = cmd.ExecuteReader();
            Beratungen alleBeratungen = new Beratungen(); //initialisiere lehre Liste
            while (reader.Read())
            {
                Beratung eineBeratung = fillBeratungFromSQLDataReader(reader);
                alleBeratungen.Add(eineBeratung);
            }
            return alleBeratungen;
        }


        // Hilfsfunktion für die beiden oberen Methoden
        private static Beratung fillBeratungFromSQLDataReader(SqlDataReader reader)
        {
            Beratung eineBeratung = new Beratung();

            eineBeratung.beratungID = reader.GetGuid(0).ToString();
            eineBeratung.beraterID = reader.GetGuid(1).ToString();
            eineBeratung.klientinID = reader.GetGuid(2).ToString();
            eineBeratung.kontaktort = reader.GetString(3);
            eineBeratung.beratungsart = reader.GetString(4);
            eineBeratung.ueberweisungskontext = reader.GetString(5);
            eineBeratung.anmerkungen = reader.GetString(6);
            eineBeratung.dauer = reader.GetTimeSpan(7);
            eineBeratung.datum = reader.GetDateTime(8);
            eineBeratung.gespraechsart = reader.GetString(9);
            eineBeratung.anhang = reader.GetString(10);

            eineBeratung.Datum_formatted = eineBeratung.datum.ToShortDateString();
            eineBeratung.Beratungsart_formatted = Start.Beratungsarten[Int32.Parse(eineBeratung.beratungsart)];
            return eineBeratung;
        }


        public Beratungsthemen getBeratungsThemenByBeratungsID(string BeratungsID)
        {
            return Beratungsthemen;
        }



        
    }
}

