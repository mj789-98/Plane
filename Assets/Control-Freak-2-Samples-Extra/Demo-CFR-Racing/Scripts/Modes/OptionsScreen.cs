// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;

using ControlFreak2;

namespace ControlFreak2.Demos.Racing
{
public class OptionsScreen : GameState
	{
	public CarDemoManager
		mainState;	

	public GameObject
		optionsGUI;

	public GameObject 
		graphicsButton,
		controlButton,
		backButton;
	


	// ---------------
	public void ShowOptions(GameState parentState)
		{
		parentState.StartSubState(this);
		}
		
		
	// ----------------
	public void CloseOptionsScreen()			{ this.parentState.EndSubState(); }
	public void ShowGraphicsConfigScreen()		{ this.StartSubState(this.mainState.graphicsConfigScreen); }
	public void ShowControlConfigScreen()		{ this.StartSubState(this.mainState.controlConfigScreen);	}

		
	// -------------
	private void ShowOptionsGUI(bool show)
		{
		this.optionsGUI.SetActive(show);
		}

	// -------------
	protected override void OnStartState (GameState parentState)
		{
		base.OnStartState (parentState);
			
		this.gameObject.SetActive(true);

		this.ShowOptionsGUI(true);

		CFUtils.SetEventSystemSelectedObject(this.backButton);
		// ...
		}

	// --------------
	protected override void OnExitState ()
		{
		base.OnExitState();

		this.gameObject.SetActive(false);
			
		this.mainState.PlayCancelSound();

		// ...
		}

	// -----------------		
	protected override void OnPreSubStateStart (GameState prevState, GameState nextState)
		{
		this.ShowOptionsGUI(nextState == null);

		if (nextState == null)
			{
			CFUtils.SetEventSystemSelectedObject(
				(this.GetSubState() is GraphicsConfigScreen) ? this.graphicsButton :
				(this.GetSubState() is ControlConfigScreen) ? this.controlButton : this.backButton);
			}
		}

	// ------------	
	protected void CloseOptions()
		{
		this.parentState.EndSubState();
		}

	
	// -----------
	protected override void OnUpdateState ()
		{
		if (!this.IsSubStateRunning())
			{
			if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.Escape))
				{
				this.CloseOptions();
				return;
				}
			}

		base.OnUpdateState ();
		}

	}
}
