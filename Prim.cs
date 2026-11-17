using System;
using System.Collections.Generic;

static class Prim
{
    public static IEnumerable<Road> Build(int cityCount, IReadOnlyList<Road> roads, int start)
    {
        var included = new bool[cityCount];
        included[start] = true;

        for (int count = 1; count < cityCount; count++)
        {
            Road? best = null;
            foreach (Road road in roads)
            {
                // Дорога подходит, если ровно один её конец уже в дереве.
                if (included[road.From] == included[road.To])
                    continue;

                if (best is null || road.Weight < best.Weight)
                    best = road;
            }

            if (best is null)
                throw new InvalidOperationException("Граф несвязный. Остовного дерева нет.");

            included[best.From] = true;
            included[best.To] = true;
            yield return best;
        }
    }
}
