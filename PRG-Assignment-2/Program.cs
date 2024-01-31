//===============================//
// Student Number : S10258483F
// Student Name : Yong Xiang
// Student Number : S10257401E
// Student Name : Xavier 
// Person who committed : Xavier
//===============================//




using PRG_Assignment_2;
using System.Reflection.Metadata.Ecma335;


Queue<Order> goldQueue = new Queue<Order>();
Queue<Order> regularQueue = new Queue<Order>();
List<IceCream> IceCreamList = new List<IceCream>();
Dictionary<string, Order> memberOrders = new Dictionary<string, Order>();



bool exit = false;

while (!exit)
{
    Console.WriteLine("Welcome I.C Treats!");

    Console.WriteLine("--------------------MENU---------------------");
    Console.WriteLine("(1) List all customers");
    Console.WriteLine("(2) List all current orders ");
    Console.WriteLine("(3) Register a new customer");
    Console.WriteLine("(4) Create a customer's order");
    Console.WriteLine("(5) Display order details of a customer");
    Console.WriteLine("(6) Modify order details ");
    Console.WriteLine("(7) Process an order and checkout");
    Console.WriteLine("(8) Display monthly charged amounts breakdown & total charged amounts for the year");
    Console.WriteLine("(0) Exit the menu");
    Console.WriteLine("---------------------------------------------");

    Console.WriteLine("Enter your choice");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ListAllCustomers();
            break;
        case "2":
            ListAllCurrentOrders(goldQueue, regularQueue);
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
        case "7":
            ProcessOrderandCheckout();
            break;
        case "8":
            DisplayMonthly();
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


// Option 2
// Done by Xavier
void ListAllCurrentOrders(Queue<Order> goldQueue, Queue<Order> regularQueue)
{
    Console.WriteLine("List all current orders\n");

    // Display Gold Queue
    DisplayQueue("Gold Queue", goldQueue);

    // Display Regular Queue
    DisplayQueue("Regular Queue", regularQueue);
}

// Helper method to display orders for a specific queue
void DisplayQueue(string queueName, Queue<Order> queue)
{
    Console.WriteLine($"{queueName}:");

    if (queue.Count > 0)
    {
        foreach (var order in queue)
        {
            Console.WriteLine(order);
        }
    }
    else
    {
        Console.WriteLine("The queue is currently empty.");
    }

    Console.WriteLine();
}


//Option 3
void RegisterCustomer()
{
    Console.WriteLine("Register a new customer");

    // get customer's name
    Console.WriteLine("Enter your name: ");
    string name = Console.ReadLine();

    // get customer's member ID
    Console.WriteLine("Enter your member ID: ");
    int memberId = int.Parse(Console.ReadLine());

    // get customer's date of birth
    Console.Write("Enter customer date of birth (yyyy-mm-dd): ");
    DateTime dob = DateTime.Parse(Console.ReadLine());

    // create customer object
    Customer customer = new Customer(name, memberId, dob);

    // create new point card object
    PointCard newPointCard = new PointCard();

    // assign point card
    customer.Rewards = newPointCard;

    // display message
    Console.WriteLine("Customer successfully registered");

    // append the new customer to 'customer.csv'
    string filePath = "customers.csv";

    string membershipStatus = "Ordinary";
    int membershipPoints = customer.Rewards.Points;
    int punchCard = customer.Rewards.PunchCard;

    // Format date of birth as yyyy-MM-dd without time
    string formattedDob = customer.Dob.ToString("dd/MM/yyyy");

    // Append the customer information to the file
    using (StreamWriter sw = File.AppendText(filePath))
    {
        sw.WriteLine($"{customer.Name},{customer.MemberId},{formattedDob},{membershipStatus},{membershipPoints},{punchCard}");
    }
}



//Option 4
void CreateCustomerOrder()
{
    // list to store flavours and toppings
    List<Flavour> flavours = new List<Flavour>();
    List<Topping> toppings = new List<Topping>();


    // list all customers
    ListAllCustomers();

    // read the csv file
    string[] customers = File.ReadAllLines("customers.csv");

    // prompt user for memberID for new order
    Console.WriteLine("Enter your memberID to create a new order : ");
    string customerMemberId = Console.ReadLine();

    // create list to store memberIds in the customer.csv
    List<string> memberIds = new List<string>();



    for (int i = 1; i < customers.Length; i++)
    {
        string[] customersData = customers[i].Split(",");

        // add each member ID in the list
        memberIds.Add(customersData[1]);
    }



    // check if input has the memberID in the list
    if (memberIds.Contains(customerMemberId))
    {

        Order newOrder = new Order();



        bool addAnotherIceCream = true;

        while (addAnotherIceCream)
        {
            // prompt for type of ice cream
            Console.WriteLine("Enter type of ice cream\n(1) Cup\n(2) Cone\n(3) Waffle");

            int iceCreamType;
            while (!int.TryParse(Console.ReadLine(), out iceCreamType) || iceCreamType < 1 || iceCreamType > 3)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
            }

            // prompt for number of scoops
            Console.WriteLine("Enter the number of scoops (1-3): ");
            int numberOfScoops;
            while (!int.TryParse(Console.ReadLine(), out numberOfScoops) || numberOfScoops < 1 || numberOfScoops > 3)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
            }



            // prompt for flavours

            Console.WriteLine("Enter flavours for each scoop:");
            for (int scoop = 1; scoop <= numberOfScoops; scoop++)
            {
                string flavourType;

                // keep prompting until a valid flavor is entered
                while (true)
                {
                    Console.Write($"Enter flavour for scoop #{scoop}: ");
                    flavourType = Console.ReadLine();

                    // Convert the input to lowercase for case-insensitive comparison
                    string lowercaseFlavour = flavourType.ToLower();

                    // Check if the entered flavor is valid
                    if (lowercaseFlavour == "strawberry" || lowercaseFlavour == "vanilla" || lowercaseFlavour == "chocolate"
                        || lowercaseFlavour == "ube" || lowercaseFlavour == "seasalt" || lowercaseFlavour == "durian")
                    {
                        break; // Exit the loop if the flavor is valid
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter a valid flavour (Vanilla, Strawberry, Chocolate, Ube, Seasalt, Durian).");
                    }
                }

                bool isPremiumFlavour = (flavourType.ToLower() == "durian" || flavourType.ToLower() == "ube" || flavourType.ToLower() == "seasalt");

                Flavour flavour = new Flavour(flavourType, isPremiumFlavour, 1);

                flavours.Add(flavour);
            }


            // prompt user for number of toppings
            Console.WriteLine("Enter the number of toppings (0-4): ");
            int numberOfToppings;
            while (!int.TryParse(Console.ReadLine(), out numberOfToppings) || numberOfToppings < 0 || numberOfToppings > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 0 and 4.");
            }

            double toppingCost = numberOfToppings * 1.0;


            if (numberOfToppings > 0)
            {
                Console.WriteLine("Available toppings are : Sprinkles, Mochi, Sago, Oreos");
                for (int toppingCount = 0; toppingCount < numberOfToppings; toppingCount++)
                {
                    Console.Write($"Enter topping #{toppingCount + 1}: ");
                    string toppingType = Console.ReadLine();

                    if (toppingType.ToUpper() != "N")
                    {
                        Topping topping = new Topping(toppingType);
                        toppings.Add(topping);
                        toppingCost += 1.0;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            switch (iceCreamType)
            {
                case 1: // Cup
                    Cup cup = new Cup("Cup", numberOfScoops, flavours, toppings);
                    newOrder.AddIceCream(cup);
                    IceCreamList.Add(cup);

                    break;

                case 2: // Cone
                    // prompt if they want dipped cone
                    Console.WriteLine("Do you want the cone to be dipped? (Y/N): ");
                    bool dipped = Console.ReadLine().ToUpper() == "Y";

                    Cone cone = new Cone("Cone", numberOfScoops, flavours, toppings, dipped);
                    newOrder.AddIceCream(cone);
                    IceCreamList.Add(cone);

                    break;

                case 3: // Waffle
                    // prompt if they want waffle flavour
                    Console.WriteLine("Do you want flavoured waffle? (Y/N): ");
                    bool wantsWaffleFlavour = Console.ReadLine().ToUpper() == "Y";

                    string waffleFlavour = "";
                    if (wantsWaffleFlavour)
                    {
                        Console.WriteLine("Choose the waffle flavour:\n(1) Red velvet\n(2) Charcoal\n(3) Pandan Waffle");

                        int waffleFlavourChoice;
                        while (!int.TryParse(Console.ReadLine(), out waffleFlavourChoice) || waffleFlavourChoice < 1 || waffleFlavourChoice > 3)
                        {
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        }

                        switch (waffleFlavourChoice)
                        {
                            case 1:
                                waffleFlavour = "Red velvet";
                                break;
                            case 2:
                                waffleFlavour = "Charcoal";
                                break;
                            case 3:
                                waffleFlavour = "Pandan Waffle";
                                break;
                        }
                    }

                    Waffle waffle = new Waffle("Waffle", numberOfScoops, flavours, toppings, waffleFlavour);
                    newOrder.AddIceCream(waffle);
                    IceCreamList.Add(waffle);

                    break;
            }

            // Clear lists for the next iteration
            flavours.Clear();
            toppings.Clear();

            // Prompt if they want to add another ice cream
            Console.WriteLine("Do you want to add another ice cream to the order? (Y/N): ");

            while (true)
            {
                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "Y" || userInput == "N")
                {
                    addAnotherIceCream = userInput == "Y";
                    break; // Exit the loop if a valid choice is entered
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 'Y' or 'N'.");
                }
            }
        }



        // create a list to store membership tier in the customer.csv
        List<string> membershipTier = new List<string>();

        for (int i = 1; i < customers.Length; i++)
        {
            string[] customersData = customers[i].Split(",");

            // add each pointcard tier in the list
            membershipTier.Add(customersData[3]);
        }

        int customerIndex = memberIds.IndexOf(customerMemberId);

        if (customerIndex != -1)
        {
            string pointcardTier = membershipTier[customerIndex];

            if (pointcardTier == "Gold")
            {
                goldQueue.Enqueue(newOrder);
                Console.WriteLine("Order successfully made and added to Gold queue!");
                foreach (var iceCream in IceCreamList)
                {
                    Console.WriteLine(iceCream.ToString());
                }


            }
            else
            {
                regularQueue.Enqueue(newOrder);
                Console.WriteLine("Order successfully made and added to Regular queue!");
                foreach (var iceCream in IceCreamList)
                {
                    Console.WriteLine(iceCream.ToString());
                }


            }


            memberOrders.Add(customerMemberId, newOrder);

        }

    }
    else
    {
        Console.WriteLine("Invalid memberID. Please input a valid memberID.");
    }
}

//option 5
void DisplayOrder()
{
    // Read the customer CSV file
    string[] customers = File.ReadAllLines("customers.csv");

    // Create a dictionary to store past orders
    Dictionary<string, Order> pastOrders = new Dictionary<string, Order>();
    Dictionary<string, string> memberNameMap = new Dictionary<string, string>();

    foreach (var customerData in customers.Skip(1))
    {
        string[] customerDetails = customerData.Split(",");
        string memberID = customerDetails[1];
        string memberName = customerDetails[0];

        // Check if the current customer has past orders
        if (memberOrders.ContainsKey(memberID))
        {
            Order pastOrder = memberOrders[memberID];
            pastOrders.Add(memberID, pastOrder);
            memberNameMap.Add(memberID, memberName);
        }
    }

    ListAllCustomers();

    // Data validation loop for Member ID
    string selectedMemberID;
    while (true)
    {
        Console.WriteLine("Please Enter a 6-digit Member ID:");
        selectedMemberID = Console.ReadLine();

        // Check if the entered Member ID is exactly 6 digits
        if (selectedMemberID.Length == 6 && int.TryParse(selectedMemberID, out _))
        {
            break; // Exit the loop if the input is valid
        }
        else
        {
            Console.WriteLine("Invalid Member ID. Please enter a 6-digit numeric value.");
        }
    }

    if (memberNameMap.ContainsKey(selectedMemberID))
    {
        string memberName = memberNameMap[selectedMemberID];
        Console.WriteLine($"Customer: {memberName}");
    }
    else
    {
        Console.WriteLine($"Customer with Member ID {selectedMemberID} not found.");
        return; // Exit the method if the member ID is not found
    }

    if (pastOrders.ContainsKey(selectedMemberID))
    {
        Order retrievedOrder = pastOrders[selectedMemberID];
        Console.WriteLine($"Past Order details for {memberNameMap[selectedMemberID]}:\n{retrievedOrder}");
    }
    else
    {
        Console.WriteLine($"No past order found for {memberNameMap[selectedMemberID]}.");
    }
}


// Option 6
void ModifyOrder()
{
    ListAllCustomers();

    // Data validation loop for Member ID
    string selectedMemberID;
    while (true)
    {
        Console.WriteLine("Please Enter a 6-digit Member ID:");
        selectedMemberID = Console.ReadLine();

        // Check if the entered Member ID is exactly 6 digits
        if (selectedMemberID.Length == 6 && int.TryParse(selectedMemberID, out _))
        {
            break; // Exit the loop if the input is valid
        }
        else
        {
            Console.WriteLine("Invalid Member ID. Please enter a 6-digit numeric value.");
        }
    }

    if (memberOrders.ContainsKey(selectedMemberID))
    {
        Order currentOrder = memberOrders[selectedMemberID];
        Console.WriteLine($"Current Order details for Member ID {selectedMemberID}:\n{currentOrder}");
    }

    // Display options menu regardless of whether they have current orders
    Console.WriteLine("Choose an option:");
    Console.WriteLine("[1] Modify an existing ice cream");
    Console.WriteLine("[2] Add a new ice cream");
    Console.WriteLine("[3] Delete an existing ice cream");
    Console.Write("Enter your choice: ");
    string option = Console.ReadLine();

    // Switch based on the selected option
    switch (option)
    {
        case "1":
            ModifyExistingIceCream(selectedMemberID);
            break;
        case "2":
            AddNewIceCream(selectedMemberID);
            break;
        case "3":
            DeleteExistingIceCream(selectedMemberID);
            break;
        default:
            Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
            break;
    }
}

// Helper method to modify an existing ice cream in the order
void ModifyExistingIceCream(string memberID)
{
    if (memberOrders.ContainsKey(memberID))
    {
        Order currentOrder = memberOrders[memberID];

        // Display the ice creams in the current order
        Console.WriteLine("Ice Creams in the Current Order:");
        int index = 1;
        foreach (var iceCream in currentOrder.IceCreamList)
        {
            Console.WriteLine($"{index}. {iceCream}");
            index++;
        }

        // Prompt the user to select which ice cream to modify
        Console.Write("Enter the number of the ice cream to modify: ");
        if (int.TryParse(Console.ReadLine(), out int iceCreamIndex) && iceCreamIndex >= 1 && iceCreamIndex <= currentOrder.IceCreamList.Count)
        {
            // Get the selected ice cream
            IceCream selectedIceCream = currentOrder.IceCreamList[iceCreamIndex - 1];

            // Modify the selected ice cream
            Console.WriteLine("Choose an option to modify:");
            Console.WriteLine("[1] Modify scoops");
            Console.WriteLine("[2] Modify flavours");
            Console.WriteLine("[3] Modify toppings");
            Console.WriteLine("[4] Modify dipped cone (if applicable)");
            Console.WriteLine("[5] Modify waffle flavour (if applicable)");
            Console.Write("Enter your choice: ");
            string modificationOption = Console.ReadLine();

            switch (modificationOption)
            {
                case "1":
                    Console.Write("Enter the new number of scoops: ");
                    if (int.TryParse(Console.ReadLine(), out int newScoops))
                    {
                        selectedIceCream.Scoops = newScoops;
                        Console.WriteLine("Scoops modified successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for scoops. Please enter a valid number.");
                    }
                    break;

                case "2":
                    // Modify flavours
                    List<string> allowedFlavors = new List<string> { "vanilla", "chocolate", "strawberry", "durian", "ube", "sea salt" };

                    while (true)
                    {
                        Console.Write("Enter new flavours (comma-separated): ");
                        string newFlavorsInput = Console.ReadLine();

                        // Check for null or empty input
                        if (string.IsNullOrEmpty(newFlavorsInput))
                        {
                            Console.WriteLine("Invalid input for flavours. Please enter at least one flavor.");
                            continue;
                        }

                        List<string> newFlavors = newFlavorsInput.Split(',').Select(f => f.Trim().ToLower()).ToList();

                        // Validate input against allowed flavors
                        if (newFlavors.All(flavor => allowedFlavors.Contains(flavor)))
                        {
                            // Clear existing flavors
                            selectedIceCream.Flavours.Clear();

                            // Add new flavors
                            foreach (var flavor in newFlavors)
                            {
                                // Assuming Flavour class has a constructor that takes the flavor name,
                                // premium status, and quantity
                                Flavour newFlavour = new Flavour(flavor, false, 0); // Replace 0 with the desired quantity
                                selectedIceCream.Flavours.Add(newFlavour);
                            }

                            Console.WriteLine("Flavours modified successfully!");
                            break; // Exit the loop if flavors are successfully modified
                        }
                        else
                        {
                            Console.WriteLine("Invalid flavor(s). Please enter valid flavors: vanilla, chocolate, strawberry, durian, ube, sea salt.");
                        }
                    }

                    break;

                case "3":
                    // Modify toppings
                    List<string> allowedToppings = new List<string> { "sprinkles", "mochi", "sago", "oreos" };

                    while (true)
                    {
                        Console.Write("Enter new toppings (comma-separated): ");
                        string newToppingsInput = Console.ReadLine();

                        // Check for null or empty input
                        if (string.IsNullOrEmpty(newToppingsInput))
                        {
                            Console.WriteLine("Invalid input for toppings. Please enter at least one topping.");
                            continue;
                        }

                        List<string> newToppings = newToppingsInput.Split(',').Select(t => t.Trim().ToLower()).ToList();

                        // Validate input against allowed toppings
                        if (newToppings.All(topping => allowedToppings.Contains(topping)))
                        {
                            // Clear existing toppings
                            selectedIceCream.Toppings.Clear();

                            // Add new toppings
                            foreach (var topping in newToppings)
                            {
                                // Assuming Topping class has a constructor that takes the topping name
                                Topping newTopping = new Topping(topping);
                                selectedIceCream.Toppings.Add(newTopping);
                            }

                            Console.WriteLine("Toppings modified successfully!");
                            break; // Exit the loop if toppings are successfully modified
                        }
                        else
                        {
                            Console.WriteLine("Invalid topping(s). Please enter valid toppings: sprinkles, mochi, sago, oreos.");
                        }
                    }

                    break;

                // ModifyExistingIceCream method - Case 4
                case "4":
                    // Modify dipped cone
                    Console.Write("Enter new dipped cone (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out bool newDippedCone))
                    {
                        // Find or add a special "Dipped Cone" flavor
                        Flavour dippedConeFlavour = selectedIceCream.Flavours.FirstOrDefault(f => f.Type.Equals("Dipped Cone"));

                        if (dippedConeFlavour == null)
                        {
                            // If "Dipped Cone" flavor doesn't exist, add it
                            dippedConeFlavour = new Flavour("Dipped Cone", false, 0);
                            selectedIceCream.Flavours.Add(dippedConeFlavour);
                        }

                        // Set the premium status based on the user input
                        dippedConeFlavour.Premium = newDippedCone;

                        Console.WriteLine("Dipped cone modified successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for dipped cone. Please enter true or false.");
                    }
                    break;

                case "5":
                    // Modify waffle flavour
                    Console.Write("Enter new waffle flavour: ");
                    string newWaffleFlavour = Console.ReadLine().ToLower();

                    // Check for null or empty input
                    if (string.IsNullOrEmpty(newWaffleFlavour))
                    {
                        Console.WriteLine("Invalid input for waffle flavour. Please enter a valid waffle flavour.");
                        break;
                    }

                    // Set the waffle flavour directly without further validation
                    if (selectedIceCream is Waffle iceCreamWithWaffleFlavour)
                    {
                        iceCreamWithWaffleFlavour.WaffleFlavour = newWaffleFlavour;
                        Console.WriteLine("Waffle flavour modified successfully!");
                    }
                    else
                    {
                        Console.WriteLine("The ice cream option does not support waffle flavour.");
                    }
                    break;




                default:
                    Console.WriteLine("Invalid choice. No modifications made.");
                    break;
            }

            // Display the updated order
            Console.WriteLine($"Updated Order details for Member ID {memberID}:\n{currentOrder}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    else
    {
        Console.WriteLine($"No order found for Member ID {memberID}.");
    }
}

// Helper method to add a new ice cream to the order
void AddNewIceCream(string memberID)
{
    // Implementation to add a new ice cream to the order

    // Prompt the user for all the required info to create a new ice cream object
    Console.WriteLine("Enter details for the new ice cream:");

    Console.Write("Enter option (e.g., Cone, Cup, Waffle): ");
    string option = Console.ReadLine();

    Console.Write("Enter number of scoops: ");
    if (int.TryParse(Console.ReadLine(), out int scoops))
    {
        // Prompt the user for flavors
        List<Flavour> newFlavours = PromptForFlavours();

        // Prompt the user for toppings
        List<Topping> newToppings = PromptForToppings();

        // If the selected option supports waffle flavor, prompt for it
        string waffleFlavour = "";
        if (option.ToLower() == "waffle")
        {
            Console.Write("Enter waffle flavour: ");
            waffleFlavour = Console.ReadLine();
        }

        // Assuming you have a Waffle class that inherits from IceCream
        Waffle newIceCream = new Waffle(option, scoops, newFlavours, newToppings, waffleFlavour);

        // Add the new ice cream to the order
        if (memberOrders.ContainsKey(memberID))
        {
            Order currentOrder = memberOrders[memberID];
            currentOrder.AddIceCream(newIceCream);
            Console.WriteLine("New ice cream added to the order!");
        }
        else
        {
            Console.WriteLine($"No order found for Member ID {memberID}.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input for scoops. Please enter a valid number.");
    }
}


// Helper method to prompt the user for flavors
List<Flavour> PromptForFlavours()
{   
    List<Flavour> flavours = new List<Flavour>();

    Console.Write("Enter flavors (comma-separated): ");
    string flavoursInput = Console.ReadLine();

    // Check for null or empty input
    if (!string.IsNullOrEmpty(flavoursInput))
    {
        List<string> flavourNames = flavoursInput.Split(',').Select(f => f.Trim()).ToList();

        // Assuming you have a method to validate and create a flavour instance
        foreach (string flavourName in flavourNames)
        {
            Flavour newFlavour = CreateFlavour(flavourName);
            flavours.Add(newFlavour);
        }
    }

    return flavours;
}

// Helper method to prompt the user for toppings
List<Topping> PromptForToppings()
{
    List<Topping> toppings = new List<Topping>();

    Console.Write("Enter toppings (comma-separated): ");
    string toppingsInput = Console.ReadLine();

    // Check for null or empty input
    if (!string.IsNullOrEmpty(toppingsInput))
    {
        List<string> toppingNames = toppingsInput.Split(',').Select(t => t.Trim()).ToList();

        // Assuming you have a method to validate and create a topping instance
        foreach (string toppingName in toppingNames)
        {
            Topping newTopping = CreateTopping(toppingName);
            toppings.Add(newTopping);
        }
    }

    return toppings;
}

// Assuming you have a method to create a Flavour instance based on the provided name
Flavour CreateFlavour(string flavourName)
{
    // Implement this based on your actual Flavour class
    // You may validate the input and create a Flavour instance
    // For simplicity, I'll return a new Flavour with the provided name and default properties
    return new Flavour(flavourName, false, 0);
}

// Assuming you have a method to create a Topping instance based on the provided name
Topping CreateTopping(string toppingName)
{
    // Implement this based on your actual Topping class
    // You may validate the input and create a Topping instance
    // For simplicity, I'll return a new Topping with the provided name
    return new Topping(toppingName);
}


// Helper method to delete an existing ice cream from the order
void DeleteExistingIceCream(string memberID)
{
    // Implementation to delete an existing ice cream from the order
    // Prompt the user for which ice cream to delete and then remove that ice cream object from the order
    // Display a message if there are zero ice creams in the order after deletion

    if (memberOrders.ContainsKey(memberID))
    {
        Order currentOrder = memberOrders[memberID];

        // Display the ice creams in the current order
        Console.WriteLine("Ice Creams in the Current Order:");
        int index = 1;
        foreach (var iceCream in currentOrder.IceCreamList)
        {
            Console.WriteLine($"{index}. {iceCream}");
            index++;
        }

        // Prompt the user to select which ice cream to delete
        Console.Write("Enter the number of the ice cream to delete: ");
        if (int.TryParse(Console.ReadLine(), out int iceCreamIndex) && iceCreamIndex >= 1 && iceCreamIndex <= currentOrder.IceCreamList.Count)
        {
            // Remove the selected ice cream
            currentOrder.IceCreamList.RemoveAt(iceCreamIndex - 1);

            // Display a message if there are zero ice creams in the order after deletion
            if (currentOrder.IceCreamList.Count == 0)
            {
                Console.WriteLine("You cannot have zero ice creams in an order.");
            }
            else
            {
                Console.WriteLine("Ice cream deleted successfully!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    else
    {
        Console.WriteLine($"No order found for Member ID {memberID}.");
    }
}

//option 7 
void ProcessOrderandCheckout()
{
    // Manually dequeue the first item from goldQueue
    if (goldQueue.Count > 0)
    {
        Order firstGoldOrder = goldQueue.Peek(); // Peek to get the first item without removing
        Console.WriteLine($"Peeked at Gold Order: {firstGoldOrder.OrderNumber} - {firstGoldOrder.CustomerName}");

        // Now dequeue the first item
        Order dequeuedGoldOrder = goldQueue.Dequeue();
        Console.WriteLine($"Dequeued Gold Order: {dequeuedGoldOrder.OrderNumber} - {dequeuedGoldOrder.CustomerName}");
    }
    else
    {
        Console.WriteLine("Gold Queue is empty.");
    }

    // Manually dequeue the first item from regularQueue
    if (regularQueue.Count > 0)
    {
        Order firstRegularOrder = regularQueue.Peek(); // Peek to get the first item without removing
        Console.WriteLine($"Peeked at Regular Order: {firstRegularOrder.OrderNumber} - {firstRegularOrder.CustomerName}");

        // Now dequeue the first item
        Order dequeuedRegularOrder = regularQueue.Dequeue();
        Console.WriteLine($"Dequeued Regular Order: {dequeuedRegularOrder.OrderNumber} - {dequeuedRegularOrder.CustomerName}");
    }
    else
    {
        Console.WriteLine("Regular Queue is empty.");
    }// Manually dequeue the first item from goldQueue
    if (goldQueue.Count > 0)
    {
        Order firstGoldOrder = goldQueue.Peek(); // Peek to get the first item without removing
        Console.WriteLine($"Peeked at Gold Order: {firstGoldOrder.OrderNumber} - {firstGoldOrder.CustomerName}");

        // Now dequeue the first item
        Order dequeuedGoldOrder = goldQueue.Dequeue();
        Console.WriteLine($"Dequeued Gold Order: {dequeuedGoldOrder.OrderNumber} - {dequeuedGoldOrder.CustomerName}");
    }
    else
    {
        Console.WriteLine("Gold Queue is empty.");
    }

    // Manually dequeue the first item from regularQueue
    if (regularQueue.Count > 0)
    {
        Order firstRegularOrder = regularQueue.Peek(); // Peek to get the first item without removing
        Console.WriteLine($"Peeked at Regular Order: {firstRegularOrder.OrderNumber} - {firstRegularOrder.CustomerName}");

        // Now dequeue the first item
        Order dequeuedRegularOrder = regularQueue.Dequeue();
        Console.WriteLine($"Dequeued Regular Order: {dequeuedRegularOrder.OrderNumber} - {dequeuedRegularOrder.CustomerName}");
    }
    else
    {
        Console.WriteLine("Regular Queue is empty.");
    }
}



//option 8
void DisplayMonthly();
{

}