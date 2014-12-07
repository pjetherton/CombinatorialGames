/* Copyright (c) 2014 Paul Etherton
 */

namespace CombinatorialGames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class TicTacToe : CombinatorialGame
    {
        private Player?[,] _Board;

        public TicTacToe()
            : this(new Player?[,]
                {
                    { null, null, null },
                    { null, null, null },
                    { null, null, null }
                })
        {
        }

        public TicTacToe(Player?[,] board)
        {
            if (board.GetLength(0) != 3 || board.GetLength(1) != 3)
            {
                throw new ArgumentException("board must be Player?[3, 3]");
            }
            this._Board = board;
        }

        public new IEnumerable<TicTacToe> Children(Player player)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<CombinatorialGame> GetChildren(Player player)
        {
            return this.Children(player);
        }
    }
}
