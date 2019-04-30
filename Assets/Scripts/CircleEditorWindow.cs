using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(DrawCircle))]
class CircleEditorWindow : EditorWindow
{
   
    [SerializeField]
    GameObject myGameObject;

    [SerializeField]
    int segments;

    [SerializeField]
    float horizRadius;

    [SerializeField]
    float vertRadius;

    private DrawCircle circleDrawer;

    [MenuItem("Window/CircleEditor")]
    public static void ShowWindow()
    {
       EditorWindow window = EditorWindow.GetWindow(typeof(CircleEditorWindow));
       window.Show();
    }

    private void OnEnable()
    {
        myGameObject = Selection.activeGameObject;
    }

    void OnSelectionChange()
    {
        myGameObject = Selection.activeGameObject;
    }

    void OnGUI()
    {
        myGameObject = (GameObject)EditorGUILayout.ObjectField(myGameObject, typeof(GameObject), true);

        if (myGameObject)
        {
            circleDrawer = myGameObject.GetComponent<DrawCircle>();

            if (circleDrawer)
            {
                EditorGUI.BeginChangeCheck();

                segments = EditorGUILayout.IntSlider("Segment slider", circleDrawer.segments, 0, 1000);

                horizRadius = EditorGUILayout.Slider("Horizontal radius slider", circleDrawer.horizRadius, 0, 10);

                vertRadius = EditorGUILayout.Slider("Vertical radius slider", circleDrawer.vertRadius, 0, 10);

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(circleDrawer, "Changed Circle");

                    circleDrawer.segments = segments;
                    circleDrawer.horizRadius = horizRadius;
                    circleDrawer.vertRadius = vertRadius;

                    circleDrawer.CallUpdate();
                }
            }

            else
            {
                Debug.Log(myGameObject.name + " is not a circle drawer");
            }
        }
    }
}

