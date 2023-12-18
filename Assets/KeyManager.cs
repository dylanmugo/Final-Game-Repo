using System.Collections.Generic;

public class KeyManager
{
    private static KeyManager _instance;
    private HashSet<int> collectedKeys = new HashSet<int>();

    public static KeyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new KeyManager();
            }
            return _instance;
        }
    }

    public bool HasKey(int keyID)
    {
        return collectedKeys.Contains(keyID);
    }

    public void AddKey(int keyID)
    {
        collectedKeys.Add(keyID);
    }
}
