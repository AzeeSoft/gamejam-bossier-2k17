using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomCursor : MonoBehaviour
{
    private SpriteRenderer cursorSprite;
    public int cursorSizeX = 32;
    public int cursorSizeY = 32;
    public static bool showNewCursor = true;
    public GameObject cursorPrefab;
    private GameObject cursorObject;
    public Sprite cursorImage;
    // Use this for initialization
    void Start()
    {
        if(showNewCursor)
        {
            Cursor.visible = false;
            cursorObject = (GameObject)Instantiate(cursorPrefab);
            cursorSprite = cursorObject.GetComponent<SpriteRenderer>();
            cursorSprite.sprite = cursorImage;
        }
    }

    // Update is called once per frame
    void OnGUI()
    {
        if(showNewCursor)
        {
            Cursor.visible = false;
            //cursorImage.rectTransform.rect.Set(Input.mousePosition.y - cursorSizeX / 2 + cursorSizeX / 2, (Screen.height - Input.mousePosition.y) - cursorSizeY / 2 + cursorSizeY / 2, cursorSizeX, cursorSizeY);
            var screenPoint = Input.mousePosition;
            screenPoint.x = screenPoint.x + cursorSizeX / 2 + cursorSizeX / 2;
            screenPoint.y = screenPoint.y - cursorSizeY / 2 - cursorSizeY / 2;
            screenPoint.z = 1.0f; //distance of the plane from the camera
            cursorObject.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

        }
    }
}
