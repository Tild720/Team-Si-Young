using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts
{
    public class DragSkillObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private FraudSkillSo skillSo;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextMeshProUGUI skillName;
        
        private Transform _originParents;
        private Vector3 _originPostiton;
        
        private Transform _beginParents;
        private Vector3 _beginPostiton;

        public bool IsInInventroySlot { get; set; }

        private void Awake()
        {
            skillName.text = skillSo.SkillName;
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

        public void SetOrigin()
        {
            transform.SetParent(_originParents);
            transform.position = _originPostiton;
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
                    SetOrigin();
                else
                    transform.position = _beginPostiton;
            }
            
            canvasGroup.blocksRaycasts = true;
        }
    }
}