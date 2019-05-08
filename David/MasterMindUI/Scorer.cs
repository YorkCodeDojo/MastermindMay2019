using System;

namespace MasterMindUI
{
    class Scorer
    {
        public Score ScoreGuess(Combination target, Combination guess)
        {
            int Compare(int p1, int p2) => (p1 == p2) ? 1 : 0;

            var result = new Score();

            result.Correct = Compare(target.Peg1, guess.Peg1) +
                           Compare(target.Peg2, guess.Peg2) +
                           Compare(target.Peg3, guess.Peg3) +
                           Compare(target.Peg4, guess.Peg4);

            var correctColour1 = CountColour(target, guess, 1);
            var correctColour2 = CountColour(target, guess, 2);
            var correctColour3 = CountColour(target, guess, 3);
            var correctColour4 = CountColour(target, guess, 4);
            var correctColour5 = CountColour(target, guess, 5);
            var correctColour6 = CountColour(target, guess, 6);

            result.WrongPosition = (correctColour1 +
                           correctColour2 +
                           correctColour3 +
                           correctColour4 +
                           correctColour5 +
                           correctColour6) - result.Correct;


            return result;
        }

        private int CountColour(Combination target, Combination guess, int colour)
        {
            int Compare(int p1, int p2) => (p1 == p2) ? 1 : 0;

            var ideal = Compare(target.Peg1, colour) +
                        Compare(target.Peg2, colour) +
                        Compare(target.Peg3, colour) +
                        Compare(target.Peg4, colour);

            var guessed = Compare(guess.Peg1, colour) +
                          Compare(guess.Peg2, colour) +
                          Compare(guess.Peg3, colour) +
                          Compare(guess.Peg4, colour);

            return Math.Min(ideal, guessed);
        }

        internal object ScoreGuess(object target, Combination guess)
        {
            throw new NotImplementedException();
        }
    }
}
