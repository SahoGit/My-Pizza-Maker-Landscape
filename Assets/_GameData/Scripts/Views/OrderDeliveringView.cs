using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Notionhub;

public class OrderDeliveringView : MonoBehaviour {

	#region Variables, Constants & Initializers
	// Use this for initialization
	private int customerIndex = -1;
	private int index = -1;
	public GameObject [] customers;
	public RectTransform customerEndPoint;
	public GameObject PizzaHand;
	public RectTransform PizzaHandEndPoint;
	public GameObject PizzaPacked;
	public RectTransform PizzaPackedCounterPoint, PizzaPackedEndPoint;
	public GameObject Currency;
	public RectTransform CurrencyEndPoint;
	public GameObject[] ThankyouText;
	public GameObject Next;
	public Image BlackScreen;
	public GameObject LoadinBg;
	public Image LoadingFilled;
	#endregion

	#region Lifecycle Methods
	void Start () {
		ShowAd ();
		GameManager.instance.currentScene = GameUtils.ORDERDELIVERINGVIEW;
		Invoke ("SetViewContents", 0.1f);
	}

	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region Utility Methods

	private void SetViewContents(){
		StartCoroutine (FadeOutAction(BlackScreen));
		CustomerComesInn ();
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

	private void CustomerComesInn(){
		print ("Value of Customer is"+PlayerPrefs.GetInt ("CustomerNo"));
		if (PlayerPrefs.GetInt ("CustomerNo") == 0) {
			customerIndex = 3;
		} else {
			customerIndex = PlayerPrefs.GetInt ("CustomerNo");
			customerIndex = customerIndex - 1;
		}

		customers [customerIndex].SetActive (true);
        Debug.Log(customerIndex);
        Invoke ("PizzaComesInn", 1.5f);
	}

	private void PizzaComesInn(){
		SoundManager.instance.PlaySwooshSound ();
		MoveAction (PizzaPacked, PizzaPackedCounterPoint, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("PizzaHandActive", 0.6f);
	}

	private void PizzaHandActive(){
		PizzaHand.SetActive (true);
		MoveAction (PizzaHand, PizzaHandEndPoint, 1.0f, iTween.EaseType.linear, iTween.LoopType.loop);
		PizzaPacked.GetComponent<ApplicatorListener> ().enabled = true;
	}

	public void OnCollisionWithCustomer(){
		SoundManager.instance.PlayCollisionSound ();
		PizzaHand.SetActive (false);
		PizzaPacked.GetComponent<ApplicatorListener> ().enabled = false;
		PizzaPacked.transform.SetParent (customers [customerIndex].transform);
		MoveAction (PizzaPacked, PizzaPackedEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		ScaleAction (PizzaPacked, 0.8f, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("TextActive", 1.0f);
	}

	private void TextActive(){
		index = Random.Range (0, ThankyouText.Length);
		SoundManager.instance.PlayActionSound ();
		ThankyouText [index].SetActive (true);
		ScaleAction (ThankyouText [index], 1.0f, 0.5f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
		Invoke ("CurrencyActive", 2.0f);
	}

	private void CurrencyActive(){
		ThankyouText [index].SetActive (false);
		ParticleManger.instance.showPointingParticle (Currency.gameObject);
		ScaleAction (Currency, 1.0f, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("CurrencyButtonEnabled", 0.3f);
	}

	private void CurrencyButtonEnabled(){
		Currency.GetComponent<ActionManager> ().enabled = true;
		Currency.GetComponent<Button> ().enabled = true;
	}

	private void NextButtonEnabled(){
		Next.SetActive (true);
	}

	public void OnClicCurrency(){
		SoundManager.instance.PlayCoinsSound();
		Currency.GetComponent<Button> ().enabled = false;
		MoveAction (Currency, CurrencyEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("LoadingBgActive", 0.5f);
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
		NavigationManager.instance.ReplaceScene (GameScene.CASHVIEW);
	}


	IEnumerator FadeOutAction (Image img){
		if (img.color.a >0) {
			img.color = new Vector4 (img.color.r,img.color.g,img.color.b, img.color.a - 0.03f);
			yield return new WaitForSeconds (0.001f);
			StartCoroutine (FadeOutAction (img));
		}  else if (img.color.a < 0) {
			BlackScreen.gameObject.SetActive (false);
			StopCoroutine (FadeOutAction (img));
		}
	}

	#endregion

}
