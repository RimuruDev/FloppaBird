using System;
using UnityEngine;

namespace Player.BirdStates
{
    public class BirdStateDead : BirdStateBase
    {
        public override void Enter(PlayerBird bird)
        {
            bird.Die();
        }
        public override void Exit(PlayerBird bird)
        {

        }
        public override void UpdateState()
        {

        }
    }
}
