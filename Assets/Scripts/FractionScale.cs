
public class FractionScale
{
    int numerator;
    readonly int denominator;

    public FractionScale(int num, int den)
    {
        numerator = num;
        denominator = den;
    }
    public FractionScale(int integer)
    {
        numerator = integer;
        denominator = integer;
    }
    public FractionScale(FractionScale f)
    {
        numerator = f.numerator;
        denominator = f.denominator;
    }
    public int Get()
    {
        return numerator;
    }
    public int GetNumerator()
    {
        return numerator;
    }
    public void SetNumerator(int n)
    {
        numerator = n;
    }
    public int GetDenominator()
    {
        return denominator;
    }
    public void Decrement()
    {
        numerator -= 1;
    }
    public void Decrement(int amount)
    {
        numerator -= amount;
    }
    public void Increment()
    {
        numerator += 1;
    }
    public void Increment(int amount)
    {
        numerator += amount;
    }
    public int ToInt()
    {
        return numerator/denominator;
    }
    public double ToDouble()
    {
        return (double) numerator / (double) denominator;
    }
    public float ToFloat()
    {
        return (float) numerator / (float) denominator;
    }
    override public string ToString()
    {
        return $"{numerator} / {denominator}";
    }
    public bool Full()
    {
        return numerator >= denominator;
    }
}