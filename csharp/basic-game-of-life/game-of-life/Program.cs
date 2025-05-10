using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;

using Core;
using Renderers;

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

      //CLIRender CLIRender = new();
      //int[,] finalGrid = CLIRender.Render(new Grid(initBoard, true));

      TimingDiagnostics();

    }

    static void TimingDiagnostics()
    {
      int[] sizes = { 32, 64, 128, 256 }; // Grid sizes (square grids)
      int[] generations = { 128, 256, 512, 1024 }; // Generations to simulate

      Console.WriteLine("Timing Diagnostics: Grid Size vs Generations\n");
      Console.Write("GridSize\\Gens".PadRight(15));
      foreach (int gen in generations)
      {
        Console.Write(gen.ToString().PadRight(10));
      }
      Console.WriteLine("\n" + new string('-', 15 + generations.Length * 10));

      foreach (int size in sizes)
      {
        Console.Write(size.ToString().PadRight(15));
        foreach (int gen in generations)
        {
          Grid grid = new(size, size, true);
          long time = MeasureTime(grid, gen);
          Console.Write($"{time}ms".PadRight(10));
        }
        Console.WriteLine();
      }
    }


    static long MeasureTime(Grid grid, int generationCount)
    {
      Stopwatch timer = new();
      timer.Start();
      for (int i = 0; i < generationCount; i++)
      {
        grid.AdvanceGrid();
      }
      timer.Stop();
      return timer.ElapsedMilliseconds;
    }

    public static void DisplayTimerProperties()
    {
      //https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.ishighresolution?view=net-9.0#system-diagnostics-stopwatch-ishighresolution
      // Display the timer frequency and resolution.
      if (Stopwatch.IsHighResolution)
      {
        Console.WriteLine("Operations timed using the system's high-resolution performance counter.");
      }
      else
      {
        Console.WriteLine("Operations timed using the DateTime class.");
      }

      long frequency = Stopwatch.Frequency;
      Console.WriteLine("  Timer frequency in ticks per second = {0}",
          frequency);
      long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
      Console.WriteLine("  Timer is accurate within {0} nanoseconds",
          nanosecPerTick);
    }
  }
}

/*

Timing Diagnostics: Grid Size vs Generations

GridSize\Gens  128       256       512       1024
-------------------------------------------------------
32             27ms      51ms      110ms     205ms
64             103ms     209ms     427ms     817ms
128            406ms     875ms     1617ms    3367ms
256            1749ms    3550ms    6872ms    13996ms

 */
