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
          _Backbuffer=new GameField();
          _Backbuffer.GameFieldContent=new List<object>();
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
                li=newfield.getFieldInfo(f.x,f.y);
                if (li.Count==0)
                {
                 Console.SetCursorPosition(f.x,f.y);
                 Console.Write(" ");

                }


            }
            this._Backbuffer.GameFieldContent.Clear();

        }

        public void draw_Field(GameField field)
        {
            killTheTrace(field); //Alte SPuren beseitigen :)
            foreach (object o in field.GameFieldContent)
            {
                  Figur f = (Figur)o;  
                  Figur tf=new Figur(); //Klone anlegen
                  tf.x=f.x;
                  tf.y=f.y;
                
                  Console.SetCursorPosition(f.x,f.y);
                    
                    switch(o.GetType().ToString()){
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



        }

        public Direction get_Control()
        {   Console.CursorVisible = false; // Cursor ausblenden
            Direction tempD=Direction.none;
            ConsoleKeyInfo k=Console.ReadKey(true);
            switch(k.Key){

                case ConsoleKey.A: tempD=Direction.left;
                break;
                 case ConsoleKey.W: tempD=Direction.up;
                break;
                 case ConsoleKey.S: tempD=Direction.down;
                break;
                 case ConsoleKey.D: tempD=Direction.right;
                break;


            }
            Console.CursorVisible = true; // Cursor einblenden
            //throw new NotImplementedException();
            return tempD;
        }

        public Gamer get_Gamer()
        {
            return new Gamer();
        }

        public void show_gameover(GameField field)
        {
            
        }

        public void show_highscore(HighScore scoreboard)
        {
            
        }

        public void show_succesfuly(GameField field)
        {
           
        }
    }
}