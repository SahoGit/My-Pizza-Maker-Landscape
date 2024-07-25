using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Notionhub;

public class DoughMakingView : MonoBehaviour {
	#region Variables, Constants & Initializers
	private bool progressFlag = true;
	private bool sauceFlag = false;
	public GameObject progressBar;
	public Image powerImage;
	public RectTransform progressBarEndPoint, progressBarStartPoint;
	public GameObject originalDough, maskingDough;
	public GameObject sauce, sauseBrush;
	public RectTransform sauceBrushStartPoint, sauseEndPoint, sauseStartPoint;
	public GameObject rawImage;
	public Sprite redBrush;
	public GameObject CheeseBag;
	public Image PanCheese;
	public RectTransform CheeseBagEndPoint, CheeseBagSecondPosition, CheeseBagMovingPosition;

	public GameObject NextButton;
	public GameObject goodJobScreen;
	public GameObject GoodJobText;
	public RectTransform GoodJobTextEndPoint;
	public GameObject LoadinBg;
	public Image LoadingFilled;
	public GameObject firework;
	#endregion

	#region Lifecycle Methods
	void Start () {
		ShowAd ();
		GameManager.instance.currentScene = GameUtils.DOUGHMAKING_VIEW;
		Invoke ("SetViewContents", 0.1f);
	}

	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region Utility Methods

	private void SetViewContents(){
		SauceComeInn ();
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

	private void MoveProgressBarComesInn(){
		powerImage.fillAmount = 0;
		MoveAction (progressBar,progressBarEndPoint,0.5f,iTween.EaseType.easeInOutBounce,iTween.LoopType.none);
	}

	private void MoveProgressBarGoesOut(){
		MoveAction (progressBar,progressBarStartPoint,0.5f,iTween.EaseType.easeInOutBack,iTween.LoopType.none);
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

	private void SauceComeInn(){
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (sauce, sauseEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("sauseBrushListenerOn", 0.5f);

	}

	private void sauseBrushListenerOn(){
		sauseBrush.GetComponent<ActionManager> ().enabled = true;
		sauseBrush.GetComponent<ApplicatorListener> ().enabled = true;
		sauseBrush.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void SauceGoesOut(){
		MoveAction (sauce, sauseStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("CheeseBagComesInn", 0.5f);
	}

	private void CheeseBagComesInn(){
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (CheeseBag, CheeseBagEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke("CheeseBagActive", 0.5f);
	}

	private void CheeseBagActive(){
		CheeseBag.GetComponent<ActionManager> ().enabled = true;
		CheeseBag.GetComponent<BoxCollider2D> ().enabled = true;
		CheeseBag.GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void CheeseBagUpperPoint(){
		CheeseBag.gameObject.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0f, 0f, -70f);
		Invoke ("CheeseFilling", 0.3f);
	}

	private void CheeseFilling(){
		iTween.Resume (CheeseBag);
		CheeseBag.transform.GetChild (0).gameObject.SetActive (true);
		SoundManager.instance.PlayFlourLoop (true);
		MoveAction (CheeseBag, CheeseBagMovingPosition, 0.5f, iTween.EaseType.linear, iTween.LoopType.pingPong);
		StartCoroutine (FadeIntAction(PanCheese));
		Invoke ("CheeseStop", 4.0f);
	}

	private void CheeseStop(){
		CheeseBag.gameObject.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0f, 0f, 0f);
		CheeseBag.transform.GetChild (0).gameObject.SetActive (false);
		SoundManager.instance.PlayFlourLoop (false);
		iTween.Stop (CheeseBag);
		MoveAction (CheeseBag, CheeseBagSecondPosition, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("CheeseBagDisappear",0.3f);
	}

	private void CheeseBagDisappear(){
		StartCoroutine (FadeOutAction(CheeseBag.gameObject.GetComponent<Image>()));
		Invoke ("GoodJobScreenActive", 0.5f);
	}


	#endregion

	#region Callback Methods
	public void SauceBrushBeginDrag(){
		print ("there");
		sauseBrush .GetComponent<ActionManager> ().enabled = false;
		iTween.Stop (sauseBrush);
		if(sauceFlag){
		GameManager.instance.canDrawMask = true;
		}
	}

	public void SauceBrushEndDrag(){
		GameManager.instance.canDrawMask = false;
		SoundManager.instance.PlayRollingLoop (false);
	}

	public void OnCollisionWithSauseBrush(){
		if(GameManager.instance.currentItem == "Sauce"){
			print ("come there or not");
			sauseBrush.transform.GetChild(0).gameObject.GetComponent<Image> ().sprite = redBrush;
			rawImage.SetActive (true);
			sauceFlag = true;
			GameManager.instance.canDrawMask = true;
		}

		else if(GameManager.instance.currentItem == "RoughDough"){
		if (progressFlag) {
			MoveProgressBarComesInn ();
			progressFlag = false;
		}
		SoundManager.instance.PlayRollingLoop (true);
		powerImage.fillAmount = powerImage.fillAmount + 0.009f;
		if (powerImage.fillAmount >= 1) {
			SoundManager.instance.PlayRollingLoop (false);
			maskingDough.SetActive (false);
			originalDough.SetActive (true);
			sauseBrush.GetComponent<ApplicatorListener> ().enabled = false;
			MoveAction (sauseBrush, sauceBrushStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
			MoveProgressBarGoesOut ();
			Invoke ("SauceGoesOut", 1.0f);
			}
		}
	}

	public void CheeseBagBeginDrag(){
		CheeseBag.GetComponent<ActionManager> ().enabled = false;
		iTween.Stop (CheeseBag);
	}

	public void OnCollisionOfCheesePack(){
		MoveAction (CheeseBag, CheeseBagSecondPosition, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("CheeseBagUpperPoint", 0.5f);
	}

	private void GoodJobScreenActive(){
		goodJobScreen.SetActive (true);
		SoundManager.instance.PlayActionSound();
        MoveAction (GoodJobText, GoodJobTextEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("NextActive", 2.0f);
	}

	private void NextActive(){
		goodJobScreen.SetActive (false);
		SoundManager.instance.PlayLevelCompletedSound();
		firework.SetActive (true);
		Invoke("NextBtnDelay", 2f);
	}

	void NextBtnDelay()
	{
		NextButton.SetActive(true);// add delay 5 secs
	}

	public void OnClickNext(){
		SoundManager.instance.PlayButtonClickSound ();
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
		NavigationManager.instance.ReplaceScene (GameScene.PIZZADECORATIONVIEW);
	}

		
	#endregion

	#region Coroutine Methods
	IEnumerator FadeOutAction (Image img){
		if (img.color.a >0) {
			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a - 0.03f);
			yield return new WaitForSeconds (0.001f);
			StartCoroutine (FadeOutAction (img));
		}  else if (img.color.a < 0) {
			StopCoroutine (FadeOutAction (img));
		}
	}

	IEnumerator FadeIntAction (Image img){
		if (img.color.a < 1) {
			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a + 0.005f);
			yield return new WaitForSeconds (0.001f);
			StartCoroutine (FadeIntAction (img));
		}  else if (img.color.a >= 1) {
			StopCoroutine (FadeIntAction (img));
		}
	}

	#endregion
}
