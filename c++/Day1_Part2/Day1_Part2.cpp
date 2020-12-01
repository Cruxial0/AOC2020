// Day1_Part2.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <fstream>

using namespace std;

int get2020Value(int input[], int fileLength)
{
    int val1, val2, val3;
    int result = 0;

    for (size_t i = 0; i < fileLength; i++)
    {
        val1 = input[i];
        for (size_t j = 0; j < fileLength; j++)
        {
            val2 = input[j];
            for (size_t k = 0; k < fileLength; k++)
            {
                val3 = input[k];
                if (val1 + val2 + val3 == 2020)
                {
                    result = val1 * val2 * val3;
                }
            }
        }
    }
    return result;
}

int main()
{
    ifstream file("input.txt");

    int myArray[sizeof(file)];

    int fileLength = sizeof(file);

    if (file.is_open())
    {
        for (int i = 0; i < sizeof(file); ++i)
        {
            file >> myArray[i];
        }
    }

    cout << get2020Value(myArray, fileLength) << endl;
}
