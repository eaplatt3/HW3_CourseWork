using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using CourseWorkLibraryV2;

/////////////////////////////////////////////////////////////////////////
// File: Program.cs                                                    //
//                                                                     //
// Purpose: Contains the Menu and file display, creation, submission   //
//                                                                     //
// Written By: Earl Platt III                                          //
//                                                                     //
// Compiler: Visual Studio 2019                                        //
//                                                                     //
/////////////////////////////////////////////////////////////////////////


namespace HW3_CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string num;
            string fileNameCreate;
            string fileNameRead;
            string userInput;
            int i;

            #region Class Instatiation
            CourseWork work = new CourseWork();
            #endregion

            #region Do-while Loop
            //Loop to loop menu
            do
            {
                Console.WriteLine("CourseWork Menu");
                Console.WriteLine("---------------");
                Console.WriteLine("1 - Read Coursework from JSON file");
                Console.WriteLine("2 - Read Coursework from XML file");
                Console.WriteLine("3 - Write Coursework to JSON file");
                Console.WriteLine("4 - Write Coursework to XML file");
                Console.WriteLine("5 - Display all Coursework data on screen");
                Console.WriteLine("6 - Find Submission");
                Console.WriteLine("7 - Exit");
                Console.Write("Enter Choice: ");
                num = Console.ReadLine();
                Console.WriteLine("");

                //Parse string to int 
                if (!Int32.TryParse(num, out i)) { }

                //Checks if user inputed 1
                if (i == 1)
                {

                    //Prompt User for filename
                    Console.Write("Enter JSON Filename: ");
                    fileNameRead = Console.ReadLine();
                    Console.WriteLine("");

                    //Searches and Opens file
                    FileStream reader = new FileStream(fileNameRead, FileMode.Open, FileAccess.Read);

                    //Pulls Data from file
                    DataContractJsonSerializer inputSerializer;
                    inputSerializer = new DataContractJsonSerializer(typeof(CourseWork));

                    //Pulls Data from file and inputs it into class
                    work = (CourseWork)inputSerializer.ReadObject(reader);
                    reader.Close(); //Closes File
                }

                //Checks if User inputed 2
                if (i == 2)
                {

                    //Prompt User for filename
                    Console.Write("Enter XML Filename: ");
                    fileNameRead = Console.ReadLine();
                    Console.WriteLine("");

                    //Searches and Opens file
                    FileStream reader = new FileStream(fileNameRead, FileMode.Open, FileAccess.Read);

                    //Pulls Data from file
                    DataContractSerializer inputSerializer;
                    inputSerializer = new DataContractSerializer(typeof(CourseWork));

                    //Pulls Data from file and inputs it into class
                    work = (CourseWork)inputSerializer.ReadObject(reader);
                    reader.Close();
                }

                //Checks if user inputed 3
                if (i == 3)
                {
                    //Prompts user for filename 
                    Console.Write("Enter JSON Filename: ");
                    fileNameCreate = Console.ReadLine();
                    Console.WriteLine("");

                    //Creates JSON file to be written to 
                    FileStream writer = new FileStream(fileNameCreate, FileMode.Create, FileAccess.Write);

                    //Uses the DataContract to write to file
                    DataContractJsonSerializer ser;
                    ser = new DataContractJsonSerializer(typeof(CourseWork));

                    //Writes to file
                    ser.WriteObject(writer, work);
                    writer.Close(); //Closes File
                }

                //Checks if user inputed 4
                if (i == 4)
                {
                    //Prompts user for filename 
                    Console.Write("Enter XML Filename: ");
                    fileNameCreate = Console.ReadLine();
                    Console.WriteLine("");

                    //Creates XML file to be written to 
                    FileStream writer = new FileStream(fileNameCreate, FileMode.Create, FileAccess.Write);

                    //Uses the DataContract to write to file
                    DataContractSerializer ser;
                    ser = new DataContractSerializer(typeof(CourseWork));

                    //Writes to file
                    ser.WriteObject(writer, work);
                    writer.Close(); //Closes File
                }

                //Checks if user inputed 5
                if(i == 5)
                {
                    Console.WriteLine(work.ToString());
                }

                //Checks if user inputed 6
                if(i == 6)
                {
                    Console.WriteLine("Enter Assignment Name");
                    userInput = Console.ReadLine().Trim();
                    Console.WriteLine(work.FindSubmission(userInput).ToString());
                }

                //Checks for vaild user input
                if (i < 1 || i > 7)
                {
                    Console.WriteLine("Invaild Input");
                    Console.WriteLine("Enter 1 to 7");
                    Console.WriteLine("");
                }

            } while (i != 7); //Loop will not exit until user inputs 7
            #endregion

            //Checks if user inputed 7
            if (i == 7)
            {
                //Terminates Application
                System.Environment.Exit(1);
            }
        }
    }
}
