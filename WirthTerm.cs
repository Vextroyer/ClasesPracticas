/*
Wirth Set (W)

x is in W

if x is in W :
                2x + 1 is in W
                3x + 1 is in W
*/
    void GenerateWirthIterative(int n){
        Queue<int> todo = new Queue<int>();
        todo.Enqueue(1);
        for(int i=1;i<=n;++i){
            int to = todo.Dequeue();
            int first = 2 * to + 1;
            int second = 3 * to + 1;
            todo.Enqueue(first);
            todo.Enqueue(second);
            Console.WriteLine($"{i}: {to}");
        }
    }
    //Returns the n-th Wirth term.
    //n > 0
    int NWirthTerm(int n){
        if(n == 1)return 1;
        if(n % 2 == 0)return NWirthTerm(n / 2) * 2 + 1;//Par
        return NWirthTerm(n/2) * 3 + 1;//Impar
    }
