using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
//using Notionhub;

public class PizzaDecorationView : MonoBehaviour {
	#region Variables, Constants & Initializers
	private bool pizzaSauceFlag = true;
	private bool SauceSoundFlag = true;
	private int itemDragCounter = 0;
	public GameObject BBQAndVeggieItems;
	public GameObject FishAndVeggieItems;
	public GameObject PepperoniAndChilliItems;
	public GameObject BaconLoversItems;
	public GameObject PrimoMeatItems;
	public GameObject CreateYourOwnItems;
	public GameObject BeefAndVeggieItems;
	public GameObject LobsterSauceItems;
	public GameObject PizzaDecorationItems;
	public GameObject DestroyColliders;
	public GameObject PizzaStopImage;
	public GameObject PizzaScreen;
	public Image FlavourPizzaScreen;
	public Sprite[] pizzaMenuBooks;
	public GameObject menuBookButton;
	public GameObject Next;

	//BBQ And Veggie Scene Started
	public GameObject pizzaItem;
	public GameObject pizzaTray;
	public Image pizzaSauce;
	public Sprite [] flavourPizzaSauces;
	public GameObject MeatPlate;
	public GameObject BBQTomatoPlate;
	public GameObject BBQOnionPlate;
	public GameObject BBQCorainderPlate;
	public RectTransform [] trayPositions;
	public RectTransform PlateStartPoint, PlateEndPoint;
	public RectTransform SauceStartPoint, SauceEndPoint;

	//Fish And Veggie Scene Started
	public GameObject FishMeatPlate;
	public GameObject FishTomatoPlate;
	public GameObject FishOnionPlate;
	public GameObject FishCapsicumPlate;
	public GameObject FishOlivesPlate;

	//Pepperoni Chilli Scene Started
	public GameObject PepperoniMeatPlate;
	public GameObject PepperoniCapsicumPlate;
	public GameObject PepperoniOnionPlate;
	public GameObject PepperoniChilliPlate;
	public GameObject PepperoniPizzaSauce;

	//Bacon Lovers Scene Started
	public GameObject BaconLoverMeatPlate;
	public GameObject BaconLoverTomatoPlate;
	public GameObject BaconLoverMushroomPlate;
	public GameObject BaconLoverMintPlate;
	public GameObject BaconLoverCherryPlate;

	//Primo Scene Started
	public GameObject PrimoMeatPlate;
	public GameObject PrimoCapsicumPlate;
	public GameObject PrimoSpanishPlate;
	public GameObject PrimoOlivePlate;
	public GameObject PrimoOrangePlate;

	//Create Your Own Scene Started
	public GameObject CreateMeatPlate;
	public GameObject CreateCapsicumPlate;
	public GameObject CreateOnionPlate;
	public GameObject CreateCornPlate;
	public GameObject CreatePizzaSauce;

	//Beef And Veggie Scene Started
	public GameObject BeefMeatPlate;
	public GameObject BeefTomatoPlate;
	public GameObject BeefCarrotPlate;
	public GameObject BeefHerbPlate;

	//Lobster Sauce Scene Started
	public GameObject LobsterMeatPlate;
	public GameObject LobsterCapsicumPlate;
	public GameObject LobsterMushroomPlate;
	public GameObject LobsterChilliPlate;
	public GameObject LobsterStrawberryPlate;
	public GameObject LobsterPizzaSauce;


	public GameObject NextButton;
	public GameObject goodJobScreen;
	public GameObject GoodJobText;
	public RectTransform GoodJobTextEndPoint;
	public GameObject LoadinBg;
	public Image LoadingFilled;
	public GameObject firework;

	// Use this for initialization
	#endregion

