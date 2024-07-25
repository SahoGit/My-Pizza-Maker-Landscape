using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Notionhub;

public class StoreShoppingView : MonoBehaviour {
	#region Variables, Constants & Initializers
	public GameObject vegetableScreen, fruitScreen, meatScreen, seaFoodScreen, herbsScreen;
	public GameObject PizzaScreen;
	public Image FlavourPizzaScreen;
	public Sprite[] pizzaMenuBooks;
	public GameObject menuBookButton;
	public GameObject basket;
	public RectTransform basketUpperPoint, basketLowerPoint;
	public Image HintImage;
	public GameObject pointingHand;
	public RectTransform pointingHandEndPoint;
	public GameObject fireWorks;
	public GameObject NextButton;
	public GameObject goodJobScreen;
	public GameObject GoodJobText;
	public RectTransform GoodJobTextEndPoint;
	public GameObject LoadinBg;
	public Image LoadingFilled;
	//BBQ & VEGGIE
	public GameObject fishPiece, tomato, Onion, Corainder;
	//Fish & Veggie
	public GameObject  GreenCapsicum, Olives, FishCut;
	//Pepperoni & Chilli
	public GameObject  YellowCapsicum, Chilli, HotDog;
	//Bacon Lovers
	public GameObject  Mashrooms, Mint, Cherry, FlatPiece;
	//Primo Meats
	public GameObject Herbs, Oranges, LegPiece, RedCapsicum, RoundFish;
	//Create Your Own
	public GameObject Corn, HalfFish;
	//Beef & Veggie
	public GameObject carrot, spanish, middlePiece;
	//Lobster Sauce
	public GameObject SeaFish, strawberry;
	// Use this for initialization
	#endregion

	#region Lifecycle Methods
	void Start () {
		ShowAd ();
		GameManager.instance.currentScene = GameUtils.StoreShopping_VIEW;
		Invoke ("SetViewContents", 0.1f);
        if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            menuBookButton.SetActive(false);
        }
        else
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
		//GameManager.instance.SelectedPizzaFlavour = 1;
		print ("Flour of pizza is" + GameManager.instance.SelectedPizzaFlavour);
		WhichPizzaPrepared (GameManager.instance.SelectedPizzaFlavour);
		PointingHandActive ();
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

	private void PointingHandActive(){
		pointingHand.SetActive (true);
		MoveAction (pointingHand, pointingHandEndPoint, 1.5f, iTween.EaseType.linear, iTween.LoopType.loop);
		Invoke ("PointingHandInactive", 2.0f);
	}

	private void PointingHandInactive(){
		pointingHand.SetActive (false);
	}

