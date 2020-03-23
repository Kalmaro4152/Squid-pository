using System;
using System.Collections.Generic;
using System.Linq;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console, Open-Source
    // Author: Velis, John
    // Modified by: Kyle Morrill
    // Dated Created: 1/22/2020
    // Last Modified: 3/16/2020
    //
    // **************************************************

    public enum Commands
    {
        NONE,
        MOVEFORWARDS,
        MOVEBACKWARDS,
        STOP,
        WAIT,
        TURNLEFT,
        TURNRIGHT,
        LEDON,
        LEDOFF,
        LEDRED,
        LEDBLUE,
        LEDGREEN,
        GETTEMPURATURE,
        DONE
    }

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

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
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
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
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        LightAlarmDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
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
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
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
        //*********************
        // Data Recorder Menu
        //*********************

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorVisible = true;

            double dataPointFrequency = 0;
            double[] tempuratures = null;

            int numberOfPoints = 0;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder");

                //**********************
                // get user menu choice
                //**********************
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //**************************
                // process user menu choice
                //**************************
                switch (menuChoice)
                {
                    case "a":
                        numberOfPoints = DataRecorderDisplayGetNumberOfDataPoints(finchRobot);
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency(finchRobot);
                        break;

                    case "c":
                        tempuratures = DataRecorderDisplayGetData(numberOfPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(tempuratures, finchRobot);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        //***********************8
        // Display Recorded Data
        //***********************8
        static void DataRecorderDisplayData(double[] tempuratures, Finch finchRobot)
        {
            DisplayScreenHeader("Show Data");

            DataRecorderDisplayTable(tempuratures);

            Console.WriteLine();
            Console.WriteLine($"Average Tempurature: {tempuratures.Average()}");
            
            DisplayMenuPrompt("Data Recorder");
        }

        //**************************
        // Display a Table
        //**********************
        static void DataRecorderDisplayTable(double[] tempuratures)
        {
            Console.WriteLine("Data Point".PadLeft(12) + "Tempuratures".PadLeft(14));
            Console.WriteLine("----------".PadLeft(12) + "------------".PadLeft(14));
            for (int index = 0; index < tempuratures.Length; index++)
            {
                Console.WriteLine($"{index + 1}".PadLeft(12) + tempuratures[index].ToString("n2").PadLeft(14));
            }
        }

        //****************88888
        // Retrieve Data
        //***********************
        static double[] DataRecorderDisplayGetData(int numberOfPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] tempuratures = new double[numberOfPoints];
            int frequencyInSeconds; 

            DisplayScreenHeader("Get Data");

            //echo Information
            Console.WriteLine("The Finch Robot is now ready to record Tempuratures.");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfPoints; index++)
            {
                tempuratures[index] = finchRobot.getTemperature();
                Console.WriteLine($"Data #{index + 1}: {tempuratures[index]}c");
                frequencyInSeconds = (int)(dataPointFrequency * 1000);
                finchRobot.wait(frequencyInSeconds);
            }

            DisplayMenuPrompt("Data Recorder");
            return tempuratures;            
        }

        //*********************8
        //Freqeuncy of Data Points
        //***********************
        static double DataRecorderDisplayGetDataPointFrequency(Finch finchRobot)
        {
            double dataPointFrequncy;
            bool validRes = false;
            DisplayScreenHeader("Data Point Frequency");
            
            do
            {
                Console.Write("How Frequently to Take Readings (In Seconds) >> ");
                validRes = double.TryParse(Console.ReadLine(), out dataPointFrequncy);
                if (validRes == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please input a valid, numeric value.");
                }
                else
                {
                    DisplayMenuPrompt("Data Recorder");
                    return dataPointFrequncy;
                }
            } while (!validRes);
            
            Console.WriteLine("Ya Broke It");
            Console.ReadKey();
            return dataPointFrequncy;
        }

        //***********************
        //Number of Data Points
        //***********************8
        static int DataRecorderDisplayGetNumberOfDataPoints(Finch finchRobot)
        {
            int numberOfDataPoints;
            bool validRes = false;

            DisplayScreenHeader("Number of Data Points");
            
            do
            {
                Console.Write("Number of Data Points to Record >> ");
                validRes = int.TryParse(Console.ReadLine(), out numberOfDataPoints);
                if (validRes == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please input a valid, numeric value.");
                    
                }
                else
                {
                    DisplayMenuPrompt("Data Recorder");
                    return numberOfDataPoints;
                }
            } while (!validRes);

            Console.WriteLine("Ya Broke It");
            Console.ReadKey();
            return numberOfDataPoints;
        }

        #endregion

        #region Alarm System

        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {
            string sensorsToMonitor = "Not Defined";
            string rangeType = "Not Defined";
            string menuChoice;

            int minMaxThreshold = 0;
            int timeToMonitor = 0;

            bool quitMenu = false;
            

            do
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                DisplayScreenHeader("Light Level Alarm Menu");

                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Minimum/Maximum Threshold Values");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\t Select a Menu Option >> ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySensorsToMonitor(finchRobot);
                        break;

                    case "b":
                        rangeType = LightAlarmDisplaySetRangeType(finchRobot);
                        break;

                    case "c":
                        minMaxThreshold = LightAlarmDisplaySetMinMaxThreshold(finchRobot, rangeType);
                        break;

                    case "d":
                        timeToMonitor = LightAlarmDisplaySetTimeToMonitor(finchRobot);
                        break;

                    case "e":
                        LightAlarmDisplaySetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThreshold, timeToMonitor);
                        break;

                    case "q":                        
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        //**************
        //Sensor to Monitor
        //***************
        static string LightAlarmDisplaySensorsToMonitor(Finch finchRobot)
        {
            string sensorsToMonitor = "No Selected Sensor";
            bool response = false;

            DisplayScreenHeader("Sensors to Monitor");

            Console.WriteLine($"The {sensorsToMonitor} is the currently monitored sensor.");
            Console.WriteLine("Which Sensors should be Monitored?");
            Console.WriteLine("Left, Right, or Both?");

            do
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "left":
                        sensorsToMonitor = "left";
                        Console.WriteLine($"Now monitoring the {sensorsToMonitor} sensor.");
                        response = true;
                        break;

                    case "right":
                        sensorsToMonitor = "right";
                        Console.WriteLine($"Now monitoring the {sensorsToMonitor} sensor.");
                        response = true;
                        break;

                    case "both":
                        sensorsToMonitor = "both";
                        Console.WriteLine($"Now monitoring {sensorsToMonitor} sensors.");
                        response = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please dictate which sensor the Finch should monitor");
                        break;
                }
            } while (response == false);

            DisplayMenuPrompt("Light Alarm");
            return sensorsToMonitor;
        }

        //**************
        //Define Range Type
        //***************
        static string LightAlarmDisplaySetRangeType(Finch finchRobot)
        {
            bool response = false;
            string rangeType = "Not Defined";
            DisplayScreenHeader("Set Range Type");
            Console.WriteLine("\t\tDefine the Minimum or Maximum Limit of the Range.");
            Console.WriteLine("Limit is using a [Max]imum or [Min]imum?");

            do
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "min":
                        rangeType = "minimum";
                        Console.WriteLine($"Range type is now set to {rangeType}.");
                        response = true;
                        break;

                    case "max":
                        rangeType = "maximum";
                        Console.WriteLine($"Range type is now set to {rangeType}");
                        response = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please dictate which range type you wish to modify.");
                        break;
                }
            } while (!response);

            DisplayMenuPrompt("Light Alarm");
            return rangeType;
        }

        //*************
        //The Min/Max Threshold Value
        //***************
        static int LightAlarmDisplaySetMinMaxThreshold(Finch finchRobot, string rangeType)
        {
            int minMaxThreshold = 0;
            bool valRes = false;

            DisplayScreenHeader("Set the Min/Max Threshold.");
            
            Console.WriteLine($"\t\tDictate the value for the {rangeType} threshold.");
            Console.WriteLine("\tNote: This program saves only one threshold type and value at a time.");

            do
            {
                Console.Write($"{rangeType} threshold value >> ");
                valRes = int.TryParse(Console.ReadLine(), out minMaxThreshold);
                if (!valRes)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please dictate an Integer Number.");
                }
                else
                {
                    Console.WriteLine($"The {rangeType} threshold value is now {minMaxThreshold}");
                }
            } while (!valRes);
            
            
            DisplayMenuPrompt("Light Alarm");
            return minMaxThreshold;
        }

        //***********************
        //Set Duration to Monitr
        //**********************
        static int LightAlarmDisplaySetTimeToMonitor(Finch finchRobot)
        {
            int timeToMonitor = 0;
            bool validRes = false;

            DisplayScreenHeader("Set The Duration to Monitor");
            
            Console.WriteLine("\t\tSet the Duration of time to monitor for changes in seconds.");
            Console.WriteLine("How long would you like to monitor for changes in light level?");
            Console.WriteLine("Note: This program will take a probe reading every second for this duration.");
            
            do
            {
                Console.Write($"Duration to monitor >> ");
                validRes = int.TryParse(Console.ReadLine(), out timeToMonitor);
                if (!validRes)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please dictate an Integer Number.");
                }
                else
                {
                    Console.WriteLine($"The duration to monitor is now {timeToMonitor}");
                }
            } while (!validRes);
            
            DisplayMenuPrompt("Light Alarm");
            return timeToMonitor;
        }

        //***************
        //Enable the Alarm
        //*****************
        static void LightAlarmDisplaySetAlarm(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxThreshold, int timeToMonitor)
        {
            bool thresholdExceeded = true;            
            int currentLightSensorValue = 0;

            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"Sensor(s) to monitor: {sensorsToMonitor}");
            Console.WriteLine($"Range Type: {rangeType}");
            Console.WriteLine($"The {rangeType} Threshold: {minMaxThreshold}");
            Console.WriteLine($"The duration to monitor: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("Press any key to begin monitoring.");
            Console.ReadKey();
                        
            thresholdExceeded = LightAlarmMonitorLightSensors(finchRobot, rangeType, minMaxThreshold, timeToMonitor, currentLightSensorValue, sensorsToMonitor);
            currentLightSensorValue = LightAlarmGetLightSensorValue(finchRobot, sensorsToMonitor, currentLightSensorValue);

            if (thresholdExceeded == true)
            {
                Console.WriteLine($"The {rangeType} threshold value of {minMaxThreshold} was exceeded by a light sensor value of {currentLightSensorValue}");
                finchRobot.noteOn(589);
                finchRobot.setLED(255, 10, 24);
                finchRobot.wait(5000);
                finchRobot.noteOff();
                finchRobot.setLED(0, 0, 0);

                DisplayMenuPrompt("Light Alarm");
            }
            else
            {
                Console.WriteLine("The threshold values were not exceeded.");
                DisplayMenuPrompt("Light Alarm");
            }

        }

        //***************************
        //Get a Sensor Value
        //************************
        static int LightAlarmGetLightSensorValue(Finch finchRobot, string sensorsToMonitor, int currentLightSensorValue)
        {
            switch (sensorsToMonitor)
            {
                case "left":
                    currentLightSensorValue = finchRobot.getLeftLightSensor();
                    break;

                case "right":
                    currentLightSensorValue = finchRobot.getRightLightSensor();
                    break;

                case "both":
                    Console.WriteLine("Captures values from both sensors and averages them.");
                    currentLightSensorValue = (int)Math.Round(finchRobot.getLightSensors().Average());
                    break;
            }

            return currentLightSensorValue;
        }

        //************************
        //Monitors the Light Sensors
        //**************************
        static bool LightAlarmMonitorLightSensors(Finch finchRobot, string rangeType, int minMaxThreshold, int timeToMonitor, int currentLightSensorValue, string sensorsToMonitor)
        {
            bool thresholdExceeded = false;
            int passedTimeSec = 0;

            do
            {
                currentLightSensorValue = LightAlarmGetLightSensorValue(finchRobot, sensorsToMonitor, currentLightSensorValue);
                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThreshold)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxThreshold)
                        {
                            thresholdExceeded = true;
                        }
                        break;
                }
                finchRobot.wait(1000);
                passedTimeSec++;
                DisplayPassedTime(passedTimeSec);
            } while (!thresholdExceeded && passedTimeSec < timeToMonitor);

            return thresholdExceeded;
        }

        //*****************
        //Displays Elapsed TIme
        //******************
        static void DisplayPassedTime(int passedTimeSec)
        {
            Console.SetCursorPosition(15, 10);
            Console.WriteLine($"Elapsed Time: {passedTimeSec}");
        }

        #endregion

        #region User Programming
        
        //******************************
        //* User Programming (Sprint 4) *
        //******************************
        
        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            
            string menuChoice;
            
            bool quitMenu = false;

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            List<Commands> commands = new List<Commands>();
            
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                DisplayScreenHeader("User Programming");

                Console.WriteLine("\ta) Set Command Parimeters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\t Select a Menu Option >> ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "a":
                        commandParameters = UserProgrammingGetCommandParimeters();
                        break;

                    case "b":
                        UserProgrammingGetFinchCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayCommands(commands);
                        break;

                    case "d":
                        UserProgrammingExecuteCommands(finchRobot, commands, commandParameters);
                        break;

                    case "q":                        
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

    static (int motorSpeed, int ledBrightness, double waitSeonds) UserProgrammingGetCommandParimeters()
        {
            DisplayScreenHeader("Command Parameters");
            
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            bool validRes = false;

            do
            {
                Console.Write("\tInput Motor Speed [1 - 255] >> ");
                validRes = int.TryParse(Console.ReadLine(), out commandParameters.motorSpeed);
                if (!validRes | commandParameters.motorSpeed > 255 | commandParameters.motorSpeed < 1)
                {
                    Console.WriteLine("Please input a whole numerical value of 1 - 255");
                    Console.WriteLine();
                    validRes = false;
                }
                else Console.WriteLine();
            } while (!validRes);
            
            do
            {
                Console.Write("\tLED Brightness [1 - 255] >> ");
                validRes = int.TryParse(Console.ReadLine(), out commandParameters.ledBrightness);
                if (!validRes | commandParameters.ledBrightness > 255 | commandParameters.ledBrightness < 1)
                {
                    Console.WriteLine("Please input a whole numerical value of 1 - 255");
                    Console.WriteLine();
                    validRes = false;
                }
                else Console.WriteLine();
            } while (!validRes);
            
            do
            {
                Console.Write("\tInput Wait Time in Seconds >> ");
                validRes = double.TryParse(Console.ReadLine(), out commandParameters.waitSeconds);
                if (!validRes)
                {
                    Console.WriteLine("Please input a numerical value.");
                    Console.WriteLine();
                    validRes = false;   
                }
                else Console.WriteLine();
            } while (!validRes);

            Console.WriteLine($"The new Motor Speed is {commandParameters.motorSpeed}.");
            Console.WriteLine($"The new LED Brightness is {commandParameters.ledBrightness}.");
            Console.WriteLine($"The new Wait Time in Seconds is {commandParameters.waitSeconds}");

            DisplayMenuPrompt("User Programming");
            return commandParameters;
        }

    static void UserProgrammingGetFinchCommands(List<Commands> commands)
        {
            Commands command = Commands.NONE;
            int commandCount = 1;
            
            DisplayScreenHeader("Input Commands");

            Console.WriteLine("\tPlease input commands for Finch Robot to do.");
            Console.WriteLine("\tThis is a list of Available Commands:");

            foreach (string commandName in Enum.GetNames(typeof(Commands)))
            {
                Console.Write($"-{commandName.ToLower()}\t");
                if (commandCount % 5 == 0) Console.Write("\n");
                commandCount++;
            }
            Console.WriteLine();

            while (command != Commands.DONE)
            {
                Console.Write("Please enter a command: ");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command); 
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Please enter a command from the list above.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Commands will be executed in the order dictated above.");

            DisplayMenuPrompt("User Programming");
        }

    static void UserProgrammingDisplayCommands(List<Commands> commands)
        {
            DisplayScreenHeader("Display Chosen Commands");

            Console.WriteLine("\tThese are the commands you chose to insert.");
            foreach (Commands command in commands)
            {
                Console.WriteLine($"\t {command}");
            }

            DisplayMenuPrompt("User Programming");
        }

    static void UserProgrammingExecuteCommands(Finch finchRobot, List<Commands> commands, (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMilliSeconds = (int)(commandParameters.waitSeconds * 1000);
            string commandFeedback = "";
            const int TURNING_MOTOR_SPEED = 100;
            
            DisplayScreenHeader("Execute Commands");
            Console.WriteLine("The finch will now execute the list of commands");
            DisplayContinuePrompt();
            
            foreach (Commands command in commands)
            {
                switch (command)
                {
                    case Commands.NONE:
                        break;

                    case Commands.MOVEFORWARDS:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        commandFeedback = Commands.MOVEFORWARDS.ToString();
                        break;
                    
                    case Commands.MOVEBACKWARDS:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedback = Commands.MOVEBACKWARDS.ToString();
                        break;
                    
                    case Commands.STOP:
                        finchRobot.setMotors(0, 0);
                        commandFeedback = Commands.STOP.ToString();
                        break;
                    
                    case Commands.WAIT:
                        finchRobot.wait(waitMilliSeconds);
                        commandFeedback = Commands.WAIT.ToString();
                        break;
                    
                    case Commands.TURNLEFT:
                        finchRobot.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        commandFeedback = Commands.TURNLEFT.ToString();
                        break;
                    
                    case Commands.TURNRIGHT:
                        finchRobot.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        commandFeedback = Commands.TURNRIGHT.ToString();
                        break;
                    
                    case Commands.LEDON:
                        finchRobot.setLED(255, 255, 255);
                        commandFeedback = Commands.LEDON.ToString();
                        break;
                    
                    case Commands.LEDOFF:
                        finchRobot.setLED(0,0,0);
                        commandFeedback = Commands.LEDOFF.ToString();
                        break;
                    
                    case Commands.LEDRED:
                        finchRobot.setLED(255,0,0);
                        commandFeedback = Commands.LEDRED.ToString();
                        break;
                    
                    case Commands.LEDBLUE:
                        finchRobot.setLED(0,255,0);
                        commandFeedback = Commands.LEDBLUE.ToString();
                        break;
                    
                    case Commands.LEDGREEN:
                        finchRobot.setLED(0,0,255);
                        commandFeedback = Commands.LEDGREEN.ToString();
                        break;
                    
                    case Commands.GETTEMPURATURE:

                        commandFeedback = $"Current Tempurature: {finchRobot.getTemperature().ToString("n2")}";
                        break;
                    
                    case Commands.DONE:
                        commandFeedback = $"Finch is now finish executing given commands.";
                        break;
                }
                Console.WriteLine($"\t {commandFeedback}");
            }
            DisplayMenuPrompt("User Programming");
        }

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
            Console.WriteLine($"\tPress any key to return to the {menuName}.");
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
