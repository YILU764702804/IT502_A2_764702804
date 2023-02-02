/*
Project Name: The LANGHAM Hotel
Author Name: Yi Lu
Date:03/02/2023
*/
using System;
using System.Collections.Generic;
using System.IO;
namespace IT502_A2_764702804
{
    public class HotelRoom
    {
        public int RoomNumber { get; set; }
        public bool IsAllocated { get; set; }
    }
    // Custom Class - Customer
    public class HotelCustomer
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
    }
    // Custom Class - RoomAllocation
    public class RoomAllocation
    {
        public int AllocatedRoomNo { get; set; }
        public HotelCustomer AllocatedCustomer { get; set; }
    }

    // Custom Main Class - Program
    internal class Program
    {
        // Variables declaration and initialization
        public static HotelRoom[] listofRooms;
        // Using the List
        public static List<RoomAllocation> listOfRoomAllocaltions = new List<RoomAllocation>();
        // Declare the Variable for file path
        public static string FolderPath;
        public static string filePath;
        public static string backupfilePath;
        // Main function
        static void Main(string[] args)
        {
            try
            {
                //Declare the folderPath for the filePath
                FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                // Assgin the adress for filePath, Using method Path.Combine the folderPath and name the txt file "764702804"
                filePath = Path.Combine(FolderPath, "lhms_764702804.txt");
                //string backupFolderPath = Path.Combine(FolderPath, "lhms_764702804_backup.txt");
                char ans;
                do
                {
                    Console.Clear();
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine("               THE LANGHAM HOTEL MANAGEMENT SYSTEM                  ");
                    Console.WriteLine("                              MENU                                 ");
                    Console.WriteLine("***********************************************************************************");
                    Console.WriteLine("1. Add Rooms");
                    Console.WriteLine("2. Display Rooms");
                    Console.WriteLine("3. Allocate Rooms");
                    Console.WriteLine("4. De-Allocate Rooms");
                    Console.WriteLine("5. Display Room Allocation Details");
                    Console.WriteLine("6. Billing");
                    Console.WriteLine("7. Save the Room Allocations To a File");
                    Console.WriteLine("8. Show the Room Allocations From a File");
                    Console.WriteLine("9. Exit");
                    Console.WriteLine("0  Backup");
                    Console.WriteLine("***********************************************************************************");
                    Console.Write("Please Enter Your Choice Number:");
                    int option = Convert.ToInt32(Console.ReadLine());
                    // Using switch for the methods
                    switch (option)
                    {
                        case 1:
                            // Option 1 - adding Rooms function
                            Console.Clear();
                            AddRooms();
                            break;
                        case 2:
                            // display the rooms function;
                            Console.Clear();
                            DisplayRoom();
                            break;
                        case 3:
                            // allocate the room to customer function
                            Console.Clear();
                            AllocateRooms();
                            break;
                        case 4:
                            // De-Allocate Room From Customer function
                            Console.Clear();
                            DeAllocateRooms();
                            break;
                        case 5:
                            // display Room Alocations function;
                            Console.Clear();
                            DisplayRoomAllocationDetails();
                            break;
                        case 6:
                            //  Display "Billing Feature is Under Construction
                            Console.Clear();
                            Billing();
                            break;
                        case 7:
                            // Save Room Allocations ToFile
                            Console.Clear();
                            SaveRoomAllocationsToFile();
                            break;
                        case 8:
                            //Show Room Allocations From File
                            Console.Clear();
                            ShowRoomAllocationsFromFile();
                            break;
                        case 9:
                            // Exit Application
                            Console.WriteLine("Exit the System");
                            Environment.Exit(0);
                            break;
                        case 0:
                            // Copy the file to make Backup file
                            Console.Clear();
                            BackUpFile();
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("---------------------------------");
                    Console.Write("Press ('Y'/'y') To Continue - OR - Press ('N'/'n') to Stop:");
                    ans = Convert.ToChar(Console.ReadLine());
                } while (ans == 'y' || ans == 'Y');
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Main(args);
            }
        }
        // Option 1 - AddRooms
        static void AddRooms()
        {
            //Assigment2 Task3 (Exceptional Handling a.FormatException)
            try
            {
                // Ask user enter how many room they need to add
                Console.Write("Please enter how many rooms to be added: ");
                // Declare variable noofroom and assgin the value user entered
                int noofroom = Convert.ToInt32(Console.ReadLine());
                // Initialize the listofRooms and sets the index number user entered
                listofRooms = new HotelRoom[noofroom];
                // Using For loop
                for (int i = 0; i < noofroom; i++)
                {
                    // Initialize RoomNumber
                    HotelRoom Room = new HotelRoom();
                    // Ask user entered the Room Number
                    Console.Write("Please enter the Room Number: ");
                    // Read the number user entered and assign to Roomnumber
                    Room.RoomNumber = Convert.ToInt32(Console.ReadLine());
                    // the room have not been allocated yet
                    //Room.IsAllocated = false;
                    // Assign the objects to list
                    listofRooms[i] = Room;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // Option 2 - Display the situation of the room
        static void DisplayRoom()
        {
            // Use the Foreach to print out the lists of room, the number and occupation
            try
            {
                //Using foreach statement loop through the array listofRooms
                foreach (HotelRoom Room in listofRooms)
                {
                    Console.WriteLine("***********************************");
                    //Print out the number
                    Console.WriteLine(Room.RoomNumber);
                    if (Room.IsAllocated == false)
                    {
                        Console.WriteLine("The Room has not been assgined yet");
                    }
                    //If else print out the room has been assgined 
                    else
                    {
                        Console.WriteLine("The Room has been assigned");
                    }

                    Console.WriteLine("***********************************");
                }
            }
            //Catch the exception
            catch (Exception e)
            {
                Console.WriteLine("The Problem is {0}", e.Message);
            }
        }
        // Option 3 - Allocate room for customer
        static void AllocateRooms()
        {
            // Initialize customer
            HotelCustomer customer = new HotelCustomer();
            //print out to represent the function has been called successfuly
            Console.WriteLine("Allocate Room has been called right now");
            //Initialize HotelRoom
            //Using for loop though listofrooms
            for (int i = 0; i < listofRooms.Length; i++)
            {
                //if the room has not been assigned yet
                if (listofRooms[i].IsAllocated == false)
                {
                    //print out the available room for the user. 
                    Console.WriteLine("{0} is available \t", listofRooms[i].RoomNumber);
                }
            }
            //Ask user how many customer they wants to put for onece time
            Console.WriteLine("Please Entter how many Customer you want to assgin the room: ");
            //Read the number of user entered
            int num = Convert.ToInt32(Console.ReadLine());
            //Using for loop through those many people user entered
            for (int x = 0; x < num; x++)
            {
                Console.Write("Please Enter Customer Number: ");
                customer.CustomerNo = Convert.ToInt32(Console.ReadLine());
                Console.Write("PLease Enter Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Please Enter Room number: ");
                int RoomNumber = Convert.ToInt32(Console.ReadLine());
                bool IsAllocated = false;
                //Using for the loop, loop through the listofRooms
                for (int i = 0; i < listofRooms.Length; i++)
                {
                    //Use If for the room status, whether it is allocated
                    if (IsAllocated == listofRooms[i].IsAllocated)
                    {
                        //Allocate room number should be fit the RoomNumber which have in listofRooms
                        if (listofRooms[i].RoomNumber == RoomNumber)
                        {
                            IsAllocated = true;
                            listofRooms[i].IsAllocated = true;
                            if (IsAllocated == true)
                            {
                                //Initialize the RoomAllocation.
                                RoomAllocation roomallocation = new RoomAllocation();
                                //Assign the value to the variables in RoomAllocation.
                                roomallocation.AllocatedRoomNo = RoomNumber;
                                roomallocation.AllocatedCustomer = customer;
                                //Add Function then Add it to the listOfRoomAllocations.
                                listOfRoomAllocaltions.Add(roomallocation);
                                break;
                            }
                            else
                            {
                                Console.Write("Wrong Room Number...");
                            }
                        }
                    }
                }
            }
        }
        // Option 4 - De-Allocate room for customer
        static void DeAllocateRooms()
        {
            //Task3 Exceptional Handling: InvalidOperationException
            try
            {
                //Print out text represent the function has been called properly
                Console.WriteLine("DeAllocate Room function is called from main function switch");
                //Ask the user write which room need to be removed
                Console.Write("Please Enter the Room Number: ");
                //Read the number user entered it
                int RoomNumber = Convert.ToInt32(Console.ReadLine());
                //Declare bool type variables assign true to it
                bool IsAllocated = true;
                //Using for loop and through array listofRooms
                for (int i = 0; i < listofRooms.Length; i++)
                {
                    //Using if IsAllocated = false
                    if (IsAllocated == listofRooms[i].IsAllocated)
                    {
                        Console.WriteLine("Software there");
                        //And If listofRooms[i].RoomNumber == RoomNumber which user entered, if the number match.
                        if (listofRooms[i].RoomNumber == RoomNumber)
                        {
                            //Making sure the listofRooms[i] and IsAllocated is also false, when we display room
                            //It will display not being Assigned.
                            listofRooms[i].IsAllocated = false;
                            IsAllocated = false;
                            break;
                        }
                    }
                }
                // And if the IsAllocated is False,  
                if (IsAllocated == false)
                {
                    //find the RoomNumber match in the roomallocation.
                    RoomAllocation roomallocation = listOfRoomAllocaltions.Find(x => x.AllocatedRoomNo == RoomNumber);
                    //Remove function Remove it in the list of listOfRoomAllocation
                    listOfRoomAllocaltions.Remove(roomallocation);
                }
                else
                {
                    Console.Write("Wrong Room Number...");
                }
            }
            catch
            {
                Console.WriteLine("The number you entered is wrong, please try it again");
            }
        }
        // Option 5 - Display Room Allocation Details
        static void DisplayRoomAllocationDetails()
        {
            Console.WriteLine("DisplayRoomAllocationDetails() function is called from Main function switch");
            Console.WriteLine("**************************** Technicians Allocations Details ****************************************");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Customer Number\t Room Number\t Customer Name");
            Console.WriteLine("------------------------------------------------------------------------------------");
            //Use foreach loop through listOfRoomAllocations
            foreach (RoomAllocation roomallocation in listOfRoomAllocaltions)
            {
                //Pinrt out all the information, roomallocation.AllocatedCustomer.
                Console.WriteLine(roomallocation.AllocatedCustomer.CustomerNo + "\t\t" + roomallocation.AllocatedRoomNo + "\t\t" + roomallocation.AllocatedCustomer.CustomerName);
            }
        }
        // Option 6 - Billing is under construction
        static void Billing()
        {
            Console.WriteLine("Billing is currently under construction");
        }
        // Option 7 - Save Room Allocations To File
        static void SaveRoomAllocationsToFile()
        {
            //Assigment2 Task3 Exceptional Handling d.UnauthorizedAccessException
            try
            {
                DateTime dt = new DateTime();
                dt = System.DateTime.Now;
                string strFu = dt.ToString("dd-MM-yyyy HH:mm:ss");
                // Write each directory name to a file.
                StreamWriter sw = new StreamWriter(filePath);
                {
                    foreach (RoomAllocation roomallocation in listOfRoomAllocaltions)
                    {
                        Console.WriteLine(roomallocation.AllocatedRoomNo + "\t" + roomallocation.AllocatedCustomer.CustomerNo + "\t" + roomallocation.AllocatedCustomer.CustomerName + "\t" + strFu);
                        sw.WriteLine(roomallocation.AllocatedRoomNo + "\t" + roomallocation.AllocatedCustomer.CustomerNo + "\t" + roomallocation.AllocatedCustomer.CustomerName + "\t" + strFu);
                    }
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }

        }
        // Option 8 - Show Room Allocations From File
        static void ShowRoomAllocationsFromFile()
        {
            //Assigment2 Task3 Exceptional Handling c.FileNotFoundException.
            try
            {
                //FileMode.OpenOrCreate
                Console.WriteLine("The Show Room Allocation From the File have been called from Function Switch");
                FileStream f = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(f);
                //StreamReader streamReader = new StreamReader(filePath);
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }
        // Option 9 - Exit has already been implemented in the function swich
        // Option 10 - Make a backup File
        // Declare the folderPath variable
        static void BackUpFile()
        {
            // Assign the adress for backup filePath
            backupfilePath = Path.Combine(FolderPath, "lhms_764702804_backup.txt");
            try
            {
                // Print out the txt meaning the function been called
                Console.WriteLine("The Backup Function has been called from Function switch");
                Console.WriteLine(backupfilePath);
                Console.WriteLine(filePath);
                // Use if , if the backup file already exist, then delete it
                if (File.Exists(backupfilePath))
                {
                    //Delete the backup the file
                    File.Delete(backupfilePath);
                    //Copy the current file to make the new backup
                    File.Copy(Path.Combine(FolderPath, filePath), Path.Combine(FolderPath, backupfilePath));
                    //Delete the current file
                    File.Delete(filePath);
                }
                // Otherwise copy the current file to make a back up file
                else
                {
                    File.Copy(Path.Combine(FolderPath, filePath), Path.Combine(FolderPath, backupfilePath));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
          
        }
    }
}

