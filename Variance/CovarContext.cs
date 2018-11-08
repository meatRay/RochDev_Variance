using System.Collections.Generic;
using static System.Console;

namespace Variance
{
    /// <summary>Do stuff to a Thing.</summary>
    /// <typeparam name="TContext">The type of Thing to do stuff to.</typeparam>
    interface IThingMod<out TContext>
        where TContext : Thing
    {
        TContext Context { get; }

        void Update(float delta_time);
    }

    /// <summary>I can do stuff to Things!</summary>
    class ThingMod : IThingMod<Thing>
    {
        public Thing Context { get; }

        float _timr = 0f;
        public void Update(float delta_time)
        {
            if ((_timr += delta_time) > 1f)
                WriteLine($"It's {Context.Name}'s birthday!");
        }
    }

    /// <summary>I can only do stuff to Apples!</summary>
    class AppleMod : IThingMod<Apple>
    {
        public Apple Context { get; }

        float _sugareaten = 0f;
        public void Update(float delta_time)
        {
            _sugareaten += delta_time * Context.Sugar;
            if (_sugareaten > 1f)
                WriteLine($"A lot of sugar has been consumed.");
        }
    }

    static partial class Program
    {
        public static void CovarContext()
        {
            var me = new Apple(sugar: 1f);
            var mymods = new List<IThingMod<Thing>>();

            //A ThingMod doesn't care we're an Apple,
            //An Apple is still a Thing.
            mymods.Add(new ThingMod());

            //AppleMod still gets its "most derived" context
            mymods.Add(new AppleMod());

            foreach (var mod in mymods)
            {
                const float DELTATIME = 1f / 60f;

                //Thing can manage Mods by a least derived context
                mod.Update(DELTATIME);
            }
        }
    }
}
