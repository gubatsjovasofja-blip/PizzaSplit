namespace PizzaSplit.Core
{
    public static class BillCalculator
    {
        public static bool TryCalculate(
            decimal total,
            int people,
            bool addTip,
            out decimal share,
            out string error)
        {
            share = 0;
            error = "";

            if (total <= 0 || total > 10000)
            {
                error = "Summa peab olema suurem kui 0 ja kuni 10 000 €.";
                return false;
            }

            if (decimal.Round(total, 2) != total)
            {
                error = "Summal võib olla kuni kaks komakohta.";
                return false;
            }

            if (people < 1 || people > 20)
            {
                error = "Sööjate arv peab olema 1 kuni 20.";
                return false;
            }

            if (addTip)
            {
                total *= 1.10m;
            }

            share = Math.Round(
                total / people,
                2,
                MidpointRounding.AwayFromZero);

            return true;
        }
    }
}