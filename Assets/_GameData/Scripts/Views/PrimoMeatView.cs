using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Notionhub;
public class PrimoMeatView : MonoBehaviour {
	#region Variables, Constants & Initializers
	private int pieceCounter = 0;
	private int tomatopieceCounter = 4;
	public GameObject progressBar;
	public Image powerImage;
	public RectTransform progressBarEndPoint, progressBarStartPoint;
	public RectTransform TomatoBoardPoint,TomatoPlateEndPoint, TomatoPlateStartPoint;
	public Sprite cuttingKnife, TableKnife;


	//Capsicum Cutting
	public GameObject CapsicumPlate, Capsicum;
	public RectTransform CapsicumBoardPoint,CapsicumPlateEndPoint, CapsicumPlateStartPoint;
	public GameObject CapsicumpointingHand;
	public RectTransform CapsicumpointingHandEndPoint;
	public GameObject CapsicumKnife;
	public RectTransform CapsicumknifeStartPoint;
	public RectTransform [] CapsicumknifeCutPoints;
	public GameObject [] CapsicumPieces;
	public RectTransform [] CapsicumPlateEndPoints;
	public GameObject plateCapsicumHand;
	public RectTransform plateCapsicumHandEndPoint;
	public GameObject CapsicumCuttingPointsParent;

	//Meat Cutting
	public GameObject MeatPlate, Meat;
	public RectTransform MeatBoardPoint, MeatPlateEndPoint, MeatPlateStartPoint;
	public GameObject MeatpointingHand;
	public RectTransform MeatpointingHandEndPoint;
	public GameObject MeatKnife;
	public RectTransform MeatknifeStartPoint;
	public RectTransform [] MeatknifeCutPoints;
	public GameObject [] MeatPieces;
	public RectTransform [] MeatPlateEndPoints;
	public GameObject plateMeatHand;
	public RectTransform plateMeatHandEndPoint;
	public GameObject MeatCuttingPointsParent;

	public GameObject NextButton;
	public GameObject goodJobScreen;
	public GameObject GoodJobText;
	public RectTransform GoodJobTextEndPoint;
	public GameObject LoadinBg;
	public Image LoadingFilled;
	public GameObject fireworks;
	#endregion

	#region Lifecycle Methods
	void Start () {
		ShowAd ();
		GameManager.instance.currentScene = GameUtils.FISHANDVEGGIECUTTINGVIEW;
		Invoke ("SetViewContents", 0.1f);
	}

	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region Utility Methods

