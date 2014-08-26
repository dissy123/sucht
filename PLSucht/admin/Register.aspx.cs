using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BOSucht;


namespace PLSucht.admin
{
    public partial class Register : System.Web.UI.Page
    {
        Berater currentBerater;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);

            if (!IsPostBack)
            {
                string beraterID = (string)Session["beraterID"]; //wurde beim Aufruf übertragen
                if (beraterID != "")
                {
                    //Objekt laden und Werte setzen
                    currentBerater = Start.getBeraterByID(beraterID);
                    if (currentBerater != null)
                    {
                        //kopiere die Properties des Objekts in die Felder der Maske
                        input_vorname.Value = currentBerater.Vorname;
                        input_nachname.Value = currentBerater.Nachname;
                        input_adresse.Value = currentBerater.Adresse;
                        input_plz.Value = currentBerater.Plz;
                        input_ort.Value = currentBerater.Ort;
                        input_telnr.Value = currentBerater.Telnr;
                        input_mobilnr.Value = currentBerater.Mobilnr;
                    }
                }
            }
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            if (saveBerater(sender,e))
            { 
                
            }
        }

        protected bool saveBerater(object sender, EventArgs e)
        {
            currentBerater = Start.newBerater();

            if (currentBerater != null)
            {

                // Berater ID = die User ID welche beim ASP Membership Provider erzeugt wurde somit wird zwischen den Tabellen eine Verbindung hergestellt
                currentBerater.BeraterID = Membership.GetUser((sender as CreateUserWizard).UserName).ProviderUserKey.ToString();

                currentBerater.Vorname = input_vorname.Value;
                currentBerater.Nachname = input_nachname.Value;
                currentBerater.Adresse = input_adresse.Value;
                currentBerater.Plz = input_plz.Value;
                currentBerater.Ort = input_ort.Value;
                currentBerater.Telnr = input_telnr.Value;
                currentBerater.Mobilnr = input_mobilnr.Value;
                if (currentBerater.saveBerater())
                    return true;
                else return false;
            }
            return false;
        }
    }
}