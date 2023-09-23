/*
Given an string S of parenthesis what is the minimum number of operations
required to balance S.
S is balanced if the amount of opening parenthesis is equal to the amount of
closing parenthesis and on no prefix of S there are more closing parenthesis
than opening parenthesis.

An example string S:
    (())() - balanced
    (()))( - unbalanced, on preffix (())) there are 3 closing parenthesis but 2
    opening parenthesis.

An operation is defined as modifiying a character.
Note tha you CANT add characters nor remove them.

(1) If S has an odd size then its not balanced.
(2) An empty string is balanced.
(3) Let B be the number of balanced parenthesis and U the number of unbalanced
parenthesis of S and N the number of parenthesis on S.
    S is balanced when U = 0.
    N = B + U.
    B + U is even.
    B is even.
    Thus U is even.

S' is the string resulting from removing every balanced parenthesis on S.
    B', N' and U' are equivalent to B, N and U but on S'.
    On S':
        B' = 0.
        N' = B' + U = U = N - B.
        N' is even.

Suppose N' >= 2.
    The strucutre of N' is only one from this options:
    I-   )...)
    II-  (...(
    III- )...(
    Lets call ... the interior of S'.
    Consider changing any parenthesis on N' by its opposite parenthesis.

    The cost of making S' a balanced string is the half of elements on its interior
    plus:
        -1 on I and II, operate on an extreme.
        -2 on III, operate on both extremes.
    Because any change on its interior will balance two parenthesis.

Some notes:
    It is always the best to operate on an unmatched parenthesis.

    If we operate on an umatched parenthesis:
        -It match another parenthesis,U decreases by 2.
        -It doesnt match another parenthesis, U increases by 0.
    So win and not lose.
    If we operate on an matched parenthesis:
        -It doesnt match and the other neither, U increases by 2.
        -It match but the other doesnt, U decrease by 2 but increase by 2, so increases by 0.
        -It doest match but the other does, same as above.
        -It match and the other match, U increase by 2 but decrease by 4, thus U decrease by 2.
    So win and lose.

    Remember that when U = 0 the string is balanced so the best option to minimize operations
    is to operate on an unbalanced parenthesis.


    This justify the removing of balanced parenthesis.

    Removing every balanced parenthesis on S means picking an opening parenthesis
    O from S and a closing parenthesis C from S such that is C is after O on S
    and removing them. The proccess is repeated until no there are no closing
    parenthesis after opening parenthesis.
*/
static class MinOperationToBalance{
    public static int Balance(string s){
        if(string.IsNullOrEmpty(s))return 0;
        if(s.Length % 2 == 1)throw new Exception("Odd size strings cant be balanced");
        foreach(char c in s)if(c != '(' && c != ')')throw new Exception("string S can only contain parentheses.");
        //S is even
        //S is made of parenthesis
        //S is not empty
        s = RemoveMatchingParenthesis(s);
        int operations = 0;

        if(s.Length >= 4){
            operations += (s.Length - 2) / 2;
        }
        //Extremes
        if(s.Length >= 2){
            char first = s[0];
            char last = s.Last();

            if(first == last)++operations;
            else if(first == ')' && last == '(')operations+=2;
        }
        return operations;
    }
    static string RemoveMatchingParenthesis(string s){
        Stack<char> aux = new Stack<char>();
        foreach(char c in s){
            if(c == ')' && aux.Count > 0 && aux.Peek() == '(')aux.Pop();
            else aux.Push(c);
        }
        s = new string(aux.ToArray());
        s = new string (s.Reverse().ToArray());
        return s;
    }
}