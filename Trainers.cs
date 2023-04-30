namespace mis_221_pa_5_uyentruong2003
{
    public class Trainers
    {
        private int trainerID;
        private string trainerName;
        private string trainerAddress;
        private string trainerEmail;
        static private int count;
        static private int maxID;
        // Constructors:
        public Trainers(){

        }

        public Trainers (int trainerID, string trainerName, string trainerAddress, string trainerEmail){
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.trainerAddress = trainerAddress;
            this.trainerEmail = trainerEmail;
        }

        // Settors & Gettors:
        // static count:
        static public void SetCount(int count){
            Trainers.count = count;
        }

        static public int GetCount(){
            return count;
        }

        static public void IncCount(){
            Trainers.count++;
        }

        static public void DecCount(){
            Trainers.count--;
        }

        // trainerID:

        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }

        public int GetTrainerID(){
            return trainerID;
        }

        // trainerName:
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetTrainerName(){
            return trainerName;
        }

        // trainerMailingAddress:
        public void SetTrainerAddress(string trainerAddress){
            this.trainerAddress = trainerAddress;
        }

        public string GetTrainerAddress(){
            return trainerAddress;
        }

        // trainerEmailAddress:
        public void SetTrainerEmail(string trainerEmail){
            this.trainerEmail = trainerEmail;
        }

        public string GetTrainerEmail(){
            return trainerEmail;
        }

        static public void SetMaxID(int maxID){
            Trainers.maxID = maxID;
        }

        static public int GetMaxID(){
            return Trainers.maxID;
        }

        static public void IncMaxID(){
            Trainers.maxID ++;
        }

        public override string ToString()
        {
            return $"{trainerID} - {trainerName} - {trainerAddress} - {trainerEmail}";
        }

        public string ToFile()
        {
            return $"{trainerID}#{trainerName}#{trainerAddress}#{trainerEmail}";
        }
    }
}  