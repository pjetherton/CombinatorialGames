/* Copyright (c) 2014 Paul Etherton
 */

using System.Collections.Generic;
using System.Linq;

namespace CombinatorialGames
{
    public class IntegerGame : CombinatorialGame
    {
        public IntegerGame(int integer)
        {
            this._Integer = integer;
        }

        public override IEnumerable<CombinatorialGame> Children(Player player)
        {
            if (player == Player.Left && _Integer > 0)
            {
                yield return new IntegerGame(_Integer - 1);
            }
            else if (player == Player.Right && _Integer < 0)
            {
                yield return new IntegerGame(_Integer + 1);
            }
            else
            {
                yield break;
            }
        }

        private int _Integer;
    }
}
