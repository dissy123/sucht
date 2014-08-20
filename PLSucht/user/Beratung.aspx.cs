using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOSucht;

namespace PLSucht
{
    public partial class Beratung : System.Web.UI.Page
    {
        protected string beratungsID;
        protected Klient Klient;
        protected BOSucht.Beratung CurrentBeratung;
        protected string[] beratungsarten = Start.Beratungsarten;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);

            beratungsID = (string)Session["beratungsID"]; //wurde beim Aufruf übertragen
            Klient = Start.getKlientByID(((Klient)Session["Klient"]).KlientinID);

            if (!IsPostBack)
            {
                if (beratungsID != "" && Klient != null)
                {
                    label_klient.Text = Klient.Vorname + " " + Klient.Nachname;
                    imgDisplay.Src = Klient.Avatar;

                    //Objekt laden und Werte setzen
                    CurrentBeratung = Start.getBeratungByID(beratungsID);

                    if (CurrentBeratung != null)
                    {
                        //kopiere die Properties des Objekts in die Felder der Maske
                        input_ueberweisungskontext.Text = CurrentBeratung.Ueberweisungskontext;
                        input_gespraechsart.Text = CurrentBeratung.Gespraechsart;
                        input_anmerkungen.Text = CurrentBeratung.Anmerkungen;
                        input_kontaktort.Text = CurrentBeratung.Kontaktort;
                        // Datum in String Konvertieren
                        input_datum.Text = CurrentBeratung.Datum_formatted;

                        // Time To Date
                        input_dauer.Text = CurrentBeratung.Dauer.ToString();

                        input_beratungsart.Text = beratungsarten[Int32.Parse(CurrentBeratung.Beratungsart)];


                        Beratungsthemen beratungsthemen = Start.getBeratungsThemenByBeratungsID(beratungsID);
                        Themen themen = Start.getAllThemen();

                        Repeater1.DataSource = beratungsthemen;
                        Repeater1.DataBind();

                        Session["Beratung"] = CurrentBeratung; //Kundenobjekt in Session speichern
                    }
                }
            }
        }

        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            Session["Klient"] = Klient;
            Session["beratungsID"] = beratungsID;
            Response.Redirect("Beratungen.aspx");
        }

        protected void ImageButton2_Click(object sender, EventArgs e)
        {
            Session["Klient"] = Klient;
            Response.Redirect("KlientDetail.aspx");
        }

        protected void ImageButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("KlientenAuswahl.aspx");
        }

    }
}