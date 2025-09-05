public class LoggingMiddleware
{
    // Field
    private readonly RequestDelegate _next;

    // Constructor

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // Method som kalles for hver HTTP-forespørsel
    public async Task InvokeAsync(HttpContext context)
    {
        // Logg forespørselsdetaljer
        Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");

        // Kall neste middleware i kjeden
        await _next(context);

        // Logg svarstatus
        Console.WriteLine($"Outgoing Response: {context.Response.StatusCode}");
    }




    
}