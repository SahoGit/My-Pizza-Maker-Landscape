using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameScene {MAINMENU = 1,
	CLEANINGVIEW = 2,
	ORDERTAKINGVIEW = 3,
	STORESHOPPINGVIEW = 4,
	PIZZAMAKINGVIEW = 5,
	BBQANDVEGGIECUTTINGVIEW = 6,
	FISHANDVEGGIECUTTINGVIEW = 7,
	PEPPERONICHILLIVIEW = 8,
	BACONLOVERSVIEW = 9,
	PRIMOMEATVIEW = 10,
	CREATEYOUROWNVIEW =11,
	BEEFANDVEGGIEVIEW = 12,
	LOBSTERSAUCEVIEW = 13,
	DOUGHMAKINGVIEW = 14,
	PIZZADECORATIONVIEW = 15,
	PIZZABAKINGVIEW = 16,
	PIZZAPACKING = 17,
	ORDERDELIVERINGVIEW = 18,
    CASHVIEW = 19,
    MULTIPLAYERVIEW = 20,
    PIZZAPACKINGMULTI = 21
}

public class NavigationManager : MonoBehaviour {

	#region Variables, Constants & Initializers

	public bool ShowDebugLogs;

	private Dictionary<string, Stack> navigationStacks = new Dictionary<string, Stack>();
	public Stack navigationStack;
	public GameScene launchScene;

	public GameObject mainMenu;
	public GameObject cleaningView;
	public GameObject orderTakingView;
	public GameObject storeShoppingView;
	public GameObject pizzaMakingView;
	public GameObject bbqVeggieCuttingView;
	public GameObject fishAndVeggieCuttingView;
	public GameObject pepperoniChilliView;
	public GameObject baconLoversView;
	public GameObject primoMeatView;
	public GameObject createYourOwnView;
	public GameObject beefAndVeggieView;
	public GameObject lobsterSauceView;
	public GameObject doughMakingView;
	public GameObject pizzaDecorationView;
	public GameObject pizzaBakingView;
	public GameObject pizzaPakingView;
    public GameObject pizzaPakingMultiplayerView;
    public GameObject orderDeliveringView;
    public GameObject cashView;
    public GameObject multiPlayer;

    private GameObject runningScene;

	// persistant singleton
    private static NavigationManager _instance;

	#endregion
	
	#region Lifecycle methods

