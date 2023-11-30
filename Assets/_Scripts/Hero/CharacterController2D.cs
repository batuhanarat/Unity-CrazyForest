
using System;
using System.Security.Cryptography;
using _Scripts.Events.EventChannels;
using UI.Audio;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private bool canSmash = false;
	private Transform heroTransform;
	private Vector3 lastCameraPosition;

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = false;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	[SerializeField] private AudioClip jump, crouch;
	public bool isAlive = true;

	[SerializeField]  private AudioSource audioSourceHero;

	[Header("Events")]
	[Space]
	public UnityEvent OnLandEvent;
	[SerializeField] private VoidEventChannelSO gameOverEvent;

	

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
		
		
		heroTransform = this.GetComponent<Transform>();
		

	}
	void Start()
	{
		isAlive = true;
	}

	public void PlayJumpSound()
	{
		//audioSource.clip = jump;
		audioSourceHero.PlayOneShot(jump,1f);
	}
	
	public void PlayCrouchSound()
	{
		audioSourceHero.clip = crouch;
		audioSourceHero.Play();
	}
	
	private void FixedUpdate()
	{
		
		
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}
	
	public void Move(float move, bool crouch, bool jump,bool chargedJump)
	{
		Debug.Log("isAlive" + isAlive);
		if (isAlive)
		{

			//only control the player if grounded or airControl is turned on
			if (m_Grounded || m_AirControl)
			{
				// If the player should jump...
				if (m_Grounded && jump)
				{
					m_Grounded = false;
					//m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
					Vector3 targetVelocity2 = new Vector2(m_Rigidbody2D.velocity.x, m_JumpForce);

					m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity2, ref m_Velocity,
						m_MovementSmoothing);

					PlayJumpSound();
					// Add a vertical force to the player.
				}

				// If crouching
				if (crouch)
				{
					PlayCrouchSound();
					m_Rigidbody2D.AddForce(new Vector2(0f, -(500)));


					// Reduce the speed by the crouchSpeed multiplier
					move *= m_CrouchSpeed;


				}

				// Move the character by finding the target velocity
				Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
				// And then smoothing it out and applying it to the character
				m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity,
					m_MovementSmoothing);

				// If the input is moving the player right and the player is facing left...
				if (move > 0 && !m_FacingRight)
				{
					// ... flip the player.
					Flip();
				}
				// Otherwise if the input is moving the player left and the player is facing right...
				else if (move < 0 && m_FacingRight)
				{
					// ... flip the player.
					Flip();
				}
			}
		}

	}
	
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void CheckPositionValid(Vector3 cameraPosition)
	{

		lastCameraPosition = cameraPosition;

	}

	public void Update()
	{
		if ((lastCameraPosition.y - 13) > m_Rigidbody2D.transform.position.y)
		{
			Debug.Log("MARİO SONG");
			isAlive = false;
			
			gameOverEvent.OnEventRaised();
		}
	}
		
	public bool isGrounded()
	{
		return m_Grounded;
	}

	
}