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

      Grid grid = new(100, 100, true);
      Console.WriteLine(grid);

      //DisplayTimerProperties();

      long time = MeasureTime(grid, 1000);
      Console.WriteLine(grid);
      Console.WriteLine($"1000 gen in: {time}ms");

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
