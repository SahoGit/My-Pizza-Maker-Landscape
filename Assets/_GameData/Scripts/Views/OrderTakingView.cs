using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Notionhub;

public class OrderTakingView : MonoBehaviour {
	#region Variables, Constants & Initializers
	// Use this for initialization
	public GameObject [] customers;
	public RectTransform customerEndPoint;
    public GameObject menuBook;
    public GameObject playButton;
    public GameObject rotatingImage;
	public GameObject menuCard;
	public GameObject [] Ticks;
	public string[] orders;
	private string str;
	public Text [] description;
	public GameObject LoadinBg;
	public Image LoadingFilled;
	#endregion

	#region Lifecycle Methods
	void Start () {
		ShowAd ();
		GameManager.instance.currentScene = GameUtils.ORDERTAKING_VIEW;
		Invoke ("SetViewContents", 0.1f);
		Debug.Log(PlayerPrefs.GetInt("CustomerNo"));
	}

	// Update is called once per frame
	void Update () {

	}

	#endregion

	#region Utility Methods

	private void SetViewContents(){
		//PlayerPrefs.SetInt ("CustomerNo", 0);
		Invoke("CustomerComesInn", 0.5f);
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
		SoundManager.instance.PlaySwooshSound ();
		customers [PlayerPrefs.GetInt ("CustomerNo")].SetActive (true);
		Debug.Log(PlayerPrefs.GetInt("CustomerNo"));
		MoveAction (customers [PlayerPrefs.GetInt ("CustomerNo")], customerEndPoint, 0.5f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("ThinkingActive", 0.5f);

	}

    private void MenuBookActive()
    {
        SoundManager.instance.PlayActionSound();
        customers[PlayerPrefs.GetInt("CustomerNo")].transform.GetChild(0).gameObject.SetActive(false);
        menuBook.SetActive(true);
        playButton.SetActive(false);
        menuBook.GetComponent<ActionManager>().enabled = true;
        menuBook.GetComponent<Button>().enabled = true;
        rotatingImage.SetActive(true);

    }

    private void PlayBtnActive()
    {
        SoundManager.instance.PlayActionSound();
        customers[PlayerPrefs.GetInt("CustomerNo")].transform.GetChild(0).gameObject.SetActive(false);
        menuBook.SetActive(false);
        playButton.SetActive(true);
        playButton.GetComponent<ActionManager>().enabled = true;
        playButton.GetComponent<Button>().enabled = true;

    }

    private void ThinkingActive(){
		SoundManager.instance.PlayActionSound ();
		customers [PlayerPrefs.GetInt ("CustomerNo")].transform.GetChild (0).gameObject.SetActive (true);
		ScaleAction (customers[PlayerPrefs.GetInt ("CustomerNo")].transform.GetChild (0).gameObject, 1.0f, 0.3f, iTween.EaseType.linear, iTween.LoopType.none);
		Invoke ("WritingOrders", 0.4f );
	}

	private void WritingOrders(){
		int index = Random.Range(0, orders.Length);
	//	print ("value of index is"+index);
		StartCoroutine( AnimateText(orders[index]));
		SoundManager.instance.PlayWritingLoop (true);
		Invoke ("LoopOff", 4.8f);
		if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            Invoke("PlayBtnActive", 5.5f);
        }
		else
        {
            Invoke("MenuBookActive", 5.5f);
        }
	}

	private void LoopOff(){
		SoundManager.instance.PlayWritingLoop (false);
	}
    #endregion

    #region CallBack Methods
    public void OnClickMenuBook()
    {
        menuBook.GetComponent<ActionManager>().enabled = false;
        iTween.Stop(menuBook);
        menuBook.GetComponent<Button>().enabled = false;
        rotatingImage.SetActive(false);
        menuCard.SetActive(true);
    }

    public void OnClickPlayBtn()
    {
        if (PlayerPrefs.GetInt("CustomerNo") < 3)
        {
            PlayerPrefs.SetInt("CustomerNo", PlayerPrefs.GetInt("CustomerNo") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("CustomerNo", 0);
        }
        LoadingBgActive();
    }

    public void OnClickStart(){
		SoundManager.instance.PlayButtonClickSound ();
		if (PlayerPrefs.GetInt ("CustomerNo") < 3) {
			PlayerPrefs.SetInt ("CustomerNo", PlayerPrefs.GetInt ("CustomerNo") + 1);
		} else {
			PlayerPrefs.SetInt ("CustomerNo", 0);
		}

		print ("Value of Customer is"+PlayerPrefs.GetInt ("CustomerNo"));
		LoadingBgActive ();
	}

	private void AllTicksDisabled(){
		for(int i = 0; i < Ticks.Length; i++){
			Ticks [i].SetActive (false);
		}

	}

	public void SelectPizzaFlavour(int tag){
		SoundManager.instance.PlayActionSound ();
		GameManager.instance.SelectedPizzaFlavour = tag;
		AllTicksDisabled ();
		Ticks [tag].SetActive (true);
	//	print ("Value is"+GameManager.instance.SelectedPizzaFlavour);
	}

	private void LoadingBgActive(){
		LoadinBg.SetActive (true);
		StartCoroutine (FillAction(LoadingFilled));
		Invoke ("LoadingFull", 4.0f);
		//Invoke("callAds", 1.0f);
	}

	void callAds()
	{   
	    AdsManager.Instance.ShowInterstitial("Ad show  on loading Screen");

		//AssignAdIds_CB.instance.CallInterstitialAd(Adspref.GamePause);
	}

	private void LoadingFull(){
		print ("Loading Completed");
		NavigationManager.instance.ReplaceScene (GameScene.STORESHOPPINGVIEW);
	}
	#endregion


	#region Coroutine Methods
	IEnumerator AnimateText(string strComplete){
		if (PlayerPrefs.GetInt("CareerMode") == 1)
		{
            int i = 0;
			string myStr = "I want yummy " + PlayerPrefs.GetString("OrderName");
            str = "";
            while (i < myStr.Length)
            {
                str += myStr[i++];
                description[PlayerPrefs.GetInt("CustomerNo")].text = str;
                yield return new WaitForSeconds(0.08F);
            }
            
		}
		else
		{
            int i = 0;
            str = "";
            while (i < strComplete.Length)
            {
                str += strComplete[i++];
                description[PlayerPrefs.GetInt("CustomerNo")].text = str;
                yield return new WaitForSeconds(0.08F);
            }
        }
		
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
