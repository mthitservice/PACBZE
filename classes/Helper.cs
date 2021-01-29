using System;

namespace PACBZE.classes
{

    static public class Helper
    {

     static public GameField createGamefield()
     {
         GameField gamef=new GameField();
            gamef.FieldName="Testspielfeld";
            gamef.GameFieldContent= new System.Collections.Generic.List<object>();

            Wall w = new Wall();
            w.x=1;
            w.y=1;

           

           Coin co=new Coin();
            co.x=10;
            co.y=10;
            Monster mo=new Monster();
            mo.x=13;
            mo.y=13;

           

         
            gamef.GameFieldContent.Add(co);// Coin zum Spielfeld
            gamef.GameFieldContent.Add(mo);// Monster zum Spielfeld
       

            byte maxX=20;
            byte maxY=15;
            // Rahmen zeichnen
            for (byte i=1;i<=maxX;i++){
                    for(byte y=1;y<=maxY;y++)
                    {
                    if ((i==1 || i==maxX) || (y==1 || y==maxY)){
                            Wall t = new Wall();
                            t.x=i;
                            t.y=y;
                            gamef.GameFieldContent.Add(t); 
                    }
                   

                    }

            }
 PacBze pac=new PacBze();
            pac.x=5;
            pac.y=5;
            pac.Life=3;

   gamef.GameFieldContent.Add(pac);// Pacman zum Spielfeld
        return gamef;

     }




    }

    public enum Direction{
        none,
        up,
        down,
        left,
        right


    }
    public enum GameStatus{
        running,
        gameover,
        succesful

    }

    public interface IGameInputOutput{

       Gamer get_Gamer();
        void draw_Field(GameField field);
         Direction get_Control();
          void show_succesfuly(GameField field);
         void show_gameover(GameField field);
         void show_highscore(HighScore scoreboard);
     
     


    }
}