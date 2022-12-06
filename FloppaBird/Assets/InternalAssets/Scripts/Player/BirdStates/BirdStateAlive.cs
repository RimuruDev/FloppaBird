using CameraBehaviour.Extensions;
using System;
using UnityEngine;

namespace Player.BirdStates
{
    public class BirdStateAlive : BirdStateBase
    {
        private PlayerBird _bird;

        public override void Enter(PlayerBird bird)
        {
            _bird = bird;
        }
        public override void Exit(PlayerBird bird)
        {

        }
        public override void UpdateState()
        {
            controlInput();
        }

        private void controlInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _bird.FlyUp();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _bird.States.EnterState<BirdStateDead>();
        }
    }
}
