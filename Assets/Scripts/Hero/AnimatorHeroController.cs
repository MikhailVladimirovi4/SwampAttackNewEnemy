using UnityEngine;

public class AnimatorHeroController : MonoBehaviour
{
    public static class Params
    {
        public const string Shoot = nameof(Shoot);
        public const string Speed = nameof(Speed);
    }

    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string Run = nameof(Run);
        public const string Shoot = nameof(Shoot);
    }
}
