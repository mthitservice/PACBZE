using System;
using System.Collections.Generic;
namespace PACBZE.classes
{
   public class GameField
    {              
            public string FieldName { get; set; }
            

            private List<object> _gamefieldcontent;
            public List<object> GameFieldContent
            {
                get { return _gamefieldcontent; }
                set { _gamefieldcontent= value; }
            }
           
       public PacBze getPacBze()
        {
            // Suche Pacman auf dem Feld
            PacBze x = null;

            foreach (object o in this._gamefieldcontent)
            {
                switch (o.GetType().ToString())
                {
                    case "PACBZE.classes.PacBze":
                        x = (PacBze)o;
                        return x;
                      

                }
            }
            return x;
        }

        public List<object> getFieldInfo(byte x, byte y)
        {   // Wer steht alles auf dem Feld rum
            List<object> templ = new List<object>();
            foreach (object o in this.GameFieldContent)
            {
                Figur f = (Figur)o;
                if (f.x==x && f.y==y)
                {
                    templ.Add(o);

                }


            }

            return templ;
        }


    }
}