/* Copyright (c) 2014 Paul Etherton
 */

namespace CombinatorialGames
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class CombinatorialGame
    {
        public IEnumerable<CombinatorialGame> Children(Player player)
        {
            return this.GetChildren(player);
        }

        protected abstract IEnumerable<CombinatorialGame> GetChildren(Player player);

        public bool Terminal(Player player)
        {
            return !this.Children(player).Any();
        }
    }
}
