using mis_221_pa_5_uyentruong2003;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Linq;
using System.Threading.Tasks;
MainMenu();

static void PressKeyGoBack(){
    System.Console.WriteLine("Press any key to go back...");
    Console.ReadKey();
}

static void MainMenu(){
    Console.Clear();
    string prompt = "MAIN MENU:";
    string[] options = {"Manage Trainers", "Manage Listings","Manage Bookings","Run Reports", "Exit Program"};
    Action[] actions = {ManageTrainersMenu, ManageListingsMenu, ManageBookingsMenu,RunReportsMenu,ExitProgram};
    Menu mainMenu = new Menu(prompt, options, actions);
    int selectedIndex = mainMenu.MakeChoice();
    mainMenu.RouteEm(selectedIndex);
}

// MANAGE TRAINERS:
static void ManageTrainersMenu(){
    Console.Clear();
    string prompt = "MANAGE TRAINERS MENU:";
    string[] options = {"View Trainers", "Add Trainers","Edit Trainers","Delete Trainers", "Exit"};
    Action[] actions = {ViewTrainers, AddTrainers, EditTrainers,DeleteTrainers,GoBack};
    Menu manageTrainersMenu = new Menu(prompt, options, actions);
    int selectedIndex = manageTrainersMenu.MakeChoice();
    manageTrainersMenu.RouteEm(selectedIndex);
    // Automatically reprompt mainmenu
    MainMenu();
}
static void ViewTrainers(){
    Trainers[] trainers = new Trainers[100];
    TrainerUtility utility = new TrainerUtility(trainers);
    utility.GetAllTrainersFromFile();
    utility.PrintOnScreen();
    PressKeyGoBack();
    // Reprompt manageTrainers Menu
    ManageTrainersMenu();
}
static void AddTrainers(){
    Trainers[] trainers = new Trainers[100];
    TrainerUtility utility = new TrainerUtility(trainers);
    utility.GetAllTrainersFromFile();
    utility.PrintOnScreen();
    System.Console.WriteLine();
    utility.AddTrainer();
    PressKeyGoBack();
    // Reprompt manageTrainers Menu
    ManageTrainersMenu();
}
static void EditTrainers(){
    Trainers[] trainers = new Trainers[100];
    TrainerUtility utility = new TrainerUtility(trainers);
    utility.GetAllTrainersFromFile();
    utility.PrintOnScreen();
    System.Console.WriteLine();
    utility.EditTrainer();
    System.Console.WriteLine();
    PressKeyGoBack();
    // Reprompt manageTrainers Menu
    ManageTrainersMenu();
}
static void DeleteTrainers(){
    Trainers[] trainers = new Trainers[100];
    TrainerUtility utility = new TrainerUtility(trainers);
    utility.GetAllTrainersFromFile();
    utility.PrintOnScreen();
    System.Console.WriteLine();
    utility.DeleteTrainer();
    System.Console.WriteLine();
    PressKeyGoBack();
    // Reprompt manageTrainers Menu
    ManageTrainersMenu();
}
static void GoBack(){
    //not doing anything
}

//MANAGE LISTINGS:
static void ManageListingsMenu(){
    Console.Clear();
    string prompt = "MANAGE LISTINGS MENU:";
    string[] options = {"View Listings", "Add Listings","Edit Listings","Delete Listings", "Exit"};
    Action[] actions = {ViewListings, AddListings, EditListings,DeleteListings,GoBack};
    Menu manageListingsMenu = new Menu(prompt, options, actions);
    int selectedIndex = manageListingsMenu.MakeChoice();
    manageListingsMenu.RouteEm(selectedIndex);
    // Automatically reprompt mainmenu
    MainMenu();
}
static void ViewListings(){
    Listings[] listings = new Listings[100];
    ListingUtility utility = new ListingUtility(listings);
    utility.GetAllListingsFromFile();
    utility.PrintOnScreen();
    System.Console.WriteLine();
    PressKeyGoBack();
    // Automatically reprompt managelisting menu
    ManageListingsMenu();
}
static void AddListings(){
    Listings[] listings = new Listings[100];
    ListingUtility utility = new ListingUtility(listings);
    utility.GetAllListingsFromFile();
    utility.AddListing();
    System.Console.WriteLine();
    PressKeyGoBack();
    // Automatically reprompt managelisting menu
    ManageListingsMenu();
}
static void EditListings(){
    Listings[] listings = new Listings[100];
    ListingUtility utility = new ListingUtility(listings);
    utility.GetAllListingsFromFile();
    utility.PrintOnScreen();
    System.Console.WriteLine();
    utility.EditListing();
    System.Console.WriteLine();
    PressKeyGoBack();
    // Automatically reprompt managelisting menu
    ManageListingsMenu();
}
static void DeleteListings(){
    Listings[] listings = new Listings[100];
    ListingUtility utility = new ListingUtility(listings);
    utility.GetAllListingsFromFile();
    utility.PrintOnScreen();
    System.Console.WriteLine();
    utility.DeleteListing();
    System.Console.WriteLine();
    PressKeyGoBack();
    // Automatically reprompt managelisting menu
    ManageListingsMenu();
}

