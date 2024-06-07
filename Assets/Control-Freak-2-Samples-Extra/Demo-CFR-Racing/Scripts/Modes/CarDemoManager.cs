// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;
using ControlFreak2;

namespace ControlFreak2.Demos.Racing
{

public class CarDemoManager : GameState
	{
	public TitleScreen
		titleScreen;
	public SingleRaceMode
		singleRaceMode;
	public OptionsScreen
		optionsScreen;

	public ControlConfigScreen 
		controlConfigScreen;
	public GraphicsConfigScreen
		graphicsConfigScreen;

	public QuestionBox
		questionBox;

	public ExitScreen
		exitScreen;

	public AudioSource
		menuSfxAudio;

	public AudioClip
		soundSelect,
		soundCancel,
		soundChange; 	
	

		

	// -------------------
	public enum GraphicsQuality
		{
		Low,
		Medium,
		High
		}

	public const GraphicsQuality 
		GraphicsQualityMax = GraphicsQuality.High;
 

		

	// --------------------
	private CarInputRigAddOn.ControlMethod
		controlMethod;

	private System.Action
		onControlMethodChange;
		

	// -------------------
	private GraphicsQuality
		graphicsQuality;



	// ----------------
	void Start()
		{
		this.controlMethod = CarInputRigAddOn.ControlMethod.WHEEL_MANUAL_ACCEL;
		this.graphicsQuality = GraphicsQuality.High;

		this.SetGraphicsQuality(this.graphicsQuality);

		this.EnterTitleScreen();
		}
	
	// -----------------
	void Update()			{ this.OnUpdateState(); }
	void FixedUpdate()		{ this.OnFixedUpdateState(); }
	//void OnGUI()			{ this.OnDrawStateGUI(); }		

		

	// -------------------
	protected override void OnPostSubStateStart(GameState prevState, GameState nextState)
		{
		if (nextState == null)
			this.ExitGame();
		}


		
	// ---------------
	private void ExitGame()
		{
		this.OnExitState();
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		}

	// ------------------
	public void EnterTitleScreen()		{ this.StartSubState(this.titleScreen); }

	// ----------------	
	public void EnterSingleRaceMode()	{ this.StartSubState(this.singleRaceMode);	}

	// ------------------
	public void EnterExitScreen()		{ this.StartSubState(this.exitScreen); }


	// ------------------
	public CarInputRigAddOn.ControlMethod GetControlMethod()		
		{ return this.controlMethod; }
	
	// ---------------
	public void SetControlMethod(CarInputRigAddOn.ControlMethod m)
		{
		this.controlMethod = m;

		if (this.onControlMethodChange != null)
			this.onControlMethodChange();
		}


	// -----------------
	public void SetControlMethodChangeCallback(System.Action a)	
		{ this.onControlMethodChange = a; }

	// -----------------
	public void RemoveControlMethodChangeCallback(System.Action a)	
		{ 
		if (this.onControlMethodChange == a) 
			this.onControlMethodChange = null; 
		}


		
	// ------------------
	public GraphicsQuality GetGraphicsQuality()		
		{ return this.graphicsQuality; }
	
	// ---------------
	public void SetGraphicsQuality(GraphicsQuality q)
		{
		this.graphicsQuality = q;

		switch (q)
			{
			case GraphicsQuality.High :
				QualitySettings.SetQualityLevel(QualitySettings.names.Length - 1);
				Shader.globalMaximumLOD		= System.Int16.MaxValue;
				break;

			case GraphicsQuality.Medium :
				QualitySettings.SetQualityLevel(0);
				Shader.globalMaximumLOD		= 150;
				break;

			case GraphicsQuality.Low :
				QualitySettings.SetQualityLevel(0);
				Shader.globalMaximumLOD		= 150;
				break;
			}
	
		// Hide background objects...

		this.HideBackgroundObjects((q == GraphicsQuality.Low));	
	
		this.SetTerrainDetail(q);
		}
		
		
		
	

	public GameObject[] bgObjectsToHide;

	// -------------------
	private void HideBackgroundObjects(bool hide)
		{
		if (this.bgObjectsToHide == null)
			return;

		for (int i = 0; i < this.bgObjectsToHide.Length; ++i)
			{
			GameObject o = this.bgObjectsToHide[i];
			if (o == null)
				continue;

			o.SetActive(!hide);
			}
		
		}


	// --------------------
	public Terrain[] bgTerrains;

	private void SetTerrainDetail(GraphicsQuality q)
		{
		for (int i = 0; i < this.bgTerrains.Length; ++i)
			{
			Terrain t = this.bgTerrains[i];
			if (t == null)
				continue;

			t.drawTreesAndFoliage	= (q > GraphicsQuality.Low);
			t.detailObjectDensity	= ((q == GraphicsQuality.High) ? 1 : (q == GraphicsQuality.Medium) ? 0.5f : 0);
			t.castShadows			= (q == GraphicsQuality.High);
			t.heightmapMaximumLOD	= (q == GraphicsQuality.High) ? 0 : (q == GraphicsQuality.Medium) ? 1 : 2;
			t.treeMaximumFullLODCount	= (q == GraphicsQuality.High) ? 200 : (q == GraphicsQuality.Medium) ? 20 : 0;
			t.treeDistance				= (q == GraphicsQuality.High) ? 700 : (q == GraphicsQuality.Medium) ? 200 : 0;
			}
		}



	// -----------------
	public void PlayMenuSound(AudioClip cl)
		{	
		if ((cl == null) || (this.menuSfxAudio == null))
			return;

		this.menuSfxAudio.ignoreListenerVolume = true;
		this.menuSfxAudio.ignoreListenerPause = true;
		this.menuSfxAudio.clip = cl;
		this.menuSfxAudio.loop = false;
		this.menuSfxAudio.Play();
		}
		

	// -------------------
	public void PlaySelectSound()	{ this.PlayMenuSound(this.soundSelect); }
	public void PlayCancelSound()	{ this.PlayMenuSound(this.soundCancel); }
	public void PlayChangeSound()	{ this.PlayMenuSound(this.soundChange); }
	
	

	}
}
