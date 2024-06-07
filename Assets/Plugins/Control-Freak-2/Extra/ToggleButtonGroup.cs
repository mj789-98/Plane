using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControlFreak2
{
public class ToggleButtonGroup : MonoBehaviour
	{
	public TouchButton[] groupButtons = new TouchButton[0];

	// ----------------
	public void ActivateButton(TouchButton activeButton)
		{
		for (int i = 0; i < this.groupButtons.Length; ++i)
			{
			var b = this.groupButtons[i];
			if (!b) continue;

			bool isActive = (b == activeButton);
	
			if (b.Toggled() != isActive)
				b.ChangeToggleState(isActive, true);
			}
		}


	// -------------
	private void OnEnable()
		{
		this.ActivateButton(null);		// Untoggle all on startup
		}

	// ----------------
	private void Update()
		{
		// If one of the buttons was just toggled by the player, untoggle the rest...

		for (int i = 0; i < this.groupButtons.Length; ++i)
			{
			var b = this.groupButtons[i];
			if (b && b.JustToggled())
				this.ActivateButton(b);
			}
		}
	}
}
