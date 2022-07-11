using Newtonsoft.Json;

public struct LinkComponent
{
    [JsonIgnore]
    public ILinkable View;
}