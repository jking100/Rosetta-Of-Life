using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
  public class Grid
  {
    int[,] _grid;
    int _gridGen = 0;
    public int GridWidth => _grid.GetLength(0);
    public int GridHeight => _grid.GetLength(1);
    public int GridGen => _gridGen;
    public int[,] GetGrid => _grid;
    private Func<int, int, int> _getCell;

    public Grid(int[,] grid, bool isWrap = false)
    {
      _grid = grid;
      _getCell = isWrap ? _EdgeWrapGetCell : _NoWrapGetCell;
    }
    public Grid(int i, int j, bool isWrap = false)
    {
      if (i < 1 || j < 1) _grid = new int[1, 1];

      _grid = new int[i, j];

      for (int k = 0; k < i; k++)
      {
        for (int l = 0; l < j; l++)
        {
          _grid[k, l] = (Random.Shared.Next(10) == 0) ? 1 : 0;
        }
      }

      _getCell = isWrap ? _EdgeWrapGetCell : _NoWrapGetCell;
    }

    public void AdvanceGrid()
    {
      int[,] nextGrid = new int[GridWidth, GridHeight];

      for (int i = 0; i < GridWidth; i++)
      {
        for (int j = 0; j < GridHeight; j++)
        {
          nextGrid[i, j] = _process(i, j);
        }
      }
      _grid = nextGrid;
      _gridGen += 1;
    }

    private int _process(int i, int j)
    {
      int cell = _grid[i, j];
      int neighbors = _countNeighbors(i, j);

      if (cell == 0 && neighbors == 3) return 1;
      if (cell == 1 && neighbors is 2 or 3) return 1;
      return 0;
    }

    private int _countNeighbors(int i, int j)
    {
      int neighbors = 0;
      for (int k = i - 1; k <= i + 1; k++)
      {
        for (int l = j - 1; l <= j + 1; l++)
        {
          neighbors += _getCell(k, l);
        }
      }
      return neighbors - _grid[i, j];
    }

    private int _NoWrapGetCell(int i, int j)
    {
      if (i < 0 || i > GridWidth - 1) return 0;
      if (j < 0 || j > GridHeight - 1) return 0;
      return _grid[i, j];
    }

    private int _EdgeWrapGetCell(int i, int j)
    {
      int width = this.GridWidth;
      int height = this.GridHeight;
      return _grid[(i + width) % width, (j + height) % height];
    }

    public override string ToString()
    {
      const char LIVE_CELL = '#'; // \u2588';
      const char DEAD_CELL = ' ';

      StringBuilder asciiBoard = new StringBuilder();
      asciiBoard.AppendLine(new String('-', this.GridHeight + 2));
      for (int i = 0; i < this.GridWidth; i++)
      {
        asciiBoard.Append('|');
        for (int j = 0; j < this.GridHeight; j++)
        {
          asciiBoard.Append((_grid[i, j] == 0) ? DEAD_CELL : LIVE_CELL);
        }
        asciiBoard.Append('|');
        asciiBoard.AppendLine();
      }
      asciiBoard.AppendLine(new String('-', this.GridHeight + 2));

      return asciiBoard.ToString();
    }
  }
}
