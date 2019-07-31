using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {

            int lostGame = int.Parse(Console.ReadLine());
            double headsetPrise = double.Parse(Console.ReadLine());
            double mousePrise = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetTrash = 0;
            int mouseTrash = 0;
            int keyboardTrash = 0;
            int displayTrash = 0;

            int counterMouse = 1;
            int counterDisplay = 0;

            bool isMouse = false;
            bool isHeadset = false;

            for (int i = 1; i <= lostGame; i++)
            {
                if (i % 2 == 0)
                {
                    headsetTrash++;
                    isHeadset = true;
                }

                if (counterMouse == 3)
                {
                    mouseTrash++;
                    isMouse = true;
                    counterMouse = 0;
                }

                if (isHeadset && isMouse)
                {
                    keyboardTrash++;
                    counterDisplay++;
                }

                if (counterDisplay == 2)
                {
                    displayTrash++;
                    counterDisplay = 0;
                }

                counterMouse++;
                isMouse = false;
                isHeadset = false;
            }

            double totalHeadset = headsetTrash * headsetPrise;
            double totalMouse = mouseTrash * mousePrise;
            double totalKeyboard = keyboardTrash * keyboardPrice;
            double totalDisplay = displayTrash * displayPrice;

            double totalSum = totalHeadset + totalKeyboard + totalMouse + totalDisplay;

            Console.WriteLine($"Rage expenses: {totalSum:f2} lv.");
        }
    }
}
