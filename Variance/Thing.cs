namespace Variance
{
    /// <summary>A typed thing to eat.</summary>
    class Thing
    {
        /// <summary>Vocabulary to describe a thing.</summary>
        public string Name { get; }

        public Thing(string name) => Name = name;
    }

    class Prop
    {
        public string Name;

        public Prop( string name )
        {
            Name = name;
        }
    }

    /// <summary>A more tasty typed thing to eat.</summary>
    class Apple : Thing
    {
        /// <summary>How tasty an Apple is to eat.</summary>
        public float Sugar { get; }

        public Apple(float sugar)
            : this(sugar, "apple")
        { }
        public Apple(float sugar, string name)
            : base(name)
            => Sugar = sugar;
    }
}
