namespace SendEmail.Api.Endpoint;

public interface IEndpoint
{
    public static abstract void Map(IEndpointRouteBuilder builder); 
}
