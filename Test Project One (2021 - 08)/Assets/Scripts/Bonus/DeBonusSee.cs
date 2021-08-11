using System;
using System.Collections;
using System.Collections.Generic;
using TestProjectOne;
using UnityEngine;

namespace TestProjectOne
{
    public class DeBonusSee : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().YesDeBonusSee();
            }
            Destroy(gameObject);
        }
    }
}