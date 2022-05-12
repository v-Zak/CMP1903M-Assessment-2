using System;

namespace CMP1903_Assessment_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ask if debug mode
            if(true)//Input.askBool("Debug Mode?"))
            {
                Test testManager = new Test();
                testManager.runTests();
            }
            else
            {
                // create Manager object and call play
                Game gameManager = new Game();
                gameManager.play();
            }
            
        }
    }
}