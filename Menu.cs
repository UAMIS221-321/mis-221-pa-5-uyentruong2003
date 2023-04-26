using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;


namespace mis_221_pa_5_uyentruong2003
{
    public class Menu
    {
        private int selectedIndex;
        private string[] options;
        private Action[] actions;
        private string prompt;

        public Menu(string prompt, string[] options, Action[] actions){
            this.prompt = prompt;
            this.options = options;
            this.actions = actions;
            selectedIndex = 0;
        }

        public void DisplayOptions(){
            ascii_text title = new ascii_text();
            title.Main();
            System.Console.WriteLine(prompt);
            for (int i = 0; i < options.Length; i++){
                string currentOption = options[i];
                string prefix;
                if (i == selectedIndex){
                    prefix= "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }else{
                    prefix= " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                System.Console.WriteLine($"{prefix} <<{currentOption}>>");
            }
            ResetColor();
        }
        public int MakeChoice(){
            ConsoleKey keyPressed;
            do{
                Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                // Update selectedIndex based on arrow keys.
                if (keyPressed == ConsoleKey.UpArrow){
                    selectedIndex--;
                    if (selectedIndex == -1){
                        selectedIndex = options.Length-1;
                    }
                }else if (keyPressed == ConsoleKey.DownArrow){
                    selectedIndex++;
                    if (selectedIndex == options.Length){
                        selectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return selectedIndex;
        }
        public void RouteEm(int selectedIndex){
            for (int i=0; i<options.Length;i++){
                if(selectedIndex==i){
                    actions[i]();
                }
                    
            } 
        }
    }
}