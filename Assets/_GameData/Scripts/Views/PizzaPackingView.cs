using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PizzaPackingView : MonoBehaviour {

	#region Variables, Constants & Initializers
	// Use this for initialization
	private GameObject pizza;
	public GameObject PizzaTray;
	public RectTransform PizzaTrayPosition;
    public GameObject topPacking1, topPacking2, topPacking3, topPacking4;
    public GameObject AitopPacking1, AitopPacking2, AitopPacking3, AitopPacking4;
    public GameObject Next;
	public GameObject LoadinBg;
	public Image LoadingFilled;
	public GameObject firework;
	public GameObject levelComplete;

	public GameObject AiCharacter;
    public GameObject WaitingForOpp;
    public Text WaitingText;

    public Text OppScore;
	public Text PlayerScore;
	public Text completeLevelText;

	public GameObject OppScorBg;
    public GameObject playerWinnerMsg;
    public GameObject oppWinnerMsg;

    public bool isWinner;


    #endregion

    #region Lifecycle Methods
    void Start () {
		
		GameManager.instance.currentScene = GameUtils.PIZZAPACKINGVIEW;
		Invoke ("SetViewContents", 0.1f);
        if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            AiCharacter.SetActive(false);
            WaitingForOpp.SetActive(true);
            StartCoroutine(Countdown(3));
        }
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {

            // display something...
            WaitingText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

        // count down is finished...
        AiCharacterShow();
    }

    void AiCharacterShow()
    {
        AiCharacter.SetActive(true);
        WaitingForOpp.SetActive(false);
        SoundManager.instance.PlayCollisionSound();
		OppScorBg.SetActive(true);
		Invoke("OppScoreAdd", 1.0f);

    }


    void OppScoreAdd()
    {

        SoundManager.instance.PlayLevelCompletedSound();
        OppScore.text = Random.Range(295, 300).ToString();
        Invoke("PlayerScoreAdd", 1.0f);
    }

    void PlayerScoreAdd()
    {
		int scoreDiff = Random.Range(Random.Range(-3, -1), Random.Range(-1, 10));
		int playerFinalScore = int.Parse(OppScore.text) + scoreDiff;
        SoundManager.instance.PlayLevelCompletedSound();
        PlayerScore.text = playerFinalScore.ToString();
		if (int.Parse(OppScore.text) < playerFinalScore)
		{
			isWinner = true;
		}
		Invoke("WinnerDeclare", 2.0f);
    }

	void WinnerDeclare()
	{
		if (isWinner)
        {
            playerWinnerMsg.SetActive(true);
            SoundManager.instance.PlayLevelCompletedSound();
        } else
		{
            oppWinnerMsg.SetActive(true);
            SoundManager.instance.PlayLevelCompletedSound();
        }
        Invoke("NextActive", 0.5f);
    }

    #endregion

    #region Utility Methods

    private void SetViewContents(){
		SettingPizza ();
	}

	private void SettingPizza(){
		pizza = GameManager.instance.player.GetPizza();
		pizza.transform.SetParent (PizzaTray.transform);
		pizza.GetComponent<RectTransform> ().localScale = new Vector3 (0.75f, 0.75f,0.75f);	
		pizza.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0f, 0f, 0f);	
		pizza.GetComponent<RectTransform>().localPosition = PizzaTrayPosition.gameObject.transform.position;
		PizzaTray.gameObject.SetActive (true);	
		PizzaTray.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.GetComponent<Image> ().enabled = false;
        if (PlayerPrefs.GetInt("FreeMode") == 1 || PlayerPrefs.GetInt("CareerMode") == 1)
        {
            Invoke("Top1Inactive", 5.0f);
        }
        //Invoke ("Top1Inactive", 15.0f);
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

	private void Top1Inactive(){
		SoundManager.instance.PlayCollisionSound ();
		if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            AitopPacking1.SetActive(false);
            AitopPacking2.SetActive(true);
        }
        topPacking1.SetActive(false);
        topPacking2.SetActive(true);
        Invoke ("Top2Inactive", 0.15f);
	}

	private void Top2Inactive(){
        if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            AitopPacking2.SetActive(false);
            AitopPacking3.SetActive(true);
        }
        topPacking2.SetActive (false);
		topPacking3.SetActive (true);
		Invoke ("Top3Inactive", 0.15f);
	}

	private void Top3Inactive(){
        if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            AitopPacking3.SetActive(false);
            AitopPacking4.SetActive(true);
        }
        SoundManager.instance.PlayCollisionSound ();
		topPacking3.SetActive (false);
		topPacking4.SetActive (true);
        Invoke("NextActive", 0.5f);
	}

	private void NextActive()
	{
		firework.SetActive(true);
		if (PlayerPrefs.GetInt("Multiplayer") == 1)
		{
			PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 1000);
			levelComplete.SetActive(true);
			completeLevelText.text = "You got 1000 coins";
		}
		if (PlayerPrefs.GetInt("FreeMode") == 1)
		{
			PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 5000);
			levelComplete.SetActive(true);
			completeLevelText.text = "You got 5000 coins";
		}
		SoundManager.instance.PlayLevelCompletedSound ();
		Invoke("NextBtnDelay", 2f);
	}
	void NextBtnDelay()
	{
		Next.SetActive(true);// add delay 5 secs
	}

	public void OnClickNext()
	{
		firework.SetActive(false);
		levelComplete.SetActive(false);
		SoundManager.instance.PlayButtonClickSound();
		LoadingBgActive();
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
        if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        }
        else
        {
            NavigationManager.instance.ReplaceScene(GameScene.ORDERDELIVERINGVIEW);
        }
	}


	#endregion
}

