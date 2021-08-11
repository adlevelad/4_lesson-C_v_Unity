using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProjectOne
{
    public class BonusJump : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().YesBonusJump();
            }
            Destroy(gameObject);
        }
    }
}
