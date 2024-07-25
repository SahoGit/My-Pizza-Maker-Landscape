using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ApplicatorListener : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    #region Variables, Constants & Initializers

    public Button.ButtonClickedEvent onEnterCollider;
    public Button.ButtonClickedEvent onExitCollider;
    public Button.ButtonClickedEvent onStayingCollider;

	private bool stopFlag = false;
    private RectTransform rectTransform;
    private Image image;

    private bool isStayingInCollider;
	private Transform parent;
	private Vector2 anchorPos;
	private RectTransform rectTrans;

    private Vector3 startPosition;
    private Vector3 startRotation;

    #endregion


    #region Lifecycle Methods

    // Use this for initialization

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        startPosition = rectTransform.localPosition;
        startRotation = rectTransform.transform.eulerAngles;
        image = gameObject.GetComponent<Image>();

    }

    #endregion

    #region IBeginDragHandler implementation
    public void OnBeginDrag(PointerEventData eventData){
		if (this.gameObject.tag == "Knife" || this.gameObject.tag == "OnionKnife" || this.gameObject.tag == "MeatKnife" || this.gameObject.tag == "CapsicumKnife") {
			SoundManager.instance.PlayItemPlacingSound ();
		}
		switch (GameManager.instance.currentScene) {
		case GameUtils.PIZZAMAKING_VIEW:
			if (this.gameObject.tag == "Flour") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "MilkBottle") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "YeastPack") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "WaterJug") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "OilBottle") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "Egg") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "SugarPack") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "SaltBottle") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "Beater") {
				this.gameObject.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0f,0f, 0f);
			}
			break;

		case GameUtils.DOUGHMAKING_VIEW:
			if (this.gameObject.tag == "SauceBrush") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "CheeseBag") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}
			break;

		case GameUtils.CLEANING_VIEW:
			if (this.gameObject.tag == "Cleaner") {
				this.gameObject.transform.GetChild (0).gameObject.SetActive (true);	
				SoundManager.instance.PlayCleanerLoop (true);
			}

			if (this.gameObject.tag == "Mob") {
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "Towel") {
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			break;

		case GameUtils.StoreShopping_VIEW:
			if (this.gameObject.tag == "BasketItem") {
				this.gameObject.transform.SetAsLastSibling ();
			}
				
			if (this.gameObject.tag == "Vegetable") {
				this.gameObject.transform.SetAsLastSibling ();
			}

			if (this.gameObject.tag == "Fruit") {
				this.gameObject.transform.SetAsLastSibling ();
			}

			if (this.gameObject.tag == "SeaFood") {
				this.gameObject.transform.SetAsLastSibling ();
			}

			if (this.gameObject.tag == "Herbs") {
				this.gameObject.transform.SetAsLastSibling ();
			}

			if (this.gameObject.tag == "Meat") {
				this.gameObject.transform.SetAsLastSibling ();
			}

			break;

		case GameUtils.PIZZADECORATIONVIEW:
			if (this.gameObject.tag == "ItemDrag") {
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "PizzaSauce") {
				this.gameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(0f, 0f, 123);
				if (onStayingCollider != null) {
					onStayingCollider.Invoke ();
				}
			}

			break;
		}
	

	}

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData) {
		
		if(this.gameObject.tag == "ItemSet"){


		}

		else{
		switch (GameManager.instance.currentScene) {

		case GameUtils.PIZZAMAKING_VIEW:
			if (this.gameObject.tag == "Flour") {
				this.gameObject.GetComponent<ActionManager> ().enabled = true;
			}

			if (this.gameObject.tag == "MilkBottle") {
				this.gameObject.GetComponent<ActionManager> ().enabled = true;
			}

			if (this.gameObject.tag == "YeastPack") {
				this.gameObject.GetComponent<ActionManager> ().enabled = true;
			}

			if (this.gameObject.tag == "WaterJug") {
				this.gameObject.GetComponent<ActionManager> ().enabled = true;
			}

			if (this.gameObject.tag == "OilBottle") {
				this.gameObject.GetComponent<ActionManager> ().enabled = true;
			}

			if (this.gameObject.tag == "Egg") {
				this.gameObject.GetComponent<ActionManager> ().enabled = true;
			}

			if (this.gameObject.tag == "SugarPack") {
				this.gameObject.GetComponent<ActionManager> ().enabled = true;
			}

			if (this.gameObject.tag == "SaltBottle") {
				this.gameObject.GetComponent<ActionManager> ().enabled = true;
			}


			if (this.gameObject.tag == "Beater") {
				this.gameObject.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0f,0f, 180f);
			}

			if (this.gameObject.tag == "ShowerBottle") {
				this.gameObject.transform.GetChild (0).gameObject.SetActive (false);
				if (onExitCollider != null) {
					onExitCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "Mob") {
				if (onExitCollider != null) {
					onExitCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "Freshner") {
				this.gameObject.transform.GetChild (0).gameObject.SetActive (false);
				if (onExitCollider != null) {
					onExitCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "Towel") {
				if (onExitCollider != null) {
					onExitCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "WebBrush") {
				if (onExitCollider != null) {
					onExitCollider.Invoke ();
				}
			}
			break;

		case GameUtils.DOUGHMAKING_VIEW:
			if (this.gameObject.tag == "SauceBrush") {
				this.gameObject.GetComponent<ActionManager> ().enabled = false;
				if (onExitCollider != null) {
					onExitCollider.Invoke ();
				}
			}

			if (this.gameObject.tag == "CheeseBag") {
				this.gameObject.GetComponent<ActionManager> ().enabled = true;
			}

			break;

		case GameUtils.CLEANING_VIEW:

			if (this.gameObject.tag == "Cleaner"){
				this.gameObject.transform.GetChild (0).gameObject.SetActive (false);	
				SoundManager.instance.PlayCleanerLoop (false);
			}
			if (this.gameObject.tag == "Mob") {
				SoundManager.instance.PlayRubbingLoop (false);
			}
			if (this.gameObject.tag == "Towel") {
				SoundManager.instance.PlayRubbingLoop (false);
			}
			break;

		case GameUtils.StoreShopping_VIEW:
			
			break;

			case GameUtils.PIZZADECORATIONVIEW:
				if (this.gameObject.tag == "PizzaSauce") {
					this.gameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(0f, 0f, 0f);
				}

				if (this.gameObject.tag == "ItemDrag") {
					if (onExitCollider != null) {
						onExitCollider.Invoke ();
					}
				}

				break;

				if (this.gameObject.tag == "Knife") {
					SoundManager.instance.PlayItemPlacingSound ();
				}
		}


			rectTransform.localPosition = startPosition;
			rectTransform.transform.eulerAngles = startRotation;
		}
	

    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData){
		if (this.gameObject.tag == "RollingPinActive") {
			print ("there");
			Vector3	point = Camera.main.ScreenToWorldPoint(new Vector3((transform.position.x-Camera.main.transform.position.x),Input.mousePosition.y,(transform.position.z-Camera.main.transform.position.z)));
			point.x = transform.position.x;                   
			point.z = transform.position.z;
			this.transform.position = point;
			if (onEnterCollider != null) {
				onEnterCollider.Invoke ();
			}

		} else {
			// dont use localPosition here
			rectTransform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			rectTransform.position = new Vector3 (rectTransform.position.x, rectTransform.position.y, 0);
			if (isStayingInCollider) {
				switch (GameManager.instance.currentScene) {
				case GameUtils.DOUGHMAKING_VIEW:
					if (this.gameObject.tag == "SauceBrush") {
						if (onEnterCollider != null) {
							onEnterCollider.Invoke ();
						}
					}
					break;
				}
			}
		}
	}

    #endregion

    #region Collision Detector Methods



    void OnCollisionEnter2D(Collision2D collision){
		switch (GameManager.instance.currentScene) {
		case GameUtils.PIZZAMAKING_VIEW:
			
	

			if (collision.gameObject.tag == "FlourUpperPoint") {
				if (this.gameObject.tag == "Flour") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
						}
					}
				}

			if (collision.gameObject.tag == "MilkBottleUpperPoint") {
				if (this.gameObject.tag == "MilkBottle") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "YeastPackUpperPoint") {
				if (this.gameObject.tag == "YeastPack") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}


			if (collision.gameObject.tag == "WaterJugUpperPoint") {
				if (this.gameObject.tag == "WaterJug") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "OilBottleUpperPoint") {
				if (this.gameObject.tag == "OilBottle") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "EggUpperPoint") {
				if (this.gameObject.tag == "Egg") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "SugarPackUpperPoint") {
				if (this.gameObject.tag == "SugarPack") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "SaltBottleUpperPoint") {
				if (this.gameObject.tag == "SaltBottle") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "RollingPinActive") {
				if (this.gameObject.tag == "RollingPin1") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					collision.gameObject.GetComponent<Image> ().enabled = true;
					this.gameObject.SetActive (false);
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}


			if (collision.gameObject.tag == "Dust") {
				if (this.gameObject.tag == "DustBrush") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "DustBin") {
				if (this.gameObject.tag == "DustPan") {
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					GameManager.instance.currentItem = this.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Web") {
				if (this.gameObject.tag == "WebBrush") {
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "GreenDirt") {
				if (this.gameObject.tag == "Sponge") {
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "WaterDrops") {
				if (this.gameObject.tag == "ShowerBottle") {
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Water") {
				if (this.gameObject.tag == "Mob") {
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Dirt") {
				if (this.gameObject.tag == "Towel") {
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "dustbin") {
				if (this.gameObject.tag == "damageitem") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					GameManager.instance.currentItem = this.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

		break;

		case GameUtils.DOUGHMAKING_VIEW:
			if (collision.gameObject.tag == "RoughDough") {
				if (this.gameObject.tag == "SauceBrush") {
					GameManager.instance.currentItem = collision.gameObject.tag;
					isStayingInCollider = true;
				}
			}

			if (collision.gameObject.tag == "Sauce") {
				if (this.gameObject.tag == "SauceBrush") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.tag;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CheeseBagUpperPoint") {
				if (this.gameObject.tag == "CheeseBag") {
					this.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;

					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			break;

		case GameUtils.CLEANING_VIEW:
			if (collision.gameObject.tag == "DirtItems") {
				if (this.gameObject.tag == "Cleaner") {
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Water") {
				if (this.gameObject.tag == "Mob") {
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "WindowDirt") {
				if (this.gameObject.tag == "Towel") {
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			break;

		case GameUtils.StoreShopping_VIEW:
			if (collision.gameObject.tag == "Basket") {
				if (this.gameObject.tag == "BasketItem") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = this.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			break;

		case GameUtils.BBQANDVEGGIECUTTINGVIEW:
			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Tomato") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "TomatoPlate") {
				if (this.gameObject.tag == "TomatoCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Onion") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "OnionPlate") {
				if (this.gameObject.tag == "OnionCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Meat") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "MeatPlate") {
				if (this.gameObject.tag == "MeatCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			break;
		

		case GameUtils.FISHANDVEGGIECUTTINGVIEW:
		if (collision.gameObject.tag == "CuttingItemEndPoint") {
			if (this.gameObject.tag == "Tomato") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint1") {
			if (this.gameObject.tag == "Knife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint4") {
			if (this.gameObject.tag == "Knife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint2") {
			if (this.gameObject.tag == "Knife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint3") {
			if (this.gameObject.tag == "Knife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "TomatoPlate") {
			if (this.gameObject.tag == "TomatoCut") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "CuttingItemEndPoint") {
			if (this.gameObject.tag == "Onion") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint1") {
			if (this.gameObject.tag == "OnionKnife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint4") {
			if (this.gameObject.tag == "OnionKnife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint2") {
			if (this.gameObject.tag == "OnionKnife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint3") {
			if (this.gameObject.tag == "OnionKnife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}
		if (collision.gameObject.tag == "OnionPlate") {
			if (this.gameObject.tag == "OnionCut") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Capsicum") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "CapsicumPlate") {
				if (this.gameObject.tag == "CapsicumCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

		if (collision.gameObject.tag == "CuttingItemEndPoint") {
			if (this.gameObject.tag == "Meat") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint1") {
			if (this.gameObject.tag == "MeatKnife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint4") {
			if (this.gameObject.tag == "MeatKnife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint2") {
			if (this.gameObject.tag == "MeatKnife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}

		if (collision.gameObject.tag == "KnifeCutPoint3") {
			if (this.gameObject.tag == "MeatKnife") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameManager.instance.currentItem = collision.gameObject.name;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}
		if (collision.gameObject.tag == "MeatPlate") {
			if (this.gameObject.tag == "MeatCut") {
				this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
				this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}
		break;



		case GameUtils.PEPPERONICHILLIVIEW:
			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Onion") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "OnionPlate") {
				if (this.gameObject.tag == "OnionCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Capsicum") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "CapsicumPlate") {
				if (this.gameObject.tag == "CapsicumCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Meat") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "MeatPlate") {
				if (this.gameObject.tag == "MeatCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			break;

		case GameUtils.BACONLOVERSVIEW:
			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Tomato") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "TomatoPlate") {
				if (this.gameObject.tag == "TomatoCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Onion") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "OnionPlate") {
				if (this.gameObject.tag == "OnionCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Meat") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "MeatPlate") {
				if (this.gameObject.tag == "MeatCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			break;

		case GameUtils.PRIMOMEATVIEW:
			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Capsicum") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "CapsicumPlate") {
				if (this.gameObject.tag == "CapsicumCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Meat") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "MeatPlate") {
				if (this.gameObject.tag == "MeatCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			break;

		case GameUtils.CREATEYOUROWNVIEW:
			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Tomato") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "TomatoPlate") {
				if (this.gameObject.tag == "TomatoCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Onion") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "OnionPlate") {
				if (this.gameObject.tag == "OnionCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Capsicum") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "CapsicumKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "CapsicumPlate") {
				if (this.gameObject.tag == "CapsicumCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Meat") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "MeatPlate") {
				if (this.gameObject.tag == "MeatCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			break;

		case GameUtils.BEEFANDVEGGIEVIEW:
			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Tomato") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "TomatoPlate") {
				if (this.gameObject.tag == "TomatoCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Onion") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "OnionPlate") {
				if (this.gameObject.tag == "OnionCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Meat") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "MeatPlate") {
				if (this.gameObject.tag == "MeatCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			break;

		case GameUtils.LOBSTERSAUCEVIEW:
			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Tomato") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "Knife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "TomatoPlate") {
				if (this.gameObject.tag == "TomatoCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Onion") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "OnionKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "OnionPlate") {
				if (this.gameObject.tag == "OnionCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "CuttingItemEndPoint") {
				if (this.gameObject.tag == "Meat") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint1") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint4") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint2") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "KnifeCutPoint3") {
				if (this.gameObject.tag == "MeatKnife") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.currentItem = collision.gameObject.name;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			if (collision.gameObject.tag == "MeatPlate") {
				if (this.gameObject.tag == "MeatCut") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			break;

		case GameUtils.PIZZADECORATIONVIEW:
			if (collision.gameObject.tag == "CheckCollider") {
				if (this.gameObject.tag == "ItemDrag") {
					print ("there");
					GameManager.instance.CollidedObject = this.gameObject;
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					GameManager.instance.itemPicked = this.gameObject.GetComponent<Image> ().sprite;
					GameManager.instance.currentItem = this.gameObject.name;
					this.gameObject.SetActive (false);
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "DestroyCollider") {
				if (this.gameObject.tag == "ItemSet") {
					Destroy(this.gameObject);
				}

			}

			if (collision.gameObject.tag == "PizzaTray") {
				if (this.gameObject.tag == "PizzaSauce") {
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}

			}
			break;

		case GameUtils.PIZZABAKINGVIEW:
			if (collision.gameObject.tag == "Oven") {
				if (this.gameObject.tag == "BakingPizza") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			break;

		case GameUtils.ORDERDELIVERINGVIEW:
			if (collision.gameObject.tag == "Customer") {
				if (this.gameObject.tag == "PizzaPacked") {
					this.gameObject.GetComponent<ApplicatorListener> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}
			break;

		case GameUtils.CASHVIEW:
			if (collision.gameObject.tag == "Dollar1Placed") {
				if (this.gameObject.tag == "Dollar1") {
					SoundManager.instance.PlayCoinsSound ();
					this.GetComponent<Collider2D> ().enabled = false;
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.SetActive (false);
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<Image> ().enabled = true;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Dollar2Placed") {
				if (this.gameObject.tag == "Dollar2") {
					SoundManager.instance.PlayCoinsSound ();
					this.GetComponent<Collider2D> ().enabled = false;
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.SetActive (false);
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<Image> ().enabled = true;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Dollar5Placed") {
				if (this.gameObject.tag == "Dollar5") {
					SoundManager.instance.PlayCoinsSound ();
					this.GetComponent<Collider2D> ().enabled = false;
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.SetActive (false);
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<Image> ().enabled = true;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Dollar10Placed") {
				if (this.gameObject.tag == "Dollar10") {
					print ("there");
					SoundManager.instance.PlayCollisionSound ();
					this.GetComponent<Collider2D> ().enabled = false;
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					this.gameObject.SetActive (false);
					collision.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.7f, 0.7f, 0.7f);
					collision.gameObject.GetComponent<Image> ().enabled = true;
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Dollar50Placed") {
				if (this.gameObject.tag == "Dollar50") {
					SoundManager.instance.PlayCollisionSound ();
					this.GetComponent<Collider2D> ().enabled = false;
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<Image> ().enabled = true;
					this.gameObject.SetActive (false);
					collision.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.7f, 0.7f, 0.7f);
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			if (collision.gameObject.tag == "Dollar20Placed") {
				if (this.gameObject.tag == "Dollar20") {
					SoundManager.instance.PlayCollisionSound ();
					this.GetComponent<Collider2D> ().enabled = false;
					this.GetComponent<BoxCollider2D> ().enabled = false;
					this.GetComponent<ApplicatorListener> ().enabled = false;
					this.gameObject.SetActive (false);
					collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
					collision.gameObject.GetComponent<Image> ().enabled = true;

					collision.gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0.7f, 0.7f, 0.7f);
					if (onEnterCollider != null) {
						onEnterCollider.Invoke ();
					}
				}
			}

			break;
		
		}

	}

        
    void OnCollisionStay2D(Collision2D collision){
		if (collision.gameObject.tag == "Mixture") {
			if (this.gameObject.tag == "Beater") {
				if (onEnterCollider != null) {
					onEnterCollider.Invoke ();
				}
			}
		}
    }

    void OnCollisionExit2D(Collision2D collision) {
		isStayingInCollider = false;
		if (collision.gameObject.tag == "Mixture") {
			if (this.gameObject.tag == "Beater") {
				if (onExitCollider != null) {
					onExitCollider.Invoke ();
				}
			}
		}
    }

    #endregion
}
