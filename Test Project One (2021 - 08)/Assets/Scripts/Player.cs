using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProjectOne
{
    public class Player : MonoBehaviour
    {
        [SerializeField, Range(1, 50)] private float _strangeJump = 3.0f;
        [SerializeField, Range(1, 10)] private float _speedPlayer = 3;
        [SerializeField, Range(1, 50)] private float _sensitivity = 25;
        private Vector3 _vector3;
        private Rigidbody _rigidbody;
        private bool _isGround = true;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked; // блокируем курсор
        }

        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>(); // инициализируем компонент твердого тела для физики
        }

        protected void Move()
        {
            // проверка позиции плеера на поверхности
            RaycastHit hit;
            var rayCast = Physics.Raycast(transform.GetChild(0).position, Vector3.down, out hit, 8.5f);
            // if (rayCast)
            //     Debug.Log(hit.collider.gameObject.name);
            if (rayCast) _isGround = true;
            else _isGround = false;
            // прыжок (сила прыжка зависит от веса тела RigidBody и заданной силы прыжка)
            if (Input.GetKeyDown(KeyCode.Space) && _isGround) 
                _rigidbody.AddForce(transform.up * _strangeJump, ForceMode.Impulse);

            // управление клавишами и поворот камеры мышью
            _vector3.x = Input.GetAxis("Horizontal");
            _vector3.z = Input.GetAxis("Vertical");
            transform.Rotate(Vector3.up * (_sensitivity * Input.GetAxis("Mouse X") * Time.deltaTime));

            // реализиция передвижения персонажа с заданной скоростью
            var speed = _vector3 * (_speedPlayer * Time.deltaTime);
            transform.Translate(speed);
        }
    }
}