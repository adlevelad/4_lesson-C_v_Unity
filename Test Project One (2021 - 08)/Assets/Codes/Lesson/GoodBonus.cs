using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestProjectOne
{
    public sealed class GoodBonus : InteractiveObject, IFLay, IFlicker
    {
        public int Point;
        public event Action<int> OnPointChange = delegate(int i) {  };
        private Material _material;
        private float _lengthFlay;

        private DisplayBonuses _displayBonuses;
        
        void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1, 5);
            //_displayBonuses = new DisplayBonuses();
        }

        protected override void Interaction()
        {
            //_displayBonuses.Display(5);
            // Add bonus
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1));
        }
    }
}