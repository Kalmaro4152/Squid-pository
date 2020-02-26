using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Velis, John
    // Dated Created: 1/22/2020
    // Last Modified: 1/25/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":

                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Play a Concert");
                Console.WriteLine("\tc) Dance (Badly)");
                Console.WriteLine("\td) Gotta Go Fast!");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        PlayBorderofLife(myFinch);
                        break;

                    case "c":
                        DisplayDanceMoves(myFinch);
                        break;

                    case "d":
                        ZoomByTimAllen(myFinch);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }

            DisplayMenuPrompt("Talent Show");
        }

        // *************************************************************************************************
        // * Talent Show > Play a Concert
        // * Plays the first few measures of "Bloom Nobly, Ink Black Cherry Blossom ~ Border of Life" by ZUN
        // *************************************************************************************************
        
        static void PlayBorderofLife(Finch finchRobot)
        {
            DisplayScreenHeader("Play Border of Life");
            
            Console.WriteLine("\tThe Finch will now play Bloom Nobly, Ink Black Cherry Blossom ~ Border of Life by ZUN");
            DisplayContinuePrompt();

            //Start playing
            finchRobot.setLED(230, 230, 250);

            DotQuarterNote150(finchRobot, 523);
            DotQuarterNote150(finchRobot, 698);
            QuarterNote150(finchRobot, 784);

            DotQuarterNote150(finchRobot, 523);
            DotQuarterNote150(finchRobot, 698);
            QuarterNote150(finchRobot, 784);

            QuarterNote150(finchRobot, 830);
            QuarterNote150(finchRobot, 698);
            QuarterNote150(finchRobot, 784);
            QuarterNote150(finchRobot, 622);

            WholeNote150(finchRobot, 698);

            DotQuarterNote150(finchRobot, 523);
            DotQuarterNote150(finchRobot, 622);
            QuarterNote150(finchRobot, 698);

            DotQuarterNote150(finchRobot, 466);
            DotQuarterNote150(finchRobot, 622);
            QuarterNote150(finchRobot, 698);

            QuarterNote150(finchRobot, 415);
            QuarterNote150(finchRobot, 349);
            QuarterNote150(finchRobot, 392);
            QuarterNote150(finchRobot, 311);

            WholeNote150(finchRobot, 349);

            finchRobot.setLED(0, 0, 0);
            DisplayMenuPrompt("Talent Show");
        }
        static void DotQuarterNote150(Finch finchRobot, int frequency)
        {
            finchRobot.noteOn(frequency);
            finchRobot.wait(600);
            finchRobot.noteOff();
        }
        static void QuarterNote150(Finch finchRobot, int frequency)
        {
            finchRobot.noteOn(frequency);
            finchRobot.wait(400);
            finchRobot.noteOff();
        }
        static void WholeNote150(Finch finchRobot, int frequency)
        {
            finchRobot.noteOn(frequency);
            finchRobot.wait(1600);
            finchRobot.noteOff();
        }
        
        //**************************
        // Talent Show > Bust a Move
        // Finch will now dance
        //**************************
        
        static void DisplayDanceMoves(Finch finchRobot)
        {
            DisplayScreenHeader("Crap Dancing");

            Console.WriteLine("\t Allow the finch to show you what it has been practicing!");
            DisplayContinuePrompt();
            for (int i = 0; i < 2; i++)
            {
                finchRobot.setMotors(255, 255);
                finchRobot.wait(450);
                finchRobot.setMotors(45, 150);
                finchRobot.wait(250);
                finchRobot.setMotors(180, 70);
                finchRobot.wait(450);
                finchRobot.setMotors(255, 20);
                finchRobot.wait(600);
                finchRobot.setMotors(20, 125);
                finchRobot.wait(150);
                finchRobot.setMotors(0, 0);
            }
            DisplayMenuPrompt("Talent Show");
        }
        
        //*************************
        //Talent Show > Zoom!
        // ZOOM BY TIM ALLEN!
        //*************************
        
        static void ZoomByTimAllen(Finch finchRobot)
        {
            DisplayScreenHeader("Zoom!");

            Console.WriteLine("\t The Finch will now zoom as fast as it can, watch out!");
            DisplayContinuePrompt();
            
            finchRobot.setMotors(255, 255);
            finchRobot.wait(2000);
            finchRobot.setMotors(255, 50);
            finchRobot.wait(1500);
            finchRobot.setMotors(255, 255);
            finchRobot.wait(2000);
            finchRobot.setMotors(0, 0);
            DisplayMenuPrompt("Talent Show");
        }

        #endregion

        #region DATA RECORDER

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
