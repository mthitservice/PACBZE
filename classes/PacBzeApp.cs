using System;

namespace PACBZE.classes
{
   public class PacBzeApp 
    {              
        private Gamer _currenGamer;
        public void start()
        {

            // Eingabe
            // Spielernamen erfragen
            this.get_Gamer();

            // Spielfeld darstellen

            // Spiel starten
                // Tastendruck SPieler auswerten
                // Spielfiguren setzen
                // Spiellregeln prüfen
            // Wenn Spielzustand Gamer Over -> Ende
            // Wenn Spielzustand Succesfuly -> Ende mit Gratulation
            // Wenn Spielzustand nächster Zug - Springe zu "Spiel STarte"



            // Verarbeitung 
            // Ende mit Gratulation : Ausgabe Herzlichen Glückwunsch
            // Ende: Ausgabe Heighscore

            // AUsgabe
        }
        // Konstruktor
        public PacBzeApp()
        {
            this._currenGamer=new Gamer();

        }

        // Spielmethoden
        private void get_Gamer()
        {


        }

    }
}