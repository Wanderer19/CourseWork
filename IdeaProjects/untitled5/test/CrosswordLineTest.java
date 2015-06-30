import crosswordUtils.CrosswordLine;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;
public class CrosswordLineTest extends Assert{

    @Test
    public void getBlocksCountForEmptyLineReturnsZero(){
        CrosswordLine line = new CrosswordLine();

        assertEquals(line.getBlocksCount(), 0);
    }

    @Test()
    public void getBlocksCountForLineWithSameBlocksReturnsCorrectResult(){
        CrosswordLine line = new CrosswordLine(1, 2, 3);

        assertEquals(line.getBlocksCount(), 3);
    }

    @Test(dataProvider = "badData", expectedExceptions = IllegalArgumentException.class)
    public void getBlockLengthForIncorrectBlockNumbersThrowsException(CrosswordLine line, int blockNumber){
        int actual = line.getBlockLength(blockNumber);
    }

    @Test(dataProvider = "goodData")
    public void getBlockLengthForForLineWithSameBlocksReturnsCorrectResult(CrosswordLine line, int blockNumber, int expectedBlockLength){
        assertEquals(line.getBlockLength(blockNumber), expectedBlockLength);
    }

    @DataProvider
    public Object[][] badData() {

        CrosswordLine line = new CrosswordLine(1, 2, 10, 5);
        CrosswordLine emptyLine = new CrosswordLine();
        return new Object[][]{
                {line, -1},
                {line, 10},
                {emptyLine, 0},
                {emptyLine, -10}
        };
    }

    @DataProvider
    public Object[][] goodData() {

        CrosswordLine line = new CrosswordLine(1, 2, 10, 5);
        return new Object[][]{
                {line, 0, 1},
                {line, 1, 2},
                {line, 2, 10},
                {line, 3, 5}
        };
    }
}