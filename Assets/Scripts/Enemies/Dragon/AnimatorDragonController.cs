using UnityEngine;

public class AnimatorDragonController : MonoBehaviour
{
    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string Fly = nameof(Fly);
        public const string Attack = nameof(Attack);
    }
}
