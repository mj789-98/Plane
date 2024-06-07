// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;

using ControlFreak2;

namespace ControlFreak2.Demos.Racing
{
public class QuestionBox : ControlFreak2.GameState
	{	
	public CarDemoManager
		mainState;
		
	public GameObject 
		defaultButton;

	public UnityEngine.UI.Button
		yesButton,
		noButton;
	public UnityEngine.UI.Text
		yesText,
		noText,
		questionText;
		
	protected System.Action
		onYes,
		onNo;



	// ------------------
	public void ShowQuestionBox(GameState parent, string msg, string yesMsg, string noMsg, 
		System.Action onYes, System.Action onNo)
		{
		if (parent == null)
			return;

		if (this.questionText != null)
			this.questionText.text = msg;
	
		if (this.yesText != null)
			this.yesText.text = yesMsg;
	
		if (this.noText != null)
			this.noText.text = noMsg;

		this.onNo = onNo;
		this.onYes = onYes;


		parent.StartSubState(this);		
		}

	// --------------------
	protected override void OnStartState (GameState parentState)
		{
		base.OnStartState (parentState);
		this.gameObject.SetActive(true);

		if (this.yesButton != null)
			this.yesButton.onClick.AddListener(this.OnYesClicked);

		if (this.noButton != null)
			this.noButton.onClick.AddListener(this.OnNoClicked);
			

		CFUtils.SetEventSystemSelectedObject(this.defaultButton);

		}
	

	// --------------------
	override protected void OnExitState()
		{
		base.OnExitState();
		this.gameObject.SetActive(false);

		if (this.yesButton != null)
			this.yesButton.onClick.RemoveListener(this.OnYesClicked);

		if (this.noButton != null)
			this.noButton.onClick.RemoveListener(this.OnNoClicked);
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

	// ------------------
	private void OnYesClicked()
		{	
		this.mainState.PlaySelectSound();

		if (this.onYes != null)
			this.onYes();
		}

	// ------------------
	private void OnNoClicked()
		{	
		this.mainState.PlaySelectSound();

		if (this.onNo != null)
			this.onNo();
		}

	}
}
