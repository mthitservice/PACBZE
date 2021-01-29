using System;

namespace PACBZE.classes
{
   public class PacBzeApp 
    {              
        private Gamer _currenGamer;
        private GameStatus _gameStatus;

        private GameField _gameField;
        public void start()
        {

            // Eingabe
            // Spielernamen erfragen
            this.get_Gamer();
            // Spielfeld darstellen
            this.draw_Field();
            // Spiel starten
            do{ // Verarbeitung 
                // Tastendruck SPieler auswerten
            Direction d;
            d=this.get_Control();
                // Spielfiguren setzen
            this.set_Figur(d);
                // Spiellregeln prüfen
            this.check_rules();
             // Wenn Spielzustand nächster Zug - Springe zu "Spiel STarte"
           

            } while(_gameStatus== GameStatus.running);
            // Ende mit Gratulation : Ausgabe Herzlichen Glückwunsch
            switch(this._gameStatus)
            {
                case GameStatus.succesful: this.show_succesfuly();
                break;
                 case GameStatus.gameover: this.show_gameover();
                break;


            }
                // Ende: Ausgabe Heighscore
        this.show_highscore();
            // AUsgabe
        }
        // Konstruktor
        public PacBzeApp()
        {
            this._currenGamer=new Gamer();
            this._gameStatus=new GameStatus();
            this._gameStatus=GameStatus.running;

        }

        // Spielmethoden
        private void get_Gamer()
        {


        }      
        
          private void draw_Field()
        {


        }
        private Direction get_Control()
        {
            Direction tempDir=Direction.none;


            return tempDir;

        }
        private void set_Figur(Direction dir){


        }

        private void check_rules()
        {


            
        }
        private void show_succesfuly()
        {



        }
        private void show_gameover()
        {


        }
        private void show_highscore()
        {

        }
        


    }
}