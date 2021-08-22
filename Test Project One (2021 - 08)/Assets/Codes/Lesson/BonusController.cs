using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProjectOne
{
    public sealed class BonusController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        }

        private void Update()
        {
            for (int i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null) continue;
                if (interactiveObject is IFLay fLay) fLay.Flay();
                if (interactiveObject is IFlicker flicker) flicker.Flicker();
                if (interactiveObject is IRotation rotation) rotation.Rotation();
                
            }
        }
    }
}