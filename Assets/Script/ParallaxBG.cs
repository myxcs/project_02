using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    public Material bg1;
    public Material bg2;
    public Material bg3;
    public Material bg4;
    public Material bg5;

    float offset1, offset2, offset3, offset4, offset5;   
    void Update()
    {
        offset5 -= Time.deltaTime * .4f;
        offset4 -= Time.deltaTime * .3f;
        offset3 -= Time.deltaTime * .2f;
        offset2 -= Time.deltaTime * .1f;
        
       bg2.mainTextureOffset = new Vector2(offset2, 0);
       bg3.mainTextureOffset = new Vector2(offset3, 0);
       bg4.mainTextureOffset = new Vector2(offset4, 0);
       bg5.mainTextureOffset = new Vector2(offset5, 0);
    
    }
}
