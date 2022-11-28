using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_Systems
{
    internal class Enviroment
    {
        public List<Entity> entities = new List<Entity>();

        private string name = "Bracken Bat Cave Ecosystem";

        public string Name { get => name; set => name = value; }
        

        public int day = 1;


        public string GetAllEntityINFO()
        {
            string output = "";
            foreach (var item in entities)
            {
                output += $"{item.Name} {item.Amount}\n";

            }

            return output;
        }

        public void TimePasses()
        {
            day++;
            int numberofBats = EntityAmount("Bat");
            int numberofHawks = EntityAmount("Hawk");
            int numberofBugs = EntityAmount("Corn earworm") + EntityAmount("Cotton Bollworm");
            Random random = new Random();

            if (numberofHawks > 0)
            {
                if (random.Next(1, 10) == 4)
                {
                    //loss of Bats
                    ChangeEntityAmount("Bat",-1);
                }
            }
            
            numberofBats = EntityAmount("Bat");

            int bugsNeeded = numberofBats * random.Next(500, 1000);
            int halfBugsNeeded = bugsNeeded / 2;
            if (numberofBugs >= bugsNeeded)
            {
                ChangeEntityAmount("Corn earworm", -halfBugsNeeded);
                ChangeEntityAmount("Cotton Bollworm", -halfBugsNeeded);
                if (EntityAmount("Corn earworm") < 0)
                {
                    SetAmountZero("Corn earworm");
                }

                if (EntityAmount("Cotton Bollworm") < 0)
                {
                    SetAmountZero("Cotton Bollworm");
                }
            }
            else
            {
                ChangeEntityAmount("Bat", -1);
            }
        }

        private int EntityAmount(string name)
        {
            foreach (var item in entities)
            {
                if (item.Name == name)
                {
                    return item.Amount;
                }
            }
            return 0;
        }

        private void ChangeEntityAmount(string name, int amount)
        {
            foreach (var item in entities)
            {
                if (item.Name == name)
                {
                    item.Amount += amount;
                }
            }
            
        }

        private void SetAmountZero(string name)
        {
            foreach (var item in entities)
            {
                if (item.Name == name)
                {
                    item.Amount = 0;
                }
            }

        }


    }
}
