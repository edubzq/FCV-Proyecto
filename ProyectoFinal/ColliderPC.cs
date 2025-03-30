using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerInteraction : MonoBehaviour
{
    public TextMeshProUGUI interactionText; 
    public GameObject[] uiElements;
    public GameObject player; 

    private bool playerInRange = false; 
    private MonoBehaviour playerMovementScript; 

    void Start()
    {
       
        interactionText.gameObject.SetActive(false);
        
       
        playerMovementScript = player.GetComponent<MonoBehaviour>();
    }

    void Update()
    {
      
        if (playerInRange && Input.GetKeyDown(KeyCode.R))
        {
          
            foreach (GameObject element in uiElements)
            {
                element.SetActive(true);
            }

        
            interactionText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactionText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactionText.gameObject.SetActive(false);
        }
    }
}


