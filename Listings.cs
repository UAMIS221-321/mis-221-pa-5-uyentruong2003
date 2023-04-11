namespace mis_221_pa_5_uyentruong2003
{
    public class Listings
    {
        private int listingID;
        private string trainerName;
        private string sessionDate;
        private string sessionTime;
        private double sessionCost;
        private string sessionStatus;

        static private int count;
        static private int maxID;

        public Listings(){

        }

        public Listings(int listingID, string trainerName, string sessionDate, string sessionTime, double sessionCost, string sessionStatus){
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.sessionCost = sessionCost;
            this.sessionStatus = sessionStatus;
        }

        // Setters and Getters:

        public void SetListingID(int listingID){
            this.listingID = listingID;
        }

        public int GetListingID(){
            return listingID;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetTrainerName(){
            return trainerName;
        }

        public void SetSessionDate(string sessionDate){
            this.sessionDate = sessionDate;
        }

        public string GetSessionDate(){
            return sessionDate;
        }

        public void SetSessionTime(string sessionTime){
            this.sessionTime = sessionTime;
        }

        public string GetSessionTime(){
            return sessionTime;
        }


        public void SetSessionCost(double sessionCost){
            this.sessionCost = sessionCost;
        }

        public double GetSessionCost(){
            return sessionCost;
        }


        public void SetSessionStatus(string sessionStatus){
            this.sessionStatus = sessionStatus;
        }

        public string GetSessionStatus(){
            return sessionStatus;
        }


        static public void SetCount(int count){
            Listings.count = count;
        }

        static public int GetCount(){
            return Listings.count;
        }

        static public void IncCount(){
            Listings.count++;
        }

        static public void DecCount(){
            Listings.count--;
        }

        static public void SetMaxID(int maxID){
            Listings.maxID = maxID;
        }

        static public int GetMaxID(){
            return Listings.maxID;
        }

        static public void IncMaxID(){
            Listings.maxID++;
        }

        public override string ToString()
        {
            return $"SessionID: {this.listingID}\nTrainer: {this.trainerName}\nDate:{this.sessionDate}\nTime: {this.sessionTime}\nPrice: ${this.sessionCost}\nStatus: {this.sessionStatus}\n \n";
        }
        public string ToFile()
        {
            return $"{this.listingID}#{this.trainerName}#{this.sessionDate}#{this.sessionTime}#{this.sessionCost}#{this.sessionStatus}";
        }

         

    }
}