//MANAGE BOOKINGS:
static void ManageBookingsMenu(){
    Console.Clear();
    string prompt = "MANAGE BOOKINGS MENU:";
    string[] options = {"View Bookings", "Add Bookings","Edit Bookings","Cancel Bookings", "Exit"};
    Action[] actions = {ViewBookings, AddBookings, EditBookings,CancelBookings,GoBack};
    Menu manageBookingsMenu = new Menu(prompt, options, actions);
    int selectedIndex = manageBookingsMenu.MakeChoice();
    manageBookingsMenu.RouteEm(selectedIndex);
    // Automatically return to Main Menu:
    MainMenu();
}
static void ViewBookings(){
    Bookings[] bookings = new Bookings[100];
    BookingUtility utility = new BookingUtility(bookings);
    utility.GetAllBookingsFromFile();
    utility.PrintOnScreen();
    System.Console.WriteLine();
    PressKeyGoBack();
    // Automatically reprompt managebooking menu
    ManageBookingsMenu();
}
static void AddBookings(){
    Bookings[] bookings = new Bookings[100];
    BookingUtility utility = new BookingUtility(bookings);
    utility.GetAllBookingsFromFile();
    utility.AddBooking();
    System.Console.WriteLine();
    PressKeyGoBack();
    // Automatically reprompt managebooking menu
    ManageBookingsMenu();
}
static void EditBookings(){
    Bookings[] bookings = new Bookings[100];
    BookingUtility utility = new BookingUtility(bookings);
    utility.GetAllBookingsFromFile();
    utility.PrintOnScreen();
    System.Console.WriteLine();
    utility.EditBooking();
    System.Console.WriteLine();
    PressKeyGoBack();
    // Automatically reprompt managebooking menu
    ManageBookingsMenu();
}
static void CancelBookings(){
    Bookings[] bookings = new Bookings[100];
    BookingUtility utility = new BookingUtility(bookings);
    utility.GetAllBookingsFromFile();
    utility.PrintOnScreen();
    System.Console.WriteLine();
    utility.CancelBooking();
    System.Console.WriteLine();
    PressKeyGoBack();
    // Automatically reprompt managebooking menu
    ManageBookingsMenu();
}

//RUN REPORTS:
static void RunReportsMenu(){
    Console.Clear();
    string prompt = "RUN REPORT MENU:";
    string[] options = {"Individual Customer Sessions Report", "Historical Customer Sessions Report","Historical Revenue Report", "Exit"};
    Action[] actions = {IndCusSesReport, HisCusSesReport, HisRevReport,GoBack};
    Menu runReportsMenu = new Menu(prompt, options, actions);
    int selectedIndex = runReportsMenu.MakeChoice();
    runReportsMenu.RouteEm(selectedIndex);
    // Automatically reprompt mainmenu
    MainMenu();
}
static void IndCusSesReport(){
    Reports report = new Reports();
    report.IndividualCustomerSession();
    System.Console.WriteLine();
    PressKeyGoBack();
    RunReportsMenu();
}
static void HisCusSesReport(){
    Reports report = new Reports();
    report.HistoricalCustomerSession();
    System.Console.WriteLine();
    PressKeyGoBack();
    RunReportsMenu();
}
static void HisRevReport(){
    Reports report = new Reports();
    report.HistoricalRevenue();
    System.Console.WriteLine();
    PressKeyGoBack();
    RunReportsMenu();
}

//EXIT PROGRAM:
static void ExitProgram(){
    Environment.Exit(0);
}










