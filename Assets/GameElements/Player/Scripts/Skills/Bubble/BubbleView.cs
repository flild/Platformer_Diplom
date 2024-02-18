using UnityEngine;

namespace Platformer.Units.PlayerSpace.Skill
{
    public class BubbleView: MonoBehaviour
    {
        [SerializeField]
        private float _degreesPerSecond;
        private void Update()
        {
            transform.Rotate(new Vector3(0f, 0f, _degreesPerSecond)*Time.deltaTime);
        }
    }
}
