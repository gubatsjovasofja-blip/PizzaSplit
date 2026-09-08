using PizzaSplit.Core;

Console.Write("Sisesta tellimuse summa (€): ");
string? totalInput = Console.ReadLine();

Console.Write("Sisesta sööjate arv: ");
string? peopleInput = Console.ReadLine();

Console.Write("Lisa 10% jootraha? (jah/ei): ");
string? tipInput = Console.ReadLine();

if (!decimal.TryParse(totalInput, out decimal total))
{
    Console.WriteLine("Viga: summa peab olema number.");
    return;
}

if (!int.TryParse(peopleInput, out int people))
{
    Console.WriteLine("Viga: sööjate arv peab olema täisarv.");
    return;
}

bool addTip = tipInput?.Trim().ToLower() == "jah";

if (BillCalculator.TryCalculate(
    total,
    people,
    addTip,
    out decimal share,
    out string error))
{
    Console.WriteLine($"Ühe sööja kohta: {share:F2} €");
}
else
{
    Console.WriteLine($"Viga: {error}");
}