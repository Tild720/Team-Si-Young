using UnityEngine;
using UnityEngine.EventSystems;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        private FraudSkillSo _skillSo;
        
        public void PutInSkill(FraudSkillSo skillSo)
        {
            if (_skillSo != null)
            {
                
            }

            _skillSo = skillSo;
        }
        
        public void TakeOutSkill()
        {
            _skillSo = null;
        }

        public SkillType GetSkillType()
        {
            if(_skillSo != null)
                return _skillSo.SkillType;

            return SkillType.None;
        }
    
        public void OnDrop(PointerEventData eventData)
        {
            eventData.position = transform.position;
        }
    }
}