using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOSucht;

namespace PLSucht
{
    public partial class KlientDetail : System.Web.UI.Page
    {
        protected Klient Klient;
        private BOSucht.Beratungen alleBeratungen;

        protected void Page_Load(object sender, EventArgs e)
        {
            Klient = (Klient)Session["Klient"];
            alleBeratungen = Start.getBeratungenbyKlient(Klient.KlientinID); //hier stecken alle Klienten als einzelne Objekte drin!
            if (!IsPostBack)
            {
                
                if (Klient != null)
                {
                    //kopiere die Properties des Objekts in die Felder der Maske
                    input_vorname.Text = Klient.Vorname;
                    input_nachname.Text = Klient.Nachname;
                    input_adresse.Text = Klient.Adresse;
                    input_plz.Text = Klient.Plz;
                    input_ort.Text = Klient.Ort;
                    input_telnr.Text = Klient.Telnr;
                    input_mobilnr.Text = Klient.Mobilnr;
                    input_nationalitaet.Text = Klient.Nationalitaet;
                    input_email.Text = Klient.Email;
                    input_status.Text = Klient.Status;
                    input_schule.Text = Klient.Schule;
                    input_stufe.Text = Klient.Stufe;

                    // Datum in String Konvertieren
                    input_gebdat.Text = Klient.Gebdat.ToShortDateString();
                    input_erstkontakt.Text = Klient.Erstkontakt.ToShortDateString();

                    // Geschlecht Radio Buttons
                    if (Klient.Geschlecht == "M")
                    {
                        input_sex.Text = "Männlich";
                    }
                    else if (Klient.Geschlecht == "W")
                    {
                        input_sex.Text = "Weiblich";
                    }

                    imgDisplay.Src = Klient.Avatar;

                    Session["alleBeratungen"] = alleBeratungen; // die heb ich mir in der Session auf
                    GVBesprechungsuebersicht.DataSource = alleBeratungen;
                    GVBesprechungsuebersicht.DataBind(); //dadurch wirds angezeigt
                }
            }
        }

       

        protected void GVBesprechungsuebersicht_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GVBesprechungsuebersicht.SelectedRow;
            // die Zeilennummer in der GridView entsricht der Position in der Liste
            Session["beratungsID"] = alleBeratungen[row.RowIndex].BeratungID; //ID aus dem Objekt rausholen und in der Session speichern

            Response.Redirect("Beratung.aspx"); //Kundeseite aufrufen - die ladet sich dann das Objekt neu.
        }

        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            Session["beratungsID"] = null;
            Session["Klient"] = Klient;
            Response.Redirect("Beratungen.aspx");
        }

        protected void ImageButton2_Click(object sender, EventArgs e)
        {
            Session["ID"] = Klient.KlientinID;
            Response.Redirect("KlientAnlegen.aspx");
        }
        protected void ImageButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("KlientenAuswahl.aspx");
        }

        
    }
}