using UnityEngine;
using UnityEngine.EventSystems;
using EventBusSystem;

namespace Eatable
{
    public class Swiper : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private float maximumAngleDeviation;
        private bool isDraging;
        public void OnBeginDrag(PointerEventData eventData) 
        {
            isDraging = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.up = Vector3.up;
            isDraging = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.enterEventCamera == null) return;
            if (!isDraging) return;

            Vector3 temp = eventData.enterEventCamera.ScreenToWorldPoint(eventData.position);
            temp.z = 0;
            transform.up = temp - transform.position;

            if (Vector3.Angle(transform.up, Vector3.up) > maximumAngleDeviation)
            {
                if (transform.up.x > 0)
                    EventBus.RaiseEvent<IRight>(x => x.Right());
                else
                    EventBus.RaiseEvent<ILeft>(x => x.Left());

                transform.up = Vector3.up;
                isDraging = false;
            }
        }
    }
}