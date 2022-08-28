using LeetCode.DataTypes;
using Xunit;

namespace LeetCode.Medium;

// https:// www.geeksforgeeks.org/rotate-all-matrix-elements-except-the-diagonal-k-times-by-90-degrees-in-clockwise-direction/
public class RotateMatrix
{
    int[][] Rotate(int[][] matrix, int turns)
    {
        if (turns == 4)
            return matrix;

        var n = matrix.Length;

        while (turns > 0)
        {
            for (var i = 0; i < n / 2; i++)
            {
                for (var j = i; j < n - 1 - i; j++)
                {
                    if (i == j || i + j == n - 1)
                        continue;
                    
                    Swap(matrix, i, j);
                }
            }

            turns--;
        }

        return matrix;
    }

    void Swap(int[][] matrix, int i, int j)
    {
        var n = matrix.Length;

        var lastI = n - 1 - i;
        var lastJ = n - 1 - j;

        var tmp = matrix[i][j];
        matrix[i][j] = matrix[lastJ][i];
        matrix[lastJ][i] = matrix[lastI][lastJ];
        matrix[lastI][lastJ] = matrix[j][lastI];
        matrix[j][lastI] = tmp;
    }

    [Theory]
    [InlineData(
        new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 
        5, 1, 
        new[] { 1, 16, 11, 6, 5, 22, 7, 12, 9, 2, 23, 18, 13, 8, 3, 24, 17, 14, 19, 4, 21, 20, 15, 10, 25 })]
    [InlineData(new[] { 10, 11, 12, 13 }, 2, 2, new[] { 10, 11, 12, 13 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 1, new[] { 1, 4, 3, 8, 5, 2, 7, 6, 9 })]
    public void Test(int[] matrix, int size, int turns, int[] expected)
    {
        var actual = Rotate(matrix.ToJagged(size), turns);
        Assert.Equal(expected.ToJagged(size), actual);
    }
}