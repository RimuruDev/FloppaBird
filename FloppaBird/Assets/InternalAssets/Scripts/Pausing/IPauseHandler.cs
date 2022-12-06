using System;

namespace Pausing
{
    public interface IPauseHandler
    {
        public void Pause();
        public void Resume();
    }
}
