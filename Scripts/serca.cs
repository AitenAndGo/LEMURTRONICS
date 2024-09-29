using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serca : MonoBehaviour
{
    // Start is called before the first frame update

    int serce = 3;

    public GameObject serce_1;
    public GameObject serce_2;
    public GameObject serce_3;
    void Start()
    {
        serce_1.SetActive(true); 
        serce_2.SetActive(true);
        serce_3.SetActive(true);
    }

    public void updateSerca(int serca)
    {
        switch (serca)
        {
            case 0:
                serce_1.SetActive(false);
                serce_2.SetActive(false);
                serce_3.SetActive(false);
                break;
            case 1:
                serce_1.SetActive(true);
                serce_2.SetActive(false);
                serce_3.SetActive(false);
                break;
            case 2:
                serce_1.SetActive(true);
                serce_2.SetActive(true);
                serce_3.SetActive(false);
                break;
        }
    }
}
