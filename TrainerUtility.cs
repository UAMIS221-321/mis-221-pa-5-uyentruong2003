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
            //prime read:
            Trainers.SetCount(0); 
            Trainers.SetMaxID(0);
            string line = inFile.ReadLine(); 
            while(line != null){
                // split the line:
                string[] temp = line.Split('#');
                // create a new obj 'trainer' & pass the info into the constructor:
                trainers[Trainers.GetCount()] = new Trainers(int.Parse(temp[0]),temp[1],temp[2],temp[3]);
                // update maxID:
                if (int.Parse(temp[0]) > Trainers.GetMaxID()){
                    Trainers.SetMaxID(int.Parse(temp[0]));
                }
                //update read:
                line = inFile.ReadLine();
                Trainers.IncCount();


            }
            //close file:
            inFile.Close();

            // print out the Trainers[] in console:
            for (int i = 0; i < Trainers.GetCount(); i++){
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

        // Save:
        private void Save(){
            //open file
            StreamWriter outFile = new StreamWriter("trainers.txt");
            //process file
            for (int i = 0; i<Trainers.GetCount(); i++){
                outFile.WriteLine(trainers[i].ToFile());
            }
            //close file
            outFile.Close();
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
            Trainers.IncMaxID();
            newTrainer.SetTrainerID(Trainers.GetMaxID());

            // Save the new trainer into the array:
            trainers[Trainers.GetCount()] = newTrainer;
            Trainers.IncCount();

            // Save to file:
            Save();
        }

        // Find the searched trainer index in the array:
        private int Find(int searchID){
            for (int i = 0; i < Trainers.GetCount(); i++){
                if (trainers[i].GetTrainerID() == searchID){
                    return i;
                }
            }
            return -1;
        }

        // Edit:
        public void EditTrainer(){
            System.Console.WriteLine("Enter the ID of the trainer you want to edit: ");    
            string input = Console.ReadLine();
            int searchID;
            // Input validation
            while (!int.TryParse(input, out searchID)){
                System.Console.WriteLine("Please input a valid number: ");
                input = Console.ReadLine();
            }
            searchID = int.Parse(input);

            // Get the index of the searched trainer:
            int searchIndex = Find(searchID);

            // Search through the array of trainers:
            if (searchIndex != 1){
                 // Prompt for Name:
                System.Console.WriteLine("Enter the trainer's name: ");
                trainers[searchIndex].SetTrainerName(Console.ReadLine());
                //Prompt for Mailing Address:
                System.Console.WriteLine("Enter the trainer's Mailing Address: ");
                trainers[searchIndex].SetTrainerMailingAddress(Console.ReadLine());
                //Prompt for Email Address:
                System.Console.WriteLine("Enter the trainer's Email Address: ");
                trainers[searchIndex].SetTrainerEmailAddress(Console.ReadLine());
            }

            Save();
        }

        // Delete a trainer:
        

    }
}