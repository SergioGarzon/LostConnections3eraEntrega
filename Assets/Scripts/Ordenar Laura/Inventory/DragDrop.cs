using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

    public class DragDrop : MonoBehaviour {
        public static Item item = null;
        public static bool  toolSelected = false; //<-- I don't know what this is for.
        public static int textureSize = 64;
        public static bool contained = false;
 
        private bool  mouseDown = false;
        private float rightdown = 0.0f;
 
        void CaptureMouse (){
            if (Input.GetMouseButtonDown (0)) {
                mouseDown = true;
            }
 
            if(Input.GetMouseButtonUp(0) && mouseDown)
            {
                mouseDown = false;
                toolSelected = false;
            }
        }
 
        void Update (){
            CaptureMouse();
        }
 
        void OnGUI (){
            if(item != null)
            {
                GUI.depth = -1;
                Vector3 mousePos = Input.mousePosition;
                Rect pos = new Rect(mousePos.x  - textureSize / 2,
                    Screen.height - mousePos.y - textureSize / 2,
                    textureSize, textureSize);
                GUI.Label(pos, item.texture);
            }
        }
    }
