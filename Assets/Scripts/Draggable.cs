using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class Draggable : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public delegate void DragEndEvent();
        public event DragEndEvent OnDragEnd;

        public void OnDrag(PointerEventData eventData)
        {
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;
            transform.position = worldPos;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnDragEnd?.Invoke();
        }
    }
}