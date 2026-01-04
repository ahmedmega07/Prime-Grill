namespace Restaurant.Domain.Exeptions
{
    public class NotFoundException(string resourceType, string Inditifier)
        : Exception($"{resourceType} with this {Inditifier} was not found")
    {

    }
}
