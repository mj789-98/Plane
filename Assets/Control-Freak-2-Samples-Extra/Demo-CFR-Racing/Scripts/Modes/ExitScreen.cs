// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;

using ControlFreak2;

namespace ControlFreak2.Demos.Racing
{
public class ExitScreen : ControlFreak2.GameState
	{	
	public CarDemoManager
		mainState;

	public GameObject
		exitButton;


	// ----------------	
	public void OpenAssetStoreUrl()
		{ 
		this.mainState.PlaySelectSound(); 
		UnityEngine.Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/content/11562"); 
		}
		
	public void OpenWebsiteUrlAndExit()
		{
		this.mainState.PlaySelectSound(); 
		UnityEngine.Application.OpenURL("http://dansgametools.com"); 
		}

	// --------------------
	protected override void OnStartState (GameState parentState)
		{
		base.OnStartState (parentState);
		this.gameObject.SetActive(true);

		CFUtils.SetEventSystemSelectedObject(this.exitButton);
		}
	

	// --------------------
	override protected void OnExitState()
		{
		base.OnExitState();
		this.gameObject.SetActive(false);
		}

	// ------------------
	override protected void OnUpdateState()
		{
		if (Input.GetKeyDown(KeyCode.Escape))
			{
			this.EndState();
			return;
			}

		base.OnUpdateState();
		}
	}
}
