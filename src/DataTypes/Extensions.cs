using System.Linq;

namespace LeetCode.DataTypes;

internal static class Extensions
{
    public static int[][] ToJagged(this int[] input, int size)
    {
        return input.Chunk(size).ToArray();
    }
}