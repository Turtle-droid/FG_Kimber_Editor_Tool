using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(DrawCircle))]

class CircleEditorWindow : EditorWindow
{
   
    [SerializeField]
    GameObject myGameObject;

    [SerializeField]
    float sides;

    [SerializeField]
    float radius;

    private DrawCircle circleDrawer;

    [MenuItem("Window/CircleEditor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CircleEditorWindow));
    }

    void OnGUI()
    {
        // The actual window code goes here
        myGameObject = (GameObject)EditorGUILayout.ObjectField(myGameObject, typeof(GameObject), true);

        if (myGameObject)
        {
            circleDrawer = myGameObject.GetComponent<DrawCircle>();

                if (circleDrawer)
                {
                    circleDrawer.segments = EditorGUILayout.IntSlider("Segment slider", circleDrawer.segments, 0, 1000);

                    circleDrawer.horizRadius = EditorGUILayout.Slider("Horizontal radius slider", circleDrawer.horizRadius, 0, 10);

                    circleDrawer.vertRadius = EditorGUILayout.Slider("Vertical radius slider", circleDrawer.vertRadius, 0, 10);
                }
        }
    }
}

