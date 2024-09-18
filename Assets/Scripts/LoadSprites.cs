using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadSprites : MonoBehaviour
{
    [SerializeField] private AssetRendererPair[] _assets;

    public void Load()
    {
        foreach (AssetRendererPair pair in _assets)
        {
            StartCoroutine(LoadCoroutine(pair));
        }
    }

    private IEnumerator LoadCoroutine(AssetRendererPair pair)
    {
        AsyncOperationHandle<Sprite> handle = pair.AssetReference.LoadAssetAsync<Sprite>();
        yield return handle;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = handle.Result;
            pair.SpriteRenderer.sprite = sprite;
        }
    }

    [Serializable]
    public struct AssetRendererPair
    {
        public SpriteRenderer SpriteRenderer;
        public AssetReferenceSprite AssetReference;
    }
}
