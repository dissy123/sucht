using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOSucht; //meinen BO-Namespace im Presentation Layer importieren!

namespace PLSucht
{
    public partial class KlientenAuswahl : System.Web.UI.Page
    {
        
        private Klienten alleKlienten;

        protected void Page_Load(object sender, EventArgs e)
        {
            //GVKunden.DataSource wird auf eine Liste von BO-Objekte gesetzt
            if (!IsPostBack)
            {
                alleKlienten = Start.getAllKlients(); //hier stecken alle Klienten als einzelne Objekte drin!
                Session["alleKlienten"] = alleKlienten; // die heb ich mir in der Session auf
                GVKlienten.DataSource = alleKlienten;
                GVKlienten.DataBind(); //dadurch wirds angezeigt
            }
            else
            {
                alleKlienten = (Klienten)Session["alleKlienten"];
            }
        }

        protected void btnNeuKlient_Click(object sender, EventArgs e)
        {
            Session["ID"] = ""; //leere ID - also neu
            Response.Redirect("KlientAnlegen.aspx"); //Kundeseite aufrufen
        }


    
        protected void GVKlient_SelectedIndexChanged(object sender, EventArgs e)
        {
           GridViewRow row = GVKlienten.SelectedRow;
           Session["Klient"] = alleKlienten[row.RowIndex];
           Response.Redirect("KlientDetail.aspx");  
        }

        protected void button_search_Click(object sender, EventArgs e)
        {
            alleKlienten = Start.getKlientenByName(input_search_vorname.Text, input_search_nachname.Text);
            Session["alleKlienten"] = alleKlienten;

            GVKlienten.DataSource = alleKlienten;
            GVKlienten.DataBind(); 
        }

        protected void input_search_vorname_TextChanged(object sender, EventArgs e)
        {
            button_search_Click(sender, e);
        }

        protected void GVKlienten_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["ID"] = alleKlienten[e.NewEditIndex].KlientinID; 
            Response.Redirect("KlientAnlegen.aspx"); 
        }

        protected void GVKlienten_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            alleKlienten[e.RowIndex].deleteKlient();
            Label1.Text = "Klient erfolgreich gelöscht!";
            Response.Redirect("KlientenAuswahl.aspx"); 
        }


    }
}