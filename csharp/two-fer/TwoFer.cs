using System;

  public static class TwoFer
  {
      public static string Name(string input)
      {
          return $"One for {input??"you"}, one for me.";
      }

      public static string Name()
      {
          return Name("you");
      }
  }
