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
    }
}