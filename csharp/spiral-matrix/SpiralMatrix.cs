using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var numbers = new Stack<int>(Enumerable.Range(1, size * size).Reverse());
        var result = new int[size, size];
        int totalSize = size * size;
        int leftBoundary = 0;
        int rightBoundary = size - 1;
        int topBoundary = 0;
        int bottomBoundary = size - 1;
        int elementsPopulated = 0;
        while (elementsPopulated < totalSize)
        {
            for (int col = leftBoundary; col <= rightBoundary; col++)
            {
                result[topBoundary, col] = numbers.Pop();
                elementsPopulated++;
            }
            topBoundary++;
            for (int row = topBoundary; row <= bottomBoundary; row++)
            {
                result[row, rightBoundary] = numbers.Pop();
                elementsPopulated++;
            }
            rightBoundary--;
            for (int col = rightBoundary; col >= leftBoundary; col--)
            {
                result[bottomBoundary, col] = numbers.Pop();
                elementsPopulated++;
            }
            bottomBoundary--;
            for (int row = bottomBoundary; row >= topBoundary; row--)
            {
                result[row, leftBoundary] = numbers.Pop();
                elementsPopulated++;
            }
            leftBoundary++;
        }
        return result;
    }
}
