using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProjectOne
{
    public sealed class CameraController : MonoBehaviour
    {
        public Player Player;
        private Vector3 _offset;
        
        [SerializeField, Range(0, 50)] public float _speedRotation = 10.0f;
        
        void Start()
        {
            _offset = transform.position - Player.transform.position;
        }

        private void Update()
        {
            CameraMove();
        }

        private void LateUpdate()
        {
            transform.position = Player.transform.position + _offset;
        }

        private void CameraMove()
        {
            //_offset.x = Input.GetAxis("Horizontal");
            //_offset.z = Input.GetAxis("Vertical");

            //var speed = _offset * (_speedRotation * Time.deltaTime);
            //transform.Translate(speed);
            transform.Rotate(Vector3.up * (_speedRotation * Input.GetAxis("Mouse X") * Time.deltaTime)); // поворот камеры по оси X
            transform.Rotate(Vector3.left * (_speedRotation * Input.GetAxis("Mouse Y") * Time.deltaTime)); // поворот камеры по оси Y
        }
    }
}