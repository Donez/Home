using UnityEngine;

public class Background : MonoBehaviour
{
    public Renderer Background1;
    public Renderer Background2;
    public Renderer Background3;
    public Vector2 Offset = new Vector2(13, 0);

    public float Speed = 0.001f;

    private Transform m_transform;
    private Transform m_cameraTransform;

    private Transform m_playerSpawn;
    private Transform m_player;

    void Start()
    {
        m_transform = transform;
        m_cameraTransform = Camera.main.transform;

        m_playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        var position = m_cameraTransform.position;
        position.z = 1;

        m_transform.position = position;

        var distance = PlayerDistanceFromSpawn() + Offset;

        Background1.material.SetTextureOffset("_MainTex", -distance * 0.5f * Speed);
        Background2.material.SetTextureOffset("_MainTex", -distance * 0.75f * Speed);
        Background3.material.SetTextureOffset("_MainTex", -distance * Speed);

        Debug.Log(distance);
    }

    private Vector2 PlayerDistanceFromSpawn()
    {
        return m_playerSpawn.position - m_player.position;
    }
}
