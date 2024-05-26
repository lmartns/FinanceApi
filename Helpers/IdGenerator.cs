namespace finance_api.Helpers;

public static class IdGenerator
{
   public static Guid GeneratorNewGuid()
    {
        return Guid.NewGuid();
    }
}