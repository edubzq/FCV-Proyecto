using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class InputFieldPC : MonoBehaviour
{
    public GameObject pantalla, password, creditos;
    public TMP_InputField inputField;
    public TextMeshProUGUI feedbackText;
    public string frase;
    public GameObject player;
    private MonoBehaviour playerMovementScript; 


    private void Start()
    {
        // Asegúrate de que el feedbackText esté vacío al inicio
        if (feedbackText != null)
        {
            feedbackText.text = "";
        }

        // Selecciona y activa el InputField al inicio
        ActivateInputField();
    }

    void Update()
    {
        if (playerMovementScript != null)
            {
                playerMovementScript.enabled = false;
            }
    }

    public void CheckPass()
    {
        // Verifica si el texto ingresado coincide con la frase secreta
        if (inputField.text == frase)
        {
            password.SetActive(false);
            pantalla.SetActive(true);
        }
        else
        {
            
                feedbackText.text = "Contraseña incorrecta";
            
        }

        // Limpia el InputField después de verificar
        inputField.text = "";

        // Reactiva el InputField para que el usuario pueda volver a escribir
        ActivateInputField();
    }

    public void CheckInput()
    {
        // Verifica si el texto ingresado coincide con la frase secreta
        if (inputField.text == frase)
        {
            feedbackText.text = "Has salvado el mundo!";
            pantalla.SetActive(false);
             password.SetActive(false);
            creditos.SetActive(true);
        }
        else
        {
            
                feedbackText.text = "Comando incorrecto. Intentalo de nuevo.";
            
        }

        // Limpia el InputField después de verificar
        inputField.text = "";

        // Reactiva el InputField para que el usuario pueda volver a escribir
        ActivateInputField();
    }

    private void ActivateInputField()
    {
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void volverMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
