using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
    {
        public float BaseSpeed = 5.0f;
        public float BaseJump = 200.0f;
        public float GroundedDistance = 0.55f;
        public float MaxChargedJump = 1.5f;
        public float JumpChargeSpeed = 1.0f;
        public float JumpChargeNow = 1.0f;

        private Transform m_transform;
        private Vector2 m_direction;
        private Rigidbody2D m_rigidbody;
        private bool m_jump;
        private bool m_chargingJump;
        private float m_horizontalInput;
        private SpriteRenderer m_spriteRenderer;
        private Animator m_animator;
        private Transform m_dustRoot;
        private ParticleSystem m_dustParticles;

        private Vector3 m_dustRight, m_dustLeft;

        void Awake()
        {
            m_transform = GetComponent<Transform>();
            m_direction = Vector2.zero;
            m_rigidbody = GetComponent<Rigidbody2D>();
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            m_animator = GetComponent<Animator>();
            m_dustRoot = m_transform.Find("DustRoot");
            m_dustParticles = m_dustRoot.GetComponentInChildren<ParticleSystem>();

            m_jump = false;
        }

        public void ResetPosition(GameObject spawn = null)
        {
            if (spawn == null)
            {
                spawn = GameObject.FindGameObjectWithTag("PlayerSpawn");
            }

            if (spawn == null)
            {
                Debug.LogError("Couldn't find player spawn");
                return;
            }

            transform.position = spawn.transform.position;
        }

        void Update()
        {
            var oldChargingValue = m_chargingJump;
            m_chargingJump = Input.GetButton("ChargeJump");

            if ((oldChargingValue && !m_chargingJump) || Input.GetButtonDown("Jump") && !m_chargingJump)
            {
                m_jump = true;
            }

            m_horizontalInput = Input.GetAxisRaw("Horizontal");

            bool grounded = IsGrounded();
            m_animator.SetBool("IsGrounded", grounded);
            m_animator.SetFloat("Velocity", Mathf.Abs(m_horizontalInput));
            m_animator.SetBool("ChargingJump", m_chargingJump && grounded);

            if (m_chargingJump && grounded)
            {
                m_horizontalInput = 0;
            }

            if(Mathf.Abs(m_horizontalInput) > 0.0f && grounded && m_dustParticles.isStopped)
                m_dustParticles.Play();
            else if(m_dustParticles.isPlaying)
                m_dustParticles.Stop();

            var dustScale = new Vector3(m_horizontalInput > 0 ? 1 : -1, 1, 1);
            if (m_dustRoot.transform.localScale != dustScale)
            {
                m_dustRoot.transform.localScale = dustScale;
            }
        }

        void FixedUpdate()
        {
            if (Game.WorkingOnPuzzle)
                return;

            if (!Physics.autoSimulation)
                return;

            if (m_jump)
            {
                if (IsGrounded())
                    m_rigidbody.AddForce(new Vector2(0, BaseJump * JumpChargeNow));

                // reset jump charge
                JumpChargeNow = 1.0f;
                m_jump = false;
            }
            else if (m_chargingJump)
            {
                if (IsGrounded())
                {
                    // increment jump charge but never exceed MaxChargedJump value
                    JumpChargeNow = Mathf.Min(MaxChargedJump, JumpChargeNow + Time.deltaTime * JumpChargeSpeed);
                }
            }

            m_direction.x = m_horizontalInput * BaseSpeed * Time.deltaTime;

            if (Math.Abs(m_direction.x) > 0.0f)
            {
                m_spriteRenderer.flipX = m_direction.x < 0;
            }

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