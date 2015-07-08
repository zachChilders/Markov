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

        private Vector cSum = new Vector(1);

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
            Double sum = transitionVector.Sum();
            for (int i = 0; i < transitionVector.Size; i++)
            {
                if (sum > 1.0)
                    transitionVector[i] = transitionVector[i] / sum;
            }

            cSum = new Vector(0);
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
            Double r = rand.NextDouble() * 100;
            for (int i = 0; i < cSum.Size; i++)
            {
                if (cSum[i] > r)
                    return i;
            }
            return 0;
        }

        public String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(stateName);
            sb.Append("\n");
            //sb.Append(transitionVector.ToString());
            return sb.ToString();
        }
    }
}
