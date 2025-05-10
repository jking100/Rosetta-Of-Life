using System;
using System.Runtime.InteropServices;
using System.Text;
using Core;

namespace Program
{
  internal class Program
  {
    static void Main(string[] args)
    {
      int[,] initBoard = new int[,]
      {
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,1,0,0,0,0},
        {0,0,0,1,0,1,0,0,0,0},
        {0,0,0,0,1,1,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
      };

      Grid game = new Grid(20, 100, true);

      while (true)
      {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"Generation: {game.GridGen}");
        Console.WriteLine(game.ToString());

        Console.WriteLine("Press any key to step, or 'q' to quit...");
        ConsoleKeyInfo key = Console.ReadKey(true);
        if (key.KeyChar == 'q' || key.KeyChar == 'Q')
          break;

        game.AdvanceGrid();
      }
    }
  }
}
