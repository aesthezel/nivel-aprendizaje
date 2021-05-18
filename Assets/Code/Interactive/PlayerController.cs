using UnityEngine;

public class PlayerController : MonoBehaviour
{
        private const float gravity_value = -9.18f;

        

        private CharacterController controller;
        private Vector3 velocity;
        private bool grounded;
        [SerializeField] private float speed = 3.0f;
        private float jumpForce = 1.0f;
        

        private void Awake()
        {
            controller = gameObject.GetComponent<CharacterController>();
        }

        void Update()
        {
            grounded = controller.isGrounded;
            if (grounded && velocity.y < 0)
            {
                velocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * speed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // if (Input.GetButtonDown("Jump") && groundedPlayer)
            // {
            //     velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            // }

            velocity.y += gravity_value * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
}
