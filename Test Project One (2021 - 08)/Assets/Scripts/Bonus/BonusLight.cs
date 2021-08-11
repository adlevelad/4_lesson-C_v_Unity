using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProjectOne
{
    public class BonusLight : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().YesBonusLight();
            }
            Destroy(gameObject);
        }
    }
}
