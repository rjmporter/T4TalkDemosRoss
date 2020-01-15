using System;
using Hello;
using System.Speech.Synthesis;

namespace Hello_Kids
{
   class Program
   {
      static SpeechSynthesizer synth = new SpeechSynthesizer();
      static string speachSynthSySLFormat = @"<?xml version='1.0'?>
<speak version='1.0'
       xmlns='http://www.w3.org/2001/10/synthesis'
       xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'
       xsi:schemaLocation='http://www.w3.org/2001/10/synthesis
                 http://www.w3.org/TR/speech-synthesis10/synthesis.xsd'
       xml:lang='en-US'>

  <s><emphasis level='strong' >{0}</emphasis><emphasis level='strong' >{1}</emphasis> What have you done?</s></speak>";
      public static void Main()
      {
         synth.SetOutputToDefaultAudioDevice();
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
               string troubleCall = GetTroubleCall( selected );
               Console.WriteLine( troubleCall );
               synth.SpeakSsml( string.Format( speachSynthSySLFormat, troubleCall.Split(' ')[0], troubleCall.Split( ' ' )[1] ) );
               Console.WriteLine();
            }
         }
         synth.Dispose();
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
               return name.ToString() + "!";
         }
      }
   }
}
