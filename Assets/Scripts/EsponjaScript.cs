using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsponjaScript : MonoBehaviour
{
    public GameObject decalObject; // El objeto decal que ser� limpiado
    private Material decalMaterial; // El material del decal
    public float opacityDecreaseSpeed = 0.1f; // Velocidad de disminuci�n de opacidad
    public float minMovementThreshold = 0.01f; // M�nimo movimiento para activar la limpieza

    private Vector3 lastPosition; // Almacena la �ltima posici�n de la esponja
    private bool isCleaning = false; // Controla si la esponja est� en el �rea de limpieza

    private void Start()
    {
        // Obtener el material del decal
        decalMaterial = decalObject.GetComponent<Renderer>().material;
        lastPosition = Vector3.zero; // Inicializar con un valor por defecto
    }

    // Detectar cuando la esponja entra en el �rea del decal
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra tiene el tag "Esponja"
        if (other.CompareTag("Esponja"))
        {
            isCleaning = true; // Iniciar la limpieza
            lastPosition = other.transform.position; // Almacenar la posici�n inicial de la esponja
        }
    }

    // Detectar cuando la esponja est� dentro del �rea del decal (mientras frota)
    private void OnTriggerStay(Collider other)
    {
        // Continuar la limpieza si es la esponja
        if (isCleaning && other.CompareTag("Esponja") && HasMoved(other.transform.position))
        {
            CleanDecal();
            lastPosition = other.transform.position; // Actualizar la �ltima posici�n
        }
    }

    // Detectar cuando la esponja sale del �rea del decal
    private void OnTriggerExit(Collider other)
    {
        // Detener la limpieza si la esponja sale del �rea
        if (other.CompareTag("Esponja"))
        {
            isCleaning = false; // Detener la limpieza
        }
    }

    // Verifica si la esponja ha movido lo suficiente para considerar que est� limpiando
    private bool HasMoved(Vector3 currentPosition)
    {
        // Comprobar si la esponja ha movido una distancia m�nima desde la �ltima actualizaci�n
        float distanceMoved = Vector3.Distance(currentPosition, lastPosition);
        return distanceMoved > minMovementThreshold;
    }

    private void CleanDecal()
    {
        // Obtener el color actual del material del decal
        Color decalColor = decalMaterial.color;

        // Reducir la opacidad (canal alpha) del decal
        decalColor.a -= opacityDecreaseSpeed * Time.deltaTime;
        decalColor.a = Mathf.Clamp01(decalColor.a); // Limitar alpha entre 0 y 1

        // Aplicar el nuevo color con menor opacidad al material del decal
        decalMaterial.color = decalColor;

        // Si la opacidad llega a 0, desactivar el decal
        if (decalColor.a <= 0)
        {
            decalObject.SetActive(false); // Decal completamente "limpio"
        }
    }

}
