using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace MyCarGame.Car
{
    [RequireComponent(typeof(my_CarController2))]
    public class my_CarUserController : MonoBehaviour
    {
        private my_CarController2 m_Car;

        private void Awake()
        {
            m_Car = GetComponent<my_CarController2>();
        }

        private void FixedUpdate()
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            //Debug.Log(h + ":" + v);
            m_Car.Move(h, v);
        }
    }
}

