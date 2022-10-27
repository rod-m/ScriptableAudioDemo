using UnityEngine;

namespace SalfordGames
{
    [CreateAssetMenu(fileName = "PlayerProperties", menuName = "Make Player Props", order = 0)]
    public class PlayerProps : ScriptableObject
    {
        public float maxSpeed = 5f;
        public float jumpHeight = 10f;
        public float gravityValue = -9.81f;
        public int maxHealth = 100;
        public float pushPower = 2.0f;
    }
}