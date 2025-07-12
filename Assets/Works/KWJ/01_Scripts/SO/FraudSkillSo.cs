using UnityEngine;

namespace Works.KWJ._01_Scripts.SO
{
    public enum SkillType
    {
        None = -1,
        
        Test1,
        Test2,
        
        Max 
    }
    
    [CreateAssetMenu(fileName = "FraudSkillSo", menuName = "SO/FraudSkillSo", order = 0)]
    public class FraudSkillSo : ScriptableObject
    {
        public string SkillName;

        [TextArea] public string Explanation;

        [field: Space] 
        
        public SkillType SkillType;
    }
}