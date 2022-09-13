using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateForStateButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RotateForState.State state;
    public RotateForState rotateForState;

    public void OnPointerEnter(PointerEventData eventData)
    {
        rotateForState.ChangeState(state);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rotateForState.ChangeState(RotateForState.State.normal);
    }

}