using UnityEngine;
using System.Collections;

/// PumaController
/// Manages puma state and activities

public class PumaController : MonoBehaviour
{
	//===================================
	//===================================
	//		MODULE VARIABLES
	//===================================
	//===================================

	private GameObject pumaObj;
	private int selectedPuma = -1;
	public float mainHeading;
	private float pumaX;
	private float pumaY;
	private float pumaZ;
	private float pumaHeading = 0f;
	private float pumaHeadingOffset = 0f;   			// NOTE: is currently changed from InputControls....probably shouldn't be
	private float pumaStalkingSpeed = 22f * 0.66f;
	private float pumaChasingSpeed = 32f * 0.66f;
	private float defaultPumaChasingSpeed = 32f * 0.66f;
	private float chaseTriggerDistance = 40f * 0.66f;
	private float defaultChaseTriggerDistance = 40f * 0.66f;
	private float deerCaughtFinalOffsetFactor0 = 1f * 0.66f;
	private float deerCaughtFinalOffsetFactor90 = 1f;

	// PUMA CHARACTERISTICS

	private float[] powerArray = new float[] {0.6f, 0.4f, 0.9f, 0.7f, 0.7f, 0.5f};
	private float[] speedArray = new float[] {0.90f, 0.80f, 0.55f, 0.45f, 0.20f, 0.10f};
	private float[] enduranceArray = new float[] {0.6f, 0.4f, 0.9f, 0.8f, 0.6f, 0.4f};
	private float[] stealthinessArray = new float[] {0.10f, 0.20f, 0.45f, 0.55f, 0.80f, 0.90f};
	
	// COLLISION DETECTION
		
	private GameObject collisionObject;
	private bool collisionOverpassInProgress = false;
	private float collisionCarForceTimeRemaining = 0;
	private float collisionCarForceOffsetX;
	private float collisionCarForceOffsetZ;
	public float forceFactor = 100f;
	
	// EXTERNAL MODULES
	private LevelManager levelManager;	
	
	//===================================
	//===================================
	//		INITIALIZATION
	//===================================
	//===================================

    void Start()
    {
		// connect to external modules
		levelManager = GameObject.Find("Scripts").GetComponent<LevelManager>();
	}
	
 	//===================================
	//===================================
	//		UPDATES
	//===================================
	//===================================

    void Update()
    {
    }

 	void FixedUpdate()
    {
		if (collisionCarForceTimeRemaining > 0f) {
			Vector3 forceVector = new Vector3(collisionCarForceOffsetX * Time.deltaTime, 0f, collisionCarForceOffsetZ * Time.deltaTime);
			//Debug.Log("=======    ===========   =======");
			//Debug.Log("Time.time: " + Time.time +  "   forceVector: " + forceVector);
			//Debug.Log("=======    ===========   =======");
			
			rigidbody.AddForce(forceVector);
			collisionCarForceTimeRemaining -= Time.deltaTime;
		}		
    }
    
	//===================================
	//===================================
	//		COLLISION LOGIC
	//===================================
	//===================================

	void OnCollisionEnter(Collision collisionInfo)
	{
		// VEHICLE

		if (collisionInfo.gameObject.tag == "Vehicle") {

			if (collisionOverpassInProgress == false &&
			(levelManager.gameState == "gameStateChasing" || 
			 levelManager.gameState == "gameStateStalking" || 
			 levelManager.gameState == "gameStateFeeding1" || 
			 levelManager.gameState == "gameStateFeeding2" || 
			 levelManager.gameState == "gameStateFeeding3" || 
			 levelManager.gameState == "gameStateFeeding4" || 
			 levelManager.gameState == "gameStateFeeding5" || 
			 levelManager.gameState == "gameStateDied1" || 
			 levelManager.gameState == "gameStateDied2" || 
			 levelManager.gameState == "gameStateDied3" || 
			 levelManager.gameState == "gameStateDied4")) {

				Debug.Log("======================================");
				Debug.Log("             VEHICLE HIT:  " + gameObject.name + " - " + collisionInfo.collider.name);
				Debug.Log("======================================");
				//Debug.Log("Collision normal is " + collisionInfo.contacts[0].normal);
				//Debug.Log("Collision relative velocity is " + collisionInfo.relativeVelocity);
				//Debug.Log("Time.time: " + Time.time);
					
				levelManager.BeginCarCollision();
				// create force to push puma off road (to right)
				float collisionScale = 75000f;
				float heading = collisionInfo.gameObject.GetComponent<VehicleController>().heading;
				heading += Random.Range(20f, 40f);
				collisionCarForceOffsetX = Mathf.Sin(heading*Mathf.PI/180) * collisionScale;
				collisionCarForceOffsetZ = Mathf.Cos(heading*Mathf.PI/180) * collisionScale;
				collisionCarForceTimeRemaining = 0.30f;
			}
		}
		
		// BRIDGE

		else if (collisionInfo.gameObject.tag == "Bridge") {

			Debug.Log("=====================================");
			Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
			
			float headingOffset;
			float barrierHeading;
			float normalHeading = levelManager.GetAngleFromOffset(0f, 0f, collisionInfo.contacts[0].normal.x, collisionInfo.contacts[0].normal.z);		
			float leftDirection = normalHeading + 90f;
			float rightDirection = normalHeading - 90f;			
			
			{
				// determine which direction to move along barrier
				float mainHeading = levelManager.mainHeading;
				float deltaToLeftDirection;
				float deltaToRightDirection;
				
				if (leftDirection > mainHeading) {
					mainHeading += 360f;
				}
				deltaToLeftDirection = mainHeading - leftDirection;
				if (deltaToLeftDirection > 180f) {
					leftDirection += 360f;
					deltaToLeftDirection = leftDirection - mainHeading;
				}
							
				if (rightDirection > mainHeading) {
					mainHeading += 360f;
				}
				deltaToRightDirection = mainHeading - rightDirection;
				if (deltaToRightDirection > 180f) {
					rightDirection += 360f;
					deltaToRightDirection = rightDirection - mainHeading;
				}
							
				if (deltaToLeftDirection > deltaToRightDirection) {
					// turn right
					headingOffset = 1f;
					barrierHeading = rightDirection;
				}
				else {
					// turn left
					headingOffset = -1f;
					barrierHeading = leftDirection;
				}
			}

			while (barrierHeading >= 360f)
				barrierHeading -= 360f;			
			while (barrierHeading < 0f)
				barrierHeading += 360f;
			
			levelManager.PumaBeginCollision(headingOffset, barrierHeading);
		}
		
		// OVERPASS

		else if (collisionInfo.gameObject.tag == "Overpass") {
			collisionOverpassInProgress = true;
			collisionObject = collisionInfo.gameObject;
			Debug.Log("=====================================");
			Debug.Log("COLLISION:  " + gameObject.name + " - " + collisionInfo.collider.name);
			return;
		}
	}


