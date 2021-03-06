using System;
using System.Collections.Generic;
using PACBZE.classes;

namespace PACBZE.ui
{
    public class Game_io : IGameInputOutput
    {

        private GameField _Backbuffer;
        public Game_io()
        {
            _Backbuffer = new GameField();
            _Backbuffer.GameFieldContent = new List<object>();
        }

        private void checkBackBuffer()
        {



        }

        private void killTheTrace(GameField newfield)
        {
            // Funktion zum entfernen der Spuren von beweglichen Teilen (Monster und Paggy)
            foreach (Figur f in this._Backbuffer.GameFieldContent)
            {
                // ist alte Pos in neuer Pos leer -> dann löschen
                List<object> li;
                li = newfield.getFieldInfo(f.x, f.y);
                if (li.Count == 0)
                {
                    Console.SetCursorPosition(f.x, f.y);
                    Console.Write(" ");

                }


            }
            this._Backbuffer.GameFieldContent.Clear();

        }

        public void draw_Field(GameField field, Gamer g)
        {
            Console.CursorVisible = false;
            PacBze pac = field.getPacBze();
            int maxy = 0;
            killTheTrace(field); //Alte SPuren beseitigen :)
            foreach (object o in field.GameFieldContent)
            {
                Figur f = (Figur)o;
                Figur tf = new Figur(); //Klone anlegen
                tf.x = f.x;
                tf.y = f.y;

                if (maxy < f.y) { maxy = f.y; }

                Console.SetCursorPosition(f.x, f.y);

                switch (o.GetType().ToString())
                {
                    case "PACBZE.classes.Wall":


                        Console.Write("#");
                        break;
                    case "PACBZE.classes.PacBze":
                        this._Backbuffer.GameFieldContent.Add(tf);
                        Console.Write("@");
                        break;
                    case "PACBZE.classes.Monster":
                        this._Backbuffer.GameFieldContent.Add(tf);
                        Console.Write("M");
                        break;
                    case "PACBZE.classes.Coin":
                        this._Backbuffer.GameFieldContent.Add(tf);
                        Console.Write("*");
                        break;

                }



            }
            maxy = maxy + 1;

            Console.SetCursorPosition(0, maxy);
            Console.Write("Gamer:{0} Coins:{1} Score:{2} Life:{3}", g.GamerName, pac.SaveCoins.Count, g.Score, pac.Life);
            Console.CursorVisible = true;


        }

        public Direction get_Control()
        {
            Console.CursorVisible = false; // Cursor ausblenden
            Direction tempD = Direction.none;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo k = Console.ReadKey(true);
                switch (k.Key)
                {

                    case ConsoleKey.A:
                        tempD = Direction.left;
                        break;
                    case ConsoleKey.W:
                        tempD = Direction.up;
                        break;
                    case ConsoleKey.S:
                        tempD = Direction.down;
                        break;
                    case ConsoleKey.D:
                        tempD = Direction.right;
                        break;


                }
            }
            Console.CursorVisible = true; // Cursor einblenden
            //throw new NotImplementedException();
            return tempD;
        }

        public Gamer get_Gamer()
        {
            string Spielername;
            Gamer Spieler = new Gamer();
            Console.Clear();
            Console.Write("Gib Deinen Namen ein:");
            Spielername = Console.ReadLine();
            Spieler.GamerName = Spielername;
            Console.Clear();

            return Spieler;
        }

        public void show_gameover(GameField field, Gamer g)
        {
            Console.Clear();
            Console.WriteLine("Game Over");
            Console.WriteLine("*********");
            Console.WriteLine("{0} sie haben {1} Punkte.", g.GamerName, g.Score);
            Console.Beep();
            Console.ReadKey();


        }

        public void show_highscore(HighScore scoreboard)
        {
            Console.Clear();
            Console.WriteLine("Highscore");
            Console.WriteLine("*************************************");
            int top = 1;
            foreach (Gamer g in scoreboard)
            {
                Console.WriteLine("{0}\t{1}\t{2}", top, g.GamerName, g.Score);

                top++;
            }
            Console.ReadKey();

        }

        public void show_succesfuly(GameField field, Gamer g)
        {
            Console.Clear();
            Console.WriteLine("You Are the Champ");
            Console.WriteLine("******************");
            Console.WriteLine("{0} sie haben {1} Punkte.", g.GamerName, g.Score);
            Console.Beep();
            Console.Beep();
            Console.Beep();

        }
    }
}