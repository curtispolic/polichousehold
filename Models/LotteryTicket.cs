using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace polichousehold.Models;

public class LotteryTicket
{   
    public List<int> Numbers { get; set; }
    public int Powerball { get; set; }

    public LotteryTicket()
    {
        Numbers = new();
        Random random = new();
        while (Numbers.Count() < 7)
        {
            int temp = random.Next(1,36);
            if (!Numbers.Contains(temp))
                Numbers.Add(temp);
        }
        Powerball = random.Next(1,21);

        Numbers.Sort();
    }

    public LotteryTicket(List<int> numbers, int powerball)
    {
        Numbers = numbers;
        Powerball = powerball;

        Numbers.Sort();
    }

    public int DivisionWin(List<int> drawnNumbers, int drawnPowerball)
    {
        int matches = 0;
        bool matchedPowerball = Powerball == drawnPowerball;
        foreach (int num in drawnNumbers)
        {
            if (Numbers.Contains(num))
            {
                matches++;
            }
        }

        switch (matches)
        {
            case 7:
                if (matchedPowerball)
                {
                    return 1;
                }
                return 2;
            case 6:
                if (matchedPowerball)
                {
                    return 3;
                }
                return 4;
            case 5:
                if (matchedPowerball)
                {
                    return 5;
                }
                return 7;
            case 4:
                if (matchedPowerball)
                {
                    return 6;
                }
                return 0;
            case 3:
                if (matchedPowerball) 
                {
                    return 8;
                }
                return 0;
            case 2:
                if (matchedPowerball)
                {
                    return 9;
                }
                return 0;
            default:
                return 0;
        }
    }
}