using System;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

[RequireComponent(typeof (NewCarController))]
public class NewCarUserControl : MonoBehaviour
    {
        public XRKnob wheel;
        public XRJoystick joystick;
        private NewCarController m_Car;

   

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<NewCarController>();
        }


        private void FixedUpdate()
        {
        // pass the input to the car!
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        float h;

        if (wheel.value > 0)
        {
            h = Mathf.Lerp(-1, 1, wheel.value);
        }
        else
        {
            h = 0; 
        }
        float v = joystick.value.y;

#if !MOBILE_INPUT
        float handbrake = Input.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
            
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }

