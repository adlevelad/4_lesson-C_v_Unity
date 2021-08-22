using System;
using System.Collections;
using System.Collections.Generic;
using TestProjectOne;
using UnityEngine;

namespace TestProjectOne
{
    public class BonusSpeed : PlayerBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                YesBonusSpeed();
            }
            Destroy(gameObject);
        }
    }
}