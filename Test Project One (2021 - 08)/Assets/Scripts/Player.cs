using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestProjectOne
{
    public class Player : MonoBehaviour
    {
        [SerializeField, Range(1, 100)] private float _strangeJump = 25.0f;
        private float _startStrangeJump = 25.0f;
        [SerializeField, Range(1, 15)] protected internal float _speedPlayer = 5;
        protected internal float _startSpeedPlayer = 5.0f;
        private Light _light;
        [SerializeField, Range(1, 50)] private float _sensitivity = 25;
        private Vector3 _vector3;
        private Rigidbody _rigidbody;
        private bool _isGround = true;
        private bool _revers;
        private float _lenghtFlay;
        private float _lenghtObserve;
        private Material _allMaterial;
        private Material _material;
        private Material _thisMaterial;
        private readonly Color _color = Color.clear;//Color.HSVToRGB(1,0,0);

        private Transform _playerPosition;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked; // блокируем курсор
            _lenghtFlay = Random.Range(4, 5);
            _lenghtObserve = Random.Range(10, 15);
        }

        public void Start()
        {
            _light = GetComponent<Light>(); // инициализируем компонент освещения 
            _rigidbody = GetComponent<Rigidbody>(); // инициализируем компонент твердого тела для физики
            _material = GetComponent<Renderer>().material;
            _thisMaterial = new Material(_material);
            _allMaterial = GetComponent<Material>();
            _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
            var plPos = _playerPosition.position;
        }

        protected void Move()
        {
            // проверка позиции плеера на поверхности (через выпускаемый луч вниз)
            RaycastHit hit;
            var rayCast = Physics.Raycast(transform.GetChild(0).position, Vector3.down, out hit, 8.5f);
            // if (rayCast)
            //     Debug.Log(hit.collider.gameObject.name);
            if (rayCast) _isGround = true;
            else _isGround = false;
            // прыжок (сила прыжка зависит от веса тела RigidBody и заданной силы прыжка)
            if (Input.GetKeyDown(KeyCode.Space) && _isGround) 
                _rigidbody.AddForce(transform.up * _strangeJump, ForceMode.Impulse);
           
            // управление клавишами (revers для дебафа)
            if (_revers == false)
            {
                _vector3.x = Input.GetAxis("Horizontal");
                _vector3.z = Input.GetAxis("Vertical");
            }
            else
            {
                _vector3.z = Input.GetAxis("Horizontal");
                _vector3.x = Input.GetAxis("Vertical");
            }
            
            // поворот камеры мышью
            if (_revers == false)
            {
                transform.Rotate(Vector3.up * (_sensitivity * Input.GetAxis("Mouse X") * Time.deltaTime));
            }
            else
            {
                transform.Rotate(Vector3.up * (_sensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime));
            }

            // реализиция движения персонажа с заданной скоростью
            var speed = _vector3 * (_speedPlayer * Time.deltaTime);
            transform.Translate(speed);
        }
        
        // методы бонусов и антибонусов
        protected internal void YesBonusSpeed()
        {
            _speedPlayer = 10;
            Invoke("NoBonusSpeed", 15f);
        }
        
        private void NoBonusSpeed()
        {
            _speedPlayer = _startSpeedPlayer;
        }

        protected internal void YesBonusJump()
        {
            _strangeJump = 100.0f;
            Invoke("NoBonusJump", 15f);
        }

        private void NoBonusJump()
        {
            _strangeJump = _startStrangeJump;
        }

        protected internal void YesBonusLight()
        {
            _light.type = LightType.Point;
            _light.color = Color.cyan;
            _light.intensity = 10.0f;
            Invoke("NoBonusLight", 15);
        }

        private void NoBonusLight()
        {
            _light.type = LightType.Spot;
            _light.color = Color.yellow;
            _light.intensity = 3.0f;
        }
        
        protected internal void YesDeBonusSlow()
        {
            _speedPlayer = 1;
            Invoke("NoBonusSpeed", 15f);
        }
        
        private void NoDeBonusSlow()
        {
            _speedPlayer = _startSpeedPlayer;
        }

        protected internal void YesDeBonusRevers()
        {
            _revers = true;
            Invoke("NoDeBonusRevers", 15.0f);
        }
        
        protected internal void NoDeBonusRevers()
        {
            _revers = false;
        }
        
        public void YesBonusFlay()
        {
            _rigidbody.useGravity = false;
            var locPos = transform.localPosition;
            locPos = new Vector3(locPos.x, Mathf.PingPong(Time.time, _lenghtFlay), locPos.z);
            transform.localPosition = locPos;
            Invoke("NoBonusFlay", 5.0f);
        }
        
        public void NoBonusFlay()
        {
            _rigidbody.useGravity = true;
            var locPos = transform.localPosition;
            locPos = new Vector3(locPos.x, locPos.y, locPos.z);
            transform.localPosition = locPos;
        }
        
        public void YesBonusObserve()
        {
            _speedPlayer = 3;
            _rigidbody.useGravity = false;
            var locPos = transform.localPosition;
            locPos = new Vector3(locPos.x, Mathf.PingPong(Time.time, _lenghtObserve), locPos.z);
            transform.localPosition = locPos;
            Invoke("NoBonusObserve", 15.0f);
        }
        
        public void NoBonusObserve()
        {
            _speedPlayer = _startSpeedPlayer;
            _rigidbody.useGravity = true;
            var locPos = transform.localPosition;
            locPos = new Vector3(locPos.x, locPos.y, locPos.z);
            transform.localPosition = _vector3;
        }

        
        public void YesDeBonusReturn()
        {
            transform.localPosition = _vector3;
        }
        
        public void YesDeBonusSee()
        {
            _material.color = new Color(_color.r, _color.g, _color.b);
            //_material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1));
            
            //_material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1));
            Invoke("NoDeBonusSee", 15.0f);
        }
        
        public void NoDeBonusSee()
        {
            _material.color = new Color( _thisMaterial.color.r, _thisMaterial.color.g, _thisMaterial.color.b);
        }

    }
}