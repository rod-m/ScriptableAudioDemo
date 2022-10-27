using System;
using UnityEngine;

namespace SalfordGames
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        private Vector3 _playerVelocity;
        private bool _groundedPlayer;
        
        private float gravityValue = -9.81f;
        [SerializeField] public PlayerProps playerProps;
        private CharacterController _controller;
        
/*
 CharacterController Scripts adapted from:
 https://docs.unity3d.com/ScriptReference/CharacterController.html
 https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
 https://docs.unity3d.com/ScriptReference/CharacterController.OnControllerColliderHit.html
 */

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            _groundedPlayer = _controller.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _controller.Move(move * (Time.deltaTime * playerProps.maxSpeed));

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && _groundedPlayer)
            {
                Jump();
            }

            _playerVelocity.y += playerProps.gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
        }

        void Jump()
        {
            _playerVelocity.y += Mathf.Sqrt(playerProps.jumpHeight * -3.0f * gravityValue);
        }


        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody body = hit.collider.attachedRigidbody;

            // no rigidbody
            if (body == null || body.isKinematic)
            {
                return;
            }

            // We dont want to push objects below us
            if (hit.moveDirection.y < -0.3)
            {
                return;
            }

            // Calculate push direction from move direction,
            // we only push objects to the sides never up and down
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            // If you know how fast your character is trying to move,
            // then you can also multiply the push velocity by that.

            // Apply the push
            body.velocity = pushDir * playerProps.pushPower;
        }
        // generate 2d perlin noise
    }
}