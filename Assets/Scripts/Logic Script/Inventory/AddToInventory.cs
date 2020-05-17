using UnityEngine;
using System.Collections;
 
// http://forum.unity3d.com/threads/here-is-a-drag-and-drop-inventory.98893/
 
//enables gameobject to be added to the inventory
public class AddToInventory : MonoBehaviour {
    public string name = "DefaultItemName";
 
    [HideInInspector] public Item item = new Item();
    bool mouseDown = false;
    bool mouseOver = false;
    Color color = new Color(0.4f, 0.4f, 0.4f, 1);
    float rightdown = 0.0f;
 
    private Color oldColor;
 
    void Start (){
        item.name = this.name;
        item.gameObject = gameObject;
        item.texture = (Texture2D) GetComponent<Renderer> ().material.mainTexture;
        oldColor = color;
        color = GetComponent<Renderer>().material.color;
        color = oldColor;
    }
 
 
    void OnMouseOver (){
        color = Color.white;
        mouseOver = true;
    }
 
 
    void OnMouseExit (){
        color = oldColor;
        mouseOver = false;
    }
 
 
 /*   void CaptureMouse (){
        if (Input.GetMouseButtonDown (0) && mouseOver) {
            mouseDown = true;
        }
 
        if (Input.GetMouseButtonUp (0) && mouseDown) {
            mouseDown = false;
        }
 
        if(!mouseOver) {
            rightdown = 0.0f;
            return;
        }
 
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) {
            MouseDown();
        }
 
        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2)) {
            MouseUp();
        }
    }*/
 
 
    void MouseDown (){
        if(Input.GetMouseButtonDown(0)) { //left click and dragging
            DragDrop.item = this.item;
            DragDrop.toolSelected = true;
        }
           
        if(Input.GetMouseButtonDown(1)) { //right clicked a thing
            rightdown = Time.time;
        }
    }
 
 
   /* void MouseUp (){
        if(Input.GetMouseButtonUp(1) && (Time.time - rightdown) < 0.25f)
        {
            GameObject inv = GameObject.Find("Inventory");
            Bag bag;
            if (inv) {
                bag = inv.GetComponent<Bag> ();
                if (bag) {
                    bag.AddItem (item);
                }
            }
        }
    }*/
 
 
    void Update (){
       // CaptureMouse();
        GetComponent<Renderer>().material.color = color;
    }
}