	void OnCollisionStay(Collision collisionInfo)

	{

	}


	void OnCollisionExit(Collision collisionInfo)

	{
		if (collisionInfo.gameObject.tag == "Bridge") {
			Debug.Log("=====================================");
			Debug.Log("Collision End:  " + gameObject.name + " - " + collisionInfo.collider.name);
			levelManager.PumaEndCollision();
		}

		else if (collisionInfo.gameObject.tag == "Overpass") {
			collisionOverpassInProgress = false;
			Debug.Log("=====================================");
			Debug.Log("Collision End:  " + gameObject.name + " - " + collisionInfo.collider.name);
			return;
		}
	}
	
	
	//===========================================
	//===========================================
	//	PUBLIC FUNCTIONS
	//===========================================
	//===========================================

	public float GetCollisionOverpassSurfaceHeight()
	{
		return collisionObject.transform.position.y + 0.48f;
	}
	
	public bool CheckCollisionOverpassInProgress()
	{
		return (collisionOverpassInProgress == true);
	}
	
	
	
	/*
	//=======================
	// Update Puma Position
	//=======================
	
	public void UpdatePumaPosition()
	{

		float distance = 0f;
		pumaHeading = mainHeading;
	
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftControl)) {
			// filter out the input when manual camera moves are in progress - DEV ONLY
		}		
		else if (gameState == "gameStateGui" || gameState == "gameStateLeavingGameplay" || gameState == "gameStateLeavingGui") {
			// process automatic puma walking during GUI state
			if ((gameState != "gameStateLeavingGui") || (Time.time - stateStartTime < 1.8f))
				pumaAnimator.SetBool("GuiMode", true);
			distance = guiFlybySpeed * Time.deltaTime  * 12f * speedOverdrive;
			pumaX += (Mathf.Sin(mainHeading*Mathf.PI/180) * distance);
			pumaZ += (Mathf.Cos(mainHeading*Mathf.PI/180) * distance);
		}	
		else if (gameState == "gameStateStalking") {	
			// main stalking state
			float rotationSpeed = 100f;
			distance = inputControls.GetInputVert() * Time.deltaTime  * pumaStalkingSpeed * speedOverdrive;
			mainHeading += inputControls.GetInputHorz() * Time.deltaTime * rotationSpeed;
			pumaHeading = mainHeading + pumaHeadingOffset;
			pumaX += (Mathf.Sin(pumaHeading*Mathf.PI/180) * distance);
			pumaZ += (Mathf.Cos(pumaHeading*Mathf.PI/180) * distance);
			scoringSystem.PumaHasWalked(selectedPuma, distance);
			if (scoringSystem.GetPumaHealth(selectedPuma) == 0f)
				SetGameState("gameStateDied1");			
		}
		else if (gameState == "gameStateChasing") {
			// main chasing state
			float rotationSpeed = 150f;
			distance = inputControls.GetInputVert() * Time.deltaTime  * pumaChasingSpeed * speedOverdrive;
			float travelledDistance = (scoringSystem.GetPumaHealth(selectedPuma) > 0.05f) ? distance : distance * (scoringSystem.GetPumaHealth(selectedPuma) / 0.05f);
			mainHeading += inputControls.GetInputHorz() * Time.deltaTime * rotationSpeed;
			pumaHeading = mainHeading + pumaHeadingOffset;
			pumaX += (Mathf.Sin(pumaHeading*Mathf.PI/180) * travelledDistance);
			pumaZ += (Mathf.Cos(pumaHeading*Mathf.PI/180) * travelledDistance);
			scoringSystem.PumaHasRun(selectedPuma, distance);
			if (scoringSystem.GetPumaHealth(selectedPuma) == 0f)
				SetGameState("gameStateDied1");			
		}
		
		else if (gameState == "gameStateFeeding1") {
			// puma and deer slide to a stop
			if (Time.time < stateStartTime + fadeTime) {
					float percentDone = 1f - ((Time.time - stateStartTime) / fadeTime);
				float pumaMoveDistance = 1f * Time.deltaTime * pumaChasingSpeed * percentDone * 1.1f;
				pumaX += (Mathf.Sin(deerCaughtmainHeading*Mathf.PI/180) * pumaMoveDistance);
				pumaZ += (Mathf.Cos(deerCaughtmainHeading*Mathf.PI/180) * pumaMoveDistance);
			}
		}
		
		pumaAnimator.SetBool("GuiMode", false);
		pumaAnimator.SetFloat("Distance", distance);
	}
	
	*/
}







