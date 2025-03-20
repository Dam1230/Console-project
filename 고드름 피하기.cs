namespace 고드름_피하기
{
    internal class Program
    {
        struct Position
        {
            public int x;
            public int y;
        }

        static void Main(string[] args)
        {
            Position playerPos;
            char[,] map = new char[15, 15];
            bool gameOver = false;
            Position icicle;
            int timer = Environment.TickCount;
            int count = 0;

            Start(out playerPos, out icicle, out map);
            

            while (gameOver == false)
            {
                Render(playerPos, icicle, map);
                if (Console.KeyAvailable)
                {  
                    ConsoleKey key = Console.ReadKey(true).Key;
                    Update(key, ref playerPos, ref icicle, ref map, ref gameOver);
                }
                if (Environment.TickCount - timer >= 1000)
                    timer = Environment.TickCount;
                count++;
                Console.SetCursorPosition(20, 0);
                Console.Write(count);
            }
            End();
        }

        static void Start(out Position playerPos, out Position icicle, out char[,] map)
        {
            Console.CursorVisible = false;
            playerPos.x = 7;
            playerPos.y = 13;
            icicle.x = 5; 
            icicle.y = 1; 
            map = new char[15, 15]
            {
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
                { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒' },
            };
            showtitle();
        }

        static void showtitle()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("고드름 피하기");
            Console.WriteLine("아무키나 눌러서 시작하세요");
            Console.ReadKey();
            Console.Clear();
        }

        static void Render(Position playerPos, Position icicle, char[,] map)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            PrintMap(map);
            PrintPlayer(playerPos);
            PrintIcicle(icicle);
        }

        static void PrintPlayer(Position playerPos)
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.Write('●');
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();
        }

        static void PrintIcicle(Position icicle)
        {
            Console.SetCursorPosition(icicle.x, icicle.y);
            Console.Write('▼');
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.ResetColor();
        }

        static ConsoleKey Input()
        {
            return Console.ReadKey(true).Key; 
        }

        static void PrintMap(char[,] map)
        {
            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
        }

        static void Update(ConsoleKey key, ref Position playerPos, ref Position icicle, ref char[,] map, ref bool gameOver)
        {
            Move(key, ref playerPos, map);
            Moveiceicle(ref icicle, ref map);
            if (isClear(playerPos, icicle))
            {
                gameOver = true; 
            }
        }

        static void Move(ConsoleKey key, ref Position playerPos, char[,] map)
        {
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (map[playerPos.y, playerPos.x - 1] == ' ')
                    {
                        playerPos.x--;
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (map[playerPos.y, playerPos.x + 1] == ' ')
                    {
                        playerPos.x++;
                    }
                    break;
            }
        }

        static bool isClear(Position playerPos, Position icicle)
        {
            return playerPos.x == icicle.x && playerPos.y == icicle.y; 
        }
        
        static void Moveiceicle(ref Position icicle, ref char[,] map)
        {
            icicle.y++;
            if (icicle.y > 14)
            {
                icicle.y = 1;
                icicle.x = new Random().Next(1, 14);
            }
        }
        static void End()
        {
            Console.Clear();
            Console.WriteLine("게임 오버!");
            Console.WriteLine("다시 시작하려면 아무 키나 누르세요.");
            Console.ReadKey();
        }
    }
}

