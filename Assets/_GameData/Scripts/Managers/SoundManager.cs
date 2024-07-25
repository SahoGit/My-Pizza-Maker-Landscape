using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	#region Variables, Constants & Initializers

	public bool isTesting;

	public AudioSource backgroundLoop;

	public AudioSource dryer;
	public AudioSource Cleanerloop;
	public AudioSource BrushCleaningloop;
	public AudioSource WritingLoop;
	public AudioSource FlourLoop;
	public AudioSource PourLoop;
	public AudioSource SaltLoop;
	public AudioSource BeatingLoop;
	public AudioSource RollingLoop;

	public AudioClip buttonClick;
	public AudioClip DayPopupSound;
	public AudioClip swooshSound;
	public AudioClip sparkleSound;
	public AudioClip ActionSound;
	public AudioClip LevelCompletedSound;
	public AudioClip EggCrackingSound;
	public AudioClip itemPlacingSound;
	public AudioClip GoodJobSound;
	public AudioClip PingSound;
	public AudioClip itemComesSound;
	public AudioClip KnifeCutSound;
	public AudioClip CollisionSound;
	public AudioClip SauceSound;
	public AudioClip OvenDoorSound;
	public AudioClip OvenButtonOnSound;
	public AudioClip OvenButtonOffSound;
	public AudioClip OvenFrySound;
	public AudioClip CoinSound;
    public AudioClip DrawerSound;
    public AudioClip Achivment;
    public AudioClip[] WowVoiceSound;




    public bool showDebugLogs;

	// persistant singleton
    private static SoundManager _instance;

	#endregion
	
	#region Lifecycle methods

    public static SoundManager instance
	{
		get
		{
			if(_instance == null)
			{
                _instance = GameObject.FindObjectOfType<SoundManager>();

				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		//Debug.Log("Awake Called");

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
		
	}

	void Start ()
	{
		//Debug.Log("Start Called");

	}

	#endregion

	#region Utility Methods 

	public void SetBackgroundMusicVolume(float value) {
		backgroundLoop.volume = value;
	}

	public void SetBackgroundMusicPitch(float value) {
		backgroundLoop.pitch = value;
	}

	public void PlayButtonClickSound() {
		if (buttonClick) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (buttonClick);
		}
	}

	public void PlayDayPopupSound() {
		if (DayPopupSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (DayPopupSound);
		}
	}

	public void PlaySwooshSound() {
		if (swooshSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (swooshSound);
		}
	}

	public void PlaySparkleSound() {
		if (sparkleSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (sparkleSound);
		}
	}

    public void PlayActionSound()
    {
        if (ActionSound)
        {
			//gameObject.GetComponent<AudioSource>().PlayOneShot(ActionSound);
			gameObject.GetComponent<AudioSource>().PlayOneShot(WowVoiceSound[Random.Range(0, WowVoiceSound.Length - 1)]);
        }
    }

    public void PlayLevelCompletedSound() {
		if (LevelCompletedSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (LevelCompletedSound);
		}
	}

	public void PlayEggCrackSound() {
		if (EggCrackingSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (EggCrackingSound);
		}
	}

	public void PlayItemPlacingSound() {
		if (itemPlacingSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (itemPlacingSound);
		}
	}

	public void PlayGoodJobSound() {
		if (GoodJobSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (GoodJobSound);
		}
	}

	public void PlayPingSound() {
		if (PingSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (PingSound);
		}
	}

	public void PlayItemComesSound() {
		if (itemComesSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (itemComesSound);
		}
	}

	public void PlayKnifeCutSound() {
		if (KnifeCutSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (KnifeCutSound);
		}
	}

	public void PlayCollisionSound() {
		if (CollisionSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (CollisionSound, 0.5f);
		}
	}

	public void PlaySauceSound() {
		if (SauceSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (SauceSound);
		}
	}

	public void PlayOvenDoorSound() {
		if (OvenDoorSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (OvenDoorSound);
		}
	}

	public void PlayOvenButtonOnSound() {
		if (OvenButtonOnSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (OvenButtonOnSound);
		}
	}

	public void PlayOvenButtonOffSound() {
		if (OvenButtonOffSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (OvenButtonOffSound);
		}
	}

	public void PlayFrySound() {
		if (OvenFrySound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (OvenFrySound);
		}
	}

	public void PlayDrawerSound() {
		if (DrawerSound) {
			gameObject.GetComponent<AudioSource> ().PlayOneShot (DrawerSound);
		}
	}

    public void PlayCoinsSound()
    {
        if (CoinSound)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(CoinSound);
        }
    }

    public void PlayAchivmentSound()
    {
        if (Achivment)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(Achivment);
        }
    }
    public void PlayDryerLoop(bool enable) {
		if (dryer && enable) {
			if(!dryer.isPlaying)
				dryer.Play ();
		} else {
			dryer.Stop ();
		}
	}

	public void PlayCleanerLoop(bool enable) {
		if (Cleanerloop && enable) {
			if(!Cleanerloop.isPlaying)
				Cleanerloop.Play ();
		} else {
			Cleanerloop.Stop ();
		}
	}

	public void PlayRubbingLoop(bool enable) {
		if (BrushCleaningloop && enable) {
			if(!BrushCleaningloop.isPlaying)
				BrushCleaningloop.Play ();
		} else {
				BrushCleaningloop.Stop ();
		}
	}

	public void PlayWritingLoop(bool enable) {
		if (WritingLoop && enable) {
			if(!WritingLoop.isPlaying)
				WritingLoop.Play ();
		} else {
			WritingLoop.Stop ();
		}
	}

	public void PlayFlourLoop(bool enable) {
		if (FlourLoop && enable) {
			if(!FlourLoop.isPlaying)
				FlourLoop.Play ();
		} else {
			FlourLoop.Stop ();
		}
	}

	public void PlayPourLoop(bool enable) {
		if (PourLoop && enable) {
			if(!PourLoop.isPlaying)
				PourLoop.Play ();
		} else {
			PourLoop.Stop ();
		}
	}

	public void PlayBeatingLoop(bool enable) {
		if (BeatingLoop && enable) {
			if(!BeatingLoop.isPlaying)
				BeatingLoop.Play ();
		} else {
			BeatingLoop.Stop ();
		}
	}

	public void PlaySaltLoop(bool enable) {
		if (SaltLoop && enable) {
			if(!SaltLoop.isPlaying)
				SaltLoop.Play ();
		} else {
			SaltLoop.Stop ();
		}
	}

	public void PlayRollingLoop(bool enable) {
		if (RollingLoop && enable) {
			if(!RollingLoop.isPlaying)
				RollingLoop.Play ();
		} else {
			RollingLoop.Stop ();
		}
	}


	#endregion

	#region Callback Methods 


	#endregion
}
