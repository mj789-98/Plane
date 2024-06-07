// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;

using ControlFreak2;


namespace ControlFreak2.Demos.Racing
{

public class PauseScreen : GameState
	{
	public CarDemoManager
		mainState;

	public Transform
		pauseModeUI;	

	public GameObject
		resumeButton,
		optionsButton;

		

	// --------------------
	public void ShowOptions()	{ this.mainState.PlaySelectSound(); this.mainState.optionsScreen.ShowOptions(this); }
	public void ResumeGame()	{ this.mainState.PlayCancelSound(); this.parentState.EndSubState(); }
	public void GoToMainMenu()	{ this.mainState.EnterTitleScreen(); }
	public void AskToRetire()	{ this.mainState.PlaySelectSound(); this.mainState.questionBox.ShowQuestionBox(this, "Are you sure?", "Yes", "No", this.GoToMainMenu, this.EndSubState); }


	// -------------------
	protected override void OnStartState(GameState parentState)
		{
		base.OnStartState(parentState);

		this.gameObject.SetActive(true);

		this.pauseModeUI.gameObject.SetActive(true);

		CFUtils.SetEventSystemSelectedObject(this.resumeButton);
		}
		
		
	// -------------------
	protected override void OnExitState()
		{
		base.OnExitState();

		this.pauseModeUI.gameObject.SetActive(false);

		this.gameObject.SetActive(false);
		}
				

	// -----------------
	protected override void OnPreSubStateStart (GameState prevState, GameState nextState)
		{
		this.pauseModeUI.gameObject.SetActive(nextState == null);

		if (nextState == null)
			{
			CFUtils.SetEventSystemSelectedObject((this.GetSubState() is OptionsScreen) ? this.optionsButton : this.resumeButton);
			}
		}
			


	}
}
