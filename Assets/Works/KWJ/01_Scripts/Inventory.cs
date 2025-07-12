using System.Collections.Generic;
using UnityEngine;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] private int _soltCount = 4;

        private int _seledSlot;
        
        private List<InventorySlot> _inventorySlots = new List<InventorySlot>();
        
        private void Start()
        {
            for (int i = 0; i < _soltCount; i++)
            {
                GameObject slotObject = Instantiate(_slotPrefab);
                InventorySlot inventorySlot = slotObject.GetComponent<InventorySlot>();
                _inventorySlots.Add(inventorySlot);
            }
        }

        public void PutInSkill()
        {

        }
        
        public void TakeOutSkill()
        {
            
        }

        public bool FindSkillTypeSlot(SkillType skillType)
        {
            for (int i = 0; i < _inventorySlots.Count; i++)
            {
                if (_inventorySlots[i].GetSkillType() == skillType)
                    return true;
            }

            return false;
        }
    }
}