using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // Importa funciones para leer/escribir archivos

public class GameDataManager
{
    private string filePath; // Ruta completa donde se guarda el archivo JSON

    public GameDataManager()
    {
        filePath = Path.Combine(Application.persistentDataPath, "savegame.json"); // Crea la ruta del archivo usando la carpeta persistente del sistema
    }

    public void GuardarDatos(GameData data) // Guarda los datos del juego en un archivo JSON
    {
        string json = JsonUtility.ToJson(data, true); // Convierte el objeto GameData a un string JSON

        File.WriteAllText(filePath, json); // Escribe el contenido JSON en el archivo especificado
    }

    public GameData CargarDatos() // Carga los datos del juego desde el archivo JSON
    {
        
        if (File.Exists(filePath)) // Verifica si el archivo de guardado existe
        {
            string json = File.ReadAllText(filePath); // Lee todo el contenido del archivo

            return JsonUtility.FromJson<GameData>(json); // Convierte el JSON leído a un objeto GameData y lo devuelve
        }
        else
        {
            Debug.Log("No se encontró archivo de guardado. Usando datos por defecto."); // Si no existe el archivo, muestra mensaje y devuelve valores por defecto
            
            return new GameData(Vector3.zero, 0); // posición (0,0,0) y puntuación 0
        }
    }
}