    public static NavigationManager instance
	{
		get
		{
			if(_instance == null)
			{
                _instance = GameObject.FindObjectOfType<NavigationManager>();

				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		Debug.Log("Awake Called");

		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		OnBackKeyPressed ();
	}

	void Start ()
	{
        //Debug.Log("Start Called");

        // for any init behavior setup
		runningScene = null;
        navigationStack = new Stack();
		SetGameScene (launchScene);
    }
	
	void OnEnable()
	{
		//Debug.Log("OnEnable Called");

	}
	
	void OnDisable()
	{
		//Debug.Log("OnDisable Called");

	}

	#endregion

	#region Utility Methods 

	private void SetGameScene(GameScene scene) {
		if(runningScene != null) {
			Destroy (runningScene);
		}

		switch (scene) {
			case GameScene.MAINMENU:
				runningScene = GetGameSceneInstance (mainMenu);
				break;
			case GameScene.CLEANINGVIEW:
				runningScene = GetGameSceneInstance (cleaningView);
				break;
			case GameScene.ORDERTAKINGVIEW:
				runningScene = GetGameSceneInstance (orderTakingView);
				break;
			case GameScene.STORESHOPPINGVIEW:
				runningScene = GetGameSceneInstance (storeShoppingView);
				break;
			case GameScene.PIZZAMAKINGVIEW:
				runningScene = GetGameSceneInstance (pizzaMakingView);
				break;
			case GameScene.BBQANDVEGGIECUTTINGVIEW:
				runningScene = GetGameSceneInstance (bbqVeggieCuttingView);
				break;
			case GameScene.FISHANDVEGGIECUTTINGVIEW:
				runningScene = GetGameSceneInstance (fishAndVeggieCuttingView);
				break;
			case GameScene.PEPPERONICHILLIVIEW:
				runningScene = GetGameSceneInstance (pepperoniChilliView);
				break;
			case GameScene.BACONLOVERSVIEW:
				runningScene = GetGameSceneInstance (baconLoversView);
				break;
			case GameScene.PRIMOMEATVIEW:
				runningScene = GetGameSceneInstance (primoMeatView);
				break;
			case GameScene.CREATEYOUROWNVIEW:
				runningScene = GetGameSceneInstance (createYourOwnView);
				break;
			case GameScene.BEEFANDVEGGIEVIEW:
				runningScene = GetGameSceneInstance (beefAndVeggieView);
				break;
			case GameScene.LOBSTERSAUCEVIEW:
				runningScene = GetGameSceneInstance (lobsterSauceView);
				break;
			case GameScene.DOUGHMAKINGVIEW:
				runningScene = GetGameSceneInstance (doughMakingView);
				break;
			case GameScene.PIZZADECORATIONVIEW:
				runningScene = GetGameSceneInstance (pizzaDecorationView);
				break;
			case GameScene.PIZZABAKINGVIEW:
				runningScene = GetGameSceneInstance (pizzaBakingView);
				break;
			case GameScene.PIZZAPACKING:
			    runningScene = GetGameSceneInstance(pizzaPakingView);
			    break;
			case GameScene.PIZZAPACKINGMULTI:
			    runningScene = GetGameSceneInstance(pizzaPakingMultiplayerView);
			    break;
			case GameScene.ORDERDELIVERINGVIEW:
				runningScene = GetGameSceneInstance (orderDeliveringView);
				break;
			case GameScene.CASHVIEW:
			    runningScene = GetGameSceneInstance(cashView);
			    break;
			case GameScene.MULTIPLAYERVIEW:
			    runningScene = GetGameSceneInstance(multiPlayer);
			    break;
        }

		navigationStack.Push (scene);

		runningScene.SetActive (true);
	}

	private GameObject GetGameSceneInstance(GameObject prefab) {
		GameObject gameScene = GameObject.Instantiate(prefab) as GameObject;
		gameScene.name = prefab.name;
		gameScene.GetComponent<Canvas>().worldCamera = Camera.main;

		return gameScene;
	}

	public void ReplaceScene(GameScene scene) {
		SetGameScene (scene);
	}

	public void ReplaceSceneWithClear(GameScene scene) {
		navigationStack.Clear();
		SetGameScene (scene);
	}

	#endregion

	#region Callback Methods 

	private void OnBackKeyPressed() {
		#if UNITY_ANDROID || UNITY_WP8
		if (Input.GetKeyDown(KeyCode.Escape) && (!GameManager.instance.isGamePaused)) 
		{ 
			switch ((GameScene) navigationStack.Peek()) {
			case GameScene.MAINMENU:
				//Application.Quit();
				break;
//			case GameScene.SELECTION:
//				navigationStack.Clear();
//				ReplaceScene(GameScene.MAINMENU);
//				break;
			case GameScene.CLEANINGVIEW:
				ReplaceScene(GameScene.MAINMENU);
				break;
			case GameScene.ORDERTAKINGVIEW:
				ReplaceScene(GameScene.MAINMENU);
				break;
			case GameScene.STORESHOPPINGVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.PIZZAMAKINGVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.BBQANDVEGGIECUTTINGVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.FISHANDVEGGIECUTTINGVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.PEPPERONICHILLIVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.BACONLOVERSVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.PRIMOMEATVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.CREATEYOUROWNVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.BEEFANDVEGGIEVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.LOBSTERSAUCEVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.DOUGHMAKINGVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.PIZZADECORATIONVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.PIZZABAKINGVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.PIZZAPACKING:
				ReplaceScene(GameScene.MAINMENU);
				break;
			case GameScene.ORDERDELIVERINGVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;
			case GameScene.CASHVIEW:
				ReplaceScene(GameScene.ORDERTAKINGVIEW);
				break;			
			}
		}
	
		#endif
	}

	#endregion
}
