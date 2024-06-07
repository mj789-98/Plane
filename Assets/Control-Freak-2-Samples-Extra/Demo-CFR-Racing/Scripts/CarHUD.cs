// -------------------------------------------
// Control Freak 2
// Copyright (C) 2013-2021 Dan's Game Tools
// http://DansGameTools.blogspot.com
// -------------------------------------------

using UnityEngine;

namespace ControlFreak2.Demos.Racing
{

public class CarHUD : MonoBehaviour 
	{
	public UnityEngine.UI.Text
		targetText;

	public UnityStandardAssets.Vehicles.Car.CarController
		sourceCar;

	private Rigidbody rb;


	// -------------------
	void Update()
		{
		if ((this.targetText == null) || (this.sourceCar == null) )
			return;

		if ((this.rb == null) || (this.rb.gameObject != this.sourceCar.gameObject))
			this.rb = this.sourceCar.GetComponent<Rigidbody>();


		float speedMetersPerSec = ((this.rb != null) ? this.rb.velocity.magnitude : 0);
		float speedKmph = (speedMetersPerSec * (3600.0f/1000.0f ));

		this.targetText.text = Mathf.RoundToInt(speedKmph).ToString() + " kmph";
		}
	}
}
