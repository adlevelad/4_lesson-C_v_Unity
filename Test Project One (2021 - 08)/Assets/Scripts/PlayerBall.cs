using System;
using System.Collections;
using System.Collections.Generic;
using TestProjectOne;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace TestProjectOne
{
    public class PlayerBall : Player
    {
        private void FixedUpdate()
        {
            Move();
        }
    }
}