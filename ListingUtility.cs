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
            Listings.SetMaxID(listings[Listings.GetCount()-1].GetListingID());

            //close file:
            inFile.Close();
            PrintOnScreen();
        }
        // Print the sessions from file on screen:
        private void PrintOnScreen(){
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
        private void PromptUser(Listings listing){
            // Trainer Validation- is the trainer in the trainers list?
            System.Console.Write("Trainer's name: ");
            listing.SetTrainerName(Console.ReadLine());
            // Date Validation- include day of the week (in the Listings class):
            System.Console.Write("Session's date: ");
            listing.SetSessionDate(Console.ReadLine());
            // Time Validation- pick from the given set (in the Listings class):
            System.Console.Write("Session's time: ");
            listing.SetSessionTime(Console.ReadLine());
            // Number Validation- must be double:
            System.Console.Write("Session's cost: ");
            listing.SetSessionCost(CheckDouble(Console.ReadLine()));
            // Status Validation- pick either taken or available:
            System.Console.Write("Session's status: ");
            listing.SetSessionStatus(Console.ReadLine()); 
        }

        static bool DateValidation(string input){
            bool isValid = true;
            // Check format (mm/dd/yyyy):
            if (!(input.Length == 10 && input[2] == '/' && input[5] == '/')){
                System.Console.WriteLine("Please input in format mm/dd/yyyy");
                isValid = false;
            } else{
                // Check if a valid date:
                DateTime date;
                if (!DateTime.TryParse(input, out date)){
                    System.Console.WriteLine("Please input a valid date");
                    isValid = false;
                } else{
                    // Restrict to only after today & within current year:
                    int currYear = DateTime.Today.Year;
                    if (DateTime.Compare(date,DateTime.Today)<=0 || date.Year != currYear){
                        System.Console.WriteLine("Only enter a date after today but within the current year");
                        isValid = false;
                    }
                }
                
            }
            return isValid;
        }
        // Add:
        public void AddListing(){
            Listings newListing = new Listings();
            // get user's input:
            System.Console.WriteLine("Enter the info of the new session below: ");
            PromptUser(newListing);

            // create user's id:
            Listings.IncMaxID();
            newListing.SetListingID(Listings.GetMaxID());

            // Add the new listing to the listings array:
            listings[Listings.GetCount()] = newListing;
            Listings.IncCount();

            // Save the updated listing array to file:
            Save();
            System.Console.WriteLine("Session Added!");
        }
        // Save:
        private void Save(){
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
                System.Console.WriteLine("Please input a valid number: ");
                input = Console.ReadLine();
            }
            outInt = int.Parse(input);
            return outInt;
        }

        // Get the Listing ID for the serched Session:
        private int GetSearchedListingIndex(string action){
            // Prompt user to enter the listing ID
            System.Console.WriteLine($"Enter the ID of the session you want to {action}: ");    
            // Check & convert to integer if the input is a valid integer:
            int searchedListingsID = CheckInt(Console.ReadLine());

            // Get the index of the searched listing:
            int searchIndex = FindIndexFromListingsArr(searchedListingsID);
            return searchIndex;
        }

        // find the Index of the given ID in the listing arr:
        private int FindIndexFromListingsArr(int searchID){
            for (int i = 0; i < Listings.GetCount(); i++){
                if (listings[i].GetListingID() == searchID){
                    return i;
                }
            }
            return -1;
        }

        // Edit:
        public void EditListing(){
            // get the index of the searched listing from the array by prompting user for the listingID:
            int searchIndex = GetSearchedListingIndex("edit");
            // Search through the array of trainers:
            if (searchIndex != -1){
                System.Console.WriteLine("Enter the updated info of the session below:");
                // Prompt user for updated input:
                PromptUser(listings[searchIndex]);   
            } else System.Console.WriteLine("Session ID not found.");

            Save();

        }

        // Delete:
        public void DeleteListing(){
            // Get the searchIndex:
            int searchIndex = GetSearchedListingIndex("delete");
            if (searchIndex != -1){
                // Ask for confirmation:
                System.Console.WriteLine($"Are you sure you want to delete: \"{listings[searchIndex].ToString()}\" ?");
                string ans = Console.ReadLine();
                // answer validation:
                while(ans.ToUpper() != "YES" && ans.ToUpper()!= "NO"){
                    System.Console.WriteLine("Please only enter Yes or No: ");
                    ans = Console.ReadLine();
                }
                if (ans.ToUpper() == "YES"){
                    // Remove the searched listing and update the array:

                    Listings[] temp = new Listings[listings.Length-1];
                    // Copy to temp[] the listings before the removed one:
                    for (int i = 0; i < searchIndex; i++){
                        temp[i] = listings[i];
                    }
                    // Copy to temp[] the listings after the removed one, excluding the removed listing:
                    for (int i = searchIndex; i < listings.Length-1; i++){
                        temp[i] = listings[i+1];
                    }
                    listings = temp;
                    Listings.DecCount();
                    Save();
                    System.Console.WriteLine("Session removed!");
                }
            

            } else System.Console.WriteLine("Session ID not found.");
        }
    }
}   

