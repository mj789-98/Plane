// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;
using ControlFreak2;

namespace ControlFreak2.Demos.Racing
{

public class GraphicsConfigScreen : GameState
	{
	public ControlFreak2.UI.LeftRightMenu 
		baseMenu;
		
	public CarDemoManager
		mainState;
		
	
	private int curSel;
		
		
	const int maxVal = (int)CarDemoManager.GraphicsQualityMax;

		
	// ------------------
	public GraphicsConfigScreen() : base()
		{
		}

	// -----------------
	private void OnMenuSwitch(int dir)
		{
		this.curSel = Mathf.Clamp(this.curSel + dir, 0, maxVal); //CFUtils.CycleInt(this.curSel, dir, maxVal);
		this.baseMenu.SetItemActive(this.curSel);			

		this.mainState.SetGraphicsQuality((CarDemoManager.GraphicsQuality)this.curSel);
		this.mainState.PlayChangeSound();
		}

	
	// -------------------
	private void OnMenuExit()
		{
		this.mainState.PlayCancelSound();
		this.parentState.EndSubState();
		}




	// -----------------
	protected override void OnStartState(GameState parentState)
		{
		base.OnStartState (parentState);
			
		this.gameObject.SetActive(true);

		this.baseMenu.SetTitle("Graphics");
		this.baseMenu.onOptionSwitch = this.OnMenuSwitch;
		this.baseMenu.onBackPressed = this.OnMenuExit;
			

		this.curSel = (int)this.mainState.GetGraphicsQuality();

		CFUtils.SetEventSystemSelectedObject(this.baseMenu.gameObject);

#if UNITY_EDITOR
		if (this.baseMenu.GetItemCount() != (maxVal + 1))
			Debug.LogError("Item count is wrong!!");
#endif			

		this.OnMenuSwitch(0);		
		}


	// ----------------
	protected override void OnExitState()
		{
		base.OnExitState ();
			
		this.gameObject.SetActive(false);

		// ...
		}
	}
}
