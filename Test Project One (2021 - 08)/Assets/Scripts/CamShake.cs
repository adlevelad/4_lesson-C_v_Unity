using System;
using System.Collections;
using System.Collections.Generic;
using TestProjectOne;
using UnityEngine;
using static TestProjectOne.EventsTest;

namespace TestProjectOne
{
    public sealed class CamShake : MonoBehaviour
    {
        public Animator camShake;

        private void Start()
        {
            ActivCamShake += Shake;
            ActivCamZoom += Zoom;
        }

        private void Shake()
        {
            camShake.SetTrigger("Shake");
        }

        private void Zoom()
        {
            camShake.SetTrigger("Zoom");
        }

        public void Dispose()
        {
            foreach (var bonuses in (GameObject.FindGameObjectsWithTag("GoodBonus")))
            {
                if (bonuses is null)
                {
                    ActivCamShake -= Shake;
                    ActivCamZoom -= Zoom;
                }
            }
            
            foreach (var bonuses in (GameObject.FindGameObjectsWithTag("BadBonus")))
            {
                if (bonuses is null)
                {
                    ActivCamShake -= Shake;
                    ActivCamZoom -= Zoom;
                }
            }
        }
    }
}