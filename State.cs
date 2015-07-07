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
        }

        public int Transistion()
        {
            Double r = rand.Next();



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
