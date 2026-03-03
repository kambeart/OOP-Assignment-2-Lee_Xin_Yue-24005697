using System;

// Program.cs - this is the entry point of the application
// TEB1043 Object Oriented Programming - Assignment 2
// Name: Lee Xin Yue
// Student ID: 24005697

class Program
{
    static void Main(string[] args)
    {
        // create a new game object and start the game
        Game game = new Game();
        game.StartGame();

        // wait for user to press enter before closing
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}