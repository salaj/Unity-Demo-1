using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets.Camera
{
    public class CameraControl : MonoBehaviour
    {
        float x = 0.0f;
        float y = 0.0f;
        public float rotationSpeed = 2f;

        private UnityEngine.Camera mainCamera;
        void Start()
        {
            this.mainCamera = UnityEngine.Camera.main;
        }

        //Called once per frame
        void Update()
        {
            //TODO: read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            this.x = CrossPlatformInputManager.GetAxis("Mouse X");
            this.y = -CrossPlatformInputManager.GetAxis("Mouse Y");
            Debug.Log("Mouse X: " + this.x + " Mouse Y: " + this.y);
            Debug.Log("Mouse X: " + CrossPlatformInputManager.GetAxis("Mouse X") + " Mouse Y: " + CrossPlatformInputManager.GetAxis("Mouse Y"));

            //TODO: implement movement
            //this.mainCamera.transform.Translate(h * Vector3.right + v * Vector3.forward, Space.Self);

            //TODO: implement camera rotation
            if (Input.GetMouseButton(0))
            {
                transform.eulerAngles += new Vector3(this.y, this.x, 0f) * this.rotationSpeed;
            }
        }
    }
}
