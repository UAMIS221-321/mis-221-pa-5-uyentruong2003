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
            // Get & Print available listings:
            Listings[] availableListings = GetAvailableListings();
            //Get User input:
            System.Console.WriteLine("Enter the information of the new booking below: ");
            //Prompt for sessionID input - validate only session available
            //Retrieve info about sessionDate, trainerName, and trainerID from Listings (trainerID might need to go further to Trainers)
            //Update status in Listings to "Booked"
            PromptUser(ref newBooking);

            // Add the new listing to the bookings array:
            bookings[Bookings.GetCount()] = newBooking;
            Bookings.IncCount();

            // Save the updated listing array to file:
            Save();
            System.Console.WriteLine("Session Added!");
        }
        // Save:
        private void Save(){
            //open file:
            StreamWriter outFile = new StreamWriter("bookings.txt");
            //process file:
            for (int i = 0; i<Bookings.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            //close file:
            outFile.Close();
        }
        private Listings[] GetAvailableListings(){
            Listings[] listings = new Listings[100];
            ListingUtility lUtility = new ListingUtility(listings);
            lUtility.GetAllListingsFromFile();
            Listings[] availableListings = new Listings[100];
            int availableCount = 0;
            //only print out the available sessions:
            for (int i = 0; i<Listings.GetCount(); i++){
                if (listings[i].GetSessionStatus() == "Available"){
                    System.Console.WriteLine(listings[i].ToString());
                    availableListings[availableCount] = listings[i];
                    availableCount ++;
                }
            }
            return availableListings;
        }
        private void PromptUser(ref Bookings booking){
            InputSessionID(ref booking);
            InputCustomerName(ref booking);
            InputCustomerEmail(ref booking);
        }
        private void InputSessionID(ref Bookings booking){

        }
        private void InputCustomerName(ref Bookings booking){
            
        }
        private void InputCustomerEmail(ref Bookings booking){
            
        
        public void EditBooking(){}
        public void DeleteBooking(){}
    }
}