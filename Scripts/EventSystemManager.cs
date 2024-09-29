using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemManager : MonoBehaviour
{
    void Start()
    {
        // SprawdŸ, czy istnieje ju¿ aktywny EventSystem w scenie
        EventSystem existingEventSystem = FindObjectOfType<EventSystem>();

        // Jeœli jest wiêcej ni¿ jeden EventSystem, usuñ nadmiarowy
        if (existingEventSystem != null && existingEventSystem.gameObject != this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
