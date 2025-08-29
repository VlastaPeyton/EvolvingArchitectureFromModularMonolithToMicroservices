using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Passes.DataAccess.Database;

namespace Passes.API.EventBus.Outbox
{
    internal static class OutboxExtension
    {   
        // Treba mi ovo jer sam u PassesDbContext napravio Outbox tabelu pa da configurisem Outbox pattern u EventBusModule.cs
        public static void ConfigureOutbox(this IBusRegistrationConfigurator configurator)
        {
            configurator.AddEntityFrameworkOutbox<PassesDbContext>(entityFrameworkOutboxConfig =>
            {
                entityFrameworkOutboxConfig.UsePostgres();
                entityFrameworkOutboxConfig.UseBusOutbox();
                entityFrameworkOutboxConfig.DuplicateDetectionWindow = TimeSpan.FromSeconds(30);
            });
        }
    }
}
