using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Matrix;


namespace Markov
{
    public class State
    {
        private String stateName { get; set; }

        private Vector transitionVector { get; set; }

        private Vector cSum { get; set; }

        private static Random rand = new Random();

        public State(String name, Vector transition)
        {
            stateName = name;
            transitionVector = transition;
        }

        public State()
        {
            stateName = "Null";
            transitionVector = new Vector(3);
        }

        /// <summary>
        /// Adds a new weight to the transition vector.  Scales the old weights appropriately.
        /// </summary>
        /// <param name="newWeight"></param>
        public void AddTransition(Double newWeight)
        {
            transitionVector.Append(newWeight);
            Double sum = transitionVector.sum();
            for (int i = 0; i < transitionVector.Size; i++)
            {
                transitionVector[i] /= sum;
            }

            //Cumulative sum for finding weights
            Double cumulativeSum = 0.0;
            for (int i = 0; i < transitionVector.Size; i++)
            {
                cumulativeSum += transitionVector[i]*100;
                cSum.Append(cumulativeSum);
            }
        }

        /// <summary>
        /// Find the next state by weighted random.
        /// </summary>
        /// <returns></returns>
        public int Transistion()
        {
            Double r = rand.Next();
            int lowGuess = 0;
            int highGuess = transitionVector.Size - 1;

            int guess = 0;
            while (highGuess > lowGuess)
            {
                guess = (lowGuess + highGuess) / 2;
                if (cSum[guess] < r)
                    lowGuess = guess + 1;
                else if (cSum[guess] - transitionVector[guess] > r)
                    highGuess = guess - 1;
            }
            return guess;
        }

        public String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(stateName);
            sb.Append("\n");
            sb.Append(transitionVector.ToString());
            return sb.ToString();
        }
    }
}
