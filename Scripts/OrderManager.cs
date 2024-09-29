using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public void MiniGameSucces()
    {
        //updateScore
        FindObjectOfType<Order>().StopTimer();
        Invoke("resetOrder", 2f);
    }

    public void resetOrder()
    {
        FindObjectOfType<Order>().reset();
    }
}
