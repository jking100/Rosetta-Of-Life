using System;
using System.Runtime.InteropServices;
using System.Text;

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

      CLIRender CLIRender = new();

      int[,] finalGrid = CLIRender.Render(new Grid(initBoard, true));

    }
  }
}
