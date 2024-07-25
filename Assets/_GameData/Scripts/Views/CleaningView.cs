using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Notionhub;
public class CleaningView : MonoBehaviour {
	#region Variables, Constants & Initializers
	private bool mobFlag= true;
	private bool towelFlag= true;
	private int itemsCounter = 0;
	private int dayNo = -1; 
	public GameObject progressBar;
	public Image powerImage;
	public RectTransform progressBarEndPoint, progressBarStartPoint;
	public GameObject cleaner;
	public RectTransform cleanerEndPoint, cleanerOutSidePoint;
	public RectTransform cleanerItemsPoint;
	public GameObject Fruit, Apple, BottleCap, Mirror, can, paper;
	public GameObject mob;
	public RectTransform mobStartPoint, mobEndPoint;
	public Image water1, water2, water3;
	public GameObject towel;
	public RectTransform towelStartPoint, towelEndPoint;
	public Image dirt1, dirt2, dirt3;
	public GameObject Frame;
	public GameObject Next;
	public Image DayImage;
	public Sprite [] weekDays; 
	public GameObject LoadinBg;
	public Image LoadingFilled;
	public GameObject calenderScreen;
	public GameObject goodJobScreen;
	public GameObject GoodJobText;
	public GameObject fireworks;
	public RectTransform GoodJobTextEndPoint;
	#endregion

	#region Lifecycle Methods
	void Start () {
		ShowAd ();
		GameManager.instance.currentScene = GameUtils.CLEANING_VIEW;
		Invoke ("SetViewContents", 0.1f);
        PlayerPrefs.SetInt("ComingFromSplash", 0);
    }

	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region Utility Methods

	private void SetViewContents(){
		CheckCalender ();
	}

	private void ShowAd(){
        //AdsSDKManager ads = GameObject.FindObjectOfType<AdsSDKManager>();
        //if (ads != null)
        //{
        //    ads.ShowAdd();
        //}
    }


	private void CheckCalender(){
		dayNo = PlayerPrefs.GetInt ("WeekDay");
		DayImage.sprite = weekDays[dayNo];
		SoundManager.instance.PlayDayPopupSound ();
		ScaleAction (DayImage.gameObject, 1.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none );
		if (PlayerPrefs.GetInt ("WeekDay") < 6) {
			PlayerPrefs.SetInt ("WeekDay", PlayerPrefs.GetInt ("WeekDay") + 1);
		} 
		else {
			PlayerPrefs.SetInt ("WeekDay", 0);
		}

		calenderScreen.SetActive (true);
		Invoke ("SceneStarted", 3.0f);
	}

