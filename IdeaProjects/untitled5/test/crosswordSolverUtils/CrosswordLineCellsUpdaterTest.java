package crosswordSolverUtils;

import crosswordUtils.CrosswordLine;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

public class CrosswordLineCellsUpdaterTest extends Assert{


    @Test(dataProvider = "goodData")
    public void uberTest(String initialCells, CrosswordLine line,String expectedCells){
        CrosswordLineCellsUpdater solver = new CrosswordLineCellsUpdater(GetCellsFromString(initialCells), line);
        CrosswordCell[] solution = solver.GetUpdatedCells();

        assertEquals(solution, GetCellsFromString(expectedCells));
    }

    @DataProvider
    public Object[][] goodData() {


        return new Object[][]{
                {"?***?", new CrosswordLine(3), " *** "},

        };
    }

    private static CrosswordCell[] GetCellsFromString(String cells)
    {
        CrosswordCell[] crosswordCells = new CrosswordCell[cells.length()];

        for (int i = 0; i < cells.length(); ++i){
            crosswordCells[i] = GetCellFromChar(cells.charAt(i));
        }

        return crosswordCells;
    }

    private static CrosswordCell GetCellFromChar(char c)
    {
        switch (c)
        {
            case ' ':
                return CrosswordCell.Empty;
            case '*':
                return CrosswordCell.Filled;
            case '?':
                return CrosswordCell.Unclear;
            default:
                throw new IllegalArgumentException();

        }
    }
}