using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProjectOne
{
    public class Player : MonoBehaviour
    {
        private float _strange = 3.0f;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked; // блокируем курсор
        }

        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            if (Input.GetKeyDown(KeyCode.Space)) _rigidbody.AddForce(transform.up * _strange, ForceMode.Impulse); // прыгать

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            _rigidbody.AddForce(movement * _strange);
            
        }
    }
}