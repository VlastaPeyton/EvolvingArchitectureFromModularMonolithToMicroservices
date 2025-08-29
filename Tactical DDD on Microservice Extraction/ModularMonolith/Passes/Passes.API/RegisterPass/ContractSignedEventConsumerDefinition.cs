
using MassTransit;
using Passes.DataAccess.Database;
using static System.TimeSpan;
namespace Passes.API.RegisterPass
{   
    // Definicija consumer side on MassTranist (Message Broker)
    public sealed class ContractSignedEventConsumerDefinition : ConsumerDefinition<ContractSignedEventConsumer>
    {   
        // Mora metoda zbog interface
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<ContractSignedEventConsumer> consumerConfigurator, IRegistrationContext context)
        {   
            // Kada consumer baci exception, MassTransit automatski ponavlja obradu eventa iz Message Broker u 3 pokusaja i pauzira 1s izmedju svakog pokusaja
            endpointConfigurator.UseMessageRetry(retryConfigurator => retryConfigurator.Interval(3, FromSeconds(1)));

            // Ako posle gore navedenog retry event i dalje nije uspesno primljen, MassTransit radi ponovno zakazivanje slanja eventa. Ovo je korisno ako je servis nedostupan, baza u problemu...
            endpointConfigurator.UseScheduledRedelivery(retryConfigurator => retryConfigurator.Intervals(FromMinutes(5), FromHours(3), FromHours(8), FromDays(1)));

            // Outbox pattern - kada consumer primi event, onda zeli da posalje mozda novi event u Message Broker, ali tako sto prvo upise taj event u Outbox table u bazu, a kada je transakcija uspesna, Outbox dispatcher salje event iz baze u Message Broker
            endpointConfigurator.UseEntityFrameworkOutbox<PassesDbContext>(context); // u PassesDbContext sam dodao Outbox pattern for EventBus

            base.ConfigureConsumer(endpointConfigurator, consumerConfigurator, context);
        }
    }
}
