namespace MasterMindUI
{
    internal class Score
    {
        public int Correct { get; set; }
        public int WrongPosition { get; set; }

        public override bool Equals(object obj)
        {
            var score = (Score)obj;
            return (score.Correct == Correct && score.WrongPosition == WrongPosition);
        }
    }
}
