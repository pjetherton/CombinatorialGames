/* Copyright (c) 2014 Paul Etherton
 */

using System.Collections.Generic;
using System.Linq;

namespace CombinatorialGames
{
    public class ChoicelessGame : CombinatorialGame
    {
        public ChoicelessGame(
            ChoicelessGame leftGame,
            ChoicelessGame rightGame)
        {
            _LeftGame = leftGame;
            _RightGame = rightGame;
        }

        public override IEnumerable<CombinatorialGame> Children(Player player)
        {
            var game = (player == Player.Left ? _LeftGame : _RightGame);
            if (game != null)
            {
                yield return game;
            }
            else
            {
                yield break;
            }
        }

        protected ChoicelessGame _LeftGame;

        protected ChoicelessGame _RightGame;
    }

    public class IntegerGame : ChoicelessGame
    {
        public IntegerGame(int integer)
            : base(
                leftGame: (integer > 0 ? new IntegerGame(integer - 1) : null),
                rightGame: (integer < 0 ? new IntegerGame(integer + 1) : null))
        {
        }
    }
}
