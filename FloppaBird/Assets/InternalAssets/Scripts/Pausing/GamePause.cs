using System;
using System.Collections.Generic;
using UnityEngine;
 
namespace Pausing
{
    public class GamePause : MonoBehaviour
    {
        private List<IPauseHandler> _handlers = new List<IPauseHandler>();

        public void Pause()
        {
            foreach (IPauseHandler handler in _handlers)
            {
                handler.Pause();
            }
        }
        public void Resume()
        {
            foreach (IPauseHandler handler in _handlers)
            {
                handler.Resume();
            }
        }

        public void Register(IPauseHandler self)
        {
            _handlers.Add(self);
        }
        public void UnRegister(IPauseHandler self)
        {
            if (!_handlers.Remove(self))
                throw new ArgumentException($"Can't unregister IPauseHander");
        }
    }
}
