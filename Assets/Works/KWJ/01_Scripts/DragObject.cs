using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Works.KWJ._01_Scripts.SO;

namespace Works.KWJ._01_Scripts
{
    public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private FraudSkillSo skillSo;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Image image;
        
        private Transform _originParents;
        private Vector3 _originPostiton;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _originPostiton = transform.position;
            _originParents = transform.parent;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(_originParents == transform.parent)
                transform.position = _originPostiton;
            
            canvasGroup.blocksRaycasts = true;
        }
    }
}