class Program {
    static void Main(string[] args) {
        Console.Write("Enter number of stalls: ");
        int n = int.Parse(Console.ReadLine());
        
        bool[] stalls = new bool[n];
        for (int i = 0; i < n; i++) {
            stalls[i] = true;
        }
        
        while (true) {
            Console.Write("Enter stall number(s) to reserve (separate by space, enter 0 or negative number to exit): ");
            string[] input = Console.ReadLine().Split();
            int stall1 = int.Parse(input[0]) - 1; 
            int stall2 = int.Parse(input[1]) - 1; 
            
            if (stall1 < 0 || stall2 < 0) {
                break; 
            } else if (stall1 >= n || stall2 >= n) {
                Console.WriteLine("Invalid stall number!");
                continue;
            } else if (stall1 == stall2) {
                if (!stalls[stall1]) {
                    Console.WriteLine("The stall is reserved.");
                } else {
                    stalls[stall1] = false;
                    PrintStatus(stalls);
                }
            } else if (stall1 > stall2) {
                int temp = stall1;
                stall1 = stall2;
                stall2 = temp;
            }
            
            bool canReserve = true;
            for (int i = stall1; i <= stall2; i++) {
                if (!stalls[i]) {
                    canReserve = false;
                    Console.WriteLine("The entrance can't be reserved.");
                    break; 
                }
            }
            
            if (canReserve) {
                for (int i = stall1; i <= stall2; i++) {
                    stalls[i] = false;
                }
                PrintStatus(stalls);
            }
        }
    }
    
    static void PrintStatus(bool[] stalls) {
        foreach (bool s in stalls) {
            Console.Write(s ? '_' : 'X');
        }
        Console.WriteLine();
    }
}