package crosswordSolutionUtils;

import crosswordSolverUtils.CrosswordCell;

public class CrosswordSolution {
        private CrosswordCell[][] crosswordCells;
        private CrosswordSolutionStatus status;
        private int width;
        private int height;

        public CrosswordSolution(CrosswordCell[][] crosswordCells, CrosswordSolutionStatus status){
            if (crosswordCells == null){
                throw new IllegalArgumentException();
            }

            this.crosswordCells = crosswordCells;
            this.status = status;

            height = crosswordCells.length;
            width = (height == 0) ? 0 : crosswordCells[0].length;
        }

        public int getWidth() {
            return width;
        }

        public int getHeight() {
            return height;
        }

        public CrosswordCell[][] getCrosswordCells() {
            return crosswordCells;
        }

        public CrosswordSolutionStatus getStatus() {
            return status;
        }
}
