/* Copyright (c) 2014 Paul Etherton
 */

using System.Collections.Generic;
using System.Linq;

namespace CombinatorialGames
{
    public class ChoicelessGame : CombinatorialGame
    {
        public ChoicelessGame(ChoicelessGame leftGame, ChoicelessGame rightGame)
        {
            _LeftGame = leftGame;
            _RightGame = rightGame;
        }

        protected ChoicelessGame()
        {
        }

        public new IEnumerable<ChoicelessGame> Children(Player player)
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

        protected override IEnumerable<CombinatorialGame> GetChildren(Player player)
        {
            return this.Children(player);
        }

        protected virtual ChoicelessGame LeftGame
        {
            get
            {
                return _LeftGame;
            }
        }

        private ChoicelessGame _LeftGame = null;

        protected virtual ChoicelessGame RightGame
        {
            get
            {
                return _RightGame;
            }
        }

        private ChoicelessGame _RightGame = null;
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
