using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace BOSucht
{
    public class Klient
    {

        // FELDER bzw. VARIABLEN *********************************************************************************************
        private String klientinID = "";
        private String vorname;
        private String nachname;
        private String adresse;
        private String plz;
        private String ort;
        private String telnr;
        private String mobilnr;
        private String geschlecht;
        private String nationalitaet;
        private String email;
        private DateTime gebdat;
        private String gebdat_formatted;
        private String status;
        private DateTime erstkontakt;
        private String schule;
        private String stufe;
        private string avatar;


        private Beratungen beratungen;
        // PROPERTIES *********************************************************************************************
        public String KlientinID
        {
            get { return klientinID; }
            internal set { klientinID = value; }
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

        public String Geschlecht
        {
            get { return geschlecht; }
            set { geschlecht = value.Trim(); }
        }

        public String Nationalitaet
        {
            get { return nationalitaet; }
            set { nationalitaet = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public DateTime Gebdat
        {
            get { return gebdat; }
            set { gebdat = value; }
        }

        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime Erstkontakt
        {
            get { return erstkontakt; }
            set { erstkontakt = value; }
        }

        public String Schule
        {
            get { return schule; }
            set { schule = value; }
        }

        public String Gebdat_formatted
        {
            get { return gebdat_formatted; }
            set { gebdat_formatted = value; }
        }

        public String Stufe
        {
            get { return stufe; }
            set { stufe = value; }
        }

        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        //und hier eine Variante ohne Zwischenspeichern - hat den Vorteil, dass die Liste sicher immer aktuell ist, 
        //dafür wird sie eventuell öfters sinnlos geladen.
        public Beratungen Beratungen
        {
            get
            {
                return Beratung.getBeratungenByKlient(this.klientinID);
            }
        }


        public bool saveKlient()
        {
            if (klientinID == "")
            {
                if (geschlecht == null) {
                    geschlecht = "X";
                }

                //neuer Record -> INSERT
                string SQL = "insert into klient (klientinID, vorname, nachname, adresse, " +
                                                 "plz, ort, telnr, mobilnr, geschlecht, nationalitaet, " +
                                                 "email, gebdat, status, erstkontakt, schule, stufe";
                            
                if (avatar != null){
                    SQL += ", avatar ";
                }

                SQL += ")" +
                       "values (@klientinID, @vorname, @nachname, @adresse, " +
                       "@plz, @ort, @telnr, @mobilnr, " +
                       "@geschlecht, @nationalitaet, @email, @gebdat, " +
                       "@status, @erstkontakt, @schule, @stufe";
                      
                if (avatar != null)
                {
                    SQL +=  ", @avatar ";
                }

                SQL += ");";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();

                //GUID für ID erzeugen und als String zurückgeben (weil mID=="")!

                klientinID = Guid.NewGuid().ToString();

                //Die Parameter in SQL-String mit Werten versehen...
                
                cmd.Parameters.Add(new SqlParameter("klientinID", klientinID));
                cmd.Parameters.Add(new SqlParameter("vorname", vorname));
                cmd.Parameters.Add(new SqlParameter("nachname", nachname));
                cmd.Parameters.Add(new SqlParameter("adresse", adresse));
                cmd.Parameters.Add(new SqlParameter("plz", plz));
                cmd.Parameters.Add(new SqlParameter("ort", ort));
                cmd.Parameters.Add(new SqlParameter("telnr", telnr));
                cmd.Parameters.Add(new SqlParameter("mobilnr", mobilnr));
                cmd.Parameters.Add(new SqlParameter("geschlecht", geschlecht));
                cmd.Parameters.Add(new SqlParameter("nationalitaet", nationalitaet));
                cmd.Parameters.Add(new SqlParameter("email", email));
                cmd.Parameters.Add(new SqlParameter("gebdat", gebdat));
                cmd.Parameters.Add(new SqlParameter("status", status));
                cmd.Parameters.Add(new SqlParameter("erstkontakt", erstkontakt));
                cmd.Parameters.Add(new SqlParameter("schule", schule));
                cmd.Parameters.Add(new SqlParameter("stufe", stufe));

                if (avatar != null)
                {
                    cmd.Parameters.Add(new SqlParameter("avatar", avatar));
                }

                

                // ExecuteNonQuery() gibt die Anzahl der veränderten/angelegten Records zurück.
                return (cmd.ExecuteNonQuery() > 0); //hat der INSERT geklappt, sollte genau ein Record verändert worden sein
            }
            else
            {
                //bestehender Record -> UPDATE
                string SQL = "update klient set   vorname=@vorname, nachname=@nachname, adresse=@adresse, " +
                                                 "plz=@plz,ort=@ort,telnr=@telnr,mobilnr=@mobilnr,geschlecht=@geschlecht,nationalitaet= @nationalitaet, " +
                                                 "email = @email, gebdat = @gebdat, status= @status , erstkontakt = @erstkontakt, schule = @schule, stufe = @stufe";
                if (avatar != null)
                {
                    SQL += " , avatar = @avatar";
                }

                SQL += " where klientinID = @klientinID;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();

                cmd.Parameters.Add(new SqlParameter("klientinID", klientinID));
                cmd.Parameters.Add(new SqlParameter("vorname", vorname));
                cmd.Parameters.Add(new SqlParameter("nachname", nachname));
                cmd.Parameters.Add(new SqlParameter("adresse", adresse));
                cmd.Parameters.Add(new SqlParameter("plz", plz));
                cmd.Parameters.Add(new SqlParameter("ort", ort));
                cmd.Parameters.Add(new SqlParameter("telnr", telnr));
                cmd.Parameters.Add(new SqlParameter("mobilnr", mobilnr));
                cmd.Parameters.Add(new SqlParameter("geschlecht", geschlecht));
                cmd.Parameters.Add(new SqlParameter("nationalitaet", nationalitaet));
                cmd.Parameters.Add(new SqlParameter("email", email));
                cmd.Parameters.Add(new SqlParameter("gebdat", gebdat));
                cmd.Parameters.Add(new SqlParameter("status", status));
                cmd.Parameters.Add(new SqlParameter("erstkontakt", erstkontakt));
                cmd.Parameters.Add(new SqlParameter("schule", schule));
                cmd.Parameters.Add(new SqlParameter("stufe", stufe));

                if (avatar != null)
                {
                    cmd.Parameters.Add(new SqlParameter("avatar", avatar));
                }
                return (cmd.ExecuteNonQuery() > 0);
            }
        }



        public bool deleteKlient()
        {
            foreach (Beratung b in Beratungen) { b.deleteBeratung(); }//erst alle Kommentare des Kunden löschen!

            if (klientinID != "")
            {
                string SQL = "delete Klient where klientinID = @klientinID;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Start.GetConnection();
                cmd.Parameters.Add(new SqlParameter("klientinID", klientinID));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    klientinID = ""; //das Objekt existiert weiter - es verhält sich aber wieder wie ein neuer Kunde
                    return true;
                }
                else return false; //Löschen aus DB klappt nicht...
            }
            else return true; // Kunde hat keine ID??? -> war noch gar nicht gespeichert.
            // wenn er nicht gespeichert war, kann man ihn auch nicht löschen,
            // aber jedenfalls ist er auch nicht in der DB, also sagen wir halt true :-)
        }


        // Laden eines Kundenobjekts - wird von BOMail.getKunde() aufgerufen
        internal static Klient getKlientByID(string KlientID)
        {
            if (KlientID == null)
            {
                KlientID = "0";
            }

            string sql = "SELECT klientinID, vorname, nachname, adresse, " +
                         "plz, ort, telnr, mobilnr, geschlecht, email, " +
                         "nationalitaet, gebdat, status, erstkontakt, " +
                         "schule, stufe, avatar " +
                         "FROM klient " +
                         "WHERE klientinID=@id " +
                         "ORDER BY nachname, vorname, gebdat DESC;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();
            cmd.Parameters.Add(new SqlParameter("id", KlientID));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                return fillKlientFromSQLDataReader(reader);
            }
            else
                return null;
        }

        internal static Klienten getKlientenByName(string vorname, string nachname)
        {
            if (vorname == null)
            {
                vorname = "*";
            }
            if (nachname == null)
            {
                nachname = "*";
            }

            string sql = "SELECT klientinID, vorname, nachname, adresse, " +
                         "plz, ort, telnr, mobilnr, geschlecht, email, " +
                         "nationalitaet, gebdat, status, erstkontakt, " +
                         "schule, stufe, avatar " +
                         "FROM klient " +
                         "WHERE vorname LIKE @vorname AND nachname LIKE @nachname " +
                         "ORDER BY nachname, vorname, gebdat DESC;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();
            cmd.Parameters.AddWithValue("@vorname", string.Format("%{0}%", vorname));
            cmd.Parameters.AddWithValue("@nachname", string.Format("%{0}%", nachname));
            //  cmd.Parameters.Add(new SqlParameter("vorname", vorname));
            //  cmd.Parameters.Add(new SqlParameter("nachname", nachname));
            SqlDataReader reader = cmd.ExecuteReader();
            Klienten alleKlienten = new Klienten(); //initialisiere lehre Liste

            while (reader.Read())
            {
                Klient einKlient = fillKlientFromSQLDataReader(reader);
                alleKlienten.Add(einKlient);
            }
            return alleKlienten;
        }


        // Laden aller Kunden als Liste von Objekten
        internal static Klienten getAllKlients()
        {
            // Schnellvariante, wie oben aber alles in einer Zeile....
            string sql = "SELECT klientinID, vorname, nachname, adresse, " +
                         "plz, ort, telnr, mobilnr, geschlecht, email, " +
                         "nationalitaet, gebdat, status, erstkontakt, " +
                         "schule, stufe, avatar  " +
                         "FROM klient  " +
                         "ORDER BY nachname, vorname, gebdat DESC;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Start.GetConnection();

            SqlDataReader reader = cmd.ExecuteReader();
            Klienten alleKlienten = new Klienten(); //initialisiere lehre Liste
            while (reader.Read())
            {
                Klient einKlient = fillKlientFromSQLDataReader(reader);
                alleKlienten.Add(einKlient);
            }
            return alleKlienten;
        }



        // Hilfsfunktion für die beiden oberen Methoden
        private static Klient fillKlientFromSQLDataReader(SqlDataReader reader)
        {
            Klient einKlient = new Klient();

            einKlient.klientinID = reader.GetGuid(0).ToString();
            einKlient.vorname = reader.GetString(1);
            einKlient.nachname = reader.GetString(2);
            einKlient.adresse = reader.GetString(3);
            einKlient.plz = reader.GetString(4);
            einKlient.ort = reader.GetString(5);
            einKlient.telnr = reader.GetString(6);
            einKlient.mobilnr = reader.GetString(7);
            einKlient.geschlecht = reader.GetString(8).Trim();
            einKlient.email = reader.GetString(9);
            einKlient.nationalitaet = reader.GetString(10);
            einKlient.gebdat = reader.GetDateTime(11);
            einKlient.status = reader.GetString(12);
            einKlient.erstkontakt = reader.GetDateTime(13);
            einKlient.schule = reader.GetString(14);
            einKlient.stufe = reader.GetString(15);
            if (!reader.IsDBNull(16))
            {
                einKlient.avatar = reader.GetString(16);
            }
            einKlient.Gebdat_formatted = einKlient.gebdat.ToShortDateString();

            return einKlient;
        }

    }
}
