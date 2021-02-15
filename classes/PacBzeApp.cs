using System;
using System.Collections.Generic;
using PACBZE.ui;

namespace PACBZE.classes
{
   public class PacBzeApp 
    {              
        private Gamer _currenGamer;
        private GameStatus _gameStatus;
        private HighScore _highScore;
       private GameField _gameField;

        private IGameInputOutput IOHelper;

        public void start()
        {
#region "Deklarationsbereich"
            // Eingabe
            // Spielernamen erfragen
            this.get_Gamer();
            // Spielfeld darstellen
            this.draw_Field();
            // Spiel starten
#endregion
            
 #region "Game Loop"
     
           
            do{ // Verarbeitung 
                // Tastendruck SPieler auswerten
            Direction d;
            d=this.get_Control();
                // Spielfiguren setzen
            this.set_Figur(d);
                // Spiellregeln prüfen
            this.check_rules();
             // Wenn Spielzustand nächster Zug - Springe zu "Spiel STarte"
           if (d!=Direction.none) this.draw_Field(); //nur zeichnen wenn  Bewegung im spiel

            } while(_gameStatus== GameStatus.running);
  #endregion
            // Ende mit Gratulation : Ausgabe Herzlichen Glückwunsch
 #region "End Game"
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
 #endregion
        }
        // Konstruktor
        #region "Konstruktor"
        public PacBzeApp()
        {
            this._currenGamer=new Gamer();
            this._gameStatus=new GameStatus();
            this._gameStatus=GameStatus.running;
            this._highScore=new HighScore();
            this.IOHelper=new Game_io();
            this._gameField=Helper.createGamefield();
           

        }
    #endregion
        // Spielmethoden
        #region "Game Methods"
        private void get_Gamer()
        {_currenGamer=  IOHelper.get_Gamer();

        }      
       
          private void draw_Field()
        {
            IOHelper.draw_Field(this._gameField,_currenGamer);

        }
        private Direction get_Control()
        {
            Direction tempDir=Direction.none;
           tempDir= IOHelper.get_Control();

            return tempDir;

        }
        private void set_Figur(Direction dir){

        // Suche aktuellen PacMan
        PacBze pac= this._gameField.getPacBze();

               switch (dir) 
               {
                   case Direction.down:
                        pac.y+=1;
                   break;
                   case Direction.up:
                        pac.y-=1;
                   break;
                       case Direction.left:
                        pac.x-=1;
                   break;
                   case Direction.right:
                pac.x+=1;
                   break;





               }
        }

        private void check_rules()
        {

          // Prüfen ob Coin gefressen
          PacBze pac= _gameField.getPacBze();

        List<object> Figuren =_gameField.getFieldInfo(pac.x,pac.y);
            foreach (var o in Figuren)
            {
                   switch (o.GetType().ToString()) 
                   {

                       case "PACBZE.classes.Coin":

                            pac.SaveCoins.Add((Coin)o);
                            _gameField.GameFieldContent.Remove(o);
                            _currenGamer.Score=_currenGamer.Score+pac.SaveCoins.Count;

                           
                       break;


                   }


            }


            
        }
        private void show_succesfuly()
        {

                IOHelper.show_succesfuly(this._gameField);

        }
        private void show_gameover()
        {

            IOHelper.show_gameover(this._gameField);

        }
        private void show_highscore()
        {
                IOHelper.show_highscore(this._highScore);
        }

     
        #endregion


    }
}