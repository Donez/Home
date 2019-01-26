using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Draggable))]
    public class Clingy : MonoBehaviour
    {
        private Vector2 originalPosition;
        public float Speed = 1.0f;

        void Awake()
        {
            originalPosition = transform.position;
        }

        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPosition, Speed * Time.deltaTime);
        }
    }
}