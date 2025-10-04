using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        PlayerController playerController = collider.GetComponent<PlayerController>();
        if (playerController != null) 
        {
            GamerManager.instance.IncreasePoint();
            Destroy(this.gameObject);
        }
    }
}
