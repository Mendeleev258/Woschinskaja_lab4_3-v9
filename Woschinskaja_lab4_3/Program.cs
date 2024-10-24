// var 9

using System.CodeDom.Compiler;

class Program
{
    const int n = 5;

    static int[] fill_arr_from_matrix(int[,] matrix, int row, int size)
    {
        int[] result = new int[size];
        for (int i = 0; i < size; ++i)
            result[i] = matrix[row, i];
        return result;
    }
    
    static int[] find_local_max(ref int[,] matrix, int size, int row, out int res_arr_size)
    {
        int[] result = new int[size];
        int[] arr = fill_arr_from_matrix(matrix, row, size);
        
        res_arr_size = 1;
        int max = arr[0];
        result[0] = 0;
        for (int i = 1; i < n; ++i)
        {
            if (arr[i] > max)
            {
                Array.Clear(result);
                max = arr[i];
                result[0] = i;
                res_arr_size = 1;
            }
            else
            {
                if (arr[i] == max)
                {
                    res_arr_size++;
                    result[res_arr_size - 1] = i;
                }
            }
        }
        return result;
    }

    static void fill_matrix(int[,] matrix, int size, int a, int b)
    {
        Random rand = new Random();
        for (int i = 0; i < size; ++i)
            for (int j = 0; j < size; ++j)
                matrix[i, j] = rand.Next(a, b);
    }

    static void print_matrix(int[,] matrix, int size)
    {
        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
                Console.Write($"{matrix[i, j], 4} ");
            Console.WriteLine();
        }
    }

    static void Main()
    {
        //int[,] matrix = new int[n, n];
        //fill_matrix(matrix, n, -100, 100);
        int[,] matrix = {
            { 1, 5, 3, 4, 5 },
            { 5, 2, 5, 4, 5 },
            { 1, 5, 3, 5, 5 },
            { 1, 2, 3, 4, 5 },
            { -1, -1, -2, -3, -4} };
        print_matrix(matrix, n);
        int[] arr_max = new int[n];

        for (int i = 0; i < n; ++i)
        {
            int arr_max_size;
            arr_max = find_local_max(ref matrix, n, i, out arr_max_size);

            Console.Write("Indexes of local max on row {0}: ", i);
            for (int j = 0; j < arr_max_size; ++j)
                Console.Write(arr_max[j] + " ");
            Console.WriteLine();
        }
    }
}