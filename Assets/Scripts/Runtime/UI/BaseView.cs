using System.IO;
using UnityEditor;
using UnityEngine.UIElements;

namespace Com.ThirdNerve.Backfire.Runtime.UI
{
    public class BaseView<T> : VisualElement
    {
        private const string UxmlBasePath = "UI";
        
        protected BaseView()
        {
            var container = GetVisualTree(typeof(T).Name);
            container.CloneTree(this);
        }

        private static VisualTreeAsset GetVisualTree(string name)
        {
            var templateContainerPath = $"Assets/{UxmlBasePath}/{name}/{name}.uxml";
            var visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(templateContainerPath);
            if (visualTreeAsset is null)
            {
                throw new FileNotFoundException($"Template {name} not found", templateContainerPath);
            }
            
            return visualTreeAsset;
        }
    }
}