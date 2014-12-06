/* Copyright (c) 2014 Paul Etherton
 */

namespace CombinatorialGames.SimpleGames
{
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerGame : ChoicelessGame
    {
        public IntegerGame(int integer)
        {
            this.Integer = integer;
        }

        public new IEnumerable<IntegerGame> Children(Player player)
        {
            return base.Children(player).Cast<IntegerGame>();
        }

        protected override ChoicelessGame LeftGame
        {
            get
            {
                return this.Integer > 0 ? new IntegerGame(this.Integer - 1) : null;
            }
        }

        protected override ChoicelessGame RightGame
        {
            get
            {
                return this.Integer < 0 ? new IntegerGame(this.Integer + 1) : null;
            }
        }

        public int Integer
        {
            get;
            private set;
        }
    }
}
