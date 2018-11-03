using System;

  public static class TwoFer
  {
      private const string template = "One for {0}, one for me.";
      public static string Name(string input = null)
      {
          return string.Format(template, input??"you");
      }
  }
