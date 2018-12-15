using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace dachi.Models
{
    public class Dachi
    {
        public int Fullness { get; set; }

        public int Happiness { get; set; }

        public int Meals { get; set; }

        public int Energy { get; set; }

        public string Messages { get; set; }

        public Dachi()
        {
            Fullness = 20;
            Happiness = 20;
            Meals = 3;
            Energy = 50;
            Messages = "Say hello to your DojoDachi!";
        }
        Random random = new Random();
        public void Feed()
        {
            if (Meals < 1)
            {
                Messages = "You do not have any meals to feed your DojoDachi :(";
            }
            else
            {
                Meals -= 1;
                int cantfeed = random.Next(1, 5);
                if (cantfeed == 1)
                {
                    Messages = "Your DojoDachi does not like this food :(";
                }
                else
                {
                    int FullnessIncrease = random.Next(5, 11);
                    Fullness += FullnessIncrease;
                    Messages = "Your DojoDachi loves this food! Fullness increased by " + FullnessIncrease + ".";
                }
            }
        }
        public void Play()
        {
            if (Energy < 5)
            {
                Messages = "Your DojoDachi is too tired to play right now :(";
            }
            else
            {
                Energy -= 5;
                int cantplay = random.Next(1, 5);
                if (cantplay == 1)
                {
                    Messages = "Your DojoDachi isn't in the mood to play right now :(";
                }
                else
                {
                    int HappinessIncrease = random.Next(5, 11);
                    Happiness += HappinessIncrease;
                    Messages = "Your DojoDachi has so much fun! Happiness increased by " + HappinessIncrease + ".";
                }
            }
        }
        public void Work()
        {
            if (Energy < 5)
            {
                Messages = "Your DojoDachi is too exhausted to work right now :(";
            }
            else
            {
                Energy -= 5;
                int MealIncrease = random.Next(1, 4);
                Meals += MealIncrease;
                Messages = "Your DojoDachi worked hard and earned " + MealIncrease + " meals!";
            }
        }
        public void Sleep()
        {
            Fullness -= 5;
            Happiness -= 5;
            Energy += 15;
            int loss = 5;
            int gained = 15;
            Messages = "Your DojoDachi had a nice rest! " + gained + " Energy gained! Uh oh, your DojoDachi is hangry now! It has lost " + loss + " Fullness and Happiness!";
        }
    }
}