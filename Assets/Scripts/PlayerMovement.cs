using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float sideForce = 10f;
	[SerializeField] private float accelerationSideForce = 10f;
	private float playerVelocity = 5f;
	void FixedUpdate()
	{
		rb.velocity = new Vector3(playerVelocity * GameManager.Instance.GetPlayerSpeedMultiplier(), rb.velocity.y, rb.velocity.z);
		PlayerInput();
	}
	private void PlayerInput()
	{
		Vector3 input;
		if (InputManager.GetInputType() == InputManager.InputType.TOUCH)
		{
			if (Input.touchCount == 0) return;
			if (Input.GetTouch(0).position.x <= Screen.width / 2)
				input = new Vector3(0, 0, sideForce * Time.fixedDeltaTime);
			else
				input = new Vector3(0, 0, -sideForce * Time.fixedDeltaTime);
		}
		else
		{
			Vector3 tilt = Input.acceleration;
			tilt = Quaternion.Euler(90, 0, 0) * tilt;
			input = new Vector3(0, 0, -tilt.x * accelerationSideForce * Time.fixedDeltaTime);
		}
		rb.AddForce(input, ForceMode.VelocityChange);
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (!collision.collider.CompareTag("Obstacle")) return;
		GameManager.Instance.PlayerDead();
	}
}