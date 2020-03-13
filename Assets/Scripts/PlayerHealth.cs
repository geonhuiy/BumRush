using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int tentHealth = 100;
    public TextMeshProUGUI healthText;
    PoolObject pool;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ontriggerenter from Player health");
        tentHealth -= 1;
        if (other.gameObject.tag == "Rat") {
            other.gameObject.GetComponent<PoolObject>().DespawnPoolObject(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(tentHealth);
        healthText.SetText(tentHealth.ToString());



        if (tentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
