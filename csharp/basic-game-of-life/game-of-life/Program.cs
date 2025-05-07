using System;
using System.Runtime.InteropServices;
using System.Text;

namespace game_of_life
{
  internal class Program
  {
    static void Main(string[] args)
    {
      GameOfLife game = new GameOfLife(10, 15);

      while (true)
      {
        Console.SetCursorPosition(0, 0); // Always draw from the top-left corner
        Console.WriteLine($"Generation: {game.getTicks()}");
        Console.WriteLine(game.ToString());

        Console.WriteLine("Press any key to step, or 'q' to quit...");
        ConsoleKeyInfo key = Console.ReadKey(true);
        if (key.KeyChar == 'q' || key.KeyChar == 'Q')
          break;

        game.Tick();
      }
    }


  }

  public class GameOfLife
  {
    private int[,] _board;
    private int ticks = 0;

    public GameOfLife(int[,] board)
    {
      _board = board;
    }

    public GameOfLife(int height, int width)
    {
      int[,] board = new int[height, width];
      Random rand = new Random();

      for (int i = 0; i < height; i++)
      {
        for (int j = 0; j < width; j++)
        {
          board[i, j] = rand.Next(2); // fill with zeros or ones
        }
      }

      _board = board;
    }

    public int getValue(int i, int j)
    {
      if ((i < 0 || i > _board.GetLength(0) - 1)
        || (j < 0 || j > _board.GetLength(1) - 1))
      {
        return 0;
      }
      return _board[i, j];
    }

    public int[,] getBoard()
    {
      return _board;
    }

    public override string ToString()
    {
      int height = _board.GetLength(0);
      int width = _board.GetLength(1);

      const char LIVE_CELL = '#'; // \u2588';
      const char DEAD_CELL = ' ';

      StringBuilder asciiBoard = new StringBuilder();
      asciiBoard.AppendLine(new String('-', width + 2));
      for (int i = 0; i < height; i++)
      {
        asciiBoard.Append('|');
        for (int j = 0; j < width; j++)
        {
          asciiBoard.Append((_board[i, j] == 0) ? DEAD_CELL : LIVE_CELL);
        }
        asciiBoard.Append('|');
        asciiBoard.AppendLine();
      }
      asciiBoard.AppendLine(new String('-', width + 2));

      return asciiBoard.ToString();

    }

    public int getNeighbors(int x, int y)
    {
      int neighbors = 0;
      for (int i = x - 1; i <= x + 1; i++)
      {
        for (int j = y - 1; j <= y + 1; j++)
        {
          neighbors += this.getValue(i, j);
        }
      }
      return neighbors - this.getValue(x, y);
    }

    public int nextCellState(int x, int y)
    {
      int neighborCount = getNeighbors(x, y);
      int cellValue = getValue(x, y);

      if (cellValue == 0 && neighborCount == 3)
      {
        return 1;
      }
      if (cellValue == 1)
      {
        if (neighborCount == 2 || neighborCount == 3)
        {
          return 1;
        }
      }
      return 0;
    }

    public int getTicks()
    {
      return ticks;
    }

    public void Tick()
    {
      int height = _board.GetLength(0);
      int width = _board.GetLength(1);

      int[,] updatedBoard = new int[height, width];

      for (int i = 0; i < height; i++)
      {
        for (int j = 0; j < width; j++)
        {
          updatedBoard[i, j] = nextCellState(i, j);
        }
      }
      _board = updatedBoard;
      ticks++;
    }
  }
}
