using System;
using System.Collections.Generic;
using System.Text;

namespace JeffVersion_MockAssessment3
{
    abstract class Villager
    {
        public int Hunger;

        /* public virtual int Farm() // When you have an abstract class, any methods inside of it will never get called. This is why we used the override for Farmer and Slacker.
        {
            return 0;
        } */

        public abstract int Farm(); // The difference between this and the above is that here the abstract means that Farmer/Slacker MUST override Farm() from Villager.
                                    // In the example above, they don't technically need to override Farm() from Villager with public virtual int (keyword: VIRTUAL).
    }
}
