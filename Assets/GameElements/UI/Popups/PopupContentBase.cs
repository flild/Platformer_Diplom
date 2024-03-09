using System;
using UnityEngine;

namespace Platformer.UI.Popup
{
    public abstract class PopupContentBase : MonoBehaviour
    {
        public abstract event Action HidePopup;
    }

}