	#region Lifecycle Methods
	void Start () {
		ShowAd ();
		GameManager.instance.currentScene = GameUtils.PIZZADECORATIONVIEW;
		Invoke ("SetViewContents", 0.1f);
        if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            menuBookButton.SetActive(false);
        } else
		{
            menuBookButton.SetActive(true);
        }

	}

	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region Utility Methods

	private void SetViewContents(){
		//GameManager.instance.SelectedPizzaFlavour = 3;
		WhichPizzaDecorated(GameManager.instance.SelectedPizzaFlavour);
		FlavourPizzaScreen.sprite = pizzaMenuBooks[GameManager.instance.SelectedPizzaFlavour];
	}

	private void ShowAd(){
        //AdsSDKManager ads = GameObject.FindObjectOfType<AdsSDKManager>();
        //if (ads != null)
        //{
        //    ads.ShowAdd();
        //}
    }

	private void ScaleAction(GameObject obj,float scaleval,float time,iTween.EaseType type,iTween.LoopType loopType) {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("scale", new Vector3 (scaleval,scaleval, 0));
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", type);
		tweenParams.Add ("looptype", loopType);
		iTween.ScaleTo(obj, tweenParams);
	}

	private void MoveAction(GameObject obj,RectTransform pos,float time,iTween.EaseType actionType,iTween.LoopType loopType){
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("x", pos.position.x);
		tweenParams.Add ("y", pos.position.y);
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", actionType);
		tweenParams.Add ("looptype", loopType);
		iTween.MoveTo (obj, tweenParams);
	}

	private void RotateAction(GameObject obj,float roatationamount,float t,iTween.EaseType actionType,iTween.LoopType loopType){
		Hashtable tweenParams = new Hashtable ();
		tweenParams.Add ("z", roatationamount);
		tweenParams.Add ("time", t);
		tweenParams.Add ("easetype", actionType);
		tweenParams.Add ("looptype", loopType);
		iTween.RotateTo (obj, tweenParams);
	}

	private void RotateAction360(GameObject obj,float roatationamount,float t,iTween.EaseType actionType,iTween.LoopType loopType){
		Hashtable tweenParams = new Hashtable ();
		tweenParams.Add ("z", roatationamount);
		tweenParams.Add ("time", t);
		tweenParams.Add ("easetype", actionType);
		tweenParams.Add ("looptype", loopType);
		iTween.RotateBy (obj, tweenParams);
	}

	private void colorIncreases(Image img, float val){
		if (img.color.a < 1) {
			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a + val);
		} 
	}

	private void colorDecreases(Image img , float value){
		if (img.color.a > 0) {
			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a - value);
		}
	}
		
	private void WhichPizzaDecorated(int tag){
		switch (tag) {
		case 0:   //BBQ & Veggie
			BBQAndVegieSceneStarted();
			break;

		case 1:     //Fish & Veggie
			FishAndVegieSceneStarted();
			break;

		case 2:     //Pepperoni & Chilli
			PepperoniAndChilliSceneStarted();
			break;


		case 3:   //Bacon Lovers
			BaconLoversSceneStarted();
			break;

		case 4:    //Primo Meats
			PrimoMeatsSceneStarted();
			break;


		case 5: //Create Your Own
			CreateYourOwnSceneStarted();
			break;

		case 6: //Beef & Veggie
			BeefAndVeggieSceneStarted();
			break;


		case 7: //Lobster Sauce
			LobsterSauceSceneStarted();
			break;


            case 8: //Multiplayer
                MultiplayerPizzaSceneStarted();
                break;

        }

	}

	//BBQ And Veggie Scene Started
	private void BBQAndVegieSceneStarted(){
		SoundManager.instance.PlaySwooshSound ();
		BBQAndVeggieItems.SetActive (true);
		MeatPlate.SetActive (true);
		MoveAction (MeatPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void BBQTomatoPlateComes(){
		itemDragCounter = 0;
		SoundManager.instance.PlaySwooshSound ();
		BBQTomatoPlate.SetActive (true);
		MoveAction (BBQTomatoPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	private void BBQOnionPlateComes(){
		itemDragCounter = 0;
		SoundManager.instance.PlaySwooshSound ();
		BBQOnionPlate.SetActive (true);
		MoveAction (BBQOnionPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	private void BBQCorainderPlateComes(){
		itemDragCounter = 0;
		SoundManager.instance.PlaySwooshSound ();
		BBQCorainderPlate.SetActive (true);
		MoveAction (BBQCorainderPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	//Fish And Veggie Scene Started
	private void FishAndVegieSceneStarted(){
		FishAndVeggieItems.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		FishMeatPlate.SetActive (true);
		MoveAction (FishMeatPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void FishTomatoPlateComes(){
		itemDragCounter = 0;
		SoundManager.instance.PlaySwooshSound ();
		FishTomatoPlate.SetActive (true);
		MoveAction (FishTomatoPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	private void FishOnionPlateComes(){
		itemDragCounter = 0;
		SoundManager.instance.PlaySwooshSound ();
		FishOnionPlate.SetActive (true);
		MoveAction (FishOnionPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	private void FishCapsicumPlateComes(){
		itemDragCounter = 0;
		SoundManager.instance.PlaySwooshSound ();
		FishCapsicumPlate.SetActive (true);
		MoveAction (FishCapsicumPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	private void FishOlivesPlateComes(){
		itemDragCounter = 0;
		SoundManager.instance.PlaySwooshSound ();
		FishOlivesPlate.SetActive (true);
		MoveAction (FishOlivesPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	//Pepperoni Chilli Scene Started
	private void PepperoniAndChilliSceneStarted(){
		PepperoniAndChilliItems.SetActive (true);
		PepperoniMeatPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (PepperoniMeatPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void PepperoniCapsicumPlateComes(){
		itemDragCounter = 0;
		SoundManager.instance.PlaySwooshSound ();
		PepperoniCapsicumPlate.SetActive (true);
		MoveAction (PepperoniCapsicumPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void PepperoniOnionPlateComes(){
		itemDragCounter = 0;
		PepperoniOnionPlate.SetActive (true);
		MoveAction (PepperoniOnionPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void PepperoniChilliPlateComes(){
		itemDragCounter = 0;
		SoundManager.instance.PlaySwooshSound ();
		PepperoniChilliPlate.SetActive (true);
		MoveAction (PepperoniChilliPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	private void PepproniPizzaSauceComesInn(){
		PepperoniPizzaSauce.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (PepperoniPizzaSauce, SauceEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("SauceListenerOn", 0.5f);
	}

	private void SauceListenerOn(){
		PepperoniPizzaSauce.gameObject.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void PizzaGoesToStartPoint(){
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (PepperoniPizzaSauce, SauceStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}


	//Bacon Lover Scene Started
	private void BaconLoversSceneStarted(){
		BaconLoversItems.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		BaconLoverMeatPlate.SetActive (true);
		MoveAction (BaconLoverMeatPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void BaconLoverTomatoPlateComes(){
		itemDragCounter = 0;
		BaconLoverTomatoPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (BaconLoverTomatoPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void BaconLoverMushroomPlateComes(){
		itemDragCounter = 0;
		BaconLoverMushroomPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (BaconLoverMushroomPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void BaconLoverMintPlateComes(){
		itemDragCounter = 0;
		BaconLoverMintPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (BaconLoverMintPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void BaconLoverCherryPlateComesInn(){
		itemDragCounter = 0;
		BaconLoverCherryPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (BaconLoverCherryPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	//Primo Scene Started
	private void PrimoMeatsSceneStarted(){
		PrimoMeatItems.SetActive (true);
		PrimoMeatPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (PrimoMeatPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void PrimoCapsicumPlateComes(){
		itemDragCounter = 0;
		PrimoCapsicumPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (PrimoCapsicumPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void PrimoSpanishPlateComes(){
		itemDragCounter = 0;
		PrimoSpanishPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (PrimoSpanishPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void PrimoOlivesPlateComes(){
		itemDragCounter = 0;
		PrimoOlivePlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (PrimoOlivePlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void PrimoOrangesPlateComes(){
		itemDragCounter = 0;
		PrimoOrangePlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (PrimoOrangePlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	//Create Your Own Scene Started
	private void CreateYourOwnSceneStarted(){
		CreateYourOwnItems.SetActive (true);
		CreateMeatPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (CreateMeatPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void CreateCapsicumPlateComes(){
		itemDragCounter = 0;
		CreateCapsicumPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (CreateCapsicumPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void CreateOnionPlateComes(){
		itemDragCounter = 0;
		CreateOnionPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (CreateOnionPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void CreateCornPlateComes(){
		itemDragCounter = 0;
		CreateCornPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (CreateCornPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void CreatePizzaSauceComesInn(){
		CreatePizzaSauce.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (CreatePizzaSauce, SauceEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("CreateSauceListenerOn", 0.5f);
	}

	private void CreateSauceListenerOn(){
		CreatePizzaSauce.gameObject.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void CreatePizzaSauceGoesToStartPoint(){
		MoveAction (CreatePizzaSauce, SauceStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

    //Beef And Veggie Scene Started
    private void BeefAndVeggieSceneStarted()
    {
        BeefAndVeggieItems.SetActive(true);
        BeefMeatPlate.SetActive(true);
        SoundManager.instance.PlaySwooshSound();
        MoveAction(BeefMeatPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
    }

    private void MultiplayerPizzaSceneStarted()
    {
        BeefAndVeggieItems.SetActive(true);
        BeefMeatPlate.SetActive(true);
        SoundManager.instance.PlaySwooshSound();
        MoveAction(BeefMeatPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
    }

    private void BeefTomatoPlateComes(){
		itemDragCounter = 0;
		BeefTomatoPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (BeefTomatoPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	private void BeefCarrotPlateComes(){
		itemDragCounter = 0;
		BeefCarrotPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (BeefCarrotPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	private void BeefHerbPlateComes(){
		itemDragCounter = 0;
		BeefHerbPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (BeefHerbPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	//Lobster Sauce Scene Started
	private void LobsterSauceSceneStarted(){
		LobsterSauceItems.SetActive (true);
		LobsterMeatPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (LobsterMeatPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void LobsterCapsicumPlateComes(){
		itemDragCounter = 0;
		LobsterCapsicumPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (LobsterCapsicumPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void LobsterMushroomPlateComes(){
		itemDragCounter = 0;
		LobsterMushroomPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (LobsterMushroomPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}

	private void LobsterChilliPlateComes(){
		itemDragCounter = 0;
		LobsterChilliPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (LobsterChilliPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	private void LobsterStrawberryPlateComes(){
		itemDragCounter = 0;
		LobsterStrawberryPlate.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (LobsterStrawberryPlate, PlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);

	}

	private void LobsterPizzaSauceComesInn(){
		LobsterPizzaSauce.SetActive (true);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (LobsterPizzaSauce, SauceEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("LobsterPizzaSauceListenerOn", 0.5f);
	}

	private void LobsterPizzaSauceListenerOn(){
		LobsterPizzaSauce.gameObject.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void LobsterPizzaSauceGoesToStartPoint(){
		MoveAction (LobsterPizzaSauce, SauceStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
	}


	private void NextButtonActive(){
		GoodJobScreenActive ();

	}
	#endregion

	#region Callback Methods
	public void DragItemBeginDrag(){
		DestroyColliders.SetActive (false);
	}

	public void DragItemEndDrag(){
		DestroyColliders.SetActive (true);
	}

	private void DestroyCollidersActive(){
		DestroyColliders.SetActive (true);
	}

	public void onCollisionWithTray(){
		Invoke ("DestroyCollidersActive", 0.4f);
		//SoundManager.instance.PlaySwooshSound ();
		GameObject temp	= (GameObject)Instantiate (pizzaItem, GameManager.instance.CollidedObject.transform.position, Quaternion.identity);
		temp.GetComponent<Image> ().sprite = GameManager.instance.itemPicked;
		temp.GetComponent<Image> ().enabled = true;
		temp.GetComponent<Image> ().SetNativeSize ();
		temp.transform.SetParent (PizzaDecorationItems.transform);
		if (GameManager.instance.currentItem == "Meat") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.6f, 0.6f, 0.6f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (MeatPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("BBQTomatoPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Tomato") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.8f, 0.8f, 0.8f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (BBQTomatoPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("BBQOnionPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Onion") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.8f, 0.8f, 0.8f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (BBQOnionPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("BBQCorainderPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Corainder") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.8f, 0.8f, 0.8f);
			itemDragCounter++;
			if(itemDragCounter >= 4){
				MoveAction (BBQCorainderPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("NextButtonActive", 0.5f);
			}
		}

		temp.transform.SetAsLastSibling();
		int index = Random.Range (0, trayPositions.Length);
		MoveAction (temp, trayPositions[index], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MakingPositionZero", 0.3f);
	}

	//Fish and Veggie Scene
	public void onCollisionWithFishPizzaTray(){
		Invoke ("DestroyCollidersActive", 0.4f);
		//SoundManager.instance.PlaySwooshSound ();
		GameObject temp	= (GameObject)Instantiate (pizzaItem, GameManager.instance.CollidedObject.transform.position, Quaternion.identity);
		temp.GetComponent<Image> ().sprite = GameManager.instance.itemPicked;
		temp.GetComponent<Image> ().enabled = true;
		temp.GetComponent<Image> ().SetNativeSize ();
		temp.transform.SetParent (PizzaDecorationItems.transform);
		if (GameManager.instance.currentItem == "Meat") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (FishMeatPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("FishTomatoPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Tomato") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (FishTomatoPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("FishCapsicumPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Onion") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (FishOnionPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("FishOlivesPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Capsicum") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (FishCapsicumPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("FishOnionPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Olives") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 9){
				MoveAction (FishOlivesPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("NextButtonActive", 0.5f);
			}
		}

		temp.transform.SetAsLastSibling();
		int index = Random.Range (0, trayPositions.Length);
		MoveAction (temp, trayPositions[index], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MakingPositionZero", 0.3f);
	}


	//Pepperoni  Scene
	public void onCollisionWithPepperoniPizzaTray(){
		Invoke ("DestroyCollidersActive", 0.4f);
		SoundManager.instance.PlayCollisionSound ();
		GameObject temp	= (GameObject)Instantiate (pizzaItem, GameManager.instance.CollidedObject.transform.position, Quaternion.identity);
		temp.GetComponent<Image> ().sprite = GameManager.instance.itemPicked;
		temp.GetComponent<Image> ().enabled = true;
		temp.GetComponent<Image> ().SetNativeSize ();
		temp.transform.SetParent (PizzaDecorationItems.transform);
		if (GameManager.instance.currentItem == "Meat") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (PepperoniMeatPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("PepperoniCapsicumPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Capsicum") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (PepperoniCapsicumPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("PepperoniOnionPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Onion") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (PepperoniOnionPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("PepperoniChilliPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Chilli") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (PepperoniChilliPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("PepproniPizzaSauceComesInn", 0.5f);
			}
		}

		temp.transform.SetAsLastSibling();
		int index = Random.Range (0, trayPositions.Length);
		MoveAction (temp, trayPositions[index], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MakingPositionZero", 0.3f);
	}


	//Bacon Lover Scene
	public void onCollisionWithBaconLoverPizzaTray(){
		Invoke ("DestroyCollidersActive", 0.4f);
		SoundManager.instance.PlayCollisionSound ();
		GameObject temp	= (GameObject)Instantiate (pizzaItem, GameManager.instance.CollidedObject.transform.position, Quaternion.identity);
		temp.GetComponent<Image> ().sprite = GameManager.instance.itemPicked;
		temp.GetComponent<Image> ().enabled = true;
		temp.GetComponent<Image> ().SetNativeSize ();
		temp.transform.SetParent (PizzaDecorationItems.transform);
		if (GameManager.instance.currentItem == "Meat") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (BaconLoverMeatPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("BaconLoverTomatoPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Tomato") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (BaconLoverTomatoPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("BaconLoverMushroomPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Mushroom") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (BaconLoverMushroomPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("BaconLoverMintPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Mint") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (BaconLoverMintPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("BaconLoverCherryPlateComesInn", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Cherry") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (BaconLoverCherryPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("NextButtonActive", 0.5f);
			}
		}

		temp.transform.SetAsLastSibling();
		int index = Random.Range (0, trayPositions.Length);
		MoveAction (temp, trayPositions[index], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MakingPositionZero", 0.3f);
	}

	//Primo Meat Scene Started 
	public void onCollisionWithPrimoPizzaTray(){
		Invoke ("DestroyCollidersActive", 0.4f);
		SoundManager.instance.PlayCollisionSound ();
		GameObject temp	= (GameObject)Instantiate (pizzaItem, GameManager.instance.CollidedObject.transform.position, Quaternion.identity);
		temp.GetComponent<Image> ().sprite = GameManager.instance.itemPicked;
		temp.GetComponent<Image> ().enabled = true;
		temp.GetComponent<Image> ().SetNativeSize ();
		temp.transform.SetParent (PizzaDecorationItems.transform);
		if (GameManager.instance.currentItem == "Meat") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (PrimoMeatPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("PrimoCapsicumPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Capsicum") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (PrimoCapsicumPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("PrimoSpanishPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Spanish") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (PrimoSpanishPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("PrimoOlivesPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Olives") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 9){
				MoveAction (PrimoOlivePlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("PrimoOrangesPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Orange") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (PrimoOrangePlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("NextButtonActive", 0.5f);
			}
		}
		temp.transform.SetAsLastSibling();
		int index = Random.Range (0, trayPositions.Length);
		MoveAction (temp, trayPositions[index], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MakingPositionZero", 0.3f);
	}

	//Create Your Own Scene
	public void onCollisionWithCreatePizzaTray(){
		Invoke ("DestroyCollidersActive", 0.4f);
		SoundManager.instance.PlayCollisionSound ();
		GameObject temp	= (GameObject)Instantiate (pizzaItem, GameManager.instance.CollidedObject.transform.position, Quaternion.identity);
		temp.GetComponent<Image> ().sprite = GameManager.instance.itemPicked;
		temp.GetComponent<Image> ().enabled = true;
		temp.GetComponent<Image> ().SetNativeSize ();
		temp.transform.SetParent (PizzaDecorationItems.transform);
		if (GameManager.instance.currentItem == "Meat") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (CreateMeatPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("CreateCapsicumPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Capsicum") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (CreateCapsicumPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("CreateOnionPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Onion") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (CreateOnionPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("CreateCornPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Corn") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 9){
				MoveAction (CreateCornPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("CreatePizzaSauceComesInn", 0.5f);
			}
		}

		temp.transform.SetAsLastSibling();
		int index = Random.Range (0, trayPositions.Length);
		MoveAction (temp, trayPositions[index], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MakingPositionZero", 0.3f);
	}

    //Beef And Veggie Scene
    public void onCollisionWithBeefPizzaTray()
    {
        Invoke("DestroyCollidersActive", 0.4f);
        SoundManager.instance.PlayCollisionSound();
        GameObject temp = (GameObject)Instantiate(pizzaItem, GameManager.instance.CollidedObject.transform.position, Quaternion.identity);
        temp.GetComponent<Image>().sprite = GameManager.instance.itemPicked;
        temp.GetComponent<Image>().enabled = true;
        temp.GetComponent<Image>().SetNativeSize();
        temp.transform.SetParent(PizzaDecorationItems.transform);
        if (GameManager.instance.currentItem == "Meat")
        {
            temp.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            itemDragCounter++;
            if (itemDragCounter >= 5)
            {
                MoveAction(BeefMeatPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
                Invoke("BeefTomatoPlateComes", 0.5f);
            }
        }

        else if (GameManager.instance.currentItem == "Tomato")
        {
            temp.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            itemDragCounter++;
            if (itemDragCounter >= 5)
            {
                MoveAction(BeefTomatoPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
                Invoke("BeefCarrotPlateComes", 0.5f);
            }
        }

        else if (GameManager.instance.currentItem == "Carrot")
        {
            temp.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            itemDragCounter++;
            if (itemDragCounter >= 5)
            {
                MoveAction(BeefCarrotPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
                Invoke("BeefHerbPlateComes", 0.5f);
            }
        }

        else if (GameManager.instance.currentItem == "Herb")
        {
            temp.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 0.7f);
            itemDragCounter++;
            if (itemDragCounter >= 4)
            {
                MoveAction(BeefHerbPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
                Invoke("NextButtonActive", 0.5f);
            }
        }

        temp.transform.SetAsLastSibling();
        int index = Random.Range(0, trayPositions.Length);
        MoveAction(temp, trayPositions[index], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("MakingPositionZero", 0.3f);
    }

    public void onCollisionWithMultiplayerPizzaTray()
    {
        Invoke("DestroyCollidersActive", 0.4f);
        SoundManager.instance.PlayCollisionSound();
        GameObject temp = (GameObject)Instantiate(pizzaItem, GameManager.instance.CollidedObject.transform.position, Quaternion.identity);
        temp.GetComponent<Image>().sprite = GameManager.instance.itemPicked;
        temp.GetComponent<Image>().enabled = true;
        temp.GetComponent<Image>().SetNativeSize();
        temp.transform.SetParent(PizzaDecorationItems.transform);
        if (GameManager.instance.currentItem == "Meat")
        {
            temp.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            itemDragCounter++;
            if (itemDragCounter >= 5)
            {
                MoveAction(BeefMeatPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
                Invoke("BeefTomatoPlateComes", 0.5f);
            }
        }

        else if (GameManager.instance.currentItem == "Tomato")
        {
            temp.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            itemDragCounter++;
            if (itemDragCounter >= 5)
            {
                MoveAction(BeefTomatoPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
                Invoke("BeefCarrotPlateComes", 0.5f);
            }
        }

        else if (GameManager.instance.currentItem == "Carrot")
        {
            temp.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            itemDragCounter++;
            if (itemDragCounter >= 5)
            {
                MoveAction(BeefCarrotPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
                Invoke("BeefHerbPlateComes", 0.5f);
            }
        }

        else if (GameManager.instance.currentItem == "Herb")
        {
            temp.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            itemDragCounter++;
            if (itemDragCounter >= 4)
            {
                MoveAction(BeefHerbPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
                Invoke("NextButtonActive", 0.5f);
            }
        }

        temp.transform.SetAsLastSibling();
        int index = Random.Range(0, trayPositions.Length);
        MoveAction(temp, trayPositions[index], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
        Invoke("MakingPositionZero", 0.3f);
    }

    //Lobster Sauce  Scene
    public void onCollisionWithLobsterPizzaTray(){
		Invoke ("DestroyCollidersActive", 0.4f);
		SoundManager.instance.PlayCollisionSound ();
		GameObject temp	= (GameObject)Instantiate (pizzaItem, GameManager.instance.CollidedObject.transform.position, Quaternion.identity);
		temp.GetComponent<RectTransform> ().localPosition = new Vector3 (temp.GetComponent<RectTransform> ().localPosition.x,temp.GetComponent<RectTransform> ().localPosition.y,0f);
		temp.GetComponent<Image> ().sprite = GameManager.instance.itemPicked;
		temp.GetComponent<Image> ().enabled = true;
		temp.GetComponent<Image> ().SetNativeSize ();
		temp.transform.SetParent (PizzaDecorationItems.transform);
		if (GameManager.instance.currentItem == "Meat") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (LobsterMeatPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("LobsterCapsicumPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Capsicum") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (LobsterCapsicumPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("LobsterMushroomPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Mushroom") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (LobsterMushroomPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("LobsterChilliPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Chilli") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.8f, 0.8f, 0.8f);
			itemDragCounter++;
			if(itemDragCounter >= 5){
				MoveAction (LobsterChilliPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("LobsterStrawberryPlateComes", 0.5f);
			}
		}

		else if (GameManager.instance.currentItem == "Strawberry") {
			temp.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			itemDragCounter++;
			if(itemDragCounter >= 8){
				MoveAction (LobsterStrawberryPlate, PlateStartPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("LobsterPizzaSauceComesInn", 0.5f);
			}
		}

		temp.transform.SetAsLastSibling();
		int index = Random.Range (0, trayPositions.Length);
		MoveAction (temp, trayPositions[index], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MakingPositionZero", 0.3f);
	}

	private void MakingPositionZero(){
		for(int i = 0; i< PizzaDecorationItems.transform.childCount; i++){
			print ("child count"+PizzaDecorationItems.transform.childCount);
			PizzaDecorationItems.transform.GetChild (i).gameObject.GetComponent<RectTransform> ().localPosition = new Vector3 (PizzaDecorationItems.transform.GetChild (i).gameObject.GetComponent<RectTransform> ().localPosition.x, PizzaDecorationItems.transform.GetChild (i).gameObject.GetComponent<RectTransform> ().localPosition.y, 0f);

		}

	}


	public void SauceBeginDrag(){
		if (pizzaSauceFlag) {
			switch (GameManager.instance.SelectedPizzaFlavour) {
			case 0:   //BBQ & Veggie

				break;

			case 1:     //Fish & Veggie
			
				break;

			case 2:     //Pepperoni & Chilli
				print("come there");
				pizzaSauce.gameObject.SetActive (true);
				pizzaSauce.sprite = flavourPizzaSauces [0];
				break;


			case 3:   //Bacon Lovers
		//BaconLoversSceneStarted();
				break;

			case 4:    //Primo Meats
		//PrimoMeatsSceneStarted();
				break;


			case 5: //Create Your Own
				pizzaSauce.gameObject.SetActive (true);
				pizzaSauce.sprite = flavourPizzaSauces [1];
				break;

			case 6: //Beef & Veggie
		//BeefAndVeggieSceneStarted();
				break;


			case 7: //Lobster Sauce
				pizzaSauce.gameObject.SetActive (true);
				pizzaSauce.sprite = flavourPizzaSauces [2];
				break;
			}
			pizzaSauceFlag = false;
		}

	}


	public void SauceEndDrag(){


	}

	public void OnCollisionWithSauces(){
		if (SauceSoundFlag) {
			SoundManager.instance.PlaySauceSound ();
			SauceSoundFlag = false;
		}
		colorIncreases (pizzaSauce, 0.3f);
		if (pizzaSauce.color.a >= 1.0f) {
			if(GameManager.instance.SelectedPizzaFlavour == 2){
			PepperoniPizzaSauce.GetComponent<BoxCollider2D> ().enabled = false;
			PepperoniPizzaSauce.GetComponent<ApplicatorListener> ().enabled = false;
			RotateAction (PepperoniPizzaSauce, 0f, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
			MoveAction (PepperoniPizzaSauce, SauceEndPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("NextButtonActive", 0.5f);
			Invoke ("PizzaGoesToStartPoint", 0.5f);
			}

			else if(GameManager.instance.SelectedPizzaFlavour == 5){
				CreatePizzaSauce.GetComponent<BoxCollider2D> ().enabled = false;
				CreatePizzaSauce.GetComponent<ApplicatorListener> ().enabled = false;
				RotateAction (CreatePizzaSauce, 0f, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				MoveAction (CreatePizzaSauce, SauceEndPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("NextButtonActive", 0.5f);
				Invoke ("CreatePizzaSauceGoesToStartPoint", 0.5f);
			}

			else if(GameManager.instance.SelectedPizzaFlavour == 7){
				LobsterPizzaSauce.GetComponent<BoxCollider2D> ().enabled = false;
				LobsterPizzaSauce.GetComponent<ApplicatorListener> ().enabled = false;
				RotateAction (LobsterPizzaSauce, 0f, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				MoveAction (LobsterPizzaSauce, SauceEndPoint, 0.4f, iTween.EaseType.linear, iTween.LoopType.none);
				Invoke ("NextButtonActive", 0.5f);
				Invoke ("LobsterPizzaSauceGoesToStartPoint", 0.5f);
			}
		}
	}

	public void OnClickMenuBook(){
		SoundManager.instance.PlayButtonClickSound ();
		menuBookButton.SetActive (false);
		PizzaScreen.SetActive (true);
	}

	public void InActiveMenuBook(){
		SoundManager.instance.PlayButtonClickSound ();
		PizzaScreen.SetActive (false);
		menuBookButton.SetActive (true);
	}

	private void PizzaInstantiate(){
		GameManager.instance.player.SetPizza(Instantiate(pizzaTray));
	}
		
	private void GoodJobScreenActive(){
		SoundManager.instance.PlayActionSound ();
        goodJobScreen.SetActive (true);
		MoveAction (GoodJobText, GoodJobTextEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("NextActive", 2.0f);
	}

	private void NextActive(){
		SoundManager.instance.PlayButtonClickSound ();
		goodJobScreen.SetActive (false);
		SoundManager.instance.PlayLevelCompletedSound ();
		firework.SetActive (true);
		Invoke("NextBtnDelay", 2f);
	}

	void NextBtnDelay()
	{
		NextButton.SetActive(true);// add delay 5 secs
	}

	public void OnClickNext(){
		firework.SetActive (false);
		NextButton.SetActive (false);
		LoadingBgActive ();
	}

	private void LoadingBgActive(){
		LoadinBg.SetActive (true);
		StartCoroutine (FillAction(LoadingFilled));
		Invoke ("LoadingFull", 4.0f);
		//Invoke("callAds", 1.0f);
	}

	void callAds()
	{
		//AssignAdIds_CB.instance.CallInterstitialAd(Adspref.GamePause);
	    AdsManager.Instance.ShowInterstitial("Ad show  on loading Screen");

	}

	IEnumerator FillAction (Image img){
		if (img.fillAmount < 1) {
			img.fillAmount = img.fillAmount + 0.009f;
			yield return new WaitForSeconds (0.02f);
			StartCoroutine (FillAction (img));
		}  else if (img.color.a >= 1f) {
			StopCoroutine (FillAction (img));
		}
	}

	private void LoadingFull(){
		print ("Loading Completed");
		MakingPositionZero ();
		PizzaStopImage.SetActive (true);
		PizzaInstantiate ();
		NavigationManager.instance.ReplaceScene (GameScene.PIZZABAKINGVIEW);
	}

	#endregion 
}
