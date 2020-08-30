namespace AdventOfCode.Stoichiometry.Models
{
    public class Element
    {
        public Element(string type, int amount = 0)
        {
            Type = type;
            Amount = amount;
        }

        public static Element FromString(string input)
        {
            var split = input.Split(" ");
            var amount = int.Parse(split[0]);
            var type = split[1];
            return new Element(type, amount);
        }

        public string Type { get; }
        public int Amount { get; }

        public string Key => ToString();

        public override string ToString()
        {
            return $"{Amount} {Type.ToUpper()}";
        }
    }
}