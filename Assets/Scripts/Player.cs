using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Player : MonoBehaviour
    {
        public float BaseSpeed = 5.0f;
        public float BaseJump = 200.0f;
        public float GroundedDistance = 0.55f;

        private Transform m_transform;
        private Vector2 m_direction;
        private Rigidbody2D m_rigidbody;

        void Awake()
        {
            m_transform = GetComponent<Transform>();
            m_direction = Vector2.zero;
            m_rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                m_rigidbody.AddForce(new Vector2(0, BaseJump));
            }

            m_direction.x = Input.GetAxisRaw("Horizontal") * BaseSpeed * Time.deltaTime;

            m_transform.Translate(m_direction, Space.World);
        }


        private bool IsGrounded()
        {
            // we do linecast downwards and see if it hits "Ground"
            var linecast = Physics2D.Linecast(
                m_transform.position,
                new Vector2(
                    m_transform.position.x,
                    m_transform.position.y - GroundedDistance),
                1 << LayerMask.NameToLayer("Ground"));

            // Uncomment to see what the linecast hits
            //if (linecast.collider)
            //{
            //    Debug.Log(linecast.collider.gameObject.name);
            //}

            return linecast.collider != null;
        }
    }
}