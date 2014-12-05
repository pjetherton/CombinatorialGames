﻿/* Copyright (c) 2014 Paul Etherton
 */

using System.Collections.Generic;
using System.Linq;

namespace CombinatorialGames.SimpleGames
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
        {
            this.Integer = integer;
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