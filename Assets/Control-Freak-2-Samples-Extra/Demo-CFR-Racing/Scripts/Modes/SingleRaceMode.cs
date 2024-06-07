// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;
using ControlFreak2;
using UnityStandardAssets.Vehicles.Car;

namespace ControlFreak2.Demos.Racing
{

public class SingleRaceMode : GameState
	{
	public CarDemoManager
		mainState;
		
	public ControlFreak2.InputRig 
		carInputRig;
	public CarInputRigAddOn
		carInputRigAddOn;
	
	public CarHUD
		carHUD;


	public PauseScreen
		pauseScreen;

	public CameraSwitcher 
		carRigPerfab;

	private GameObject
		carRigInstance;
		
	private CarController
		carController;
	private CameraSwitcher
		carCamSwitcher;
		

	public Transform 
		carStartingLocation;
		

		


	// -----------------------
	protected void MoveCarToStartingPosition()
		{

		this.carController.transform.position = this.carStartingLocation.position;
		this.carController.transform.rotation = this.carStartingLocation.rotation;
			
		Rigidbody rb = this.carController.GetComponent<Rigidbody>();

		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		}

	// -------------------
	protected override void OnStartState (GameState parentState)
		{
		base.OnStartState (parentState);

		this.gameObject.SetActive(true);

		this.carRigInstance = GameObject.Instantiate<CameraSwitcher>(this.carRigPerfab).gameObject;
		this.carCamSwitcher = this.carRigInstance.GetComponent<CameraSwitcher>();
		this.carController	= this.carRigInstance.GetComponentInChildren<CarController>();
			
		this.carCamSwitcher.SwitchCamera(true);
			

		// Init Input rig...

		this.carInputRig.gameObject.SetActive(true);
		this.carInputRig.ResetState();
		this.carInputRig.ShowOrHideTouchControls(true, true);	
		ControlFreak2.CF2Input.activeRig = this.carInputRig;
			
		this.mainState.SetControlMethodChangeCallback(this.OnControlMethodChange);
			
		this.SyncControlMethod(true);


		if (this.carHUD != null)
			this.carHUD.sourceCar = this.carController;

		this.OnPauseGameplay(false);

		this.MoveCarToStartingPosition();
		}


	// ------------


	// -------------------
	protected override void OnExitState ()
		{
		base.OnExitState ();

		this.gameObject.SetActive(false);

		// Disable car input rig...

		this.carInputRig.gameObject.SetActive(false);
			
		this.mainState.RemoveControlMethodChangeCallback(this.OnControlMethodChange);

			
		AudioListener.pause = false;
		Time.timeScale = 1;

		Destroy(this.carRigInstance);
		this.carRigInstance = null;
		}


	// ---------------------
	override protected void OnUpdateState()
		{
		if (!this.IsSubStateRunning())
			{
			if (ControlFreak2.CF2Input.GetButtonDown("Pause"))
				{
				this.StartSubState(this.pauseScreen);
				return;
				}
			}

		base.OnUpdateState();
		}

	// ----------------
	protected override void OnPreSubStateStart (GameState prevState, GameState nextState)
		{
		this.OnPauseGameplay(nextState != null);
		}

	// -------------------
	private void OnPauseGameplay(bool pauseGameplay)
		{
		Time.timeScale = (!pauseGameplay ? 1.0f : 0);
		AudioListener.pause = pauseGameplay;

		this.carInputRig.ShowOrHideTouchControls(!pauseGameplay, false);

		ControlFreak2.CF2Input.ResetInputAxes();

		}

	// ------------------
	private void SyncControlMethod(bool skipAnim)
		{
		if (this.mainState == null)
			return;
	
		var m = this.mainState.GetControlMethod();
		
		this.carInputRigAddOn.SetControlMethod(m, skipAnim);


		}

	// ----------------
	private void OnControlMethodChange()
		{
		this.SyncControlMethod(false);
		}
	}
}
