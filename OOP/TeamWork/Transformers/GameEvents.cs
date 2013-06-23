using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers
{
    public class GameEvents
    {
        public event EventHandler GameFinished;

        public event EventHandler GameInitialized;

        public void EventOnGameFinished()
        {
            this.OnGameFinished();
        }

        public void EventOnGameInitialized()
        {
            this.OnGameInitialized();
        }

        protected void OnGameFinished()
        {
            if ((this.GameFinished != null) && (Transformers.Check == true))
            {
                this.GameFinished(this, new EventArgs());
            }
        }

        protected void OnGameInitialized()
        {
            if (Transformers.CurrentProblem != null)
            {
                this.GameInitialized(this, new EventArgs());
            }
        }
    }
}