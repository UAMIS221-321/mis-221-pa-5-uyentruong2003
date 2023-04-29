namespace mis_221_pa_5_uyentruong2003
{
    public class Reports
    {
        
         
        public Reports(){}
        //INDIVIDUAL CUSTOMER SESSION REPORT:
        public void IndividualCustomerSession(){
            Bookings[] bookings = new Bookings[100];
            BookingUtility bUtility = new BookingUtility(bookings);
            bUtility.GetAllBookingsFromFile();
            bUtility.PrintOnScreen();
            // Prompt for user input and validate input:
            string customerEmail = InputCustomerEmail(bookings);
            // Clean previous content of report.txt file:
            ResetReportFile("INDIVIDUAL CUSTOMER SESSION REPORT");
            // Loop through bookings to print out any bookings with the given customerEmail:
            for (int i = 0; i<Bookings.GetCount(); i++){
                if (bookings[i].GetCustomerEmail() == customerEmail){
                    //Print on screen
                    System.Console.WriteLine(bookings[i].ToString());
                    //Save in the report.txt file
                    StreamWriter outFile = new StreamWriter("report.txt",true);
                    outFile.WriteLine(bookings[i].ToFile());
                    outFile.Close();
                }
            }
            System.Console.WriteLine("\nA report is now available in 'report.txt' file.");   
        }

        private string InputCustomerEmail(Bookings[] bookings){
            System.Console.Write("Enter a customer's email address: ");
            string input = Console.ReadLine();
            while(!IsValidEmail(input, bookings)){
                System.Console.WriteLine("Invalid email. Please try again");
                System.Console.Write("Enter a customer's email address: ");
                input = Console.ReadLine();
            }
            return input;
        }
        // isValidEmail?
        private bool IsValidEmail(string input, Bookings[] bookings){
            bool valid = false;
            for (int i = 0; i< Bookings.GetCount(); i++){
                if (input == bookings[i].GetCustomerEmail()){
                    valid = true;
                    break;
                }
            }
            return valid;
        }
        private void ResetReportFile(string reportTitle){
            StreamWriter outFile = new StreamWriter("report.txt");
            outFile.WriteLine(reportTitle);
            outFile.Close();
        }

        //HISTORICAL CUSTOMER SESSION REPORT:
        public void HistoricalCustomerSession(){
            Bookings[] bookings = new Bookings[100];
            BookingUtility bUtility = new BookingUtility(bookings);
            bUtility.GetAllBookingsFromFile();
            // Clean previous content of report.txt file:
            ResetReportFile("HISTORICAL CUSTOMER SESSION REPORT");
            // Sort by Customer name then by Date:
            SortByCustomerThenByDate(ref bookings);
            // Print out on screen:
            System.Console.WriteLine("\nSorted By Customer Name Then By Date...");
            bUtility.PrintOnScreen();
            // Save to File:
            StreamWriter outFile = new StreamWriter("report.txt",true);
            // Save the sorted bookings:
            for (int i = 0; i<Bookings.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            // Do CountByCustomer & Print on Screen:
            System.Console.WriteLine();
            CountByCustomer(bookings, ref outFile);
            outFile.Close();  
            System.Console.WriteLine("\nA report is now available in 'report.txt' file.");
        }
        private void SortByCustomerThenByDate(ref Bookings[] bookings){
            for (int i = 0; i<Bookings.GetCount()-1; i++){
                int min = i;
                for (int j= min; j<Bookings.GetCount();j++){
                    if(bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerName()) < 0 || 
                    (bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerName()) == 0 && 
                    DateTime.Parse(bookings[j].GetSessionDate())< DateTime.Parse(bookings[min].GetSessionDate()))){
                        min = j;
                    }
                }
                if (min != i){
                    Swap (min, i, ref bookings);
                }
        
            }
        }
        private void Swap(int x, int y, ref Bookings[] bookings){
            Bookings temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }
        public void CountByCustomer(Bookings[] bookings, ref StreamWriter outFile){
            string curr = bookings[0].GetCustomerName();
            int count = 1;
            for (int i = 1; i < Bookings.GetCount(); i++){
                if (bookings[i].GetCustomerName() == curr){
                    count ++;
                }else{
                    ProcessBreak(ref curr, ref count, bookings[i], ref outFile);
                }
            }
            ProcessBreak(curr, count, ref outFile);
        }
        private void ProcessBreak(ref string curr, ref int count, Bookings newBooking, ref StreamWriter outFile){
            System.Console.WriteLine($"Customer: {curr} --> # of Bookings: {count}");
            outFile.WriteLine($"Customer: {curr} --> # of Bookings: {count}");
            curr = newBooking.GetCustomerName();
            count = 1;
        }
        private void ProcessBreak(string curr, int count, ref StreamWriter outFile){
            System.Console.WriteLine($"Customer: {curr} --> # of Bookings: {count}");
            outFile.WriteLine($"Customer: {curr} --> # of Bookings: {count}");
        }
        // HISTORICAL REVENUE REPORT:
        public void HistoricalRevenue(){
            Bookings[] bookings = new Bookings[100];
            BookingUtility bUtility = new BookingUtility(bookings);
            bUtility.GetAllBookingsFromFile();

            Listings[] listings = new Listings[100];
            ListingUtility lUtility = new ListingUtility(listings);
            lUtility.GetAllListingsFromFile();

            // Clean previous content of report.txt file:
            ResetReportFile("HISTORICAL REVENUE REPORT");
            // Sort the bookings by date:
            SortByDate(ref bookings);
            //Prompt user to input option to calc revenue by year or by month:
            System.Console.Write("Revenue Report by month or by year? Enter 'month' or 'year':");
            string option = Console.ReadLine();
            while (option.ToLower() != "month" && option.ToLower() != "year"){
                System.Console.WriteLine("Invalid input. Please try again.");
                System.Console.Write("Enter 'month' or 'year': ");
                option = Console.ReadLine();
            }
            if (option.ToLower() == "month"){
                RevenueByMonth(bookings, listings);
            } else{
                RevenueByYear(bookings, listings);
            }

        }
        private void SortByDate(ref Bookings[] bookings){
            for (int i = 0; i<Bookings.GetCount()-1; i++){
                int min = i;
                for (int j= min; j<Bookings.GetCount();j++){
                    if(DateTime.Parse(bookings[j].GetSessionDate())< DateTime.Parse(bookings[min].GetSessionDate())){
                        min = j;
                    }
                }
                if (min != i){
                    Swap (min, i, ref bookings);
                }
        
            }
        }
        private void RevenueByMonth(Bookings[] bookings, Listings[] listings){
            

        }
        private void RevenueByYear(Bookings[] bookings, Listings[] listings){

        }
        
    }
}