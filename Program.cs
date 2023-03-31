// Add, Edit, Delete Trainer Info
using mis_221_pa_5_uyentruong2003;
Trainers[] trainers = new Trainers[100];
TrainerUtility tUtility = new TrainerUtility(trainers);

Trainers.SetCount(0);
tUtility.AddTrainer();

for (int i = 0; i<4; i++){
    System.Console.WriteLine(trainers[i].ToString());
    tUtility.AddTrainer();

}