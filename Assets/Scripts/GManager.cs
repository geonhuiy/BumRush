using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GManager : MonoBehaviour
{
    public static GManager gManagerInstance;
    [SerializeField]
    private TextMeshProUGUI moneyText;
    public int money;
    private void Awake()
    {
        if (gManagerInstance == null) {
            gManagerInstance = this;
        }
        else {
            Destroy(this);
        }
    }
    private void Start()
    {
        money = 10;
    }
    private void Update()
    {
        //moneyText.text = money.ToString();
        if(money >= 9999)
        {
            money = 9999;
        }
        moneyText.SetText(money.ToString());
    }

}
