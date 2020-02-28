using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        healthText.text = tentHealth.ToString();



        if (tentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
