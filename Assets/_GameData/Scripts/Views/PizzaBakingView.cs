using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Notionhub;

public class PizzaBakingView : MonoBehaviour {
	#region Variables, Constants & Initializers
	// Use this for initialization
	public GameObject OvenDoorOpen, OvenDoorClose;
	public GameObject PizzaHand;
	public RectTransform PizzaHandEndPoint;
	public GameObject Oven;
	public GameObject PizzaTray;
	public RectTransform PizzaTrayPosition, PizzaTrayOvenPosition;
	public GameObject OvenDoorHand;
	public GameObject OvenOnButton, OvenOffButton;
	public GameObject OvenArrow;
	public RectTransform OvenArrowEndPoint, OvenArrowStartPoint;
	private GameObject pizzaPrepared;
	public GameObject pizzaBakingBg;
	private GameObject bakedPizzaImage;
	public GameObject SmokeParticles;
	public GameObject ovenLight;

	public GameObject NextButton;
	public GameObject goodJobScreen;
	public GameObject GoodJobText;
	public RectTransform GoodJobTextEndPoint;
	#endregion

	#region Lifecycle Methods
	void Start () {
		ShowAd ();
		GameManager.instance.currentScene = GameUtils.PIZZABAKINGVIEW;
		Invoke ("SetViewContents", 0.1f);
	}

	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region Utility Methods

	private void SetViewContents(){
		SettingPizza ();
	}

	private void ShowAd(){
        //AdsSDKManager ads = GameObject.FindObjectOfType<AdsSDKManager>();
        //if (ads != null)
        //{
        //    ads.ShowAdd();
        //}
    }

	private void SettingPizza(){
		pizzaPrepared = GameManager.instance.player.GetPizza();
		pizzaPrepared.transform.SetParent (PizzaTray.transform);
		pizzaPrepared.GetComponent<RectTransform> ().localScale = new Vector3 (0.7f, 0.7f,0.7f);	
		pizzaPrepared.GetComponent<RectTransform> ().eulerAngles = new Vector3 (48.01f, 0.7f,0.93f);	
		pizzaPrepared.GetComponent<RectTransform>().localPosition = PizzaTrayPosition.gameObject.transform.position;
		PizzaTray.SetActive (true);	
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

//	private void MoveProgressBarComesInn(){
//		powerImage.fillAmount = 0;
//		MoveAction (progressBar,progressBarEndPoint,0.5f,iTween.EaseType.easeInOutBounce,iTween.LoopType.none);
//	}
//
//	private void MoveProgressBarGoesOut(){
//		MoveAction (progressBar,progressBarStartPoint,0.5f,iTween.EaseType.easeInOutBack,iTween.LoopType.none);
//	}

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

	private void PizzaTrayListenerOn(){
		PizzaHand.SetActive (true);
		MoveAction (PizzaHand, PizzaHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		PizzaTray.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void DoorOpenButtonEnabled(){
		OvenDoorHand.SetActive (true);
		OvenDoorOpen.GetComponent<Button> ().enabled = true;
	}

	#endregion


	#region Callback Methods
	public void OnClickDoorClose(){
		SoundManager.instance.PlayOvenDoorSound ();
		OvenDoorHand.SetActive (false);
		OvenDoorClose.GetComponent<Button> ().enabled = false;
		OvenDoorClose.SetActive (false);
		OvenDoorOpen.SetActive (true);
		Invoke ("PizzaTrayListenerOn", 0.3f);
	}

	public void OnCollisionWithOven(){
		SoundManager.instance.PlayCollisionSound ();
		PizzaHand.SetActive (false);
		PizzaTray.transform.SetParent (Oven.transform);
		PizzaTray.transform.SetAsFirstSibling ();
		PizzaTray.GetComponent<RectTransform> ().localScale = new Vector3 (0.8f, 0.8f, 0.8f);
		MoveAction (PizzaTray, PizzaTrayOvenPosition, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("DoorOpenButtonEnabled", 0.6f);
	}

	public void OnClickDoorOpen(){
		SoundManager.instance.PlayOvenDoorSound ();
		OvenDoorHand.SetActive (false);
		OvenDoorOpen.GetComponent<Button> ().enabled = false;
		OvenDoorOpen.SetActive (false);
		OvenDoorClose.SetActive (true);
		Invoke ("OvenButtonOffEnabled", 0.5f);
	}

	private void OvenButtonOffEnabled(){
		OvenOffButton.GetComponent<Button> ().enabled = true;
		OvenOffButton.GetComponent<ActionManager> ().enabled = true;
	}

	public void OnClickOvenOffButton(){
		SoundManager.instance.PlayOvenButtonOffSound ();
		OvenOffButton.GetComponent<ActionManager> ().enabled = false;
		OvenOffButton.GetComponent<Button> ().enabled = false;
		ovenLight.SetActive (true);
		iTween.Pause (OvenOffButton);
		OvenOffButton.SetActive (false);
		OvenOnButton.SetActive (true);
		MoveAction (OvenArrow, OvenArrowEndPoint, 6.0f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("OvenButtonOnEnabled", 6.3f);
		Invoke ("PizzaBecomeBaked", 2.0f);
	}

	private void PizzaBecomeBaked(){
		SmokeParticles.SetActive (true);
		SoundManager.instance.PlayFrySound ();
		PizzaTray.transform.GetChild (0).gameObject.transform.GetChild (7).gameObject.SetActive (true);
	}

	private void OvenButtonOnEnabled(){
		SoundManager.instance.PlayOvenButtonOnSound ();
		OvenOnButton.GetComponent<Button> ().enabled = true;
		OvenOnButton.GetComponent<ActionManager> ().enabled = true;
	}

	public void OnClickOvenOnButton(){
		SoundManager.instance.PlayOvenButtonOffSound ();
		OvenOnButton.GetComponent<Button> ().enabled = false;
		OvenArrow.transform.position = OvenArrowStartPoint.gameObject.transform.position;
		ovenLight.SetActive (false);
		OvenOnButton.SetActive (false);
		OvenOffButton.SetActive (true);
		OvenDoorClose.SetActive (false);
		OvenDoorOpen.SetActive (true);
		Invoke ("GoodJobScreenActive", 1.5f);
	}

	private void GoodJobScreenActive(){
		SoundManager.instance.PlayActionSound ();
        goodJobScreen.SetActive (true);
		MoveAction (GoodJobText, GoodJobTextEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("NextActive", 2.0f);
	}

	private void NextActive(){
		goodJobScreen.SetActive (false);
		Invoke("NextBtnDelay", 2f);
	}

	void NextBtnDelay()
	{
		NextButton.SetActive(true);// add delay 5 secs
	}

	private void PizzaInstantiate(){
		GameManager.instance.player.SetPizza(Instantiate(pizzaPrepared));
	}

	public void OnClickNext(){
		SoundManager.instance.PlayButtonClickSound ();
		if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            PizzaInstantiate();
            NavigationManager.instance.ReplaceScene(GameScene.PIZZAPACKINGMULTI);
        } else
        {
            PizzaInstantiate();
            NavigationManager.instance.ReplaceScene(GameScene.PIZZAPACKING);
        }
	}


	#endregion
}
