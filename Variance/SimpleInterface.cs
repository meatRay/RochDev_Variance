namespace Variance
{
    /// <summary>Eats and contains Things.</summary>
    interface IHungry
    {
        
        /// <summary>Contain a Thing in a destructive manner.</summary>
        /// <param name="thing">The thing to be destructively contained.</param>
        void Eat(Thing thing);

        
        /// <summary>Acquire the contents last eaten.</summary>
        /// <returns>A Thing that was eaten, or default(Thing)</returns>
        Thing Contains();
    }
}