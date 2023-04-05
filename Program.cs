using mis_221_pa_5_uyentruong2003;
Console.Clear();
// Main Menu:

// ManageTrainers()
Trainers[] trainers = new Trainers[100];
TrainerUtility utility = new TrainerUtility(trainers);
// Display trainers list:
utility.GetAllTrainersFromFile();

// // Add a new trainer:
// utility.AddTrainer();

// Edit an existing trainer:
utility.EditTrainer();