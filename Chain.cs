using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpe.Matrix;

namespace Markov
{
    public class Chain
    {
        private List<State> chain = new List<State>();

        public State CurrentState;

        /// <summary>
        /// Adds a new State to the chain and weights all existing states to it.
        /// </summary>
        /// <param name="NewState">A new state to add in, must have</param>
        /// <param name="weights">The weights of every other state pointing to this one.</param>
        /// <param name="AutoWeight">TODO: Automatically calculate weights based on data.</param>
        public void Insert(State NewState, Vector weights, bool AutoWeight=false)
        {
            //We're entering weights manually
            if (AutoWeight == false)
            {
                ////Check to make sure we have proper amount of weights for this chain
                if (weights.Size != chain.Count + 1)
                {
                    throw new Exception("Wrong number of transition weights when adding a new state.");
                }
                //Copy over weights to each state
                for (int i = 0; i < chain.Count; i++)
                {
                    chain[i].AddTransition(weights[i]);
                }
            }

            chain.Add(NewState);
            CurrentState = NewState;
        }

        /// <summary>
        /// Transistions the chain to the next available state.
        /// </summary>
        public State Next()
        {
            CurrentState = chain[CurrentState.Transistion()];

            return CurrentState;
        }

        public String ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < chain.Count; i++)
            {
                sb.Append(chain[i].ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
