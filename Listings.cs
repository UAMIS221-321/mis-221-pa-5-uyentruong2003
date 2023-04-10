namespace mis_221_pa_5_uyentruong2003
{
    public class Listings
    {
        private int listingID;
        private string trainerName;
        private string sessionDate;
        private string sessionTime;
        private double sessionCost;
        private bool sessionStatus;

        public Listings(){

        }

        public Listings(int listingID, string trainerName, string sessionDate, string sessionTime, double sessionCost, bool sessionStatus){
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


        public void SetSessionStatus(bool sessionStatus){
            this.sessionStatus = sessionStatus;
        }

        public bool GetSessionStatus(){
            return sessionStatus;
        }

        public override string ToString()
        {
            return $"{this.listingID} - {this.trainerName} - {this.sessionDate} - {this.sessionTime} - {this.sessionCost} - {this.sessionStatus}";
        }

        public string ToFile()
        {
            return $"{this.listingID}#{this.trainerName}#{this.sessionDate}#{this.sessionTime}#{this.sessionCost}#{this.sessionStatus}";
        }

    }
}