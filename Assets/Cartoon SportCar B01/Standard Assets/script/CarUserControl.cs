using System;
using UnityEngine;
// using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        private int input;
        BackwardButton BackButton;
        ForwardButton ForwardButton;


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private  void Start(){
            BackButton=GameObject.Find("Backward").GetComponent<BackwardButton>();
            ForwardButton=GameObject.Find("Forward").GetComponent<ForwardButton>();

            BackwardButton.instance.SetPlayer(this.gameObject);
            ForwardButton.instance.SetPlayer(this.gameObject);

        }

        float handbrake;
        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = SimpleInput.GetAxis("Horizontal");
            float v = SimpleInput.GetAxis("Vertical");
// #if !MOBILE_INPUT
//             float handbrake = CrossPlatformInputManager.GetAxis("Jump");

            if(Input.GetKey(KeyCode.Space)){
                handbrake=1;

            }
            else{
                handbrake=0;
            }

            m_Car.Move(h, input, input, handbrake);
// #else
//             m_Car.Move(h, v, v, 0f);
// #endif
        }
        public void Forward(){
            input=1;

        }
        public void Backward(){
            input=-1;
        }
        public void PointerUP(){
            input=0;
        }
    }
}
