namespace mis_221_pa_5_uyentruong2003
{
    public class TrainerUtility
    {
        private Trainers[] trainers;

        // Constructors:
        public TrainerUtility(Trainers[] trainers){
            this.trainers = trainers;
        }

        //Get Trainers from File:
        public void GetAllTrainersFromFile(){
            //open file:
            StreamReader inFile = new StreamReader("trainers.txt");

            //process file:
            Trainers.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                // trainers[Trainers.GetCount()] = 
            }
        }

        // Add:   
        public void AddTrainer(){
            // Create a new trainer:
            Trainers newTrainer = new Trainers();
            // Prompt for name:
            System.Console.WriteLine("Enter the trainer's name: ");
            newTrainer.SetTrainerName(Console.ReadLine());
            //Prompt for Mailing Address:
            System.Console.WriteLine("Enter the trainer's Mailing Address: ");
            newTrainer.SetTrainerMailingAddress(Console.ReadLine());
            //Prompt for Email Address:
            System.Console.WriteLine("Enter the trainer's Email Address: ");
            newTrainer.SetTrainerEmailAddress(Console.ReadLine());
            // Create the ID for the new one:
            Trainers.IncCount();
            newTrainer.SetTrainerID(Trainers.GetCount());

            // Save the new trainer into the array:
            trainers[Trainers.GetCount()-1] = newTrainer;
        }

        // Edit:
        public void EditTrainer(){
            System.Console.WriteLine("Prompt ");    
            int searchID = int.Parse(Console.ReadLine());
            // Input Validation:
            //Binary Search:


        }
    }
}