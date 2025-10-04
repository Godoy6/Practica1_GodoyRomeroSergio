using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Importa funciones para leer/escribir archivos

public class SavePosition : MonoBehaviour
{
    private GameDataManager dataManager; // Instancia para manejar el guardado y carga de datos

    void Start()
    {
        dataManager = new GameDataManager(); // Crea el manejador de datos

        GameData datos = dataManager.CargarDatos(); // Carga los datos guardados (posici�n y puntuaci�n)

        transform.position = datos.GetPosition(); // Aplica la posici�n guardada al transform del jugador

        GamerManager.instance.point = datos.puntuacion; // Restaura la puntuaci�n guardada en el gestor global
    }

    
    void OnApplicationQuit() // M�todo llamado cuando la aplicaci�n se cierra
    {
        GuardarDatos(); // Guarda los datos actuales antes de cerrar
    }

    void GuardarDatos() // Guarda la posici�n y puntuaci�n actuales en un archivo
    {
        int puntosActuales = GamerManager.instance.point; // Obtiene la puntuaci�n actual del gestor global

        GameData datos = new GameData(transform.position, puntosActuales); // Crea un objeto GameData con la posici�n y puntuaci�n actuales

        dataManager.GuardarDatos(datos); // Guarda los datos usando el manejador
    }
}