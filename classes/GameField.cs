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
           


    }
}