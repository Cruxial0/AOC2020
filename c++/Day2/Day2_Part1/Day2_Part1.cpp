// Day2_Part1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <fstream>
#include <StringParser.h>

using namespace std;

int getValidPasswords(int input[])
{
    for (size_t i = 0; i < sizeof(input); i++)
    {
        StringParser
    }
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
}
