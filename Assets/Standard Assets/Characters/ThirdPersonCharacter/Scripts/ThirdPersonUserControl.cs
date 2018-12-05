using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

        //Called once upon object initialzation
        private void Start()
        {
            //TODO: initialize m_Character and m_Cam
            this.m_Cam = Camera.main.transform;
            this.m_Character = GetComponent<ThirdPersonCharacter>();
        }

        //Called once per frame
        private void Update()
        {
            //TODO: update m_Jump
            if (!this.m_Jump)
            {
                this.m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }

        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            //TODO: read inputs
            var h = CrossPlatformInputManager.GetAxis("Horizontal");
            var v = CrossPlatformInputManager.GetAxis("Vertical");

            //TODO: implement movement
            this.m_Move = h * transform.right + v * transform.forward;

            //TODO: uncomment when ready
            //pass all parameters to the character control script
            this.m_Character.Move(this.m_Move, false, this.m_Jump);
            this.m_Jump = false;
        }
    }
}
