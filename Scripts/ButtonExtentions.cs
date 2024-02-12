using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace CodeHelper.Unity
{
    internal static class ButtonExtentions
    {
        /// <summary>
        /// Sets Actionswhich work once in a while
        /// </summary>
        /// <param name="actions"></param>
        internal static void SetDisposableListeners(this Button self, List<Action<Button>> actions)
        {
            self.onClick.AddListener(DoAction);
            void DoAction()
            {
                foreach (var item in actions) item(self);
                self.onClick.RemoveListener(DoAction);
            }
        }

        /// <summary>
        /// Sets Action which works once in a while
        /// </summary>
        /// <param name="action"></param>
        internal static void SetDisposableListener(this Button self, Action<Button> action)
        {
            self.onClick.AddListener(DoAction);
            void DoAction()
            {
                action(self);
                self.onClick.RemoveListener(DoAction);
            }
        }

        /// <summary>
        /// If true on click removes interectable, else do nothing
        /// </summary>
        /// <param name="value"></param>
        internal static void OffInterectableOnClick(this Button self, bool value)
        {
            self.onClick.AddListener(() =>
            {
                if (value) self.interactable = false;
                else self.interactable = true;
            });
        }

        /// <summary>
        /// If true on click setActive false, else do nothing
        /// </summary>
        /// <param name="value"></param>
        internal static void OffOnClick(this Button self, bool value)
        {
            self.onClick.AddListener(() =>
            {
                if (value) self.gameObject.SetActive(false);
                else self.gameObject.SetActive(true);
            });
        }
    }
}
