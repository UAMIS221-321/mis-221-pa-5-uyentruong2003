using mis_221_pa_5_uyentruong2003;
Console.Clear();
// Main Menu:

static string GetChoice(string opt1,string opt2,string opt3,string opt4,string opt5){
    System.Console.WriteLine("\nTRAINERS MENU: ");
    System.Console.WriteLine($"\n1.{opt1}\n2.{opt2}\n3.{opt3}\n4.{opt4}\n5.{opt5}\n");
    System.Console.WriteLine("Please enter your choice: ");
    string choice = Console.ReadLine();
    return choice;
}

static void PressKeyClearScreen(){
    System.Console.WriteLine("\nPress any key to go back...");
    Console.ReadKey();
    Console.Clear();
}

// ManageTrainers()
Trainers[] trainers = new Trainers[100];
TrainerUtility utility = new TrainerUtility(trainers);
// TrainerReport report = new TrainerReport(trainers);
string choice = GetChoice("View Trainer List","Add a Trainer","Edit a Trainer","Delete a Trainer","Exit to Main Menu");

while(choice != "5"){
        if(choice == "1"){
            Console.Clear();
            utility.GetAllTrainersFromFile();
            utility.PrintFile();
            PressKeyClearScreen();
        }else if (choice == "2"){
            Console.Clear();
            utility.GetAllTrainersFromFile();
            utility.PrintFile();
            System.Console.WriteLine();
            utility.AddTrainer();
            PressKeyClearScreen();
        }else if (choice == "3"){
            Console.Clear();
            utility.GetAllTrainersFromFile();
            utility.PrintFile();
            System.Console.WriteLine();
            utility.EditTrainer();
            PressKeyClearScreen();
        } else if (choice == "4"){
            Console.Clear();
            utility.GetAllTrainersFromFile();
            utility.PrintFile();
            System.Console.WriteLine();
            utility.DeleteTrainer();
            PressKeyClearScreen();
        } else{
            System.Console.WriteLine("Invalid choice. Please only enter a number 1-5.");
        }

        choice = GetChoice("View Trainer List","Add a Trainer","Edit a Trainer","Delete a Trainer","Exit to Main Menu");


    }
