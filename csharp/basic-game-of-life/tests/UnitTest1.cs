using game_of_life;

namespace tests
{
  public class UnitTest1
  {
    [Fact]
    public void Test_Random_Init()
    {
      // check that all board values are either 0 or 1
      // check that height and width are correct
      const int HEIGHT = 11;
      const int WIDTH = 11;


      GameOfLife game = new GameOfLife(HEIGHT, WIDTH);
      int[,] objBoard = game.getBoard();

      foreach (int cell in objBoard)
      {
        Assert.InRange(cell, 0, 1);
      }

      Assert.Equal(HEIGHT, objBoard.GetLength(0));
      Assert.Equal(WIDTH, objBoard.GetLength(1));
    }

    [Fact]
    public void Test_Explicit_Init()
    {
      int[,] board = new int[,]
      {
        {0,1,0},
        {0,1,0},
        {0,1,0}
      };

      GameOfLife game = new GameOfLife(board);

      Assert.Equal(board, game.getBoard());
    }

    [Fact]
    public void Test_GetValue()
    {
      int[,] board = new int[,]
      {
        {0,1,0},
        {0,1,0},
        {0,1,0}
      };

      const int i = 0;
      const int j = 2;

      GameOfLife game = new GameOfLife(board);

      Assert.Equal(board[i, j], game.getValue(i, j));
    }

    [Fact]
    public void Test_GetValue_OutOfRange()
    {
      int[,] board = new int[,]
      {
        {0,1,0},
        {0,1,0},
        {0,1,0}
      };

      const int i = 0;
      const int j = 2;

      GameOfLife game = new GameOfLife(board);

      Assert.Equal(0, game.getValue(4, 4));
      Assert.Equal(0, game.getValue(3, 3));
    }


    [Fact]
    public void Test_ToString() // will fail on *nix
    {
      int[,] board = new int[,]
      {
        {0,1,0},
        {0,1,0},
        {0,1,0}
      };

      string boardAsStr = " # \r\n # \r\n # \r\n";

      GameOfLife game = new GameOfLife(board);

      Assert.Equal(boardAsStr, game.ToString());
    }

    [Fact]
    public void Test_get_neighbors()
    {
      int[,] board = new int[,]
      {
        {0,1,0},
        {0,1,0},
        {0,1,0}
      };
      GameOfLife game = new GameOfLife(board);

      Assert.Equal(1, game.getNeighbors(2, 1));
      Assert.Equal(2, game.getNeighbors(0, 0));
      Assert.Equal(2, game.getNeighbors(1, 1));


    }


    [Fact]
    public void Test_Next_Cell_State()
    {
      int[,] board = new int[,]
      {
        {0,1,0},
        {0,1,0},
        {0,1,0}
      };
      GameOfLife game = new GameOfLife(board);

      Assert.Equal(0, game.nextCellState(0, 0));
      Assert.Equal(0, game.nextCellState(0, 1));
      Assert.Equal(0, game.nextCellState(0, 2));

      Assert.Equal(1, game.nextCellState(1, 0));
      Assert.Equal(1, game.nextCellState(1, 1));
      Assert.Equal(1, game.nextCellState(1, 2));


    }

    [Fact]
    public void Test_Tick()
    {
      int[,] board = new int[,]
      {
        {0,1,0},
        {0,1,0},
        {0,1,0}
      };
      GameOfLife game = new GameOfLife(board);

      game.Tick();
      int[,] expected = new int[,]
      {
        {0,0,0},
        {1,1,1},
        {0,0,0}
      };
      Assert.Equal(expected, game.getBoard());
      Assert.Equal(1, game.getTicks());

      game.Tick();
      expected = new int[,]
      {
        {0,1,0},
        {0,1,0},
        {0,1,0}
      };
      Assert.Equal(expected, game.getBoard());
      Assert.Equal(2, game.getTicks());
    }
  }
}