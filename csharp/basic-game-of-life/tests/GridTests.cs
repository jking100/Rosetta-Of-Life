using game_of_life;

namespace Grid_Class_Tests
{
  public class GridTests
  {
    [Fact]
    public void Test_Random_Init()
    {
      // check that all board values are either 0 or 1
      // check that height and width are correct
      const int HEIGHT = 11;
      const int WIDTH = 11;


      Grid game = new Grid(WIDTH, HEIGHT);
      int[,] board = game.GetGrid;

      foreach (int cell in board)
      {
        Assert.InRange(cell, 0, 1);
      }

      Assert.Equal(WIDTH, game.GridWidth);
      Assert.Equal(HEIGHT, game.GridHeight);
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

      Grid grid = new Grid(board, false);

      Assert.Equal(board, grid.GetGrid);
    }

    [Fact]
    public void Test_Advance_Explicit_Seed()
    {
      int[,] initBoard = new int[,]
      {
        {0,1,0},
        {0,1,0},
        {0,1,0}
      };
      int[,] expectedBoard = new int[,]
      {
        {0,0,0},
        {1,1,1},
        {0,0,0}
      };


      Grid grid = new Grid(initBoard);
      grid.AdvanceGrid();
      Assert.Equal(expectedBoard, grid.GetGrid);
      Assert.Equal(1, grid.GridGen);

      initBoard = new int[,]
      {
        {1,1,0},
        {1,1,0},
        {0,0,0}
      };
      expectedBoard = new int[,]
      {
        {1,1,0},
        {1,1,0},
        {0,0,0}
      };

      grid = new Grid(initBoard);
      grid.AdvanceGrid();
      Assert.Equal(expectedBoard, grid.GetGrid);
      Assert.Equal(1, grid.GridGen);
    }

    [Fact]
    public void Test_Advance_Implicit_Seed()
    {
      int GRIDWIDTH = 15;
      int GRIDHEIGHT = 10;

      Grid grid = new Grid(GRIDWIDTH, GRIDHEIGHT);
      grid.AdvanceGrid();

      int[,] gen1 = grid.GetGrid;

      foreach (int cell in gen1)
      {
        Assert.InRange(cell, 0, 1);
      }

      Assert.Equal(GRIDWIDTH, grid.GridWidth);
      Assert.Equal(GRIDHEIGHT, grid.GridHeight);
    }

    [Fact]
    public void Test_Advance_Wrapping()
    {
      int[,] initBoard = new int[,]
      {
        {0,0,0,0,0},
        {0,0,0,0,0},
        {0,0,0,0,0},
        {0,1,1,1,0}
      };
      int[,] expectedBoard = new int[,]
      {
        {0,0,1,0,0},
        {0,0,0,0,0},
        {0,0,1,0,0},
        {0,0,1,0,0}
      };


      Grid grid = new Grid(initBoard, true);
      grid.AdvanceGrid();
      Assert.Equal(expectedBoard, grid.GetGrid);
      Assert.Equal(1, grid.GridGen);
    }
  }
}