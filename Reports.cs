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
            System.Console.WriteLine();
            string customerEmail = InputCustomerEmail(bookings);
            System.Console.WriteLine();
            // Clean previous content of report.txt file:
            ResetReportFile("INDIVIDUAL CUSTOMER SESSION REPORT");
            //Open file:
            StreamWriter outFile = new StreamWriter("report.txt",true);
            outFile.WriteLine($"Cusomer Email: {customerEmail}");
            // Loop through bookings to print out any bookings with the given customerEmail:
            for (int i = 0; i<Bookings.GetCount(); i++){
                if (bookings[i].GetCustomerEmail() == customerEmail){
                    //Print on screen
                    System.Console.WriteLine(bookings[i].ToString());
                    //Save in the report.txt file
                    outFile.WriteLine(bookings[i].ToFile());
                }
            }
            //Close file:
            outFile.Close();
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
            // Open file to save:
            StreamWriter outFile = new StreamWriter("report.txt",true);
            // Save the sorted bookings:
            for (int i = 0; i<Bookings.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            // Do CountByCustomer, Print on Screen, and Save to file:
            System.Console.WriteLine();
            CountByCustomer(bookings, ref outFile);
            // Close file:
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
                    ProcessBreakForCountByCustomer(ref curr, ref count, bookings[i], ref outFile);
                }
            }
            ProcessBreakForCountByCustomer(curr, count, ref outFile);
        }
        private void ProcessBreakForCountByCustomer(ref string curr, ref int count, Bookings newBooking, ref StreamWriter outFile){
            System.Console.WriteLine($"Customer: {curr} --> # of Bookings: {count}");
            outFile.WriteLine($"Customer: {curr} --> # of Bookings: {count}");
            curr = newBooking.GetCustomerName();
            count = 1;
        }
        private void ProcessBreakForCountByCustomer(string curr, int count, ref StreamWriter outFile){
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
            //Prompt user to input option to calc revenue by year or by month:
            System.Console.Write("Revenue Report by month or by year? Enter 'month' or 'year': ");
            string option = Console.ReadLine();
            while (option.ToLower() != "month" && option.ToLower() != "year"){
                System.Console.WriteLine("Invalid input. Please try again.");
                System.Console.Write("Enter 'month' or 'year': ");
                option = Console.ReadLine();
            }
            // Open file to save:
            StreamWriter outFile = new StreamWriter("report.txt",true);
            // Sort the bookings by date for control break later:
            SortByDate(ref bookings);
            if (option.ToLower() == "month"){
                outFile.WriteLine("Revenue By MONTH Breakdown:");
                // Calc the revenue by month, print on screen, and save in file:
                RevenueByMonth(bookings, listings, lUtility, ref outFile);
            } else{
                outFile.WriteLine("Revenue By YEAR Breakdown:");
                RevenueByYear(bookings, listings, lUtility, ref outFile);
            }
            // Close file:
            outFile.Close();
            System.Console.WriteLine("\nA report is now available in 'report.txt' file.");
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
        private void RevenueByMonth(Bookings[] bookings, Listings[] listings, ListingUtility lUtility, ref StreamWriter outFile){
            // Get the month and the year of the first booking
            string curr = (DateTime.Parse(bookings[0].GetSessionDate())).ToString("MM/yyyy");
            // Get the cost of the booking from LISTING to calc the revenue
            int listingIndex = lUtility.FindIndex(bookings[0].GetSessionID());
            double rev = listings[listingIndex].GetSessionCost();
            for (int i = 0; i< Bookings.GetCount(); i++){
                if ((DateTime.Parse(bookings[i].GetSessionDate())).ToString("MM/yyyy") == curr){
                    //accumulate the cost of the booking to the group's rev:
                    listingIndex = lUtility.FindIndex(bookings[i].GetSessionID());
                    rev += listings[listingIndex].GetSessionCost();
                } else{
                    ProcessBreakForRevByMonth(ref curr, ref rev, bookings[i], listings, lUtility, ref outFile);
                }
            }
            ProcessBreakForRevenue(curr, rev, ref outFile);  
        }
        private void ProcessBreakForRevByMonth(ref string curr, ref double rev, Bookings newBooking, 
                                            Listings[] listings, ListingUtility lUtility, ref StreamWriter outFile){
            System.Console.WriteLine($"{curr} --> Revenue: ${rev}");
            outFile.WriteLine($"{curr} --> Revenue: ${rev}");
            // Get the month & year of the booking to start a new group:
            curr = (DateTime.Parse(newBooking.GetSessionDate())).ToString("MM/yyyy");
            // Get the cost of that booking from LISTING to start new revenue calc:
            int listingIndex = lUtility.FindIndex(newBooking.GetSessionID());
            rev = listings[listingIndex].GetSessionCost();
        }

        private void ProcessBreakForRevenue(string curr, double rev, ref StreamWriter outFile){
            System.Console.WriteLine($"{curr} --> Revenue: ${rev}");
            outFile.WriteLine($"{curr} --> Revenue: ${rev}");
        }
        private void RevenueByYear(Bookings[] bookings, Listings[] listings, ListingUtility lUtility, ref StreamWriter outFile){
            // Get the year of the first booking
            string curr = (DateTime.Parse(bookings[0].GetSessionDate())).ToString("yyyy");
            // Get the cost of the booking from LISTING to calc the revenue
            int listingIndex = lUtility.FindIndex(bookings[0].GetSessionID());
            double rev = listings[listingIndex].GetSessionCost();
            for (int i = 0; i< Bookings.GetCount(); i++){
                if ((DateTime.Parse(bookings[i].GetSessionDate())).ToString("yyyy") == curr){
                    //accumulate the cost of the booking to the group's rev:
                    listingIndex = lUtility.FindIndex(bookings[i].GetSessionID());
                    rev += listings[listingIndex].GetSessionCost();
                } else{
                    ProcessBreakForRevByYear(ref curr, ref rev, bookings[i], listings, lUtility, ref outFile);
                }
            }
            ProcessBreakForRevenue(curr, rev, ref outFile);
        }
        private void ProcessBreakForRevByYear(ref string curr, ref double rev, Bookings newBooking, 
                                            Listings[] listings, ListingUtility lUtility, ref StreamWriter outFile){
            System.Console.WriteLine($"{curr} --> Revenue: ${rev}");
            outFile.WriteLine($"{curr} --> Revenue: ${rev}");
            // Get the month & year of the booking to start a new group:
            curr = (DateTime.Parse(newBooking.GetSessionDate())).ToString("yyyy");
            // Get the cost of that booking from LISTING to start new revenue calc:
            int listingIndex = lUtility.FindIndex(newBooking.GetSessionID());
            rev = listings[listingIndex].GetSessionCost();
        }
    }
}