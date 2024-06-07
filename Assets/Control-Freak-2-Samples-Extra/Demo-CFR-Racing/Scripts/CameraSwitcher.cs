// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;
using ControlFreak2;

namespace ControlFreak2.Demos.Racing
{
public class CameraSwitcher : MonoBehaviour 
	{
	public Camera[] cameras;
	public Camera	rearViewMirrorCam;

	public bool dontSwitchWhenPaused = true;

	public KeyCode	switchKey = KeyCode.None;
	public string switchButton = "";
	private int switchButtonId = 0;

	public KeyCode	mirrorKey = KeyCode.None;
	public string mirrorButton = "";
	private int mirrorButtonId = 0;
		
	[System.NonSerializedAttribute]
	private Camera
		curCam;
	



	// -------------------
	void Start()
		{
		this.SwitchCamera(true);
		}

	// -------------------
	void Update()
		{
		if (this.dontSwitchWhenPaused && (Time.timeScale < 0.0001f))
			return;

		bool mirrorKeyPressed = ((this.rearViewMirrorCam != null) && ((this.mirrorKey != KeyCode.None) && CF2Input.GetKey(this.mirrorKey)) ||
			(!string.IsNullOrEmpty(this.mirrorButton) && CF2Input.GetButton(this.mirrorButton, ref this.mirrorButtonId)));


		if (mirrorKeyPressed)
			{
			if (!this.rearViewMirrorCam.enabled)
				this.rearViewMirrorCam.enabled = true;

			if ((this.curCam != null) && (this.curCam.enabled))
				this.curCam.enabled = false;
			}

		else
			{
			if (((this.switchKey != KeyCode.None) && CF2Input.GetKeyDown(this.switchKey)) ||	
				((this.switchButton.Length > 0) && CF2Input.GetButtonDown(this.switchButton, ref this.switchButtonId)))
				this.SwitchCamera();

			else if ((this.curCam == null) || !this.curCam.enabled)
				{
				this.SwitchCamera(true);
				}
			}
		}	


	// ----------------	
	private bool IsCameraListed(Camera cam)
		{
		if (cam == null)
			return false;

		return (System.Array.IndexOf(this.cameras, cam) >= 0);
		}
		


	// ------------------
	public void SwitchCamera(bool dontSwitch = false)
		{

		int curCam = -1;
			
		int firstCam = -1;
		int nextCam = -1;
		
		if ((this.rearViewMirrorCam != null) && (this.rearViewMirrorCam.enabled))
			this.rearViewMirrorCam.enabled = false;


		for (int i = 0; i < this.cameras.Length; ++i)
			{
			Camera cam = this.cameras[i];
			if (cam == null)
				continue;

			if (firstCam == -1)
				firstCam = i;
				
			if ((curCam != -1) && (nextCam == -1))
				nextCam = i;
 
			if ((cam.enabled && (curCam == -1)) || (this.curCam == cam))
				{
				curCam = i;
				nextCam = -1;
				}
			}

		if ((firstCam < 0) && (nextCam < 0))
			return;
			
		if (!dontSwitch)
			{
			if (nextCam >= 0)
				curCam = nextCam;
			else
				curCam = firstCam;
			}
			
		for (int i = 0; i < this.cameras.Length; ++i)
			{
			if (this.cameras[i] == null)
				continue;

			if (i == curCam)
				{
				this.curCam = this.cameras[i];
				this.curCam.enabled = true;
				}
			else
				this.cameras[i].enabled = false;
			}		
		}
	
	}
}
