namespace mis_221_pa_5_uyentruong2003
{
    public class TrainerReport
    {
        private Trainers[] trainers;
        public TrainerReport(Trainers[] trainers){
            this.trainers = trainers;
        }
        
        public void PrintAllTrainersFromFile(){
            System.Console.WriteLine("\nLIST OF TRAINERS:");
            // print out the Trainers[] in console:
            for (int i = 0; i < Trainers.GetCount(); i++){
                System.Console.WriteLine(trainers[i].ToString());
            }
        }
    }
}