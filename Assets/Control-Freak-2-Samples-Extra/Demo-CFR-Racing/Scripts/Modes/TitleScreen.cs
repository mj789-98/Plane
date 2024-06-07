// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;
using ControlFreak2;

namespace ControlFreak2.Demos.Racing
{
public class TitleScreen : GameState
	{
		
	public CarDemoManager
		mainState;

	public GameObject
		titleGUI;

	public GameObject
		singleRaceButton,
		optionsButton,
		exitButton;
	
		
	public Camera 
		flybyCam;
		

	// ----------------
	private void ShowTitleGUI(bool show)
		{
		this.titleGUI.SetActive(show);
		}

	// -----------------
	protected override void OnStartState (GameState parentState)
		{
		base.OnStartState(parentState);
			
		this.gameObject.SetActive(true);
			
			
		// Hide the exit button in web player...
			
		//if (this.exitButton != null)
		//	this.exitButton.SetActive(!Application.isWebPlayer);


	
		this.ShowTitleGUI(true);

		CFUtils.SetEventSystemSelectedObject(this.singleRaceButton);


		// ...
		}

	// -----------------
	protected override void OnExitState ()
		{
		base.OnExitState ();
			
		this.gameObject.SetActive(false);

		// ...
		}
		
	// ------------------
	protected override void OnPreSubStateStart (GameState prevState, GameState nextState)
		{
		this.ShowTitleGUI(nextState == null);
			

		// Init menu selection...

		if (nextState == null) 
			{
			CFUtils.SetEventSystemSelectedObject((this.GetSubState().GetType() == typeof(OptionsScreen)) ? this.optionsButton : this.singleRaceButton);
			}
		}
		

	// --------------------
	public void OpenSingleRaceMode() { this.mainState.PlaySelectSound(); this.mainState.EnterSingleRaceMode(); }
	public void OpenOptionsScreen() { this.mainState.PlaySelectSound(); this.mainState.optionsScreen.ShowOptions(this); }
	public void OpenExitConfirmation()	{ this.mainState.PlaySelectSound(); this.mainState.questionBox.ShowQuestionBox(this, "Exit?", "Yes", "No", this.OpenExitScreen, this.EndSubState); }
	public void OpenExitScreen() { this.mainState.PlayCancelSound(); this.mainState.EnterExitScreen(); }


	}
}
