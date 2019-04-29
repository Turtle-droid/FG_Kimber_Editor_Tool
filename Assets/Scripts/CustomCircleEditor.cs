using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(DrawCircle))]
public class CustomCircleEditor : Editor
{
    

    public void OnSceneGUI()
    {
        DrawCircle dc = (target as DrawCircle);

        float size = HandleUtility.GetHandleSize(dc.transform.position) * 1.5f;
        float snap = 1.0f;

        EditorGUI.BeginChangeCheck();

        //Scale slider for horizontal radius
        float horizRadius = Handles.ScaleSlider(dc.horizRadius, dc.transform.position, dc.transform.right, Quaternion.identity, size, snap);
        //Scale slider for vertical radius
        float vertRadius = Handles.ScaleSlider(dc.vertRadius, dc.transform.position, dc.transform.up, Quaternion.identity, size, snap);

        // Handle for changing number of segments.
        float segments = Handles.ScaleValueHandle((float)dc.segments, dc.transform.position, Quaternion.identity, 5, Handles.CircleHandleCap, 1);
       
    if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Changed Area Of Effect");
            //Set radius for circle object
            dc.horizRadius = horizRadius;
            dc.vertRadius = vertRadius;

            // Make sure segments doesn't go below zero
            if (segments < 0)
            {
                segments = 0;
            }
            //Set number of segments as int
            dc.segments = (int)segments;        
        }
    }
}
