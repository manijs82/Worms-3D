using System;

namespace Worms
{
    public class Countdown
    {
        public event Action OnEnd;
        
        private readonly float time;
        private float currentTime;
        private bool started;

        public bool IsTicking => started;
        public float CurrentTime
        {
            get
            {
                if (started)
                    return currentTime;
                return 0;
            }
        }

        public Countdown(float time)
        {
            this.time = time;
        }

        public void Tick(float interval)
        {
            if (!started) return;
            
            currentTime -= interval;
            if(currentTime <= 0)
                Stop();
        }

        public void Start()
        {
            currentTime = time;
            started = true;
        }
        
        public void Pause()
        {
            started = false;
        }
        
        public void Resume()
        {
            started = true;
        }
        
        public void Stop()
        {
            started = false;
            OnEnd?.Invoke();
        }
    }
}