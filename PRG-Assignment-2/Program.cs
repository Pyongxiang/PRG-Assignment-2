//===============================//
// Student Number : S10258483F
// Student Name : Yong Xiang
// Student Number : S10257401E
// Student Name : Xavier 
// Person who committed : Yong Xiang
//===============================//




using PRG_Assignment_2;






bool exit = false;

while (!exit)
{
    Console.WriteLine("Welcome I.C Treats!");
    Console.WriteLine("MENU");
    Console.WriteLine("(1) List all customers");
    Console.WriteLine("(2) List all current orders ");
    Console.WriteLine("(3) Register a new customer");
    Console.WriteLine("(4) Create a customer's order");
    Console.WriteLine("(5) Display order details of a customer");
    Console.WriteLine("(6) Modify order details ");
    Console.WriteLine("(0) Exit the menu");

    Console.WriteLine("Enter your choice");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ListAllCustomers();
            break;
        case "2":
            ListAllCurrentOrders();
            break;
        case "3":
            RegisterCustomer();
            break;
        case "4":
            CreateCustomerOrder();
            break;
        case "5":
            DisplayOrder();
            break;
        case "6":
            ModifyOrder();
            break;
        case "0":
            Console.WriteLine("Thank you for using I.C Treats!");
            exit = true;

            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

//Option 1 
//Done by Yong Xiang
void ListAllCustomers()
{
    Console.WriteLine("List all customers \n");

    //reading the csv file
    string[] customers = File.ReadAllLines("customers.csv");
    string[] customersData = customers[0].Split(",");

    //for loop for the header
    for (int j = 0; j < customersData.Length; j++)
    {
        Console.Write("{0,-20}", customersData[j]);
    }
    Console.WriteLine();

    //for loop for the customers information
    for (int i = 1; i < customers.Length; i++)
    {
        string[] customerData = customers[i].Split(",");


        for (int j = 0; j < customerData.Length; j++)
        {
            Console.Write("{0,-20}", customerData[j]);
        }

        Console.WriteLine();
    }
}


//Option 2
//Done by Xavier


void ListAllCurrentOrders()
{
    //reading the csv files
    string[] orders = File.ReadAllLines("orders.csv");
    string[] ordersData = orders[0].Split(',');

    string[] customers = File.ReadAllLines("customers.csv");
    


    // Create the gold and regular queue
    List<string> goldQueue = new List<string>();
    List<string> regularQueue = new List<string>();


    for (int i = 1; i < customers.Length; i++)
    {
        string[] customerDetails = customers[i].Split(",");

        if (customerDetails[3].Equals("Gold", StringComparison.OrdinalIgnoreCase))
        {
            goldQueue.Add(customerDetails[1]);
        }
        else
        {
            regularQueue.Add(customerDetails[1]);
        }
    }


    Console.WriteLine("\nGold Queue Order informations:");


    foreach (var memberId in goldQueue)
    {
        // Check if there are any orders for this memberId
        if (orders.Any(order => order.Split(',')[1].Trim() == memberId))
        {

            // Find and display orders for this memberId
            var customerOrders = orders.Where(order => order.Split(',')[1].Trim() == memberId);
            foreach (var order in customerOrders)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine();
        }
    }

    Console.WriteLine("\nRegular Queue Order informations:");

    // Loop through regularQueue
    foreach (var memberId in regularQueue)
    {
        // Check if there are any orders for this memberId
        if (orders.Any(order => order.Split(',')[1].Trim() == memberId))
        {

            // Find and display orders for this memberId
            var customerOrders = orders.Where(order => order.Split(',')[1].Trim() == memberId);
            foreach (var order in customerOrders)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine();
        }
    }
}

//Option 3
void RegisterCustomer()
{

}

//Option 4
void CreateCustomerOrder()
{
   
}

//Option 5
void DisplayOrder()
{

}

//Option 6
void ModifyOrder()
{

}