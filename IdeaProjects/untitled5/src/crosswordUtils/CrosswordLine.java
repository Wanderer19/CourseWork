package crosswordUtils;

public class CrosswordLine {
    private final int[] blocks;
    //проверять на отрицательную длину
    public CrosswordLine(int ... blocks){
        this.blocks = blocks;
    }

    public int getBlocksCount(){
        return blocks.length;
    }

    public int getBlockLength(int blockNumber) {
        return (blockNumber >= 0 && blockNumber < getBlocksCount()) ? blocks[blockNumber] : 0;
    }

    @Override
    public String toString() {
        StringBuffer blocksAsString = new StringBuffer();
        for (int block : blocks){
            blocksAsString.append(block);
            blocksAsString.append(" ");
        }
        return String.format("\"[ %s]\"", blocksAsString);
    }
}
