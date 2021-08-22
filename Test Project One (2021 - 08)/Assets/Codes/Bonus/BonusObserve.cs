using System;
using System.Collections;
using System.Collections.Generic;
using TestProjectOne;
using UnityEngine;
using UnityEngine.UI;

namespace TestProjectOne
{
    public class BonusObserve : PlayerBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerBase>().YesBonusObserve();
            }
            Destroy(gameObject);
        }
    }
}