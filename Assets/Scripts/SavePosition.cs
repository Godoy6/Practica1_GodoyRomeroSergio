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

        GameData datos = dataManager.CargarDatos(); // Carga los datos guardados (posición y puntuación)

        transform.position = datos.GetPosition(); // Aplica la posición guardada al transform del jugador

        GamerManager.instance.point = datos.puntuacion; // Restaura la puntuación guardada en el gestor global
    }

    
    void OnApplicationQuit() // Método llamado cuando la aplicación se cierra
    {
        GuardarDatos(); // Guarda los datos actuales antes de cerrar
    }

    void GuardarDatos() // Guarda la posición y puntuación actuales en un archivo
    {
        int puntosActuales = GamerManager.instance.point; // Obtiene la puntuación actual del gestor global

        GameData datos = new GameData(transform.position, puntosActuales); // Crea un objeto GameData con la posición y puntuación actuales

        dataManager.GuardarDatos(datos); // Guarda los datos usando el manejador
    }
}