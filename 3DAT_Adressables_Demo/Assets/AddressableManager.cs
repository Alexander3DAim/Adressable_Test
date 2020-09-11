using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressableManager : MonoBehaviour
{
    [SerializeField] AssetReference assetReference;
    [SerializeField] AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] GameObject spawned = null;

    IEnumerator AddressablesPrefabs()
    {
        AsyncOperationHandle<GameObject> obj = Addressables.InstantiateAsync(assetReferenceGameObject);

        while (!obj.IsDone)
        {
            yield return null;
        }

        obj.Result.transform.position = new Vector3(0, 0, -7.5f);
        spawned = obj.Result;
    }

    IEnumerator AddressablesScenes()
    {
        while (!assetReference.LoadSceneAsync(UnityEngine.SceneManagement.LoadSceneMode.Additive).IsDone)
        {
            yield return null;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        spawned = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            if(spawned == null)
                StartCoroutine(AddressablesPrefabs());
            else
            {
                Destroy(spawned);
                spawned = null;
            }
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
                StartCoroutine(AddressablesScenes());
        }
    }
}
