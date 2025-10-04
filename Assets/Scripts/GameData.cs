using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Esta clase puede ser convertida a JSON gracias a este atributo
public class GameData
{
    public float posX;
    public float posY;
    public float posZ;
    public int puntuacion;

    public GameData() // Constructor vac�o (necesario para que Unity pueda deserializar JSON correctamente)
    {

    }

    public GameData(Vector3 position, int puntuacion) // Constructor que recibe la posici�n y puntuaci�n al crear el objeto
    {
        // Guarda la posici�n separando las componentes X, Y y Z
        this.posX = position.x;
        this.posY = position.y;
        this.posZ = position.z;

        this.puntuacion = puntuacion; // Guarda la puntuaci�n
    }

    public Vector3 GetPosition() // Devuelve la posici�n como un Vector3 (combinando X, Y y Z)
    {
        return new Vector3(posX, posY, posZ);
    }
}