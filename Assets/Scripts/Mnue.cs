using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mnue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void JazireAhangari()
    {
        Application.LoadLevel(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
