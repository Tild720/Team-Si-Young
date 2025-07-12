using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts.UI
{
    public class DragSkillObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private FraudSkillSo skillSo;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextMeshProUGUI skillName;
        [SerializeField] private TextMeshProUGUI skillName2;
        [SerializeField] private TextMeshProUGUI skillPirce;
        [SerializeField] private GameObject lockUI;
        
        private Transform _originParents;
        private Vector3 _originPostiton;
        
        private Transform _beginParents;
        private Vector3 _beginPostiton;

        public bool IsInInventroySlot { get; set; }
        public bool IsBuy { get; set; }

        private void Awake()
        {
            skillName.text = skillSo.SkillName;
            skillName2.text = "<" + skillSo.SkillName + ">";
            skillPirce.text = skillSo.Price + "";
        }

        private void Start()
        {
            _originPostiton = transform.position;
            _originParents = transform.parent;
        }

        public FraudSkillSo GetSkillSo()
        {
            if(skillSo != null)
                return skillSo;

            return null;
        }

        public void BuySkill()
        {
            if (PlayerManager.Instance.Player.PlayerMoney.CurrentMoney < skillSo.Price)
                return;
            
            lockUI.SetActive(false);
            IsBuy = true;
        }

        public void ResetOrigin()
        {
            transform.SetParent(_originParents);
            transform.position = _originPostiton;
            IsInInventroySlot = false;
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _beginPostiton = transform.position;
            _beginParents = transform.parent;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_beginParents == transform.parent)
            {
                if(IsInInventroySlot == true)
                    ResetOrigin();
                else
                    transform.position = _beginPostiton;
            }
            
            canvasGroup.blocksRaycasts = true;
        }
    }
}