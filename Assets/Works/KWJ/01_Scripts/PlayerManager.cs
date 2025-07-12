using Core.Scripts;
using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        [field: SerializeField] public Player Player;
    }
}