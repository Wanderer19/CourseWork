package crosswordUtils;

import java.util.ArrayList;

public class Crossword {
    private ArrayList<CrosswordLine> rows;
    private ArrayList<CrosswordLine> columns;
    private int width;
    private int height;



    public Crossword(ArrayList<CrosswordLine> rows, ArrayList<CrosswordLine> columns){
        this.rows = rows;
        this.columns = columns;
        this.width = columns.size();
        this.height = rows.size();
    }

    public ArrayList<CrosswordLine> GetRows(){
        return rows;
    }

    public ArrayList<CrosswordLine> GetColumns(){
        return columns;
    }

    public int GetWidth(){
        return width;
    }

    public int GetHeight(){
        return height;
    }
}
