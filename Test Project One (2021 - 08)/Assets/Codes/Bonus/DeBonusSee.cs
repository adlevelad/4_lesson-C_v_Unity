using System;
using System.Collections;
using System.Collections.Generic;
using TestProjectOne;
using UnityEngine;

namespace TestProjectOne
{
    public class DeBonusSee : PlayerBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                YesDeBonusSee();
            }
            Destroy(gameObject);
        }
    }
}