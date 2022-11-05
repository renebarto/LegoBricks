using LegoBricks;

public enum ModifyOperation
{
    Add,
    Delete,
    Update
}

public struct Modification<T>
{
    public ModifyOperation operation;
    public T data;
    public T originalData;

    public static Modification<T> Add(T data)
    {
        Modification<T> result = new Modification<T>();
        result.operation = ModifyOperation.Add;
        result.data = data;
        return result;
    }

    public static Modification<T> Delete(T data)
    {
        Modification<T> result = new Modification<T>();
        result.operation = ModifyOperation.Delete;
        result.data = data;
        return result;
    }

    public static Modification<T> Update(T data, T originalData)
    {
        Modification<T> result = new Modification<T>();
        result.operation = ModifyOperation.Update;
        result.data = data;
        result.originalData = originalData;
        return result;
    }
}
