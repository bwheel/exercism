using System;
using System.Collections.Generic;
using System.Linq;


public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        int count = 0;
        foreach (T item in input)
            count++;
        return count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        int j = input.Count - 1;
        for (int i = 0; i < j; i++)
        {
            (input[i], input[j]) = (input[j], input[i]);
            j--;
        }
        return input;
    }

    private static IEnumerable<TOut> mapElements<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        foreach (var element in input)
            yield return map(element);
    }
    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
        => mapElements(input, map).ToList();

    private static IEnumerable<T> filterElements<T>(List<T> input, Func<T, bool> predicate)
    {
        foreach (var element in input)
            if (predicate(element))
                yield return element;
    }
    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate) =>
        filterElements(input, predicate).ToList();

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        foreach (var element in input)
            start = func(start, element);
        return start;
    }
    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        foreach (var element in Reverse(input))
            start = func(element, start);
        return start;
    }

    public static IEnumerable<T> concatElements<T>(List<List<T>> input)
    {
        foreach (var element in input)
            foreach (var element2 in element)
                yield return element2;
    }
    public static List<T> Concat<T>(List<List<T>> input) =>
        concatElements(input).ToList();


    public static IEnumerable<T> appendElements<T>(List<T> left, List<T> right)
    {
        foreach (var element in left)
            yield return element;
        foreach (var element2 in right)
            yield return element2;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
        => appendElements(left, right).ToList();
}