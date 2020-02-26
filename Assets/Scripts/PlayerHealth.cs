using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int tentHealth = 100;
    public Text healthText;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ontriggerenter from Player health");
        tentHealth -= 1;
    }

    // Update is called once per frame
    void Update()
    {    
        //Debug.Log(tentHealth);
        healthText.text = "Tent Health  : " + (tentHealth);
       
        // If the health is 0 or lower, stop the game and popup some menu screen
        if (tentHealth <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
