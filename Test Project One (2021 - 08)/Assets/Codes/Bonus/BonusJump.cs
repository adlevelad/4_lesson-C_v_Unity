using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProjectOne
{
    public class BonusJump : PlayerBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                YesBonusJump();
            }
            Destroy(gameObject);
        }
    }
}
