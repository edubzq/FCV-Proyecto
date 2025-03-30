using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperCursor : MonoBehaviour
{
    public Transform mirilla;

    // Update is called once per frame
    void Update()
    {
        // Obtener la posición del cursor del ratón en coordenadas de pantalla
        Vector2 cursorPos = Input.mousePosition;
        // Convertir las coordenadas de pantalla a coordenadas del mundo
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(cursorPos);
        // Mantener la posición de la mirilla en el plano XY
        worldPos.z = 0f;
        // Establecer la posición de la mirilla
        mirilla.position = cursorPos;
    }
}
