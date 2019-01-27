using UnityEngine;

public class Background : MonoBehaviour
{
    public SpriteRenderer Background1;
    public SpriteRenderer Background2;

    private Transform m_transform;
    private Transform m_cameraTransform;

    private Transform m_playerSpawn;
    private Transform m_player;

    private Material m_bg1mat, m_bg2mat;

    void Start()
    {
        m_transform = transform;
        m_cameraTransform = Camera.main.transform;

        m_playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        m_player = GameObject.FindGameObjectWithTag("Player").transform;

        m_bg1mat = Background1.material;
        m_bg2mat = Background2.material;
    }

    private void Update()
    {
        m_transform.position = m_cameraTransform.position;

        var distance = PlayerDistanceFromSpawn();

        m_bg1mat.SetTextureOffset("_MainTex", distance * 0.9f);
        m_bg2mat.SetTextureOffset("_MainTex", distance);
    }

    private Vector2 PlayerDistanceFromSpawn()
    {
        return m_playerSpawn.position - m_player.position;
    }
}
