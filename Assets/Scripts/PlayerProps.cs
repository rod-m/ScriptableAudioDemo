using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "PlayerProperties", menuName = "Make Player Props", order = 0)]
    public class PlayerProps : ScriptableObject
    {
        public float maxSpeed;
        public int maxHealth;
    }
}