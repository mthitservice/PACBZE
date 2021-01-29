using System;
using System.Collections.Generic;

namespace PACBZE.classes
{
   public class  PacBze:Figur
    {     

        public Direction ViewDirection { get; set; }         
        private List<Coin> _savecoins;
        private ushort _life;
        
        public ushort Life{
            get { return _life;}
            set { _life=value;}
        }
        
        public List<Coin> SaveCoins
        {
            get { return _savecoins; }
            set { _savecoins = value; }
        }
         // Konstruktor
         public PacBze ()
         {
             _savecoins=new List<Coin>();
             ViewDirection= Direction.left;
         }       


    }
}