using UseCases;

namespace AccountIt;

public static class DependencyInjection
{
    // Configure services for the application
    // Konfigurera tjänster för applikationen
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register the TransactionService
        // Registrera TransactionService

        // Add other services here as needed
        // Lägg till andra tjänster här efter behov

        return services;
    }
}