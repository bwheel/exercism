using System;

public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin() =>
        database.BeginTransaction();


    public void Write(string data) =>
        safeExecute(
            () => database.Write(data),
            Dispose
        );


    public void Commit() =>
        safeExecute(
            database.EndTransaction,
            Dispose
        );


    public void Dispose() =>
        database.Dispose();

    private void safeExecute(Action execute, Action onError)
    {
        try
        {
            execute();
        }
        catch
        {
            onError();
        }
    }
}
