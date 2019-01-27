using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    public static Music Instance { get; private set; }

    public AudioClip Clip;

    private AudioSource m_source;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        m_source = GetComponent<AudioSource>();

        m_source.clip = Clip;
        m_source.loop = true;
        m_source.Play();
    }

    /// <summary>
    /// 0 to 1
    /// </summary>
    /// <param name="value">0 to 1</param>
    public void Volume(float value)
    {
        m_source.volume = value;
    }
}
