using System;
using System.IO;

namespace Variance
{
    class UIManager
    {
        public void Draw() { }
    }
    class Manager<TUIManager>
        where TUIManager : UIManager, new()
    {
        public TUIManager GUI { get; private set; }

        public Manager() => GUI = new TUIManager();
    }

    public static partial class Program
    {
        public static void GenericDI()
        {
            var manager = 
                new Manager<TextUIManager>();
            manager.GUI.Output = new StreamWriter(
                Console.OpenStandardOutput());

            //Deconstruction assignment
            var (name, age) = ("Shannon", 22);

            //Implicit Object deconstruction
            var vec = new Vec2(4, 2);
            var (x, y) = vec;

            //Throw statements are smarter
            int bob = int.TryParse("Bob", out int i) 
                ? i 
                : throw new Exception("Custom Exception");
        }
        readonly struct Vec2
        {
            int X { get; }
            int Y { get; }

            public void Deconstruct( out int x, out int y )
            {
                x = X;
                y = Y;
            }

            public Vec2(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }

    class TextUIManager : UIManager
    {
        public TextWriter Output;
    }
}
