using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BOSucht;
using System.Web.Security;

namespace PLSucht
{
    public partial class Beratungen : System.Web.UI.Page
    {
        protected string beratungsID;
        protected Klient Klient;
        protected BOSucht.Beratung CurrentBeratung;
        private BOSucht.Beratungen alleBeratungen;
        string UploadFolderPath = "";
        protected string[] beratungsarten = Start.Beratungsarten;
        List<string> ThemenIDs_selected = new List<string>();
        MembershipUser currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);

            currentUser = Membership.GetUser();

            input_anhang.UploadedComplete += new EventHandler<AsyncFileUploadEventArgs>(FileUploadComplete);

            beratungsID = (string)Session["beratungsID"]; //wurde beim Aufruf übertragen
            Klient = Start.getKlientByID(((Klient)Session["Klient"]).KlientinID);
            CurrentBeratung = (BOSucht.Beratung)Session["Beratung"]; //neues leeres Kundenobjekt

            //GVKunden.DataSource wird auf eine Liste von BO-Objekte gesetzt
            if (!IsPostBack)
            {
                if (beratungsID != "" && Klient != null)
                {
                    label_klient.Text = Klient.Vorname + " " + Klient.Nachname;
                    if (Klient.Avatar != null)
                    {
                        imgDisplay.Src = Klient.Avatar;
                    }
                    //Objekt laden und Werte setzen
                    CurrentBeratung = Start.getBeratungByID(beratungsID);
                    
                    if (CurrentBeratung != null)
                    {
                        headertxt.Text = "Bearbeiten";

                        //kopiere die Properties des Objekts in die Felder der Maske
                        input_ueberweisungskontext.Value = CurrentBeratung.Ueberweisungskontext;
                        input_gespraechsart.Value = CurrentBeratung.Gespraechsart;
                        input_anmerkungen.InnerText = CurrentBeratung.Anmerkungen_formatted;
                        input_kontaktort.Value = CurrentBeratung.Kontaktort;
                        // Datum in String Konvertieren
                        input_datum.Text = CurrentBeratung.Datum.ToShortDateString();

                        // Time To Date
                        input_dauer.Text = CurrentBeratung.Dauer.ToString();

                        input_beratungsart.SelectedIndex = Int32.Parse(CurrentBeratung.Beratungsart);

                        set_selected_beratungsthemen();

                        Session["Beratung"] = CurrentBeratung; //Kundenobjekt in Session speichern
                    }
                    else
                    {
                        input_datum.Text = DateTime.Today.ToShortDateString();
                        
                        headertxt.Text = "Anlegen";
                        
                        Session["Beratung"] = Start.newBeratung(); //neues leeres Kundenobjekt

                        alleBeratungen = Start.getBeratungenbyKlient(Klient.KlientinID); //hier stecken alle Klienten als einzelne Objekte drin!
                        Session["alleBeratungen"] = alleBeratungen; // die heb ich mir in der Session auf
                        GVBesprechungsuebersicht.DataSource = alleBeratungen;
                        GVBesprechungsuebersicht.DataBind(); //dadurch wirds angezeigt
                    }
                }
                else
                {
                     
                    initializeBeratung();
                }

                input_beratungsart.DataSource = beratungsarten;
                input_beratungsart.DataBind();

                set_selected_beratungsthemen();
            }
            else
            {
                alleBeratungen = (BOSucht.Beratungen)Session["alleBeratungen"];
            }
        }

        protected void initializeBeratung()
        {
            Klient = (Klient)Session["Klient"];
            if (CurrentBeratung == null)
            {
                CurrentBeratung = Start.newBeratung();
                CurrentBeratung.Klient = Klient;
                Session["Beratung"] = CurrentBeratung; //neues leeres Kundenobjekt
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

        protected void FileUploadComplete(object sender, EventArgs e)
        {
            string guid = Guid.NewGuid().ToString();
            string filePath = Server.MapPath(Start.Path_anhang) + guid + "-" + System.IO.Path.GetFileName(input_anhang.FileName);
            string pathjs = Start.Path_anhang + guid + "-" + System.IO.Path.GetFileName(input_anhang.FileName);
            input_anhang.SaveAs(filePath);
            input_anhang.ResolveUrl(filePath);

            if (CurrentBeratung == null)
            {
                initializeBeratung();
            }

            CurrentBeratung.Anhang = pathjs;
            link_anhang.NavigateUrl = input_anhang.ResolveUrl(filePath);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "size", "top.$get(\"" + link_anhang.ClientID + "\").href = '" + pathjs + "';", true);
        }

        protected void add_thema_Click(object sender, EventArgs e)
        {
            if (input_thema.Value != "")
            {
                Thema thema = Start.newThema();
                thema.Titel = input_thema.Value;
                if (!thema.saveThema())
                {
                    lblFehlermeldung.Text = "Speichern des Themas fehlgeschlagen";
                }
                set_selected_beratungsthemen();
            }
            else {
                lbl_error_add_thema.Text = "Kein Thema eingegeben!";
            }
        }

        protected void input_themen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentBeratung == null)
            {
                initializeBeratung();
            }
            get_selected_beratungsthemen();
        }

        // Klienten Speichern
        protected void btnSaveClick(object sender, EventArgs e)
        {
            currentUser = Membership.GetUser();

            if (CurrentBeratung != null)
            {
                //kopiere die Properties des Objekts in die Felder der Maske
                Klient = (Klient)Session["Klient"];
                CurrentBeratung.Klient = Klient;

                Berater ber = Start.getBeraterByID(currentUser.ProviderUserKey.ToString());

                CurrentBeratung.Berater = ber;
                
                CurrentBeratung.Ueberweisungskontext = input_ueberweisungskontext.Value;
                CurrentBeratung.Gespraechsart = input_gespraechsart.Value;
                CurrentBeratung.Anmerkungen_formatted = input_anmerkungen.InnerText;
                CurrentBeratung.Anhang = CurrentBeratung.Anhang;
                CurrentBeratung.Kontaktort = input_kontaktort.Value;

                // Datum in String Konvertieren
                CurrentBeratung.Datum = DateTime.Parse(input_datum.Text);

                // Time To Date
                CurrentBeratung.Dauer = TimeSpan.Parse(input_dauer.Text);

                CurrentBeratung.Beratungsart = input_beratungsart.SelectedIndex.ToString();

                get_selected_beratungsthemen();

                if (CurrentBeratung.saveBeratung())
                {
                    foreach (Beratungsthema beratungsthema in CurrentBeratung.Beratungsthemen)
                    {
                        beratungsthema.deleteBeratungsThema(); // Löschen damit dannach wieder gesaved werden kann! Sonst gibts ned Primary Key Exception

                        beratungsthema.BeratungID = CurrentBeratung.BeratungID;
                        if (!beratungsthema.saveBeratungsThema())
                        {
                            lblFehlermeldung.Text = "Speichern der Beratungsthemen fehlgeschlagen";
                        }
                    }
                    Response.Redirect("KlientenAuswahl.aspx");
                }
                else
                {
                    lblFehlermeldung.Text = "Speichern der Beratung fehlgeschlagen";
                }
            }
            
        }

        protected void btnCancelClick(object sender, EventArgs e)
        {
            Session["Klient"] = Klient;
            Response.Redirect("KlientDetail.aspx"); //ohne Speichern zur Hauptseite
        }

        protected void Anhang_Download_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Server.MapPath(Start.Path_image) + CurrentBeratung.Anhang);
        }

        protected void get_selected_beratungsthemen()
        {
            initializeBeratung();
            Beratungsthemen beratungsthemen = Start.newBeratungsthemen();
           
            foreach (ListItem item in input_themen.Items)
            {
                if (item.Selected)
                {
                    Beratungsthema beratungsthema = Start.newBeratungsthema();
                    beratungsthema.BeratungID = CurrentBeratung.BeratungID;
                    beratungsthema.ThemenID = item.Value;
                    beratungsthemen.Add(beratungsthema);
                }
            }

            CurrentBeratung.Beratungsthemen = beratungsthemen;
        }

        protected void set_selected_beratungsthemen()
        {
            beratungsID = (string)Session["beratungsID"]; //wurde beim Aufruf übertragen

            Themen themen = Start.getAllThemen();

            input_themen.DataSource = themen;
            input_themen.DataTextField = "Titel";
            input_themen.DataValueField = "ThemenID";
            input_themen.DataBind();

            if (beratungsID != null)
            {
                Beratungsthemen beratungsthemen = Start.getBeratungsThemenByBeratungsID(beratungsID);
                foreach (ListItem item in input_themen.Items)
                {

                    foreach (Beratungsthema thema in beratungsthemen)
                    {

                        if (item.Value == thema.ThemenID)
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
        }

    }
}