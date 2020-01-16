using System;
using System.Collections.Generic;

namespace GenerateResourceDictionaryFromResx
{
   class Program
   {
      private static List<string> keys = new List<string>(9)
                                 {
                                    "IDS_ClipSpeed_Duration",
                                    "IDS_ClipSpeed_Frames",
                                    "IDS_ClipSpeed_Minutes",
                                    "IDS_ClipSpeed_Note_Audio",
                                    "IDS_ClipSpeed_Percent",
                                    "IDS_ClipSpeed_Seconds",
                                    "IDS_ClipSpeed_Silence",
                                    "IDS_ClipSpeed_Speed",
                                    "IDS_ClipSpeed_Tray",
                                    //"IDS_Demo"
                                 };
      static void Main( string[] args )
      {
         foreach ( string s in keys )
         {
            Resources.CurrentCulture = "en-US";
            Console.WriteLine( "English: " + s );
            Console.WriteLine( typeof( Resources ).GetProperty( s ).GetValue( typeof( Resources ) ) );
            Console.WriteLine( string.Empty );

            Resources.CurrentCulture = "de-DE";
            Console.WriteLine( "German: " + s );
            Console.WriteLine( typeof( Resources ).GetProperty( s ).GetValue( typeof( Resources ) ) );
            Console.WriteLine( string.Empty );

            Resources.CurrentCulture = "fr-FR";
            Console.WriteLine( "French: " + s );
            Console.WriteLine( typeof( Resources ).GetProperty( s ).GetValue( typeof( Resources ) ) );
            Console.WriteLine( string.Empty );
         }
         Console.ReadLine();
      }
   }
}
