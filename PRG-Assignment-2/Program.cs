//===============================//
// Student Number : S10258483F
// Student Name : Yong Xiang
// Student Number : S10257401E
// Student Name : Xavier 
// Person who committed : Xavier
//===============================//




using PRG_Assignment_2;
using System.Globalization;

static List<Customer> CreateCustomer()
{
    List<Customer> customers = new List<Customer>();
    string[] data = File.ReadAllLines("customers.csv");
    string[] header = data[0].Split(',');

    for (int i = 1; i < data.Length; i++)
    {
        string[] data2 = data[i].Split(",");

        // Check if the data2 array has enough elements
        if (data2.Length >= 5) // Adjust the number based on the expected number of columns
        {
            // Specify the corrected DateTime format here
            string dateFormat = "d/M/yyyy HH:mm";
            DateTime birthDate;

            try
            {
                if (DateTime.TryParseExact(data2[2], dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                {
                    string[] data3 = File.ReadAllLines("orders.csv");
                    Customer c = new Customer(data2[0], Convert.ToInt32(data2[1]), birthDate);
                    for (int j = 0; j < data3.Length; j++)
                    {
                        string[] data4 = data3[j].Split(",");
                        if (data2[1] == data4[1])
                        {
                            Order o = new Order(Convert.ToInt32(data4[0]), Convert.ToDateTime(data4[2]));
                            c.OrderHistory.Add(o);
                            c.CurrentOrder = o;
                            break;
                        }
                    }
                    customers.Add(c);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    return customers;
}

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
    ListAllCustomers();
    Console.WriteLine("Select a customer");
    string response = Console.ReadLine().ToLower();
    List<Customer> customers = CreateCustomer();
    string[] data = File.ReadAllLines("orders.csv");
    for (int i = 1; i < data.Length; i++)
    {
        string[] data2 = data[i].Split(",");
        Order order = new Order(Convert.ToInt32(data2[0]), Convert.ToDateTime(data2[2]));
        foreach (Customer c in customers)
        {
            if (Convert.ToInt32(data2[1]) == c.MemberId)
            {
                c.OrderHistory.Add(order);
            }
        }
    }
    foreach (Customer c in customers)
    {
        if (c.Name.ToLower() == response)
        {
            Console.WriteLine("Past Orders: ");
            Console.WriteLine("{0,-3}, {1,10}, {2,10}", "ID", "Time Received", "Time Fullfilled");
            for (int i = 0; i < c.OrderHistory.Count; i++)
            {
                Console.WriteLine("{0,-3}, {1,10}, {2,10}", c.OrderHistory[i].Id, c.OrderHistory[i].TimeReceived, c.OrderHistory[i]);
            }
            Console.WriteLine("-----------------------------------");
            if (c.CurrentOrder != null)
            {
                Console.WriteLine("Current Orders");
                Console.WriteLine("{0,-3}, {1,10}", "ID", "Time Received");
                Console.WriteLine("{0,-3}, {1,10}", c.CurrentOrder.Id, c.CurrentOrder.TimeReceived);
            }
        }
    }

}

//Option 6
void ModifyOrder()
{
    ListAllCustomers();
    Console.WriteLine("Select a customer");
    string response = Console.ReadLine().ToLower();
    List<Customer> customers = CreateCustomer();
    string[] data = File.ReadAllLines("orders.csv");
    for (int i = 1; i < data.Length; i++)
    {
        string[] data2 = data[i].Split(",");
        Order order = new Order(Convert.ToInt32(data2[0]), Convert.ToDateTime(data2[2]));
        foreach (Customer c in customers)
        {
            if (Convert.ToInt32(data2[1]) == c.MemberId)
            {
                c.OrderHistory.Add(order);
            }
        }
    }
}

