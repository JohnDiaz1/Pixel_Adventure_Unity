using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuToggle : MonoBehaviour
{
    [SerializeField]
    bool initialState;
    [SerializeField]
    UIAnimation uiAnimation;

    bool currentState;
    [SerializeField]
    UnityEvent turnedOn;
    [SerializeField]
    UnityEvent turnedOff;

    public UnityEvent TurnedOn => turnedOn;
    public UnityEvent TurnedOff => turnedOff;

    private void Start()
    {
        if (initialState == true)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
        
    }

    public void ToggleState()
    {
        if (!uiAnimation.isPlaying)
        {
            currentState = !currentState;
            if (currentState == true)
            {
                TurnOn();
            }
            else
            {
                TurnOff();
            }
        }
    }

    public void TurnOn()
    {
        if (!uiAnimation.isPlaying)
        {
            currentState = true;
            turnedOn.Invoke();
        }
    }

    public void TurnOff()
    {
        if (!uiAnimation.isPlaying)
        {
            currentState = false;
            turnedOff.Invoke();
        }
    }

}
