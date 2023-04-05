namespace mis_221_pa_5_uyentruong2003
{
    public class Trainers
    {
        private int trainerID;
        private string trainerName;
        private string trainerMailingAddress;
        private string trainerEmailAddress;
        static private int count;
        // Constructors:
        public Trainers(){

        }

        public Trainers (int trainerID, string trainerName, string trainerMailingAddress, string trainerEmailAddress){
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.trainerMailingAddress = trainerMailingAddress;
            this.trainerEmailAddress = trainerEmailAddress;
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
        public void SetTrainerMailingAddress(string trainerMailingAddress){
            this.trainerMailingAddress = trainerMailingAddress;
        }

        public string GetTrainerMailingAddress(){
            return trainerMailingAddress;
        }

        // trainerEmailAddress:
        public void SetTrainerEmailAddress(string trainerEmailAddress){
            this.trainerEmailAddress = trainerEmailAddress;
        }

        public string GetTrainerEmailAddress(){
            return trainerEmailAddress;
        }

        public override string ToString()
        {
            return $"{trainerName}#{trainerMailingAddress}#{trainerEmailAddress}";
        }
    }
}  