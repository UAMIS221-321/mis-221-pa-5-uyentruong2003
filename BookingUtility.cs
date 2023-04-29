namespace mis_221_pa_5_uyentruong2003
{
    public class BookingUtility
    {
        private Bookings[] bookings = new Bookings[100];
        public BookingUtility(Bookings[] bookings){
            this.bookings = bookings;
        }
        public void GetAllBookingsFromFile(){
            //open file:
            StreamReader inFile = new StreamReader("transactions.txt");
            //process file:
            string line = inFile.ReadLine();
            Bookings.SetCount(0); // prime read
            while(line != null){
                string[] temp = line.Split('#');
                bookings[Bookings.GetCount()] = new Bookings(int.Parse(temp[0]), temp[1], temp[2],temp[3],int.Parse(temp[4]),temp[5],temp[6]);
                line = inFile.ReadLine();
                Bookings.IncCount(); // update read
            }

            //close file:
            inFile.Close();
        }
        public void PrintOnScreen(){
            System.Console.WriteLine("LIST OF BOOKINGS: ");
            for (int i = 0; i< Bookings.GetCount(); i++){
                System.Console.WriteLine(bookings[i].ToString());
            }
        }
                // Add:
        public void AddBooking(){
            Bookings newBooking = new Bookings();  
            //Get User input:
            System.Console.WriteLine("Enter the information of the new booking below: ");
            //Prompt user input for the all booking info; especially return sessionID
            PromptUser(ref newBooking);

            //New Booking is only made if the date hasn't passed:
            if (DateTime.Parse(newBooking.GetSessionDate())<DateTime.Today){
                System.Console.WriteLine("The session date has already passed. Booking can't be made");
            }else{
                //Set status of the booking in LISTINGS & BOOKINGS:
                newBooking.SetSessionStatus("Booked");
                UpdateStatusInListings(newBooking.GetSessionID(), "Booked");
                // Add the new booking to the bookings array:
                bookings[Bookings.GetCount()] = newBooking;
                Bookings.IncCount();

                // Save the updated listing array to file:
                Save();
                System.Console.WriteLine("Booking Added!");
            }       
        }
        // Update session status in listing:
        private void UpdateStatusInListings(int sessionID, string status){
            Listings[] listings = new Listings[100];
            ListingUtility lUtility = new ListingUtility(listings);
            lUtility.GetAllListingsFromFile();
            int sessionIndex = lUtility.FindIndex(sessionID);
            listings[sessionIndex].SetSessionStatus(status);
            lUtility.Save();

        }
        // Prompt to fill out the information of the booking (for editing/adding new booking); especially return sessionID:
        private void PromptUser(ref Bookings booking){
            // Get & Print all listings:
            Listings[] listings = new Listings[100];
            ListingUtility lUtility = new ListingUtility(listings);
            lUtility.GetAllListingsFromFile();
            lUtility.PrintOnScreen();
            //Prompt for sessionID input - validate: only VALID ID of AVAILABLE session - add to newBooking
            int sessionID = InputSessionID(ref booking, listings);
            //Retrieve sessionDate, and trainerName from Listings given the sessionID; then, add them to newBooking:
            string trainerName = RetrieveFromListings(ref booking, sessionID, listings,lUtility);
            //Retrieve trainerID from Trainers given the trainerName; then, add them to newBooking:
            RetrieveFromTrainers(ref booking, trainerName);
            //Prompt for customerName & customerEmail and then add to newBooking:
            GetCustomerInfo(ref booking); 
        }

        //Prompt for sessionID input - validate: only VALID ID of AVAILABLE session
        private int InputSessionID(ref Bookings booking, Listings[] listings){
            int sessionID = CheckSessionID(listings);
            booking.SetSessionID(sessionID);
            return sessionID;
        } 
        private int CheckSessionID(Listings[] listings){
            // prompt for user input of sessionID:
            System.Console.Write("Enter an Available session's ID: ");
            int sessionID = CheckInt(Console.ReadLine()); //prime read
            // Validate that the sessionID entered is valid and the session is Available
            while (!isAvailableSessionID(sessionID, listings)){
                System.Console.WriteLine("The session is booked or sessionID is invalid. Please try again.");
                System.Console.Write("Enter an Available session's ID: ");
                sessionID = CheckInt(Console.ReadLine()); //update read
            }
            return sessionID;
        }
        // Check if the input sessionID is a valid sessionID of an AVAILABLE session
        private bool isAvailableSessionID(int sessionID, Listings[] listings){
            bool available = false;
            for (int i = 0; i< Listings.GetCount(); i++){
                if(sessionID == listings[i].GetSessionID() && listings[i].GetSessionStatus() == "Available"){
                    available = true;
                    break;
                }
            }
            return available;
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
        //Retrieve sessionDate, and trainerName from Listings given the sessionID:
        private string RetrieveFromListings(ref Bookings booking, int sessionID, Listings[] listings, ListingUtility lUtility){
            int sessionIndex = lUtility.FindIndex(sessionID);
            booking.SetSessionDate(listings[sessionIndex].GetSessionDate());
            string trainerName = listings[sessionIndex].GetTrainerName();
            booking.SetTrainerName(trainerName);
            return trainerName;
        }
        //Retrieve trainerID from Trainers given the trainerName:
        private void RetrieveFromTrainers(ref Bookings booking, string trainerName){
            Trainers[] trainers = new Trainers[100];
            TrainerUtility tUtility = new TrainerUtility(trainers);
            tUtility.GetAllTrainersFromFile();
            int trainerIndex = tUtility.FindIndexGivenTrainerName(trainerName);
            booking.SetTrainerID(trainers[trainerIndex].GetTrainerID());
        }
        // Prompt user for customer info:
        private void GetCustomerInfo(ref Bookings booking){
            System.Console.Write("Enter Customer's Name: ");
            booking.SetCustomerName(Console.ReadLine());
            System.Console.Write("Enter Customer's Email: ");
            booking.SetCustomerEmail(Console.ReadLine());
        }

        // Save:
        private void Save(){
            //open file:
            StreamWriter outFile = new StreamWriter("transactions.txt");
            //process file:
            for (int i = 0; i<Bookings.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            //close file:
            outFile.Close();
        }
        
        // Prompt user for sessionID and return the index of the searched Booking:
        private int GetSearchedBookingIndex(string action){
            // Prompt user to enter the session ID
            System.Console.Write($"Enter the sessionID of the booking you want to {action}: ");    
            // Check & convert to integer if the input is a valid integer:
            int sessionID = CheckInt(Console.ReadLine());

            // Get the index of the booking given its sessionID:
            int bookingIndex = FindIndex(sessionID);
            return bookingIndex;
        }

        // find the Index of the given ID in the listing arr:
        public int FindIndex(int sessionID){
            for (int i = 0; i < Bookings.GetCount(); i++){
                if (bookings[i].GetSessionID() == sessionID){
                    return i;
                }
            }
            return -1;
        }
        private void UpdateStatusInBookings(int bookingIndex){
            DateTime date = DateTime.Parse(bookings[bookingIndex].GetSessionDate());
            if (date < DateTime.Today){
                System.Console.Write("The session has already passed. Is it a 'Completed' or 'No-Show' booking? ");
                string status = Console.ReadLine();
                while (status.ToLower() != "no-show" && status.ToLower() != "completed"){
                    System.Console.Write("Please only enter 'Completed' or 'No-Show': ");
                    status = Console.ReadLine();
                }
                bookings[bookingIndex].SetSessionStatus(status);
            } else{
                bookings[bookingIndex].SetSessionStatus("Booked");
            }
        }
        public void EditBooking(){
            // get the index of the searched listing from the array by prompting user for the SessionID:
            int bookingIndex = GetSearchedBookingIndex("edit");
            // Search through the array of bookings:
            if (bookingIndex != -1){
                System.Console.WriteLine("Enter the updated info of the booking below:");
                // Prompt user for updated input:
                UpdateStatusInListings(bookings[bookingIndex].GetSessionID(),"Available"); //return the status of the booking to available for editing
                PromptUser(ref bookings[bookingIndex]);
                // Update the status of the session in BOOKINGS (Completed/No-show) if the session already passed;
                // else, keep the default setting to "Booked"
                UpdateStatusInBookings(bookingIndex);
                //Update status in LISTINGS to "Booked":
                UpdateStatusInListings(bookings[bookingIndex].GetSessionID(),"Booked");

                // Save the updated booking to file:
                Save();
            } else System.Console.WriteLine("Session ID not found.");
            
            
        }
        public void CancelBooking(){
            // Get the searchIndex:
            int bookingIndex = GetSearchedBookingIndex("cancel");
            if (bookingIndex != -1){
                // Check the sessionDate. Only allow cancelling BEFORE the day of booking
                if (DateTime.Parse(bookings[bookingIndex].GetSessionDate()) <= DateTime.Today){
                    System.Console.WriteLine("You can only cancel booking before the date of the session date.");
                }else{
                    // Ask for confirmation:
                    System.Console.WriteLine($"Are you sure you want to delete:\n\"{bookings[bookingIndex].ToString()}\" ?");
                    string ans = Console.ReadLine();
                    // answer validation:
                    while(ans.ToUpper() != "YES" && ans.ToUpper()!= "NO"){
                        System.Console.Write("Please only enter Yes or No: ");
                        ans = Console.ReadLine();
                    }
                    if (ans.ToUpper() == "YES"){
                        // Update the status of the session in LISTINGS back to available
                        UpdateStatusInListings(bookings[bookingIndex].GetSessionID(),"Available");
                        // Delete from the array and transactions.txt file
                        RemoveBookingFromFile(bookingIndex);
                        System.Console.WriteLine("Booking removed!");
                    }
                }

            } else System.Console.WriteLine("Session ID not found.");
        }
        public void RemoveBookingFromFile(int bookingIndex){
            // Remove the searched booking and update the array:
            Bookings[] temp = new Bookings[bookings.Length-1];
            // Copy to temp[] the bookings before the removed one:
            for (int i = 0; i < bookingIndex; i++){
                temp[i] = bookings[i];
            }
            // Copy to temp[] the bookings after the removed one, excluding the removed booking:
            for (int i = bookingIndex; i < bookings.Length-1; i++){
                temp[i] = bookings[i+1];
            }
            bookings = temp;
            Bookings.DecCount();
            Save();
        }
    }
}