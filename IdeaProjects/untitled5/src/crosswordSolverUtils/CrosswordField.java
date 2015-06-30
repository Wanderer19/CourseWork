package crosswordSolverUtils;

public class CrosswordField {
    private final CrosswordCell[][]rows;
    private final CrosswordCell[][] columns;

    public CrosswordField(int width, int height){
        rows = getCells(width, height, CrosswordCell.Unclear);
        columns = getCells(height, width, CrosswordCell.Unclear);
    }

    private static CrosswordCell[][] getCells(int width, int height, CrosswordCell defaultValue){
        CrosswordCell[][] cells = new CrosswordCell[width][height];

        for (int i = 0; i < height; ++i){
            for (int j = 0; j < width; ++j){
                cells[i][j] = defaultValue;
            }
        }

        return cells;
    }

    public void setCell(int row, int column, CrosswordCell value){
        if (row < 0 || column < 0 || row >= rows.length || column >= columns.length){
            throw new IllegalArgumentException();
        }

        rows[row][column] = value;
        columns[column][row] = value;
    }

    public CrosswordCell getCell(int row, int column){
        if (row < 0 || column < 0 || row >= rows.length || column >= columns.length){
            throw new IllegalArgumentException();
        }

        return rows[row][column];
    }

    public CrosswordCell[] getColumnCells(int index){
        if (index < 0 && index >= columns.length){
            throw new IllegalArgumentException();
        }

        return columns[index];
    }

    public CrosswordCell[] getRowCells(int index){
        if (index < 0 && index >= rows.length){
            throw new IllegalArgumentException();
        }

        return rows[index];
    }

    public boolean IsFilled(){
        for (int i = 0; i < rows.length; ++i){
            for (int j = 0; j < rows[i].length; ++j){
                if (rows[i][j] == CrosswordCell.Unclear){
                    return false;
                }
            }
        }

        return true;
    }

    public void print(){
        for (int i = 0; i < rows.length; ++i){
            for (int j = 0; j < rows[i].length; ++j){
                System.out.println(rows[i][j]);
            }
        }
    }
}
