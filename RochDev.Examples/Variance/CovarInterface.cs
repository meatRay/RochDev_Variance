namespace Variance
{
    /// <summary>Provides instances of food</summary>
    /// <typeparam name="TFood">The covariantly typed food to provide</typeparam>
    interface IFood<out TFood>
        where TFood : Thing
    {
        TFood Contains();

        //void Eat(TFood food);
        /*{
            IFood<Base> = new IFood<Complex>;
            //Eat can now be called with a less derived Type!
            IFood<Base>.Eat( Base );
        }*/
    }



    static partial class Program
    {
        class Bush : IFood<Apple>
        {
            public Apple Growing { get; private set; }
            public Apple Contains() => Growing;
            public void Grow()
                => Growing = new Apple(sugar: 1f);
        }
        static void CovarInterface()
        {
            IFood<Apple> as_apple = new Bush();
            IFood<Thing> as_thing = as_apple;

            //Context of Type determines context of property.
            Thing thing = as_thing.Contains();
            Apple apple = as_apple.Contains();
        }
    }
}
