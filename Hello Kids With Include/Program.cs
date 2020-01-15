using System;
using Hello;

namespace Hello_Kids
{
   class Program
   {
      public static void Main()
      {
         StoredNames selected = StoredNames.Devin;
         int i = 0;
         bool continueRun = true;
         while ( continueRun )
         {
            Console.WriteLine( "Which kid is in trouble? (or press q to quit )" );
            foreach ( string s in Enum.GetNames( typeof( Hello.StoredNames ) ) )
            {
               Console.WriteLine( $"{++i}. {s}" );
            }
            string entry = Console.ReadLine();
            if ( entry == "q" )
            {
               continueRun = false;
            }
            else if ( Enum.TryParse<StoredNames>( entry, out selected ) )
            {
               selected--;
               i = 0;
               Console.WriteLine();
               Console.WriteLine( GetTroubleCall( selected ) );
               Console.WriteLine();
            }
         }
      }

      private static string GetTroubleCall( StoredNames name )
      {
         switch ( name )
         {
            case StoredNames.Devin:
               return "Devin Matthew!";
            case StoredNames.Grace:
               return "Grace Victoria!";
            case StoredNames.Nathan:
               return "Nathan Michael!";
            case StoredNames.Colin:
               return "Colin Thomas!";
            case StoredNames.Rose:
               return "Rose Kathryn-Ann!";
            case StoredNames.Ethan:
               return "Ethan Xavier!";
            case StoredNames.William:
               return "William Dennis!";
            case StoredNames.Benjamin:
               return "Benjamin Joseph!";
            default:
               return name.ToString() + " !";
         }
      }
   }
}
