/*
 * Copyright (c) 2013, Nick Gravelyn.
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 *    1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 *
 *    2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 *
 *    3. This notice may not be removed or altered from any source
 *    distribution.
 */

using UnityEngine;
using UnityEditor;

namespace UnityToolbag
{
    [CustomEditor(typeof(SortingLayerExposed))]
    public class SortingLayerExposedEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            // Get the renderer from the target object
            var renderer = (target as SortingLayerExposed).gameObject.renderer;

            // If there is no renderer, we can't do anything
            if (!renderer)
            {
                return;
            }

            // Expose the sorting layer name
            string newSortingLayerName = EditorGUILayout.TextField("Sorting Layer Name", renderer.sortingLayerName);
            if (newSortingLayerName != renderer.sortingLayerName) {
                Undo.RecordObject(renderer, "Edit Sorting Layer Name");
                renderer.sortingLayerName = newSortingLayerName;
                EditorUtility.SetDirty(renderer);
            }

            // Expose the sorting layer ID
            int newSortingLayerId = EditorGUILayout.IntField("Sorting Layer ID", renderer.sortingLayerID);
            if (newSortingLayerId != renderer.sortingLayerID) {
                Undo.RecordObject(renderer, "Edit Sorting Layer ID");
                renderer.sortingLayerID = newSortingLayerId;
                EditorUtility.SetDirty(renderer);
            }

            // Expose the manual sorting order
            int newSortingLayerOrder = EditorGUILayout.IntField("Sorting Layer Order", renderer.sortingOrder);
            if (newSortingLayerOrder != renderer.sortingOrder) {
                Undo.RecordObject(renderer, "Edit Sorting Order");
                renderer.sortingOrder = newSortingLayerOrder;
                EditorUtility.SetDirty(renderer);
            }
        }
    }
}