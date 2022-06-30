using System.Collections.Generic;

public static class UidGenerator
{
    private static readonly HashSet<Uid> HashSet = new HashSet<Uid>();
    private static int _current;

    public static void Clear()
    {
        _current = 0;
        HashSet.Clear();
    }

    private static int NextUid
    {
        get
        {
            if (_current == int.MaxValue)
                _current = 0;
            return _current++;
        }
    }

    public static Uid Next()
    {
        Uid uid;
        do
        {
            uid = (Uid) NextUid;
        } while (HashSet.Contains(uid));

        HashSet.Add(uid);
        return uid;
    }

    public static void Reserve(Uid uid) => HashSet.Add(uid);

    public static void Remove(Uid uid)
    {
        HashSet.Remove(uid);
    }
}