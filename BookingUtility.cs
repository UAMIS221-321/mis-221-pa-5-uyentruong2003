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

            //Update the max ID:
            Bookings.SetMaxID(bookings[Bookings.GetCount()-1].GetSessionID());

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
            // get user's input:
            System.Console.WriteLine("Enter the info of the new session below: ");
            
            // PromptUser(ref newBooking);

            // create user's id:
            Bookings.IncMaxID();
            newBooking.SetSessionID(Bookings.GetMaxID());

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
        public void EditBooking(){}
        public void DeleteBooking(){}
    }
}