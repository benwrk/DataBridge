using System.Collections.Generic;

public static class GameUtility
{
    public static IList<T> CloneListWithRandomOrder<T>(IEnumerable<T> originalList)
    {
        var originalListClone = new List<T>(originalList);
        var randomizedList = new List<T>();

        var random = new System.Random();
        while (originalListClone.Count > 0)
        {
            var randomNumber = random.Next(0, originalListClone.Count);
            randomizedList.Add(originalListClone[randomNumber]);
            originalListClone.RemoveAt(randomNumber);
        }

        return randomizedList;
    }
}