using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Renderers
{
  public interface IGridRender
  {
    int[,] Render(Grid grid);
  }

  public class CLIRender : IGridRender
  {
    public int[,] Render(Grid grid)
    {
      while (true)
      {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"Generation: {grid.GridGen}");
        Console.WriteLine(grid.ToString());

        Console.WriteLine("Press any key to step, or 'q' to quit...");
        ConsoleKeyInfo key = Console.ReadKey(true);
        if (key.KeyChar == 'q' || key.KeyChar == 'Q')
          break;

        grid.AdvanceGrid();
      }
      return grid.GetGrid;
    }
  }
}
