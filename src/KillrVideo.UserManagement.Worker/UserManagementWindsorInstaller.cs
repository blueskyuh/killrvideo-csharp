﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KillrVideo.UserManagement.Messages.Commands;
using KillrVideo.Utils.Nimbus;

namespace KillrVideo.UserManagement.Worker
{
    /// <summary>
    /// Castle Windsor installer for installing all the components needed by the UserManagement worker.
    /// </summary>
    public class UserManagementWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<NimbusAssemblyConfig>()
                         .Instance(NimbusAssemblyConfig.FromTypes(typeof(UserManagementWindsorInstaller), typeof(CreateUser))));

            // Register the UserManagement components as singletons so their state can be reused (prepared statements)
            container.Register(
                Classes.FromAssemblyContaining<UserWriteModel>().Pick()
                       .WithServiceFirstInterface().LifestyleSingleton());
        }
    }
}
