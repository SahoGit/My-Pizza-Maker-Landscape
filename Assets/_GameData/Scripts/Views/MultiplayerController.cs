using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MultiplayerController : MonoBehaviour
{
    //private GameObject pizza;
    public GameObject PizzaTray;
    public RectTransform PizzaTrayPosition;
    public GameObject topPacking1, topPacking2, topPacking3, topPacking4;
    public Image dough;
    public Image souce;
    public Image cheez;
    public Image backed;

    public Image[] vegies;
    public Sprite[] vegiesList;
    public Image[] meet;
    public Sprite[] meetList;
    public Image[] hurb;
    public Sprite[] hurbList;
    public Image[] fruit;
    public Sprite[] fruitList;

    public Sprite doughList;
    public Sprite souceist;
    public Sprite cheezList;
    public Sprite backedList;
    //public GameObject Next;
    //public GameObject LoadinBg;
    //public Image LoadingFilled;
    //public GameObject firework;

    // Start is called before the first frame update
    void Start()
    {
        dough.GetComponent<Image>().sprite = doughList;
        for (int i = 0; i < vegies.Length; i++)
        {
            vegies[i].GetComponent<Image>().sprite = vegiesList[Random.Range(0, vegiesList.Length)];
        }
        for (int i = 0; i < meet.Length; i++)
        {
            meet[i].GetComponent<Image>().sprite = meetList[Random.Range(0, meetList.Length)];
        }
        for (int i = 0; i < hurb.Length; i++)
        {
            hurb[i].GetComponent<Image>().sprite = hurbList[Random.Range(0, hurbList.Length)];
        }
        for (int i = 0; i < fruit.Length; i++)
        {
            fruit[i].GetComponent<Image>().sprite = fruitList[Random.Range(0, fruitList.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
