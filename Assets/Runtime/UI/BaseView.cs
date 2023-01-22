using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    public class BaseView<T> : VisualElement
    {
        protected BaseView()
        {
            var container = GetVisualTree(typeof(T).Name);
            container.CloneTree(this);
        }

        private static VisualTreeAsset GetVisualTree(string name)
        {
            var templateContainerPath = $"{name}/{name}";
            var visualTreeAsset = Resources.Load<VisualTreeAsset>(templateContainerPath);
            if (visualTreeAsset is null)
            {
                throw new FileNotFoundException($"Template {name} not found", templateContainerPath);
            }
            
            return visualTreeAsset;
        }
    }
}