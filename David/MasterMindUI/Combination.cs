namespace MasterMindUI
{
    internal class Combination
    {
        public int Peg1 { get; private set; }
        public int Peg2 { get; private set; }
        public int Peg3 { get; private set; }
        public int Peg4 { get; private set; }

        public Combination(int peg1, int peg2, int peg3, int peg4)
        {
            Peg1 = peg1;
            Peg2 = peg2;
            Peg3 = peg3;
            Peg4 = peg4;
        }

        public override string ToString() => $"{Peg1} {Peg2} {Peg3} {Peg4}";
    }
}
