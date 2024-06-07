// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;
using UnityEngine.UI;

using ControlFreak2;
using ControlFreak2.UI;

namespace ControlFreak2.Demos.Racing
{

public class ControlConfigScreen : GameState 
	{
	public CarDemoManager
		mainState;

	public ControlFreak2.UI.LeftRightMenu 
		baseMenu;

		
	private int curSel;
		
		
	const int maxVal = (int)CarInputRigAddOn.ControlMethodMax;	// TODO!!

		
	// ------------------
	public ControlConfigScreen() : base()
		{
		}

	// -----------------
	private void OnMenuSwitch(int dir)
		{
		this.curSel = CFUtils.CycleInt(this.curSel, dir, maxVal);
		this.baseMenu.SetItemActive(this.curSel);	


		if (this.mainState != null)
			this.mainState.SetControlMethod((CarInputRigAddOn.ControlMethod) this.curSel);

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

		this.baseMenu.SetTitle("Controls");
		this.baseMenu.onOptionSwitch = this.OnMenuSwitch;
		this.baseMenu.onBackPressed = this.OnMenuExit;
			
		this.curSel = (int)this.mainState.GetControlMethod();

		this.OnMenuSwitch(0);
			
		CFUtils.SetEventSystemSelectedObject(this.baseMenu.gameObject);

#if UNITY_EDITOR
		if (this.baseMenu.GetItemCount() != (maxVal + 1))
			Debug.LogError("Item count is wrong!!");
#endif			
		}


	// ----------------
	protected override void OnExitState ()
		{
		base.OnExitState ();
			
		this.gameObject.SetActive(false);

		// ...
		}
	




	}
}
