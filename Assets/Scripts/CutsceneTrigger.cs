using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class CutsceneTrigger : MonoBehaviour
    {
        public Cutscene CutscenePrefab;

        void OnTriggerEnter2D(Collider2D col)
        {
            Game.PlayCutscene(CutscenePrefab);
        }

        void OnTriggerExit2D(Collider2D col)
        {
            GameObject.Destroy(gameObject);
        }
    }
}