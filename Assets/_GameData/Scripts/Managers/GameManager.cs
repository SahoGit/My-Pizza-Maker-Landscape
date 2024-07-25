using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	#region Variables, Constants & Initializers

	public bool ShowDebugLogs;

	public ArrayList charactersDataList;
	public ArrayList hatsDataList;
	public ArrayList beardStylesDataList;
	public ArrayList glassesDataList;

	//[HideInInspector]
	public bool isGameFirstLoop;
	//[HideInInspector]
	public string currentScene;

	//[HideInInspector]
	public Sprite itemPicked;

	//[HideInInspector]
	public string currentItem;

	public BaseItem selectedCharacter;

	//[HideInInspector]
	public bool isGamePaused;

	//[HideInInspector]
	public bool canDrawMask = false;

	//[HideInInspector]
	public int SelectedPizzaFlavour = -1;

	//[HideInInspector]
	public GameObject CollidedObject; 

	
	// persistant singleton
    private static GameManager _instance;

	public Player player;

	#endregion
	
	#region Lifecycle methods

    public static GameManager instance
	{
		get
		{
			if(_instance == null)
			{
                _instance = GameObject.FindObjectOfType<GameManager>();

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


	void Start ()
	{
		Debug.Log("Start Called");

		// for any init behavior setup
		this.isGamePaused = false;
		this.isGameFirstLoop = true;
		this.player = new Player();
		this.SetData();
	}
	
	void OnEnable()
	{
		Debug.Log("OnEnable Called");
		//AssignAdIds_CB.instance.ShowBanner();
		AdsManager.Instance.ShowBanner();

	}
	
	

	#endregion

	#region Utility Methods 

	private void SetData() {
		this.charactersDataList = DataProvider.GetCharactersDataList ();
		this.hatsDataList = DataProvider.GetHatsDataList ();
		this.glassesDataList = DataProvider.GetGlassesDataList ();
		this.beardStylesDataList = DataProvider.GetBeardStylesDataList ();
	}

	public void LogDebug(string message) {
		if (ShowDebugLogs)
			Debug.Log ("GameManager >> " + message);
	}
	
	private void LogErrorDebug(string message) {
		if (ShowDebugLogs)
			Debug.LogError ("GameManager >> " + message);
	}

	#endregion

	#region Callback Methods 


	#endregion
}
