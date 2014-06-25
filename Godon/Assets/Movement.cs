using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
		public float movementSpeed = 5.0f;
		public float mouseSensitivity = 5.0f;
		float verticalRotation = 0;
		public float upDownRange = 60.0f;
		float verticalVelocity = 0;
		public float jump = 5f;

		void Update ()
		{
				float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
				transform.Rotate (0, rotLeftRight, 0);
				verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
				verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
				Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);

				float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
				float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

				verticalVelocity += Physics.gravity.y*2 * Time.deltaTime;

				if (Input.GetButton ("Jump")) {
						verticalVelocity = jump;
				}
				Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);


				speed = transform.rotation * speed;
				CharacterController cc = GetComponent<CharacterController> ();
				cc.Move (speed * Time.deltaTime);
		}
	

	
	

}