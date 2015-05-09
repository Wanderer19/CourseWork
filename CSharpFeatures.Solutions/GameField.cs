﻿using System.Linq;

namespace CSharpFeatures.Solutions
{
    public enum CellMark
    {
        Empty,
        Cross,
        Zero
    }

    public class GameField
    {
        private readonly CellMark[][] rows;
        private readonly CellMark[][] columns;
        private readonly CellMark[][] diagonals;
        private readonly int size;
       
        public GameField(int size)
        {
            this.size = size;
            
            rows = Enumerable.Range(0, size).Select(i => new CellMark[size]).ToArray();
            columns = Enumerable.Range(0, size).Select(i => new CellMark[size]).ToArray();
            diagonals = Enumerable.Range(0, 2).Select(i => new CellMark[size]).ToArray();
        }

        public CellMark this[int x, int y]
        {
            get { return rows[x][y]; }
            set
            {
                rows[x][y] = value;
                columns[y][x] = value;

                if (x == y)
                {
                    diagonals[0][x] = value;
                }

                if (x + y == size - 1)
                {
                    diagonals[1][x] = value;
                }
            }
        }

        public bool HasWinner()
        {
            return rows.Any(IsWinnerLine) || columns.Any(IsWinnerLine) || diagonals.Any(IsWinnerLine);
        }

        private static bool IsWinnerLine(CellMark[] line)
        {
            return line.All(cell => cell == CellMark.Cross) || line.All(cell => cell == CellMark.Zero);
        }

        public CellMark[][] GetRows()
        {
            return rows;
        }

        public CellMark[][] GetColumns()
        {
            return columns;
        }

        public CellMark[] GetLeftDiagonal()
        {
            return diagonals[0];
        }

        public CellMark[] GetRightDiaonal()
        {
            return diagonals[1];
        }
    }
}