	private void SceneStarted(){
		calenderScreen.SetActive (false);
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

	private void ItemsGoingInCleaner(GameObject obj){
		obj.transform.SetParent (cleaner.transform);
		MoveAction (obj, cleanerItemsPoint, 0.3f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		ScaleAction (obj, 0.0f, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		itemsCounter++;
		if(itemsCounter >= 6){
			SoundManager.instance.PlayCleanerLoop (false);
			cleaner.transform.GetChild (0).gameObject.SetActive (false);
			Invoke ("CleanerGoesToStart", 0.5f);
		}
	}

	private void CleanerGoesToStart(){
		SoundManager.instance.PlaySwooshSound ();
		cleaner.GetComponent<ApplicatorListener> ().enabled = false;
		MoveAction (cleaner, cleanerEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("CleanerGoesOutside", 0.5f);
	}

	private void CleanerGoesOutside(){
		MoveAction (cleaner, cleanerOutSidePoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("mobActive", 0.5f);
	}


	private void mobActive(){
		mob.SetActive (true);
		MoveAction (mob, mobEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MobListenerOn", 0.6f);
	}

	private void MobListenerOn(){
		mob.GetComponent<ApplicatorListener> ().enabled = true;
		mob.GetComponent<BoxCollider2D> ().enabled = true;
		water1.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		water2.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		water3.gameObject.transform.GetChild (0).gameObject.SetActive (true);
	}

	private void MobGoesToStartPoint(){
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (mob, mobEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MobGoesOut",0.3f);
	}

	private void MobGoesOut(){
		MoveAction (mob, mobStartPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("towelActive",0.5f);
	}

	private void towelActive(){
		towel.SetActive (true);
		MoveAction (towel, towelEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("towelListenerOn", 0.6f);
	}

	private void towelListenerOn(){
		towel.GetComponent<ApplicatorListener> ().enabled = true;
		towel.GetComponent<BoxCollider2D> ().enabled = true;
		dirt1.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		dirt2.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		dirt3.gameObject.transform.GetChild (0).gameObject.SetActive (true);
	}

	private void TowelGoesToStartPoint(){
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (towel, towelEndPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("towelGoesOut",0.5f);
	}

	private void towelGoesOut(){
		MoveAction (towel, towelStartPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("FrameEnabled",0.4f);
	}

	private void FrameEnabled(){
		Frame.transform.GetChild (0).gameObject.SetActive (true);
		Frame.GetComponent<Button> ().enabled = true;
	}

	private void GoodJobScreenActive(){
		goodJobScreen.SetActive (true);
        SoundManager.instance.PlayActionSound();
        MoveAction (GoodJobText, GoodJobTextEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("NextActive", 2.0f);
	}

	private void NextActive(){
		goodJobScreen.SetActive (false);
		SoundManager.instance.PlayLevelCompletedSound ();
		fireworks.SetActive (true);
		Invoke("NextBtnDelay", 2f);
	}

	void NextBtnDelay()
	{
		Next.SetActive(true);// add delay 5 secs
	}
	#endregion

	#region Utility Methods
	public void OnCollisionWithCleaner(){
		if(GameManager.instance.currentItem == "Fruit"){
			ItemsGoingInCleaner(Fruit);
		}

		else if(GameManager.instance.currentItem == "Apple"){
			ItemsGoingInCleaner(Apple);

		}

		else if(GameManager.instance.currentItem == "BottleCap"){
			ItemsGoingInCleaner(BottleCap);

		}

		else if(GameManager.instance.currentItem == "Mirror"){
			ItemsGoingInCleaner(Mirror);

		}

		else if(GameManager.instance.currentItem == "Can"){
			ItemsGoingInCleaner(can);

		}

		else if(GameManager.instance.currentItem == "Paper"){
			ItemsGoingInCleaner(paper);

		}
	}

	public void mobBeginDrag(){
		if(mobFlag){
			MoveProgressBarComesInn ();
			mobFlag = false;
		}

	}

	public void mobEndDrag(){

	}

	public void OnCollisionMobBrush(){
		if (GameManager.instance.currentItem == "Water1") {
			SoundManager.instance.PlayRubbingLoop (true);
			colorDecreases (water1, 0.1f);
			powerImage.fillAmount = powerImage.fillAmount + 0.034f;
			if (water1.color.a < 0) {
				SoundManager.instance.PlayRubbingLoop (false);
				water1.transform.GetChild (0).gameObject.SetActive(false);
				water1.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				ParticleManger.instance.showPointingParticle (water1.gameObject);
				if (powerImage.fillAmount >= 1.0f) {
					water1.gameObject.SetActive (false);
					water1.gameObject.SetActive (false);
					water1.gameObject.SetActive (false);
					MoveProgressBarGoesOut ();
					mob.GetComponent<ApplicatorListener> ().enabled = false;
					MoveAction (mob, mobEndPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
					Invoke ("MobGoesToStartPoint", 0.7f);
				}
			}
		}

		if (GameManager.instance.currentItem == "Water2") {
			SoundManager.instance.PlayRubbingLoop (true);
			colorDecreases (water2, 0.1f);
			powerImage.fillAmount = powerImage.fillAmount + 0.034f;
			if (water2.color.a < 0) {
				SoundManager.instance.PlayRubbingLoop (false);
				water2.transform.GetChild (0).gameObject.SetActive(false);
				water2.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				ParticleManger.instance.showPointingParticle (water2.gameObject);
				if (powerImage.fillAmount >= 1.0f) {
					water1.gameObject.SetActive (false);
					water2.gameObject.SetActive (false);
					water3.gameObject.SetActive (false);
					MoveProgressBarGoesOut ();
					mob.GetComponent<ApplicatorListener> ().enabled = false;
					MoveAction (mob, mobEndPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
					Invoke ("MobGoesToStartPoint", 0.7f);
				}
			}
		}

		if (GameManager.instance.currentItem == "Water3") {
			colorDecreases (water3, 0.1f);
			SoundManager.instance.PlayRubbingLoop (true);
			powerImage.fillAmount = powerImage.fillAmount + 0.034f;
			if (water3.color.a < 0) {
				water3.transform.GetChild (0).gameObject.SetActive(false);
				water3.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				ParticleManger.instance.showPointingParticle (water3.gameObject);
				SoundManager.instance.PlayRubbingLoop (false);
				if (powerImage.fillAmount >= 1.0f) {
					water1.gameObject.SetActive (false);
					water2.gameObject.SetActive (false);
					water3.gameObject.SetActive (false);
					SoundManager.instance.PlayRubbingLoop (false);
					MoveProgressBarGoesOut ();
					mob.GetComponent<ApplicatorListener> ().enabled = false;
					MoveAction (mob, mobEndPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
					Invoke ("MobGoesToStartPoint", 0.7f);
				}
			}
		}
	}

	public void TowelBeginDrag(){
		if(towelFlag){
			MoveProgressBarComesInn ();
			towelFlag = false;
		}

	}
		
	public void OnCollisionTowel(){
		if (GameManager.instance.currentItem == "Dirt1") {
			SoundManager.instance.PlayRubbingLoop (true);
			colorDecreases (dirt1, 0.1f);
			powerImage.fillAmount = powerImage.fillAmount + 0.034f;
			if (dirt1.color.a < 0) {
				SoundManager.instance.PlayRubbingLoop (false);
				dirt1.transform.GetChild (0).gameObject.SetActive(false);
				dirt1.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				ParticleManger.instance.showPointingParticle (dirt1.gameObject);
				if (powerImage.fillAmount >= 1.0f) {
					dirt1.gameObject.SetActive (false);
					dirt2.gameObject.SetActive (false);
					dirt3.gameObject.SetActive (false);
					MoveProgressBarGoesOut ();
					towel.GetComponent<ApplicatorListener> ().enabled = false;
					MoveAction (towel, towelEndPoint, 0.4f, iTween.EaseType.easeInBack, iTween.LoopType.none);
					Invoke ("TowelGoesToStartPoint", 0.5f);
				}
			}
		}

		if (GameManager.instance.currentItem == "Dirt2") {
			SoundManager.instance.PlayRubbingLoop (true);
			colorDecreases (dirt2, 0.1f);
			powerImage.fillAmount = powerImage.fillAmount + 0.034f;
			if (dirt2.color.a < 0) {
				SoundManager.instance.PlayRubbingLoop (false);
				dirt2.transform.GetChild (0).gameObject.SetActive(false);
				dirt2.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				ParticleManger.instance.showPointingParticle (dirt2.gameObject);
				if (powerImage.fillAmount >= 1.0f) {
					dirt1.gameObject.SetActive (false);
					dirt2.gameObject.SetActive (false);
					dirt3.gameObject.SetActive (false);
					MoveProgressBarGoesOut ();
					towel.GetComponent<ApplicatorListener> ().enabled = false;
					MoveAction (towel, towelEndPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
					Invoke ("TowelGoesToStartPoint", 0.7f);
				}
			}
		}

		if (GameManager.instance.currentItem == "Dirt3") {
			colorDecreases (dirt3, 0.1f);
			SoundManager.instance.PlayRubbingLoop (true);
			powerImage.fillAmount = powerImage.fillAmount + 0.034f;
			if (dirt3.color.a < 0) {
				dirt3.transform.GetChild (0).gameObject.SetActive(false);
				dirt3.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				ParticleManger.instance.showPointingParticle (dirt3.gameObject);
				SoundManager.instance.PlayRubbingLoop (false);
				if (powerImage.fillAmount >= 1.0f) {
					dirt1.gameObject.SetActive (false);
					dirt2.gameObject.SetActive (false);
					dirt3.gameObject.SetActive (false);
					MoveProgressBarGoesOut ();
					towel.GetComponent<ApplicatorListener> ().enabled = false;
					MoveAction (towel, towelEndPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none);
					Invoke ("TowelGoesToStartPoint", 0.7f);
				}
			}
		}
	}

	public void OnClickFrame(){
		SoundManager.instance.PlayActionSound ();
		Frame.GetComponent<Button> ().enabled = false;
		Frame.transform.GetChild (0).gameObject.SetActive (false);
		RotateAction (Frame, -25.0f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke("GoodJobScreenActive", 0.8f);
	}

	public void OnClickNext(){
		fireworks.SetActive (false);
		SoundManager.instance.PlayButtonClickSound ();
		Next.SetActive (false);
		LoadingBgActive ();
	}

	private void LoadingBgActive(){
		LoadinBg.SetActive (true);
		StartCoroutine (FillAction(LoadingFilled));
		Invoke ("LoadingFull", 4.0f);
		Invoke("callAds", 2.0f);
	}

	void callAds()
	{
		//AssignAdIds_CB.instance.CallInterstitialAd(Adspref.GamePause);
	    //AdsManager.Instance.ShowInterstitial("Ad show  on loading Screen");

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
		NavigationManager.instance.ReplaceScene (GameScene.ORDERTAKINGVIEW);
	}
	#endregion
}
