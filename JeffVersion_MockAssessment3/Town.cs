using System;
using System.Collections.Generic;
using System.Text;

// Jeff said not to worry about abstract at first. You can add it later.

namespace JeffVersion_MockAssessment3
{
    class Town
    {
        public List<Villager> Villagers = new List<Villager>(); // The left side of this simply creates a variable called Villagers. The right side of the equals sign actually creates the list that the pointer variable can access.

        public Town()
        {
            Villagers.Add(new Farmer());
            Villagers.Add(new Slacker());
            Villagers.Add(new Slacker());
            Villagers.Add(new Slacker());
        }

        public int Harvest()
        {
            int total = 0;
            foreach (Villager person in Villagers)
            {
                total += person.Farm();
            }
            return total;
        }

        public int CalcFoodConsumpion()
        {
            int total = 0;
            foreach (Villager person in Villagers)
            {
                total += person.Hunger;
            }
            return total;
        }

        public bool SurviveTheWinter()
        {
            /*
            int h = Harvest();
            int f = CalcFoodConsumpion();

            if (f <= h)
            {
                return true;
            }
            else
            {
                return false;
            }
            */ // This was is not wrong, it's just a bit longer. Technically speaking we should always go by the specs. This is what the assessment asked for.

            if (CalcFoodConsumpion() <= Harvest())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
