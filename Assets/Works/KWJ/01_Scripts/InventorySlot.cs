using UnityEngine;
using UnityEngine.EventSystems;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        private DragSkillObject _dagSkillObject;
        
        public void PutInSkill(DragSkillObject dagSkillObject)
        {
            if(_dagSkillObject == dagSkillObject) return;
            
            if (_dagSkillObject != null)
                _dagSkillObject.SetOrigin();

            _dagSkillObject = dagSkillObject;
            _dagSkillObject.IsInInventroySlot = true;
        }
        
        public void TakeOutSkill()
        {
            _dagSkillObject = null;
        }

        public SkillType GetSkillType()
        {
            if(_dagSkillObject != null)
                return _dagSkillObject.GetSkillSo().SkillType;

            return SkillType.None;
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