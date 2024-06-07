// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;
using ControlFreak2;

namespace ControlFreak2.Demos.Racing
{
public class CarInputRigAddOn : MonoBehaviour 
	{
	public InputRig 
		rig;
	public ControlMethod 
		controlMethod = ControlMethod.WHEEL_AUTO_ACCEL;
		
	const string
		SWITCH_WHEEL		= "Wheel",
		SWITCH_TILT			= "Tilt",
		SWITCH_DIGITAL		= "Digital",
		SWITCH_AUTO_ACCEL	= "Auto-Accel";

	// ---------------
	public enum ControlMethod
		{
		WHEEL_AUTO_ACCEL,
		WHEEL_MANUAL_ACCEL,

		TILT_AUTO_ACCEL,
		TILT_MANUAL_ACCEL,

		DIGITAL_STEERING
		}
		
	public const ControlMethod 
		ControlMethodMax = ControlMethod.DIGITAL_STEERING;		


	// --------------------
	void OnEnable()
		{
		if (this.rig == null)
			this.rig = this.GetComponent<InputRig>();

		if ((this.rig != null) && this.rig.CanBeUsed())
			this.SetControlMethod(this.controlMethod, true);
		}


	// -------------------
	public void SetControlMethod(ControlMethod m, bool skipAnim)
		{
		this.controlMethod = m;

		if (this.rig != null)	
			{
			bool
				wheelOn		= false,
				tiltOn		= false,
				digiOn		= false,	
				autoAccelOn = false;
				
			switch (m)
				{
				case ControlMethod.WHEEL_AUTO_ACCEL		: wheelOn = true; autoAccelOn = true; break;
				case ControlMethod.WHEEL_MANUAL_ACCEL	: wheelOn = true; break;
				case ControlMethod.TILT_AUTO_ACCEL		: tiltOn = true; autoAccelOn = true; break;
				case ControlMethod.TILT_MANUAL_ACCEL 	: tiltOn = true; break;
				case ControlMethod.DIGITAL_STEERING		: digiOn = true; break;
				}

			this.rig.SetSwitchState(SWITCH_WHEEL,		wheelOn);
			this.rig.SetSwitchState(SWITCH_TILT,		tiltOn);
			this.rig.SetSwitchState(SWITCH_DIGITAL,		digiOn);
			this.rig.SetSwitchState(SWITCH_AUTO_ACCEL,	autoAccelOn);

				
			if (skipAnim)
				this.rig.ApplySwitches(true);
			}
		}

	}
}
