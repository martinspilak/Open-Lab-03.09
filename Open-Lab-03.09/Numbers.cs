using System;

namespace Open_Lab_03._09
{
    public class Numbers
    {
        public bool IsPrimeNumber(int num)
        {

           if(num < 2) return false;
           if (num == 2) return true;     
           for (int i = 2; i < num; i++)
                if(num % i == 0)return false; 
                return true;                                        
        }
    }
}
