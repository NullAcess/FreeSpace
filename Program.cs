Func<int, int> Multiply(int n, int m)
{
    int Inner(int m) => n * m;
    return Inner;
}