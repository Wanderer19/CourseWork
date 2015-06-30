package crosswordSolverUtils;

import crosswordSolutionUtils.CrosswordSolution;
import crosswordUtils.Crossword;

public interface ICrosswordSolver {
    CrosswordSolution Solve(Crossword crossword);
}
