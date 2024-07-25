﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Notionhub;
public class BeefAndVeggieView : MonoBehaviour {

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
		GameManager.instance.currentScene = GameUtils.BEEFANDVEGGIEVIEW;
		Invoke ("SetViewContents", 0.1f);
	}

	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region Utility Methods

	private void SetViewContents(){
		OrangePlateComesInn ();
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

	private void OrangePlateComesInn(){
		SoundManager.instance.PlaySwooshSound ();
		TomatoPlate.SetActive (true);
		MoveAction (TomatoPlate, TomatoPlateEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("makingOrangeListenerOn", 0.5f);
		Invoke ("pointingHandActive", 0.5f);
	}

	private void makingOrangeListenerOn(){
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
		MeatCuttingPointsParent.SetActive (true);
		Knife.SetActive (false);
		OnionKnife.SetActive (false);
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
		plateOnionHand.SetActive (false);
		OnionPieces [tomatopieceCounter].gameObject.transform.SetParent (OnionPlate.gameObject.transform);
		OnionPieces [tomatopieceCounter].gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
		MoveAction (OnionPieces[tomatopieceCounter], OnionPlateEndPoints[tomatopieceCounter], 0.3f, iTween.EaseType.linear, iTween.LoopType.none );
		Invoke ("plateOnionListenerOn", 0.3f);
	}

	private void plateOnionListenerOn(){
		SoundManager.instance.PlayItemComesSound ();
		print ("value is"+tomatopieceCounter);
		if (tomatopieceCounter > 0) {
			tomatopieceCounter--;
			OnionPieces [tomatopieceCounter].GetComponent<ApplicatorListener> ().enabled = true;
		} else {
			Invoke ("OnionPlateGoesOut", 0.5f);
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
		plateMeatHand.SetActive (false);
		MeatPieces [tomatopieceCounter].gameObject.transform.SetParent (MeatPlate.gameObject.transform);
		MeatPieces [tomatopieceCounter].gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.7f, 0.7f, 0.7f);
		MoveAction (MeatPieces[tomatopieceCounter], MeatPlateEndPoints[tomatopieceCounter], 0.3f, iTween.EaseType.linear, iTween.LoopType.none );
		Invoke ("plateMeatListenerOn", 0.3f);
	}

	private void plateMeatListenerOn(){
		SoundManager.instance.PlayItemComesSound ();
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
		Invoke("NextBtnDelay", 5f);
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
		//AssignAdIds_CB.instance.CallInterstitialAd(Adspref.GamePause)
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