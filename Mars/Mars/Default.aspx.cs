using Mars.Classes;
using System;
using System.Web.UI;

namespace Mars
{
    public partial class Default : Page
    {
        static SuperficieMarte marte;
        static Rover rover;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    marte = new SuperficieMarte();
                    rover = new Rover();
                    txtOstacoli.Text = string.Join(" - ", marte.MostraOstacoli());
                    txtMsg.Text = $"Rover atterrato in posizione ({rover.PosizioneAttuale.X},{rover.PosizioneAttuale.Y}), con direzione {rover.DirezioneAttuale}.\n";
                    rover.CreaSuperficie(marte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnInviaComandi_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                bool comandoValido = true;

                foreach (char ch in txtComandi.Text)
                {
                    if (!comandoValido)
                        break;

                    switch (ch)
                    {
                        case 'f':
                            comandoValido = rover.Avanti(ref msg);

                            break;

                        case 'b':
                            comandoValido = rover.Dietro(ref msg);

                            break;

                        case 'l':
                            rover.Sinistra();

                            break;

                        case 'r':
                            rover.Destra();

                            break;
                    }
                }
                txtMsg.Text += msg;
                txtMsg.Text += rover.MostraNuovaPosizione();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnPulisciComandi_Click(object sender, EventArgs e)
        {
            try
            {
                txtComandi.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}