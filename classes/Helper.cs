using System;

namespace PACBZE.classes
{

    static public class Helper
    {

        static public GameField createGamefield()
        {
            GameField gamef = new GameField();
            gamef.FieldName = "Testspielfeld";
            gamef.GameFieldContent = new System.Collections.Generic.List<object>();

            Wall w = new Wall();
            w.x = 1;
            w.y = 1;



            Coin co = new Coin();
            co.x = 10;
            co.y = 10;

            Coin co1 = new Coin();
            co1.x = 3;
            co1.y = 10;
            Coin co2 = new Coin();
            co2.x = 10;
            co2.y = 3;

            Monster mo = new Monster();
            mo.x = 13;
            mo.y = 13;

            Monster mo1 = new Monster();
            mo1.x = 15;
            mo1.y = 10;





            gamef.GameFieldContent.Add(co);// Coin zum Spielfeld
            gamef.GameFieldContent.Add(co1);// Coin zum Spielfeld
            gamef.GameFieldContent.Add(co2);// Coin zum Spielfeld
            gamef.GameFieldContent.Add(mo);// Monster zum Spielfeld
            gamef.GameFieldContent.Add(mo1);// Monster zum Spielfeld


            byte maxX = 20;
            byte maxY = 15;
            // Rahmen zeichnen
            for (byte i = 1; i <= maxX; i++)
            {
                for (byte y = 1; y <= maxY; y++)
                {
                    if ((i == 1 || i == maxX) || (y == 1 || y == maxY))
                    {
                        Wall t = new Wall();
                        t.x = i;
                        t.y = y;
                        gamef.GameFieldContent.Add(t);
                    }


                }

            }
            PacBze pac = new PacBze();
            pac.x = 5;
            pac.y = 5;
            pac.Life = 3;

            gamef.GameFieldContent.Add(pac);// Pacman zum Spielfeld
            return gamef;

        }




    }

    public enum Direction
    {
        none,
        up,
        down,
        left,
        right


    }
    public enum GameStatus
    {
        running,
        gameover,
        succesful

    }

    public interface IGameInputOutput
    {

        Gamer get_Gamer();
        void draw_Field(GameField field, Gamer g);
        Direction get_Control();
        void show_succesfuly(GameField field, Gamer g);
        void show_gameover(GameField field, Gamer g);
        void show_highscore(HighScore scoreboard);




    }
}