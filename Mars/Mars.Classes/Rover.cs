using System.Drawing;
using System;

namespace Mars.Classes
{
    public class Rover
    {
        public enum Direzione { N, S, E, O };

        #region Properties
        public Point PosizioneAttuale { get; set; }

        public Direzione DirezioneAttuale { get; set; }

        private SuperficieMarte Marte;
        #endregion

        #region Constructors
        public Rover(int X = 0, int Y = 0, Direzione direzione = Direzione.N)
        {
            try
            {
                PosizioneAttuale = new Point(X, Y);
                DirezioneAttuale = direzione;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Methods
        public string CreaSuperficie(SuperficieMarte marte)
        {
            try
            {
                string msg = string.Empty;
                Marte = marte;
                while (marte.Ostacoli.Contains(PosizioneAttuale))
                    Avanti(ref msg);
                return $"Ci sono ostacoli nella posizione di partenza del rover. Rover atterato alla seguente posizione ({PosizioneAttuale.X},{PosizioneAttuale.Y}). \n";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Avanti(ref string msg)
        {
            try
            {
                switch (DirezioneAttuale)
                {
                    case Direzione.N:
                        AumentaY();
                        break;

                    case Direzione.S:
                        DiminuisciY();
                        break;

                    case Direzione.E:
                        AumentaX();
                        break;

                    case Direzione.O:
                        DiminuisciX();
                        break;
                }

                if (Marte.Ostacoli.Contains(PosizioneAttuale))
                {
                    msg += $"Non posso spostarmi avanti, poichè sono presenti ostacoli nella posizione ({PosizioneAttuale.X},{PosizioneAttuale.Y}). \n";

                    Dietro(ref msg);

                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Dietro(ref string msg)
        {
            try
            {
                switch (DirezioneAttuale)
                {
                    case Direzione.N:
                        DiminuisciY();
                        break;

                    case Direzione.S:
                        AumentaY();
                        break;

                    case Direzione.E:
                        DiminuisciX();
                        break;

                    case Direzione.O:
                        AumentaX();
                        break;
                }

                if (Marte.Ostacoli.Contains(PosizioneAttuale))
                {
                    msg += $"Non posso spostarmi dietro, poichè sono presenti ostacoli nella posizione ({PosizioneAttuale.X},{PosizioneAttuale.Y}). \n";

                    Avanti(ref msg);

                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Sinistra()
        {
            try
            {
                switch (DirezioneAttuale)
                {
                    case Direzione.N:
                        DirezioneAttuale = Direzione.O;
                        break;

                    case Direzione.S:
                        DirezioneAttuale = Direzione.E;

                        break;
                    case Direzione.E:
                        DirezioneAttuale = Direzione.N;

                        break;

                    case Direzione.O:
                        DirezioneAttuale = Direzione.S;

                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Destra()
        {
            try
            {
                switch (DirezioneAttuale)
                {
                    case Direzione.N:
                        DirezioneAttuale = Direzione.E;
                        break;

                    case Direzione.S:
                        DirezioneAttuale = Direzione.O;
                        break;

                    case Direzione.E:
                        DirezioneAttuale = Direzione.S;
                        break;

                    case Direzione.O:
                        DirezioneAttuale = Direzione.N;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AumentaX()
        {
            try
            {
                int nuovaX = PosizioneAttuale.X + 1;

                if (nuovaX > Marte.MaxX)
                    nuovaX = Marte.MinX;

                PosizioneAttuale = new Point(nuovaX, PosizioneAttuale.Y);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DiminuisciX()
        {
            try
            {
                int nuovaX = PosizioneAttuale.X - 1;

                if (nuovaX < Marte.MinX)
                    nuovaX = Marte.MaxX;

                PosizioneAttuale = new Point(nuovaX, PosizioneAttuale.Y);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AumentaY()
        {
            try
            {
                int nuovaY = PosizioneAttuale.Y + 1;

                if (nuovaY > Marte.MaxY)
                    nuovaY = Marte.MinY;

                PosizioneAttuale = new Point(PosizioneAttuale.X, nuovaY);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DiminuisciY()
        {
            try
            {
                int nuovaY = PosizioneAttuale.Y - 1;

                if (nuovaY < Marte.MinY)
                    nuovaY = Marte.MaxY;

                PosizioneAttuale = new Point(PosizioneAttuale.X, nuovaY);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public string MostraNuovaPosizione()
        {
            try
            {
                string nuovaDirezione = string.Empty;
                switch (DirezioneAttuale)
                {
                    case Direzione.N:
                        nuovaDirezione = "N.\n";
                        break;

                    case Direzione.S:
                        nuovaDirezione = "S.\n";
                        break;

                    case Direzione.E:
                        nuovaDirezione = "E.\n";
                        break;

                    case Direzione.O:
                        nuovaDirezione = "O.\n";
                        break;
                }
                return $"Nuova posizione ({PosizioneAttuale.X},{PosizioneAttuale.Y}), con direzione {nuovaDirezione}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
