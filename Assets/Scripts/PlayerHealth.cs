using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public Text healthText;




    // Start is called before the first frame update
    void Start()
    {
        health = 60;
    }



    // Update is called once per frame
    void Update()
    {


        healthText.text = "Tent Health  : " + health;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }
}
