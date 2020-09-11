﻿using UnityEngine;
using UnityEditor;

namespace HierarchyDecorator
    {
    [System.Serializable]
    internal class GlobalSettings
        {   
        public bool showComponents = true;
        public bool showLayers = true;
        public bool showActiveToggles = true;

        public bool twoToneBackground;

        public Color GetTwoToneColour(Rect selectionRect)
            {
            bool hasRemainder = selectionRect.y % 32 != 0;

            if (EditorGUIUtility.isProSkin)
                {
                return hasRemainder
                    ? new Color (0.25f, 0.25f, 0.25f, 1)
                    : new Color (0.225f, 0.225f, 0.225f, 1);
                }
            else
                {
                return hasRemainder
                    ? new Color (0.8f, 0.8f, 0.8f, 1)
                    : new Color (0.75f, 0.75f, 0.75f, 1);
                }
            }

        public void OnDraw()
            {
            EditorGUI.indentLevel++;
                {
                EditorGUILayout.LabelField ("Features", EditorStyles.boldLabel);

                EditorGUI.indentLevel++;
                    {
                    HierarchyDecoratorGUI.ToggleAuto (ref showActiveToggles, "Show GameObject Toggles");
                    HierarchyDecoratorGUI.ToggleAuto (ref showComponents, "Show Common Components");
                    HierarchyDecoratorGUI.ToggleAuto (ref showLayers, "Show Current Layer");
                    }
                EditorGUI.indentLevel--;

                EditorGUILayout.Space ();

                EditorGUILayout.LabelField ("Style", EditorStyles.boldLabel);

                EditorGUI.indentLevel++;
                    {
                    HierarchyDecoratorGUI.ToggleAuto (ref twoToneBackground, "Show Two Tone Background");
                    }
                EditorGUI.indentLevel--;
                }
            EditorGUI.indentLevel--;
            }
        }
    }
