using System;
using System.Collections.Generic;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string[] cities = { "Казань", "Москва", "Сочи", "Санкт-Петербург", "Чебоксары" };
Road[] roads =
{
    new Road(0, 1, 800),
    new Road(0, 4, 160),
    new Road(1, 3, 710),
    new Road(1, 2, 1620),
    new Road(4, 2, 1800)
};

const int start = 0;
var connected = new List<string> { cities[start] };
int step = 0;
long total = 0;

Console.WriteLine("Алгоритм Прима");
Console.WriteLine($"Шаг 0. Начальный город: {cities[start]}");

try
{
    foreach (Road road in Prim.Build(cities.Length, roads, start))
    {
        string from = cities[road.From];
        string to = cities[road.To];
        connected.Add(connected.Contains(from) ? to : from);
        total += road.Weight;

        Console.WriteLine($"\nШаг {++step}. {from} — {to} ({road.Weight} км)");
        Console.WriteLine($"Города в дереве: {string.Join(", ", connected)}");
        Console.WriteLine($"Вес выбранных дорог: {total} км");
    }
}
catch (InvalidOperationException error)
{
    Console.Error.WriteLine(error.Message);
    return 1;
}

Console.WriteLine($"\nИтог: дорог — {step}, общий вес — {total} км.");
return 0;
