using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

	#region Variables, Constants & Initializers

	public GameObject pizza;
	#endregion


	public void SetPizza(GameObject pizza)
	{
		this.pizza = pizza;
	}

	public GameObject GetPizza()
	{
		return this.pizza;
	}
}
