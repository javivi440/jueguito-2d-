using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIheallth : MonoBehaviour
{
    public Image[] cherry;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Updatehealth(int lives)
    {
        for (int i = 0; i < cherry.Length; i++)
        {
            if (i < (lives + 1))
                cherry[i].color = Color.white;
            else
                cherry[i].color = Color.black;


        }
    }
}
