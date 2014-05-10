using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	#region Declared Variables
	// public statics
	public static PlayerMovement Instance;				// Is the object that is accessed by other classes.
	// public members
	public ParticleSystem leftTreadSystem;
	public ParticleSystem rightTreadSystem;
	public bool  m_bStop = false;						// Controls whether the player should or shouldn't be moving
	// private members
				
	private float m_fmoveSpeed = 20.0f;					// Controls the players moving speed
	private float m_fturnSpeed = 50.0f;					// Controls the players rotating speed
	private float m_fHorizontal;						// Stores the horizontal input from the player
	private float m_fVertical;							// Stores the vertical input from the player 
	#endregion

	#region Getters/Setters Functions
	
	public bool GetPlayerStop()
	{
		if(m_bStop)										// Checks if the player is stopped
		{
			return true;								// Returns True if the player is not moving
		}
		else
		{
			return false;								// Returns False if the player is moving
		}
	}
	
	public void SetPlayerStop(bool newStop)
	{
		m_bStop = newStop;
	}
	
	#endregion
	
	#region Unity Pre Built Functions

	// Use this for creating Instances of objects in first loop
	void Awake () 
	{
		Instance = this;

	}
	
	// This function is called once each frame
	void Update()
	{
		if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)	// checks to see if any input is coming in
		{
			GetMovement();
			leftTreadSystem.gameObject.SetActive(true);
			rightTreadSystem.gameObject.SetActive(true);
		}
		else
		{
			leftTreadSystem.gameObject.SetActive(false);
			rightTreadSystem.gameObject.SetActive(false);
		}


	}
	

	
	#endregion	

	#region cPlayerMovement Functions

	public void GetMovement() 
	{
		m_fVertical = Input.GetAxis("Vertical");			// Takes player input(W, S, Up & Down Arrow and Gampad LeftStick) in increments each itiration				
		m_fHorizontal = Input.GetAxis("Horizontal");		// Takes player input(A, D, Left & Right Arrow and Gampad LeftStick) in increments each itiration
		
		if(!m_bStop)										// Checks to see if the player is moving or not
		{
			PlayerMotor(m_fVertical);				
			PlayerRotation(m_fHorizontal);
		}

	
			
	}
	
	// Player motor handles translating the vertical input to moving the character foward and backwards in 3D space
	private void PlayerMotor(float fVertical)
	{
		this.transform.Translate(Vector3.forward * fVertical * m_fmoveSpeed * Time.deltaTime);
	}

	// Plater rotation handles translating the horizontal input to rotating the chracter left and right in 3D space
	private void PlayerRotation(float fHorizontal)
	{
		this.transform.Rotate(Vector3.up * fHorizontal * m_fturnSpeed * Time.deltaTime);

	}

	#endregion
}
