import crosswordUtils.Crossword;
import crosswordUtils.CrosswordLine;
import org.testng.Assert;
import org.testng.annotations.Test;

import java.util.ArrayList;

public class CrosswordTest extends Assert {

    @Test
    public void testCorrectInitialization(){
        ArrayList<CrosswordLine> expectedRows = new ArrayList<CrosswordLine>(){
            {
                add(new CrosswordLine(1, 2));
                add(new CrosswordLine(1, 2, 3));
                add(new CrosswordLine(2));
            }
        };

        ArrayList<CrosswordLine> expectedColumns = new ArrayList<CrosswordLine>(){
            {
                add(new CrosswordLine(2, 2));
                add(new CrosswordLine(5));
            }
        };

        Crossword crossword = new Crossword(expectedRows, expectedColumns);

        assertEquals(crossword.GetWidth(), 2);
        assertEquals(crossword.GetHeight(), 3);
        assertEquals(crossword.GetRows(), expectedRows);
        assertEquals(crossword.GetColumns(), expectedColumns);
    }
}