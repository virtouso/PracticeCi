using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Help.Script.Help.Utility
{
    public interface IUtilityAssetLoader
    {
        void LoadAssetByStringAddressAsync<T>(string address, Action<AsyncOperationHandle<T>> callback);

        void LoadAssetByAssetReferenceAsync<T>(AssetReference assetReference, Action<AsyncOperationHandle<T>> callback);

        T LoadAssetSync<T>(object address);
    }
    
    public class UtilityAddressables : IUtilityAssetLoader
    {
        public void LoadAssetByStringAddressAsync<T>(string address, Action<AsyncOperationHandle<T>> callback)
        {
            UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<T>(address).Completed += callback;
        }

        public void LoadAssetByAssetReferenceAsync<T>(AssetReference assetReference,
            Action<AsyncOperationHandle<T>> callback)
        {
            assetReference.LoadAssetAsync<T>().Completed += callback;
        }


        public T LoadAssetSync<T>(object address)
        {
            throw new NotImplementedException();
            // return UnityEngine.AddressableAssets.Addressables.LoadAsset<T>(address).Result;
        }

    }
    
    
    
}