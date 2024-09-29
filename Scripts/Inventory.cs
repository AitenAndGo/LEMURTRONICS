using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject empty_slot_1_ledy;
    public GameObject empty_slot_2_ledy;
    public GameObject empty_slot_3_ledy;

    public GameObject slot_1_ledy;
    public GameObject slot_2_ledy;
    public GameObject slot_3_ledy;

    public GameObject empty_slot_1_klawia;
    public GameObject empty_slot_2_klawia;
    public GameObject empty_slot_3_klawia;

    public GameObject slot_1_klawia;
    public GameObject slot_2_klawia;
    public GameObject slot_3_klawia;

    public GameObject empty_slot_1_kabelki;
    public GameObject empty_slot_2_kabelki;
    public GameObject empty_slot_3_kabelki;

    public GameObject slot_1_kabelki;
    public GameObject slot_2_kableki;
    public GameObject slot_3_kabelki;


    public int setOrderIndex;

    public void newOrder(int Index)
    {
        Debug.Log(Index);
        setOrderIndex = Index;

        switch (setOrderIndex)
        {
            case 0:
                empty_slot_1_ledy.SetActive(true);
                slot_1_ledy.SetActive(false);

                empty_slot_2_ledy.SetActive(true);
                slot_2_ledy.SetActive(false);

                empty_slot_3_ledy.SetActive(true);
                slot_3_ledy.SetActive(false);
            break;
            case 1:
                empty_slot_1_klawia.SetActive(true);
                slot_1_klawia.SetActive(false);
                empty_slot_2_klawia.SetActive(true);
                slot_2_klawia.SetActive(false);
                empty_slot_3_klawia.SetActive(true);
                slot_3_klawia.SetActive(false);
            break;
        }
    }

    public void AddItem(int index)
    {
        switch (setOrderIndex)
        {
            case 0:
                switch (index)
                {
                    case 0:
                        empty_slot_1_ledy.SetActive(false);
                        slot_1_ledy.SetActive(true);
                        break;
                    case 1:
                        empty_slot_2_ledy.SetActive(false);
                        slot_2_ledy.SetActive(true);
                        break;
                    case 2:
                        empty_slot_3_ledy.SetActive(false);
                        slot_3_ledy.SetActive(true);
                        break;
                }
                break;
            case 2:
                switch (index)
                {
                    case 0:
                        empty_slot_1_klawia.SetActive(false);
                        slot_1_klawia.SetActive(true);
                        break;
                    case 1:
                        empty_slot_2_klawia.SetActive(false);
                        slot_2_klawia.SetActive(true);
                        break;
                    case 2:
                        empty_slot_3_klawia.SetActive(false);
                        slot_3_klawia.SetActive(true);
                        break;
                }
                break;
            }
    }
}
