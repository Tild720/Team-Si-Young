using System.Collections.Generic;
using UnityEngine;

namespace Tild.Chat
{
    [CreateAssetMenu(fileName = "ChoiceSO", menuName = "SO/ChoiceSO", order = 0)]
    public class ChoiceSO : ScriptableObject
    {
        public List<Chat> choice;
    }
}