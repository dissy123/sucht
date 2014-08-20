using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using AjaxControlToolkit;
using BOSucht;

namespace PLSucht
{
    public partial class KlientAnlegen : System.Web.UI.Page
    {

        protected string currentID;
        protected Klient currentKlient;
        protected string UploadFolderPath = "";

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
                currentID = (string)Session["ID"]; //wurde beim Aufruf übertragen
                if (currentID != "")
                {
                    //Objekt laden und Werte setzen
                    currentKlient = Start.getKlientByID(currentID);
                    if (currentKlient != null)
                    {
                        //kopiere die Properties des Objekts in die Felder der Maske
                        input_vorname.Value = currentKlient.Vorname;
                        input_nachname.Value = currentKlient.Nachname;
                        input_adresse.Value = currentKlient.Adresse;
                        input_plz.Value = currentKlient.Plz;
                        input_ort.Value = currentKlient.Ort;
                        input_telnr.Value = currentKlient.Telnr;
                        input_mobilnr.Value = currentKlient.Mobilnr;
                        input_nationalitaet.Value = currentKlient.Nationalitaet;
                        input_email.Value = currentKlient.Email;
                        input_status.Value = currentKlient.Status;
                        input_schule.Value = currentKlient.Schule;
                        input_stufe.Value = currentKlient.Stufe;

                        // Datum in String Konvertieren
                        input_gebdat.Text = currentKlient.Gebdat.ToShortDateString();
                        input_erstkontakt.Text = currentKlient.Erstkontakt.ToShortDateString();

                        // Geschlecht Radio Buttons
                        if (currentKlient.Geschlecht == "M")
                        {
                            M.Checked = true;
                        }
                        else if (currentKlient.Geschlecht == "W")
                        {
                            W.Checked = true;
                        }

                        imgDisplay.Src = currentKlient.Avatar;

                        Session["Klient"] = currentKlient; //Kundenobjekt in Session speichern
                    }
                    else
                    {
                        lblFehlermeldung.Text = "Kunde nicht gefunden - Sie können einen neuen Kunden anlegen!";
                        Session["Klient"] = Start.newKlient(); //neues leeres Kundenobjekt
                        input_erstkontakt.Text = DateTime.Today.ToShortDateString();
                    }
                }
                else
                {
                    initializeKlient();
                    input_erstkontakt.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
                currentKlient = (Klient)Session["Klient"];
        }

        protected void initializeKlient()
        {
            //leere ID? Dann ist das ein neuer Kunde
            currentKlient = Start.newKlient();
            Session["Klient"] = currentKlient; //neues leeres Kundenobjekt
        }

        protected bool saveKlient()
        {
            Page.Validate();
            if (currentKlient != null)
            {
                //Feldwerte in das Objekt laden
                //kopiere die Properties des Objekts in die Felder der Maske
                currentKlient.Vorname = input_vorname.Value;
                currentKlient.Nachname = input_nachname.Value;
                currentKlient.Adresse = input_adresse.Value;
                currentKlient.Plz = input_plz.Value;
                currentKlient.Ort = input_ort.Value;
                currentKlient.Telnr = input_telnr.Value;
                currentKlient.Mobilnr = input_mobilnr.Value;
                currentKlient.Nationalitaet = input_nationalitaet.Value;
                currentKlient.Email = input_email.Value;
                currentKlient.Status = input_status.Value;
                currentKlient.Schule = input_schule.Value;
                currentKlient.Stufe = input_stufe.Value;


                // Datum in String Konvertieren
                if (input_gebdat.Text == "")
                {
                    currentKlient.Gebdat = DateTime.Today;
                }
                else {
                    currentKlient.Gebdat = DateTime.Parse(input_gebdat.Text);
                }

                if (input_erstkontakt.Text == "")
                {
                    currentKlient.Erstkontakt = DateTime.Today;
                }
                else
                {
                    currentKlient.Erstkontakt = DateTime.Parse(input_erstkontakt.Text);
                }
                
                // Geschlecht Radio Buttons
                if (M.Checked == true)
                {
                    currentKlient.Geschlecht = "M";
                }
                else if (W.Checked == true)
                {
                    currentKlient.Geschlecht = "W";
                }

                // AVATAR Image URL
                currentKlient.Avatar = (string)Session["dbimgpath"];

                if (currentKlient.saveKlient())
                    return true;

                else return false;
            }
            else return false;

        }

        // Klienten Speichern
        protected void btnSaveClick(object sender, EventArgs e)
        {
            if (saveKlient())
            {
                Response.Redirect("KlientenAuswahl.aspx");
            }
            else
                lblFehlermeldung.Text = "Speichern fehlgeschlagen";
        }

        protected void btnSaveClickBeratung(object sender, EventArgs e)
        
        {
            Session["beratungsID"] = null;
            Session["Klient"] = currentKlient; //neues leeres Kundenobjekt
            if (saveKlient())
            {
                Response.Redirect("Beratungen.aspx");
            }
            else
                lblFehlermeldung.Text = "Speichern fehlgeschlagen";
        }

        protected void btnCancelClick(object sender, EventArgs e)
        {
            Response.Redirect("KlientenAuswahl.aspx"); //ohne Speichern zur Hauptseite
        }

        protected void FileUploadComplete(object sender, EventArgs e)
        {
            string thumbnailextension = "200px";
            string guid = Guid.NewGuid().ToString();
            string filePath = Server.MapPath(Start.Path_image) + guid + "-" + System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
            string pathjs = Start.Path_image + guid + "-" + thumbnailextension + "-" + System.IO.Path.GetFileName(AsyncFileUpload1.FileName);

            AsyncFileUpload1.SaveAs(filePath);
            AsyncFileUpload1.ResolveUrl(filePath);

            CreateThumbnailImage(filePath, Server.MapPath(pathjs), 200);
            Session["dbimgpath"] = pathjs;

            if (currentKlient == null)
            {
                initializeKlient();
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "size", "top.$get(\"" + imgDisplay.ClientID + "\").src = '" + pathjs + "';", true);
        }


        protected void input_avatar_UploadError(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            lblFehlermeldung.Text = "Bild upload fehlgeschlagen!";
        }

        public static string CreateThumbnailImage(string sourceImage, string thumbnailFilename, int maxImageSize)
        {
            int thumbnailWidth;
            int thumbnailHeight;

            // Determine thumbnail filename


            // Open original image and determine thumbnail size based on image dimensions and the max image size
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(sourceImage);
            int sourceWidth = originalImage.Width;
            int sourceHeight = originalImage.Height;
            double widthHeightRatio = (double)sourceWidth / (double)sourceHeight;

            // If width greater than height, then width should be max image size, otherwise height should be.
            // Image should keep the same proportions.
            if (widthHeightRatio > 1.0)
            {
                thumbnailWidth = maxImageSize;
                thumbnailHeight = (int)(maxImageSize / widthHeightRatio);
            }
            else
            {
                thumbnailWidth = (int)(maxImageSize * widthHeightRatio);
                thumbnailHeight = maxImageSize;
            }

            // Create bitmap and graphics objects for the new image
            System.Drawing.Bitmap thumbnailBitmap = new System.Drawing.Bitmap(thumbnailWidth, thumbnailHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(thumbnailBitmap);

            // set graphics parameters to optimize thumbnail image
            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Transform image to new size and save thumbnail
            g.DrawImage(originalImage, 0, 0, thumbnailWidth, thumbnailHeight);
            thumbnailBitmap.Save(thumbnailFilename, originalImage.RawFormat);

            // Return thumbnail filename
            return System.IO.Path.GetFileName(thumbnailFilename);
        }
    }
}
