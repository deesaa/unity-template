using System;
using Newtonsoft.Json;

namespace ECS.Utils.Extensions
{
    public struct MonoLinkComponent<T> where T : ILinkable
    {
        [JsonIgnore]
        public T View;
    }
}