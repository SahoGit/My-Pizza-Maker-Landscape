using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Notionhub;

public class CashView : MonoBehaviour {
	#region Variables, Constants & Initializers
	// Use this for initialization
	//Cash Scene
	private int dollarCount = 0;
	public Image cashBlackScreen;
	public GameObject [] moneySets;
	public GameObject drawerHand, moneyHand;
	public RectTransform drawerHandEndPoint, moneyHandEndPoint;
	public GameObject drawerOpen, drawerClose;
	public GameObject NextButton;
	public GameObject goodJobScreen;
	public GameObject GoodJobText;
	public RectTransform GoodJobTextEndPoint;
	public GameObject LoadinBg;
	public Image LoadingFilled;
	public GameObject firework;
	public GameObject levelComplete;
	#endregion

	#region Lifecycle Methods
	void Start () {
		ShowAd ();
		GameManager.instance.currentScene = GameUtils.CASHVIEW;
		Invoke ("SetViewContents", 0.1f);
	}

	// Update is called once per frame
	void Update () {
	}

	#endregion

	#region Utility Methods

	private void SetViewContents(){
		cashSceneChanges();
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
		

	//Cash Scene
	private void cashSceneChanges(){
		cashBlackScreen.gameObject.SetActive (true);
		ruppeeSetChosen ();
		StartCoroutine (FadeOutAction(cashBlackScreen));
		Invoke ("drawerHandActive", 1.5f);

	}

	private void ruppeeSetChosen(){
		int i = Random.Range (0, moneySets.Length);
		moneySets [i].SetActive (true);
	}
		
	private void drawerHandActive(){
		cashBlackScreen.gameObject.SetActive (false);
		drawerClose.GetComponent<Button> ().enabled = true;
		drawerHand.SetActive (true);
		MoveAction (drawerHand, drawerHandEndPoint,0.5f, iTween.EaseType.linear, iTween.LoopType.loop);
	}

	private void CashHandActive(){
		moneyHand.SetActive (true);
		MoveAction (moneyHand, moneyHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
	}

	private void DrawerClose(){
		SoundManager.instance.PlayDrawerSound ();
		drawerOpen.SetActive (false);
		drawerClose.SetActive (true);
		Invoke ("showNext", 0.5f);
	}

	private void CheckCustomerAttended(){
        //if (PlayerPrefs.GetInt ("CustomersPizzaDelivered") < 3) {
        //	NavigationManager.instance.ReplaceScene (GameScene.ORDERTAKINGVIEW);
        //} else {
        //    if (PlayerPrefs.GetInt("FreeMode") == 1)
        //    {
        //        NavigationManager.instance.ReplaceScene(GameScene.CLEANINGVIEW);
        //    }
        //    else
        //    {
        //        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        //    }
        //}
        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        PlayerPrefs.SetInt ("CustomersPizzaDelivered", PlayerPrefs.GetInt ("CustomersPizzaDelivered") + 1);
	}
		
	private void showNext(){
		GoodJobScreenActive ();
	}
		
	#endregion

	#region Callback Methods

	//Cash Scene
	public void OnClickDrawer(){
		SoundManager.instance.PlayDrawerSound ();
		drawerHand.SetActive (false);
		drawerClose.SetActive (false);
		drawerOpen.SetActive (true);
		drawerClose.GetComponent<Button> ().enabled = false;
		Invoke ("CashHandActive", 0.5f);
	}

	public void OnCollisionOfDollars(){
		moneyHand.SetActive (false);
		dollarCount++;
		if (dollarCount >= 7) {
			for (int i = 0; i < moneySets.Length; i++) {
				moneySets [i].SetActive (false);
			}
			Invoke ("DrawerClose", 1.0f);
		}
	}
		

	private void GoodJobScreenActive(){
		SoundManager.instance.PlayActionSound ();
        goodJobScreen.SetActive (true);
		MoveAction (GoodJobText, GoodJobTextEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("NextActive", 2.0f);
	}

	private void NextActive(){
		goodJobScreen.SetActive (false);
		SoundManager.instance.PlayLevelCompletedSound ();
		firework.SetActive(true);
		levelComplete.SetActive(true);
		//Invoke("NextBtnDelay", 5f);
	}

	void NextBtnDelay()
    {
		NextButton.SetActive(true);// add delay 5 secs
	}


	public void OnClickNext()
	{
		levelComplete.SetActive(false);
		firework.SetActive(false);
		SoundManager.instance.PlayButtonClickSound();
		NextButton.SetActive(false);
		LoadingBgActive();
		//PlayerPrefs.SetInt(PlayerPrefs.GetString("OrderName"), 1);
		if (PlayerPrefs.GetInt(PlayerPrefs.GetString("OrderName")) == 0)
		{
			PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
		}
		PlayerPrefs.SetInt(PlayerPrefs.GetString("OrderName"), 1);
		PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 500);
	}

	public void OnClickHome()
	{
		levelComplete.SetActive(false);
		firework.SetActive(false);
		SoundManager.instance.PlayButtonClickSound();
		NextButton.SetActive(false);
		LoadingBgActive();
		//PlayerPrefs.SetInt(PlayerPrefs.GetString("OrderName"), 1);
		if (PlayerPrefs.GetInt(PlayerPrefs.GetString("OrderName")) == 0)
		{
			PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
		}
		PlayerPrefs.SetInt(PlayerPrefs.GetString("OrderName"), 1);
		PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 500);
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
		AdsManager.Instance.ShowInterstitial("Ad call on Loading Screen");
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
		CheckCustomerAttended ();
	}

	#endregion

	#region Coroutine Methods

	IEnumerator FadeOutAction (Image img){
		if (img.color.a >0) {
			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a - 0.009f);
			yield return new WaitForSeconds (0.004f);
			StartCoroutine (FadeOutAction (img));
		}  else if (img.color.a < 0) {
			StopCoroutine (FadeOutAction (img));
			cashBlackScreen.gameObject.SetActive (false);
		}
	}

	public void tripleReward()
	{
		 AdsManager.Instance.ShowRewarded(() =>
        {
        firework.SetActive(false);
		levelComplete.SetActive(false);
		if (PlayerPrefs.GetInt("Multiplayer") == 1)
		{
			PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 2000);
		}
		if (PlayerPrefs.GetInt("FreeMode") == 1)
		{
			PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 10000);
		}
		SoundManager.instance.PlayButtonClickSound();
		LoadingBgActive();
        }, "WATCH AD GET 2x COINS");

		
	}

//	parent = transform.parent;
//	transform.SetParent (transform.root);

//	GetComponent <RectTransform> ().anchoredPosition = anchorPos;
//	transform.SetParent (parent);
	#endregion
}
