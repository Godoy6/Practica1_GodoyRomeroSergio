using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavePosition : MonoBehaviour
{
    
    void Start() // Start is called before the first frame update
    {
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/saveposition.text");

        float x = float.Parse(sr.ReadLine());
        float y = float.Parse(sr.ReadLine());
        float z = float.Parse(sr.ReadLine());
        transform.position = new Vector3(x, y, z);

        sr.Close();
    }
    
    void Update() // Update is called once per frame
    {
        
    }

    private void OnDisable() 
    {
        FileStream fs = File.Create(Application.persistentDataPath + "/saveposition.text");
        StreamWriter sw = new StreamWriter(fs);

        sw.WriteLine(transform.position.x);
        sw.WriteLine(transform.position.y);
        sw.WriteLine(transform.position.z);

        sw.Close();
        fs.Close();
    }
}