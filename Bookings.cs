namespace mis_221_pa_5_uyentruong2003
{
    public class Bookings
    {
        private int sessionID;
        private string customerName;
        private string customerEmail;
        private string sessionDate;
        private int trainerID;
        private string trainerName;
        private string sessionStatus;
        private static int count;
        
        public Bookings(){}
        public Bookings(int sessionID, string customerName, string customerEmail, string sessionDate, 
                            int trainerID, string trainerName, string sessionStatus){
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.sessionDate = sessionDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.sessionStatus = sessionStatus;
        }
        //Setters:
        public void SetSessionID(int sessionID){
            this.sessionID = sessionID;
        }
        public void SetCustomerName(string customerName){
            this.customerName = customerName;
        }
        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail; 
        }
        public void SetSessionDate(string sessionDate){
            this.sessionDate = sessionDate;
        }
        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public void SetSessionStatus(string sessionStatus){
            this.sessionStatus = sessionStatus;
        }
        static public void SetCount(int count){
            Bookings.count = count;
        }
        static public void IncCount(){
            Bookings.count++;
        }
        static public void DecCount(){
            Bookings.count--;
        }

        
        //Getters:
        public int GetSessionID(){
            return sessionID;
        }
        public string GetCustomerName(){
            return customerName;
        }
        public string GetCustomerEmail(){
            return customerEmail;
        }
        public string GetSessionDate(){
            return sessionDate;
        }
        public int GetTrainerID(){
            return trainerID;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public string GetSessionStatus(){
            return sessionStatus;
        }
        static public int GetCount(){
            return Bookings.count;
        }

        //ToString():
        public override string ToString(){
            return $"SessionID: {sessionID}\tCustomer: {customerName}\tCustomer Email: {customerEmail}\tDate: {sessionDate}\tTrainerID: {trainerID}\tTrainer: {trainerName}\tStatus: {sessionStatus}";
        }
        public  string ToFile(){
            return $"{sessionID}#{customerName}#{customerEmail}#{sessionDate}#{trainerID}#{trainerName}#{sessionStatus}";
        }
        
    }
}