using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestProjectOne
{
    public sealed class BadBonus : InteractiveObject, IFLay, IRotation
    {
        public event Action<string, Color> OnCaughtPlayerChange = delegate(string s, Color color) {  };
        private float _lenghtFlay;
        private float _speedRotation;

        private void Awake()
        {
            _lenghtFlay = Random.Range(1, 5);
            _speedRotation = Random.Range(10, 50);
        }

        protected override void Interaction()
        {
            // Destroy player
        }

        public void Flay()
        {
            var locPos = transform.localPosition;
            locPos = new Vector3(locPos.x, Mathf.PingPong(Time.time, _lenghtFlay), locPos.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}