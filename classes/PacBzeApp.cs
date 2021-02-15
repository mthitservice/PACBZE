using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
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
            // Highscore Laden
            this.load_highscore();

            // Spielernamen erfragen
            this.get_Gamer();

            // Spielfeld darstellen
            this.draw_Field();
            // Spiel starten
            #endregion

            #region "Game Loop"

            int zl = 0;
            do
            { // Verarbeitung 
              // Tastendruck SPieler auswerten
                Direction d;
                d = this.get_Control();
                // Spielfiguren setzen
                this.set_Figur(d);
                // Monster Bewegen
                zl++;
                if (zl > 25)
                {
                    this.set_monster();
                    zl = 0;
                }
                // Spiellregeln prüfen
                this.check_rules(ref _gameStatus);
                // Wenn Spielzustand nächster Zug - Springe zu "Spiel STarte"
                this.draw_Field(); //nur zeichnen wenn  Bewegung im spiel

            } while (_gameStatus == GameStatus.running);
            #endregion
            // Ende mit Gratulation : Ausgabe Herzlichen Glückwunsch
            #region "End Game"
            switch (this._gameStatus)
            {
                case GameStatus.succesful:
                    this.show_succesfuly();
                    break;
                case GameStatus.gameover:
                    this.show_gameover();
                    break;


            }
            // Ende: Ausgabe Heighscore
            this.show_highscore();
            this.save_highscore();
            // AUsgabe
            #endregion
        }
        // Konstruktor
        #region "Konstruktor"
        public PacBzeApp()
        {
            this._currenGamer = new Gamer();
            this._gameStatus = new GameStatus();
            this._gameStatus = GameStatus.running;
            this._highScore = new HighScore();
            this.IOHelper = new Game_io();
            this._gameField = Helper.createGamefield();


        }
        #endregion
        // Spielmethoden
        #region "Game Methods"
        private void get_Gamer()
        {
            _currenGamer = IOHelper.get_Gamer();

        }

        private void draw_Field()
        {
            IOHelper.draw_Field(this._gameField, _currenGamer);

        }
        private Direction get_Control()
        {
            Direction tempDir = Direction.none;
            tempDir = IOHelper.get_Control();

            return tempDir;

        }
        private void set_Figur(Direction dir)
        {

            // Suche aktuellen PacMan
            PacBze pac = this._gameField.getPacBze();
            byte x = pac.x;
            byte y = pac.y;

            switch (dir)
            {
                case Direction.down:
                    pac.y += 1;
                    break;
                case Direction.up:
                    pac.y -= 1;
                    break;
                case Direction.left:
                    pac.x -= 1;
                    break;
                case Direction.right:
                    pac.x += 1;
                    break;


            }

            List<object> Figuren = _gameField.getFieldInfo(pac.x, pac.y);
            foreach (var o in Figuren)
            {
                switch (o.GetType().ToString())
                {

                    case "PACBZE.classes.Wall":
                        pac.x = x;
                        pac.y = y;

                        break;


                }


            }




        }

        private void save_highscore()
        {

            FileStream fs = new FileStream(@"c:\temp\highscore.csv", FileMode.OpenOrCreate, FileAccess.Write);




            BinaryFormatter bf = new BinaryFormatter();
            using (var gZipStream = new GZipStream(fs, CompressionMode.Compress))
            {
                bf.Serialize(gZipStream, _highScore);

            }
            fs.Close();



        }
        private void load_highscore()
        {
            FileStream fs = new FileStream(@"c:\temp\highscore.csv", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            using (var z = new GZipStream(fs, CompressionMode.Decompress))
            {
                var x = (HighScore)bf.Deserialize(z);




                foreach (Gamer o in x)
                {
                    _highScore.Add(o);

                }
            }

            fs.Close();
        }


        private void check_rules(ref GameStatus status)
        {

            // Prüfen ob Coin gefressen
            PacBze pac = _gameField.getPacBze();

            List<object> Figuren = _gameField.getFieldInfo(pac.x, pac.y);
            foreach (var o in Figuren)
            {
                switch (o.GetType().ToString())
                {

                    case "PACBZE.classes.Coin":

                        pac.SaveCoins.Add((Coin)o);
                        _gameField.GameFieldContent.Remove(o);
                        Console.Beep();
                        if (_gameField.getCoinCount() == 0)
                        {
                            _currenGamer.Score = _currenGamer.Score + pac.SaveCoins.Count;
                            _highScore.Add(_currenGamer);
                            status = GameStatus.succesful;

                        }


                        break;

                    case "PACBZE.classes.Monster":
                        pac.Life--;
                        if (pac.Life < 1)
                        {
                            status = GameStatus.gameover;

                        }



                        break;


                }


            }



        }
        private void show_succesfuly()
        {

            IOHelper.show_succesfuly(this._gameField, this._currenGamer);

        }
        private void show_gameover()
        {

            IOHelper.show_gameover(this._gameField, this._currenGamer);

        }
        private void show_highscore()
        {
            IOHelper.show_highscore(this._highScore);
        }

        private void set_monster()
        {
            // Finden der Monster auf dem Spielfeld
            List<Monster> Monsterliste = new List<Monster>();
            foreach (var o in _gameField.GameFieldContent)
            {
                switch (o.GetType().ToString())
                {

                    case "PACBZE.classes.Monster":
                        Monsterliste.Add((Monster)o);

                        break;
                }

            }


            // Setzen der Monster
            foreach (Monster monsi in Monsterliste)
            {
                Random zufall = new Random();
                Direction d = Direction.none;
                byte x = monsi.x;
                byte y = monsi.y;

                // Zufallsrichtung festlegen
                d = (Direction)zufall.Next(0, 5);
                // Monster setzen
                switch (d)
                {
                    case Direction.down:
                        monsi.y += 1;
                        break;
                    case Direction.up:
                        monsi.y -= 1;
                        break;
                    case Direction.left:
                        monsi.x -= 1;
                        break;
                    case Direction.right:
                        monsi.x += 1;
                        break;


                }
                // prüfern ob Wand
                List<object> Figuren = _gameField.getFieldInfo(monsi.x, monsi.y);
                foreach (var o in Figuren)
                {
                    switch (o.GetType().ToString())
                    {

                        case "PACBZE.classes.Wall":
                            monsi.x = x;
                            monsi.y = y;

                            break;


                    }


                }


            }



        }

        #endregion


    }
}