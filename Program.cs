using System;
using System.Collections.Generic;
using System.Linq;

public class Influences
{
    public static void Main()
    {
        double[][] state = new double[4][];
        state[0] = new double[] { 0.3, 0.5, 0.8, double.NaN };
        state[1] = new double[] { 0, 0.2, 0.5, 0.7 };
        state[2] = new double[] { double.NaN, 0, 0.4, 0.6 };
        state[3] = new double[] { double.NaN, double.NaN, 0, 0.1 };

        double leadingMin = 0.6, leadingMax = 0.8, leadingIntensity = 4;
        double firstCoordinationMin = 0.3, firstCoordinationMax = 0.4, firstCoordinationIntensity = 8;
        double secondCoordinationMin = 0.2, secondCoordinationMax = 0.3, secondCoordinationIntensity = 10;

        int currentIndex = 0;
        double currentState = 0.0;

        for (int i = 1; i <= 30; i++)
        {
            if (currentIndex <= 3)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (state[currentIndex][j] <= currentState && state[currentIndex][j] != 0)
                    {
                        currentState -= state[currentIndex][j];
                        currentIndex = j + 1;
                        break;
                    }
                }
                Console.Write($"Day {i} ");

                if (ShouldImpactOccur(leadingIntensity))
                {
                    double powerOfInfluence = GenerateRandomInfluence(leadingMin, leadingMax);
                    currentState += powerOfInfluence;
                    leadingIntensity--;
                    for (int j = 3; j >= 0; j--)
                    {
                        if (state[currentIndex][j] <= currentState && state[currentIndex][j] != 0)
                        {
                            currentState -= state[currentIndex][j];
                            currentIndex = j + 1;
                            break;
                        }
                    }
                    Console.Write($"Leading influence has occured with the power of {powerOfInfluence} with the overall power of {currentState} and current level of {currentIndex}");
                }
                else if (ShouldImpactOccur(firstCoordinationIntensity))
                {
                    double powerOfInfluence = GenerateRandomInfluence(firstCoordinationMin, firstCoordinationMax);
                    currentState += powerOfInfluence;
                    firstCoordinationIntensity--;
                    for (int j = 3; j >= 0; j--)
                    {
                        if (state[currentIndex][j] <= currentState && state[currentIndex][j] != 0)
                        {
                            currentState -= state[currentIndex][j];
                            currentIndex = j + 1;
                            break;
                        }
                    }
                    Console.Write($"First coordination influence has occured with the power of {powerOfInfluence} with the overall power of {currentState} and current level of {currentIndex}");
                }
                else if (ShouldImpactOccur(secondCoordinationIntensity))
                {
                    double powerOfInfluence = GenerateRandomInfluence(secondCoordinationMin, secondCoordinationMax);
                    currentState += powerOfInfluence;
                    secondCoordinationIntensity--;
                    for (int j = 3; j >= 0; j--)
                    {
                        if (state[currentIndex][j] <= currentState && state[currentIndex][j] != 0)
                        {
                            currentState -= state[currentIndex][j];
                            currentIndex = j + 1;
                            break;
                        }
                    }
                    Console.Write($"Second coordination influence has occured with the power of {powerOfInfluence} with the overall power of {currentState} and current level of {currentIndex}");
                }
            }
            else
            {
                Console.Write($"Day {i} ");
            }
            Console.WriteLine();
        }
    }
    static bool ShouldImpactOccur(double intensity)
    {
        Random random = new Random();
        double probability = random.NextDouble();
        return probability < (intensity / 30);
    }
    static double GenerateRandomInfluence(double minValue, double maxValue)
    {
        Random random = new Random();
        return minValue + (maxValue - minValue) * random.NextDouble();
    }
}
