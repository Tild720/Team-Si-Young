using System.Collections.Generic;
using Core.Scripts;
using UnityEngine;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts.UI
{
    public class SkillManager : MonoSingleton<SkillManager>
    {
        [SerializeField] private Transform _inventoryPanel;
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] private int _slotCount = 3;

        private int _seledSlot;
        
        private List<SkillInventorySlot> _inventorySlots = new List<SkillInventorySlot>();
        private List<FraudSkillSo> _fraudSkillSlots = new List<FraudSkillSo>();
        
        private void Start()
        {
            for (int i = 0; i < _slotCount; i++)
            {
                if(_inventoryPanel.childCount == 3) break;
                
                GameObject slotObject = Instantiate(_slotPrefab, _inventoryPanel);
                SkillInventorySlot skillInventorySlot = slotObject.GetComponent<SkillInventorySlot>();
                _inventorySlots.Add(skillInventorySlot);
            }
        }

        public List<FraudSkillSo> GetSkillList()
        {
            _fraudSkillSlots.Clear();
                
            for (int i = 0; i < _slotCount; i++)
            {
                if(_inventorySlots[i].GetSkillSo() != null)
                    _fraudSkillSlots.Add(_inventorySlots[i].GetSkillSo());
            }
            
            return _fraudSkillSlots;
        }
    }
}