	private void WhichPizzaPrepared(int tag){
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

	//BBQ & Veggie
	private void BBQAndVegieSceneStarted(){
		fishPiece.tag = "BasketItem";
		tomato.tag = "BasketItem";
		Onion.tag = "BasketItem";
		Corainder.tag = "BasketItem";
		HintImage.sprite = tomato.GetComponent<Image> ().sprite; 
		SoundManager.instance.PlayActionSound ();
		HintImage.gameObject.SetActive (true);
		FlavourPizzaScreen.sprite = pizzaMenuBooks[GameManager.instance.SelectedPizzaFlavour];
		VegetableScreenActive ();
	}

	private void VegetableScreenActive(){
		vegetableScreen.SetActive (true);
		tomato.GetComponent<BoxCollider2D> ().enabled = true;
	}


	//Fish & Veggie

	private void FishAndVegieSceneStarted(){
		FishCut.tag = "BasketItem";
		tomato.tag = "BasketItem";
		Onion.tag = "BasketItem";
		GreenCapsicum.tag = "BasketItem";
		Olives.tag = "BasketItem";
		HintImage.sprite = tomato.GetComponent<Image> ().sprite; 
		SoundManager.instance.PlayActionSound ();
		HintImage.gameObject.SetActive (true);
		FlavourPizzaScreen.sprite = pizzaMenuBooks[GameManager.instance.SelectedPizzaFlavour];
		VegetableScreenActive ();
	}

	//Pepperoni & Chilli
		
	private void PepperoniAndChilliSceneStarted(){
		HotDog.tag = "BasketItem";
		YellowCapsicum.tag = "BasketItem";
		Onion.tag = "BasketItem";
		Chilli.tag = "BasketItem";
		HintImage.sprite = Onion.GetComponent<Image> ().sprite; 
		SoundManager.instance.PlayActionSound ();
		HintImage.gameObject.SetActive (true);
		FlavourPizzaScreen.sprite = pizzaMenuBooks[GameManager.instance.SelectedPizzaFlavour];
		VegetableScreenActiveWithOnion ();
	}
		
	private void VegetableScreenActiveWithOnion(){
		vegetableScreen.SetActive (true);
		Onion.GetComponent<BoxCollider2D> ().enabled = true;
	}

	//Beccon Lovers 

	private void BaconLoversSceneStarted(){
		FlatPiece.tag = "BasketItem";
		tomato.tag = "BasketItem";
		Mashrooms.tag = "BasketItem";
		Mint.tag = "BasketItem";
		Cherry.tag = "BasketItem";
		HintImage.sprite = tomato.GetComponent<Image> ().sprite; 
		SoundManager.instance.PlayActionSound ();
		HintImage.gameObject.SetActive (true);
		FlavourPizzaScreen.sprite = pizzaMenuBooks[GameManager.instance.SelectedPizzaFlavour];
		VegetableScreenActive ();
	}


	//Primo Meats
	private void PrimoMeatsSceneStarted(){
		RedCapsicum.tag = "BasketItem";
		Herbs.tag = "BasketItem";
		Oranges.tag = "BasketItem";
		Olives.tag = "BasketItem";
		RoundFish.tag = "BasketItem";
		HintImage.sprite = RedCapsicum.GetComponent<Image> ().sprite; 
		SoundManager.instance.PlayActionSound ();
		HintImage.gameObject.SetActive (true);
		FlavourPizzaScreen.sprite = pizzaMenuBooks[GameManager.instance.SelectedPizzaFlavour];
		VegetableScreenActiveWithRedCapsicum ();


	}

	private void  VegetableScreenActiveWithRedCapsicum(){
		vegetableScreen.SetActive (true);
		RedCapsicum.GetComponent<BoxCollider2D> ().enabled = true;

	}

	//CreateYourOwn
	private void CreateYourOwnSceneStarted(){
		Onion.tag = "BasketItem";
		GreenCapsicum.tag = "BasketItem";
		Corn.tag = "BasketItem";
		HalfFish.tag = "BasketItem";
		HintImage.sprite = Onion.GetComponent<Image> ().sprite; 
		SoundManager.instance.PlayActionSound ();
		HintImage.gameObject.SetActive (true);
		FlavourPizzaScreen.sprite = pizzaMenuBooks[GameManager.instance.SelectedPizzaFlavour];
		VegetableScreenActiveWithOnion ();

	}

	//Beef And Veggie
	private void  BeefAndVeggieSceneStarted(){
		tomato.tag = "BasketItem";
		carrot.tag = "BasketItem";
		spanish.tag = "BasketItem";
		middlePiece.tag = "BasketItem";
		HintImage.sprite = tomato.GetComponent<Image> ().sprite; 
		SoundManager.instance.PlayActionSound ();
		HintImage.gameObject.SetActive (true);
		FlavourPizzaScreen.sprite = pizzaMenuBooks[GameManager.instance.SelectedPizzaFlavour];
		VegetableScreenActive ();
	}

    //Lobster Sauce
    private void LobsterSauceSceneStarted()
    {
        SeaFish.tag = "BasketItem";
        YellowCapsicum.tag = "BasketItem";
        Chilli.tag = "BasketItem";
        Mashrooms.tag = "BasketItem";
        strawberry.tag = "BasketItem";
        HintImage.sprite = YellowCapsicum.GetComponent<Image>().sprite;
        SoundManager.instance.PlayActionSound();
        HintImage.gameObject.SetActive(true);
        FlavourPizzaScreen.sprite = pizzaMenuBooks[GameManager.instance.SelectedPizzaFlavour];
        VegetableScreenActiveWithYellowCapsicum();
    }

    private void VegetableScreenActiveWithYellowCapsicum(){
		vegetableScreen.SetActive (true);
		YellowCapsicum.GetComponent<BoxCollider2D> ().enabled = true;
	}

    private void MultiplayerPizzaSceneStarted()
    {
        tomato.tag = "BasketItem";
        carrot.tag = "BasketItem";
        spanish.tag = "BasketItem";
        middlePiece.tag = "BasketItem";
        HintImage.sprite = tomato.GetComponent<Image>().sprite;
        SoundManager.instance.PlayActionSound();
        HintImage.gameObject.SetActive(true);
        FlavourPizzaScreen.sprite = pizzaMenuBooks[GameManager.instance.SelectedPizzaFlavour];
        VegetableScreenActive();
    }

    #endregion

    #region Callback Methods
    //BBQ & Veggie
    public void OnCollisionBasketWithTomato(){
		if (GameManager.instance.currentItem == "Tomato") {
			tomato.transform.SetParent (basket.transform);
			tomato.transform.SetSiblingIndex (2);
			tomato.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (tomato, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(tomato));
			if(GameManager.instance.SelectedPizzaFlavour == 3){
				Invoke ("MushroomActive", 0.8f);
			}
			else if(GameManager.instance.SelectedPizzaFlavour == 4){
				Invoke ("FruitScreenActive", 0.8f);
			}

            else if (GameManager.instance.SelectedPizzaFlavour == 6)
            {
                Invoke("CarrotActive", 0.8f);
            }
            else if (GameManager.instance.SelectedPizzaFlavour == 8)
            {
                Invoke("CarrotActive", 0.8f);
            }

            else
            {
				Invoke ("OnionActive", 0.8f);
			}
		}
	}

	private void OnionActive(){
		HintImage.sprite = Onion.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionBasketWithOnion(){
		if (GameManager.instance.currentItem == "Onion") {
			Onion.transform.SetParent (basket.transform);
			Onion.transform.SetSiblingIndex (2);
			Onion.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (Onion, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(Onion));
			if (GameManager.instance.SelectedPizzaFlavour == 0) {
				Invoke ("MeatScreenActive", 0.8f);
			}

			else if(GameManager.instance.SelectedPizzaFlavour == 1){
				Invoke ("CapsicumActive", 0.8f);
			}	

			else if(GameManager.instance.SelectedPizzaFlavour == 2){
				Invoke ("YellowCapsicumActive", 0.8f);
			}

			else if(GameManager.instance.SelectedPizzaFlavour == 5){
				Invoke ("CapsicumActive", 0.8f);
			}	
		}
	}

	private void MeatScreenActive(){
		meatScreen.SetActive (true);
		vegetableScreen.SetActive (false);
		fishPiece.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = fishPiece.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionFishMeatWithBasket(){
		if (GameManager.instance.currentItem == "LegPiece") {
			fishPiece.transform.SetParent (basket.transform);
			fishPiece.transform.SetSiblingIndex (2);
			fishPiece.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (fishPiece, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(fishPiece));
			Invoke ("HerbScreenActive", 0.8f);
		}
	}

	private void HerbScreenActive(){
		meatScreen.SetActive (false);
		herbsScreen.SetActive (true);
		Corainder.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = Corainder.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionCorainderWithBasket(){
		if (GameManager.instance.currentItem == "Corainder") {
			Corainder.transform.SetParent (basket.transform);
			Corainder.transform.SetSiblingIndex (2);
			Corainder.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (Corainder, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(Corainder));
			Invoke ("PizzaPrepared", 0.8f);
		}
	}

	//BBQ && fish Scene Active
	private void CapsicumActive(){
		GreenCapsicum.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = GreenCapsicum.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionCapsicumWithBasket(){
		if (GameManager.instance.currentItem == "CapsicumGreen") {
			GreenCapsicum.transform.SetParent (basket.transform);
			GreenCapsicum.transform.SetSiblingIndex (2);
			GreenCapsicum.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (GreenCapsicum, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(GreenCapsicum));
			if(GameManager.instance.SelectedPizzaFlavour == 5){
				Invoke("CornActive", 0.8f);
			}
			else{
				Invoke ("FruitScreenActive", 0.8f);
			}
		}
	}

	private void FruitScreenActive(){
		vegetableScreen.SetActive (false);
		fruitScreen.SetActive (true);
		Olives.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = Olives.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionOlivesWithBasket(){
		if (GameManager.instance.currentItem == "Olives") {
			Olives.transform.SetParent (basket.transform);
			Olives.transform.SetSiblingIndex (2);
			Olives.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (Olives, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(Olives));
			if (GameManager.instance.SelectedPizzaFlavour == 4) {
				Invoke ("OrangesActive", 0.8f);
			} else {
				Invoke ("SeaFoodFishCutScreenActive", 0.8f);
			}
		}
	}

	private void SeaFoodFishCutScreenActive(){
		fruitScreen.SetActive (false);
		seaFoodScreen.SetActive (true);
		FishCut.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = FishCut.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionFishCutWithBasket(){
		if (GameManager.instance.currentItem == "FishCut") {
			FishCut.transform.SetParent (basket.transform);
			FishCut.transform.SetSiblingIndex (2);
			FishCut.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (FishCut, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(FishCut));
			Invoke ("PizzaPrepared", 0.8f);
		}
	}

	//Pepperoni And Chilli Pizza
	private void YellowCapsicumActive(){
		YellowCapsicum.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = YellowCapsicum.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionYellowCapsicumWithBasket(){
		if (GameManager.instance.currentItem == "CapsicumYellow") {
			YellowCapsicum.transform.SetParent (basket.transform);
			YellowCapsicum.transform.SetSiblingIndex (2);
			YellowCapsicum.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (YellowCapsicum, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(YellowCapsicum));
            if (GameManager.instance.SelectedPizzaFlavour == 7)
            {
                Invoke("MushroomActive", 0.8f);

            }
            else if (GameManager.instance.SelectedPizzaFlavour == 8)
            {
                Invoke("MushroomActive", 0.8f);
            } else
            {
                Invoke("MeatScreenActiveWithHotDogs", 0.8f);
            }
            
        }
	}

	private void MeatScreenActiveWithHotDogs(){
		meatScreen.SetActive (true);
		vegetableScreen.SetActive (false);
		HotDog.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = HotDog.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionHotDogsWithBasket(){
		if (GameManager.instance.currentItem == "HotDogs") {
			HotDog.GetComponent<BoxCollider2D> ().enabled = false;
			HotDog.transform.SetParent (basket.transform);
			HotDog.transform.SetSiblingIndex (2);
			HotDog.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (HotDog, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(HotDog));
			Invoke ("HerbScreenActiveWithChilli", 0.8f);
		}
	}

	private void HerbScreenActiveWithChilli(){
		seaFoodScreen.SetActive (false);
		meatScreen.SetActive (false);
		herbsScreen.SetActive (true);
		Chilli.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = Chilli.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionChilliWithBasket(){
		if (GameManager.instance.currentItem == "GreenChilli") {
			Chilli.GetComponent<BoxCollider2D> ().enabled = false;
			Chilli.transform.SetParent (basket.transform);
			Chilli.transform.SetSiblingIndex (2);
			Chilli.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (Chilli, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(Chilli));
			if (GameManager.instance.SelectedPizzaFlavour == 7) {
				Invoke ("PizzaPrepared", 0.8f);
			} else {
				Invoke ("PizzaPrepared", 0.8f);
			}
		}
	}

	//Becon Lover
	private void MushroomActive(){
		Mashrooms.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = Mashrooms.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionMushroomWithBasket(){
		if (GameManager.instance.currentItem == "Mushroom") {
			Mashrooms.transform.SetParent (basket.transform);
			Mashrooms.transform.SetSiblingIndex (2);
			Mashrooms.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (Mashrooms, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(Mashrooms));
			if(GameManager.instance.SelectedPizzaFlavour == 7){
				Invoke ("FruitScreenActiveWithStrawberry", 0.8f);
			}
			else{
				Invoke ("FruitScreenActiveWithCherry", 0.8f);
			}
		}
	}

	private void FruitScreenActiveWithCherry(){
		vegetableScreen.SetActive (false);
		fruitScreen.SetActive (true);
		Cherry.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = Cherry.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionCherryWithBasket(){
		if (GameManager.instance.currentItem == "Cherry") {
			Cherry.transform.SetParent (basket.transform);
			Cherry.transform.SetSiblingIndex (2);
			Cherry.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (Cherry, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(Cherry));
			Invoke ("MeatScreenActiveWithFlatPiece", 0.8f);
		}
	}

	private void MeatScreenActiveWithFlatPiece(){
		meatScreen.SetActive (true);
		fruitScreen.SetActive (false);
		FlatPiece.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = FlatPiece.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionFlatPieceWithBasket(){
		if (GameManager.instance.currentItem == "FlatPiece") {
			FlatPiece.GetComponent<BoxCollider2D> ().enabled = false;
			FlatPiece.transform.SetParent (basket.transform);
			FlatPiece.transform.SetSiblingIndex (2);
			FlatPiece.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (FlatPiece, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(FlatPiece));
			Invoke ("HerbScreenActiveWithMint", 0.8f);
		}
	}

	private void HerbScreenActiveWithMint(){
		meatScreen.SetActive (false);
		herbsScreen.SetActive (true);
		Mint.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = Mint.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionMintWithBasket(){
		if (GameManager.instance.currentItem == "Mint") {
			Mint.GetComponent<BoxCollider2D> ().enabled = false;
			Mint.transform.SetParent (basket.transform);
			Mint.transform.SetSiblingIndex (2);
			Mint.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (Mint, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(Mint));
			Invoke ("PizzaPrepared", 0.8f);
		}
	}

	//Primo Meats
	private void OrangesActive(){
		Oranges.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = Oranges.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionOrangesWithBasket(){
		if (GameManager.instance.currentItem == "Orange") {
			Oranges.transform.SetParent (basket.transform);
			Oranges.transform.SetSiblingIndex (2);
			Oranges.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (Oranges, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(Oranges));
			Invoke ("SeaFoodScreenActiveWithFishRound", 0.8f);
		}
	}

	private void MeatScreenActiveWithLegPiece(){
		meatScreen.SetActive (true);
		fruitScreen.SetActive (false);
		LegPiece.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = LegPiece.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	private void SeaFoodScreenActiveWithFishRound(){
		seaFoodScreen.SetActive (true);
		fruitScreen.SetActive (false);
		RoundFish.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = RoundFish.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionLegPieceWithBasket(){
		if (GameManager.instance.currentItem == "LegPiece") {
			LegPiece.GetComponent<BoxCollider2D> ().enabled = false;
			LegPiece.transform.SetParent (basket.transform);
			LegPiece.transform.SetSiblingIndex (2);
			LegPiece.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (LegPiece, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(LegPiece));
			if (GameManager.instance.SelectedPizzaFlavour == 0) {
				Invoke ("HerbScreenActive", 0.8f);
			} else {
				Invoke ("HerbScreenActiveWithHerbs", 0.8f);
			}
		}
	}

	public void OnCollisionRoundFishWithBasket(){
		if (GameManager.instance.currentItem == "FishRound") {
			RoundFish.GetComponent<BoxCollider2D> ().enabled = false;
			RoundFish.transform.SetParent (basket.transform);
			RoundFish.transform.SetSiblingIndex (2);
			RoundFish.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (RoundFish, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(RoundFish));
			Invoke ("HerbScreenActiveWithHerbs", 0.8f);
			}
		}


	private void HerbScreenActiveWithHerbs(){
		seaFoodScreen.SetActive (false);
		herbsScreen.SetActive (true);
		Herbs.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = Herbs.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}


	public void OnCollisionRedCapsicumWithBasket(){
		if (GameManager.instance.currentItem == "RedCapsicum") {
			RedCapsicum.GetComponent<BoxCollider2D> ().enabled = false;
			RedCapsicum.transform.SetParent (basket.transform);
			RedCapsicum.transform.SetSiblingIndex (2);
			RedCapsicum.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (RedCapsicum, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(RedCapsicum));
			Invoke ("FruitScreenActive", 0.8f);
		}
	}

	public void OnCollisionHerbsWithBasket(){
		if (GameManager.instance.currentItem == "Herbs") {
			Herbs.GetComponent<BoxCollider2D> ().enabled = false;
			Herbs.transform.SetParent (basket.transform);
			Herbs.transform.SetSiblingIndex (2);
			Herbs.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (Herbs, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(Herbs));
			Invoke ("PizzaPrepared", 0.8f);
		}
	}

	//Create Your Own
	private void CornActive(){
		Corn.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = Corn.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionCornWithBasket(){
		if (GameManager.instance.currentItem == "Corn") {
			Corn.transform.SetParent (basket.transform);
			Corn.transform.SetSiblingIndex (2);
			Corn.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (Corn, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(Corn));
			Invoke ("SeaFoodScreenActiveWithHalfFish", 0.8f);
		}
	}

	private void SeaFoodScreenActiveWithHalfFish(){
		seaFoodScreen.SetActive (true);
		vegetableScreen.SetActive (false);
		HalfFish.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = HalfFish.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionHalfFishWithBasket(){
		if (GameManager.instance.currentItem == "HalfFish") {
			HalfFish.GetComponent<BoxCollider2D> ().enabled = false;
			HalfFish.transform.SetParent (basket.transform);
			HalfFish.transform.SetSiblingIndex (2);
			HalfFish.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (HalfFish, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(HalfFish));
			Invoke ("PizzaPrepared", 0.8f);
		}
	}

	// Beef And Veggie
	private void CarrotActive(){
		carrot.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = carrot.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionBasketWithCarrot(){
		if (GameManager.instance.currentItem == "Carrot") {
			carrot.transform.SetParent (basket.transform);
			carrot.transform.SetSiblingIndex (2);
			carrot.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (carrot, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			StartCoroutine (itemsInBasket(carrot));
			Invoke ("MeatScreenActiveWitMiddlePiece", 0.8f);
		}
	}

	private void MeatScreenActiveWitMiddlePiece(){
		meatScreen.SetActive (true);
		vegetableScreen.SetActive (false);
		middlePiece.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = middlePiece.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionMiddlePieceWithBasket(){
		if (GameManager.instance.currentItem == "MiddlePiece") {
			middlePiece.GetComponent<BoxCollider2D> ().enabled = false;
			middlePiece.transform.SetParent (basket.transform);
			middlePiece.transform.SetSiblingIndex (2);
			middlePiece.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (middlePiece, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(middlePiece));
			Invoke ("HerbScreenActiveWithSpanish", 0.8f);
		}
	}

	private void HerbScreenActiveWithSpanish(){
		meatScreen.SetActive (false);
		herbsScreen.SetActive (true);
		spanish.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = spanish.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionSpanishWithBasket(){
		if (GameManager.instance.currentItem == "Spanish") {
			spanish.GetComponent<BoxCollider2D> ().enabled = false;
			spanish.transform.SetParent (basket.transform);
			spanish.transform.SetSiblingIndex (2);
			spanish.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (spanish, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(spanish));
			Invoke ("PizzaPrepared", 0.8f);
		}
	}

	//Lobstur Sauce
	private void FruitScreenActiveWithStrawberry(){
		vegetableScreen.SetActive (false);
		fruitScreen.SetActive (true);
		strawberry.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = strawberry.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionStrawberryWithBasket(){
		if (GameManager.instance.currentItem == "Strawberry") {
			strawberry.transform.SetParent (basket.transform);
			strawberry.transform.SetSiblingIndex (2);
			strawberry.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (strawberry, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(strawberry));
			Invoke ("SeaFoodScreenActiveWithSeaFish", 0.8f);
		}
	}

	private void SeaFoodScreenActiveWithSeaFish(){
		seaFoodScreen.SetActive (true);
		fruitScreen.SetActive (false);
		SeaFish.GetComponent<BoxCollider2D> ().enabled = true;
		HintImage.sprite = SeaFish.GetComponent<Image> ().sprite;
		SoundManager.instance.PlayActionSound ();
		HintImage.SetNativeSize ();
	}

	public void OnCollisionSeaFishWithBasket(){
		if (GameManager.instance.currentItem == "SeaFish") {
			SeaFish.GetComponent<BoxCollider2D> ().enabled = false;
			SeaFish.transform.SetParent (basket.transform);
			SeaFish.transform.SetSiblingIndex (2);
			SeaFish.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			MoveAction (SeaFish, basketUpperPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			//Onion.GetComponent<BoxCollider2D> ().enabled = true;
			StartCoroutine (itemsInBasket(SeaFish));
			Invoke ("HerbScreenActiveWithChilli", 0.8f);
		}
	}




	private void PizzaPrepared(){
		HintImage.gameObject.SetActive (false);
		Invoke ("GoodJobScreenActive", 0.5f);
	}

	private void GoodJobScreenActive(){
		SoundManager.instance.PlayActionSound ();
        goodJobScreen.SetActive (true);
		MoveAction (GoodJobText, GoodJobTextEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("NextActive", 2.0f);
	}

	private void NextActive(){
		SoundManager.instance.PlayLevelCompletedSound ();
		fireWorks.SetActive (true);
		goodJobScreen.SetActive (false);
		Invoke("NextBtnDelay", 2f);
	}

	void NextBtnDelay()
	{
		NextButton.SetActive(true);// add delay 5 secs
	}

	public void OnClickMenuBook(){
		SoundManager.instance.PlayButtonClickSound ();
		menuBookButton.SetActive (false);
		PizzaScreen.SetActive (true);
	}

	public void InActiveMenuBook(){
		SoundManager.instance.PlayButtonClickSound ();
		PizzaScreen.SetActive (false);
        menuBookButton.SetActive(true);
	}

	public void OnClickNext(){
		SoundManager.instance.PlayButtonClickSound ();
		fireWorks.SetActive (false);
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

	private void LoadingFull(){
		print ("Loading Completed");
		NavigationManager.instance.ReplaceScene (GameScene.PIZZAMAKINGVIEW);
	}
	#endregion


	#region Coroutine Methods
	IEnumerator itemsInBasket(GameObject obj){
		yield return new WaitForSeconds (0.5f);
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (obj, basketLowerPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		ScaleAction (obj, 0.5f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
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

	#endregion
}
