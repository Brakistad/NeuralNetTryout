using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    class Action
    {
        String defencive;
        String agressive;
        String act;
        double damage;
        double resist;
        public static int maxAmount = 4;

        public Action(String attack, String defend)
        {
            this.agressive = attack;
            this.defencive = defend;


        }
        public void ActIt(String type)
        {
            switch(type)
            {
                case "defend":
                {
                        switch (this.act)
                        {
                            case "bash":
                                {
                                    break;

                                }
                            case "cut":
                                {
                                    break;

                                }
                            case "parry":
                                {
                                    break;

                                }
                            case "block":
                                {
                                    break;

                                }
                            default:
                                {
                                    break;
                                }
                        }
                        break;

                }
                case "attack":
                {
                        switch (this.act)
                        {
                            case "bash":
                                {
                                    break;

                                }
                            case "cut":
                                {
                                    break;

                                }
                            case "parry":
                                {
                                    break;

                                }
                            case "block":
                                {
                                    break;

                                }
                            default:
                                {
                                    break;
                                }
                        }
                        break;

                }
                default:
                {
                        break;
                }
            }
        }
        public void Bash()
        {

        }
        public void Cut()
        {

        }
        public void Parry()
        {

        }
        public void Block()
        {

        }

        public double Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        public double Resist
        {
            get { return this.resist; }
            set { this.resist = value; }
        }

        public String Act
        {
            get { return this.act; }
            set { this.act = value; }
        }

    }
}
