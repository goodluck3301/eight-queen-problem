using System;
using System.Windows;
using System.Windows.Controls;

namespace Chess8Queen
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        { InitializeComponent(); }

        static int Q = 8;
        static int n = 1;
        static int rand = 0;

        void printSolution(int[,] board)
        {
            n++;
            Random r = new Random();
            rand = r.Next(1, 92);
            if (n == rand)
            {
                for (int i = 0; i < Q; i++)
                {
                    if (board[i, 0] == 1) {
                       Grid.SetColumn(Queen, i);
                       Grid.SetRow(Queen, 0);
                    }
                    if (board[i, 1] == 1)
                    {
                        Grid.SetColumn(Queen2, i);
                        Grid.SetRow(Queen2, 1);
                    }
                    if (board[i, 2] == 1)
                    {
                        Grid.SetColumn(Queen3, i);
                        Grid.SetRow(Queen3, 2);
                    }
                    if (board[i, 3] == 1)
                    {
                        Grid.SetColumn(Queen4, i);
                        Grid.SetRow(Queen4, 3);
                    }
                    if (board[i, 4] == 1)
                    {
                        Grid.SetColumn(Queen5, i);
                        Grid.SetRow(Queen5, 4);
                    }
                    if (board[i, 5] == 1)
                    {
                        Grid.SetColumn(Queen6, i);
                        Grid.SetRow(Queen6, 5);
                    }
                    if (board[i, 6] == 1)
                    {
                        Grid.SetColumn(Queen7, i);
                        Grid.SetRow(Queen7, 6);
                    }
                    if (board[i, 7] == 1)
                    {
                        Grid.SetColumn(Queen8, i);
                        Grid.SetRow(Queen8, 7);
                    }
                }
            }
        }

        static bool isSafe(int[,] board, int row, int col)
        {
            int i, j;

            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;


            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            for (i = row, j = col; j >= 0 && i < Q; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        bool solveNQUtil(int[,] board, int col)
        {
            if (col == Q)
            {
                printSolution(board);
                return true;
            }
            bool res = false;
            for (int i = 0; i < Q; i++)
            {

                if (isSafe(board, i, col))
                {
                    board[i, col] = 1;
                    res = solveNQUtil(board, col + 1) || res;
                    board[i, col] = 0;
                }
            }
            return res;
        }
         void solveNQ()
        {
            int[,] board = new int[Q, Q];

            if (solveNQUtil(board, 0) == false)
            {
                MessageBox.Show("Solution does not exist");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            solveNQ();
            Q = 8;
            n = 1;
        }
    }
}
