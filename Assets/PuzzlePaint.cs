using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PuzzlePaint : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    System.Action<PointerEventData, PuzzlePaint> OnBeginDragCallback, OnDragCallback, OnEndDragCallback, OnPointerClickCallback;
    public void setListenerDragDrop(System.Action<PointerEventData, PuzzlePaint> _OnBeginDrag, System.Action<PointerEventData, PuzzlePaint> _OnDrag, System.Action<PointerEventData, PuzzlePaint> _OnEndDrag, System.Action<PointerEventData, PuzzlePaint> _OnPointClick = null)
    {
        OnBeginDragCallback = _OnBeginDrag;
        OnDragCallback = _OnDrag;
        OnEndDragCallback = _OnEndDrag;
        OnPointerClickCallback = _OnPointClick;
    }

    public void removeAllListenerDragDrop()
    {
        OnBeginDragCallback = null;
        OnDragCallback = null;
        OnEndDragCallback = null;
        OnPointerClickCallback = null;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragCallback != null)
        {
            OnBeginDragCallback.Invoke(eventData, this);
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (OnDragCallback != null)
        {
            OnDragCallback.Invoke(eventData, this);
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragCallback != null)
        {
            OnEndDragCallback.Invoke(eventData, this);
        }
    }
}
