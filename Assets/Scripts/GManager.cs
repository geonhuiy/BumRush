using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public static GManager gManagerInstance;
    [SerializeField]
    private Text moneyText;
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
        moneyText.text = money.ToString();
    }

}
