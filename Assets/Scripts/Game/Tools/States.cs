namespace SecondChanse.Game.Tools
{
    public class States
    {
        public enum GameState
        {
            Null,
            Play,
            PlayBoard,
            OpenCard,
            ReadStory,
            Menu,
            PlayAgain
        }
        public enum EndingState
        {
            Null,
            VeryBadEnd,
            BadEnd,
            NoChangeEnd,
            NormalEnd,
            GoodEnd,
            VeryGoodEnd
        }
    }
}