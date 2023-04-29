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
        // Get from file:
        public void GetAllTrainersFromFile(){
            //open file:
            StreamReader inFile = new StreamReader("trainers.txt");
            //process file:
            string lined = inFile.ReadLine();
            Trainers.SetCount(0); // prime read
            while(lined != null){
                string[] tempD = lined.Split('#');
                trainers[Trainers.GetCount()] = new Trainers(int.Parse(tempD[0]), tempD[1], tempD[2], tempD[3]);
                lined = inFile.ReadLine();
                Trainers.IncCount(); // update read
            }

            //Update the max ID:
            Trainers.SetMaxID(trainers[Trainers.GetCount()-1].GetTrainerID());

            //close file:
            inFile.Close();
        }
        // Print the trainers from file on screen:
        public void PrintOnScreen(){
            System.Console.WriteLine("LIST OF TRAINERS: ");
            for (int i = 0; i< Trainers.GetCount(); i++){
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

        //PromptUser:
        private void PromptUser(Trainers trainer){
            // Prompt for name:
            System.Console.Write("Trainer's name: ");
            trainer.SetTrainerName(Console.ReadLine());
            //Prompt for Mailing Address:
            System.Console.Write("Trainer's Mailing Address: ");
            trainer.SetTrainerMailingAddress(Console.ReadLine());
            //Prompt for Email Address:
            System.Console.Write("Trainer's Email Address: ");
            trainer.SetTrainerEmailAddress(Console.ReadLine());
        }

        // CheckInt:
        private int CheckInt(string input){
            int outInt;
            while (!int.TryParse(input, out outInt)){
                System.Console.WriteLine("Please input a valid number: ");
                input = Console.ReadLine();
            }
            outInt = int.Parse(input);
            return outInt;
        }

        // Add:   
        public void AddTrainer(){
            // Create a new trainer:
            Trainers newTrainer = new Trainers();
            // Prompt for input:
            System.Console.WriteLine("Enter the info of the new trainer below: ");
            PromptUser(newTrainer);
            // Create the ID for the new one:
            Trainers.IncMaxID();
            newTrainer.SetTrainerID(Trainers.GetMaxID());

            // Save the new trainer into the array:
            trainers[Trainers.GetCount()] = newTrainer;
            Trainers.IncCount();

            // Save to file:
            Save();
            System.Console.WriteLine("Trainer added!");

        }

        // GetSearchIndex:
        private int GetSearchedTrainerIndex(string action){
            // Prompt user to enter the trainer ID
            System.Console.Write($"Enter the ID of the trainer you want to {action}: ");    
            string input = Console.ReadLine();
            
            // Check & convert to integer if the input is a valid integer:
            int trainerID = CheckInt(input);

            // Get the index of the searched trainer:
            int searchIndex = FindIndex(trainerID);
            return searchIndex;
        }

        // Find the searched trainer index in the array given the trainerID:
        private int FindIndex(int trainerID){
            for (int i = 0; i < Trainers.GetCount(); i++){
                if (trainers[i].GetTrainerID() == trainerID){
                    return i;
                }
            }
            return -1;
        }

        // Find the searched trainer index in the array given the trainerName:
        public int FindIndexGivenTrainerName (string trainerName){
            for(int i =0; i<Trainers.GetCount(); i++){
                if (trainers[i].GetTrainerName() == trainerName){
                    return i;
                    break;
                }
            }
            return -1; 
        }
        

        // Edit:
        public void EditTrainer(){
            // Get the searchIndex:
            int trainerIndex = GetSearchedTrainerIndex("edit");

            // Search through the array of trainers:
            if (trainerIndex != -1){
                System.Console.WriteLine("Enter the updated info of the trainer below:");
                // Prompt user for updated input:
                PromptUser(trainers[trainerIndex]);   
            } else System.Console.WriteLine("Trainer ID not found.");

            Save();
        }

        // Delete a trainer:
        public void DeleteTrainer(){
            // Get the searchIndex:
            int searchIndex = GetSearchedTrainerIndex("delete");
            if (searchIndex != -1){
                // Ask for confirmation:
                System.Console.WriteLine($"Are you sure you want to delete: \"{trainers[searchIndex].ToString()}\" ?");
                string ans = Console.ReadLine();
                // answer validation:
                while(ans.ToUpper() != "YES" && ans.ToUpper()!= "NO"){
                    System.Console.WriteLine("Please only enter Yes or No: ");
                    ans = Console.ReadLine();
                }
                if (ans.ToUpper() == "YES"){
                    // Remove the search trainer and update the array:
                    Trainers[] temp = new Trainers[trainers.Length-1];
                    // Copy to temp[] the trainers before the removed one:
                    for (int i = 0; i < searchIndex; i++){
                        temp[i] = trainers[i];
                    }
                    // Copy to temp[] the trainers after the removed one, excluding the removed trainer:
                    for (int i = searchIndex; i < trainers.Length-1; i++){
                        temp[i] = trainers[i+1];
                    }

                    trainers = temp;
                    Trainers.DecCount();
                    Save();
                    System.Console.WriteLine("Trainer removed!");
                }
            

            } else System.Console.WriteLine("Trainer ID not found.");
            

        }

    }
}