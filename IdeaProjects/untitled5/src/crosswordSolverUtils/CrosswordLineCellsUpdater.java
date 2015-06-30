package crosswordSolverUtils;
import crosswordUtils.CrosswordLine;

public class CrosswordLineCellsUpdater {
    private final CrosswordCell[] lineCells;
    private final CrosswordLine crosswordLine;
    private final BlockPositionState[][] blockPositionStates;
    private final boolean[] maybeFilledCells;
    private final boolean[] maybeEmptyCells;

    public CrosswordLineCellsUpdater(CrosswordCell[] lineCells, CrosswordLine crosswordLine){
        this.lineCells = lineCells.clone();
        this.crosswordLine = crosswordLine;
        maybeFilledCells = new boolean[lineCells.length];
        maybeEmptyCells = new boolean[lineCells.length];
        blockPositionStates = new BlockPositionState[lineCells.length+1][crosswordLine.getBlocksCount()+1];

        for (int i = 0; i < blockPositionStates.length; ++i){
            for (int j = 0; j < blockPositionStates[i].length; ++j){
                blockPositionStates[i][j] = BlockPositionState.StillUnknown;
            }
        }
    }

    public CrosswordCell[] GetUpdatedCells()
    {
        if (trySetBlock(0, 0))
        {
            updateCells();
        }
        else
        {
            return null;
        }

        return lineCells;
    }

    private boolean trySetBlock(int start, int blockNumber)
    {
        if (blockPositionStates[start][blockNumber] != BlockPositionState.StillUnknown)
        return blockPositionStates[start][blockNumber] == BlockPositionState.Successfully;

        if (blockContainsEmptyCells(start, blockNumber))
        {
            blockPositionStates[start][blockNumber] = BlockPositionState.Fails;
            return false;
        }

        if (blockNumber < crosswordLine.getBlocksCount() - 1)
        {
            return trySetMiddleBlock(start, blockNumber);
        }

        return trySetLastBlock(start, blockNumber);
    }

    private boolean blockContainsEmptyCells(int start, int blockNumber)
    {
        for (int i = start; i < lineCells.length && i < start + crosswordLine.getBlockLength(blockNumber);++i){
            if (lineCells[i] == CrosswordCell.Empty){
                return true;
            }
        }
        return false;
    }

    private boolean trySetMiddleBlock(int start, int blockNumber)
    {
        int blockLength = crosswordLine.getBlockLength(blockNumber);
        int nextPosition = blockLength == 0 ? start : start + blockLength + 1;
        int nextBlockLength = crosswordLine.getBlockLength(blockNumber + 1);
        int lastPosition = lineCells.length - nextBlockLength;
        boolean blockIsSet = false;

        while (nextPosition <= lastPosition && !existsFilledCellBeforeBlockPosition(nextPosition))
        {
            if (trySetBlock(nextPosition, blockNumber + 1))
            {
                setBlock(start, nextPosition, blockNumber);
                blockIsSet = true;
            }
            nextPosition++;
        }

        return blockIsSet;
    }

    private boolean existsFilledCellBeforeBlockPosition(int blockPosition)
    {
        return blockPosition > 0 && lineCells[blockPosition - 1] == CrosswordCell.Filled;
    }

    private boolean trySetLastBlock(int start, int blockNumber)
    {
        if (afterBlockExistsFilledCells(start, blockNumber))
            return false;

        setBlock(start, lineCells.length, blockNumber);
        return true;
    }

    private boolean afterBlockExistsFilledCells(int start, int blockNumber)
    {
        int blockLength = crosswordLine.getBlockLength(blockNumber);
        if (blockLength <= 0){
            return false;
        }

        for (int i = start + blockLength; i < lineCells.length; ++i){
            if (lineCells[i] == CrosswordCell.Filled){
                return true;
            }
        }

        return false;
    }

    private void setBlock(int start, int end, int blockNumber)
    {
        int blockLength = crosswordLine.getBlockLength(blockNumber);
        for (int i = start; i < end; ++i)
        {
            if (i < start + blockLength)
            {
                maybeFilledCells[i] = true;
            }
            else
            {
                maybeEmptyCells[i] = true;
            }
        }

        blockPositionStates[start][blockNumber] = BlockPositionState.Successfully;
    }

    private void updateCells()
    {
        for (int k = 0; k < lineCells.length; ++k)
        {
            if (lineCells[k] == CrosswordCell.Unclear && maybeFilledCells[k] ^ maybeEmptyCells[k])
            {
                lineCells[k] = maybeFilledCells[k] ? CrosswordCell.Filled : CrosswordCell.Empty;
            }
        }
    }
}
