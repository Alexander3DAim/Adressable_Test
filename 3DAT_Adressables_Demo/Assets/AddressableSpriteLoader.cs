using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;

public class AddressableSpriteLoader : MonoBehaviour
{
    public AssetReferenceSprite newSprite; 
    private SpriteRenderer spriteRenderer;
    public string newSpriteAddress; 
    public bool useAddress;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.TryGetComponent(out spriteRenderer); 
        //newSprite.LoadAssetAsync().Completed += SpriteLoaded;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
        if (useAddress) 
            Addressables.LoadAssetAsync<Sprite>(newSpriteAddress).Completed += SpriteLoaded; 
        else 
            newSprite.LoadAssetAsync().Completed += SpriteLoaded;
    }
    private void SpriteLoaded(AsyncOperationHandle<Sprite> obj)
    {
        switch (obj.Status)
        {
            case AsyncOperationStatus.Succeeded: spriteRenderer.sprite = obj.Result; break;
            case AsyncOperationStatus.Failed: Debug.LogError("Sprite load failed."); break;
            default: // case AsyncOperationStatus.None: break; } }
                     // Update is called once per frame
                break;
        }
        
    }
}