	private void SetViewContents(){
		CapsicumPlateComesInn ();
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

	private void AllKnifeListenerOn(){
		CapsicumKnife.GetComponent<ApplicatorListener> ().enabled = true;
		MeatKnife.GetComponent<ApplicatorListener> ().enabled = true;
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

	//Capsicum Cutting
	private void CapsicumPlateComesInn(){
		SoundManager.instance.PlaySwooshSound ();
		pieceCounter = 0;
		tomatopieceCounter = 4;
		CapsicumPlate.SetActive (true);
		MoveAction (CapsicumPlate, CapsicumPlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingCapsicumListenerOn", 0.5f);
		Invoke ("CapsicumpointingHandActive", 0.5f);
	}

	private void makingCapsicumListenerOn(){
		CapsicumCuttingPointsParent.SetActive (true);
		CapsicumKnife.SetActive (true);
		Capsicum.GetComponent<ApplicatorListener> ().enabled = true;
		Capsicum.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void CapsicumpointingHandActive(){
		CapsicumKnife.SetActive (true);
		CapsicumpointingHand.SetActive (true);
		MoveAction (CapsicumpointingHand, CapsicumpointingHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
	}

	private void CapsicumKnifeListenerOn(){
		CapsicumKnife.GetComponent<ApplicatorListener> ().enabled = true;
		CapsicumKnife.GetComponent<BoxCollider2D> ().enabled = true;
		print ("value is"+pieceCounter);
		if (pieceCounter <= 3) {
			CapsicumknifeCutPoints [pieceCounter].gameObject.SetActive (true);
		}
	}

	private void firstCapsicumKnifePointActive(){
		print ("Capsicum value comes"+pieceCounter);
		CapsicumknifeCutPoints[pieceCounter].gameObject.SetActive (true);
	}

	private void CapsicumKnifeAnimatorOn(){
		SoundManager.instance.PlayKnifeCutSound ();
		CapsicumKnife.GetComponent<Animator> ().SetBool ("KnifeCut", false);
		Invoke("CapsicumKnifeAnimatorOff", 0.9f);
	}

	private void CapsicumKnifeAnimatorOff(){
		CapsicumKnife.GetComponent<Animator> ().SetBool ("KnifeCut", true);
		CapsicumKnifeGoesToStartPoint ();
	}

	private void CapsicumKnifeGoesToStartPoint(){
		powerImage.fillAmount = powerImage.fillAmount + 0.2f;
		Capsicum.GetComponent<Image>().fillAmount = Capsicum.GetComponent<Image>().fillAmount - 0.2f;
		CapsicumPieces[pieceCounter].gameObject.SetActive(true);
		MoveAction (CapsicumKnife, CapsicumknifeStartPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		CapsicumKnife.GetComponent<Image> ().sprite = TableKnife;
		Invoke ("AllKnifeListenerOn", 0.4f);
		pieceCounter++;
		Invoke ("CapsicumKnifeListenerOn", 0.35f);
		if(pieceCounter >= 4){
			powerImage.fillAmount = 1.0f;
			CapsicumPieces[4].gameObject.SetActive(true);
			Capsicum.GetComponent<Image> ().fillAmount = 0f;
			MoveProgressBarGoesOut ();
			Invoke ("CapsicumPiece1ListenerOn", 0.5f);
		}
	}

	private void CapsicumPiece1ListenerOn(){
		plateCapsicumHand.SetActive (true);
		MoveAction (plateCapsicumHand, plateCapsicumHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		CapsicumPieces [tomatopieceCounter].GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void CapsicumPlateGoesOut(){
		MoveAction (CapsicumPlate, CapsicumPlateStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none );
		Invoke ("MeatPlateComesInn", 0.5f);
	}

	//Meat Cutting
	private void MeatPlateComesInn(){
		SoundManager.instance.PlaySwooshSound ();
		pieceCounter = 0;
		tomatopieceCounter = 4;
		MeatPlate.SetActive (true);
		MoveAction (MeatPlate, MeatPlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingMeatListenerOn", 0.5f);
		Invoke ("MeatpointingHandActive", 0.5f);
	}

	private void makingMeatListenerOn(){
		CapsicumCuttingPointsParent.SetActive (false);
		MeatCuttingPointsParent.SetActive (true);
		CapsicumKnife.SetActive (false);
		MeatKnife.SetActive (true);
		Meat.GetComponent<ApplicatorListener> ().enabled = true;
		Meat.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void MeatpointingHandActive(){
		MeatpointingHand.SetActive (true);
		MoveAction (MeatpointingHand, MeatpointingHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
	}

	private void MeatKnifeListenerOn(){
		MeatKnife.GetComponent<ApplicatorListener> ().enabled = true;
		MeatKnife.GetComponent<BoxCollider2D> ().enabled = true;
		print ("value is"+pieceCounter);
		if (pieceCounter <= 3) {
			MeatknifeCutPoints [pieceCounter].gameObject.SetActive (true);
		}
	}

	private void firstMeatCutPointActive(){
		print ("meat value comes"+pieceCounter);
		MeatknifeCutPoints[pieceCounter].gameObject.SetActive (true);
	}

	private void MeatKnifeAnimatorOn(){
		SoundManager.instance.PlayKnifeCutSound ();
		MeatKnife.GetComponent<Animator> ().SetBool ("KnifeCut", false);
		Invoke("MeatKnifeAnimatorOff", 0.9f);
	}

	private void MeatKnifeAnimatorOff(){
		MeatKnife.GetComponent<Animator> ().SetBool ("KnifeCut", true);
		MeatKnifeGoesToStartPoint ();
	}

	private void MeatKnifeGoesToStartPoint(){
		powerImage.fillAmount = powerImage.fillAmount + 0.2f;
		Meat.GetComponent<Image>().fillAmount = Meat.GetComponent<Image>().fillAmount - 0.15f;
		MeatPieces[pieceCounter].gameObject.SetActive(true);
		MoveAction (MeatKnife, MeatknifeStartPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		MeatKnife.GetComponent<Image> ().sprite = TableKnife;
		Invoke ("AllKnifeListenerOn", 0.4f);
		pieceCounter++;
		Invoke ("MeatKnifeListenerOn", 0.35f);
		if(pieceCounter >= 4){
			powerImage.fillAmount = 1.0f;
			MeatPieces[4].gameObject.SetActive(true);
			Meat.GetComponent<Image> ().fillAmount = 0f;
			MoveProgressBarGoesOut ();
			Invoke ("MeatPiece1ListenerOn", 0.5f);
		}
	}

	private void MeatPiece1ListenerOn(){
		plateMeatHand.SetActive (true);
		MoveAction (plateMeatHand, plateMeatHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		MeatPieces [tomatopieceCounter].GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void MeatPlateGoesOut(){
		MoveAction (MeatPlate, MeatPlateStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none );
		Invoke ("GoodJobScreenActive", 1.0f);
	}

	#endregion

	#region CallBack Methods

	//Capsicum Cutting

	public void OnCollisionOfCapsicum(){
		SoundManager.instance.PlayItemComesSound ();
		CapsicumpointingHand.SetActive (false);
		MoveAction (Capsicum, CapsicumBoardPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MoveProgressBarComesInn", 0.5f);
		Invoke ("CapsicumKnifeListenerOn", 0.5f);
		Invoke ("firstCapsicumKnifePointActive", 0.5f);
	}

	public void OnCollisionWithCapsicumKnife(){
		CapsicumKnife.GetComponent<ApplicatorListener> ().enabled = false;
		if (GameManager.instance.currentItem == "KnifeCutPointCapsicum1") {
			CapsicumKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (CapsicumKnife, CapsicumknifeCutPoints [0], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("CapsicumKnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPointCapsicum2") {
			CapsicumKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (CapsicumKnife, CapsicumknifeCutPoints [1], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("CapsicumKnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPointCapsicum3") {
			CapsicumKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (CapsicumKnife, CapsicumknifeCutPoints [2], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("CapsicumKnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPointCapsicum4") {
			CapsicumKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (CapsicumKnife, CapsicumknifeCutPoints [3], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("CapsicumKnifeAnimatorOn", 0.3f);
		}
	}

	public void OnCollisionCapsicumWithPlate(){
		SoundManager.instance.PlayItemComesSound ();
		plateCapsicumHand.SetActive (false);
		CapsicumPieces [tomatopieceCounter].gameObject.transform.SetParent (CapsicumPlate.gameObject.transform);
		CapsicumPieces [tomatopieceCounter].gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
		MoveAction (CapsicumPieces[tomatopieceCounter], CapsicumPlateEndPoints[tomatopieceCounter], 0.3f, iTween.EaseType.linear, iTween.LoopType.none );
		Invoke ("plateCapsicumListenerOn", 0.3f);
	}

	private void plateCapsicumListenerOn(){
		print ("value is"+tomatopieceCounter);
		if (tomatopieceCounter > 0) {
			tomatopieceCounter--;
			CapsicumPieces [tomatopieceCounter].GetComponent<ApplicatorListener> ().enabled = true;
		} else {
			Invoke ("CapsicumPlateGoesOut", 0.5f);
		}

	}
	//Meat Cutting

	public void OnCollisionOfMeat(){
		SoundManager.instance.PlayItemComesSound ();
		MeatpointingHand.SetActive (false);
		MoveAction (Meat, TomatoBoardPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MoveProgressBarComesInn", 0.5f);
		Invoke ("MeatKnifeListenerOn", 0.5f);
		Invoke ("firstMeatCutPointActive", 0.5f);
	}

	public void OnCollisionWithMeatKnife(){
		MeatKnife.GetComponent<ApplicatorListener> ().enabled = false;
		if (GameManager.instance.currentItem == "KnifeCutPointMeat1") {
			MeatKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (MeatKnife, MeatknifeCutPoints [0], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("MeatKnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPointMeat2") {
			MeatKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (MeatKnife, MeatknifeCutPoints [1], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("MeatKnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPointMeat3") {
			MeatKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (MeatKnife, MeatknifeCutPoints [2], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("MeatKnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPointMeat4") {
			MeatKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (MeatKnife, MeatknifeCutPoints [3], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("MeatKnifeAnimatorOn", 0.3f);
		}
	}

	public void OnCollisionMeatWithPlate(){
		SoundManager.instance.PlayItemComesSound ();
		plateMeatHand.SetActive (false);
		MeatPieces [tomatopieceCounter].gameObject.transform.SetParent (MeatPlate.gameObject.transform);
		MeatPieces [tomatopieceCounter].gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		MoveAction (MeatPieces[tomatopieceCounter], MeatPlateEndPoints[tomatopieceCounter], 0.3f, iTween.EaseType.linear, iTween.LoopType.none );
		Invoke ("plateMeatListenerOn", 0.3f);
	}

	private void plateMeatListenerOn(){
		if (tomatopieceCounter > 0) {
			tomatopieceCounter--;
			MeatPieces [tomatopieceCounter].GetComponent<ApplicatorListener> ().enabled = true;
		} else {
			Invoke ("MeatPlateGoesOut", 0.5f);
		}
	}


	private void GoodJobScreenActive(){
		SoundManager.instance.PlayActionSound ();
        goodJobScreen.SetActive (true);
		MoveAction (GoodJobText, GoodJobTextEndPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("NextActive", 2.0f);
	}

	private void NextActive(){
		SoundManager.instance.PlayLevelCompletedSound ();
		fireworks.SetActive (true);
		goodJobScreen.SetActive (false);
		Invoke("NextBtnDelay", 2f);
	}

	void NextBtnDelay()
	{
		NextButton.SetActive(true);// add delay 5 secs
	}

	public void OnClickNext(){
		fireworks.SetActive (false);
		SoundManager.instance.PlayButtonClickSound ();
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
		NavigationManager.instance.ReplaceScene (GameScene.DOUGHMAKINGVIEW);
	}


	#endregion
}
