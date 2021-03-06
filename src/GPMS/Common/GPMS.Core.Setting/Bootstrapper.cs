﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using GPMS.Core.IRepositories;
using GPMS.Core.IServices;
using GPMS.Core.Repositories;
using GPMS.Core.Services;
using NHibernate;

namespace GPMS.Setting
{
    public class Bootstrapper
    {
        /// <summary>
        /// 注册组件
        /// </summary>
        /// <param name="container">容器</param>
        /// <param name="sessionFactory">数据库会话工厂</param>
        public void RegisterComponents(IWindsorContainer container, ISessionFactory sessionFactory)
        {
            container.Register(
                Component.For<ISession>()
                    .UsingFactoryMethod(k => sessionFactory.GetCurrentSession()
                    ));
            RegisterRepositories(container);
            RegisterSerives(container);
        }

        /// <summary>
        /// 注册数据操作层实现
        /// </summary>
        /// <param name="container"></param>
        private void RegisterRepositories(IWindsorContainer container)
        {
            //系统配置
            container.Register(
                Component.For<ISystemConfigRepository>()
                .ImplementedBy<SystemConfigRepository>()
                .LifeStyle.PerWebRequest
                );

            //用户
            container.Register(
                Component.For<IUserBasicInfoRepository>()
                .ImplementedBy<UserBasicInfoRepository>()
                .LifeStyle.PerWebRequest
                );
            //首页轮询
            container.Register(
               Component.For<ICarouselRepository>()
               .ImplementedBy<CarouselRepository>()
               .LifeStyle.PerWebRequest
               );
            //文件
            container.Register(
               Component.For<IAttachmentInfoRepository>()
               .ImplementedBy<FileInfoRepository>()
               .LifeStyle.PerWebRequest
               );
        }

        /// <summary>
        /// 注册服务层组件
        /// </summary>
        /// <param name="container"></param>
        private void RegisterSerives(IWindsorContainer container)
        {
            //系统配置
            container.Register(
                Component.For<ISystemConfigService>()
                .ImplementedBy<SystemConfigService>()
                .LifeStyle.PerWebRequest
                );

            //用户
            container.Register(
                Component.For<IUserService>()
                    .ImplementedBy<UserService>()
                    .LifeStyle.PerWebRequest
                );
            //首页轮询
            container.Register(
               Component.For<ICarouselService>()
                   .ImplementedBy<CarouselService>()
                   .LifeStyle.PerWebRequest
               );
            //文件
            container.Register(
                Component.For<IFileInfoService>()
                    .ImplementedBy<FileInfoService>()
                    .LifeStyle.PerWebRequest
                );  
        }
    }
}
