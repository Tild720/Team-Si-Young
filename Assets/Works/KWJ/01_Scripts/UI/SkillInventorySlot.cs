using UnityEngine;
using UnityEngine.EventSystems;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts.UI
{
    public class SkillInventorySlot : MonoBehaviour, IDropHandler
    {
        private DragSkillObject _dagSkillObject;
        
        public void PutInSkill(DragSkillObject dagSkillObject)
        {
            if(_dagSkillObject == dagSkillObject) return;

            if (_dagSkillObject != null)
            {
                _dagSkillObject.ResetOrigin();
            }

            _dagSkillObject = dagSkillObject;
            _dagSkillObject.IsInInventroySlot = true;
        }

        public FraudSkillSo GetSkillSo()
        {
            if(_dagSkillObject != null)
                return _dagSkillObject.GetSkillSo();

            return null;
        }
    
        public void OnDrop(PointerEventData eventData)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.transform.position = transform.position;
            DragSkillObject dragSkillObject  = eventData.pointerDrag.GetComponent<DragSkillObject>();
            PutInSkill(dragSkillObject);
        }
    }
}