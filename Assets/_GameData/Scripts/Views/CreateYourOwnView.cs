using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Notionhub;

public class CreateYourOwnView : MonoBehaviour {

	#region Variables, Constants & Initializers
	private int pieceCounter = 0;
	private int tomatopieceCounter = 4;
	public GameObject progressBar;
	public Image powerImage;
	public RectTransform progressBarEndPoint, progressBarStartPoint;
	public GameObject TomatoPlate, Tomato;
	public RectTransform TomatoBoardPoint,TomatoPlateEndPoint, TomatoPlateStartPoint;
	public GameObject pointingHand;
	public RectTransform pointingHandEndPoint;
	public GameObject Knife;
	public RectTransform knifeStartPoint;
	public RectTransform [] knifeCutPoints;
	public Sprite cuttingKnife, TableKnife;
	public GameObject [] tomatoesPieces;
	public RectTransform [] tomatoesPlateEndPoint;
	public GameObject plateTomatoHand;
	public RectTransform plateTomatoHandEndPoint;
	public GameObject tomatoCuttingPointsParent;
	//Onion Cutting
	public GameObject OnionPlate, Onion;
	public RectTransform OnionBoardPoint,OnionPlateEndPoint, OnionPlateStartPoint;
	public GameObject OnionpointingHand;
	public RectTransform OnionpointingHandEndPoint;
	public GameObject OnionKnife;
	public RectTransform OnionknifeStartPoint;
	public RectTransform [] OnionknifeCutPoints;
	public GameObject [] OnionPieces;
	public RectTransform [] OnionPlateEndPoints;
	public GameObject plateOnionHand;
	public RectTransform plateOnionHandEndPoint;
	public GameObject OnionCuttingPointsParent;

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
		GameManager.instance.currentScene = GameUtils.CREATEYOUROWNVIEW;
		Invoke ("SetViewContents", 0.1f);
	}

	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region Utility Methods

	private void SetViewContents(){
		TomatoPlateComesInn ();
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

	private void AllKnifeListenerOn(){
		OnionKnife.GetComponent<ApplicatorListener> ().enabled = true;
		MeatKnife.GetComponent<ApplicatorListener> ().enabled = true;
		Knife.GetComponent<ApplicatorListener> ().enabled = true;
		CapsicumKnife.GetComponent<ApplicatorListener> ().enabled = true;
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

	private void pointingHandActive(){
		pointingHand.SetActive (true);
		MoveAction (pointingHand, pointingHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
	}

	private void TomatoPlateComesInn(){
		SoundManager.instance.PlaySwooshSound ();
		TomatoPlate.SetActive (true);
		MoveAction (TomatoPlate, TomatoPlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingTomatoListenerOn", 0.5f);
		Invoke ("pointingHandActive", 0.5f);
	}

	private void makingTomatoListenerOn(){
		Tomato.GetComponent<ApplicatorListener> ().enabled = true;
		Tomato.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void KnifeListenerOn(){
		Knife.GetComponent<ApplicatorListener> ().enabled = true;
		Knife.GetComponent<BoxCollider2D> ().enabled = true;
		print ("value is"+pieceCounter);
		if (pieceCounter <= 3) {
			knifeCutPoints [pieceCounter].gameObject.SetActive (true);
		}
	}

	private void KnifeAnimatorOn(){
		SoundManager.instance.PlayKnifeCutSound ();
		Knife.GetComponent<Animator> ().SetBool ("KnifeCut", false);
		Invoke("KnifeAnimatorOff", 0.9f);
	}

	private void KnifeAnimatorOff(){
		Knife.GetComponent<Animator> ().SetBool ("KnifeCut", true);
		KnifeGoesToStartPoint ();
	}

	private void KnifeGoesToStartPoint(){
		powerImage.fillAmount = powerImage.fillAmount + 0.2f;
		Tomato.GetComponent<Image>().fillAmount = Tomato.GetComponent<Image>().fillAmount - 0.2f;
		tomatoesPieces[pieceCounter].gameObject.SetActive(true);
		MoveAction (Knife, knifeStartPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Knife.GetComponent<Image> ().sprite = TableKnife;
		Invoke ("AllKnifeListenerOn", 0.4f);
		pieceCounter++;
		Invoke ("KnifeListenerOn", 0.35f);
		if(pieceCounter >= 4){
			powerImage.fillAmount = 1.0f;
			tomatoesPieces[4].gameObject.SetActive(true);
			Tomato.GetComponent<Image> ().fillAmount = 0f;
			MoveProgressBarGoesOut ();
			Invoke ("PlateTomato1PieceListenerOn", 0.5f);
		}
	}

	private void PlateTomato1PieceListenerOn(){
		plateTomatoHand.SetActive (true);
		MoveAction (plateTomatoHand, plateTomatoHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		tomatoesPieces [tomatopieceCounter].GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void TomatoPlateGoesOut(){
		MoveAction (TomatoPlate, TomatoPlateStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none );
		Invoke ("OnionPlateComesInn", 0.5f);
	}

	//Onion Cutting
	private void OnionPlateComesInn(){
		SoundManager.instance.PlaySwooshSound ();
		pieceCounter = 0;
		tomatopieceCounter = 4;
		OnionPlate.SetActive (true);
		MoveAction (OnionPlate, OnionPlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingOnionListenerOn", 0.5f);
		Invoke ("OnionpointingHandActive", 0.5f);
	}

	private void makingOnionListenerOn(){
		tomatoCuttingPointsParent.SetActive (false);
		OnionCuttingPointsParent.SetActive (true);
		Knife.SetActive (false);
		OnionKnife.SetActive (true);
		Onion.GetComponent<ApplicatorListener> ().enabled = true;
		Onion.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void OnionpointingHandActive(){
		OnionKnife.SetActive (true);
		OnionpointingHand.SetActive (true);
		MoveAction (OnionpointingHand, OnionpointingHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
	}

	private void OnionKnifeListenerOn(){
		OnionKnife.GetComponent<ApplicatorListener> ().enabled = true;
		OnionKnife.GetComponent<BoxCollider2D> ().enabled = true;
		print ("value is"+pieceCounter);
		if (pieceCounter <= 3) {
			OnionknifeCutPoints [pieceCounter].gameObject.SetActive (true);
		}
	}

	private void firstOnionCutPointActive(){
		print ("onion value comes"+pieceCounter);
		OnionknifeCutPoints[pieceCounter].gameObject.SetActive (true);
	}

	private void OnionKnifeAnimatorOn(){
		SoundManager.instance.PlayKnifeCutSound ();
		OnionKnife.GetComponent<Animator> ().SetBool ("KnifeCut", false);
		Invoke("OnionKnifeAnimatorOff", 0.9f);
	}

	private void OnionKnifeAnimatorOff(){
		OnionKnife.GetComponent<Animator> ().SetBool ("KnifeCut", true);
		OnionKnifeGoesToStartPoint ();
	}

	private void OnionKnifeGoesToStartPoint(){
		powerImage.fillAmount = powerImage.fillAmount + 0.2f;
		Onion.GetComponent<Image>().fillAmount = Onion.GetComponent<Image>().fillAmount - 0.2f;
		OnionPieces[pieceCounter].gameObject.SetActive(true);
		MoveAction (OnionKnife, OnionknifeStartPoint, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		OnionKnife.GetComponent<Image> ().sprite = TableKnife;
		Invoke ("AllKnifeListenerOn", 0.4f);
		pieceCounter++;
		Invoke ("OnionKnifeListenerOn", 0.35f);
		if(pieceCounter >= 4){
			powerImage.fillAmount = 1.0f;
			OnionPieces[4].gameObject.SetActive(true);
			Onion.GetComponent<Image> ().fillAmount = 0f;
			MoveProgressBarGoesOut ();
			Invoke ("OnionPiecesPlateTomato1PieceListenerOn", 0.5f);
		}
	}

	private void OnionPiecesPlateTomato1PieceListenerOn(){
		plateOnionHand.SetActive (true);
		MoveAction (plateOnionHand, plateOnionHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		OnionPieces [tomatopieceCounter].GetComponent<ApplicatorListener> ().enabled = true;
	}

	private void OnionPlateGoesOut(){
		MoveAction (OnionPlate, OnionPlateStartPoint, 0.5f, iTween.EaseType.easeInBack, iTween.LoopType.none );
		Invoke ("CapsicumPlateComesInn", 0.5f);
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
		tomatoCuttingPointsParent.SetActive (false);
		OnionCuttingPointsParent.SetActive (false);
		CapsicumCuttingPointsParent.SetActive (true);
		Knife.SetActive (false);
		OnionKnife.SetActive (false);
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
		tomatoCuttingPointsParent.SetActive (false);
		OnionCuttingPointsParent.SetActive (false);
		CapsicumCuttingPointsParent.SetActive (false);
		MeatCuttingPointsParent.SetActive (true);
		Knife.SetActive (false);
		OnionKnife.SetActive (false);
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
		SoundManager.instance.PlaySwooshSound ();
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
	public void OnCollisionOfTomatoes(){
		SoundManager.instance.PlayItemComesSound ();
		pointingHand.SetActive (false);
		MoveAction (Tomato, TomatoBoardPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MoveProgressBarComesInn", 0.5f);
		Invoke ("KnifeListenerOn", 0.5f);
		Invoke ("firstCutPointActive", 0.5f);
	}

	public void OnCollisionWithKnife(){
		Knife.GetComponent<ApplicatorListener> ().enabled = false;
		if (GameManager.instance.currentItem == "KnifeCutPoint1") {
			Knife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (Knife, knifeCutPoints [0], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("KnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPoint2") {
			Knife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (Knife, knifeCutPoints [1], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("KnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPoint3") {
			Knife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (Knife, knifeCutPoints [2], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("KnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPoint4") {
			Knife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (Knife, knifeCutPoints [3], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("KnifeAnimatorOn", 0.3f);
		}
	}


	public void OnCollisionTomatoWithPlate(){
		SoundManager.instance.PlayItemComesSound ();
		plateTomatoHand.SetActive (false);
		tomatoesPieces [tomatopieceCounter].gameObject.transform.SetParent (TomatoPlate.gameObject.transform);
		tomatoesPieces [tomatopieceCounter].gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
		MoveAction (tomatoesPieces[tomatopieceCounter], tomatoesPlateEndPoint[tomatopieceCounter], 0.3f, iTween.EaseType.linear, iTween.LoopType.none );
		Invoke ("plateTomatoListenerOn", 0.3f);
	}

	private void plateTomatoListenerOn(){
		print ("value is"+tomatopieceCounter);
		if (tomatopieceCounter > 0) {
			tomatopieceCounter--;
			tomatoesPieces [tomatopieceCounter].GetComponent<ApplicatorListener> ().enabled = true;
		} else {
			Invoke ("TomatoPlateGoesOut", 0.5f);
		}

	}

	//Onion Cutting

	public void OnCollisionOfOnion(){
		SoundManager.instance.PlayItemComesSound ();
		OnionpointingHand.SetActive (false);
		MoveAction (Onion, TomatoBoardPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("MoveProgressBarComesInn", 0.5f);
		Invoke ("OnionKnifeListenerOn", 0.5f);
		Invoke ("firstOnionCutPointActive", 0.5f);
	}

	public void OnCollisionWithOnionKnife(){
		OnionKnife.GetComponent<ApplicatorListener> ().enabled = false;
		if (GameManager.instance.currentItem == "KnifeCutPointOnion1") {
			OnionKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (OnionKnife, OnionknifeCutPoints [0], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("OnionKnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPointOnion2") {
			OnionKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (OnionKnife, OnionknifeCutPoints [1], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("OnionKnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPointOnion3") {
			OnionKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (OnionKnife, OnionknifeCutPoints [2], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("OnionKnifeAnimatorOn", 0.3f);
		}

		if (GameManager.instance.currentItem == "KnifeCutPointOnion4") {
			OnionKnife.GetComponent<Image> ().sprite = cuttingKnife;
			MoveAction (OnionKnife, OnionknifeCutPoints [3], 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
			Invoke ("OnionKnifeAnimatorOn", 0.3f);
		}
	}

	public void OnCollisionOnionWithPlate(){
		SoundManager.instance.PlayItemComesSound ();
		plateOnionHand.SetActive (false);
		OnionPieces [tomatopieceCounter].gameObject.transform.SetParent (OnionPlate.gameObject.transform);
		OnionPieces [tomatopieceCounter].gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
		MoveAction (OnionPieces[tomatopieceCounter], OnionPlateEndPoints[tomatopieceCounter], 0.3f, iTween.EaseType.linear, iTween.LoopType.none );
		Invoke ("plateOnionListenerOn", 0.3f);
	}

	private void plateOnionListenerOn(){
		print ("value is"+tomatopieceCounter);
		if (tomatopieceCounter > 0) {
			tomatopieceCounter--;
			OnionPieces [tomatopieceCounter].GetComponent<ApplicatorListener> ().enabled = true;
		} else {
			Invoke ("OnionPlateGoesOut", 0.5f);
		}

	}


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
		plateOnionHand.SetActive (false);
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
		goodJobScreen.SetActive (false);
		SoundManager.instance.PlayLevelCompletedSound ();
		fireworks.SetActive (true);
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
