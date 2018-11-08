namespace Variance
{
    interface IHunger<in TFood>
        where TFood : Thing
    {
        //TFood Contains();
        /*{
            IFood<Complex> = new IFood<Base>;
            //Contains can now be called, returning
            //A more derived type than supported!
            Complex = IFood<Complex>.Contains()
        }*/

        void Eat(TFood food);
    }

    static partial class Program
    {
        class Dinosaur : IHunger<Thing>
        {
            public Thing Stomach { get; private set; }
            public void Eat(Thing food)
                => Stomach = food;
        }
        static void ContravarInterface()
        {
            IHunger<Thing> eats_things = new Dinosaur();
            //Woah... I<Complex> = I<Base>? What the heck?
            IHunger<Apple> eats_apples = eats_things;

            //Contex determines the function in params..
            //Dinosaurs can eat Things..
            eats_things.Eat(new Thing("chair"));
            //Dinosaurs can eat Apples, which are also Things..
            eats_apples.Eat(new Apple(sugar: 1f));
            //So Therefor a Dinosaur, of type I<Simple>
            //can be assigned to a type of I<Complex>!

            //eats_things = new OnlyApples();
            //Assigning something that eats apples to
            //a context of eating Things is illegal!
            //eats_things.Eat(new Thing("chair"));
        }
        class OnlyApples : IHunger<Apple>
        {
            public void Eat(Apple food) { }
        }
    }
}
