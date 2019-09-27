using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapControl : MonoBehaviour
{
    public RectTransform Minimap_map;
    public RectTransform Minimap_target;

    public Transform Target;

    public float Scene_height;
    public float Scene_width;

    private float Scale_X, Scale_Y;

    public ETCJoystick ETCleft;
    public ETCJoystick ETCright;

    // Start is called before the first frame update
    void Start()
    {
        ETCleft.onMove.AddListener((Vector2 v2) => { Set_Minimap_Target_Position(v2); });
        ETCright.onMove.AddListener((Vector2 v2) => { Set_Minimap_Target_Rotation(v2); });
        Set_Minimap_Target_Position(new Vector2());
    }

    // Update is called once per frame
    void Update()
    {
        //Set_Minimap_Target_Position(new Vector2());
        //Set_Minimap_Target_Rotation(new Vector2());
    }

    public void Set_Minimap_Target_Position(Vector2 vector2)
    {
        Scale_X = Target.localPosition.x / Scene_width;
        Scale_Y = Target.localPosition.z / Scene_height;
        Minimap_target.anchoredPosition3D = new Vector3(Minimap_map.rect.width * Scale_X, Minimap_map.rect.height * Scale_Y);
        
    }

    public void Set_Minimap_Target_Rotation(Vector2 vector2)
    {
        Minimap_target.gameObject.transform.localEulerAngles = new Vector3(0, 0, -Target.localEulerAngles.y);
    }

    public void Set_Targer_Position()
    {
        ETCleft.enabled = false;
        StartCoroutine("Set_Targer_position");
    }

    IEnumerator Set_Targer_position()
    {
        Vector3 vector3 = Input.mousePosition;
        float x = Minimap_map.rect.width - (Screen.width - vector3.x);
        float y = Minimap_map.rect.height - (Screen.height - vector3.y);

        Minimap_target.anchoredPosition3D = new Vector3(x, y);
        //Debug.Log("X===" + (x / Minimap_map.rect.width) * Scene_width);
        //Debug.Log("Y===" + (y / Minimap_map.rect.height) * Scene_height);
        Target.position = new Vector3((x / Minimap_map.rect.width) * Scene_width, Target.localPosition.y, (y / Minimap_map.rect.height) * Scene_height);
        yield return Target.position = new Vector3((x / Minimap_map.rect.width) * Scene_width, Target.localPosition.y, (y / Minimap_map.rect.height) * Scene_height);
        ETCleft.enabled = true;
    }
}
