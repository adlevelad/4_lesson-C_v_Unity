using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace TestProjectOne
{
    internal sealed class TestException : MonoBehaviour
    {
        // для проверки наличия префаба
        [SerializeField] private Transform _prefab;

        private void Start()
        {
            // делаем саму проверку наличия префаба, если его нет то программа упадет, в консоль уйдет сообщение
            // Назвается выкинуть эксцепшн, что бы проверить когда программа себя ведет не правильно
            // Делают для разных проверок, например когда инвентарь переполнен и вы в него кладете еще предмет
            if (_prefab == null)
            {
                throw new DataException("_prefab not found");
            }
            
            // конструкция для перехватывания эксцепшенов
            var t = 0; // что бы мы могли ниже съэмитировать исключение (деление на ноль невозможно)

            try
            {
                // тут описывается какоето действие, например:
                var i = 8 / t;
            }
            // catch может быть несколько
            catch (DataException e) when(t == 0) // сразу идут мелкие исключения
            {
                Debug.Log(e.Message);
            }
            catch (Exception e) // потом более крупные, Exception базовый класс для всех исключений
            {
                Debug.Log(e.Message);
            }

            finally
            {
                // здесь описываются обязательно какие либо действия не зависимо от того было или нет исключение
            }
        }
    }
}