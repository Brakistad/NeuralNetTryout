using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    class Equipment
    {
        String name;
        Action[] actions;
        double[] statMod;

        public Equipment(String name)
        {
            this.name = name;
            this.defineStatmod(name);
            this.defineActions(name);
        }

        private void defineStatmod(String name)
        {

        }

        private void defineActions(String name)
        {

        }
    }
}
