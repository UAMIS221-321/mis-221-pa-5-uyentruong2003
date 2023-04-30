namespace mis_221_pa_5_uyentruong2003
{
    public class ListingUtility
    {
        private Listings[] listings;

        // constructor:
        public ListingUtility(Listings[] listings){
            this.listings  = listings;
        }

        // Get from file:
        public void GetAllListingsFromFile(){
            //open file:
            StreamReader inFile = new StreamReader("listings.txt");
            //process file:
            string line = inFile.ReadLine();
            Listings.SetCount(0); // prime read
            while(line != null){
                string[] temp = line.Split('#');
                listings[Listings.GetCount()] = new Listings(int.Parse(temp[0]), temp[1], temp[2], temp[3],double.Parse(temp[4]), temp[5]);
                line = inFile.ReadLine();
                Listings.IncCount(); // update read
            }

            //Update the max ID:
            Listings.SetMaxID(listings[Listings.GetCount()-1].GetSessionID());

            //close file:
            inFile.Close();
        }
        // Print the sessions from file on screen:
        public void PrintOnScreen(){
            System.Console.WriteLine("LIST OF SESSIONS: ");
            for (int i = 0; i< Listings.GetCount(); i++){
                System.Console.WriteLine(listings[i].ToString());
            }
        }

        // Check double:
        private double CheckDouble(string input){
            double outDouble;
            while (!double.TryParse(input, out outDouble)){
                System.Console.WriteLine("Please input a valid number: ");
                input = Console.ReadLine();
            }
            outDouble = double.Parse(input);
            return outDouble;
        }
        // PromptUser:
        private void PromptUser(ref Listings listing){
            InputTrainer(ref listing);
            InputDate(ref listing);
            InputTime(ref listing);
            InputCost(ref listing);
            InputStatus(ref listing);
        }

        public void InputTrainer(ref Listings listing){
            Trainers[] trainers = new Trainers[100];
            TrainerUtility tUtility = new TrainerUtility(trainers);
            tUtility.GetAllTrainersFromFile();
            tUtility.PrintOnScreen();
            // Trainer Validation- is the trainer in the trainers list?
            System.Console.Write("Trainer's name: ");
            string trainer = Console.ReadLine();
            Func<string,bool> CheckTrainer = isValidTrainer; 
            listing.SetTrainerName(InputValidation(ref trainer, "trainer", CheckTrainer));
        }

        public void InputDate(ref Listings listing){
            // Date Validation:
            System.Console.Write("Session's date: ");
            string date = Console.ReadLine();
            Func<string,bool> CheckDate = isValidDate;
            listing.SetSessionDate(InputValidation(ref date, "date (date must be in mm/dd/yyyy format and after today)", CheckDate));
        }

        public void InputTime(ref Listings listing){
            // Time Validation:
            System.Console.Write("Session's time: ");
            string time = Console.ReadLine();
            Func<string,bool> CheckTime = isValidTime;
            listing.SetSessionTime(InputValidation(ref time, "time",CheckTime));
        }
        public void InputCost(ref Listings listing){
            // Number Validation- must be double:
            System.Console.Write("Session's cost: ");
            listing.SetSessionCost(CheckDouble(Console.ReadLine()));
        }
        public void InputStatus(ref Listings listing){
            // Status Validation- pick either taken or available:
            System.Console.Write("Session's status (Available/Booked): ");
            string status = Console.ReadLine();
            Func<string,bool>CheckStatus = isValidStatus;
            listing.SetSessionStatus(InputValidation(ref status, "status", CheckStatus)); 
        }

        // Validation of user input based on the bool value returned from an isValid method:
        private string InputValidation(ref string input, string typeChecked, Func<string,bool> CheckValid){
            while (!CheckValid(input)){
                System.Console.WriteLine($"Invalid {typeChecked}. Please try again.");
                System.Console.Write($"Enter event {typeChecked}: ");
                input = Console.ReadLine();
            }
            return input;
        }

        private bool isValidTrainer(string input){
            bool valid = false;
            Trainers[] trainers = new Trainers[100];
            TrainerUtility tUtility = new TrainerUtility(trainers);
            tUtility.GetAllTrainersFromFile();
            for (int i =0; i<Trainers.GetCount(); i++){
                if (input == trainers[i].GetTrainerName()){
                    valid = true;
                    break;
                }
            }
            return valid;
        }

        private bool isValidDate(string input){
            // Attempt to parse the input as a DateTime object & check if the date is after today
            if (DateTime.TryParseExact(input, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date) && date > DateTime.Today){
                // If the parsing succeeded, check that the parsed date matches the input string
                // This is necessary to ensure that the input string is in the correct format
                return date.ToString("MM/dd/yyyy") == input;
            }

            // If the parsing failed, the input is not a valid date string
            return false;
        }
        private bool isValidTime(string input){
            // Parse the user input into a DateTime object
            DateTime time;
            if (DateTime.TryParse(input, out time)){
                // Convert the time to 24-hour format if it's in AM/PM format
                if (time.ToString("tt") == "PM" && time.Hour != 12)
                {
                    time = time.AddHours(12);
                }
                else if (time.ToString("tt") == "AM" && time.Hour == 12)
                {
                    time = time.AddHours(-12);
                }
                return true;
            } else return false;
        }
        private bool isValidStatus(string input){
            string[] status = {"Available", "Booked"};
            bool valid = false;
            for (int i = 0; i<status.Length; i++){
                if (input == status[i]){
                    valid = true;
                    break;
                }
            }
            return valid;
        }
        // Add:
        public void AddListing(){
            Listings newListing = new Listings();
            // get user's input:
            System.Console.WriteLine("Enter the info of the new session below: ");
            PromptUser(ref newListing);

            // create user's id:
            Listings.IncMaxID();
            newListing.SetSessionID(Listings.GetMaxID());

            // Add the new listing to the listings array:
            listings[Listings.GetCount()] = newListing;
            Listings.IncCount();

            // Save the updated listing array to file:
            Save();
            System.Console.WriteLine("Session Added!");
        }
        // Save:
        public void Save(){
            //open file:
            StreamWriter outFile = new StreamWriter("listings.txt");
            //process file:
            for (int i = 0; i<Listings.GetCount(); i++){
                outFile.WriteLine(listings[i].ToFile());
            }
            //close file:
            outFile.Close();
        }

        private int CheckInt(string input){
            int outInt;
            while (!int.TryParse(input, out outInt)){
                System.Console.Write("Please input a valid number: ");
                input = Console.ReadLine();
            }
            outInt = int.Parse(input);
            return outInt;
        }

        // Prompt user for sessionID and return the index of the searched Session:
        private int GetSearchedListingIndex(string action){
            // Prompt user to enter the listing ID
            System.Console.Write($"Enter the ID of the session you want to {action}: ");    
            // Check & convert to integer if the input is a valid integer:
            int sessionID = CheckInt(Console.ReadLine());

            // Get the index of listing given its ID:
            int searchIndex = FindIndex(sessionID);
            return searchIndex;
        }

        // find the Index of the given ID in the listing arr:
        public int FindIndex(int sessionID){
            for (int i = 0; i < Listings.GetCount(); i++){
                if (listings[i].GetSessionID() == sessionID){
                    return i;
                }
            }
            return -1;
        }

        // Edit:
        public void EditListing(){
            // get the index of the searched listing from the array by prompting user for the SessionID:
            int listingIndex = GetSearchedListingIndex("edit");
            // Search through the array of listings:
            if (listingIndex != -1){
                System.Console.WriteLine("Enter the updated info of the session below:");
                // Prompt user for updated input:
                PromptUser(ref listings[listingIndex]);   
            } else System.Console.WriteLine("Session ID not found.");

            Save();
        }

        // Delete:
        public void DeleteListing(){
            // Get the searchIndex:
            int listingIndex = GetSearchedListingIndex("delete");
            if (listingIndex != -1){
                // Ask for confirmation:
                System.Console.WriteLine($"Are you sure you want to delete:\n\"{listings[listingIndex].ToString()}\" ?");
                string ans = Console.ReadLine();
                // answer validation:
                while(ans.ToUpper() != "YES" && ans.ToUpper()!= "NO"){
                    System.Console.Write("Please only enter Yes or No: ");
                    ans = Console.ReadLine();
                }
                if (ans.ToUpper() == "YES"){
                    // Remove the Booking tied to this listing:
                    RemoveRelatedBooking(listings[listingIndex].GetSessionID());
                    // Remove the listing from file:
                    RemoveListingFromFile(listingIndex);
                    System.Console.WriteLine("Session listing removed!");
                    System.Console.WriteLine("Any booking tied to this session listing is also removed!");
                }
            

            } else System.Console.WriteLine("Session ID not found.");
        }
        public void RemoveListingFromFile(int listingIndex){
            // Remove the searched listing and update the array:
                    Listings[] temp = new Listings[listings.Length-1];
                    // Copy to temp[] the listings before the removed one:
                    for (int i = 0; i < listingIndex; i++){
                        temp[i] = listings[i];
                    }
                    // Copy to temp[] the listings after the removed one, excluding the removed listing:
                    for (int i = listingIndex; i < listings.Length-1; i++){
                        temp[i] = listings[i+1];
                    }
                    listings = temp;
                    Listings.DecCount();
                    Save();
        }
        private void RemoveRelatedBooking(int sessionID){
            Bookings[] bookings = new Bookings[100];
            BookingUtility bUtility = new BookingUtility(bookings);
            bUtility.GetAllBookingsFromFile();
            for (int i = 0; i<Bookings.GetCount(); i++){
                if(bookings[i].GetSessionID() == sessionID){
                    bUtility.RemoveBookingFromFile(i);
                }
            }
        }
    }
}   

