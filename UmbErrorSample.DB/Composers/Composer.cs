using Microsoft.EntityFrameworkCore;
using UmbErrorSample.DB.Contexts;
using UmbErrorSample.DB.Migrations;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace UmbErrorSample.DB.Composers
{
    public class Composer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddNotificationAsyncHandler<UmbracoApplicationStartedNotification, MovieMigration>();
            builder.Services.AddUmbracoDbContext<MovieContext>((serviceProvider, options) =>
            {
                options.UseSqlServer("name=ConnectionStrings:externalDbDSN");
            });
        }
    }
}
