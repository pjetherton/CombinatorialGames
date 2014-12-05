﻿/* Copyright (c) 2014 Paul Etherton
 */

using System.Linq;
using System.Collections.Generic;

namespace CombinatorialGames
{
    public abstract class CombinatorialGame
    {
        public IEnumerable<CombinatorialGame> Children(Player player);

        public bool Terminal(Player player)
        {
            return !this.Children(player).Any();
        }
    }
}