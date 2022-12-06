using System;
using UnityEngine;

namespace Player.BirdStates
{
    public abstract class BirdStateBase : MonoBehaviour
    {
        public abstract void Enter(PlayerBird bird);
        public abstract void Exit(PlayerBird bird);
        public abstract void UpdateState();
    }
}
