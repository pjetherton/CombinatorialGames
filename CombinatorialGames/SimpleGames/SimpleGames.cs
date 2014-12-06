/* Copyright (c) 2014 Paul Etherton
 */

namespace CombinatorialGames.SimpleGames
{
    public class StarGame : ChoicelessGame
    {
        public StarGame()
            : base(new IntegerGame(0), new IntegerGame(0))
        {
        }
    }

    public class UpGame : ChoicelessGame
    {
        public UpGame()
            : base(new IntegerGame(0), new StarGame())
        {
        }
    }

    public class DownGame : ChoicelessGame
    {
        public DownGame()
            : base(new StarGame(), new IntegerGame(0))
        {
        }
    }
}
