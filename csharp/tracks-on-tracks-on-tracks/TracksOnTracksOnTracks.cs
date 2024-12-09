using System;
using System.Collections.Generic;
using System.Linq;

public static class Languages
{
    public static List<string> NewList()
        => new List<string>();

    public static List<string> GetExistingLanguages()
        => new List<string> { "C#", "Clojure", "Elm" };

    public static List<string> AddLanguage(List<string> languages, string language)
        => Enumerable.Concat(languages, [language]).ToList();

    public static int CountLanguages(List<string> languages)
        => languages.Count();

    public static bool HasLanguage(List<string> languages, string language)
        => languages.Any(l => l == language);

    public static List<string> ReverseList(List<string> languages)
        => Enumerable.Reverse(languages).ToList();

    public static bool IsExciting(List<string> languages)
    {
        int count = languages.Count();
        return count > 0 && count <= 3
            && languages
                .Take(count)
                .Any(l => l == "C#");
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
        => !languages
            .GroupBy(l => l)
            .Where(l => l.Count() > 1)
            .Any();
}
