using System.Collections.Generic;
using Tild.Chat;
using UnityEngine;

namespace Works.KWJ._01_Scripts.SO
{
    public enum SkillType
    {
        None = -1,
        
        HungerSkill_1,
        ParentsSkill_2,
        TravelSkill_3,
        AccidentSkill_4,
        KoreaSkill_5,
        CallSkill_6,
        InvestSkill_7,
        
        Max 
    }
    
    [CreateAssetMenu(fileName = "FraudSkillSo", menuName = "SO/FraudSkillSo", order = 0)]
    public class FraudSkillSo : ScriptableObject
    {
        public string SkillName;

        [TextArea] public string Code;

        [field: Space] 
        
        public SkillType SkillType;
        
        public int Price;

        public List<Chat> cheatChat;
    }
}