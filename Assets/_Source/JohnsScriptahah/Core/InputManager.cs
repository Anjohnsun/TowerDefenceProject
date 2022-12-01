using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private List<KeyCode> _inventoryKeys;

    public UnityEvent<KeyCode> OnInventorySlotClicked = new UnityEvent<KeyCode>();
    public UnityEvent OnMouseClick = new UnityEvent();

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            OnMouseClick.Invoke();

        foreach(KeyCode key in _inventoryKeys)
        {
            if (Input.GetKey(key))
                OnInventorySlotClicked.Invoke(key);
        }
    }

}
