using UnityEngine;
using System.IO;
 
public static class IMG2Sprite {
 
   // This script loads a PNG or JPEG image from disk and returns it as a Sprite
   // Drop it on any GameObject/Camera in your scene (singleton implementation)
   //
   // Usage from any other script:
   // MySprite = IMG2Sprite.instance.LoadNewSprite(FilePath, [PixelsPerUnit (optional)])
 
   
 
   public static Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f) {
   
     // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
     
    //  Sprite NewSprite;
     Texture2D SpriteTexture = LoadTexture(FilePath);
     Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),new Vector2(0,0), PixelsPerUnit);
 
     return NewSprite;
   }
 
   public static Texture2D LoadTexture(string FilePath) {
 
     // Load a PNG or JPG file from disk to a Texture2D
     // Returns null if load fails
 
     Texture2D Tex2D;
     byte[] FileData;
 
     if (File.Exists(FilePath)){
       FileData = File.ReadAllBytes(FilePath);
       Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
       if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
         return Tex2D;                 // If data = readable -> return texture
     }  
     return null;                     // Return null if load failed
   }
}