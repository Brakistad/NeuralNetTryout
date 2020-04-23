using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    class Character
    {
        double health;
        double speed;
        double strength;
        Brain brain;
        List<Equipment> equipments;

        public Character()
        {
            Random random = new Random();
            this.speed = ((double)random.Next(0, 100))/100.0;
            this.strength = 1 - this.speed;
            this.health = 1000;

            brain = new Brain();
        }
        public void Equip(Equipment equipment)
        {
            equipments.Add(equipment);
        }
        /* on hold until further development
        public Action respond(Action action, Character opponent)
        {
            double[] inputElements = {0.0, 0.0, 0.0, 0.0, 0.0, 0.0};
            switch (action.Act)
            {
                case "bash":
                    {
                        inputElements[0] = 1;
                        break;

                    }
                case "cut":
                    {
                        inputElements[1] = 1;
                        break;

                    }
                case "parry":
                    {
                        inputElements[2] = 1;
                        break;

                    }
                case "block":
                    {
                        inputElements[3] = 1;
                        break;

                    }
                default:
                    break;
            }
            inputElements[4] = (((this.Speed - opponent.Speed)-1.0)/(2.0))+1.0;
            inputElements[5] = (((this.Strength - opponent.Strength) - 1.0)/(2.0))+1.0;

            return this.brain.Think(inputElements, equipments);

        }*/

        public void takeConsecuence(Action action)
        {
            this.health -= action.Damage;
        }

        public double Health
        {
            get { return this.health; }
            set { this.health = value; }
        }
        public double Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }
        public double Strength
        {
            get { return this.strength; }
            set { this.strength = value; }
        }
    }
}
