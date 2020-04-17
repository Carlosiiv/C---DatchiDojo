using System;


namespace DatchiDojo.Models
{
    public class Datchi
    {
        public int Happiness {get;set;}
        public int Fullness {get;set;}
        public int Energy {get;set;}
        public int Meals {get;set;}
        public string Image { get;set; }

        public string Message {get;set;} //Plan is to display the appropriate message of the Datchi object through the Controller, setting it through the various functions.

        public Datchi()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            Message = "Welcome to DinoDatchi.";
            Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-31-57.gif";
        }

        public void Feed()
        {
            if (Meals == 0)
            {
                Fullness -=5;
                Message = "Can't eat anything if there isn't any food!";
                Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-30-43.gif";
            }
            else
            {
                Random fail = new Random();
                int Pass = fail.Next(1,4);
                if(Pass != 1)
                {
                    Meals-=1;
                    Random r = new Random();
                    int tempfull = 5+(r.Next(0,5));
                    Fullness += tempfull;
                    Message = $"Datchi gained {tempfull} points of Fullness";
                    Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-34-34.gif";
                }
                else{
                    Meals-=1;
                    Message = "Datchi didn't like you cooking.";
                    Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-38-86.gif";
                }
            }

        }

        public void Work()
        {   
            if(Energy <= 4)
            {
                Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-35-4.gif";
                Message = "Too tired to work! Let me sleep!";
            }
            else
            {
                Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-35-87.gif";
                Energy -= 5;
                Random rand = new Random();
                int tempmeal = rand.Next(1,3);
                Meals += tempmeal;
                Message = $"Earned {tempmeal} meals!";
            }
            //Working costs 5 energy and earns between 1 and 3 meals
           
        }

        public void Play()
        {
            //Playing with your Dojodachi costs 5 energy and gains a random amount of happiness between 5 and 10
            if(Energy > 5)
            {
                Random fail = new Random();
                int Pass = fail.Next(1,4);
                if(Pass != 1){
                    // if 25% failure rate fails
                    Energy -= 5;
                    Random r = new Random();
                    int addHappiness = r.Next(5,10);
                    Happiness += addHappiness;
                    Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-36-50.gif";
                    Message = $"Datchi liked playing and gained {addHappiness} points of happiness";
                }else{
                    // if 25% failure rate passes
                    Energy -= 5;
                    Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-30-43.gif";
                    Message = $"Datchi didn't like playing and gained no happiness";
                }
            } else{
                Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-28-96.gif";
                Message = "Datchi doesn't have enough energy to play.";
            }
        }

        public void Sleep()
        {   
            if (Fullness <=4 || Happiness <=4)
            {
                Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-32-35.gif";
                Message = "Too much to do to sleep!";
            }
            else
            {
                Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-39-99.gif";
                Energy += 15;
                Fullness -= 5;
                Happiness -= 5;
                Message = "Datchi takes a nice nap.";
            }
            //Sleeping earns 15 energy and decreases fullness and happiness each by 5
            
        }
    }

}