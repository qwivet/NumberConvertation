using System.Collections.Generic;
using System.Linq;

internal class TextConvert
{
    private Dictionary<char, int> charToInt = new Dictionary<char, int>() 
    { {'0', 0},{'1', 1},{'2', 2},{'3', 3},
        {'4', 4},{'5', 5},{'6', 6},{'7', 7},
        {'8', 8},{'9', 9},{'A', 10},{'B', 11},
        {'C', 12},{'D', 13},{'E', 14},{'F', 15}};
    private readonly char[] intToChar = new char[] 
    {'0','1','2','3','4','5','6','7',
    '8','9','A','B','C','D','E','F'};

    public TextConvert()
    {
    }

    public int[] Convert (string exp, ref bool isSigned, ref int floatPosition, List<int> errors = null)
    {
        if (exp == "")
            return new int[0];
        floatPosition = exp.Length;
        int numbersLength = exp.Length;
        if (exp[0] == '-')
        {
            isSigned = true;
            numbersLength--;
        }
        numbersLength = 
            exp.ToCharArray().Contains('.') || exp.ToCharArray().Contains(',') 
            ? numbersLength - 1 : numbersLength;
        int[] numbers = new int[numbersLength];
        int divider = isSigned ? 1 : 0;
        for (int i = isSigned ? 1 : 0; i < exp.Length; i++)
        {
            if (exp[i] == '.' || exp[i] == ',')
            {
                floatPosition = i;
                divider += 1;
            }
            else
            {
                if (!charToInt.ContainsKey(exp[i]))
                {
                    numbers[i - divider] = -1;
                    if (errors != null)
                    {
                        errors.Add(i);
                    }
                }
                else
                {
                    numbers[i - divider] = charToInt[exp[i]];
                }
            }
        }
        return numbers;
    }
    public char Convert (int i)
    {
        return intToChar[i];
    }
}
