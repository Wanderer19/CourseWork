package crosswordSolutionUtils;

import crosswordSolverUtils.CrosswordCell;

public class CrosswordSolutionTextVisualizer implements ICrosswordSolutionVisualizer<String> {

    @Override
    public String Visualize(CrosswordSolution crosswordSolution) {
        StringBuffer result = new StringBuffer();
        CrosswordCell[][] cells = crosswordSolution.getCrosswordCells();

        for (int i = 0; i < cells.length; ++i){
            for (int j = 0; j < cells.length; ++j){
                result.append(getCharAtCell(cells[i][j]));
            }
            result.append("\\n");
        }

        return result.toString();
    }

    private static char getCharAtCell(CrosswordCell solutionCell)
    {
        switch (solutionCell)
        {
            case Empty:
            {
                return '.';
            }
            case Filled:
            {
                return '*';
            }
            case Unclear:
            {
                return '?';
            }
            default:
            {
                throw new IllegalArgumentException();
            }
        }
    }
}
