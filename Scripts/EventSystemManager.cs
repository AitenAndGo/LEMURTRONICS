using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemManager : MonoBehaviour
{
    void Start()
    {
        // Sprawd�, czy istnieje ju� aktywny EventSystem w scenie
        EventSystem existingEventSystem = FindObjectOfType<EventSystem>();

        // Je�li jest wi�cej ni� jeden EventSystem, usu� nadmiarowy
        if (existingEventSystem != null && existingEventSystem.gameObject != this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
