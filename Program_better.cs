void random_2_generator(int[] rand_index, string[,] field)
{
    while (true) {
        rand_index[0] = new Random().Next(0, 4);
        rand_index[1] = new Random().Next(0, 4);
        if (field[rand_index[0], rand_index[1]] == "0")
        {
            field[rand_index[0], rand_index[1]] = "2";
            break;
        }
    }
}
void controls(string[,] field, string last_move)
{
    switch (last_move)
    {
        case "u":
            // move up
            for (int j = 0; j < 4; j++) {
                for (int i = field.GetLength(0) - 1; i > 0; i--)
                {
                    for (int k = 0; k < field.GetLength(1); k++)
                    {
                        while (i - 1 >= 0 && field[i - 1, k] == "0")
                        {
                            field[i - 1, k] = field[i, k];
                            field[i, k] = "0";
                            break;
                        }
                    }
                }
            }
            break;
        case "d":
            // move down
            for (int j = 0; j < 4; j++) {
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int k = 0; k < field.GetLength(1); k++)
                    {
                        while (i + 1 < field.GetLength(0) && field[i + 1, k] == "0")
                        {
                            field[i + 1, k] = field[i, k];
                            field[i, k] = "0";
                            break;
                        }
                    }
                }
            }
            break;
        case "l":
            // move left
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int k = field.GetLength(1) - 1; k > 0; k--)
                    {
                        while (k - 1 >= 0 && field[i, k - 1] == "0")
                        {
                            field[i, k - 1] = field[i, k];
                            field[i, k] = "0";
                            break;
                        }
                    }
                }
            }
            break;
        case "r":
            // move right
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int k = 0; k < field.GetLength(1); k++)
                    {
                        while (k + 1 < field.GetLength(1) && field[i, k + 1] == "0")
                        {
                            field[i, k + 1] = field[i, k];
                            field[i, k] = "0";
                            break;
                        }
                    }
                }
            }
            break;
        default:
            break;
    }
}
void combine(string[,] field, string last_move)
{
    switch (last_move)
    {
        case "u":
            // combine up
            for (int i = 0; i < field.GetLength(0) - 1; i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    if (field[i, k] == field[i + 1, k] && field[i, k] != "0")
                    {
                        field[i, k] = (int.Parse(field[i + 1, k]) * 2).ToString();
                        field[i + 1, k] = "0";
                    }
                }
            }
            break;
        case "d":
            // combine down
            for (int i = field.GetLength(0) - 1; i > 0; i--)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    if (field[i, k] == field[i - 1, k] && field[i, k] != "0")
                    {
                        field[i, k] = (int.Parse(field[i - 1, k]) * 2).ToString();
                        field[i -1, k] = "0";
                    }
                }
            }
            break;
        case "l":
            // combine left
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1) - 1; k++)
                {
                    if (field[i, k] == field[i, k + 1] && field[i, k] != "0")
                    {
                        field[i, k] = (int.Parse(field[i, k + 1]) * 2).ToString();
                        field[i, k + 1] = "0";
                    }
                }
            }
            break;
        case "r":
            // combine right
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = field.GetLength(1) - 1; k > 0; k--)
                {
                    if (field[i, k] == field[i, k - 1] && field[i, k] != "0")
                    {
                        field[i, k] = (int.Parse(field[i, k -1]) * 2).ToString();
                        field[i, k -1] = "0";
                    }
                }
            }
            break;
        default:
            break;
    }
}
void text_color(string val, ConsoleColor defaultColor)
{
    switch (val)
    {
        case "2": Console.ForegroundColor = ConsoleColor.Red; break;
        case "4": Console.ForegroundColor = ConsoleColor.Yellow; break;
        case "8": Console.ForegroundColor = ConsoleColor.Green; break;
        case "16": Console.ForegroundColor = ConsoleColor.Cyan; break;
        case "32": Console.ForegroundColor = ConsoleColor.Blue; break;
        case "64": Console.ForegroundColor = ConsoleColor.Magenta; break;
        case "128": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
        case "256": Console.ForegroundColor = ConsoleColor.DarkGreen; break;
        case "512": Console.ForegroundColor = ConsoleColor.DarkCyan; break;
        case "1024": Console.ForegroundColor = ConsoleColor.DarkBlue; break;
        case "2048": Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
        default: Console.ForegroundColor = defaultColor; break;
    }
}

Random rand = new Random();
bool game = true;
string[,] field = new string[4, 4];
string last_move = new string("");
for (int i = 0; i < field.GetLength(0); i++)
{
    for (int k = 0; k < field.GetLength(1); k++)
    {
         field[i, k] = "0";
    }
}
random_2_generator(new int[2], field);

do
{
    game = false;
    // checks for game over
    for (int i = 0; i < field.GetLength(0); i++)
    {
        for (int k = 0; k < field.GetLength(1); k++)
        {
            if (field[i, k] == "0")
            {
                game = true;
            }
        }
    }
    Console.Clear();
    ConsoleColor defaultColor = Console.ForegroundColor;
    // print field
    for (int i = 0; i < field.GetLength(0); i++)
    {
        for (int k = 0; k < field.GetLength(1); k++)
        {
            string val = field[i, k];

            text_color(val, defaultColor);

            Console.Write(val + "\t");

            Console.ForegroundColor = defaultColor;
        }
        Console.WriteLine();
        Console.WriteLine();
    }
    // key input
    ConsoleKeyInfo key = Console.ReadKey();
    switch (key.Key)
    {
        case ConsoleKey.UpArrow:
            last_move = "u";
            break;
        case ConsoleKey.DownArrow:
            last_move = "d";
            break;
        case ConsoleKey.LeftArrow:
            last_move = "l";
            break;
        case ConsoleKey.RightArrow:
            last_move = "r";
            break;
        default:
            last_move = "";
            break;
    }
    controls(field,last_move);
    combine(field,last_move);
    controls(field, last_move);
    random_2_generator(new int[2], field);
    // checks for game over (you can never be sure)
    for (int i = 0; i < field.GetLength(0); i++)
    {
        for (int k = 0; k < field.GetLength(1); k++)
        {
            if (field[i, k] == "0")
            {
                game = true;
            }
        }
    }
} while (game == true);
Console.WriteLine("game over");
