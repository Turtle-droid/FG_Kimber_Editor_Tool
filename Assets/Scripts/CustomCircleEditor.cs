using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(DrawCircle))]
public class CustomCircleEditor : Editor
{
    public void OnSceneGUI()
    {
        DrawCircle dc = (target as DrawCircle);

        EditorGUI.BeginChangeCheck();
        //Radius handle to change... radius
        float horizRadius = Handles.RadiusHandle(Quaternion.identity, dc.transform.position, dc.horizRadius, false);
        //float vertradius = Handles.RadiusHandle(Quaternion.identity, dc.transform.position, dc.vertRadius, true);
        // Handle for changing number of segments.
        float segments = Handles.ScaleValueHandle((float)dc.segments, dc.transform.position, Quaternion.identity, 5, Handles.CircleHandleCap, 1);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Changed Area Of Effect");
            //Set radius for circle object
            dc.horizRadius = horizRadius;
            dc.vertRadius = horizRadius;
            //dc.vertRadius = vertRadius;

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
